using Plugin.SecureStorage.Abstractions;

namespace Agate.Business.Services
{
    public static class UserAccount
    {
        public static int? GetUserId(this ISecureStorage secureStorage)
        {
            if (secureStorage.HasKey("userid"))
            {
                int.TryParse(secureStorage.GetValue("userid"), out int result);
                return result;
            }
            return null;
        }

        public static void SetUserId(this ISecureStorage secureStorage, int? value)
        {
            if (value == null)
                secureStorage.DeleteKey("userid");
            else
                secureStorage.SetValue("userid", value.Value.ToString());
        }

        public static string GetAccessCode(this ISecureStorage secureStorage)
        {
            return secureStorage.GetValue("accesscode");
        }

        public static void SetAccessCode(this ISecureStorage secureStorage, string value)
        {
            if (value == null)
                secureStorage.DeleteKey("accesscode");
            else
                secureStorage.SetValue("accesscode", value);
        }

        public static string GetPin(this ISecureStorage secureStorage)
        {
            return secureStorage.GetValue("pin");
        }

        public static void SetPin(this ISecureStorage secureStorage, string value)
        {
            if (value == null)
                secureStorage.DeleteKey("pin");
            else
                secureStorage.SetValue("pin", value);
        }
    }

    //public interface IViewModelFactory
    //{
    //    TViewModel Create<TViewModel>();
    //    TViewModel Create<TInputModel, TViewModel>();
    //}
}
