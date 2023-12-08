using Android.App;
using Android.Content.PM;
using Android.OS;

namespace BrighTown
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
      
    }
    
    
}