using System.Threading.Tasks;
using Agate.Contracts.Models;
using Agate.Contracts.Models.PaymentRequest;

namespace Agate.Business.API
{
    public class PaymentRequestService : IPaymentRequestService
    {
        public async Task<NewPaymentResponse> Create(NewPaymentRequest newPaymentRequest)
        {
            return await Client.Post<NewPaymentRequest, NewPaymentResponse>("paymentrequest", newPaymentRequest);
        }

        public async Task<ApiResponse> Update(int paymentRequestId, UpdatePaymentRequest updatePaymentRequest)
        {
            return await Client.Post<UpdatePaymentRequest, ApiResponse>($"paymentrequest/{paymentRequestId}",updatePaymentRequest);
        }

        public async Task<PaymentRequest> Get(int paymentRequestId)
        {
            return await Client.Get<PaymentRequest>($"paymentrequest/{paymentRequestId}");
        }

        public async Task<PaymentSubmissionResponse> Pay(int paymentRequestId, PaymentSubmission submission)
        {
            return await Client.Post<PaymentSubmission, PaymentSubmissionResponse>($"paymentrequest/{paymentRequestId}/pay", submission);
        }
    }
}