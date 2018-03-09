namespace Agate.Contracts.Models.Cards
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CardNumberHint { get; set; } // only last 4 digit the rest is replaced by star
        public CardState State { get; set; }
        public decimal Balance { get; set; }
        public string BalanceCurrency { get; set; }
    }

    public enum CardState
    {
        Ordered,
        RequiresActivation,
        Active,
        Blocked,        
    }
}
