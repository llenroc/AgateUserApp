using System;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Agate.Business.Services;
using Agate.Business.ViewModels.Merchant;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class MainViewModel : BaseViewModel, IViewModelLifeTime
    {
        private readonly IViewService viewService;
        private readonly IAppInfo appInfo;
        public MainMenuViewModel MainMenu { get; }
        private readonly Func<HomePageViewModel> createHomePageViewModel;
        private readonly Func<ReceivePaymentViewModel> createReceivePaymentViewModelFunc;

        public MainViewModel(IViewService viewService, IAppInfo appInfo, MainMenuViewModel mainMenu, Func<HomePageViewModel> createHomePageViewModel, Func<ReceivePaymentViewModel> createReceivePaymentViewModelFunc)
        {
            this.viewService = viewService;
            this.appInfo = appInfo;
            this.MainMenu = mainMenu;
            this.createHomePageViewModel = createHomePageViewModel;
            this.createReceivePaymentViewModelFunc = createReceivePaymentViewModelFunc;
        }

        public string Title => appInfo.AppName;

        public async Task OnAppearing()
        {
            var navigationService = viewService.CreateNavigationService(this.View as INavigationView);
            MainMenu?.Initialize(navigationService);

            if (appInfo.Mode == AppMode.User)
            {
                var homePageViewModel = createHomePageViewModel();
                homePageViewModel.Initialize(navigationService);
                await navigationService.SetCurrentPage(homePageViewModel);
            }
            if (appInfo.Mode == AppMode.Merchant)
            {
                var receivePaymentViewModel = createReceivePaymentViewModelFunc();
                await navigationService.SetCurrentPage(receivePaymentViewModel);
            }
        }

        public async Task OnDisappearing()
        {
            
        }
    }
}
