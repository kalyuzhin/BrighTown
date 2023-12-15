using BrighTown.ViewModels;
using Microsoft.Data.Sqlite;
using BrighTown.Services;
namespace BrighTown.Pages;


    public partial class NewAuthenticationPage : ContentPage
    {
        public NewAuthenticationPage(NewAuthenticationViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

     
        public async void Login(object sender, EventArgs e)
        {
            if (IsBusy) return;
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Упс!", "К сожалению вы не подключены к интернету...",
                    "Повторить попытку");
                return;
            }

        if (string.IsNullOrEmpty(LoginEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text)) // Проверка ввода пользователем
        {
            await Shell.Current.DisplayAlert("Упс!", "Некорректный логин или пароль, или вы не зарегистрированы.",
                "Повторить попытку");
            return;
        }
        else
            try
            {
                FrontRequests front = null;
                front.Login(LoginEntry.Text, PasswordEntry.Text);
                //using (var connection = new SqliteConnection("Data Source=C:\\Users\\1111\\Dropbox\\ПК (3)\\Documents\\GitHub\\BrighTown\\Backend\\database.db")) // работает только если путь полностью от диска прописывать
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

        private async void MoveToRegisterPage(object sender, EventArgs e)
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                Routing.RegisterRoute("RegisterPage", typeof(RegisterPage));
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