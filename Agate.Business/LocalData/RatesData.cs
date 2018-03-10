using System.Threading.Tasks;
using static OpalApp.LocalData.FilesFacade;

namespace OpalApp.LocalData
{
    public class RatesData
    {
        public const string RatesFileName = "rates.json";
        public static async Task<Rate[]> ReadRates() => await ReadObject<Rate[]>(RatesFileName);
        public static async Task SaveRates(Rate[] rates) => await SaveObject(RatesFileName, rates);
    }

    public class Rate
    {
        public Rate()
        {

        }
        public Rate(int assetId, string targetCurrency, decimal amount, decimal fee)
        {
            AssetId = assetId;
            TargetCurrency = targetCurrency;
            Amount = amount;
            Fee = fee;
        }

        public int AssetId { get; set; }
        public string TargetCurrency { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
    }
}
