using System;
using System.Threading.Tasks;
using static OpalApp.LocalData.FilesFacade;

namespace OpalApp.LocalData
{
    public class UserData
    {
        public const string UserProfileFileName = "userprofile.json";
        public const string UserSettingsFileName = "usersettings.json";
        public const string UserAssetsFileName = "userassets.json";
        public const string UserAddressesFileName = "useraddresses.json";

        public static async Task<UserProfile> ReadUserData() => 
            await ReadObject<UserProfile>(UserProfileFileName);

        public static async Task SaveUserData(UserProfile profile) =>
            await SaveObject(UserProfileFileName, profile);

        public static async Task<UserAsset[]> ReadUserAssets() => 
            await ReadObject<UserAsset[]>(UserAssetsFileName);

        public static async Task SaveUserAssets(UserAsset[] userAssets) =>
            await SaveObject(UserAssetsFileName, userAssets);

        public static async Task<UserSettings> ReadSettings() =>
            await ReadObject<UserSettings>(UserSettingsFileName);

        public static async Task SaveSettings(UserSettings userSettings) =>
            await SaveObject<UserSettings>(UserSettingsFileName, userSettings);

        public static async Task<UserAddress[]> ReadUserAddresses() =>
            await ReadObject<UserAddress[]>(UserAddressesFileName);

        public static async Task SaveUserAddresses(UserAddress[] userAddresses) =>
            await SaveObject(UserAddressesFileName, userAddresses);

        public static async Task UpdateUserData(Action<UserProfile> updateAction) =>
            await UpdateObject(UserProfileFileName, updateAction, ()=> new UserProfile());
    }
}
