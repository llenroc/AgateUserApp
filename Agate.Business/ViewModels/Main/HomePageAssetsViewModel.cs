using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Agate.Business.AppLogic;
using Agate.Business.LocalData;
using Triplezerooo.XMVVM;
using Xamarin.Forms;

namespace Agate.Business.ViewModels.Main
{
    public class HomePageAssetsViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService navigation;
        private readonly Func<ChooseAssetsViewModel> createChooseAssetsViewModel;
        private readonly Func<AssetHomeViewModel> createAssetHomeViewModel;

        public HomePageAssetsViewModel(HomePageViewModel parent, INavigationService navigation, Func<ChooseAssetsViewModel> createChooseAssetsViewModel, Func<AssetHomeViewModel> createAssetHomeViewModel)
        {
            this.navigation = navigation;
            this.createChooseAssetsViewModel = createChooseAssetsViewModel;
            this.createAssetHomeViewModel = createAssetHomeViewModel;
            Parent = parent;
            ChooseAssetsCommand = new Command(async () => await ChooseAssets());
        }

        public HomePageViewModel Parent { get; }
        public List<AssetViewModel> List { get; set; }
        public ICommand ChooseAssetsCommand { get; }
        public async Task ChooseAssets()
        {
            await navigation.Push(createChooseAssetsViewModel());
        }

        public void Update(Asset[] assets, UserAsset[] userAssets, Rate[] rates)
        {
            var list = new List<AssetViewModel>();
            if (userAssets.Any())
            {
                foreach (var userAsset in userAssets.Where(u => u.Favorited))
                {
                    var asset = assets.Single(a => a.AssetId == userAsset.AssetId);
                    var rate = rates.SingleOrDefault(r => r.AssetId == asset.AssetId && r.TargetCurrency == AppData.UserCurrency);

                    var viewModel = new AssetViewModel(this, navigation, asset, userAsset, rate, createAssetHomeViewModel);

                    list.Add(viewModel);
                }
            }
            List = list;
            Raise(nameof(List));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void Raise(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}