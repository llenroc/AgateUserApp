using Plugin.SecureStorage.Abstractions;

namespace Agate.Business.Services
{
    public static class UserAccount
    {
        public const string UserIdkey = "userid";
        public const string AccessCodeKey = "accesscode";
        public const string PinKey = "pin";

        public static int? GetUserId(this ISecureStorage secureStorage)
        {
            if (secureStorage.HasKey(UserIdkey))
            {
                int.TryParse(secureStorage.GetValue(UserIdkey), out int result);
                return result;
            }
            return null;
        }

        public static void SetUserId(this ISecureStorage secureStorage, int? value)
        {
            if (value == null)
                secureStorage.DeleteKey(UserIdkey);
            else
                secureStorage.SetValue(UserIdkey, value.Value.ToString());
        }

        public static string GetAccessCode(this ISecureStorage secureStorage)
        {
            return secureStorage.GetValue(AccessCodeKey);
        }

        public static void SetAccessCode(this ISecureStorage secureStorage, string value)
        {
            if (value == null)
                secureStorage.DeleteKey(AccessCodeKey);
            else
                secureStorage.SetValue(AccessCodeKey, value);
        }

        public static string GetPin(this ISecureStorage secureStorage)
        {
            return secureStorage.GetValue(PinKey);
        }

        public static void SetPin(this ISecureStorage secureStorage, string value)
        {
            if (value == null)
                secureStorage.DeleteKey(PinKey);
            else
                secureStorage.SetValue(PinKey, value);
        }
    }
}
