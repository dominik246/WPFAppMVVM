using System.Collections.ObjectModel;
using System.Threading.Tasks;

using WPFAppMVVM.Model;
using WPFAppMVVM.ViewModel.Command;

namespace WPFAppMVVM.ViewModel
{
    public interface IUserViewModel
    {
        InsertCommand InsertCommand { get; set; }
        UpdateCommand UpdateCommand { get; set; }
        ObservableCollection<User> UserList { get; set; }

        Task InsertData(string lastName, string firstName, string city, string state, string country);
        Task UpdateData(int userId, string lastName, string firstName, string city, string state, string country);
        Task DeleteData(int userId);
    }
}