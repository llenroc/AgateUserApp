using System;

namespace Agate.Contracts.Models
{
    public class BaseResponseModel
    {
        public bool Success { get; set; } = true;
        public string Error { get; set; }
    }

    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Error { get; set; }
    }

    public class ErrorResponse : ApiResponse
    {
        public ErrorResponse(int statusCode, string error = null)
        {
            StatusCode = statusCode;
            Error = error ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return "Resource not found";
                case 500:
                    return "An unhandled error occurred";
                default:
                    return null;
            }
        }
    }

    public class ApiRequest
    {
        public Credentials Credentials { get; set; }
    }

    public class Credentials
    {
        public int UserId { get; set; }
        public string DeviceId { get; set; }
        public string AccessCode { get; set; }
    }

    public static class DefaultReponses
    {
        public static ErrorResponse GenericError(Exception ex)
        {
            return new ErrorResponse(500, "an unhandled error occurered. " + ex.Message);
        }
        public static ErrorResponse Error(int statusCode, string error = null)
        {
            return new ErrorResponse(statusCode, error);
        }

    }
}
