using System.Collections.Generic;
using System.Threading.Tasks;
using Agate.Contracts.Models.Bucket;
using Agate.Contracts.Models.Rates;

namespace Agate.Business.Api
{
    public class RatesService
    {
        public static async Task<List<Rate>> Get() =>
            await Services.Get<List<Rate>>("rates");
    }

    public class BucketService
    {
        public static async Task<BalanceResponse> GetBalance(int userId) =>
            await Services.Post<BalanceRequest, BalanceResponse>("bucket", new BalanceRequest { UserId = userId });
    }
}
