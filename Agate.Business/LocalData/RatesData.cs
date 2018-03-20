using System.Threading.Tasks;

namespace Agate.Business.LocalData
{
    public class RatesData
    {
        public const string RatesFileName = "rates.json";
        public static async Task<Rate[]> ReadRates() => await FilesFacade.ReadObject<Rate[]>(RatesFileName);
        public static async Task SaveRates(Rate[] rates) => await FilesFacade.SaveObject(RatesFileName, rates);
    }
}
