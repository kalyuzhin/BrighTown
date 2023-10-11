namespace BrighTown.Pages;

public partial class FavouritesPage : ContentPage
{
	public FavouritesPage()
	{
		InitializeComponent();
	}

    //-----------Навигационная панель---------------------------------------------

    private void ClickOnFavouritesButton(object sender, EventArgs e)  // процедура реакции на кнопку "Избранное"
    {
        Navigation.PushModalAsync(new FavouritesPage());
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
        Navigation.PushModalAsync(new ProfilePage());
    }



}