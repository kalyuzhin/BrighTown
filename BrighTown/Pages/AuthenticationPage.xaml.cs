using BrighTown.ViewModel;
using CommunityToolkit.Maui.Views;

namespace BrighTown.Pages;

public partial class AuthenticationPage : ContentPage
{
    public AuthenticationPage(AuthenticationViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    public AuthenticationPage() // костыль для возврата на регистрацию
    {
        InitializeComponent();
    }

    private void DisplayRegisterPopUp(object sender, EventArgs e)
    {
        if (IsBusy)
        {
            return;
        }

        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            this.DisplayAlert("Упс!", "К сожалению вы не подключены к интернету...", "Повторить попытку");
            return;
        }

        Shell.Current.CurrentPage.ShowPopup(new RegisterPopUp());
        //this.ShowPopup();
    }

    private void DisplayLoginPopUp(object sender, EventArgs e)
    {
        if (IsBusy)
        {
            return;
        }

        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            this.DisplayAlert("Упс!", "К сожалению вы не подключены к интернету...", "Повторить попытку");
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