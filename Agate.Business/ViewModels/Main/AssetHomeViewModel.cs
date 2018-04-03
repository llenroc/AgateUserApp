using Agate.Business.LocalData;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class AssetHomeViewModel : BaseViewModel
    {
        public AssetHomeViewModel(SendAssetViewModel sendViewModel, ReceiveAssetViewModel receiveAssetViewModel, TransferAssetViewModel transferAssetViewModel)
        {
            this.SendViewModel = sendViewModel;
            this.ReceiveViewModel = receiveAssetViewModel;
            this.TransferViewModel = transferAssetViewModel;
        }
        public void Initialize(Asset asset, UserAsset userAsset, Rate rate)
        {
            Asset = asset;
            UserAsset = userAsset;
            Rate = rate;

            SendViewModel.Initialize(asset, userAsset);
            ReceiveViewModel.Initialize(this);
            TransferViewModel.Initialize(asset, userAsset);
        }

        public Asset Asset { get; set; }
        public UserAsset UserAsset { get; set; }
        public Rate Rate { get; set; }
        public SendAssetViewModel SendViewModel { get; set; }
        public ReceiveAssetViewModel ReceiveViewModel { get; set; }
        public TransferAssetViewModel TransferViewModel { get; set; }
    }
}