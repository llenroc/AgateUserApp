using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agate.Business;
using Agate.Business.Api;
using Agate.Business.AppLogic;
using Agate.Business.API;
using Agate.Business.Services;
using Agate.Business.ViewModels.Main;
using Agate.Business.ViewModels.User;
using Agate.ViewBridge;
using Autofac;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
using OpalApp.Services;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Plugin.DeviceInfo;
using Plugin.DeviceInfo.Abstractions;
using Plugin.SecureStorage;
using Plugin.SecureStorage.Abstractions;
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

            var builder = new ContainerBuilder();
		    builder.RegisterType<DataFlow>().As<IDataFlow>();
		    builder.RegisterType<UXFlow>().As<IUXFlow>();
		    builder.RegisterType<AppData>().As<IAppData>();
		    builder.RegisterType<DataReset>().As<DataReset>();
		    builder.Register(c => CrossSecureStorage.Current).As<ISecureStorage>();
		    builder.Register(c => CrossConnectivity.Current).As<IConnectivity>();
		    builder.RegisterType<AccountService>().As<IAccountService>();
		    builder.RegisterType<ViewService>().As<IViewService>();
		    builder.Register(c => DependencyService.Get<IPhoneService>()).As<IPhoneService>();
		    builder.Register(c => CrossDeviceInfo.Current).As<IDeviceInfo>();
		    builder.RegisterType<SignUpPageViewModel>();
		    builder.RegisterType<ConfirmationCodeEntryViewModel>();
		    builder.RegisterType<SetPinViewModel>();
		    builder.RegisterType<MainViewModel>();
		    builder.RegisterType<HomePageViewModel>();
		    builder.RegisterType<ChooseAssetsViewModel>();
		    builder.RegisterType<AssetHomeViewModel>();
		    builder.RegisterType<PinSignInViewModel>();
            
		    var container = builder.Build();

		    //var dataReset = container.Resolve<DataReset>();
		    //dataReset.SetTestUser().Wait();

		    var uxFlow = container.Resolve<IUXFlow>();
            uxFlow.DecideOnAppStartPage();
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
