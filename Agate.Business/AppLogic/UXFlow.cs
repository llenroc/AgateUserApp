using System;
using System.Linq;
using System.Threading.Tasks;
using Agate.Business.LocalData;
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
        private readonly IUserData userData;
        private readonly ISecureStorage secureStorage;
        private readonly IViewService viewService;
        private readonly Func<MainViewModel> createMainViewModel;
        private readonly Func<PinSignInViewModel> createPinSignInViewModel;
        private readonly Func<SignUpPageViewModel> createSignUpPageViewModel;
        private readonly Func<EditAddressViewModel> createEditAddressViewModel;
        private readonly Func<OrderNewCardViewModel> createOrderNewCardViewModel;

        public UXFlow(IUserData userData, ISecureStorage secureStorage, IViewService viewService, Func<MainViewModel> createMainViewModel, Func<PinSignInViewModel> createPinSignInViewModel, Func<SignUpPageViewModel> createSignUpPageViewModel, Func<EditAddressViewModel> createEditAddressViewModel, Func<OrderNewCardViewModel> createOrderNewCardViewModel)
        {
            this.userData = userData;
            this.secureStorage = secureStorage;
            this.viewService = viewService;
            this.createMainViewModel = createMainViewModel;
            this.createPinSignInViewModel = createPinSignInViewModel;
            this.createSignUpPageViewModel = createSignUpPageViewModel;
            this.createEditAddressViewModel = createEditAddressViewModel;
            this.createOrderNewCardViewModel = createOrderNewCardViewModel;
        }

        public void DecideOnAppStartPage()
        {
            if (secureStorage.GetUserId() != null && secureStorage.GetAccessCode() != null)
            {
                if (secureStorage.GetPin() != null)
                {
                    var pinSignInViewModel = createPinSignInViewModel();
                    viewService.SetCurrentPage(pinSignInViewModel);
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

        public async Task<BaseViewModel> DecideOrderCardPage(INavigationService navigationService)
        {
            var userAddresses = (await userData.ReadUserAddresses()) ?? new UserAddress[0];
            if (userAddresses.Length == 0 || !userAddresses.Any(ua => ua.Type == AddressType.Shipping))
            {
                var editAddressViewModel = createEditAddressViewModel();
                editAddressViewModel.InitializeForNewAddress(navigationService, userAddresses, 
                    async (view) =>
                    {
                        var newUserAddresses = await userData.ReadUserAddresses();
                        var orderNewCardViewModel = createOrderNewCardViewModel();
                        orderNewCardViewModel.Initialize(navigationService, newUserAddresses, newUserAddresses.FirstOrDefault(x => x.Type == AddressType.Shipping));
                        navigationService.Replace(orderNewCardViewModel);
                    });
                return editAddressViewModel;
            }
            else
            {
                var orderNewCardViewModel = createOrderNewCardViewModel();
                orderNewCardViewModel.Initialize(navigationService, userAddresses, userAddresses.FirstOrDefault(x => x.Type == AddressType.Shipping));
                return orderNewCardViewModel;
            }

            // for next release it should ask users to deposit equal to 20$ to their bucket
            // or if they have that amount in their bucket should let them know that they would be charged 20$ from their bucket
        }
    }
}
