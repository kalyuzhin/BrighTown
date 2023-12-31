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