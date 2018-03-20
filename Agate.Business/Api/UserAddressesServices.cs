using System.Threading.Tasks;
using Agate.Contracts.Models.User;

namespace Agate.Business.Api
{
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