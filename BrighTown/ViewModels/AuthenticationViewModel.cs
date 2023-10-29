using BrighTown.Pages;
using BrighTown.ViewModels;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BrighTown.ViewModel;

public partial class AuthenticationViewModel : BaseViewModel
{
    [ObservableProperty] private string _userName;
    [ObservableProperty] private string _password;

    IConnectivity _connectivity;

    public AuthenticationViewModel(IConnectivity connectivity)
    {
        this._connectivity = connectivity;
    }


    [RelayCommand]
    async Task RegisterPopUp()
    {
        if (IsBusy)
        {
            return;
        }

        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Упс!", "К сожалению вы не подключены к интернету...",
                "Повторить попытку");
            return;
        }

        try
        {
            IsBusy = true;
            var popup = new RegisterPopUp();
            await Shell.Current.ShowPopupAsync(popup);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка!", $"{ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task LoginPopUp()
    {
        if (IsBusy)
        {
            return;
        }

        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Упс!", "К сожалению вы не подключены к интернету...",
                "Повторить попытку");
            return;
        }

        try
        {
            IsBusy = true;
            var popup = new LoginPopUp();
            await Shell.Current.ShowPopupAsync(popup);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка!", $"{ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}