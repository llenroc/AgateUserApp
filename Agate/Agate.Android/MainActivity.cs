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
    //[Activity(Label = "Agate", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    //public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    //{
    //    protected override void OnCreate(Bundle bundle)
    //    {
    //        TabLayoutResource = Resource.Layout.Tabbar;
    //        ToolbarResource = Resource.Layout.Toolbar;

    //        base.OnCreate(bundle);

    //        global::Xamarin.Forms.Forms.Init(this, bundle);
    //        LoadApplication(new App());
    //    }
    //}

    [Activity(
    Label = "Agate User's Wallet",
    Icon = "@drawable/icon",
    Theme = "@style/Theme.Splash",
    MainLauncher = true,
    LaunchMode = LaunchMode.SingleTask,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.Locale | ConfigChanges.LayoutDirection
    )
]

    public class MainActivity : FormsAppCompatActivity
    {
        private Locale _locale;

        protected override void OnCreate(Bundle bundle)
        {
            // Changing to App's theme since we are OnCreate and we are ready to 
            // "hide" the splash
            base.Window.RequestFeature(WindowFeatures.ActionBar);
            base.SetTheme(Resource.Style.AppTheme);

            FormsAppCompatActivity.ToolbarResource = Resource.Layout.Toolbar;
            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.Tabs;

            base.OnCreate(bundle);

            ZXing.Net.Mobile.Forms.Android.Platform.Init();

            // Initializing FFImageLoading
            CachedImageRenderer.Init(true);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            GrialKit.Init(this, "Agate.Droid.GrialLicense");

            FormsHelper.ForceLoadingAssemblyContainingType(typeof(UXDivers.Effects.Effects));

            _locale = Resources.Configuration.Locale;

            LoadApplication(new App());
        }

        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            GrialKit.NotifyConfigurationChanged(newConfig);

            if ((int)Build.VERSION.SdkInt <= 19 &&
                !_locale.Equals(newConfig.Locale))
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

