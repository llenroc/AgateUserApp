using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class ReceiveAssetViewModel : BaseViewModel
    {
        public ReceiveAssetViewModel()
        {
        }

        public void Initialize(AssetHomeViewModel parent)
        {
            Parent = parent;
            DepositAddress = parent.UserAsset.CurrentReceiveAddress;
        }

        public AssetHomeViewModel Parent { get; set; }
        public string DepositAddress { get; set; }
    }
}