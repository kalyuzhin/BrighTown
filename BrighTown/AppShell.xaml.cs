using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esri.ArcGISRuntime.Tasks.NetworkAnalysis;
using BrighTown.Pages;

namespace BrighTown;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
    }
}