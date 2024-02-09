using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Storage;

namespace BrighTown.Pages;

public partial class AddPlaceToMapPage : ContentPage
{
   
    public AddPlaceToMapPage()
    {
        InitializeComponent();
    }
   
    private async void PickPhoto_Clicked(object sender, EventArgs e)
    {
        FileResult result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Pick a Photo",
            FileTypes = FilePickerFileType.Images
        });

        if (result == null) return;
        else
        {
            if (FirstImage.Source != null)
            {
                FirstImage.Source = result.FullPath;
            }
            else
            {
                SecondImage.Source = result.FullPath;
            }
           
        }

        
    }

   
    public void ClickOnAddButton(object sender, EventArgs e)
    {
        
    }
}