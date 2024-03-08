using System.Net.Http.Json;
using BrighTown.Models;
using Esri.ArcGISRuntime;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Maui;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;
using Map = Esri.ArcGISRuntime.Mapping.Map;
using BrighTown.Services;
using CommunityToolkit.Mvvm.Input;

namespace BrighTown.Pages;

public partial class MapPage : ContentPage
{
    private GeodatabaseFeatureTable _geodatabaseFeatureTable;
    private GraphicsOverlay _graphicsOverlay;
    private ArcGISFeature _newFeature;

    public MapPage()
    {
        InitializeComponent();
    }

    private void ClickOnAddPlaceButton(object sender, EventArgs e)
    {
        Routing.RegisterRoute("AddPlace", typeof(AddPlaceToMapPage));
        Shell.Current.GoToAsync("AddPlace");
    }

    private async void MainMapView_OnGeoViewTapped(object sender, GeoViewInputEventArgs e)
    {
        MapPoint mapPoint = (MapPoint)e.Location;
        // MapPoint correctPoint = new MapPoint(mapPoint.X, mapPoint.Y, SpatialReferences.Wgs84);
        // MainMapView.GraphicsOverlays[0].Graphics.Add(new Graphic(correctPoint));
    }
}