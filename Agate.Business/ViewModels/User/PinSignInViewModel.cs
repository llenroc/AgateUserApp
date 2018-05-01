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
        private string message;
        private string pinValue;

        public PinSignInViewModel(IViewService viewService, ISecureStorage secureStorage, IAppData appData, Func<MainViewModel> createMainViewModel)
        {
            this.viewService = viewService;
            this.secureStorage = secureStorage;
            this.appData = appData;
            this.createMainViewModel = createMainViewModel;
            SignInCommand = new XCommand(SignIn);
            SignInCommand.SetDependency(this);
        }

        public string Message
        {
            get => message;
            set
            {
                message = value;
                Raise(nameof(Message));
            }
        }

        public string PinValue
        {
            get => pinValue;
            set
            {
                pinValue = value;
                Raise(nameof(PinValue));
            }
        }

        public IXCommand SignInCommand { get; set; }

        public async void SignIn()
        {
            if (PinValue == secureStorage.GetPin())
            {
                await appData.LoadOfflineData();
                var mainViewModel = createMainViewModel();
                viewService.SetCurrentPage(mainViewModel);
            }
            else
            {
                Message = "Try Again";
                PinValue = null;
            }
        }
    }
}
