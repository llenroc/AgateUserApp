using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Agate.Business.ViewModels.Main
{
    public class MenuItem
    {
        public const string ArrowRight = "\ue315";

        public MenuItem(string name, Type viewModelType, string backgroundImage, string icon = ArrowRight,
            bool isNew = false,
            bool justNotifyNavigateIntent = false,
            Action<INavigation> customNavigation = null
        )
        {
            Name = name;
            ViewModelType = viewModelType;
            Icon = icon;
            BackgroundImage = backgroundImage;
            IsNew = isNew;
        }

        public string Name { get; }

        public Type ViewModelType { get; }

        public string Icon { get; }

        public string BackgroundImage { get; }

        public Type PageType { get; }

        public bool IsNew { get; }
    }
}