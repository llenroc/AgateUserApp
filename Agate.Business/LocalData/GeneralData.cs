using System.Threading.Tasks;
using static OpalApp.LocalData.FilesFacade;

namespace OpalApp.LocalData
{
    public class GeneralData
    {
        public const string GeneralInfoFileName = "general.json";

        public static async Task<GeneralInfo> ReadGeneralInfo() => await ReadObject<GeneralInfo>(GeneralInfoFileName);

        public static async Task SaveGeneralInfo(GeneralInfo generalInfo) => await SaveObject(GeneralInfoFileName, generalInfo);
    }

    public class GeneralInfo
    {
        public bool ImpendingCardOrder { get; set; }
    }
}
