using DataLibrary;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using WPFAppMVVM.Model;
using WPFAppMVVM.View;
using WPFAppMVVM.ViewModel.Command;

namespace WPFAppMVVM.ViewModel
{
    public class UserViewModel : IUserViewModel
    {
        public UpdateCommand UpdateCommand { get; set; }
        public InsertCommand InsertCommand { get; set; }
        public DeleteCommand DeleteCommand { get; set; }
        private readonly IDataAccess _dataAccess;
        public UserViewModel()
        {
            _dataAccess = new DataAccess();

            UpdateCommand = new UpdateCommand(this);
            InsertCommand = new InsertCommand(this);
            DeleteCommand = new DeleteCommand(this);
        }

        private ObservableCollection<User> userList;
        public ObservableCollection<User> UserList
        {
            get
            {
                return userList ??= new ObservableCollection<User>(GetData().Result);
            }
            set
            {
                userList = value;
            }
        }

        private async Task<List<User>> GetData()
        {
            string sql = "select * from [dbo].[Users]";
            return await _dataAccess.LoadData<User, dynamic>(sql, new { }, Environment.GetEnvironmentVariable("connectionString")).ConfigureAwait(false);
        }

        public async Task InsertData(string lastName, string firstName, string city, string state, string country)
        {
            string sql = "insert into [dbo].[Users] (LastName, FirstName, City, State, Country) " +
                $"values ('{lastName}', '{firstName}', '{city}', '{state}', '{country}');";
            await _dataAccess.SaveData(sql, new { }, Environment.GetEnvironmentVariable("connectionString"));

            UserList.Add((await GetData())[^1]);
        }

        public async Task UpdateData(int userId, string lastName, string firstName, string city, string state, string country)
        {
            string sql = $"update [dbo].[Users] set LastName='{lastName}', FirstName='{firstName}', " +
                $"City='{city}', State='{state}', Country='{country}' " +
                $"where UserId={userId};";
            await _dataAccess.SaveData<dynamic>(sql, new { }, Environment.GetEnvironmentVariable("connectionString"));
        }

        public async Task DeleteData(int userId)
        {
            string sql = $"delete from [dbo].Users where UserId='{userId}'";
            await _dataAccess.DeleteData(sql, new { }, Environment.GetEnvironmentVariable("connectionString"));

            UserList.RemoveAt(UserList.IndexOf(UserList.First(u => u.UserId == userId)));
        }
    }
}
