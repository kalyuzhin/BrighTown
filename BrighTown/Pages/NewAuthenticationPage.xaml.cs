using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrighTown.ViewModels;
using Esri.ArcGISRuntime.Mapping;


namespace BrighTown.Pages;

public partial class NewAuthenticationPage : ContentPage
{
    public NewAuthenticationPage(NewAuthenticationViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;


        if (Preferences.Default.Get("theme",Application.Current.RequestedTheme.ToString() == "Dark"))
        {

            Application.Current.UserAppTheme = AppTheme.Dark;

        }
        else
        {
            Application.Current.UserAppTheme = AppTheme.Light;
        }
        


    }

    async void Login(object sender, EventArgs e)
    {
        if (IsBusy)
        {
            return;
        }
        
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Упс!", "К сожалению вы не подключены к интернету...",
                "Повторить попытку");
            return;
        }

        try
        {
            IsBusy = true;
            await Shell.Current.GoToAsync($"//{nameof(MapPage)}");
            //await Shell.Current.Navigation.PushModalAsync(new MapPage());
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Упс!", "К сожалению произошла ошибка...", "ОК");
        }
        finally
        {
            IsBusy = false;
        }
    }

    async void MoveToRegisterPage(object sender, EventArgs e)
    {
        if (IsBusy)
        {
            return;
        }
        
        // if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        // {
        //     await Shell.Current.DisplayAlert("Упс!", "К сожалению вы не подключены к интернету...",
        //         "Повторить попытку");
        //     return;
        // }

        try
        {
            IsBusy = true;
            //Routing.RegisterRoute("RegisterPage", typeof(RegisterPage));
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
            //await Shell.Current.Navigation.PushModalAsync(new MapPage());
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Упс!", "К сожалению произошла ошибка...", "ОК");
        }
        finally
        {
            IsBusy = false;
        }
    }
    
}