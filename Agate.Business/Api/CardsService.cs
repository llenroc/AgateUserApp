using System.Threading.Tasks;
using Agate.Contracts.Models.Cards;

namespace Agate.Business.API
{
    public class CardsService : ICardsService
    {
        public async Task<ChargeCardResponse> ChargeCard(int userId, int cardId, ChargeCardRequest request) =>
            await Client.Post<ChargeCardRequest, ChargeCardResponse>("${userId}/cards/{cardId}/chargeCard", request);

    }
}
