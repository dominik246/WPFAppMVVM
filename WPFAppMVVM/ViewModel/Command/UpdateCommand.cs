using System;
using System.Windows;
using System.Windows.Input;

namespace WPFAppMVVM.ViewModel.Command
{
    public class UpdateCommand : ICommand
    {
        private readonly IUserViewModel _viewModel;
        public UpdateCommand(IUserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var arr = (object[])parameter;
            if (int.TryParse(arr[0].ToString(), out int userId))
                await _viewModel.UpdateData(userId, arr[1].ToString(), arr[2].ToString(), arr[3].ToString(), arr[4].ToString(), arr[5].ToString());
            else
                MessageBox.Show("You must click a field first.");
        }
    }
}
