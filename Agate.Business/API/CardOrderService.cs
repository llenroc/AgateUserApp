using System.Threading.Tasks;
using Agate.Contracts.Models.Cards;

namespace Agate.Business.API
{
    public class CardOrderService : ICardOrderService
    {
        public async Task<OrderCardResponse> CreateOrder(OrderCardRequest request) =>
            await Client.Post<OrderCardRequest, OrderCardResponse>("CardOrder", request);
    }
}