using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrighTown.ViewModels;
using System.Text.RegularExpressions;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using BrighTown.Models;
using Newtonsoft.Json;

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

        IsBusy = true;

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
            //Получение данных из полей ввода
            string Username = UsernameEntry.Text;
            // string firstName = FirstNameEntry.Text;
            // string secondName = SecondNameEntry.Text;
            string Password = PasswordEntry.Text;
            string Email = EmailEntry.Text;
            var data = new
            {
                username = Username,
                password = Password,
                email = Email
            };

            using (HttpClient httpClient = new HttpClient())
            {
                var url = "http://10.0.2.2:5280/register";

                var requestData = new Dictionary<string, string>
                {
                    { "username", Username },
                    { "password", Password },
                    { "email", Email }
                };

                var content = new
                    StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, content);
                var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<User>>();
                if (responseContent.Success == true)
                {
                    await Shell.Current.GoToAsync($"..");
                    await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
                    await Shell.Current.DisplayAlert("Ура!", "Вы успешно зарегистрированы!", "OK");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Упс!", "К сожалению произошла ошибка...", "ОК");
                }
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