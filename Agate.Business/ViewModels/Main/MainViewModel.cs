using System;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Agate.Business.Services;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class MainViewModel : BaseViewModel, IViewModelLifeTime
    {
        private readonly IViewService viewService;
        private readonly IAppInfo appInfo;
        public MainMenuViewModel MainMenu { get; }
        private readonly Func<HomePageViewModel> createHomePageViewModel;

        public MainViewModel(IViewService viewService, IAppInfo appInfo, MainMenuViewModel mainMenu, Func<HomePageViewModel> createHomePageViewModel)
        {
            this.viewService = viewService;
            this.appInfo = appInfo;
            this.MainMenu = mainMenu;
            this.createHomePageViewModel = createHomePageViewModel;
        }

        public string Title => appInfo.AppName;

        public async Task OnAppearing()
        {
            var navigationService = viewService.CreateNavigationService(this.View as INavigationView);
            MainMenu?.Initialize(navigationService);

            var homePageViewModel = createHomePageViewModel();
            homePageViewModel.Initialize(navigationService);

            await navigationService.SetCurrentPage(homePageViewModel);
        }

        public async Task OnDisappearing()
        {
            
        }
    }
}
