using System.Threading.Tasks;

namespace Agate.Business.LocalData
{
    public class RatesData : IRatesData
    {
        public const string RatesFileName = "rates.json";
        public async Task<Rate[]> ReadRates() => await FilesFacade.ReadObject<Rate[]>(RatesFileName);
        public async Task SaveRates(Rate[] rates) => await FilesFacade.SaveObject(RatesFileName, rates);
    }
}
