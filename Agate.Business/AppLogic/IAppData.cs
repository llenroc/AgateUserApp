using System.Threading.Tasks;
using Agate.Business.LocalData;

namespace Agate.Business.AppLogic
{
    public interface IAppData
    {
        Asset[] AllAssets { get; set; }
        decimal BucketAmount { get; set; }
        Card[] Cards { get; set; }
        Rate[] Rates { get; set; }
        UserAsset[] UserAssets { get; set; }

        Task LoadOfflineData();
        Task<bool> LoadOnlineData(bool forceLoad = false);
    }
}