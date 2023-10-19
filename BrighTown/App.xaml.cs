using BrighTown.Pages;
namespace BrighTown
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new RegisterPage();
        }
    }
}