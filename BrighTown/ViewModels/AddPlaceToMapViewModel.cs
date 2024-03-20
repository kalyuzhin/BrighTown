using CommunityToolkit.Mvvm.ComponentModel;
namespace BrighTown.ViewModels;

[QueryProperty("Latitude", "latitude")]
[QueryProperty("Longitude", "longitude")]
public partial class AddPlaceToMapPageViewModel : ObservableObject
{
    [ObservableProperty] double latitude;
    [ObservableProperty] double longitude;
}

