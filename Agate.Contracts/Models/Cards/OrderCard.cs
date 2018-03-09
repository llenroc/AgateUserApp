namespace Agate.Contracts.Models.Cards
{
    public class OrderCardRequest
    {
        public int UserId { get; set; }
    }

    public class OrderCardResponse : BaseResponseModel
    {
        public OrderCardResponse()
        {
            
        }

        public OrderCardResponse(string error)
        {
            Success = false;
            Error = error;
        }
    }

    public class CardOrderErrors
    {
        public const string AlreadyOrdered = "AlreadyOrdered";
    }
}
