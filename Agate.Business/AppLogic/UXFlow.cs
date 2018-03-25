using System;
using System.Threading.Tasks;
using Agate.Business.Services;
using Agate.Business.ViewModels.Main;
using Agate.Business.ViewModels.User;
using Plugin.SecureStorage.Abstractions;
using Triplezerooo.XMVVM;
using Xamarin.Forms;

namespace Agate.Business.AppLogic
{
    public class UXFlow : IUXFlow
    {
        private readonly ISecureStorage secureStorage;
        private readonly IViewService viewService;
        private readonly Func<MainViewModel> createMainViewModel;
        private readonly Func<SetPinViewModel> createSetPinViewModel;
        private readonly Func<SignUpPageViewModel> createSignUpPageViewModel;

        public UXFlow(ISecureStorage secureStorage, IViewService viewService, Func<MainViewModel> createMainViewModel, Func<SetPinViewModel> createSetPinViewModel, Func<SignUpPageViewModel> createSignUpPageViewModel)
        {
            this.secureStorage = secureStorage;
            this.viewService = viewService;
            this.createMainViewModel = createMainViewModel;
            this.createSetPinViewModel = createSetPinViewModel;
            this.createSignUpPageViewModel = createSignUpPageViewModel;
        }

        public void DecideOnAppStartPage()
        {
            var mainViewModel = createMainViewModel();
            viewService.SetCurrentPage(mainViewModel);
            return;

            if (secureStorage.GetUserId() != null && secureStorage.GetAccessCode() != null)
            {
                if (secureStorage.GetPin() != null)
                {
                    var setPinViewModel = createSetPinViewModel();
                    viewService.SetCurrentPage(setPinViewModel);
                }
                else
                {
                    // User exists but has not set pin
                    // demand them to login and set pin                    
                }
            }
            else
            {
                var signUpViewModel = createSignUpPageViewModel();
                viewService.SetCurrentPage(signUpViewModel);
            }
        }

        public async Task<BaseViewModel> DecideOrderCardPage()
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
