using System.Collections.Generic;
using System.Threading.Tasks;
using Agate.Contracts.Models.Assets;

namespace Agate.Business.Api
{
    public class AssetsService
    {
        public static async Task<List<Asset>> Get() =>
            await Services.Get<List<Asset>>("assets");
    }
}
