using System.Linq;
using Agate.Business.LocalData;

namespace Agate.Business.AppLogic
{
    public class Calculations
    {
        public static decimal EvaluateTotalAmount(string userCurrency, Asset[] assets, UserAsset[] userAssets, Rate[] rates, Card[] cards, decimal bucketAmount)
        {
            var ratesByAssetId = rates.Where(r=>r.TargetCurrency=="USD").ToDictionary(r => r.AssetId, r => r);
            var assetsTotal = userAssets.Sum(a => a.Balance * ratesByAssetId[a.AssetId]?.Amount ?? 0);
            var cardsTotal = cards.Sum(c => c.Balance);
            var bucketTotal = bucketAmount;

            return assetsTotal + cardsTotal + bucketTotal;
        }
    }
}