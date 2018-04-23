using System;
using System.Collections.Generic;
using System.Text;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class FeedbackViewModel : BaseViewModel
    {
        public FeedbackViewModel()
        {
            Feedback = new Property<string>().Required("");
            SubmitCommand = new XCommand(Submit, CanSubmit);
            SubmitCommand.SetDependency(this, Feedback);
        }

        public Property<string> Feedback { get; set; }

        private bool CanSubmit()
        {
            return IsNotBusy && Validation.Check(Feedback);
        }

        private async void Submit()
        {
            await View.DisplayAlert("Success", "Thank you for your feedback.", "Ok");
            Feedback.InitializeValue("");
        }

        public IXCommand SubmitCommand { get; set; }
    }
}
