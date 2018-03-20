using System.Threading.Tasks;

namespace Agate.Business.LocalData
{
    public class GeneralData
    {
        public const string GeneralInfoFileName = "general.json";

        public static async Task<GeneralInfo> ReadGeneralInfo() => await FilesFacade.ReadObject<GeneralInfo>(GeneralInfoFileName);

        public static async Task SaveGeneralInfo(GeneralInfo generalInfo) => await FilesFacade.SaveObject(GeneralInfoFileName, generalInfo);
    }

    public class GeneralInfo
    {
        public bool ImpendingCardOrder { get; set; }
    }
}
