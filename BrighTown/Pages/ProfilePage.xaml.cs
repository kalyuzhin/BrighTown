using System.Diagnostics;
using CommunityToolkit.Maui.Alerts;
using static BrighTown.Pages.UserIconPopUp;
using CommunityToolkit.Maui.Views;
namespace BrighTown.Pages;

public partial class ProfilePage : ContentPage
{
    
   
    
    public ProfilePage()
    {
        InitializeComponent();
        
        TapGestureRecognizer tapGesture = new TapGestureRecognizer
        {
            NumberOfTapsRequired = 1
        };
        
       
        tapGesture.Tapped += (s, e) =>
        {
            this.ShowPopup(new UserIconPopUp());
           // Shell.Current.DisplayAlert("!", "Icon", "ok");
           UserIcon.Source = ImagetSource;
        };
        UserIcon.GestureRecognizers.Add(tapGesture);
        



    }


    private void ClickOnSettingsButton(object sender, EventArgs e) // ��������� ������� �� ������ "���������"
    {
        
        Shell.Current.GoToAsync("OpenSettings");
    }


    private async void ClickOnExitButton(object sender, EventArgs e) // ��������� ������� �� ������ "���������"
    {
        App.user = null;
        //new ShellNavigationState(nameof(MapPage));
        //await Shell.Current.DisplayAlert("!", Shell.Current.Navigation.NavigationStack.Count().ToString(), "OK");
       // await Shell.Current.GoToAsync(nameof(MapPage));
        await Shell.Current.GoToAsync($"//{nameof(NewAuthenticationPage)}");

       
        
        
        
    }
    
}