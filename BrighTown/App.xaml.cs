using BrighTown.Models;

namespace BrighTown;

public partial class App : Application
{
    public static User user;

    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
        //MainPage = new AuthenticationPage(new NewAuthenticationViewModel(Connectivity.Current));
        //MainPage = new NewAuthenticationPage();
    }
}