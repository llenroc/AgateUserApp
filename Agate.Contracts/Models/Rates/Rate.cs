namespace Agate.Contracts.Models.Rates
{
    public class Rate
    {
        public int AssetId { get; set; }
        public string TargetCurrency { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
    }    
}
