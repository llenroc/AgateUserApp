using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Agate.Business.Api;
using Agate.Contracts.Models.Account;
using OpalApp.AppLogic;
using OpalApp.Services;
using Plugin.Connectivity;
using Triplezerooo.XMVVM;
using Xamarin.Forms;

namespace Agate.Business.ViewModels.User
{
    public class SignUpPageViewModel : BaseViewModel
    {
        public SignUpPageViewModel() : base()
        {
            SignUpCommand = new XCommand(async () => await SignUp(), CanSignUp);

            FirstName = new Property<string>("First Name").RequiredString("First Name is required");
            LastName = new Property<string>("Last Name").RequiredString("Last Name is required");
            MobileNumber = new Property<string>("Mobile Number").RequiredString("Mobile Number is required");//.RequiredFormat(@"\d*", "Please just enter digits");
            EmailAddress = new Property<string>("Email Address").RequiredString("Email address is required");

            SignUpCommand.SetDependency(this, FirstName, LastName, MobileNumber, EmailAddress);            
        }

        public Property<string> FirstName { get; set; }
        public Property<string> LastName { get; set; }
        public Property<string> MobileNumber { get; set; }
        public Property<string> EmailAddress { get; set; }

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
                if (!CrossConnectivity.Current.IsConnected)
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

                using (var scope = WorkingScope.Enter())
                {
                    result = await AccountService.SignUp(requestObj);
                }

                if (result != null)
                {
                    if (result.Success)
                    {
                        using (var scope = WorkingScope.Enter())
                        {
                            await DataFlow.InitializeUser(requestObj.FirstName, requestObj.LastName,
                                requestObj.CountryCode,
                                requestObj.EmailAddress, requestObj.MobileNumber);
                        }

                        var confirmationPage = new ConfirmationCodeEntryViewModel(result.RequestId);
                        SingltonServices.ViewService.SetCurrentPage(confirmationPage);
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
                await View.DisplayAlert("Error", "Error message:" + ex.Message, "Ok");
            }
        }

        private static string GetDeviceId()
        {
            try
            {
                var deviceId = Plugin.DeviceInfo.CrossDeviceInfo.Current.Id;
                return deviceId;
            }
            catch (Exception ex)
            {
                return "Error occurred" + ex.ToString(); // todo : this is for testing period, replace it with proper exception handling
            }
        }

        private static string GetCountryCode()
        {
            try
            {
                var phoneService = DependencyService.Get<IPhoneService>();
                var countryCode = $"ISO:{phoneService.ICC}::::MMC:{phoneService.MCC}";
                return countryCode;
            }
            catch (Exception ex)
            {
                return "Error occured" + ex.ToString(); // todo : this is for testing period, replace it with proper exception handling
            }
        }


    }
}
