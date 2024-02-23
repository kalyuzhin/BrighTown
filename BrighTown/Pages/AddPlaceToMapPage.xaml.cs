using System;
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


namespace BrighTown.Pages;

public partial class AddPlaceToMapPage : ContentPage
{
    public ObservableCollection<Place> Place_Images { get; private set; }


    public AddPlaceToMapPage()
    {
        InitializeComponent();
        RatingValue.Text = $"Оценка места: 5/5";
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
        BindingContext = this;
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

    public double Rating;

    void OnRatingValueChanged(object sender, ValueChangedEventArgs args)
    {
        RatingValue.Text = $"Оценка места: {Round(args.NewValue / 100000000)}/5";
        Rating = Round(args.NewValue / 100000000);
    }


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

            // Place addedPlace = new Place()
            // {
            //     Name = NameOfCurrentPlace,
            //     Description = DescriptionOfCurrentPlace,
            //     ImagesList = CurrentPlaceImages,
            //     Rating = Rating,
            //     ImageUrl = "",
            // };

            using (HttpClient httpClient = new HttpClient())
            {
                var url = "http://10.0.2.2:5280/api/Places/add";

                var requestData = new Dictionary<string, string>
                {
                    { "name", Name.Text },
                    { "description", DescriptionEntry.Text }
                };

                var content = new
                    StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, content);
                var responseContent = await response.Content.ReadFromJsonAsync<ServiceResponse<Place>>();
                if (responseContent.Success)
                {
                    // CurrentPlaceImages = GenerateImagesArray(Place_Images);
                    await Shell.Current.GoToAsync($"..");
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