using DataLibrary;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using WPFAppMVVM.View;
using WPFAppMVVM.ViewModel;

namespace WPFAppMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private readonly ServiceProvider _serviceProvider;

        //public App()
        //{
        //    var serviceCollection = new ServiceCollection();
        //    ConfigureServices(serviceCollection);
        //    _serviceProvider = serviceCollection.BuildServiceProvider();
        //}

        //private void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddSingleton<IDataAccess, DataAccess>();
        //}

        internal void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainPage
            {
                DataContext = new UserViewModel()
            };
            mainWindow.Show();
        }
    }
}
