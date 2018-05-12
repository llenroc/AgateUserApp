using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Agate.Business.API;
using Agate.Business.LocalData;
using Agate.Contracts.Models.PaymentRequest;
using Microsoft.AppCenter.Crashes;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Merchant
{
    public class ReceivePaymentViewModel : BaseViewModel
    {
        private UserProfile userProfile;
        private readonly IPaymentRequestService paymentRequestService;
        private string amount = "0";
        private string generatedAddress;
        private int paymentRequestId = -1;
        private PaymentRequest paymentRequest;
        private bool newPaymentMode;
        private bool paymentSuccessMode;
        private Timer checkPaymentTimer;
        private string paymentCode;
        private bool barcodeVisible;

        public ReceivePaymentViewModel(IPaymentRequestService paymentRequestService)
        {
            this.paymentRequestService = paymentRequestService;

            ReturnCommand = new XCommand(() =>
            {
                Amount = "";
                NewPaymentMode = true;
            });
        }

        public void Initialize(UserProfile userProfile)
        {
            NewPaymentMode = true;

            this.userProfile = userProfile;

            StartPooling();
            StartNewPayment();
        }

        private void StartPooling()
        {
            checkPaymentTimer = new Timer(
                async s => await CheckPayment(s),
                null,
                TimeSpan.FromSeconds(8),
                TimeSpan.FromMilliseconds(700));

            Xamarin.Forms.Device.StartTimer(TimeSpan.FromMilliseconds(2000), EvaluatePayment);
        }

        private void StartNewPayment()
        {
            paymentCode = GenerateRandomAddress();

            try
            {
                var response = paymentRequestService.Create(new NewPaymentRequest
                {
                    UserId = userProfile.UserId,
                    Amount = 0,
                    Address = paymentCode
                });
                response.ContinueWith(r =>
                {
                    paymentRequestId = r.Result.NewPaymentRequestId;
                });
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string> { { "page", "receive payment" }, { "operation", "creating payment request" } });
            }


            string GenerateRandomAddress()
            {
                var codes = "ABCDEF1234567890";
                var random = new Random((int)DateTime.Now.Ticks);
                return string.Concat(Enumerable.Range(1, 32).Select(i => codes[random.Next(0, codes.Length - 1)]));
            }
        }

        private void StopPooling()
        {
            checkPaymentTimer.Dispose();
        }

        async Task CheckPayment(object state)
        {
            if (paymentRequestId >= 0)
            {
                paymentRequest = await paymentRequestService.Get(paymentRequestId);
            }
        }

        bool EvaluatePayment()
        {
            if (paymentRequest == null)
                return true;

            if (paymentRequest.Status == PaymentRequestStatus.Paid)
            {
                PaymentSuccessMode = true;

                StopPooling();

                return false;
            }

            return true;
        }

        public string Amount
        {
            get => amount;
            set
            {
                if (amount == value)
                    return;
                amount = value;

                var decimalAmountParsed = decimal.TryParse(amount, out var decimalAmount);

                try
                {
                    if (!string.IsNullOrEmpty(amount) && amount.Trim() != "0")
                    {
                        BarcodeVisible = true;
                        GeneratedAddress = $"agate://{paymentCode}_{paymentRequestId}?asset=AGT&amount={amount}";
                    }
                    else
                    {
                        BarcodeVisible = false;
                        GeneratedAddress = "Not a valid entry";
                    }
                }
                catch(Exception ex)
                {
                    Crashes.TrackError(ex, new Dictionary<string, string> { { "page", "receive payment" }, { "operation", "setting barcode value" }});
                }

                if (decimalAmountParsed && paymentRequestId > 0)
                {
                    try
                    {
                        paymentRequestService.Update(paymentRequestId, new UpdatePaymentRequest {Amount = decimalAmount});
                    }
                    catch(Exception ex)
                    {
                        Crashes.TrackError(ex, new Dictionary<string, string> {{"page", "receive payment"}, {"operation", "updating amount"}});
                    }
                }

                Raise(nameof(Amount));
            }
        }

        public string GeneratedAddress
        {
            get => generatedAddress; set
            {
                generatedAddress = value;
                Raise(nameof(GeneratedAddress));
            }
        }

        public bool BarcodeVisible
        {
            get => barcodeVisible;
            set
            {
                if (barcodeVisible == value)
                    return;
                barcodeVisible = value;
                Raise(nameof(BarcodeVisible));
            }
        }

        public bool NewPaymentMode
        {
            get => newPaymentMode;
            set
            {
                if (newPaymentMode == value)
                    return;

                newPaymentMode = value;
                paymentSuccessMode = !value;

                Raise(nameof(PaymentSuccessMode));
                Raise(nameof(NewPaymentMode));
            }
        }

        public bool PaymentSuccessMode
        {
            get => paymentSuccessMode;
            set
            {
                if (paymentSuccessMode == value)
                    return;

                newPaymentMode = !value;
                paymentSuccessMode = value;

                Raise(nameof(PaymentSuccessMode));
                Raise(nameof(NewPaymentMode));
            }
        }

        public IXCommand ReturnCommand { get; set; }
    }
}
