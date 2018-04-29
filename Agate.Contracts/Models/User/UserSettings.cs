namespace Agate.Contracts.Models.User
{
    public class UserSettings
    {
        public bool NotifyByEmailOnPaymentSuccessful { get; set; }
        public bool NotifyByEmailOnPaymentFailed { get; set; }
        public bool NotifyByEmailOnIncomingTransfer { get; set; }
        public bool NotifyByEmailOnOutgoingTransfer { get; set; }
        public bool NotifyBySMSOnPaymentSuccessful { get; set; }
        public bool NotifyBySMSOnPaymentFailed { get; set; }
        public bool NotifyBySMSOnIncomingTransfer { get; set; }
        public bool NotifyBySMSOnOutgoingTransfer { get; set; }
    }
}
