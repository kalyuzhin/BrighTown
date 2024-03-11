using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BrighTown.Models;
using BrighTown.ViewModels;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Newtonsoft.Json;
using static BrighTown.Pages.FriendsPage;

namespace BrighTown.Pages;

public partial class CurrentFriendInfoPage : ContentPage
{
    public CurrentFriendInfoPage(FriendDetailsViewModel friendDetailsViewModel)
    {
        InitializeComponent();
        BindingContext = friendDetailsViewModel;
    }

    private async void AddFriendButton_OnClicked(object sender, EventArgs e)
    {
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

            var viewModel = BindingContext as FriendDetailsViewModel;

            using (HttpClient httpClient = new HttpClient())
            {
                string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                    ? "http://10.0.2.2:5280/"
                    : "http://localhost:5280/";
                var url = baseUrl + "add_friend";

                var requestData = new Dictionary<string, string>
                {
                    { "userId", App.user.Id.ToString() },
                    { "friendId", viewModel.Friend.Id.ToString() }
                };

                var content = new
                    StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, content);
                var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<User>>();
                if (responseContent.Success)
                {
                    await Shell.Current.DisplayAlert("", $"{responseContent.Message}", "OK");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Упс!", $"{responseContent.Message}", "ОК");
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
    }
}