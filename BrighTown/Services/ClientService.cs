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

    private readonly HttpClient _httpClient;

    public ClientService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }


    // public async Task<User> Register(RegisterModel model) //string email, string username, string password)
    // {
    //     try
    //     {
    //         var client = _httpClientFactory.CreateClient();
    //         var result = await client.PostAsJsonAsync("/register", model);
    //         if (result.IsSuccessStatusCode)
    //         {
    //             User user = await result.Content.ReadFromJsonAsync<User>();
    //             return await Task.FromResult(user);
    //         }
    //
    //         return null;
    //     }
    //     catch (Exception ex)
    //     {
    //         await Shell.Current.DisplayAlert("Ошибка!", "Не удалость завершить регистрацию", "ОК");
    //         return null;
    //     }
    // }

    public async Task<ServiceResponse<List<Place2>>> GetPlaces()
    {
        using (HttpClient httpClient = new HttpClient())
        {
            string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5280/"
                : "http://localhost:5280/";
            var url = baseUrl + "api/Places/getAll";
            var response = await httpClient.GetAsync(url);
            var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Place2>>>();
            return responseContent;
        }
    }
}