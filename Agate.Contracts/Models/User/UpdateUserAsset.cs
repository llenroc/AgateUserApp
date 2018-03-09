namespace Agate.Contracts.Models.User
{    
    public class UpdateUserAssetRequest
    {
        public int AssetId { get; set; }
        public bool Favorited { get; set; }
        public bool IgnoreBalanceCheck { get; set; }
    }

    public class CreateUserAssetsResponse : BaseResponseModel
     {
        public CreateUserAssetsResponse()
        {

        }
        public CreateUserAssetsResponse(int userAssetId)
        {
            UserAssetId = userAssetId;
        }
        public int UserAssetId { get; set; }
    }
    public class UpdateUserAssetsResponse : BaseResponseModel
    {
    }
}