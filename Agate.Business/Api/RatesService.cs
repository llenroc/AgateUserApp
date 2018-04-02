using System.Collections.Generic;
using System.Threading.Tasks;
using Agate.Business.LocalData;
using Rate = Agate.Contracts.Models.Rates.Rate;

namespace Agate.Business.API
{
    public class RatesService : IRatesService
    {
        public async Task<List<Rate>> Get() =>
            await Client.Get<List<Rate>>("rates");
    }
}
