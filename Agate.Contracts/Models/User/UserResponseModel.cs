using Agate.Contracts.Models.Cards;

namespace Agate.Contracts.Models.User
{
    public class UserResponseModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserAddress[] Addresses { get; set; }
        public UserSettings Settings { get; set; }
        public UserAsset[] Assets { get; set; }
        public bool CardOrderPending { get; set; }
        public Card[] Cards { get; set; }
    }
}
