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

    private void ClickOnFriendButton(object sender, EventArgs e) // ��������� ������� �� ������ "������"
    {
        Navigation.PushModalAsync(new FriendsPage(), true);
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