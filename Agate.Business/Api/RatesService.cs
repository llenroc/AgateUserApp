using System.Collections.Generic;
using System.Threading.Tasks;
using Agate.Contracts.Models.Bucket;
using Agate.Contracts.Models.Rates;

namespace Agate.Business.API
{
    public class RatesService
    {
        public static async Task<List<Rate>> Get() =>
            await Client.Get<List<Rate>>("rates");
    }

    public class BucketService
    {
        public static async Task<BalanceResponse> GetBalance(int userId) =>
            await Client.Post<BalanceRequest, BalanceResponse>("bucket", new BalanceRequest { UserId = userId });
    }
}
