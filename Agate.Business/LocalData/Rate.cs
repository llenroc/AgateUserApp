namespace Agate.Business.LocalData
{
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