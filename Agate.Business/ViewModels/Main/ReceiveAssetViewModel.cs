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
            // todo : make sure we have a deposit address as it might be first time user using app and userasset read from file does not have address
            // so show a "Generating address ..." or not allow user to come to this page at all

            Parent = parent;
            DepositAddress = parent.UserAsset.CurrentReceiveAddress;

            GenerateNewAddressCommand = new XCommand(GenerateNewAddress);
        }
        public AssetHomeViewModel Parent { get; set; }
        public string DepositAddress { get; set; }
        public IXCommand GenerateNewAddressCommand { get; set; }
        public void GenerateNewAddress()
        {
            // todo : uncomment XAML part and implement here
        }
    }
}