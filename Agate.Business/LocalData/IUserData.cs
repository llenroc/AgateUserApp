using System;
using System.Threading.Tasks;

namespace Agate.Business.LocalData
{
    public interface IUserData
    {
        Task<UserSettings> ReadSettings();
        Task<UserAddress[]> ReadUserAddresses();
        Task<UserAsset[]> ReadUserAssets();
        Task<UserProfile> ReadUserData();
        Task SaveSettings(UserSettings userSettings);
        Task SaveUserAddresses(UserAddress[] userAddresses);
        Task SaveUserAssets(UserAsset[] userAssets);
        Task SaveUserData(UserProfile profile);
        Task UpdateUserData(Action<UserProfile> updateAction);
    }
}