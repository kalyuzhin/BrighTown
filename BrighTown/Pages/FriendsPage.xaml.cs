using static Microsoft.Maui.ApplicationModel.Permissions;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using BrighTown.Models;

namespace BrighTown.Pages;

public partial class FriendsPage : ContentPage
{
    
    public FriendsPage()
    {

        InitializeComponent();
        
        
    }

    public static string CurrentFriendName;
    public static string CurrentFriendStatus;
    public static string CurrentFriendImageUrl;
    void OnFriendsCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {

        if (FriendsCollections.SelectedItem != null)
        {
            CurrentFriendName = (e.CurrentSelection.FirstOrDefault() as Friend)?.Name;
            CurrentFriendStatus = (e.CurrentSelection.FirstOrDefault() as Friend)?.Status;
            CurrentFriendImageUrl = (e.CurrentSelection.FirstOrDefault() as Friend)?.ImageUrl;
            FriendsCollections.SelectedItem = null;
            Routing.RegisterRoute("TakeALookOnFriend", typeof(CurrentFriendInfoPage));
            Shell.Current.GoToAsync("TakeALookOnFriend");
        }












    }
}