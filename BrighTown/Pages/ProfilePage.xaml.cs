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


    private void ClickOnExitButton(object sender, EventArgs e) // ��������� ������� �� ������ "���������"
    {
        App.user = null;
        Shell.Current.GoToAsync($"//{nameof(NewAuthenticationPage)}");
    }
}