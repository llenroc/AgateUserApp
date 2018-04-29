using System.Threading.Tasks;
using Agate.Business.LocalData;
using Agate.Business.Services;
using Plugin.SecureStorage.Abstractions;

namespace Agate.Business.AppLogic
{
    public class DataFlow : IDataFlow
    {
        private readonly ISecureStorage secureStorage;
        private readonly IUserData userData;
        private readonly IAppData appData;

        public DataFlow(ISecureStorage secureStorage, IUserData userData, IAppData appData)
        {
            this.secureStorage = secureStorage;
            this.userData = userData;
            this.appData = appData;
        }
        //public static async Task<Asset[]> GetAllAssets()
        //{
        //    var assetsFromFile = await BasicData.ReadAssets();

        //    if (assetsFromFile != null)
        //        return assetsFromFile.Data;

        //    return GetDefaultAssetValues();

        //    //// for now list of assets is hard-coded so no need to get from server
        //    //var assetsFromServer = await AssetsService.Get();
        //    //var localAssets = assetsFromServer.Select(
        //    //    a => new Asset
        //    //    {
        //    //        AssetId = a.AssetId,
        //    //        AssetSymbol = a.AssetSymbol,
        //    //        AssetName = a.AssetName,
        //    //        LogoName = a.LogoName
        //    //    }).ToArray();

        //    //await BasicData.SaveAssets(new CacheData<Asset[]>(localAssets, TimeSpan.FromDays(5)));

        //    //return localAssets;
        //}

        private static Asset[] GetDefaultAssetValues()
        {
            return new[] {
                new Asset{AssetId = 0, AssetSymbol = "AGT", AssetName = "Agate", LogoName = "logo.png"},
                new Asset{AssetId = 1, AssetSymbol = "BTC",AssetName="Bitcoin", LogoName ="btc.png"},
                new Asset{AssetId = 2, AssetSymbol = "ETH",AssetName="Ethereum", LogoName = "eth.png"},
                new Asset{AssetId = 3, AssetSymbol = "XRP", AssetName="Ripple", LogoName="xrp.png"},
                new Asset{AssetId = 4, AssetSymbol = "BCH", AssetName="Bitcoin Cash", LogoName = "bch.png"},
                new Asset{AssetId = 5, AssetSymbol = "LTC", AssetName="Litecoin", LogoName = "ltc.png"}
            };
        }

        public async Task InitializeUser(string firstname, string lastname, string countryCode, string emailAddress, string mobileNumber)
        {
            await userData.SaveUserData(new UserProfile
            {
                UserId = int.MinValue,
                FirstName = firstname,
                LastName = lastname,
                CountryCode = countryCode,
                EmailAddress = emailAddress,
                MobileNumber = mobileNumber,                
            });
            await userData.SaveUserAssets(new[] {
                        new UserAsset { AssetId = 0, Balance = 0, Favorited = true },
                        new UserAsset { AssetId = 1, Balance = 0, Favorited = true, CurrentReceiveAddress = "37JG5sdbjji39BARLwyaCF9doSEUgFXMX9"},
                        new UserAsset { AssetId = 2, Balance = 0, Favorited = true, CurrentReceiveAddress = "0x350C8a737dF3947a624B049D1DCe34790AE00F86" },
                        new UserAsset { AssetId = 3, Balance = 0, Favorited = true, CurrentReceiveAddress = "" },
                        new UserAsset { AssetId = 4, Balance = 0, Favorited = false, CurrentReceiveAddress = "pp2r04n9nwwl6p8hhc9euz6lxwu3vrxun5hsg7sxf7" },
                        new UserAsset { AssetId = 5, Balance = 0, Favorited = false, CurrentReceiveAddress = "LRHyQFVnYaVnkp9PtCA2f7hxunmsCw37Mh" },
                    });

            await userData.SaveSettings(new UserSettings{
                NotifyByEmailOnPaymentSuccessful = true,
                NotifyBySMSOnPaymentSuccessful = true,
                NotifyByEmailOnPaymentFailed = true,
                NotifyBySMSOnPaymentFailed = true,
                NotifyByEmailOnIncomingTransfer = true,
                NotifyBySMSOnIncomingTransfer = true,
                NotifyByEmailOnOutgoingTransfer = true,
                NotifyBySMSOnOutgoingTransfer = true,
            });
            await appData.LoadOfflineData();
        }

        public async Task UpdateUserId(int userId)
        {
            await userData.UpdateUserData(u => { u.UserId = userId; });
            secureStorage.SetUserId(userId);
        }

        public async Task UpdateAccessCode(string accessCode)
        {
            secureStorage.SetAccessCode(accessCode);
        }
    }
}
