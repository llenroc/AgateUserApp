using System;
using System.Collections.Generic;
using System.Linq;
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
    public class TransferAssetViewModel : BaseViewModel
    {
        private readonly ITransactionService transactionService;
        private readonly ISecureStorage secureStorage;
        private readonly IAppData appData;
        private readonly IBucketData bucketData;
        private readonly IUserData userData;
        private readonly IConnectivity connectivity;
        private Asset asset;
        private UserAsset userAsset;
        private Rate rate;
        private string transferAmount;
        private bool showTransferAmount;

        public TransferAssetViewModel(ITransactionService transactionService, ISecureStorage secureStorage, IAppData appData, IBucketData bucketData, IUserData userData, IConnectivity connectivity)
        {
            this.transactionService = transactionService;
            this.secureStorage = secureStorage;
            this.appData = appData;
            this.bucketData = bucketData;
            this.userData = userData;
            this.connectivity = connectivity;
        }

        public void Initialize(Asset asset, UserAsset userAsset)
        {
            this.asset = asset;
            this.userAsset = userAsset;
            this.rate = appData.Rates.SingleOrDefault(r => r.AssetId == asset.AssetId && r.TargetCurrency == "iBucket");

            TransferCommand = new XCommand(Transfer, CanTransfer);

            Amount = new Property<decimal>().Required("Please enter an amount.");
            Amount.PropertyChanged += Amount_Changed;
        }

        private void Amount_Changed(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (rate != null)
            {
                TransferAmount = $"{Amount.Value * rate.Amount - rate.Fee}";
            }
            else
            {
                TransferAmount = "No exchange rate found";
            }

            ShowTransferAmount = Amount.Value > 0;
        }

        public Property<decimal> Amount { get; set; }
        public IXCommand TransferCommand { get; set; }

        public string TransferAmount
        {
            get => transferAmount;
            set
            {
                if (value == transferAmount)
                    return;

                transferAmount = value;
                Raise(nameof(TransferAmount));
            }
        }

        public bool ShowTransferAmount
        {
            get => showTransferAmount;
            set
            {
                if(value == showTransferAmount)
                    return;
                
                showTransferAmount = value;
                Raise(nameof(ShowTransferAmount));
            }
        }

        public bool CanTransfer()
        {
            return IsNotBusy && Validation.Check(Amount);
        }
        public async void Transfer()
        {
            try
            {
                if (!connectivity.IsConnected)
                {
                    await View.DisplayAlert("...", "Internet connection required", "Ok");
                    return;
                }

                var request = new TransferOrderRequest
                {
                    Amount = Amount.Value,
                    AssetId = asset.AssetId,
                    AcceptedFee = rate.Fee,
                    UserId = secureStorage.GetUserId().Value
                };

                using (WorkingScope.Enter())
                {
                    var response = await transactionService.TransferOrder(request);

                    userAsset.Balance = response.AssetNewBalance;

                    await userData.SaveUserAssets(appData.UserAssets);

                    appData.BucketAmount = response.BucketNewBalance;
                    await bucketData.SaveBucketInfo(new BucketInfo() {Amount = appData.BucketAmount});
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    {"page", "asset page"},
                    {"operation", $"{nameof(TransferAssetViewModel)}.{nameof(Transfer)}"}
                });
                await View.DisplayAlert("Error", "An error occurred while processing your request" + ex, "Ok");
            }

        }
    }
}