using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace BrighTown.Pages;

    public partial class LoginErrorPage : ContentPage
    {
    public LoginErrorPage() 
    {
        //InitializeComponent();
    }

    //public void DisplayPopUpError()
    //{

    //    //DisplayAlert("Упс!", "Ошибка входа", "Повторить попытку");
    //}

    private RelayCommand displayPopUpErrorComand;
    public ICommand DisplayPopUpErrorComand => displayPopUpErrorComand ??= new RelayCommand(PerformDisplayPopUpErrorComand);

    private void PerformDisplayPopUpErrorComand()
    {
        if (IsBusy) return;

    }
}
