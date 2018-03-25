using System;
using System.Text;
using Agate.Business.AppLogic;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class HomePageViewModel : BaseViewModel
    {
        private readonly IAppData appData;
        private readonly IUXFlow uxFlow;
        private readonly Func<ChooseAssetsViewModel> createChooseAssetsViewModel;
        private readonly Func<AssetHomeViewModel> createAssetHomeViewModel;
        private string totalAmount;

        public HomePageViewModel(
            IAppData appData, 
            IUXFlow uxFlow,
            Func<ChooseAssetsViewModel> createChooseAssetsViewModel, 
            Func<AssetHomeViewModel> createAssetHomeViewModel)
        {
            this.appData = appData;
            this.uxFlow = uxFlow;
            this.createChooseAssetsViewModel = createChooseAssetsViewModel;
            this.createAssetHomeViewModel = createAssetHomeViewModel;
        }

        public void Initialize(INavigationService navigationService)
        {
            Assets = new HomePageAssetsViewModel(this, navigationService, createChooseAssetsViewModel, createAssetHomeViewModel);
            Bucket = new HomePageBucketInfoViewModel(this);
            Cards = new HomePageCardsViewModel(this, navigationService, uxFlow);

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

        public HomePageAssetsViewModel Assets { get; set; }
        public HomePageBucketInfoViewModel Bucket { get; set; }
        public HomePageCardsViewModel Cards { get; set; }

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
