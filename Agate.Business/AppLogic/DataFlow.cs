using OpalApp.LocalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpalApp.AppLogic
{
    public class DataFlow
    {
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
                new Asset{AssetId = 1, AssetSymbol = "BTC",AssetName="Bitcoin", LogoName ="btc.png"},
                new Asset{AssetId = 2, AssetSymbol = "ETH",AssetName="Ethereum", LogoName = "eth.png"},
                new Asset{AssetId = 3, AssetSymbol = "XRP", AssetName="Ripple", LogoName="xrp.png"},
                new Asset{AssetId = 4, AssetSymbol = "BCH", AssetName="Bitcoin Cash", LogoName = "bch.png"},
                new Asset{AssetId = 5, AssetSymbol = "LTC", AssetName="Litecoin", LogoName = "ltc.png"}
            };
        }

        public static async Task InitializeUser(string firstname, string lastname, string countryCode, string emailAddress, string mobileNumber)
        {
            await UserData.SaveUserData(new UserProfile
            {
                UserId = int.MinValue,
                FirstName = firstname,
                LastName = lastname,
                CountryCode = countryCode,
                EmailAddress = emailAddress,
                MobileNumber = mobileNumber,
            });
            await UserData.SaveUserAssets(new[] {
                        new UserAsset { AssetId = 1, Balance = 0, Favorited = true },
                        new UserAsset { AssetId = 2, Balance = 0, Favorited = true },
                        new UserAsset { AssetId = 3, Balance = 0, Favorited = true },
                        new UserAsset { AssetId = 4, Balance = 0, Favorited = false },
                        new UserAsset { AssetId = 5, Balance = 0, Favorited = false },
                    });

        }
    }
}
