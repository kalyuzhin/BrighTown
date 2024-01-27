using BrighTown.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BrighTown.Models;
using BrighTown.Pages;

namespace BrighTown.ViewModels;

public partial class RegisterViewModel : BaseViewModel
{
    private readonly IConnectivity _connectivity;

    //[ObservableProperty] private string _email;
    [ObservableProperty] private string _username;
    [ObservableProperty] private string _password;

    private readonly ILoginRepository _loginService = new LoginService();


    [RelayCommand]
    public async void Register()
    {
        if (IsBusy) return;

        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Упс!", "К сожалению вы не подключены к интернету...",
                "Повторить попытку");
            return;
        }

        try
        {
            // if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password) &&
            //     !string.IsNullOrWhiteSpace(Username))
            if (!string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Username))
            {
                User user = await _loginService.Register(Username, Password); //Email, Username, Password);
                // if (Preferences)
                App.user = user;
                await Shell.Current.GoToAsync(nameof(MapPage));
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Упс!", "К сожалению произошла ошибка...", "ОК");
        }
        finally
        {
            IsBusy = false;
        }
    }
}