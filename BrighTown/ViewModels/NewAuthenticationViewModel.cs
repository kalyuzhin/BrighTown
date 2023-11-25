using BrighTown.Pages;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BrighTown.ViewModels;

public partial class NewAuthenticationViewModel : BaseViewModel
{
    [ObservableProperty] private string _userName;
    [ObservableProperty] private string _userPassword;

    IConnectivity _connectivity;

    public NewAuthenticationViewModel(IConnectivity connectivity)
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
            //Console.WriteLine(currentPage.ToString());
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


    [RelayCommand]
    async Task Login()
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
            // await Shell.Current.Navigation.PushAsync(new MapPage());
            await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
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

    [RelayCommand]
    async Task Register()
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
            await Shell.Current.GoToAsync($"..");
            await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
            await Shell.Current.DisplayAlert("Ура!", "Вы успешно зарегистрированы!", "OK");
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

    // [RelayCommand]
    // async Task Login()
    // {
    //     Shell.Current.GoToAsync($"//{nameof(MapPage)}");
    // }
}