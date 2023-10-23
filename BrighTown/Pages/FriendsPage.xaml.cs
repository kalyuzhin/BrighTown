using static Microsoft.Maui.ApplicationModel.Permissions;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;

namespace BrighTown.Pages;

public partial class FriendsPage : ContentPage
{
  
    public FriendsPage()
	{
       
        InitializeComponent();

    }

    //-----------������������� ������---------------------------------------------




   

 

    private void ClickOnFavouritesButton(object sender, EventArgs e)  // ��������� ������� �� ������ "���������"
    {
        Navigation.PushModalAsync(new FavouritesPage());
    }

    private void ClickOnFriendButton(object sender, EventArgs e)  // ��������� ������� �� ������ "������"
    {
        Navigation.PushModalAsync(new FriendsPage());
    }

    private void ClickOnMapButton(object sender, EventArgs e) // ��������� ������� �� ������ "�����"
    {
        Navigation.PushModalAsync(new MapPage());
    }

    private void ClickOnProfileButton(object sender, EventArgs e) // ��������� ������� �� ������ "�������"
    {
        Navigation.PushModalAsync(new ProfilePage());
    }












}