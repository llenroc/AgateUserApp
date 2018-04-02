using System.Threading.Tasks;

namespace Agate.Business.LocalData
{
    public interface IBucketData
    {
        Task<BucketInfo> ReadBucketInfo();
        Task SaveBucketInfo(BucketInfo bucketInfo);
    }
}