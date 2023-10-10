
using System.Security.AccessControl;

namespace BrighTown.Pages;

public partial class MapPage : ContentPage
{
	public MapPage()
	{
		InitializeComponent();
		
	}








  

    private void ClickOnFavouritesButton(object sender, EventArgs e)  // процедура реакции на кнопку "Избранное"
    {
        Maps.Source = "https://www.google.ru/maps/place/%D0%98%D0%BD%D1%81%D1%82%D0%B8%D1%82%D1%83%D1%82+%D0%BC%D0%B0%D1%82%D0%B5%D0%BC%D0%B0%D1%82%D0%B8%D0%BA%D0%B8,+%D0%BC%D0%B5%D1%85%D0%B0%D0%BD%D0%B8%D0%BA%D0%B8+%D0%B8+%D0%BA%D0%BE%D0%BC%D0%BF%D1%8C%D1%8E%D1%82%D0%B5%D1%80%D0%BD%D1%8B%D1%85+%D0%BD%D0%B0%D1%83%D0%BA+%D0%B8%D0%BC.+%D0%98.%D0%98.+%D0%92%D0%BE%D1%80%D0%BE%D0%B2%D0%B8%D1%87%D0%B0/@47.2167781,39.6266609,17z/data=!4m6!3m5!1s0x40e3b9a8f82b0a17:0xd9233ce383e6c05e!8m2!3d47.2167781!4d39.6287646!16s%2Fg%2F1q5bm5h5c?entry=ttu";
    }

    private void ClickOnFriendButton(object sender, EventArgs e)  // процедура реакции на кнопку "Друзья"
    {
        Navigation.PushModalAsync(new FriendsPage());
    }

    private void ClickOnMapButton(object sender, EventArgs e) // процедура реакции на кнопку "Карта"
    {
        Navigation.PushModalAsync(new MapPage());
    }

    private void ClickOnProfileButton(object sender, EventArgs e) // процедура реакции на кнопку "Профиль"
    {
        Maps.Source = "https://google.ru/maps";
    }










}