namespace Agate.Contracts.Models.User
{
    public class UserAsset
    {
        public int AssetId { get; set; }
        public bool Favorited { get; set; }
        public decimal Balance { get; set; }
        public string CurrentReceiveAddress { get; set; }
    }
}