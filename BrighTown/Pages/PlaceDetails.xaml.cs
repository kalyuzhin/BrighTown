using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrighTown.ViewModels;
using BrighTown.Models;
using static BrighTown.Pages.FavouritesPage;

namespace BrighTown.Pages;

public partial class PlaceDetails : ContentPage
{
    public PlaceDetails(PlaceDetailsViewModel placeDetailsViewModel)
    {
        InitializeComponent();
        BindingContext = placeDetailsViewModel;

        // RatingValue.Text = $"Оценка: {CurrentRating}/5";
        // Descriptor.Text = CurrentDescription;
        // NameTag.Text = CurrentName;
    }

    // void ClickOnCloseButton(object sender, EventArgs e)
    // {
    //     Shell.Current.GoToAsync("..");
    // }
}