using static Microsoft.Maui.ApplicationModel.Permissions;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Text;
using BrighTown.Models;
using CommunityToolkit.Maui.Core.Extensions;
using Newtonsoft.Json;

namespace BrighTown.Pages;

public partial class FriendsPage : ContentPage
{
    public FriendsPage()
    {
        InitializeComponent();
    }

    void OnFriendsCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (FriendsCollections.SelectedItem != null)
        {
            var navigation = new Dictionary<string, object>()
            {
                { "CurrentFriendInfoPage", FriendsCollections.SelectedItem }
            };
            FriendsCollections.SelectedItem = null;
            Shell.Current.GoToAsync("CurrentFriendInfoPage", navigation);
        }
    }

    private async void RefreshView_OnRefreshing(object sender, EventArgs e)
    {
        using (HttpClient httpClient = new HttpClient())
        {
            string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5280/"
                : "http://localhost:5280/";
            var url = baseUrl + "getfriends?id=";
            var requestData = new Dictionary<string, int>()
            {
                { "id", App.user.Id }
            };
            var content = new
                StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
            url += App.user.Id;
            var response = await httpClient.PostAsync(url, content);
            var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<List<User>>>();
            if (responseContent.Data.Count == 0)
            {
                EmptyViewLabel.Text = responseContent.Message;
            }

            FriendsCollections.ItemsSource = responseContent.Data.ToObservableCollection();
            RefreshView.IsRefreshing = false;
        }
    }
}