using CommunityToolkit.Mvvm.ComponentModel;

namespace BrighTown.ViewModel;

public partial class RegisterViewModel : ObservableObject
{ 
    IConnectivity _connectivity;

    public RegisterViewModel(IConnectivity connectivity)
    {
        this._connectivity = connectivity;
    }

    async Task Register()
    {
        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Упс!", "К сожалению вы не подключены к интернету...","Повторить попытку");
            return;
        }
    }
    
    
}