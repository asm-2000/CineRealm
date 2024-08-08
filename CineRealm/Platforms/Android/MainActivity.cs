using Android.App;
using Android.Content.PM;
using Android.OS;
using CineRealm.Pages;

namespace CineRealm
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        // Custom Styling for Android to colour System Bar (Top)
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#1f1f1f"));
            base.OnCreate(savedInstanceState);
        }
    }
}

