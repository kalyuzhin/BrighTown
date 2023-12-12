using BrighTown.Pages;
using BrighTown.ViewModels;

namespace BrighTown;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        //MainPage = new AuthenticationPage(new NewAuthenticationViewModel(Connectivity.Current));
        //MainPage = new NewAuthenticationPage();
        var account = Microsoft.Maui.Storage.Preferences.ContainsKey("UserAccount") ? Microsoft.Maui.Storage.Preferences.ContainsKey("UserAccount").ToString() : "";
        var password = Microsoft.Maui.Storage.Preferences.ContainsKey("UserPassword") ? Microsoft.Maui.Storage.Preferences.ContainsKey("UserPassword").ToString() : "";

        //MainPage = new AuthenticationPage(account, password, new NewAuthenticationViewModel(Connectivity.Current));

        //MainPage = new AppShell(account, password, new NewAuthenticationViewModel(Connectivity.Current));
        MainPage = new AppShell();
        //MainPage = new FavouritesPage();
    }
}