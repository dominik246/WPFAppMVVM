﻿using System;
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
            var arr = (object[])parameter;
            await _viewModel.UpdateData((int)arr[0], arr[1].ToString(), arr[2].ToString(), arr[3].ToString(), arr[4].ToString(), arr[5].ToString());
        }
    }
}
