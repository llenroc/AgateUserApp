using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agate.Business.Services;
using AgateMerchant.Droid.Implementations;
using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(PhoneService))]

namespace AgateMerchant.Droid.Implementations
{
    public class PhoneService : IPhoneService
    {
        public static TelephonyManager Manager => Application.Context.GetSystemService(Context.TelephonyService) as TelephonyManager;

        public static ConnectivityManager ConnectivityManager => Application.Context.GetSystemService(Context.ConnectivityService) as ConnectivityManager;

        /// <summary>
        /// Gets the ISO Country Code.
        /// </summary>
        public string ICC => Manager.SimCountryIso;

        /// <summary>
        /// Gets the Mobile Country Code.
        /// </summary>
        public string MCC => Manager.NetworkOperator;
    }
}