using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Agate.Business.AppLogic;
using Agate.Business.Services;
using Agate.Business.ViewModels.Main;
using Plugin.SecureStorage.Abstractions;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.User
{
    public class PinSignInViewModel : BaseViewModel
    {
        private readonly IViewService viewService;
        private readonly ISecureStorage secureStorage;
        private readonly IAppData appData;
        private readonly Func<MainViewModel> createMainViewModel;

        public PinSignInViewModel(IViewService viewService, ISecureStorage secureStorage, IAppData appData, Func<MainViewModel> createMainViewModel)
        {
            this.viewService = viewService;
            this.secureStorage = secureStorage;
            this.appData = appData;
            this.createMainViewModel = createMainViewModel;
            Pin = new Property<string>("Pin").RequiredString("Pin is required");
            SignInCommand = new XCommand(SignIn, CanSignIn);
            SignInCommand.SetDependency(this, Pin);
        }

        public Property<string> Pin { get; set; }
        public IXCommand SignInCommand { get; set; }

        public bool CanSignIn()
        {
            return IsNotBusy && Validation.Check(Pin);
        }

        public async void SignIn()
        {
            if (Pin.Value == secureStorage.GetPin())
            {
                await appData.LoadOfflineData();
                var mainViewModel = createMainViewModel();
                viewService.SetCurrentPage(mainViewModel);
            }
            else
            {
                Pin.Value = "";
            }
        }
    }
}
