using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrighTown.ViewModels;
using System.Text.RegularExpressions;

namespace BrighTown.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private void EmailEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        string text = e.NewTextValue;
        if (Regex.IsMatch(text, @".+\@\w+\.\w+"))
        {
            EmailEntry.TextColor = Colors.Black;
        }
        else
        {
            EmailEntry.TextColor = Colors.Red;
        }
    }

    private void PasswordConfirmEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        string text = e.NewTextValue;
        if (text != PasswordEntry.Text)
        {
            PasswordConfirmEntry.TextColor = Colors.Red;
        }
        else
        {
            PasswordConfirmEntry.TextColor = Colors.Black;
        }
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

        if (EmailEntry.TextColor == Colors.Red || string.IsNullOrWhiteSpace(UsernameEntry.Text) ||
            string.IsNullOrWhiteSpace(PasswordEntry.Text) || PasswordConfirmEntry.TextColor == Colors.Red)
        {
            await Shell.Current.DisplayAlert("Ошибка!", "Заполните все поля корректно...", "ОК");
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
}