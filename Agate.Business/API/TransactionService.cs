using System.Threading.Tasks;
using Agate.Contracts.Models.Transactions;

namespace Agate.Business.API
{
    public class TransactionService : ITransactionService
    {
        public async Task<GenerateDepositAddressResponse> GenerateDepositAddress(GenerateDepositAddressRequest request) =>
            await Client.Post<GenerateDepositAddressRequest, GenerateDepositAddressResponse>($"transactions/generateDepositAddress", request);

        public async Task<SendOrderResponse> SendOrder(SendOrderRequest request) =>
            await Client.Post<SendOrderRequest, SendOrderResponse>($"transactions/sendOrder", request);

        public async Task<TransferOrderResponse> TransferOrder(TransferOrderRequest request) =>
            await Client.Post<TransferOrderRequest, TransferOrderResponse>($"transactions/transferOrder", request);
    }
}