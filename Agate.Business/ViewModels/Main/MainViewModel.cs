using System;
using System.ComponentModel;
using System.Text;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class MainViewModel : BaseViewModel, IViewModelLifeTime
    {
        private readonly IViewService viewService;
        private readonly Func<HomePageViewModel> createHomePageViewModel;

        public MainViewModel(IViewService viewService, Func<HomePageViewModel> createHomePageViewModel)
        {
            this.viewService = viewService;
            this.createHomePageViewModel = createHomePageViewModel;
        }

        public void OnAppearing()
        {
            var navigationService = viewService.CreateNavigationService(this.View as INavigationView);

            var homePageViewModel = createHomePageViewModel();
            homePageViewModel.Initialize(navigationService);

            viewService.SetCurrentPage(homePageViewModel);
        }

        public void OnDisappearing()
        {
            
        }
    }
}
