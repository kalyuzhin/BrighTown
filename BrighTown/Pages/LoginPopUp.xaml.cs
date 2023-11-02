using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrighTown.ViewModels;
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


    async void Login(object sender, EventArgs e)
    {
        await CloseAsync();
        await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
    }

    // public bool PressLoginPopUpButton(object sender, EventArgs e)
    // {
    //     return true;
    // }
}