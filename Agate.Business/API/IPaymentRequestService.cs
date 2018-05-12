using System.Threading.Tasks;
using Agate.Contracts.Models;
using Agate.Contracts.Models.PaymentRequest;

namespace Agate.Business.API
{
    public interface IPaymentRequestService
    {
        Task<NewPaymentResponse> Create(NewPaymentRequest newPaymentRequest);
        Task<ApiResponse> Update(int paymentRequestId, UpdatePaymentRequest updatePaymentRequest);
        Task<PaymentRequest> Get(int paymentRequestId);
        Task<PaymentSubmissionResponse> Pay(int paymentRequestId, PaymentSubmission submission);
    }
}