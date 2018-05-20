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
        private readonly Func<FeedbackViewModel> createFeedbackViewModelFunc;
        private readonly Func<SettingsViewModel> createSettingsViewModelFunc;
        private INavigationService navigationService;
        private List<MenuItem> allMenuItems;

        public MainMenuViewModel(IAppInfo appInfo, IAppData appData, Func<NotImplementedFeatureViewModel> createNotImplementedFeatureViewModel, Func<ChooseAssetsViewModel> createChooseAssetsViewModel, Func<ManageBucketViewModel> createManageBucketViewModelFunc, Func<FeedbackViewModel> createFeedbackViewModelFunc, Func<SettingsViewModel> createSettingsViewModelFunc)
        {
            this.appInfo = appInfo;
            this.appData = appData;
            this.createChooseAssetsViewModel = createChooseAssetsViewModel;
            this.createManageBucketViewModelFunc = createManageBucketViewModelFunc;
            this.createFeedbackViewModelFunc = createFeedbackViewModelFunc;
            this.createSettingsViewModelFunc = createSettingsViewModelFunc;
            if (appInfo.Mode == AppMode.User)
            {
                AllMenuItems = new List<MenuItem>(new[]
                {
                    new MenuItem("Manage Assets", CreateChooseAssetViewModel, "#921243", "n"),
                    new MenuItem("Manage Cards", createNotImplementedFeatureViewModel, "#921243", "A"),
                    new MenuItem("Manage iBucket", createManageBucketViewModelFunc, "#921243", "Y"),
                    new MenuItem("Trader Bot", createNotImplementedFeatureViewModel, "#921243", "D"),
                    new MenuItem("AI Engine", createNotImplementedFeatureViewModel, "#921243", "S"),
                    new MenuItem("Settings", createSettingsViewModelFunc, "#921243", "i"),
                    new MenuItem("Tools", createNotImplementedFeatureViewModel, "#921243", "R"),
                    new MenuItem("Help Center", createNotImplementedFeatureViewModel, "#921243", "M"),
                    new MenuItem("Feedback", createFeedbackViewModelFunc, "#921243", "F"),
                    new MenuItem("Legal", createNotImplementedFeatureViewModel, "#921243", "f"),
                });
            }
            else
            {
                AllMenuItems = new List<MenuItem>(new[]
                {
                    new MenuItem("Merchant Home", createNotImplementedFeatureViewModel,  "#921243", "N"),
                    new MenuItem("Manage Assets", CreateChooseAssetViewModel, "#921243", "n"),
                    new MenuItem("Manage Cards", createNotImplementedFeatureViewModel, "#921243", "A"),
                    new MenuItem("Manage iBucket", createManageBucketViewModelFunc, "#921243", "Y"),
                    new MenuItem("Trader Bot", createNotImplementedFeatureViewModel, "#921243", "D"),
                    new MenuItem("AI Engine", createNotImplementedFeatureViewModel, "#921243", "S"),
                    new MenuItem("Settings", createSettingsViewModelFunc, "#921243", "i"),
                    new MenuItem("Tools", createNotImplementedFeatureViewModel, "#921243", "R"),
                    new MenuItem("Help Center", createNotImplementedFeatureViewModel, "#921243", "M"),
                    new MenuItem("Feedback", createFeedbackViewModelFunc, "#921243", "F"),
                    new MenuItem("Legal", createNotImplementedFeatureViewModel, "#921243", "f"),
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