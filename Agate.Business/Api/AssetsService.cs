using System.Collections.Generic;
using System.Threading.Tasks;
using Agate.Contracts.Models.Assets;

namespace Agate.Business.API
{
    public class AssetsService
    {
        public async Task<List<Asset>> Get() =>
            await Client.Get<List<Asset>>("assets");
    }
}
