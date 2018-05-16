using System.Threading.Tasks;
using Agate.Contracts.Models;

namespace Agate.Business.API
{
    public interface IUserServices
    {
        Task<ApiResponse> Feedback(int userId, SubmitFeedbackRequest feedback);
    }
}