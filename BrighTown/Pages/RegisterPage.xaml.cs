using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrighTown.ViewModels;
using System.Text.RegularExpressions;
using BrighTown.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http;

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

        // Получение данных из полей ввода
        string username = UsernameEntry.Text;
        string firstName = FirstNameEntry.Text;
        string secondName = SecondNameEntry.Text;
        string password = PasswordEntry.Text;
        string email = EmailEntry.Text;

        // Создание объекта JSON для отправки на сервер
        var user = new JObject
    {
        { "Username", username },
        { "FirstName", firstName },
        { "SecondName", secondName },
        { "Password", password },
        { "Email", email }
    };

        //if (EmailEntry.TextColor == Colors.Red || string.IsNullOrWhiteSpace(UsernameEntry.Text) ||
        //    string.IsNullOrWhiteSpace(PasswordEntry.Text) || PasswordConfirmEntry.TextColor == Colors.Red)
        //{
        //    await Shell.Current.DisplayAlert("Ошибка!", "Заполните все поля корректно...", "ОК");
        //    return;
        //}
        using (HttpClient httpClient = new HttpClient())
        {
            try
            {
                IsBusy = true;

               

                var response = await httpClient.PostAsync("http://localhost:1337/api/users/Register", new StringContent(user.ToString(), Encoding.UTF8, "application/json"));
                await Shell.Current.GoToAsync($"..");
                await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
                //await Ok("Ура!", "Вы успешно зарегистрированы!", "OK");
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
}