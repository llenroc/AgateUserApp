namespace Agate.Contracts.Models.User
{
    public class UpdateUserRequest
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}