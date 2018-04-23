using System;
using System.Collections.Generic;
using Agate.Business.AppLogic;
using Agate.Business.Services;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class MainMenuViewModel : BaseViewModel
    {
        private readonly IAppInfo appInfo;
        private readonly IAppData appData;
        private readonly Func<ChooseAssetsViewModel> createChooseAssetsViewModel;
        private readonly Func<ManageBucketViewModel> createManageBucketViewModelFunc;
        private INavigationService navigationService;
        private List<MenuItem> allMenuItems;

        public MainMenuViewModel(IAppInfo appInfo, IAppData appData, Func<NotImplementedFeatureViewModel> createNotImplementedFeatureViewModel, Func<ChooseAssetsViewModel> createChooseAssetsViewModel, Func<ManageBucketViewModel> createManageBucketViewModelFunc)
        {
            this.appInfo = appInfo;
            this.appData = appData;
            this.createChooseAssetsViewModel = createChooseAssetsViewModel;
            this.createManageBucketViewModelFunc = createManageBucketViewModelFunc;
            if (appInfo.Mode == AppMode.User)
            {
                AllMenuItems = new List<MenuItem>(new[]
                {
                    new MenuItem("Manage Assets", CreateChooseAssetViewModel, "#921243", "\ue90f"),
                    new MenuItem("Manage Cards", createNotImplementedFeatureViewModel, "#921243", "\ue870"),
                    new MenuItem("Manage iBucket", createManageBucketViewModelFunc, "#921243", "\ue80c"),
                    new MenuItem("Trader Bot", createNotImplementedFeatureViewModel, "#921243", "\ue80c"),
                    new MenuItem("AI Engine", createNotImplementedFeatureViewModel, "#921243", "\ue906"),
                    new MenuItem("Settings", createNotImplementedFeatureViewModel, "#921243", "\ue90f"),
                    new MenuItem("Tools", createNotImplementedFeatureViewModel, "#921243", "\ue8b8"),
                    new MenuItem("Help Center", createNotImplementedFeatureViewModel, "#921243", "\ue887"),
                    new MenuItem("Feedback", createNotImplementedFeatureViewModel, "#921243", "\ue0ca"),
                    new MenuItem("Legal", createNotImplementedFeatureViewModel, "#921243", "\ue80c"),
                });
            }
            else
            {
                AllMenuItems = new List<MenuItem>(new[]
                {
                    new MenuItem("Merchant Home", createNotImplementedFeatureViewModel,  "#921243", "\ue80c"),
                    new MenuItem("Manage Assets", CreateChooseAssetViewModel, "#921243", "\ue90f"),
                    new MenuItem("Manage Cards", createNotImplementedFeatureViewModel, "#921243", "\ue870"),
                    new MenuItem("Manage iBucket", createManageBucketViewModelFunc, "#921243", "\ue80c"),
                    new MenuItem("Trader Bot", createNotImplementedFeatureViewModel, "#921243", "\ue80c"),
                    new MenuItem("AI Engine", createNotImplementedFeatureViewModel, "#921243", "\ue906"),
                    new MenuItem("Settings", createNotImplementedFeatureViewModel, "#921243", "\ue90f"),
                    new MenuItem("Tools", createNotImplementedFeatureViewModel, "#921243", "\ue8b8"),
                    new MenuItem("Help Center", createNotImplementedFeatureViewModel, "#921243", "\ue887"),
                    new MenuItem("Feedback", createNotImplementedFeatureViewModel, "#921243", "\ue0ca"),
                    new MenuItem("Legal", createNotImplementedFeatureViewModel, "#921243", "\ue80c"),
                });
            }
        }

        public void Initialize(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public string Title => appInfo.AppName;

        public List<MenuItem> AllMenuItems
        {
            get => allMenuItems;
            set
            {
                allMenuItems = value;
                Raise(nameof(AllMenuItems));
            }
        }

        public MenuItem SelectedMenuItem
        {
            get => null;
            set
            {
                var menuitem = value;
                if (menuitem == null)
                    return;
                var viewModel = menuitem.CreateViewModelFunc();
                navigationService.Push(viewModel);
                Raise(nameof(SelectedMenuItem));
            }
        }

        private ChooseAssetsViewModel CreateChooseAssetViewModel()
        {
            var result = createChooseAssetsViewModel();
            result.Initialize(appData.AllAssets, appData.UserAssets);
            return result;
        }
    }
}