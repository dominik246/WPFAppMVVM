using DataLibrary;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using WPFAppMVVM.Model;
using WPFAppMVVM.View;
using WPFAppMVVM.ViewModel.Command;

namespace WPFAppMVVM.ViewModel
{
    public class UserViewModel
    {
        public IList<User> UserList { get; set; }

        private readonly IDataAccess _dataAccess;
        //public UpdateCommand UpdateCommand { get; set; }
        public UserViewModel(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

            UserList = GetData().Result;

            //UpdateCommand = new UpdateCommand(this);
        }

        private async Task<IList<User>> GetData()
        {
            const string sql = "select * from [dbo].[Users]";
            return await _dataAccess.LoadData<User, dynamic>(sql, new { }, Environment.GetEnvironmentVariable("connectionString")).ConfigureAwait(false);
        }

        //public async Task InsetData(string lastName, string firstName, string city, string state, string country)
        //{
        //    string sql = "insert into [dbo].[Users] (LastName, FirstName, City, State, Country)" +
        //        $"values ({lastName}, {firstName}, {city}, {state}, {country});";
        //    await _dataAccess.SaveData(sql, new { }, Environment.GetEnvironmentVariable("connectionString"));
        //}

        //public async Task<IList<User>> UpdateData(int userId, string lastName, string firstName, string city, string state, string country)
        //{
        //    string sql = $"update [dbo].[Users] set LastName={lastName}, FirstName={firstName}, City={city}, State={state}, Country={country}" +
        //        $"where UserId={userId}";
        //    return await _dataAccess.LoadData<User, dynamic>(sql, new { }, Environment.GetEnvironmentVariable("connectionString"));
        //}
    }
}
