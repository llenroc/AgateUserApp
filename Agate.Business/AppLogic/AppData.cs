using System;
using System.Linq;
using System.Threading.Tasks;
using Agate.Business.Api;
using Agate.Business.API;
using Agate.Business.LocalData;
using Agate.Business.Services;
using OpalApp.Services;
using Plugin.SecureStorage.Abstractions;

namespace Agate.Business.AppLogic
{
    public class AppData : IAppData
    {
        public static string UserCurrency = "USD";

        private readonly ISecureStorage secureStorage;
        private readonly IUserData userData;
        private readonly ICardsService cardsService;
        private readonly IRatesService ratesService;
        private readonly IBucketService bucketService;
        private readonly IUserAssetsService userAssetsService;
        private readonly IRatesData ratesData;
        private readonly ICardData cardData;
        private readonly IBucketData bucketData;

        public AppData(ISecureStorage secureStorage,IUserData userData, ICardsService cardsService, IRatesService ratesService, IBucketService bucketService, IUserAssetsService userAssetsService, IRatesData ratesData, ICardData cardData, IBucketData bucketData)
        {
            this.secureStorage = secureStorage;
            this.userData = userData;
            this.cardsService = cardsService;
            this.ratesService = ratesService;
            this.bucketService = bucketService;
            this.userAssetsService = userAssetsService;
            this.ratesData = ratesData;
            this.cardData = cardData;
            this.bucketData = bucketData;
        }

        public Asset[] AllAssets { get; set; }
        public UserAsset[] UserAssets { get; set; }
        public Rate[] Rates { get; set; }
        public decimal BucketAmount { get; set; }
        public Card[] Cards { get; set; }

        private bool online = false;
        private object _lock = new object();

        public async Task LoadOfflineData()
        {
            AllAssets = GetDefaultAssetValues(); // for now we just read a hard coded list of assets
            UserAssets = (await userData.ReadUserAssets()) ?? new UserAsset[] { };
            Rates = (await ratesData.ReadRates()) ?? new Rate[] { };
            Cards = (await cardData.ReadCards()) ?? new Card[] { };
            BucketAmount = (await bucketData.ReadBucketInfo())?.Amount ?? 0;
        }

        public async Task<bool> LoadOnlineData(bool forceLoad = false)
        {
            async Task<bool> LoadRates()
            {
                var rates = await ratesService.Get();
                if (rates == null)
                {
                    online = false;
                    return false;
                }

                Rates = rates.Select(r => new Rate(r.AssetId, r.TargetCurrency, r.Amount, r.Fee)).ToArray();
                // if rates changed
                await ratesData.SaveRates(Rates);
                return true;
            }

            async Task<bool> LoadUserAssets()
            {
                var userAssets = await userAssetsService.Get(secureStorage.GetUserId().Value);
                if(userAssets == null)
                {
                    online = false;
                    return false;
                }

                UserAssets = userAssets.Select(a=>new UserAsset{ AssetId = a.AssetId, Balance = a.Balance, CurrentReceiveAddress = a.CurrentReceiveAddress, Favorited = a.Favorited}).ToArray();

                await userData.SaveUserAssets(UserAssets);

                return true;
            }

            async Task<bool> LoadCards()
            {
                var cards = await cardsService.Get(secureStorage.GetUserId().Value);
                if (cards == null)
                {
                    online = false;
                    return false;
                }

                Cards = cards.Select(c => new Card(c.Id, c.Name, c.CardNumberHint, (CardState)(int)c.State, c.Balance, c.BalanceCurrency)).ToArray();
                // if cards changed
                await cardData.SaveCards(Cards);
                return true;
            }

            async Task<Boolean> LoadBucketAmount()
            {
                var bucketAmount = (await bucketService.GetBalance(secureStorage.GetUserId().Value));
                if(bucketAmount == null)
                {
                    online = false;
                    return false;
                }

                BucketAmount = bucketAmount.Amount;
                await bucketData.SaveBucketInfo(new BucketInfo {Amount = BucketAmount});
                return true;
            }



            lock (_lock)
            {
                if (online)
                    return false;
                online = true;
            }

            try
            {
                if (!await LoadRates()) return false;

                if (!await LoadCards()) return false;

                if(!await LoadBucketAmount()) return false;

                if (!await LoadUserAssets()) return false;

                return true;
            }
            catch
            {
                online = false;
                throw;
            }
        }

        private static Asset[] GetDefaultAssetValues()
        {
            return new[] {
                new Asset{AssetId = 1, AssetSymbol = "BTC",AssetName="Bitcoin", LogoName ="btc.png"},
                new Asset{AssetId = 2, AssetSymbol = "ETH",AssetName="Ethereum", LogoName = "eth.png"},
                new Asset{AssetId = 3, AssetSymbol = "XRP", AssetName="Ripple", LogoName="xrp.png"},
                new Asset{AssetId = 4, AssetSymbol = "BCH", AssetName="Bitcoin Cash", LogoName = "bch.png"},
                new Asset{AssetId = 5, AssetSymbol = "LTC", AssetName="Litecoin", LogoName = "ltc.png"}
            };
        }

    }
}
