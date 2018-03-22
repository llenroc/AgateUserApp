using System.Threading.Tasks;
using Agate.Business.Api;
using Agate.Business.API;
using Agate.Contracts.Models.Account;

namespace Agate.Business.API
{
    public class AccountService : IAccountService
    {
        public async Task<SignUpResponseModel> SignUp(SignUpRequest request) => 
            await Client.Post<SignUpRequest, SignUpResponseModel>("account/signup", request);

        public async Task<ConfirmSignUpResponse> ConfirmSignup(ConfirmSignUpRequest request) => 
            await Client.Post<ConfirmSignUpRequest, ConfirmSignUpResponse>("account/confirmsignup", request);

        public async Task<ChangePinResponse> ChangePin(ChangePinRequest request) => 
            await Client.Post<ChangePinRequest, ChangePinResponse>("account/changepin", request);
    }
}
