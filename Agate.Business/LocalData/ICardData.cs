using System.Threading.Tasks;

namespace Agate.Business.LocalData
{
    public interface ICardData
    {
        Task<Card[]> ReadCards();
        Task SaveCards(Card[] cards);
    }
}