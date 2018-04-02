using Agate.Business.API;
using Agate.Business.Services;
using Agate.Contracts.Models.Transactions;
using Plugin.SecureStorage.Abstractions;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class TransferAssetViewModel : BaseViewModel
    {
        private readonly ISecureStorage secureStorage;

        public TransferAssetViewModel(ISecureStorage secureStorage)
        {
            this.secureStorage = secureStorage;
        }

        public void Initialize(AssetHomeViewModel parent)
        {
            Parent = parent;
            TransferCommand = new XCommand(Transfer, CanTransfer);

            Amount = new Property<decimal>().Required("Please enter an amount.");
        }
        public AssetHomeViewModel Parent { get; set; }
        public Property<decimal> Amount { get; set; }
        public IXCommand TransferCommand { get; set; }

        public bool CanTransfer()
        {
            return IsNotBusy && Validation.Check(Amount);
        }
        public async void Transfer()
        {
            var request = new TransferOrderRequest
            {
                Amount = Amount.Value,
                AssetId = Parent.Asset.AssetId,
                UserId = secureStorage.GetUserId().Value
            };
            var response = await TransactionService.TransferOrder(request);
            Parent.UserAsset.Balance = response.AssetNewBalance;
            // todo : find the local instance of Card and update it Balance value
        }
    }
}