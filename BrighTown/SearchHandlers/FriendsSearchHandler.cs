using System.Net.Http.Json;
using BrighTown.Models;

namespace BrighTown.SearchHandlers;

public class FriendsSearchHandler : SearchHandler
{
    public List<User> Friends { get; set; }
    public string NavigationRoute { get; set; }

    protected override async void OnQueryChanged(string oldValue, string newValue)
    {
        base.OnQueryChanged(oldValue, newValue);

        using (HttpClient httpClient = new HttpClient())
        {
            string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5280/"
                : "http://localhost:5280/";
            var url = baseUrl + "getallusers";
            var response = await httpClient.GetAsync(url);
            var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<List<User>>>();
            Friends = responseContent.Data;
        }

        if (string.IsNullOrWhiteSpace(newValue))
        {
            ItemsSource = null;
        }
        else
        {
            ItemsSource = Friends.Where(p => p.UserName.ToLower().Contains(newValue.ToLower()))
                .ToList<User>();
        }
    }

    protected override async void OnItemSelected(object item)
    {
        base.OnItemSelected(item);

        // await Task.Delay(1000);

        var navigation = new Dictionary<string, object>()
        {
            { "CurrentFriendInfoPage", item }
        };
        await Shell.Current.GoToAsync(NavigationRoute, navigation);
    }
}