using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Agate.Business.LocalData;
using Triplezerooo.XMVVM;
using Xamarin.Forms;

namespace Agate.Business.ViewModels.Main
{
    public class AssetViewModel
    {
        private readonly INavigationService navigationService;
        private readonly Func<AssetHomeViewModel> createAssetHomeViewModel;

        public AssetViewModel(HomePageAssetsViewModel parent, INavigationService navigationService, Asset asset, UserAsset userAsset, Rate rate, Func<AssetHomeViewModel> createAssetHomeViewModel)
        {
            this.navigationService = navigationService;
            this.createAssetHomeViewModel = createAssetHomeViewModel;
            Parent = parent;
            Asset = asset;
            UserAsset = userAsset;
            Rate = rate;
            ShowAssetCommand = new Command(async ()=> await ShowAsset());
        }

        public HomePageAssetsViewModel Parent { get; }
        public Asset Asset { get; }
        public UserAsset UserAsset { get; }
        public Rate Rate { get; }
        public string Balance => $"{UserAsset.Balance} ${Asset.AssetSymbol}";
        public string FiatBalance => Rate != null ? $"{Rate.TargetCurrency} {UserAsset.Balance * Rate.Amount}" : "";
        public ICommand ShowAssetCommand { get; }
        public async Task ShowAsset()
        {
            var assetHomeViewModel = createAssetHomeViewModel();
            assetHomeViewModel.Initialize(Asset, UserAsset, Rate);
            await navigationService.Push(assetHomeViewModel);
        }
    }
}