using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Text;
using System.Windows.Input;
using BrighTown.Models;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;

namespace BrighTown.ViewModels;

public partial class FriendsListViewModel : BaseViewModel
{
    [ObservableProperty] public bool _isRefreshing;
    [ObservableProperty] public ObservableCollection<User> _users;

    [RelayCommand]
    public async void Refresh()
    {
        IsRefreshing = true;
        using (HttpClient httpClient = new HttpClient())
        {
            string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5280/"
                : "http://localhost:5280/";
            var url = baseUrl + $"getfriends?id={App.user.Id}";
            var requestData = new Dictionary<string, int>()
            {
                { "id", App.user.Id }
            };
            var content = new
                StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<List<User>>>();
            Users = responseContent.Data.ToObservableCollection();
        }

        IsRefreshing = false;
    }
}