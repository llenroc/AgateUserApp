using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Agate.Business.Api;
using Agate.Business.AppLogic;
using Agate.Business.LocalData;
using Agate.Contracts.Models.Account;
using Microsoft.AppCenter.Crashes;
using OpalApp.Services;
using Plugin.Connectivity.Abstractions;
using Plugin.DeviceInfo.Abstractions;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.User
{
    public class ConfirmationCodeEntryViewModel : BaseViewModel
    {
        private readonly IAccountService accountService;
        private readonly IViewService viewService;
        private readonly IDataFlow dataFlow;
        private readonly IDeviceInfo deviceInfo;
        private readonly IConnectivity connectivity;
        private readonly int requestId;

        public ConfirmationCodeEntryViewModel(int requestId, IAccountService accountService, IViewService viewService, IDataFlow dataFlow, IDeviceInfo deviceInfo, IConnectivity connectivity) : base()
        {
            this.accountService = accountService;
            this.viewService = viewService;
            this.dataFlow = dataFlow;
            this.deviceInfo = deviceInfo;
            this.connectivity = connectivity;
            this.requestId = requestId;

            Initialize();
        }

        private void Initialize()
        {
            ConfirmationCode = new Property<string>("Confirmation Code");
            ConfirmCommand = new XCommand(async () => await Confirm(), CanConfirm);
            ConfirmCommand.SetDependency(this, ConfirmationCode);
        }

        public Property<string> ConfirmationCode { get; set; }
        public IXCommand ConfirmCommand { get; set; }

        public bool CanConfirm()
        {
            return IsNotBusy && ConfirmationCode.IsValid;

        }
        public async Task Confirm()
        {
            try
            {
                if (!connectivity.IsConnected)
                {
                    await View.DisplayAlert("Internet required", "To sign up the app requires internet connection.", "Ok");
                    return;
                }

                ConfirmSignUpResponse response;
                using (WorkingScope.Enter())
                {
                    (string deviceId, string deviceName) = GetDeviceInfo();
                    var request = new ConfirmSignUpRequest
                    {
                        RequestId = requestId,
                        DeviceId = Plugin.DeviceInfo.CrossDeviceInfo.Current.Id,
                        DeviceName = Plugin.DeviceInfo.CrossDeviceInfo.Current.DeviceName,
                        ConfirmationCode = ConfirmationCode.Value,
                    };

                    response = await accountService.ConfirmSignup(request);
                }

                if (response.Success)
                {
                    await dataFlow.UpdateUserId(response.UserId);
                    await dataFlow.UpdateAccessCode(response.AccessCode);

                    viewService.SetCurrentPage(new SetPinViewModel());
                }
                else
                {
                    await View.DisplayAlert("Invalid Code", response.Error, "Ok");
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    {"page", "confirmation code entry"},
                    {"operation", nameof(Confirm)}
                });
                await View.DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private (string deviceId, string deviceName) GetDeviceInfo()
        {
            try
            {
                return (deviceInfo.Id, deviceInfo.DeviceName);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    {"page", "confirmation code entry"},
                    {"operation", nameof(GetDeviceInfo)}
                });
                return ("Error occurred" + ex.ToString(), "Error occurred");
            }
        }
    }
}
