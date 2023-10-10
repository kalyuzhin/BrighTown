namespace BrighTown
{
    public partial class MainPage : ContentPage
    {
    
        public MainPage()
        {
            InitializeComponent();
        }

        private void ClickOnFavouritesButton(object sender, EventArgs e)  // процедура реакции на кнопку "Избранное"
        {
            Maps.Source = "https://www.google.ru/maps/place/%D0%98%D0%BD%D1%81%D1%82%D0%B8%D1%82%D1%83%D1%82+%D0%BC%D0%B0%D1%82%D0%B5%D0%BC%D0%B0%D1%82%D0%B8%D0%BA%D0%B8,+%D0%BC%D0%B5%D1%85%D0%B0%D0%BD%D0%B8%D0%BA%D0%B8+%D0%B8+%D0%BA%D0%BE%D0%BC%D0%BF%D1%8C%D1%8E%D1%82%D0%B5%D1%80%D0%BD%D1%8B%D1%85+%D0%BD%D0%B0%D1%83%D0%BA+%D0%B8%D0%BC.+%D0%98.%D0%98.+%D0%92%D0%BE%D1%80%D0%BE%D0%B2%D0%B8%D1%87%D0%B0/@47.2167781,39.6266609,17z/data=!4m6!3m5!1s0x40e3b9a8f82b0a17:0xd9233ce383e6c05e!8m2!3d47.2167781!4d39.6287646!16s%2Fg%2F1q5bm5h5c?entry=ttu";
        }

        private void ClickOnFriendButton(object sender, EventArgs e)  // процедура реакции на кнопку "Друзья"
        {
            Maps.Source = "https://www.google.ru/maps/place/%D0%91%D0%BB%D0%B0%D0%B3%D0%BE%D1%82%D0%B2%D0%BE%D1%80%D0%B8%D1%82%D0%B5%D0%BB%D1%8C%D0%BD%D1%8B%D0%B9+%D1%84%D0%BE%D0%BD%D0%B4+%22%D0%AF+%D0%B1%D0%B5%D0%B7+%D0%BC%D0%B0%D0%BC%D1%8B%22/@47.2165372,39.630467,16.25z/data=!4m14!1m7!3m6!1s0x40e3b9a8f82b0a17:0xd9233ce383e6c05e!2z0JjQvdGB0YLQuNGC0YPRgiDQvNCw0YLQtdC80LDRgtC40LrQuCwg0LzQtdGF0LDQvdC40LrQuCDQuCDQutC-0LzQv9GM0Y7RgtC10YDQvdGL0YUg0L3QsNGD0Log0LjQvC4g0Jgu0JguINCS0L7RgNC-0LLQuNGH0LA!8m2!3d47.2167781!4d39.6287646!16s%2Fg%2F1q5bm5h5c!3m5!1s0x40e3bf325b324929:0x148b0794655971e!8m2!3d47.2129815!4d39.6352668!16s%2Fg%2F11byyrhywl?entry=ttu";
                }

        private void ClickOnMapButton(object sender, EventArgs e) // процедура реакции на кнопку "Карта"
        {
            Maps.Source = "https://google.ru/maps";
        }

        private void ClickOnProfileButton(object sender, EventArgs e) // процедура реакции на кнопку "Профиль"
        {
            Maps.Source = "https://google.ru/maps";
        }

    }
}