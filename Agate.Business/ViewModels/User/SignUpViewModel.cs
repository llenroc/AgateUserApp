using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Agate.Business.Api;
using Agate.Business.AppLogic;
using Agate.Business.Services;
using Agate.Contracts.Models.Account;
using Microsoft.AppCenter.Crashes;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Plugin.DeviceInfo.Abstractions;
using Triplezerooo.XMVVM;
using Xamarin.Forms;

namespace Agate.Business.ViewModels.User
{
    public class SignUpPageViewModel : BaseViewModel
    {
        private readonly IAccountService accountService;
        private readonly Func<int, ConfirmationCodeEntryViewModel> createConfirmationCodeEntryViewModel;
        private readonly IDataFlow dataFlow;
        private readonly IViewService viewService;
        private readonly Func<IPhoneService> phoneService;
        private readonly IDeviceInfo deviceInfo;
        private readonly IConnectivity connectivity;

        public SignUpPageViewModel(IAccountService accountService, Func<int, ConfirmationCodeEntryViewModel> createConfirmationCodeEntryViewModel, IDataFlow dataFlow, IViewService viewService, Func<IPhoneService> phoneService, IDeviceInfo deviceInfo, IConnectivity connectivity)
        {
            this.accountService = accountService;
            this.createConfirmationCodeEntryViewModel = createConfirmationCodeEntryViewModel;
            this.dataFlow = dataFlow;
            this.viewService = viewService;
            this.phoneService = phoneService;
            this.deviceInfo = deviceInfo;
            this.connectivity = connectivity;
            SignUpCommand = new XCommand(async () => await SignUp(), CanSignUp);

            FirstName = new Property<string>("First Name").RequiredString("First Name is required");
            LastName = new Property<string>("Last Name").RequiredString("Last Name is required");
            MobileNumber = new Property<string>("Mobile Number").RequiredString("Mobile Number is required");//.RequiredFormat(@"\d*", "Please just enter digits");
            EmailAddress = new Property<string>("Email Address").RequiredString("Email address is required");

            SignUpCommand.SetDependency(this, FirstName, LastName, MobileNumber, EmailAddress);            
        }

        public Property<string> FirstName { get; }
        public Property<string> LastName { get; }
        public Property<string> MobileNumber { get; }
        public Property<string> EmailAddress { get; }

        public IXCommand SignUpCommand { get; }

        public bool CanSignUp()
        {
            return IsNotBusy && Validation.Check(FirstName, LastName, MobileNumber, EmailAddress);
        }

        public async Task SignUp()
        {
            if (!CanSignUp())
            {
                await View.DisplayAlert("Invalid values", "Please enter all required values.", "Ok");
                return;
            }

            try
            {
                if (!connectivity.IsConnected)
                {
                    await View.DisplayAlert("Internet required", "To sign up the app requires internet connection.", "Ok");
                    return;
                }

                var requestObj = new SignUpRequest
                {
                    FirstName = FirstName.Value,
                    LastName = LastName.Value,
                    CountryCode = GetCountryCode(),
                    DeviceId = GetDeviceId(),
                    EmailAddress = EmailAddress.Value,
                    MobileNumber = MobileNumber.Value,
                    RequestForNewCode = false
                };

                SignUpResponseModel result;

                using (WorkingScope.Enter())
                {
                    result = await accountService.SignUp(requestObj);
                }

                if (result != null)
                {
                    if (result.Success)
                    {
                        using (WorkingScope.Enter())
                        {
                            await dataFlow.InitializeUser(requestObj.FirstName, requestObj.LastName,
                                requestObj.CountryCode,
                                requestObj.EmailAddress, requestObj.MobileNumber);
                        }

                        var confirmationPage = createConfirmationCodeEntryViewModel(result.RequestId);
                        viewService.SetCurrentPage(confirmationPage);
                    }

                    else
                    {
                        var message = result.Error ?? "Unknown error.";

                        await View.DisplayAlert("Error", message, "Ok");
                    }
                }
                else
                {
                    var message = "There is an issue with communicating to our servers. Please try again.";

                    await View.DisplayAlert("Error", message, "Ok");
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    {"page", "sign up"},
                    {"operation", nameof(SignUp)}
                });
                await View.DisplayAlert("Error", "An error occurred while processing your request" + ex, "Ok");
            }
        }

        private string GetDeviceId()
        {
            try
            {
                var deviceId = deviceInfo.Id;
                return deviceId;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    {"page", "sign up"},
                    {"operation", nameof(GetDeviceId)}
                });
                return "error";
            }
        }

        private string GetCountryCode()
        {
            try
            {
                var phoneServiceInstance = phoneService();
                var countryCode = $"ISO:{phoneServiceInstance.ICC}::::MMC:{phoneServiceInstance.MCC}";
                return countryCode;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    {"page", "sign up"},
                    {"operation", nameof(GetDeviceId)}
                });
                return "error";
            }
        }
    }
}
