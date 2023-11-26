using CommunityToolkit.Maui.Views;

namespace BrighTown.Pages;

public partial class LoginPopUp : Popup
{
    public LoginPopUp()
    {
        InitializeComponent();
        BindingContext = this;
    }


    private async void Login(object sender, EventArgs e)
    {
        await CloseAsync();
        await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
    }

    // public bool PressLoginPopUpButton(object sender, EventArgs e)
    // {
    //     return true;
    // }
}