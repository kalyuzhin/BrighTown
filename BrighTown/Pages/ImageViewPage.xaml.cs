using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighTown.Pages;

public partial class ImageViewPage : ContentPage
{
    public static string SourceImage;
    public ImageViewPage()
    {
        InitializeComponent();
        CurrentImage.Source = SourceImage;
    }

    async void CloseButtonClicked(object sender, EventArgs e)
    {
     
        await Shell.Current.GoToAsync($"..");
        
        
    }
    
    
    
    
    
}
