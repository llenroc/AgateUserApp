using System;
using System.Collections.Generic;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class MainMenuViewModel : BaseViewModel
    {
        private INavigationService navigationService;
        private List<MenuItem> allMenuItems;

        public MainMenuViewModel(Func<NotImplementedFeatureViewModel> createNotImplementedFeatureViewModel)
        {
            AllMenuItems = new List<MenuItem>(new[]
            {
                new MenuItem("Manage Assets", createNotImplementedFeatureViewModel, "#921243", "\ue90f"),
                new MenuItem("Manage Cards", createNotImplementedFeatureViewModel, "#921243", "\ue870"),
                new MenuItem("Trader Bot", createNotImplementedFeatureViewModel, "#921243", "\ue80c"),
                new MenuItem("AI Engine", createNotImplementedFeatureViewModel, "#921243", "\ue906"),
                new MenuItem("Settings", createNotImplementedFeatureViewModel, "#921243", "\ue90f"),
                new MenuItem("Tools", createNotImplementedFeatureViewModel, "#921243", "\ue8b8"),
                new MenuItem("Help Center", createNotImplementedFeatureViewModel, "#921243", "\ue887"),
                new MenuItem("Feedback", createNotImplementedFeatureViewModel, "#921243", "\ue0ca"),
            });
        }

        public void Initialize(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

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
    }
}