using System.Threading.Tasks;
using Agate.Contracts.Models.Cards;

namespace Agate.Business.API
{
    public interface ICardOrderService
    {
        Task<OrderCardResponse> CreateOrder(OrderCardRequest request);
    }
}