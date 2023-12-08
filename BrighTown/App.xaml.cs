using BrighTown.Pages;
using BrighTown.ViewModels;

namespace BrighTown
{
    
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
           // Application.Current.UserAppTheme = AppTheme.Light; // Fixing app theme
            MainPage = new AppShell();
            //MainPage = new AuthenticationPage(new NewAuthenticationViewModel(Connectivity.Current));
            //MainPage = new NewAuthenticationPage();
        }
    }
}