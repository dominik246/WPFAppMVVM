using System.Windows;

using WPFAppMVVM.ViewModel;

namespace WPFAppMVVM.View
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
            UserViewModel vm = new UserViewModel();
            DataContext = vm;
        }
    }
}
