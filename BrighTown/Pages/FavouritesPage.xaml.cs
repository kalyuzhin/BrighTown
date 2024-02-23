using BrighTown.Models;

namespace BrighTown.Pages;

public partial class FavouritesPage : ContentPage
{
    public FavouritesPage()
    {
        InitializeComponent();
    }

    public static string CurrentName;
    public static double CurrentRating;
    public static string CurrentDescription;
    
    void OnFavouritesCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {

        if (FavouritesCollections.SelectedItem != null)
        {
            CurrentName = (e.CurrentSelection.FirstOrDefault() as Place)?.Name;
            CurrentRating =(double)(e.CurrentSelection.FirstOrDefault() as Place)?.Rating;
            CurrentDescription =(e.CurrentSelection.FirstOrDefault() as Place)?.Description;
            FavouritesCollections.SelectedItem = null;
            Routing.RegisterRoute("TakeALookOnPlace", typeof(CurrentPlaceInfoPage));
            Shell.Current.GoToAsync("TakeALookOnPlace");
        }
        
        

        
        
       

    }
  
    

   
}