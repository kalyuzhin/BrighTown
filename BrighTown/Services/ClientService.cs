using System.Net.Http.Json;
using System.Text.Json;
using BrighTown.Models;

namespace BrighTown.Services;

public class ClientService : IClientService
{
    // public async Task<User> Login(string email, string password)
    // {
    //     var client = new HttpClient();
    //     string localHostUrl = "http://localhost:5280/api/user/register/" + email + "/" + password;
    //     HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
    //     User user = new User();
    //     return Task.FromResult(user);
    // }

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _localHostUrl = "http://localhost:5280/api/Users/register";

    public async Task<User> Register(RegisterModel model) //string email, string username, string password)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.PostAsJsonAsync("/register", model);
            if (result.IsSuccessStatusCode)
            {
                User user = await result.Content.ReadFromJsonAsync<User>();
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