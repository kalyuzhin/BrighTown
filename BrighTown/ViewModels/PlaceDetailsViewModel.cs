using BrighTown.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BrighTown.ViewModels;

[QueryProperty(nameof(Place), "PlaceDetails")]
public partial class PlaceDetailsViewModel : BaseViewModel
{
    [ObservableProperty] Place2 _place;
}