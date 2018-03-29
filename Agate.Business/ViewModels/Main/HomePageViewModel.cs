using System;
using System.Text;
using System.Threading.Tasks;
using Agate.Business.AppLogic;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class HomePageViewModel : BaseViewModel, IViewModelLifeTime
    {
        private readonly IAppData appData;
        private readonly IUXFlow uxFlow;
        private string totalAmount;

        public HomePageViewModel(
            IAppData appData, 
            IUXFlow uxFlow,
            Func<ChooseAssetsViewModel> createChooseAssetsViewModel, 
            Func<AssetHomeViewModel> createAssetHomeViewModel, 
            HomePageAssetsViewModel assetsViewModel,
            HomePageBucketInfoViewModel bucketInfoViewModel,
            HomePageCardsViewModel cardsViewModel)
        {
            this.appData = appData;
            this.uxFlow = uxFlow;

            Assets = assetsViewModel;
            Bucket = bucketInfoViewModel;
            Cards = cardsViewModel;
        }

        public async Task Initialize(INavigationService navigationService)
        {
            Assets.Initialize(this, navigationService);
            Bucket.Initialize(this);
            Cards.Initialize(this, navigationService);

            await appData.LoadOfflineData();

            ShowData();

            await appData.LoadOnlineData(false);
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

        public async Task OnAppearing()
        {
            ShowData();

            var reloaded = await appData.LoadOnlineData();

            if (reloaded)
            {
                ShowData();
            }
        }

        public async Task OnDisappearing()
        {
        }

        public void ShowData()
        {
            var newTotalAmount = Calculations.EvaluateTotalAmount(AppData.UserCurrency, appData.AllAssets, appData.UserAssets, appData.Rates, appData.Cards, appData.BucketAmount);
            TotalAmount = $"{newTotalAmount:C}";
            Assets.Update(appData.AllAssets, appData.UserAssets, appData.Rates);
            Bucket.Balance = appData.BucketAmount;
            Cards.Update(appData.Cards);
        }
    }
}
