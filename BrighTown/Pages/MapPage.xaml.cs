
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
   
    //-----------Навигационная панель---------------------------------------------

    private void ClickOnFavouritesButton(object sender, EventArgs e)  // процедура реакции на кнопку "Избранное"
    {
        Navigation.PushModalAsync(new FavouritesPage(),true);
    }
   
    private void ClickOnFriendButton(object sender, EventArgs e)  // процедура реакции на кнопку "Друзья"
    {
        Navigation.PushModalAsync(new FriendsPage(),true);
        
    }

    private void ClickOnMapButton(object sender, EventArgs e) // процедура реакции на кнопку "Карта"
    {
        Navigation.PushModalAsync(new MapPage(),true);
    }

    private void ClickOnProfileButton(object sender, EventArgs e) // процедура реакции на кнопку "Профиль"
    {
        Navigation.PushModalAsync(new ProfilePage(), true);
    }










}