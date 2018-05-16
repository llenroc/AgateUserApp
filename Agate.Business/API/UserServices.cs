using System.Threading.Tasks;
using Agate.Contracts.Models;

namespace Agate.Business.API
{
    public class UserServices : IUserServices
    {
        //public async Task<> Get(int userId) =>
        //    await Client.Get<>($"user/{userId}");

        //public async Task<> Update(int userId, UpdateUserRequest updateUser) =>
        //    await Client.Post<UpdateUserRequest, >($"user/{userId}", updateUser);

        public async Task<ApiResponse> Feedback(int userId, SubmitFeedbackRequest feedback) =>
            await Client.Post<SubmitFeedbackRequest, ApiResponse>($"user/{userId}/feedback", feedback);
    }
}