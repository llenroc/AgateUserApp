namespace Agate.Contracts.Models.Account
{
    public class ChangePinRequest
    {
        public int UserId { get; set; }
        public string DeviceId { get; set; }
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