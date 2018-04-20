namespace Agate.Contracts.Models.Account
{
    public class SignUpRequest
    {
        public string DeviceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryCode { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool RequestForNewCode { get; set; }
    }

    public class SignUpResponseModel : ApiResponse
    {
        public SignUpResponseModel()
        {
            
        }

        public SignUpResponseModel(int requestId)
        {
            RequestId = requestId;
        }

        public int RequestId { get; set; }
    }
}