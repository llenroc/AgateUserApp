namespace Agate.Contracts.Models.Transactions
{
    public class SendOrderRequest
    {
        public int UserId { get; set; }
        public int AssetId { get; set; }
        public string TargetAddress { get; set; }
        public decimal Amount { get; set; }
    }

    public class SendOrderResponse : BaseResponseModel
    {
        public decimal AssetNewBalance { get; set; }
    }
}
