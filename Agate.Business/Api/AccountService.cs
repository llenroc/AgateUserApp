using System.Threading.Tasks;
using Agate.Contracts.Models.Account;

namespace Agate.Business.Api
{
    public class AccountService : IAccountService
    {
        public async Task<SignUpResponseModel> SignUp(SignUpRequest request) => 
            await Services.Post<SignUpRequest, SignUpResponseModel>("account/signup", request);

        public async Task<ConfirmSignUpResponse> ConfirmSignup(ConfirmSignUpRequest request) => 
            await Services.Post<ConfirmSignUpRequest, ConfirmSignUpResponse>("account/confirmsignup", request);

        public async Task<ChangePinResponse> ChangePin(ChangePinRequest request) => 
            await Services.Post<ChangePinRequest, ChangePinResponse>("account/changepin", request);
    }
}
