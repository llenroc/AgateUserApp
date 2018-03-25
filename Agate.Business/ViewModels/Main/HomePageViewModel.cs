using System;
using System.Text;
using Agate.Business.AppLogic;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class HomePageViewModel : BaseViewModel
    {
        private readonly IAppData appData;
        private readonly INavigationService navigationService;
        private string totalAmount;

        public HomePageViewModel(IView view, IAppData appData, INavigationService navigationService, Func<ChooseAssetsViewModel> createChooseAssetsViewModel, Func<AssetHomeViewModel> createAssetHomeViewModel)
        {
            this.appData = appData;
            this.navigationService = navigationService;
            View = view;
            Assets = new HomePageAssetsViewModel(this, navigationService, createChooseAssetsViewModel, createAssetHomeViewModel);
            Bucket = new HomePageBucketInfoViewModel(this);
            Cards = new HomePageCardsViewModel(this, navigationService);

            ShowData();
        }

        public string TotalAmount
        {
            get => totalAmount;
            set
            {
                if (totalAmount == value)
                    return;
                totalAmount = value;
                Raise(nameof(TotalAmount));
            }
        }

        public HomePageAssetsViewModel Assets { get; }
        public HomePageBucketInfoViewModel Bucket { get; }
        public HomePageCardsViewModel Cards { get; }

        public async void OnAppearing()
        {
            ShowData();

            var reloaded = await appData.LoadOnlineData();

            // todo : it actually needs to reload only if data is received from server
            // otherwise changes from other pages should be applied partially only for the parts that changed
            if (reloaded)
            {
                ShowData();
            }
        }

        public void ShowData()
        {
            var newTotalAmount = Calculations.EvaluateTotalAmount(AppData.UserCurrency, appData.AllAssets, appData.UserAssets, appData.Rates, appData.Cards, appData.BucketAmount);
            TotalAmount = $"{newTotalAmount} {AppData.UserCurrency}";
            Assets.Update(appData.AllAssets, appData.UserAssets, appData.Rates);
            Bucket.Balance = appData.BucketAmount;
            Cards.Update(appData.Cards);
        }
    }
}
