using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;

namespace BrighTown.Pages;

public partial class RegisterPopUp : Popup
{
    public RegisterPopUp()
    {
        InitializeComponent();
    }
    
    async void Register(object sender, EventArgs e)
    {
        await CloseAsync();
        await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
    }


}