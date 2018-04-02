using System.Threading.Tasks;
using Agate.Contracts.Models.Bucket;

namespace Agate.Business.API
{
    public interface IBucketService
    {
        Task<BalanceResponse> GetBalance(int userId);
    }
}