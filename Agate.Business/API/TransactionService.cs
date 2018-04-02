using System.Threading.Tasks;
using Agate.Contracts.Models.Transactions;

namespace Agate.Business.API
{
    public class TransactionService : ITransactionService
    {
        public async Task<GenerateDepositAddressResponse> GenerateDepositAddress(GenerateDepositAddressRequest request) =>
            await Client.Post<GenerateDepositAddressRequest, GenerateDepositAddressResponse>($"transactions/{request.AssetId}/generateDepositAddress", request);

        public async Task<SendOrderResponse> SendOrder(SendOrderRequest request) =>
            await Client.Post<SendOrderRequest, SendOrderResponse>($"transactions/{request.AssetId}/sendOrder", request);

        public async Task<TransferOrderResponse> TransferOrder(TransferOrderRequest request) =>
            await Client.Post<TransferOrderRequest, TransferOrderResponse>($"transactions/{request.AssetId}/transferOrder", request);
    }
}