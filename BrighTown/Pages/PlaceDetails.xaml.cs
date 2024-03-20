using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BrighTown.ViewModels;
using BrighTown.Models;
using static BrighTown.Pages.ImageViewPage;
using BrighTown.Models;
using CommunityToolkit.Maui.Views;
using Newtonsoft.Json;
using static BrighTown.Pages.FavouritesPage;

namespace BrighTown.Pages;

public partial class PlaceDetails : ContentPage
{
    public PlaceDetails(PlaceDetailsViewModel placeDetailsViewModel)
    {
        InitializeComponent();
        BindingContext = placeDetailsViewModel;

        
    }

    // void ClickOnCloseButton(object sender, EventArgs e)
    // {
    //     Shell.Current.GoToAsync("..");
    // }

    void OnImageForZoomClicked(object sender, SelectionChangedEventArgs e)
    {
        if (ImagesCollection.SelectedItem != null)
        {
            SourceImage = (e.CurrentSelection.FirstOrDefault() as Place).ImageUrl;
           
            
            
            ImagesCollection.SelectedItem = null;
           
            
            
            Shell.Current.GoToAsync($"TakeAZoom");
        }
    }

    private async void Button_OnClicked(object sender, EventArgs e)
    {
        var item = BindingContext as PlaceDetailsViewModel;
        using (HttpClient httpClient = new HttpClient())
        {
            string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5280/"
                : "http://localhost:5280/";
            var url = baseUrl + "api/Places/addtofavourites";
            var requestData = new Dictionary<string, int>()
            {
                { "userId", App.user.Id },
                { "placeId", item.Place.Id }
            };
            var content = new
                StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<Place2>>();
            if (responseContent.Success)
            {
                AddButton.Text = "Место уже добавлено";
            }
        }
    }

    private async void RemoveButton_OnClicked(object sender, EventArgs e)
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

            var viewModel = BindingContext as PlaceDetailsViewModel;

            using (HttpClient httpClient = new HttpClient())
            {
                string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                    ? "http://10.0.2.2:5280/"
                    : "http://localhost:5280/";
                var url = baseUrl + "deletefavourites";

                var requestData = new Dictionary<string, int>
                {
                    { "userId", App.user.Id },
                    { "placeId", viewModel.Place.Id }
                };

                var content = new
                    StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync(url, content);
                var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
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