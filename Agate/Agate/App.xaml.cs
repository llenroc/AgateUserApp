using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agate.Business;
using Agate.Business.Api;
using Agate.Business.AppLogic;
using Agate.Business.API;
using Agate.Business.LocalData;
using Agate.Business.Services;
using Agate.Business.ViewModels.Main;
using Agate.Business.ViewModels.User;
using Agate.ViewBridge;
using Autofac;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;
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
		    builder.RegisterType<UserData>().As<IUserData>();
		    builder.RegisterType<DataFlow>().As<IDataFlow>();
		    builder.RegisterType<UXFlow>().As<IUXFlow>();
		    builder.RegisterType<AppData>().SingleInstance().As<IAppData>();
		    builder.RegisterType<GeneralData>().As<IGeneralData>();
		    builder.RegisterType<CardData>().As<ICardData>();
		    builder.RegisterType<RatesData>().As<IRatesData>();
		    builder.RegisterType<BucketData>().As<IBucketData>();
		    builder.RegisterType<DataReset>().As<DataReset>();
		    builder.Register(c => CrossSecureStorage.Current).As<ISecureStorage>();
		    builder.Register(c => CrossConnectivity.Current).As<IConnectivity>();
		    builder.RegisterType<AccountService>().As<IAccountService>();
		    builder.RegisterType<UserAddressesServices>().As<IUserAddressesServices>();
		    builder.RegisterType<CardOrderService>().As<ICardOrderService>();
		    builder.RegisterType<CardsService>().As<ICardsService>();
		    builder.RegisterType<UserCardsService>().As<IUserCardsService>();
		    builder.RegisterType<RatesService>().As<IRatesService>();
		    builder.RegisterType<BucketService>().As<IBucketService>();
		    builder.RegisterType<TransactionService>().As<ITransactionService>();
		    builder.RegisterType<UserAssetsService>().As<IUserAssetsService>();
            builder.RegisterType<ViewService>().As<IViewService>();
		    builder.Register(c => DependencyService.Get<IPhoneService>()).As<IPhoneService>();
		    builder.Register(c => CrossDeviceInfo.Current).As<IDeviceInfo>();
		    builder.RegisterType<SignUpPageViewModel>();
		    builder.RegisterType<ConfirmationCodeEntryViewModel>();
		    builder.RegisterType<SetPinViewModel>();
		    builder.RegisterType<MainViewModel>();
		    builder.RegisterType<MainMenuViewModel>();
		    builder.RegisterType<HomePageViewModel>();
		    builder.RegisterType<HomePageAssetsViewModel>();
		    builder.RegisterType<HomePageBucketInfoViewModel>();
		    builder.RegisterType<HomePageCardsViewModel>();
		    builder.RegisterType<ChooseAssetsViewModel>();
		    builder.RegisterType<AssetHomeViewModel>();
		    builder.RegisterType<PinSignInViewModel>();
		    builder.RegisterType<EditAddressViewModel>();
		    builder.RegisterType<OrderNewCardViewModel>();
		    builder.RegisterType<SendAssetViewModel>();
		    builder.RegisterType<ReceiveAssetViewModel>();
		    builder.RegisterType<TransferAssetViewModel>();
		    builder.RegisterType<NotImplementedFeatureViewModel>();

		    var container = builder.Build();

		    var dataReset = container.Resolve<DataReset>();

            Task.Run((async () =>
            {
                //await dataReset.Reset();
                //await dataReset.SetTestUser();
            }));

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
