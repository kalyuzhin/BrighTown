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

    public void RegisterPopUpFunc(object sender, EventArgs e)
    {
        // if (Connectivity.Current != NetworkAccess.Internet)
        // {
        //     return;
        // }
        this.ShowPopup(new RegisterPopUp());
    } 
}