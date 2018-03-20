namespace Agate.Business.LocalData
{
    public class UserSettings
    {
        public bool NotifyOnPaymentSuccessful { get; set; }
        public bool NotifyOnPaymentFailed { get; set; }
        public bool NotifyOnIncomingTransfer { get; set; }
        public bool NotifyOnOutgoingTransfer { get; set; }
    }
}