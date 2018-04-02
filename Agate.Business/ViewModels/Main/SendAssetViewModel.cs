using System;
using System.Threading.Tasks;
using Agate.Business.API;
using Agate.Business.Services;
using Agate.Contracts.Models.Transactions;
using Plugin.Connectivity.Abstractions;
using Plugin.SecureStorage.Abstractions;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class SendAssetViewModel : BaseViewModel
    {
        private readonly ITransactionService transactionService;
        private readonly ISecureStorage secureStorage;
        private readonly IConnectivity connectivity;

        public SendAssetViewModel(ITransactionService transactionService, ISecureStorage secureStorage, IConnectivity connectivity)
        {
            this.transactionService = transactionService;
            this.secureStorage = secureStorage;
            this.connectivity = connectivity;
        }

        public void Initialize(AssetHomeViewModel parent)
        {
            Parent = parent;

            Amount = new Property<decimal>("amount")
                .Required("Please enter an amount.")
                .Check(amount => (Parent.UserAsset.Balance >= amount), "Insufficient funds");
            SendAddress = new Property<string>("address").RequiredString("Please specify address.");
            SendCommand = new XCommand(async () => await Send(), CanSend);

            SendCommand.SetDependency(this, Amount, SendAddress);
        }


        public AssetHomeViewModel Parent { get; set; }
        public Property<decimal> Amount { get; set; }
        public Property<string> SendAddress { get; set; }
        public IXCommand SendCommand { get; set; }

        public bool CanSend()
        {
            return IsNotBusy && Validation.Check(Amount, SendAddress);
        }

        public async Task Send()
        {
            try
            {
                using (WorkingScope.Enter())
                {
                    if (!connectivity.IsConnected)
                    {
                        await View.DisplayAlert("...", "Internet connection required", "Ok");
                        return;
                    }
                    var request = new SendOrderRequest
                    {
                        Amount = Amount.Value,
                        TargetAddress = SendAddress.Value,
                        AssetId = Parent.Asset.AssetId,
                        UserId = secureStorage.GetUserId().Value
                    };
                    var response = await transactionService.SendOrder(request);
                    Parent.UserAsset.Balance = response.AssetNewBalance;
                    await View.DisplayAlert("Done", "Send order submitted.", "Ok");
                }
            }
            catch (Exception ex)
            {
                await View.DisplayErrorAlert(ex.Message);
            }
        }
    }
}