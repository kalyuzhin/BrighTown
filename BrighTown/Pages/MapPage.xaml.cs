using System.Security.AccessControl;

namespace BrighTown.Pages;

public class PlaceSearchHandler : SearchHandler
{
}

public partial class MapPage : ContentPage
{
    public MapPage()
    {
        InitializeComponent();
        
    }

    //-----------������������� ������---------------------------------------------

    private void ClickOnFavouritesButton(object sender, EventArgs e) // ��������� ������� �� ������ "���������"
    {
        Navigation.PushModalAsync(new FavouritesPage(), true);
    }

    private void ClickOnAddPlaceButton(object sender, EventArgs e) // ��������� ������� �� ������ "������"
    {
       
       
        
        
    }

    private void ClickOnMapButton(object sender, EventArgs e) // ��������� ������� �� ������ "�����"
    {
        Navigation.PushModalAsync(new MapPage(), true);
    }

    private void ClickOnProfileButton(object sender, EventArgs e) // ��������� ������� �� ������ "�������"
    {
        Navigation.PushModalAsync(new ProfilePage(), true);
    }
}