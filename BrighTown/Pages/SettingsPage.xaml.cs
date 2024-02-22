namespace BrighTown.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    private void ClickOnSettingsButton(object sender, EventArgs e) // ��������� ������� �� ������ "���������"
    {
        Shell.Current.GoToAsync("..");
        App.user = null;
    }
}