using System.Threading.Tasks;

namespace Agate.Business.LocalData
{
    public interface IGeneralData
    {
        Task<GeneralInfo> ReadGeneralInfo();
        Task SaveGeneralInfo(GeneralInfo generalInfo);
    }
}