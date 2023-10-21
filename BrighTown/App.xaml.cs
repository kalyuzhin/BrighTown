using BrighTown.Pages;
using BrighTown.ViewModel;

namespace BrighTown
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            MainPage = new RegisterPage(new RegisterViewModel(Connectivity.Current));
        }
    }
}