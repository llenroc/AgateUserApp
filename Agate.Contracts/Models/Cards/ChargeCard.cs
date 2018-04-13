namespace Agate.Contracts.Models.Cards
{
    public class ChargeCardRequest
    {
        public decimal Amount { get; set; }
    }

    public class ChargeCardResponse : ApiResponse
    {
        public decimal NewCardBalance { get; set; }
    }

    public enum ChargeCardErrorCodes
    {
        InsufficientBalance
    }
}
