using System.Collections.Generic;
using System.Threading.Tasks;
using Agate.Contracts.Models.Cards;
using Agate.Contracts.Models.User;

namespace Agate.Business.API
{
    public class UserAssetsService : IUserAssetsService
    {
        public async Task<List<UserAsset>> Get(int userId) =>
            await Client.Get<List<UserAsset>>($"user/{userId}/assets/");

        public async Task<UpdateUserAssetsResponse> Save(int userId, UpdateUserAssetRequest[] updateUserAssetRequests) =>
            await Client.Post<UpdateUserAssetRequest[], UpdateUserAssetsResponse>($"user/{userId}/assets", updateUserAssetRequests);
    }
}