using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agate.Business;
using Agate.Business.Api;
using Agate.Business.AppLogic;
using Agate.Business.ViewModels.User;
using Agate.ViewBridge;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using OpalApp.Services;
using Plugin.Connectivity;
using Plugin.DeviceInfo;
using Triplezerooo.XMVVM;
using Xamarin.Forms;

namespace Agate
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
		    Resources["DefaultStringResources"] = new Resx.AppResources();

            SingltonServices.ViewService = new ViewService();
            DataAccessServices.Account = new AccountService();

		    var signUpPage = new SignUpPageViewModel(DataAccessServices.Account, new DataFlow(), SingltonServices.ViewService, DependencyService.Get<IPhoneService>(), CrossDeviceInfo.Current, CrossConnectivity.Current);
            SingltonServices.ViewService.SetCurrentPage(signUpPage);
		}

		protected override void OnStart ()
		{
		    const string iosAppSecret = "7df34d42-0a03-4a9f-a531-258a00dcb43b";
		    const string androidAppSecret = "1b5839a3-c70b-4583-b903-3fee62584f5d";
		    AppCenter.Start($"android={androidAppSecret};ios={iosAppSecret}",typeof(Analytics), typeof(Crashes));
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
    }
}
