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
            await Shell.Current.DisplayAlert("Упс!", "Некорректный логин или пароль.",
                "Повторить попытку");
            return;
        }
        else
            try
           {
            //using (var connection = new SqliteConnection("Data Source=C:\\Users\\1111\\Dropbox\\ПК (3)\\Documents\\GitHub\\BrighTown\\Backend\\database.db")) // работает только если путь полностью от диска прописывать
            using (var connection = new SqliteConnection("Data Source=database.db"))
            {
                SQLitePCL.Batteries.Init();
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT COUNT(*) FROM TableName WHERE Column1 = @Value1 AND Column2 = @Value2";
                    command.Parameters.AddWithValue("@Value1", LoginEntry.Text);
                    command.Parameters.AddWithValue("@Value2", PasswordEntry.Text);
                    // Добавить параметры и значения для каждого столбца таблицы, которые хочу проверить.

                    // Выполнить запрос к базе данных и получить результат.
                    var result = (long)command.ExecuteScalar();

                    // Проверить результат и принять соответствующие действия.
                    if (result > 0)
                    {
                        // Информация существует в базе данных.
                        IsBusy = true;
                        await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
                    }
                    else
                    {
                        // Информация не существует в базе данных.
                        await Shell.Current.DisplayAlert("Упс!", "Некорректный логин или пароль.",
                    "Повторить попытку");
                        return;
                    }
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

        //try
        //    {
        //        IsBusy = true;
        //        await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
        //        //await Shell.Current.Navigation.PushModalAsync(new MapPage());
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    finally
        //    {
        //    }
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