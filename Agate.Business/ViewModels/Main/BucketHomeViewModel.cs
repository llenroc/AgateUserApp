using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agate.Business.AppLogic;
using Agate.Business.API;
using Agate.Business.LocalData;
using Agate.Business.Services;
using Agate.Contracts.Models.Cards;
using Agate.Contracts.Models.Transactions;
using Microsoft.AppCenter.Crashes;
using Plugin.Connectivity.Abstractions;
using Plugin.SecureStorage.Abstractions;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class BucketHomeViewModel : BaseViewModel
    {
        private readonly ICardsService cardsService;
        private readonly IConnectivity connectivity;
        private readonly IAppData appData;
        private readonly ICardData cardData;
        private readonly IBucketData bucketData;
        private readonly ISecureStorage secureStorage;

        public BucketHomeViewModel(ICardsService cardsService, ISecureStorage secureStorage, IConnectivity connectivity, IAppData appData, ICardData cardData, IBucketData bucketData)
        {
            this.cardsService = cardsService;
            this.connectivity = connectivity;
            this.appData = appData;
            this.cardData = cardData;
            this.bucketData = bucketData;
            this.secureStorage = secureStorage;
            Amount = new Property<string>("Amount").RequiredString("Please specify amount").RequiredFormat(@"^\d*(\.\d+)?$", "Please specify a valid number");
            SendCommand = new XCommand(async () => await Send(), CanSend);
            SendCommand.SetDependency(Amount);

            CardBalance = appData.Cards.Any() ? $"$ {appData.Cards.First().Balance}" : "You do not have any cards. Order a card first.";
            BucketBalance = appData.BucketAmount;
        }

        public Property<string> Amount { get; set; }
        public decimal BucketBalance { get; set; }
        public string CardBalance { get; set; }
        public IXCommand SendCommand { get; set; }

        public bool CanSend()
        {
            return IsNotBusy && Validation.Check(Amount);
        }

        public async Task Send()
        {
            try
            {
                if (!CanSend())
                    return;

                if (!connectivity.IsConnected)
                {
                    await View.DisplayAlert("...", "Internet connection required", "Ok");
                    return;
                }

                var amount = decimal.Parse(Amount.Value);

                var request = new ChargeCardRequest
                {
                    Amount = amount,
                };

                using (WorkingScope.Enter())
                {
                    var response = await cardsService.ChargeCard(secureStorage.GetUserId().Value, appData.Cards.First().Id, request);

                    appData.Cards.First().Balance = response.NewCardBalance;
                    appData.BucketAmount = response.NewBucketAmount;

                    await cardData.SaveCards(appData.Cards);
                    await bucketData.SaveBucketInfo(new BucketInfo {Amount = appData.BucketAmount});
                }

                await View.DisplayAlert("Done", "Card charged successfully!", "Ok");
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                    {
                        {"page", "send bucket to card"},
                        {"operation", $"{nameof(BucketHomeViewModel)}.{nameof(Send)}"}
                    });
                await View.DisplayAlert("Error", "An error occurred while processing your request" + ex, "Ok");
            }
        }
    }
}
