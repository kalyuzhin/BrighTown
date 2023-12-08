using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrighTown.Pages;

public partial class SettingsPage : ContentPage
{
   
    public SettingsPage()
    {
        InitializeComponent();
        ThemeSwitch.IsToggled = (Application.Current.RequestedTheme.ToString() == "Dark");
    }

   
   
    void OnToggledThemeSwitcher(object sender, ToggledEventArgs e)
    {
        if (ThemeSwitch.IsToggled != (Application.Current.RequestedTheme.ToString() == "Dark"))
        {
            if (Application.Current.RequestedTheme.ToString() == "Dark")
            {
                Application.Current.UserAppTheme = AppTheme.Light;
            }
            else
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
            }

        }
    }
    
    
    
    private void ClickOnSettingsButton(object sender, EventArgs e) // ��������� ������� �� ������ "���������"
    {
        Shell.Current.GoToAsync("..");
    }
    
    
}