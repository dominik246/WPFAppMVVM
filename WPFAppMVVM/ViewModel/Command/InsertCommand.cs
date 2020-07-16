using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFAppMVVM.Model;

namespace WPFAppMVVM.ViewModel.Command
{
    public class InsertCommand : ICommand
    {
        private readonly IUserViewModel _viewModel;
        public InsertCommand(IUserViewModel viewModel)
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
            if (arr.Any(i => i.ToString()?.Length != 0))
                await _viewModel.InsertData(arr[1].ToString(), arr[2].ToString(), arr[3].ToString(), arr[4].ToString(), arr[5].ToString());
            else
                MessageBox.Show("All fields must be filled.");
        }
    }
}
