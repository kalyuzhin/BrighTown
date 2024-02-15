﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static System.Math;
using System.Text;
using System.Threading.Tasks;
using BrighTown.Models;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Storage;
using static BrighTown.Models.Debug_Data;

namespace BrighTown.Pages;

public partial class AddPlaceToMapPage : ContentPage
{
    public ObservableCollection<Place> Place_Images{ get; private set; }

   
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

    public static string DiscriptionOfCurrentPlace;
    void OnDiscriptionEntryCompleted(object sender, EventArgs e)
    {
       DiscriptionOfCurrentPlace = ((Entry)sender).Text;
    }

    public double Rating;
    void OnRatingValueChanged(object sender, ValueChangedEventArgs args)
    {
        RatingValue.Text = $"Оценка места: {Round(args.NewValue /100000000)}/5";
        Rating = Round(args.NewValue /100000000);
    }
    
    
    public List<string> CurrentPlaceImages;
    public List<string> GenerateImagesArray(ObservableCollection<Place> a) //Generator of array of paths of place images 
    {
        var lst = new List<string>();
        foreach (var VARIABLE in a)
        {
            lst.Add(VARIABLE.ImageUrl);
        }

        return lst;
    }
    public void ClickOnAddButton(object sender, EventArgs e)
    {
        
        // returns current added object type Place
        CurrentPlaceImages = GenerateImagesArray(Place_Images);

        Place AddedPlace = new Place()
        {
            Name = NameOfCurrentPlace,
            Description = DiscriptionOfCurrentPlace,
            ImagesList = CurrentPlaceImages,
            Rating = Rating,
            ImageUrl = "",
        };
        
        
        
        
        // Returns to MapPage
        Shell.Current.GoToAsync("..");
    }
}