using System;
using System.Collections.Generic;
using System.Text;

namespace Agate.Contracts.Models.PaymentRequest
{
    public class NewPaymentRequest : ApiRequest
    {
        public int UserId { get; set; }
        public string Address { get; set; }
        public decimal Amount { get; set; }
    }

    public class UpdatePaymentRequest : ApiRequest
    {
        public decimal Amount { get; set; }
    }

    public class NewPaymentResponse : ApiResponse
    {
        public int NewPaymentRequestId { get; set; }
    }

    public class PaymentRequest
    {
        public int PaymentRequestId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public PaymentRequestStatus Status { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public DateTime? DateTimePaid { get; set; }
    }

    public enum PaymentRequestStatus
    {
        Pending,
        Paid
    }

    public class PaymentSubmission : ApiRequest
    {
        public int UserId { get; set; }
        public int AssetId { get; set; }
        public decimal Amount { get; set; }
    }

    public class PaymentSubmissionResponse : ApiResponse
    {

    }
}
