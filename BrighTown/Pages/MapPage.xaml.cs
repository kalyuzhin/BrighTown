using Esri.ArcGISRuntime.Geometry;

namespace BrighTown.Pages;

public class PlaceSearchHandler : SearchHandler
{
}

public partial class MapPage : ContentPage
{
    public MapPage()
    {
        InitializeComponent();
    }

    //-----------������������� ������---------------------------------------------

    private void ClickOnFavouritesButton(object sender, EventArgs e) // ��������� ������� �� ������ "���������"
    {
        Navigation.PushModalAsync(new FavouritesPage(), true);
    }

    private void ClickOnAddPlaceButton(object sender, EventArgs e) // ��������� ������� �� ������ "������"
    {
        Routing.RegisterRoute("AddPlace", typeof(AddPlaceToMapPage));
        Shell.Current.GoToAsync("AddPlace");
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
        CoordiantesLabel.Text = $"Кооридинаты: {latitude}, {longitude}";
        Console.WriteLine($"Кооридинаты: {latitude}, {longitude}");
        AddingPlacePopUp.IsVisible = true;
    }
}