﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agate.Business.Services;
using Agate.Droid.Implementations;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(AppInfo))]

namespace Agate.Droid.Implementations
{
    public class AppInfo : IAppInfo
    {
        public AppMode Mode => AppMode.User;
        public string AppName => "Agate User";
    }
}