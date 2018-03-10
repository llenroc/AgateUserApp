using System.Threading.Tasks;
using static OpalApp.LocalData.FilesFacade;

namespace OpalApp.LocalData
{
    public class BucketData
    {
        public const string BucketDataFileName = "bucket.json";
        public static async Task<BucketInfo> ReadBucketInfo() => await ReadObject<BucketInfo>(BucketDataFileName);
        public static async Task SaveBucketInfo(BucketInfo bucketInfo) => await SaveObject(BucketDataFileName, bucketInfo);
    }
    public class BucketInfo
    {
        public decimal Amount { get; set; }
    }
}
