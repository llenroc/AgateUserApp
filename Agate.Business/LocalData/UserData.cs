using System;
using System.Threading.Tasks;
using static Agate.Business.LocalData.FilesFacade;

namespace Agate.Business.LocalData
{
    public class UserData : IUserData
    {
        public const string UserProfileFileName = "userprofile.json";
        public const string UserSettingsFileName = "usersettings.json";
        public const string UserAssetsFileName = "userassets.json";
        public const string UserAddressesFileName = "useraddresses.json";

        public async Task<UserProfile> ReadUserData() => 
            await ReadObject<UserProfile>(UserProfileFileName);

        public async Task SaveUserData(UserProfile profile) =>
            await SaveObject(UserProfileFileName, profile);

        public async Task<UserAsset[]> ReadUserAssets() => 
            await ReadObject<UserAsset[]>(UserAssetsFileName);

        public async Task SaveUserAssets(UserAsset[] userAssets) =>
            await SaveObject(UserAssetsFileName, userAssets);

        public async Task<UserSettings> ReadSettings() =>
            await ReadObject<UserSettings>(UserSettingsFileName);

        public async Task SaveSettings(UserSettings userSettings) =>
            await SaveObject<UserSettings>(UserSettingsFileName, userSettings);

        public async Task<UserAddress[]> ReadUserAddresses() =>
            await ReadObject<UserAddress[]>(UserAddressesFileName);

        public async Task SaveUserAddresses(UserAddress[] userAddresses) =>
            await SaveObject(UserAddressesFileName, userAddresses);

        public async Task UpdateUserData(Action<UserProfile> updateAction) =>
            await UpdateObject(UserProfileFileName, updateAction, ()=> new UserProfile());
    }
}
