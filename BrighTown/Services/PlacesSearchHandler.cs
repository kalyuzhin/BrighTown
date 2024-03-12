using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrighTown.ViewModels;
using System.Text.RegularExpressions;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using BrighTown.Models;
using BrighTown.Pages;
using Newtonsoft.Json;

namespace BrighTown.Services;

public class PlacesSearchHandler : SearchHandler
{
    public List<Place2> Places { get; set; }
    public string NavigationRoute { get; set; }

    protected override void OnFocused()
    {
        base.OnFocused();

        UpdateField();
    }


    protected override async void OnQueryChanged(string oldValue, string newValue)
    {
        base.OnQueryChanged(oldValue, newValue);
        
        using (HttpClient httpClient = new HttpClient())
        {
            string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5280/"
                : "http://localhost:5280/";
            var url = baseUrl + "api/Places/getAll";
            var response = await httpClient.GetAsync(url);
            var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Place2>>>();
            Places = responseContent.Data;
        }

        if (string.IsNullOrWhiteSpace(newValue))
        {
            ItemsSource = null;
        }
        else
        {
            ItemsSource = Places.Where(p => p.Name.ToLower().Contains(newValue.ToLower()))
                .ToList<Place2>();
        }
    }

    public async void UpdateField()
    {
        try
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                    ? "http://10.0.2.2:5280/"
                    : "http://localhost:5280/";
                var url = baseUrl + "api/Places/getAll";
                var response = await httpClient.GetAsync(url);
                var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Place2>>>();
                Places = responseContent.Data;
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", "Something went wrong...", "OK");
        }
    }

    protected override async void OnItemSelected(object item)
    {
        base.OnItemSelected(item);

        // await Task.Delay(1000);

        var navigation = new Dictionary<string, object>()
        {
            { "PlaceDetails", item }
        };
        await Shell.Current.GoToAsync(NavigationRoute, navigation);
    }
}