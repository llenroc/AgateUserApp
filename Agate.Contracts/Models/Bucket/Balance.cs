namespace Agate.Contracts.Models.Bucket
{
    public class BalanceRequest
    {
        public int UserId { get; set; }
    }

    public class BalanceResponse : BaseResponseModel
    {
        public decimal Amount { get; set; }
    }
}
