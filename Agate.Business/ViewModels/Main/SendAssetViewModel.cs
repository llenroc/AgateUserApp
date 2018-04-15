using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Agate.Business.AppLogic;
using Agate.Business.API;
using Agate.Business.LocalData;
using Agate.Business.Services;
using Agate.Contracts.Models.Transactions;
using Microsoft.AppCenter.Crashes;
using Plugin.Connectivity.Abstractions;
using Plugin.SecureStorage.Abstractions;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class SendAssetViewModel : BaseViewModel
    {
        private readonly ITransactionService transactionService;
        private readonly IAppData appData;
        private readonly IUserData userData;
        private readonly ISecureStorage secureStorage;
        private readonly IConnectivity connectivity;
        private Asset asset;
        private UserAsset userAsset;

        public SendAssetViewModel(ITransactionService transactionService, IAppData appData, IUserData userData, ISecureStorage secureStorage, IConnectivity connectivity)
        {
            this.transactionService = transactionService;
            this.appData = appData;
            this.userData = userData;
            this.secureStorage = secureStorage;
            this.connectivity = connectivity;
        }

        public void Initialize(Asset asset, UserAsset userAsset)
        {
            this.asset = asset;
            this.userAsset = userAsset;

            Amount = new Property<decimal>("amount")
                .Required("Please enter an amount.")
                .Check(amount => (userAsset.Balance >= amount), "Insufficient funds");
            SendAddress = new Property<string>("address").RequiredString("Please specify address.");
            SendCommand = new XCommand(async () => await Send(), CanSend);

            SendCommand.SetDependency(this, Amount, SendAddress);
        }


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
                if (!connectivity.IsConnected)
                {
                    await View.DisplayAlert("...", "Internet connection required", "Ok");
                    return;
                }

                var request = new SendOrderRequest
                {
                    Amount = Amount.Value,
                    TargetAddress = SendAddress.Value,
                    AssetId = asset.AssetId,
                    UserId = secureStorage.GetUserId().Value,
                    AcceptedFee = 0,
                };

                SendOrderResponse response;
                using (WorkingScope.Enter())
                {
                    response = await transactionService.SendOrder(request);
                }

                userAsset.Balance = response.AssetNewBalance;

                await userData.SaveUserAssets(appData.UserAssets);
                
                await View.DisplayAlert("Done", "Send order submitted.", "Ok");
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                    {
                        {"page", "asset page"},
                        {"operation", $"{nameof(SendAssetViewModel)}.{nameof(Send)}"}
                    });
                await View.DisplayAlert("Error", "An error occurred while processing your request" + ex, "Ok");
            }
        }
    }
}