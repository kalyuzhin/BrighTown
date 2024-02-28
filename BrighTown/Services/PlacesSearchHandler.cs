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
    public Type SelectedItemNavigationTarget { get; set; }

    protected override async void OnQueryChanged(string oldValue, string newValue)
    {
        base.OnQueryChanged(oldValue, newValue);

        if (string.IsNullOrWhiteSpace(newValue))
        {
            ItemsSource = null;
        }
        else
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    if (Places.Count == 0)
                    {
                        string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                            ? "http://10.0.2.2:5280/"
                            : "http://localhost:5280/";
                        var url = baseUrl + "api/Places/getAll";
                        var response = await httpClient.GetAsync(url);
                        var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Place2>>>();
                        Places = responseContent.Data;
                        if (responseContent.Success)
                        {
                            ItemsSource = Places.Where(p => p.Name.ToLower().Contains(newValue.ToLower()))
                                .ToList<Place2>();
                        }
                        else
                        {
                            Shell.Current.DisplayAlert("Error", "Not success request", "OK");
                        }
                    }
                    else
                    {
                        ItemsSource = Places.Where(p => p.Name.ToLower().Contains(newValue.ToLower())).ToList<Place2>();
                    }
                }
            }
            catch (Exception ex)
            {
                Shell.Current.DisplayAlert("Error", "Error to access API", "OK");
            }
        }
    }

    protected override async void OnItemSelected(object item)
    {
        base.OnItemSelected(item);

        // Let the animation complete
        await Task.Delay(1000);

        await Shell.Current.GoToAsync($"{nameof(CurrentPlaceInfoPage)}");
        // ShellNavigationState state = (App.Current.MainPage as Shell).CurrentState;
        // The following route works because route names are unique in this app.
        // await Shell.Current.GoToAsync($"{GetNavigationTarget()}?name={((Place2)item).Name}");
    }
}