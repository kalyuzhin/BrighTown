using static Microsoft.Maui.ApplicationModel.Permissions;

namespace BrighTown.Pages;

public partial class FriendsPage : ContentPage
{
	public FriendsPage()
	{
		InitializeComponent();
	}
    
    private void ClickOnFavouritesButton(object sender, EventArgs e)  // ��������� ������� �� ������ "���������"
    {
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
          }














}