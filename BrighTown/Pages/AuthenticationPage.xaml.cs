using BrighTown.ViewModels;
using CommunityToolkit.Maui.Views;

namespace BrighTown.Pages;

public partial class AuthenticationPage : ContentPage
{


    public AuthenticationPage(NewAuthenticationViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    //public AuthenticationPage(string account, string password, NewAuthenticationViewModel viewModel)
    //{
    //    InitializeComponent();
    //    BindingContext = viewModel;
    //    viewModel.UserPassword = password;
    //    viewModel.UserName = account;
    //    Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
    //    Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
    //}

    public AuthenticationPage() // костыль для возврата на регистрацию
    {
        InitializeComponent();
    }

    private async void DisplayRegisterPopUp(object sender, EventArgs e)
    {
        if (IsBusy) return;

        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            DisplayAlert("Упс!", "К сожалению вы не подключены к интернету...", "Повторить попытку");
        }

        //Shell.Current.CurrentPage.ShowPopup(new RegisterPopUp());
        //this.ShowPopup();
        //await this.ShowPopupAsync(new RegisterPopUp());
    }

    private void DisplayLoginPopUp(object sender, EventArgs e)
    {
        if (IsBusy) return;

        //using (var db = new DataContext())
        //{
        //    User user = new User { Name = "John", Email = "john@example.com" };
        //    db.Users.Add(user);
        //    db.SaveChanges();
        //}

        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            DisplayAlert("Упс!", "К сожалению вы не подключены к интернету...", "Повторить попытку");
            return;
        }

        this.ShowPopup(new LoginPopUp());
    }


    //-----------Заглушка----------------------//
    // private void ClickOnMapButton(object sender, EventArgs e)
    // {
    //     Navigation.PushModalAsync(new MapPage(), true);
    // }
}