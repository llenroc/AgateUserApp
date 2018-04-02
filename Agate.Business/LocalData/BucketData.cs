using System.Threading.Tasks;

namespace Agate.Business.LocalData
{
    public class BucketData : IBucketData
    {
        public const string BucketDataFileName = "bucket.json";
        public async Task<BucketInfo> ReadBucketInfo() => await FilesFacade.ReadObject<BucketInfo>(BucketDataFileName);
        public async Task SaveBucketInfo(BucketInfo bucketInfo) => await FilesFacade.SaveObject(BucketDataFileName, bucketInfo);
    }
    public class BucketInfo
    {
        public decimal Amount { get; set; }
    }
}
