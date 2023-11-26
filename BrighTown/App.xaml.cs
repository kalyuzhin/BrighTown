namespace BrighTown;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
        //MainPage = new AuthenticationPage(new NewAuthenticationViewModel(Connectivity.Current));
        //MainPage = new NewAuthenticationPage();
    }
}