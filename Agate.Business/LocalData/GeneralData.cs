using System.Threading.Tasks;

namespace Agate.Business.LocalData
{
    public class GeneralData : IGeneralData
    {
        public const string GeneralInfoFileName = "general.json";

        public async Task<GeneralInfo> ReadGeneralInfo() => await FilesFacade.ReadObject<GeneralInfo>(GeneralInfoFileName);

        public async Task SaveGeneralInfo(GeneralInfo generalInfo) => await FilesFacade.SaveObject(GeneralInfoFileName, generalInfo);
    }

    public class GeneralInfo
    {
        public bool ImpendingCardOrder { get; set; }
    }
}
