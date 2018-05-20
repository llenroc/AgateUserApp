using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Agate.Business.API;
using Agate.Business.LocalData;
using Agate.Business.Services;
using Agate.Contracts.Models;
using Microsoft.AppCenter.Crashes;
using Plugin.SecureStorage.Abstractions;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class FeedbackViewModel : BaseViewModel
    {
        private readonly ISecureStorage secureStorage;
        private readonly IUserServices userServices;

        public FeedbackViewModel(ISecureStorage secureStorage, IUserServices userServices)
        {
            this.secureStorage = secureStorage;
            this.userServices = userServices;
            Feedback = new Property<string>("Message").Required("");
            FeedbackType = new Property<string>("Type");
            SubmitCommand = new XCommand(Submit, CanSubmit);
            SubmitCommand.SetDependency(this, Feedback);

            FeedbackTypes = new List<string>(new[] {"Thanks", "Complain", "Suggestion", "Other"});
        }

        public Property<string> Feedback { get; set; }
        public List<string> FeedbackTypes { get; set; }
        public Property<string> FeedbackType { get; set; }

        private bool CanSubmit()
        {
            return IsNotBusy && Validation.Check(Feedback);
        }

        private async void Submit()
        {
            try
            {
                using (var scope = base.WorkingScope.Enter())
                {
                    await userServices.Feedback(secureStorage.GetUserId().Value, new SubmitFeedbackRequest {Type = FeedbackType.Value, Message = Feedback.Value});
                    await View.DisplayAlert("Success", "Thank you for your feedback.", "Ok");
                    Feedback.InitializeValue("");
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>
                {
                    {"page", "feedback"},
                    {"operation", nameof(Submit)}
                });
                await View.DisplayAlert("Error", "An error occurred while processing your request" + ex, "Ok");
            }
        }

        public IXCommand SubmitCommand { get; set; }
    }
}
