using System.Diagnostics;

namespace BrighTown.Pages;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
        DisplayStack();
    }


    private void ClickOnSettingsButton(object sender, EventArgs e) // ��������� ������� �� ������ "���������"
    {
        
        Shell.Current.GoToAsync("OpenSettings");
    }


    private async void ClickOnExitButton(object sender, EventArgs e) // ��������� ������� �� ������ "���������"
    {
        App.user = null;
        
      
       
       
        await Shell.Current.GoToAsync($"//{nameof(NewAuthenticationPage)}");

       
        
        
        
    }
    protected internal void DisplayStack()
    {
        var stackLabel = new Label();
        if (Application.Current?.MainPage is NavigationPage navPage)
        {
            // выводим стек навигации
            stackLabel.Text = "";
            foreach (Page p in navPage.Navigation.NavigationStack)
            {
                stackLabel.Text = $"{p.Title}\n{stackLabel.Text}";
            }
        }
    }
}