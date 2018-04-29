using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Agate.Business.LocalData;
using Microsoft.AppCenter.Crashes;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class SettingsViewModel : BaseViewModel, IViewModelLifeTime
    {
        private readonly IUserData userData;
        private UserSettings userSettings;
        private UserProfile userProfile;

        public SettingsViewModel(IUserData userData)
        {
            this.userData = userData;
            Initialize();
        }

        private void Initialize()
        {
            EmailAddress = new Property<string>("Email Address");
            PhoneNumber = new Property<string>("Phone Number");

            PaymentSuccessfulViaEmail = new Property<bool>();
            PaymentSuccessfulViaSMS = new Property<bool>();
            PaymentFailedViaEmail = new Property<bool>();
            PaymentFailedViaSMS = new Property<bool>();
            IncomingTransferViaEmail = new Property<bool>();
            IncomingTransferViaSMS = new Property<bool>();
            OutgoingTransferViaEmail = new Property<bool>();
            OutgoingTransferViaSMS = new Property<bool>();

            ManagePINCommand = new XCommand(ManagePin);
            VerificationCommand = new XCommand(VerificationCode);
            BackupCommand = new XCommand(Backup);
            SaveCommand = new XCommand(async ()=> await Save(), CanSave);            
        }

        public Property<string> EmailAddress { get; set; }
        public Property<string> PhoneNumber { get; set; }
        public Property<bool> PaymentSuccessfulViaEmail { get; set; }
        public Property<bool> PaymentSuccessfulViaSMS { get; set; }
        public Property<bool> PaymentFailedViaEmail { get; set; }
        public Property<bool> PaymentFailedViaSMS { get; set; }
        public Property<bool> IncomingTransferViaEmail { get; set; }
        public Property<bool> IncomingTransferViaSMS { get; set; }
        public Property<bool> OutgoingTransferViaEmail { get; set; }
        public Property<bool> OutgoingTransferViaSMS { get; set; }
        public IXCommand ManagePINCommand { get; set; }
        public IXCommand VerificationCommand { get; set; }
        public IXCommand BackupCommand { get; set; }
        public IXCommand SaveCommand { get; set; }

        public async Task OnAppearing()
        {
            userSettings = await userData.ReadSettings();
            userProfile = await userData.ReadUserData();

            EmailAddress.Value = userProfile.EmailAddress;
            PhoneNumber.Value = userProfile.MobileNumber;

            PaymentSuccessfulViaEmail.Value = userSettings.NotifyByEmailOnPaymentSuccessful;
            PaymentSuccessfulViaSMS.Value = userSettings.NotifyBySMSOnPaymentSuccessful;
            PaymentFailedViaEmail.Value = userSettings.NotifyByEmailOnPaymentFailed;
            PaymentFailedViaSMS.Value = userSettings.NotifyBySMSOnPaymentFailed;
            IncomingTransferViaEmail.Value = userSettings.NotifyByEmailOnIncomingTransfer;
            IncomingTransferViaSMS.Value = userSettings.NotifyBySMSOnIncomingTransfer;
            OutgoingTransferViaEmail.Value = userSettings.NotifyByEmailOnOutgoingTransfer;
            OutgoingTransferViaSMS.Value = userSettings.NotifyBySMSOnOutgoingTransfer;
        }

        public async Task OnDisappearing()
        {

        }

        private void ManagePin()
        {

        }

        private void VerificationCode()
        {

        }

        private void Backup()
        {

        }

        private bool CanSave()
        {
            return IsNotBusy;
        }

        private async Task Save()
        {
            try
            {
                using (WorkingScope.Enter())
                {
                    userSettings.NotifyByEmailOnPaymentSuccessful = PaymentSuccessfulViaEmail.Value;
                    userSettings.NotifyBySMSOnPaymentSuccessful = PaymentSuccessfulViaSMS.Value;
                    userSettings.NotifyByEmailOnPaymentFailed = PaymentFailedViaEmail.Value;
                    userSettings.NotifyBySMSOnPaymentFailed = PaymentFailedViaSMS.Value;
                    userSettings.NotifyByEmailOnIncomingTransfer = IncomingTransferViaEmail.Value;
                    userSettings.NotifyBySMSOnIncomingTransfer = IncomingTransferViaSMS.Value;
                    userSettings.NotifyByEmailOnOutgoingTransfer = OutgoingTransferViaEmail.Value;
                    userSettings.NotifyBySMSOnOutgoingTransfer = OutgoingTransferViaSMS.Value;

                    await userData.SaveSettings(userSettings);
                }
            }
            catch(Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    {"page", "settings"},
                    {"operation", $"saving changes"}
                });
                await View.DisplayAlert("Error", "An error occurred while saving settings" + ex, "Ok");
            }
        }
    }
}
