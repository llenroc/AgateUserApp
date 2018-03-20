namespace Agate.Business.LocalData
{
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
}