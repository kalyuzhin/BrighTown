using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.Text.Json;
using System.Text;
using BrighTown.Services;
//using ThreadNetwork;

namespace BrighTown.Pages;

public partial class RegisterPage : ContentPage
{
    FrontRequests front = new FrontRequests();
    public RegisterPage()
    {
        InitializeComponent();
        //BindingContext = viewModel;
    }

    private void AddUser(string Email, string Username, string Password, string FirstName, string SecondName)
    {
       Random random = new Random();
        // id пусть генерируется рандомно пока что
        int Id = random.Next();
        front.Regist(Id, Email, Username, Password, FirstName, SecondName);
    }


  
    //private void CreateTable()
    //{
    //    using (var connection = new SqliteConnection("Data Source=database.db"))
    //    {
    //        connection.Open();
    //        string createTableQuery = "CREATE TABLE IF NOT EXISTS MyTable (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Age INTEGER)";
    //        SqliteCommand command = new SqliteCommand(createTableQuery, connection);
    //        command.ExecuteNonQuery();
    //    }
    //}

    private async void PressRegisterButton(object sender, EventArgs e)
    {
        if (IsBusy) return;

        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Упс!", "К сожалению вы не подключены к интернету...",
                "Повторить попытку");
            return;
        }

        try
        {
            IsBusy = true;
            AddUser(Mail.Text, UserName.Text, UserPassword.Text, FirstName.Text, SecondName.Text);
            await Shell.Current.GoToAsync("..");
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