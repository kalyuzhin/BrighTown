using CommunityToolkit.Maui.Views;
using static BrighTown.Pages.ProfilePage;
namespace BrighTown.Pages;

public partial class UserIconPopUp : Popup
{
    public UserIconPopUp()
    {
        InitializeComponent();
        BindingContext = this;
    }

    public  static string  ImagetSource;
    async void ClickedOnCloseButton(object sender, EventArgs e)
    {
        
        ImagetSource = IconSelector.SelectedItem.ToString();
        await CloseAsync();
        
    }
    
}