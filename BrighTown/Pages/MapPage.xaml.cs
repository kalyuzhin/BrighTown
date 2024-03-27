using BrighTown.Models;
using Esri.ArcGISRuntime.Geometry;

namespace BrighTown.Pages;

public class PlaceSearchHandler : SearchHandler
{
}

public partial class MapPage : ContentPage
{
    MapViewModel mvm;

    public MapPage()
    {
        InitializeComponent();
    }

    //-----------������������� ������---------------------------------------------

    private void ClickOnFavouritesButton(object sender, EventArgs e) // ��������� ������� �� ������ "���������"
    {
        Navigation.PushModalAsync(new FavouritesPage(), true);
    }

    private async void ClickOnAddPlaceButton(object sender, EventArgs e) // ��������� ������� �� ������ "������"
    {
        //Routing.RegisterRoute("AddPlace", typeof(AddPlaceToMapPage));
        //Shell.Current.GoToAsync("AddPlace");
        MapViewModel mvm = (MapViewModel)Resources["MapViewModel"];
        Place2 place = new Place2();
        place.Longitude = mvm.Longitude;
        place.Latitude = mvm.Latitude;
        var nav = new Dictionary<string, object>()
        {
            { "AddPlaceToMapPage", place },
            { "MapViewModel", mvm }
        };
        var path = $"{nameof(AddPlaceToMapPage)}?lat={mvm.Latitude}&long={mvm.Longitude}";
        await Shell.Current.GoToAsync(nameof(AddPlaceToMapPage), nav);
    }

    private void ClickOnCloseButton(object sender, EventArgs e) // ��������� ������� �� ������ "������"
    {
        AddingPlacePopUp.IsVisible = false;
    }

    private void ClickOnMapButton(object sender, EventArgs e) // ��������� ������� �� ������ "�����"
    {
        Navigation.PushModalAsync(new MapPage(), true);
    }

    private void ClickOnProfileButton(object sender, EventArgs e) // ��������� ������� �� ������ "�������"
    {
        Navigation.PushModalAsync(new ProfilePage(), true);
    }

    private void MainMapView_GeoViewHolding(object sender, Esri.ArcGISRuntime.Maui.GeoViewInputEventArgs e)
    {
        //MapPoint mapPoint = e.Location;
        MapPoint mapPoint = (MapPoint)GeometryEngine.Project(e.Location, SpatialReferences.Wgs84);
        //Получение широты и долготы
        double latitude = mapPoint.Y; //широта
        double longitude = mapPoint.X; //долгота
        MapViewModel mvm = (MapViewModel)Resources["MapViewModel"];
        mvm.Latitude = latitude;
        mvm.Longitude = longitude;
        //CoordiantesLabel.Text = $"Кооридинаты: {latitude}, {longitude}";
        Console.WriteLine($"Кооридинаты: {latitude}, {longitude}");
        AddingPlacePopUp.IsVisible = true;
    }
}