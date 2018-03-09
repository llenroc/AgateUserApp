using System;

namespace Agate.Contracts.Models.Account
{
    public class ConfirmSignUpRequest
    {
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public int RequestId { get; set; }
        public string ConfirmationCode { get; set; }
    }

    public class ConfirmSignUpResponse
    {
        public ConfirmSignUpResponse()
        {
            
        }
        public ConfirmSignUpResponse(int userId, string accessCode, DateTime accessCodeExpiryDate)
        {
            Success = true;
            UserId = userId;
            AccessCode = accessCode;
            AccessCodeExpiryDate = accessCodeExpiryDate;
        }

        public ConfirmSignUpResponse(string error)
        {
            Success = false;
            Error = error;
        }

        public bool Success { get; set; }
        
        // User has already have an mobile number with us, we trust that user owns the number. But now we just let him set a new PIN and then give him an option to update his details.
        public bool MobileNumberExists { get; set; }

        // User needs to update their email address, or prove they have access to this email address. Then if they have access to 
        public bool EmailAddressExists { get; set; }

        public int UserId { get; set; }

        public string AccessCode { get; set; }

        public DateTime AccessCodeExpiryDate { get; set; }

        public string Error { get; set; }
    }
}