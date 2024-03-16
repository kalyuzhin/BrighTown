using System.Net.Http.Json;
using System.Text;
using BrighTown.Models;
using CommunityToolkit.Maui.Core.Extensions;
using Newtonsoft.Json;

namespace BrighTown.Pages;

public partial class FavouritesPage : ContentPage
{
    public FavouritesPage()
    {
        InitializeComponent();
    }

    // public static string CurrentName;
    // public static double CurrentRating;
    // public static string CurrentDescription;

    void OnFavouritesCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (FavouritesCollections.SelectedItem != null)
        {
            // CurrentName = (e.CurrentSelection.FirstOrDefault() as Place)?.Name;
            // CurrentRating = (double)(e.CurrentSelection.FirstOrDefault() as Place)?.Rating;
            // CurrentDescription = (e.CurrentSelection.FirstOrDefault() as Place)?.Description;
            var navigation = new Dictionary<string, object>()
            {
                { "PlaceDetails", FavouritesCollections.SelectedItem }
            };
            FavouritesCollections.SelectedItem = null;
            // Routing.RegisterRoute("TakeALookOnPlace", typeof(PlaceDetails));
            Shell.Current.GoToAsync("PlaceDetails", navigation);
        }
    }

    private async void RefreshView_OnRefreshing(object sender, EventArgs e)
    {
        using (HttpClient httpClient = new HttpClient())
        {
            string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5280/"
                : "http://localhost:5280/";
            var url = baseUrl + "api/Places/getfavourites?id=";
            var requestData = new Dictionary<string, int>()
            {
                { "id", App.user.Id }
            };
            var content = new
                StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
            url += App.user.Id;
            var response = await httpClient.PostAsync(url, content);
            var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Place2>>>();
            if (responseContent.Data.Count == 0)
            {
                EmptyViewLabel.Text = responseContent.Message;
            }

            FavouritesCollections.ItemsSource = responseContent.Data.ToObservableCollection();
            RefreshView.IsRefreshing = false;
        }
    }
}