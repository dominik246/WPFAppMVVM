using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WPFAppMVVM.ViewModel.Command
{
    public class UpdateCommand : ICommand
    {
        private readonly UserViewModel _viewModel;
        public UpdateCommand(UserViewModel viewModel)
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
            //await _viewModel.UpdateData(parameter);
        }
    }
}
