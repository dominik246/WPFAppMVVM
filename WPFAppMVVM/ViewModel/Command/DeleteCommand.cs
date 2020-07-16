using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFAppMVVM.ViewModel.Command
{
    public class DeleteCommand : ICommand
    {
        private readonly IUserViewModel _viewModel;
        public DeleteCommand(IUserViewModel viewModel)
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
            if (int.TryParse(parameter.ToString(), out int userId))
                await _viewModel.DeleteData(userId);
            else
                MessageBox.Show("Select a field first.");
        }
    }
}
