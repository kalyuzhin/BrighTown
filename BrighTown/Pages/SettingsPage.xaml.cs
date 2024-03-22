using BrighTown.Models;

namespace BrighTown.Pages;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();

        ThemeSwitch.IsToggled =
            Preferences.Default.Get("theme", Application.Current.RequestedTheme.ToString() == "Dark");
    }


    void OnToggledThemeSwitcher(object sender, ToggledEventArgs e)
    {
        if (ThemeSwitch.IsToggled != (Application.Current.RequestedTheme.ToString() == "Dark"))
        {
            if (Application.Current.RequestedTheme.ToString() == "Dark")
            {
                Application.Current.UserAppTheme = AppTheme.Light;
                Preferences.Default.Set("theme", Application.Current.RequestedTheme.ToString() == "Dark");
            }
            else
            {
                Application.Current.UserAppTheme = AppTheme.Dark;
                Preferences.Default.Set("theme", Application.Current.RequestedTheme.ToString() == "Dark");
            }
        }
    }

    private void ClickOnChangeEmailButton(object sender, EventArgs e)
    {
     //   var email =  DisplayPromptAsync("Электронная почта", "Введите адрес:", "OK", "Отмена");
    //    App.user.Email = email.ToString();
    }
    private void ClickOnChangeNameButton(object sender, EventArgs e)
    {
      //  var name =  DisplayPromptAsync("Изменить имя пользователя", "Введите новое имя:", "OK", "Отмена");
     //  App.user.UserName = name.ToString();
    }
    private void ClickOnSettingsButton(object sender, EventArgs e) // ��������� ������� �� ������ "���������"
    {
        Shell.Current.GoToAsync("..");
    }
}