﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using BrighTown.Models;
using System.Text;
using Newtonsoft.Json;
using static System.Math;
using System.Text;
using System.Threading.Tasks;
using BrighTown.Models;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using static BrighTown.Pages.ImageViewPage;
using System.Web;
using BrighTown.ViewModels;

namespace BrighTown.Pages;

public partial class AddPlaceToMapPage : ContentPage
{
    //Почему Place? Возможно стоит в завести объект Place
    //В список ImagesUrl добавлять адреса изображений и все остальные поля заполнять постепенно
    public ObservableCollection<Place> Place_Images { get; private set; }
    //AddPlaceToMapPage mvm;
    //public Place2 place = new Place2();

    void OnImageForZoomClicked(object sender, SelectionChangedEventArgs e)
    {
        if (ImagesCollection.SelectedItem != null)
        {
            SourceImage = (e.CurrentSelection.FirstOrDefault() as Place).ImageUrl;
            ImagesCollection.SelectedItem = null;
            Routing.RegisterRoute("TakeAZoom1", typeof(ImageViewPage));
            Shell.Current.GoToAsync("TakeAZoom1");
        }
    }

    //Опять же, почему добавляются новые места
    public AddPlaceToMapPage(AddPlaceToMapPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

        // var view = BindingContext as AddPlaceToMapPageViewModel;

        // DescriptionEntry.Text = $"{view.Place.Latitude}, {view.Place.Longitude}";
        RatingValue.Text = $"Оценка места: 5";
        Place_Images = new ObservableCollection<Place>();

        Place_Images.Add(new Place()
        {
            ImageUrl = "demo_place.png",
        });
        Place_Images.Add(new Place()
        {
            ImageUrl = "demo_place.png",
        });
        Place_Images.Add(new Place()
        {
            ImageUrl = "demo_place.png",
        });
    }

    private async void PickPhoto_Clicked(object sender, EventArgs e)
    {
        FileResult result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Pick a Photo",
            FileTypes = FilePickerFileType.Images
        });

        // for debugging:  result.FullPath - path of uploaded image

        if (Place_Images.Count(y => y.ImageUrl == "demo_place.png") == 3)
        {
            Place_Images.Clear();
        }

        Place_Images.Add(new Place()
        {
            ImageUrl = result.FullPath,
        });

        BindingContext = this;
    }

    public static string NameOfCurrentPlace;

    void OnNameEntryCompleted(object sender, EventArgs e)
    {
        NameOfCurrentPlace = ((Entry)sender).Text;
    }

    public static string DescriptionOfCurrentPlace;

    void OnDiscriptionEntryCompleted(object sender, EventArgs e)
    {
        DescriptionOfCurrentPlace = ((Entry)sender).Text;
    }

    double rating;
    private readonly double sliderIncrement = 1;

    void OnRatingValueChanged(object sender, ValueChangedEventArgs args)
    {
        Slider slider = (Slider)sender;


        double relativeValue = slider.Value - slider.Minimum;

        rating = Math.Truncate(slider.Value);

        if (rating >= 4)
        {
            slider.ThumbColor = Colors.Green;
        }
        else if (rating == 3)
        {
            slider.ThumbColor = Colors.Gold;
        }
        else
        {
            slider.ThumbColor = Colors.Red;
        }

        RatingValue.Text = "Оценка места: " + rating.ToString();
    }

    //Что это за списки
    public List<string> CurrentPlaceImages;

    public List<string>
        GenerateImagesArray(ObservableCollection<Place> a) //Generator of array of paths of place images 
    {
        var lst = new List<string>();
        foreach (var variable in a)
        {
            lst.Add(variable.ImageUrl);
        }

        return lst;
    }

    async void ClickOnAddButton(object sender, EventArgs e)
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

            var vm = BindingContext as AddPlaceToMapPageViewModel;

            using (HttpClient httpClient = new HttpClient())
            {
                string baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                    ? "http://10.0.2.2:5280/"
                    : "http://localhost:5280/";
                var url = baseUrl + "api/Places/add";

                var requestData = new Dictionary<string, string>
                {
                    { "name", Name.Text },
                    { "description", DescriptionEntry.Text },
                    { "rating", Math.Truncate(ratingSlider.Value).ToString() },
                    { "latitude", vm.Place.Latitude.ToString() },
                    { "longitude", vm.Place.Longitude.ToString() }
                };

                var content = new
                    StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, content);
                var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Place2>>>();
                if (responseContent.Success)
                {
                    //MapViewModel mvm = (MapViewModel)Resources["MapViewModel"];
                    await Shell.Current.GoToAsync($"..");
                    vm.MapViewModel.Places.Add(responseContent.Data.Last());
                    CurrentPlaceImages = GenerateImagesArray(Place_Images);
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