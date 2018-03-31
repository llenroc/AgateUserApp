using System.Collections.Generic;
using System.Threading.Tasks;
using Agate.Contracts.Models.Cards;
using Agate.Contracts.Models.Transactions;

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

    public class TransactionService
    {
        public static async Task<GenerateDepositAddressResponse> GenerateDepositAddress(GenerateDepositAddressRequest request) =>
            await Client.Post<GenerateDepositAddressRequest, GenerateDepositAddressResponse>($"transactions/{request.AssetId}/generateDepositAddress", request);

        public static async Task<SendOrderResponse> SendOrder(SendOrderRequest request) =>
            await Client.Post<SendOrderRequest, SendOrderResponse>($"transactions/{request.AssetId}/sendOrder", request);

        public static async Task<TransferOrderResponse> TransferOrder(TransferOrderRequest request) =>
            await Client.Post<TransferOrderRequest, TransferOrderResponse>($"transactions/{request.AssetId}/transferOrder", request);
    }

}
