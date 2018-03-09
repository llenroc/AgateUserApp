namespace Agate.Contracts.Models.Transactions
{
    public class GenerateDepositAddressRequest
    {
        public int UserId { get; set; }
        public int AssetId { get; set; }
    }

    public class GenerateDepositAddressResponse : BaseResponseModel
    {
        public string Address { get; set; }
    }
}
