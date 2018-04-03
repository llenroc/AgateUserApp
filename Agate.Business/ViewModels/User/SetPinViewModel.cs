using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Agate.Business.Api;
using Agate.Business.Services;
using Agate.Business.ViewModels.Main;
using Agate.Contracts.Models.Account;
using Plugin.DeviceInfo.Abstractions;
using Plugin.SecureStorage.Abstractions;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.User
{
    public class SetPinViewModel : BaseViewModel
    {
        private readonly IAccountService accountService;
        private readonly IViewService viewService;
        private readonly IDeviceInfo deviceInfo;
        private readonly ISecureStorage secureStorage;
        private readonly Func<MainViewModel> createMainViewModel;

        public SetPinViewModel(IAccountService accountService, IViewService viewService, IDeviceInfo deviceInfo, ISecureStorage secureStorage, Func<MainViewModel> createMainViewModel)
        {
            this.accountService = accountService;
            this.viewService = viewService;
            this.deviceInfo = deviceInfo;
            this.secureStorage = secureStorage;
            this.createMainViewModel = createMainViewModel;
            Pin1 = new Property<string>("PIN").RequiredString("Please enter a PIN value");
            Pin2 = new Property<string>("PIN repeat").Check(pin2=>pin2 == Pin1.Value, "The values does not match");
            SetPinCommand = new XCommand(async ()=> await SetPin(), CanSetPin);
            SetPinCommand.SetDependency(this, Pin1, Pin2);
        }

    
        public Property<string> Pin1 { get; set; }
        public Property<string> Pin2 { get; set; }
        public IXCommand SetPinCommand { get; set; }

        public bool CanSetPin()
        {
            return IsNotBusy && Validation.Check(Pin1,Pin2);
        }

        public async Task SetPin()
        {
            try
            {
                if (Pin1.Value != Pin2.Value)
                {
                    await View.DisplayAlert("PINs don't match", "The PIN values entered does not match", "Ok");
                    return;
                }
                var userId = secureStorage.GetUserId();
                var accessCode = secureStorage.GetAccessCode();

                if (userId == null || string.IsNullOrWhiteSpace(accessCode))
                {
                    await View.DisplayAlert("Error", "You are not signed in.", "Ok");
                }

                var response = await accountService.ChangePin(new ChangePinRequest
                {
                    UserId = secureStorage.GetUserId().Value,
                    DeviceId = deviceInfo.Id,
                    Pin = Pin1.Value,
                });

                secureStorage.SetPin(Pin1.Value);

                if (response != null && response.Success)
                {
                    viewService.SetCurrentPage(createMainViewModel());
                }
                else
                {
                    await View.DisplayAlert("Error", response == null ? "Connection Error" : response.Error, "Ok");
                }
            }
            catch (Exception ex)
            {
                await View.DisplayAlert("Error", "An error occurred. Please try again.", "Ok");
            }

        }
    }
}
