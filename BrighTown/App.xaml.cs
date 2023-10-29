using BrighTown.Pages;
using BrighTown.ViewModel;

namespace BrighTown
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            //MainPage = new AuthenticationPage(new AuthenticationViewModel(Connectivity.Current));
        }
    }
}