﻿using System.Threading.Tasks;

namespace Agate.Business.LocalData
{
    public class CardData : ICardData
    {
        public const string CardsFileName = "cards.json";
        public async Task<Card[]> ReadCards() => await FilesFacade.ReadObject<Card[]>(CardsFileName);
        public async Task SaveCards(Card[] cards) => await FilesFacade.SaveObject(CardsFileName, cards);
    }

    public class Card
    {
        public Card()
        {

        }

        public Card(int id, string name, string cardNumberHint, CardState state, decimal balance, string balanceCurrency)
        {
            Id = id;
            Name = name;
            CardNumberHint = cardNumberHint;
            State = state;
            Balance = balance;
            BalanceCurrency = balanceCurrency;
        }

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
