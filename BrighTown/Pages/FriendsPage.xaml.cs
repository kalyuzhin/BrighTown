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
            var navigation = new Dictionary<string, object>()
            {
                { "CurrentFriendInfoPage", FriendsCollections.SelectedItem }
            };
            FriendsCollections.SelectedItem = null;
            Shell.Current.GoToAsync("CurrentFriendInfoPage", navigation);
        }
    }
}