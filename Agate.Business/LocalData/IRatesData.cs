using System.Threading.Tasks;

namespace Agate.Business.LocalData
{
    public interface IRatesData
    {
        Task<Rate[]> ReadRates();
        Task SaveRates(Rate[] rates);
    }
}