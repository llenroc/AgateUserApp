using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agate.Business.AppLogic;
using Agate.Business.LocalData;
using Triplezerooo.XMVVM;
using Xamarin.Forms;

namespace Agate.Business.ViewModels.Main
{
    public class ChooseAssetsViewModel : BaseViewModel
    {
        private readonly IAppData appData;
        private Asset[] allAssets;
        private List<UserAsset> userAssets;
        private object _lock = new object();

        public ChooseAssetsViewModel(IAppData appData)
        {
            this.appData = appData;
        }

        public void Initialize(Asset[] allAssets, UserAsset[] userAssets)
        {

            this.allAssets = allAssets;
            this.userAssets = userAssets.ToList();

            var assetSelectionQuery = from asset in allAssets
                                      let userAsset = userAssets.SingleOrDefault(ua => ua.AssetId == asset.AssetId) ?? new UserAsset { AssetId = asset.AssetId, Balance = 0, Favorited = false }
                                      select new AssetSelectionRow(this, asset, userAsset);

            Assets = assetSelectionQuery.ToList();
        }

        public List<AssetSelectionRow> Assets { get; set; }

        public async void SelectionChanged(AssetSelectionRow changedRow)
        {
            await Save(changedRow);
        }

        private async Task Save(AssetSelectionRow changedAsset)
        {
            if (!userAssets.Contains(changedAsset.UserAsset))
                userAssets.Add(changedAsset.UserAsset);

            appData.UserAssets = userAssets.ToArray();

            await UserData.SaveUserAssets(appData.UserAssets);
        }
    }

    public class AssetSelectionRow
    {
        private readonly ChooseAssetsViewModel container;
        private readonly Asset asset;
        private readonly UserAsset userAsset;
        private ImageSource _assetLogoImageSource;

        public AssetSelectionRow(ChooseAssetsViewModel container, Asset asset, UserAsset userAsset)
        {
            this.container = container;
            this.asset = asset;
            this.userAsset = userAsset;
            _assetLogoImageSource = ImageSource.FromFile(asset.LogoName);
        }
        public int AssetId => asset.AssetId;
        public ImageSource AssetLogoImageSource => _assetLogoImageSource;
        public string AssetSymbol => asset.AssetSymbol;
        public string AssetName => asset.AssetName;
        public bool Selected
        {
            get => userAsset.Favorited;
            set
            {
                if (userAsset.Favorited == value)
                    return;
                userAsset.Favorited = value;
                container.SelectionChanged(this);
            }
        }

        public UserAsset UserAsset => userAsset;
    }

}