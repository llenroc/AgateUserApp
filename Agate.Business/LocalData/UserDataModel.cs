namespace OpalApp.LocalData
{
    public class UserDataModel
    {
        public UserSettings Settings { get; set; }
    }
    public class UserProfile
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryCode { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
    }
    public enum AddressType
    {
        Home,
        Shipping
    }
    public class UserSettings
    {
        public bool NotifyOnPaymentSuccessful { get; set; }
        public bool NotifyOnPaymentFailed { get; set; }
        public bool NotifyOnIncomingTransfer { get; set; }
        public bool NotifyOnOutgoingTransfer { get; set; }
    }

    public class UserAddress
    {
        public int Id { get; set; }
        public AddressType Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Unit { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }

    public class UserAsset
    {
        public int AssetId { get; set; }
        public bool Favorited { get; set; }
        public decimal Balance { get; set; }
        public string CurrentReceiveAddress { get; set; }
    }

}
