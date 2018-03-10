using OpalApp.LocalData;
using OpalApp.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OpalApp.AppLogic
{
    public class UXFlow
    {
        public static void DecideOnAppStartPage()
        {
            //if (UserAccount.UserId != null && UserAccount.AccessCode != null)
            //{
            //    if (UserAccount.Pin != null)
            //    {
            //        Application.Current.MainPage = new PinSignInPage();
            //    }
            //    else
            //    {
            //        // User exists but has not set pin
            //        // demand them to login and set pin                    
            //    }
            //}
            //else
            //{
            //    Application.Current.MainPage = new SignUpPage();
            //}
        }

        public static async Task<ContentPage> DecideOrderCardPage()
        {
            return null;
            //var userAddresses = (await UserData.ReadUserAddresses()) ?? new OpalApp.LocalData.UserAddress[0];
            //if (userAddresses == null || userAddresses.Length == 0 || !userAddresses.Any(ua => ua.Type == AddressType.Shipping))
            //{
            //    return new EditAddressPage(userAddresses,
            //        async (view) =>
            //        {
            //            var newUserAddresses = await UserData.ReadUserAddresses(); // todo : it will work fine for now, but it is inefficient to load addresses again. we should have it by now
            //            view.Navigation.InsertPageBefore(new OrderNewCardPage(newUserAddresses, userAddresses.FirstOrDefault(x => x.Type == AddressType.Shipping)), view.Navigation.NavigationStack.Last());
            //            await view.Navigation.PopAsync();
            //        });
            //}
            //else
            //{
            //    return new OrderNewCardPage(userAddresses, userAddresses.FirstOrDefault(x => x.Type == AddressType.Shipping));
            //}

            //// for next release it should ask users to deposit equal to 20$ to their bucket
            //// or if they have that amount in their bucket should let them know that they would be charged 20$ from their bucket
        }
    }
}
