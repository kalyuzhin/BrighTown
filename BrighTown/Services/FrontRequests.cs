using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Maui.Controls;
using Microsoft.Data.Sqlite;
using BrighTown.Pages;
using Microsoft.Maui.ApplicationModel.Communication;
using System.Diagnostics;
using System.Text.Json;
using System.Xml.Linq;
using BrighTown.Models;

namespace BrighTown.Services;

    public class FrontRequests
{
    public FrontRequests() { }

    private static HttpClient _client = new HttpClient();

    //private static JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
    //{
    //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    //    WriteIndented = true
    //};
    // Проверяет пользователя в базе данных
    async public void Login(string login, string password)
    {
        using (var connection = new SqliteConnection("Data Source=database.db"))
        {
            SQLitePCL.Batteries.Init();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM Users WHERE Column1 = @Value1 AND Column2 = @Value2";
                command.Parameters.AddWithValue("@Value1", login);
                command.Parameters.AddWithValue("@Value2", password);
                // Добавить параметры и значения для каждого столбца таблицы, которые хочу проверить.

                // Выполнить запрос к базе данных и получить результат.
                var result = (long)command.ExecuteScalar();

                // Проверить результат и принять соответствующие действия.
                if (result > 0)
                {
                    // Информация существует в базе данных.
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

    public async void Regist(int Id, string Email, string Username, string Password, string FirstName, string SecondName)
    {
        using (var connection = new SqliteConnection("Data Source=database.db"))
        {
            SQLitePCL.Batteries.Init();
            connection.Open();
            try
            {
            string sql = "INSERT INTO Users(Id, Email, Username, Password, FirstName, SecondName) VALUES(@Id, @Email, @Username, @Password, @FirstName, @SecondName)";
                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {
                // Параметризуем запрос для безопасного добавления данных
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Id", Id); 
                command.Parameters.AddWithValue("@Username", Username); 
                command.Parameters.AddWithValue("@Password", Password); 
                command.Parameters.AddWithValue("@FirstName", FirstName); 
                command.Parameters.AddWithValue("@SecondName", SecondName);

                    // Выполняем запрос
                    command.ExecuteNonQuery();
                }

                await Shell.Current.DisplayAlert("Успех!", "Вы успешно зарегистрировались", "ОК");
                    //Debug.WriteLine("Ok");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Упс!", "К сожалению произошла ошибка...", "ОК"); // ОШИБКА ЕСЛИ ЧТО ВЫСКАКИВАЕТ ЗДЕСЬ Т К ЕЩЕ НЕТ ТАБЛИЦЫ
            }


            connection.Close();
        }
        }
    //public async void f()
    //{
    //        var client = new HttpClient();
    //        var response = await client.GetAsync("http://localhost:5280/api/");
    //        var content = await response.Content.ReadAsStringAsync();
    //    Console.WriteLine(content);
    //}
  }

