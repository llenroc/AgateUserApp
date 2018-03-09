using System;

namespace Agate.Contracts.Models
{
    public class BaseResponseModel
    {
        public bool Success { get; set; } = true;
        public string Error { get; set; }
    }

    public class ErrorResponse : BaseResponseModel
    {
        public ErrorResponse(string error)
        {
            this.Success = false;
            this.Error = error;
        }
    }

    public class BaseAuthenticatedRequestModel
    {
        public int UserId { get; set; }
        public string AccessCode { get; set; }
    }

    public class DefaultReponses
    {
        public static ErrorResponse GenericError(Exception ex)
        {
            return new ErrorResponse("an unhandled error occurered. " + ex.Message);
        }
        public static ErrorResponse Error(string error)
        {
            return new ErrorResponse(error);
        }
    }
}
