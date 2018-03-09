namespace Agate.Contracts.Models.User
{
    public class UpdateUserSettingsRequest
    {
        public int UserId { get; set; }
        public UserSettings Settings { get; set; }
    }
}