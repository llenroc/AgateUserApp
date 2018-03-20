using System;
using System.Linq;
using System.Threading.Tasks;
using static Agate.Business.LocalData.FilesFacade;

namespace Agate.Business.LocalData
{
    //public class BasicData
    //{
    //    public const string AssetsFileName = "assets.json";

    //    // to be called upon app's first execution ... but better to include file in the app package
    //    public static async Task SaveDefaultAssets()
    //    {
    //        await SaveAssets(new CacheData<Asset[]>(new[] {
    //            new Asset { AssetId = 1, AssetName = "BTC", LogoName = "" },
    //            new Asset { AssetId = 2, AssetName = "BTC", LogoName = "" },
    //            new Asset { AssetId = 3, AssetName = "BTC", LogoName = "" },
    //        }, TimeSpan.FromSeconds(100)));
    //    }

    //    public static async Task SaveAssets(CacheData<Asset[]> assets) => await SaveObject(AssetsFileName, assets);

    //    public static async Task<CacheData<Asset[]>> ReadAssets() => await ReadObject<CacheData<Asset[]>>(AssetsFileName);
    //}
}
