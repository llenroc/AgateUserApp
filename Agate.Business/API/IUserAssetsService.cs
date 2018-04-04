using System.Collections.Generic;
using System.Threading.Tasks;
using Agate.Contracts.Models.User;

namespace Agate.Business.API
{
    public interface IUserAssetsService
    {
        Task<List<UserAsset>> Get(int userId);
    }
}