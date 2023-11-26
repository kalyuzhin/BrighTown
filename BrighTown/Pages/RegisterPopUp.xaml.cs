using CommunityToolkit.Maui.Views;

namespace BrighTown.Pages;

public partial class RegisterPopUp : Popup
{
    public RegisterPopUp()
    {
        InitializeComponent();
    }

    private async void Register(object sender, EventArgs e)
    {
        await CloseAsync();
        await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
    }
}