using System;
using System.Collections.Generic;
using Agate.Business.API;
using Agate.Business.Services;
using Agate.Contracts.Models.Transactions;
using Microsoft.AppCenter.Crashes;
using Plugin.SecureStorage.Abstractions;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class TransferAssetViewModel : BaseViewModel
    {
        private readonly ITransactionService transactionService;
        private readonly ISecureStorage secureStorage;

        public TransferAssetViewModel(ITransactionService transactionService, ISecureStorage secureStorage)
        {
            this.transactionService = transactionService;
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
            try
            {
                var request = new TransferOrderRequest
                {
                    Amount = Amount.Value,
                    AssetId = Parent.Asset.AssetId,
                    UserId = secureStorage.GetUserId().Value
                };
                TransferOrderResponse response;
                using (WorkingScope.Enter())
                {
                    response = await transactionService.TransferOrder(request);
                }

                Parent.UserAsset.Balance = response.AssetNewBalance;
                // todo : find the local instance of Card and update it Balance value
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