using Plugin.SecureStorage;
//using XamStorage;
using FileAccess = System.IO.FileAccess;

namespace OpalApp.Services
{
    public class UserAccount
    {
        public static int? UserId
        {
            get
            {
                if (CrossSecureStorage.Current.HasKey("userid"))
                {
                    int.TryParse(CrossSecureStorage.Current.GetValue("userid"), out int result);
                    return result;
                }
                return null;
            }
            set
            {
                if (value == null)
                    CrossSecureStorage.Current.DeleteKey("userid");
                else
                    CrossSecureStorage.Current.SetValue("userid", value.Value.ToString());
            }
        }
        public static string AccessCode
        {
            get => CrossSecureStorage.Current.GetValue("accesscode");
            set
            {
                if (value == null)
                    CrossSecureStorage.Current.DeleteKey("accesscode");
                else
                    CrossSecureStorage.Current.SetValue("accesscode", value);
            }
        }

        public static string Pin
        {
            get => CrossSecureStorage.Current.GetValue("pin");
            set
            {
                if (value == null)
                    CrossSecureStorage.Current.DeleteKey("pin");
                else
                    CrossSecureStorage.Current.SetValue("pin", value);
            }
        }
    }
}
