namespace Agate.Contracts.Models.User
{
    public class UserSettings
    {
        public bool NotifyOnPaymentSuccessful { get; set; }
        public bool NotifyOnPaymentFailed { get; set; }
        public bool NotifyOnIncomingTransfer { get; set; }
        public bool NotifyOnOutgoingTransfer { get; set; }
    }
}
