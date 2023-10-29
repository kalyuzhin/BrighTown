namespace BrighTown.Pages;

public partial class FavouritesPage : ContentPage
{
    public FavouritesPage()
    {
        InitializeComponent();
    }

    //-----------������������� ������---------------------------------------------

    private void ClickOnFavouritesButton(object sender, EventArgs e) // ��������� ������� �� ������ "���������"
    {
        Navigation.PushModalAsync(new FavouritesPage());
    }

    private void ClickOnFriendButton(object sender, EventArgs e) // ��������� ������� �� ������ "������"
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