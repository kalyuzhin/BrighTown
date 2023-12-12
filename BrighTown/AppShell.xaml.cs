using BrighTown.Pages;
using BrighTown.ViewModels;

namespace BrighTown;

public partial class AppShell : Shell
{
    public AppShell()
    { 
        InitializeComponent();
    }
    public AppShell(string account, string password, NewAuthenticationViewModel viewModel)
    {
        InitializeComponent();
        //BindingContext = viewModel;
        //viewModel.UserPassword = password;
        //viewModel.UserName = account;
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
    }
}