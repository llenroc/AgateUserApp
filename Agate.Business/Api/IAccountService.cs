using System.Threading.Tasks;
using Agate.Contracts.Models.Account;

namespace Agate.Business.Api
{
    public interface IAccountService
    {
        Task<ChangePinResponse> ChangePin(ChangePinRequest request);
        Task<ConfirmSignUpResponse> ConfirmSignup(ConfirmSignUpRequest request);
        Task<SignUpResponseModel> SignUp(SignUpRequest request);
    }
}