namespace Agate.Contracts.Models.Transactions
{
    public class TransferOrderRequest
    {
        public int UserId { get; set; }
        public int AssetId { get; set; }
        public int CardId { get; set; }
        public decimal AcceptedFee { get; set; }
        public decimal Amount { get; set; }
    }

    public class TransferOrderResponse : BaseResponseModel
    {
        public decimal AssetNewBalance { get; set; }
        public decimal CardNewBalance { get; set; }
        public decimal BucketNewBalance { get; set; }
    }
}
