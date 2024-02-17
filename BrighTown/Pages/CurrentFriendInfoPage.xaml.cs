using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BrighTown.Pages.FriendsPage;
namespace BrighTown.Pages;

public partial class CurrentFriendInfoPage : ContentPage
{
    public CurrentFriendInfoPage()
    {
        InitializeComponent();

        AddFriendButton.Text = "У вас в друзьях ✓";
        
        FriendIcon.Source = CurrentFriendImageUrl;
        FriendName.Text = CurrentFriendName;
        FriendStatus.Text = $"Статус: {CurrentFriendStatus}";
        if (CurrentFriendStatus == "Онлайн")
        {
            StatusColor.Color = Colors.Green;
        }
        else
        {
            StatusColor.Color = Colors.Red;
        }
    }
    void ClickOnCloseButton(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
    
    
    
    
}