using System.Threading.Tasks;
using Agate.Business.AppLogic;
using Agate.Business.LocalData;
using Plugin.SecureStorage.Abstractions;

namespace Agate.Business.Services
{
    public class DataReset
    {
        private readonly ISecureStorage secureStorage;
        private readonly IDataFlow dataFlow;

        public DataReset(ISecureStorage secureStorage, IDataFlow dataFlow)
        {
            this.secureStorage = secureStorage;
            this.dataFlow = dataFlow;
        }

        public async Task Reset()
        {
            secureStorage.DeleteKey("userid");
            secureStorage.DeleteKey("accesscode");
            secureStorage.DeleteKey("pin");

            await FilesFacade.DeleteFile(UserData.UserProfileFileName);
            await FilesFacade.DeleteFile(UserData.UserSettingsFileName);
            await FilesFacade.DeleteFile(UserData.UserAssetsFileName);
            await FilesFacade.DeleteFile(UserData.UserAddressesFileName);
            await FilesFacade.DeleteFile(BucketData.BucketDataFileName);
            await FilesFacade.DeleteFile(CardData.CardsFileName);
            await FilesFacade.DeleteFile(GeneralData.GeneralInfoFileName);
            await FilesFacade.DeleteFile(RatesData.RatesFileName);
        }

        public async Task SetTestUser()
        {
            secureStorage.SetUserId(1);
            secureStorage.SetAccessCode("testaccesscode");
            secureStorage.SetPin("1234");

            await dataFlow.InitializeUser("", "Meysam", "Naseri", "+61", "meysamnaseri@live.com", "+61424554644");
            
        }
    }
}