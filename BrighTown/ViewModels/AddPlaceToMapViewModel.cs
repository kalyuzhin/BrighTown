using BrighTown.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BrighTown.ViewModels;

[QueryProperty(nameof(Place), "AddPlaceToMapPage")]
[QueryProperty(nameof(MapViewModel), "MapViewModel")]
public partial class AddPlaceToMapPageViewModel : BaseViewModel
{
    [ObservableProperty] Place2 _place;
    [ObservableProperty] MapViewModel _mapViewModel;
}