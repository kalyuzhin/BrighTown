using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrighTown.ViewModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using Esri.ArcGISRuntime.Mapping;

namespace BrighTown.Pages;

public partial class LoginPopUp : Popup
{
    public LoginPopUp()
    {
        InitializeComponent();
        BindingContext = this;
    }


    private void PressLoginButton(object sender, EventArgs e)
    {
        Close();
        Shell.Current.GoToAsync($"//{nameof(MapPage)}");
    }

    // public bool PressLoginPopUpButton(object sender, EventArgs e)
    // {
    //     return true;
    // }
}