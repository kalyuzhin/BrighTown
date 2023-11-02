using BrighTown.Pages;
using BrighTown.ViewModels;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BrighTown.ViewModels;

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
    async Task DisplayRegisterPopUp()
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
    async Task DisplayLoginPopUp()
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
            var currentPage = Shell.Current.CurrentPage;
            Console.WriteLine(currentPage.ToString());
            if (currentPage is AuthenticationPage)
            {
                await currentPage.ShowPopupAsync(popup);
            }
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

    // [RelayCommand]
    // async Task Login()
    // {
    //     Shell.Current.GoToAsync($"//{nameof(MapPage)}");
    // }
}