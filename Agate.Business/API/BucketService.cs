using System.Threading.Tasks;
using Agate.Contracts.Models.Bucket;

namespace Agate.Business.API
{
    public class BucketService : IBucketService
    {
        public async Task<BalanceResponse> GetBalance(int userId) =>
            await Client.Post<BalanceRequest, BalanceResponse>("bucket", new BalanceRequest { UserId = userId });
    }
}