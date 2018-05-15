using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IAppInfo appInfo;

        public SignUpPageViewModel(IAccountService accountService, Func<int, ConfirmationCodeEntryViewModel> createConfirmationCodeEntryViewModel, IDataFlow dataFlow, IViewService viewService, Func<IPhoneService> phoneService, IDeviceInfo deviceInfo, IConnectivity connectivity, IAppInfo appInfo)
        {
            this.accountService = accountService;
            this.createConfirmationCodeEntryViewModel = createConfirmationCodeEntryViewModel;
            this.dataFlow = dataFlow;
            this.viewService = viewService;
            this.phoneService = phoneService;
            this.deviceInfo = deviceInfo;
            this.connectivity = connectivity;
            this.appInfo = appInfo;
            SignUpCommand = new XCommand(async () => await SignUp(), CanSignUp);

            BusinessName = new Property<string>("Buiness Name").RequiredString("Business Name is required");
            FirstName = new Property<string>("First Name").RequiredString("First Name is required");
            LastName = new Property<string>("Last Name").RequiredString("Last Name is required");
            Country = new Property<CountryDetails>("Country").Required("Choose a country");
            MobileNumber = new Property<string>("Mobile Number").RequiredString("Mobile Number is required").RequiredFormat(@"(\d|\s)*", "Please just enter digits");
            EmailAddress = new Property<string>("Email Address").RequiredString("Email address is required");

            SignUpCommand.SetDependency(this, FirstName, LastName, MobileNumber, EmailAddress);

            AllCountries = CountriesData.List.OrderBy(c=>c.CountryName).ToArray();
            var countryCode = GetCountryCode();
            var country = AllCountries.SingleOrDefault(c => c.DialingCode == countryCode) ?? AllCountries.SingleOrDefault(c => c.CountryCode == "AU");
            Country.InitializeValue(country);
        }

        public Property<string> BusinessName { get; set; }
        public Property<string> FirstName { get; }
        public Property<string> LastName { get; }
        public CountryDetails[] AllCountries { get; }
        public Property<CountryDetails> Country { get; set; }
        public Property<string> MobileNumber { get; }
        public Property<string> EmailAddress { get; }

        public IXCommand SignUpCommand { get; }

        public bool CanSignUp()
        {
            if (appInfo.Mode == AppMode.Merchant)
            {
                return IsNotBusy && Validation.Check(BusinessName, MobileNumber, EmailAddress);
            }
            else
            {
                return IsNotBusy && Validation.Check(FirstName, LastName, MobileNumber, EmailAddress);
            }
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
                    BusinessName = BusinessName.Value,
                    FirstName = FirstName.Value,
                    LastName = LastName.Value,
                    CountryCode = Country.Value?.DialingCode ?? GetCountryCode(),
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
                    if (result.StatusCode == 0)
                    {
                        using (WorkingScope.Enter())
                        {
                            await dataFlow.InitializeUser(requestObj.BusinessName, requestObj.FirstName, requestObj.LastName,
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
