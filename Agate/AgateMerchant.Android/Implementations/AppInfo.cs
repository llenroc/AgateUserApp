using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agate.Business.Services;
using AgateMerchant.Droid.Implementations;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(AppInfo))]

namespace AgateMerchant.Droid.Implementations
{
    public class AppInfo : IAppInfo
    {
        public string AppName => "Agate Merchant";
    }
}