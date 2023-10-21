using BrighTown.Pages;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BrighTown.ViewModel;

public partial class RegisterViewModel : ObservableObject
{ 
    IConnectivity _connectivity;

    public RegisterViewModel(IConnectivity connectivity)
    {
        this._connectivity = connectivity;
    }
    
    
    [RelayCommand]
    async Task RegisterPopUp()
    {
        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Упс!", "К сожалению вы не подключены к интернету...","Повторить попытку");
            return;
        }

        var popup = new RegisterPopUp();
        Shell.Current.CurrentPage.ShowPopup(popup);
    }
    
    
}