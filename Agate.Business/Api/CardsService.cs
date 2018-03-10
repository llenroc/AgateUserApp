using System.Collections.Generic;
using System.Threading.Tasks;
using Agate.Contracts.Models.Cards;
using Agate.Contracts.Models.Transactions;

namespace Agate.Business.Api
{
    public class CardOrderService
    {
        public static async Task<OrderCardResponse> CreateOrder(OrderCardRequest request) =>
            await Services.Post<OrderCardRequest, OrderCardResponse>("CardOrder", request);
    }

    public class CardsService
    {
        public static async Task<List<Card>> Get(int userId) =>
            await Services.Get<List<Card>>($"{userId}/cards/");

        public static async Task<ChargeCardResponse> ChargeCard(int userId, int cardId, ChargeCardRequest request) =>
            await Services.Post<ChargeCardRequest, ChargeCardResponse>("${userId}/cards/{cardId}/chargeCard", request);

    }

    public class TransactionService
    {
        public static async Task<GenerateDepositAddressResponse> GenerateDepositAddress(GenerateDepositAddressRequest request) =>
            await Services.Post<GenerateDepositAddressRequest, GenerateDepositAddressResponse>($"transactions/{request.AssetId}/generateDepositAddress", request);

        public static async Task<SendOrderResponse> SendOrder(SendOrderRequest request) =>
            await Services.Post<SendOrderRequest, SendOrderResponse>($"transactions/{request.AssetId}/sendOrder", request);

        public static async Task<TransferOrderResponse> TransferOrder(TransferOrderRequest request) =>
            await Services.Post<TransferOrderRequest, TransferOrderResponse>($"transactions/{request.AssetId}/transferOrder", request);
    }

}
