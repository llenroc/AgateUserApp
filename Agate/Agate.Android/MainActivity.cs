using System;
using Agate.Business;
using Agate.Business.API;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Droid;
using Java.Interop;
using Java.Util;
using UXDivers.Artina.Shared;
using Xamarin.Forms.Platform.Android;

namespace Agate.Droid
{
    [Activity(
    Label = "Agate User's Wallet",
    Icon = "@drawable/icon",
    Theme = "@style/Theme.Splash",
    MainLauncher = false,
    LaunchMode = LaunchMode.SingleTask,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.Locale | ConfigChanges.LayoutDirection
    )]

    public class MainActivity : FormsAppCompatActivity
    {
        private Locale locale;

        protected override void OnCreate(Bundle bundle)
        {
            // Changing to App's theme since we are OnCreate and we are ready to 
            // "hide" the splash
            Window.RequestFeature(WindowFeatures.ActionBar);
            SetTheme(Resource.Style.AppTheme);

            ToolbarResource = Resource.Layout.Toolbar;
            TabLayoutResource = Resource.Layout.Tabs;

            base.OnCreate(bundle);

            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            ZXing.Mobile.MobileBarcodeScanner.Initialize(this.Application);

            // Initializing FFImageLoading
            CachedImageRenderer.Init(true);

            Xamarin.Forms.Forms.Init(this, bundle);
            GrialKit.Init(this, "Agate.Droid.GrialLicense");

            FormsHelper.ForceLoadingAssemblyContainingType(typeof(UXDivers.Effects.Effects));

            locale = Resources.Configuration.Locale;

            LoadApplication(new App());
        }

        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            GrialKit.NotifyConfigurationChanged(newConfig);

            if ((int)Build.VERSION.SdkInt <= 19 &&
                !locale.Equals(newConfig.Locale))
            {
                // Need to recreate the activity when locale has changed for APIs 18 and 19 
                // as changes in ConfigChanges.Locale break images used in the app
                Recreate();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        [Export]
        public void SetServicesAddress(String baseAddress)
        {
            Client.BaseAddress = baseAddress;
        }
    }
}

