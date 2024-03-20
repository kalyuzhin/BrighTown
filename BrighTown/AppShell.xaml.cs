using BrighTown.Pages;

namespace BrighTown;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
        Routing.RegisterRoute(nameof(PlaceDetails), typeof(PlaceDetails));
        Routing.RegisterRoute(nameof(CurrentFriendInfoPage), typeof(CurrentFriendInfoPage));
        Routing.RegisterRoute(nameof(AddPlaceToMapPage), typeof(AddPlaceToMapPage));
    }
}