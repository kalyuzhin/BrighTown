using System.Diagnostics;

namespace BrighTown.Pages;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
    }


    private void ClickOnSettingsButton(object sender, EventArgs e) // ��������� ������� �� ������ "���������"
    {
        Routing.RegisterRoute("OpenSettings", typeof(SettingsPage));
        Shell.Current.GoToAsync("OpenSettings");
    }


    private async void ClickOnExitButton(object sender, EventArgs e) // ��������� ������� �� ������ "���������"
    {
        App.user = null;
        await Shell.Current.GoToAsync($"//{nameof(NewAuthenticationPage)}");
    }
}