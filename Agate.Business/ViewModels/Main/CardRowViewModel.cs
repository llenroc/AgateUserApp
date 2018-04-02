using Agate.Business.LocalData;

namespace Agate.Business.ViewModels.Main
{
    public class CardRowViewModel
    {
        public CardRowViewModel(HomePageCardsViewModel parent, Card card)
        {
            Parent = parent;
            Card = card;
        }

        public HomePageCardsViewModel Parent { get; }
        public Card Card { get; }
        public string Balance => $"{Card.Balance:N} {Card.BalanceCurrency}";
    }
}