using System.Threading.Tasks;
using Agate.Contracts.Models.User;

namespace Agate.Business.API
{
    public interface IUserAddressesServices
    {
        Task<CreateUserAddressResponse> Create(int userId, UserAddress userAddress);
        Task<UserAddress[]> Get(int userId);
        Task<UpdateUserAddressResponse> Update(int userId, UserAddress userAddress);
    }
}