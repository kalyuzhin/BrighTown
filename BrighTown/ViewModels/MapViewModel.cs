using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Geometry;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Map = Esri.ArcGISRuntime.Mapping.Map;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;

namespace BrighTown
{

    internal class MapViewModel : INotifyPropertyChanged
    {
        public MapViewModel()
        {
            SetupMap();
            CreateGraphics();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Map _map;
        public Map Map
        {
            get => _map;
            set
            {
                _map = value;
                OnPropertyChanged();
            }
        }

        private GraphicsOverlayCollection? _graphicsOverlays;
        public GraphicsOverlayCollection? GraphicsOverlays
        {
            get { return _graphicsOverlays; }
            set
            {
                _graphicsOverlays = value;
                OnPropertyChanged();
            }
        }


        private void SetupMap()
        {

            if (Application.Current.RequestedTheme.ToString() == "Dark")
            {
                Map = new Map(BasemapStyle.OSMDarkGray);
            }
            else
            {
                Map = new Map(BasemapStyle.OSMStandard);
            }
            
            var mapCenterPoint = new MapPoint(39.709612, 47.240004,  SpatialReferences.Wgs84);
            Map.InitialViewpoint = new Viewpoint(mapCenterPoint, 100000);


        }

        private void CreateGraphics()
        {
            // Create a new graphics overlay to contain a variety of graphics.
            var MapGraphicsOverlay = new GraphicsOverlay();

            // Add the overlay to a graphics overlay collection.
            GraphicsOverlayCollection overlays = new GraphicsOverlayCollection
            {
                MapGraphicsOverlay
            };

            // Set the view model's "GraphicsOverlays" property (will be consumed by the map view).
            this.GraphicsOverlays = overlays;


            // Create a point geometry.
            var MMCS = new MapPoint(39.628649, 47.216686,  SpatialReferences.Wgs84);
            Button mm = new Button();



            // Create a symbol to define how the point is displayed.
            var pointSymbol = new SimpleMarkerSymbol
            {
                Style = SimpleMarkerSymbolStyle.Circle,
                Color = System.Drawing.Color.Orange,
                Size = 20.0
            };

            // Add an outline to the symbol.
            pointSymbol.Outline = new SimpleLineSymbol
            {
                Style = SimpleLineSymbolStyle.Solid,
                Color = System.Drawing.Color.Blue,
                Width = 2.0
            };
           
            // Create a point graphic with the geometry and symbol.
            var pointGraphic = new Graphic(MMCS, pointSymbol);
          
            // Add the point graphic to graphics overlay.
            MapGraphicsOverlay.Graphics.Add(pointGraphic);
            
           
          
            
        }
        
        

    }
}
// ссылка на UserGuide по ArcGis: https://developers.arcgis.com/net/maps-2d/tutorials/add-a-point-line-and-polygon/