namespace Agate.Contracts.Models.Cards
{
    public class ChargeCardRequest
    {
        public decimal Amount { get; set; }
    }

    public class ChargeCardResponse : BaseResponseModel
    {
        public decimal NewCardBalance { get; set; }
    }
}
