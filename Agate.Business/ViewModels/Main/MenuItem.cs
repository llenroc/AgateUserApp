using System;
using System.Threading.Tasks;
using Triplezerooo.XMVVM;
using Xamarin.Forms;

namespace Agate.Business.ViewModels.Main
{
    public class MenuItem
    {
        public const string ArrowRight = "\ue315";

        public MenuItem(string name, Func<BaseViewModel> createViewModelFunc, string backgroundImage, string icon = ArrowRight,
            bool isNew = false,
            bool justNotifyNavigateIntent = false,
            Action<INavigation> customNavigation = null
        )
        {
            Name = name;
            CreateViewModelFunc = createViewModelFunc;
            Icon = icon;
            BackgroundImage = backgroundImage;
            IsNew = isNew;
        }

        public string Name { get; }

        public Func<BaseViewModel> CreateViewModelFunc { get; }

        public string Icon { get; }

        public string BackgroundImage { get; }

        public bool IsNew { get; }
    }
}