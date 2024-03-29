using BrighTown.ViewModels;
using System.Text;
using System.Threading.Tasks;
using BrighTown.ViewModels;
using System.Text.RegularExpressions;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using BrighTown.Models;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;


namespace BrighTown.Pages;

public partial class NewAuthenticationPage : ContentPage
{
    public NewAuthenticationPage(NewAuthenticationViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;


        if (Preferences.Default.Get("theme", Application.Current.RequestedTheme.ToString() == "Dark"))
        {
            Application.Current.UserAppTheme = AppTheme.Dark;
        }
        else
        {
            Application.Current.UserAppTheme = AppTheme.Light;
        }
    }

    private async void Login(object sender, EventArgs e)
    {
        EntryBtn.Text = "Входим...";
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
            // string firstName = FirstNameEntry.Text;
            // string secondName = SecondNameEntry.Text;
            string Password = PasswordEntry.Text;
            string Login = LoginEntry.Text;
            // var data = new
            // {
            //     login = Login,
            //     password = Password,
            // };

            using (HttpClient httpClient = new HttpClient())
            {
                string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                    ? "http://10.0.2.2:5280/"
                    : "http://localhost:5280/";
                var url = baseUrl + "login";

                var requestData = new Dictionary<string, string>
                {
                    { "email", Login.ToLower() },
                    { "username", Login.ToLower() },
                    { "password", Password }
                };

                var content = new
                    StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, content);
                var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<User>>();
                if (responseContent.Success)
                {
                    App.user = responseContent.Data;


                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    string text = "Вход в аккаунт выполнен успешно!";
                    ToastDuration duration = ToastDuration.Short;
                    double fontSize = 14;
                    var toast = Toast.Make(text, duration, fontSize);
                    await toast.Show(cancellationTokenSource.Token);


                    await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
                    LoginEntry.Text = "";
                    PasswordEntry.Text = "";
                }
                else
                {
                    await Shell.Current.DisplayAlert("Упс!", $"{responseContent.Message}", "ОК");
                }
            }
            //await Shell.Current.Navigation.PushModalAsync(new MapPage());
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Упс!", "К сожалению произошла ошибка...", "ОК");
        }
        finally
        {
            EntryBtn.Text = "Вход";
            IsBusy = false;
        }
    }

    private async void MoveToRegisterPage(object sender, EventArgs e)
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
            //await Shell.Current.Navigation.PushModalAsync(new MapPage());
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Упс!", $"{ex}", "ОК");
        }
        finally
        {
            IsBusy = false;
        }
    }
}