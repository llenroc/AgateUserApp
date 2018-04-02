using System.Collections.Generic;
using System.Threading.Tasks;
using Agate.Contracts.Models.Cards;

namespace Agate.Business.API
{
    public class CardOrderService : ICardOrderService
    {
        public async Task<OrderCardResponse> CreateOrder(OrderCardRequest request) =>
            await Client.Post<OrderCardRequest, OrderCardResponse>("CardOrder", request);
    }

    public class CardsService
    {
        public static async Task<List<Card>> Get(int userId) =>
            await Client.Get<List<Card>>($"{userId}/cards/");

        public static async Task<ChargeCardResponse> ChargeCard(int userId, int cardId, ChargeCardRequest request) =>
            await Client.Post<ChargeCardRequest, ChargeCardResponse>("${userId}/cards/{cardId}/chargeCard", request);

    }
}
