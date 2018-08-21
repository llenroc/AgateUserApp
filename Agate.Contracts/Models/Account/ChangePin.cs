namespace Agate.Contracts.Models.Account
{
    public class ChangePinRequest : ApiRequest
    {
        public string PreviousPin { get; set; }
        public string Pin { get; set; }
    }

    public class ChangePinResponse : BaseResponseModel
    {
        public ChangePinResponse()
        {
            
        }

        public ChangePinResponse(bool success)
        {
            Success = success;
        }

        public ChangePinResponse(string error)
        {
            Error = error;
        }
    }
}