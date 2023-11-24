using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrighTown.ViewModels;

namespace BrighTown.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    async void PressRegisterButton(object sender, EventArgs e)
    {
        if (IsBusy)
        {
            return;
        }

        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Упс!", "К сожалению вы не подключены к интернету...",
                "Повторить попытку");
            return;
        }

        try
        {
            IsBusy = true;
            await Shell.Current.GoToAsync($"..");
            Shell.Current.DisplayAlert("Ура!", "Вы успешно зарегистрированы!", "OK");
            Shell.Current.GoToAsync($"//{nameof(MapPage)}");
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