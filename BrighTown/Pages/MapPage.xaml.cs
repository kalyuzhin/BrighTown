using Esri.ArcGISRuntime;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Maui;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;
using Map = Esri.ArcGISRuntime.Mapping.Map;

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
        // ArcGISFeature feature = (ArcGISFeature)_geodatabaseFeatureTable.CreateFeature();
        // MapPoint mapPoint = (MapPoint)e.Location.NormalizeCentralMeridian();
        // feature.Geometry = mapPoint;
        // await _geodatabaseFeatureTable.AddFeatureAsync(feature);
        // feature.Refresh();
        // MainMapView.GraphicsOverlays[0].Graphics.Add(new Graphic(mapPoint));
    }
}