using System.Threading.Tasks;
using Agate.Contracts.Models.Transactions;

namespace Agate.Business.API
{
    public interface ITransactionService
    {
        Task<GenerateDepositAddressResponse> GenerateDepositAddress(GenerateDepositAddressRequest request);
        Task<SendOrderResponse> SendOrder(SendOrderRequest request);
        Task<TransferOrderResponse> TransferOrder(TransferOrderRequest request);
    }
}