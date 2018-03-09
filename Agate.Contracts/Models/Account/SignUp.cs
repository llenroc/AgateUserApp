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

    public class SignUpResponseModel : BaseResponseModel
    {
        public SignUpResponseModel()
        {
            
        }

        public SignUpResponseModel(int requestId)
        {
            Success = true;
            RequestId = requestId;
        }

        public SignUpResponseModel(string error)
        {
            Error = error;
        }

        public int RequestId { get; set; }
    }
}