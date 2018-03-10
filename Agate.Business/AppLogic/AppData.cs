using System.Linq;
using System.Threading.Tasks;
using Agate.Business.Api;
using OpalApp.LocalData;
using OpalApp.Services;

namespace Agate.Business.AppLogic
{
    public class AppData
    {
        public static string UserCurrency = "USD";

        public static Asset[] AllAssets { get; set; }
        public static UserAsset[] UserAssets { get; set; }
        public static Rate[] Rates { get; set; }
        public static decimal BucketAmount { get; set; }
        public static Card[] Cards { get; set; }

        private static bool online = false;
        private static object _lock = new object();

        public static async Task LoadOfflineData()
        {
            AllAssets = GetDefaultAssetValues(); // for now we just read a hard coded list of assets
            UserAssets = (await UserData.ReadUserAssets()) ?? new UserAsset[] { };
            Rates = (await RatesData.ReadRates()) ?? new Rate[] { };
            Cards = (await CardData.ReadCards()) ?? new Card[] { };
            BucketAmount = (await BucketData.ReadBucketInfo())?.Amount ?? 0;
        }

        public static async Task<bool> LoadOnlineData(bool forceLoad = false)
        {
            lock (_lock)
            {
                if (online)
                    return false;
                online = true;
            }

            try
            {
                var rates = await RatesService.Get();
                if(rates== null)
                {
                    online = false;
                    return false;
                }
                Rates = rates.Select(r => new Rate(r.AssetId, r.TargetCurrency, r.Amount, r.Fee)).ToArray();
                // if rates changed
                await RatesData.SaveRates(Rates);

                var cards = await CardsService.Get(UserAccount.UserId.Value);
                if(cards == null)
                {
                    online = false;
                    return false;
                }
                Cards = cards.Select(c => new Card(c.Id, c.Name, c.CardNumberHint, (CardState)(int)c.State, c.Balance, c.BalanceCurrency)).ToArray();
                // if cards changed
                await CardData.SaveCards(Cards);

                BucketAmount = (await BucketService.GetBalance(UserAccount.UserId.Value))?.Amount ?? 0;
                await BucketData.SaveBucketInfo(new BucketInfo { Amount = BucketAmount });

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


    public class Calculations
    {
        public static decimal EvaluateTotalAmount(string userCurrency, Asset[] assets, UserAsset[] userAssets, Rate[] rates, Card[] cards, decimal bucketAmount)
        {
            return 204843;
        }
    }
}
