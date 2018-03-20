using System.Threading.Tasks;

namespace Agate.Business.AppLogic
{
    public interface IDataFlow
    {
        Task InitializeUser(string firstname, string lastname, string countryCode, string emailAddress, string mobileNumber);
        Task UpdateUserId(int userId);
        Task UpdateAccessCode(string accessCode);
    }
}