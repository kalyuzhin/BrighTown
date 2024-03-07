using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BrighTown.Pages.ImageViewPage;
using BrighTown.Models;
using static BrighTown.Pages.FavouritesPage;

namespace BrighTown.Pages;

public partial class CurrentPlaceInfoPage : ContentPage
{
    public CurrentPlaceInfoPage()
    {
        InitializeComponent();

        RatingValue.Text = $"Оценка: {CurrentRating}/5";
        Descriptor.Text = CurrentDescription;
        NameTag.Text = CurrentName;
    }

    
    void OnImageForZoomClicked(object sender, SelectionChangedEventArgs e)
    {

         if (ImagesCollection.SelectedItem != null)
         {
             SourceImage = (e.CurrentSelection.FirstOrDefault() as Place).ImageUrl;
             ImagesCollection.SelectedItem = null;
             Routing.RegisterRoute("TakeAZoom", typeof(ImageViewPage));
             Shell.Current.GoToAsync("TakeAZoom");
         }
    }
    

    void ClickOnCloseButton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}
    
