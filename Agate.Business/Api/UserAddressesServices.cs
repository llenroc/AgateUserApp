using System.Threading.Tasks;
using Agate.Contracts.Models.User;

namespace Agate.Business.API
{
    public class UserAddressesServices : IUserAddressesServices
    {
        public async Task<UserAddress[]> Get(int userId) =>
            await Client.Get<UserAddress[]>($"user/{userId}/addresses");

        public async Task<CreateUserAddressResponse> Create(int userId, UserAddress userAddress) =>
            await Client.Post<UserAddress, CreateUserAddressResponse>($"user/{userId}/addresses", userAddress);

        public async Task<UpdateUserAddressResponse> Update(int userId, UserAddress userAddress) =>
            await Client.Post<UserAddress, UpdateUserAddressResponse>($"user/{userId}/addresses/{userAddress.Id}", userAddress);
    }
}