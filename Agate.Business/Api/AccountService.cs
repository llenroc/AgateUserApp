using System.Threading.Tasks;
using Agate.Contracts.Models.Account;
using Agate.Contracts.Models.User;

namespace Agate.Business.Api
{
    public class AccountService
    {
        public static async Task<SignUpResponseModel> SignUp(SignUpRequest request) => 
            await Services.Post<SignUpRequest, SignUpResponseModel>("account/signup", request);

        public static async Task<ConfirmSignUpResponse> ConfirmSignup(ConfirmSignUpRequest request) => 
            await Services.Post<ConfirmSignUpRequest, ConfirmSignUpResponse>("account/confirmsignup", request);

        public static async Task<ChangePinResponse> ChangePin(ChangePinRequest request) => 
            await Services.Post<ChangePinRequest, ChangePinResponse>("account/changepin", request);
    }

    public class UserAddressesServices
    {
        public static async Task<UserAddress[]> Get(int userId) =>
            await Services.Get<UserAddress[]>($"user/{userId}/addresses");

        public static async Task<CreateUserAddressResponse> Create(int userId, UserAddress userAddress) =>
            await Services.Post<UserAddress, CreateUserAddressResponse>($"user/{userId}/addresses", userAddress);

        public static async Task<UpdateUserAddressResponse> Update(int userId, UserAddress userAddress) =>
            await Services.Post<UserAddress, UpdateUserAddressResponse>($"user/{userId}/addresses/{userAddress.Id}", userAddress);
    }
}
