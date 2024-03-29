using BrighTown.Pages;

namespace BrighTown;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Routing.RegisterRoute(nameof(NewAuthenticationPage), typeof(NewAuthenticationPage));
        Routing.RegisterRoute("AddPlace", typeof(AddPlaceToMapPage));
        Routing.RegisterRoute("TakeAZoom",typeof(ImageViewPage));
        Routing.RegisterRoute("OpenSettings", typeof(SettingsPage));
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
        Routing.RegisterRoute(nameof(PlaceDetails), typeof(PlaceDetails));
        Routing.RegisterRoute(nameof(CurrentFriendInfoPage), typeof(CurrentFriendInfoPage));
    }
}