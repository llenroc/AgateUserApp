using System;
using System.Threading.Tasks;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.User
{
    public class SetPinViewModel : BaseViewModel
    {
        public SetPinViewModel()
        {
            Pin1 = new Property<string>("PIN");
            Pin2 = new Property<string>("PIN repeat");
            SetPinCommand = new XCommand(async ()=> await SetPin(), CanSetPin);
            SetPinCommand.SetDependency(this, Pin1, Pin2);
        }


        public Property<string> Pin1 { get; set; }
        public Property<string> Pin2 { get; set; }
        public IXCommand SetPinCommand { get; set; }

        private bool CanSetPin()
        {
            return IsNotBusy && Validation.Check(Pin1,Pin2);
        }

        private Task SetPin()
        {
            throw new NotImplementedException();
        }
    }
}
