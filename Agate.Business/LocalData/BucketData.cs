using System.Threading.Tasks;

namespace Agate.Business.LocalData
{
    public class BucketData
    {
        public const string BucketDataFileName = "bucket.json";
        public static async Task<BucketInfo> ReadBucketInfo() => await FilesFacade.ReadObject<BucketInfo>(BucketDataFileName);
        public static async Task SaveBucketInfo(BucketInfo bucketInfo) => await FilesFacade.SaveObject(BucketDataFileName, bucketInfo);
    }
    public class BucketInfo
    {
        public decimal Amount { get; set; }
    }
}
