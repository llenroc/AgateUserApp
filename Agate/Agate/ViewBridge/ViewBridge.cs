using System;
using System.Collections.Generic;
using System.Text;
using Agate.Business.ViewModels;
using Agate.Business.ViewModels.Main;
using Agate.Business.ViewModels.User;
using Agate.Views.Main;
using Agate.Views.User;
using Triplezerooo.XMVVM;
using Xamarin.Forms;

namespace Agate.ViewBridge
{
    public class ViewService : IViewService
    {
        public void SetCurrentPage(BaseViewModel viewModel)
        {
            Application.Current.MainPage = ViewModelToViewMapping.ResolvePageForViewModel(viewModel);
        }

        public INavigationService CreateNavigationService(INavigationView view)
        {
            return new NavigationService(view);
        }
    }

    public class ViewModelToViewMapping
    {
        public static Page ResolvePageForViewModel(BaseViewModel viewModel)
        {
            var view = CreateViewBasedOnViewModelType(viewModel);
            view.BindingContext = viewModel;
            viewModel.View = view as IView;
            
            if(viewModel is IViewModelLifeTime)
            {
                var lifeTimeAwareViewModel = viewModel as IViewModelLifeTime;
                view.Appearing += async (sender, args) => await lifeTimeAwareViewModel.OnAppearing();
                view.Disappearing += async (sender, args) => await lifeTimeAwareViewModel.OnDisappearing();
            }

            return view;
        }

        private static Page CreateViewBasedOnViewModelType(BaseViewModel viewModel)
        {
            if (viewModel.GetType() == typeof(SignUpPageViewModel))
            {
                return new SignUpPage();
            }
            if(viewModel.GetType() == typeof(ConfirmationCodeEntryViewModel))
            {
                return new ConfirmationCodeEntryPage();
            }
            if(viewModel.GetType() == typeof(SetPinViewModel))
            {
                return new SetPinPage();
            }
            if(viewModel.GetType() == typeof(MainViewModel))
            {
                return new MainPage();
            }
            if(viewModel.GetType() == typeof(HomePageViewModel))
            {
                return new HomePage();
            }
            if(viewModel.GetType() == typeof(PinSignInViewModel))
            {
                return new PinSignInPage();
            }
            if(viewModel.GetType() == typeof(AssetHomeViewModel))
            {
                return new AssetHomePage();
            }
            if(viewModel.GetType() == typeof(ChooseAssetsViewModel))
            {
                return new ChooseAssetsPage();
            }
            if(viewModel.GetType() == typeof(EditAddressViewModel))
            {
                return new EditAddressPage();
            }
            if(viewModel.GetType() == typeof(OrderNewCardViewModel))
            {
                return new OrderNewCardPage();
            }

            throw new Exception($"Implement ResolvePageForViewModel for {viewModel.GetType().Name}");
        }
    }
}
