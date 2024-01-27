using System.Net.Http.Json;
using BrighTown.Models;

namespace BrighTown.Services;

public class LoginService : ILoginRepository
{
    // public async Task<User> Login(string email, string password)
    // {
    //     var client = new HttpClient();
    //     string localHostUrl = "http://localhost:5280/api/user/register/" + email + "/" + password;
    //     HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
    //     User user = new User();
    //     return Task.FromResult(user);
    // }

    public async Task<User> Register(string username, string password) //string email, string username, string password)
    {
        try
        {
            var client = new HttpClient();
            string localHostUrl = "http://localhost:5280/api/user/register/" + username + "/" + password;
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                User user = await response.Content.ReadFromJsonAsync<User>();
                return await Task.FromResult(user);
            }

            return null;
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка!", "Не удалость завершить регистрацию", "ОК");
            return null;
        }
    }
}