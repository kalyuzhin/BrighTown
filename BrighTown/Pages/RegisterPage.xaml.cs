using BrighTown.ViewModel;
using CommunityToolkit.Maui.Views;

namespace BrighTown.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(RegisterViewModel viewModel)
    {
        InitializeComponent();
        //BindingContext = viewModel;
    }

    public void PressRegisterButton(object sender, EventArgs e)
    {
        // if (Connectivity.Current != NetworkAccess.Internet)
        // {
        //     return;
        // }

        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            this.DisplayAlert("Упс!", "К сожалению вы не подключены к интернету...","Повторить попытку");
            return;
        }
        
        this.ShowPopup(new RegisterPopUp());
    } 
    
    public void PressLoginButton(object sender, EventArgs e)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            this.DisplayAlert("Упс!", "К сожалению вы не подключены к интернету...","Повторить попытку");
            return;
        }
        
        this.ShowPopup(new LoginPopUp());
    }
}