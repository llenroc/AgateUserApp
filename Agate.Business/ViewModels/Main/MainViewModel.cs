using System;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Triplezerooo.XMVVM;
using Xamarin.Forms;

namespace Agate.Business.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
    }

    //public class MenuCategory
    //{
    //    public int Id { get; set; }

    //    public string Name { get; set; }

    //    public Color BackgroundColor { get; set; }

    //    public String BackgroundImage { get; set; }

    //    public List<MenuItem> MenuItems { get; set; }

    //    public string Icon { get; set; }

    //    public int Badge { get; set; }
    //}

    //public class MenuGroup : List<MenuItem>
    //{
    //    public MenuGroup(string name)
    //    {
    //        Name = name;
    //    }

    //    public string Name { get; }
    //}

    public class MenuItem
    {
        public const string ArrowRight = "\ue315";

        private readonly string _name;
        private readonly bool _modal;
        private readonly string _icon;
        private readonly Type _pageType;
        private readonly string _backgroundImage;
        private readonly bool _justNotifyNavigateIntent;
        private readonly Action<INavigation> _customNavigation;
        private readonly bool _isNew;

        public MenuItem(
                string name,
                Type pageType,
                string backgroundImage,
                string icon = ArrowRight,
                bool modal = false,
                bool isNew = false,
                bool justNotifyNavigateIntent = false,
                Action<INavigation> customNavigation = null
            )
        {
            _name = name;
            _pageType = pageType;
            _icon = icon;
            _backgroundImage = backgroundImage;
            _modal = modal;
            _justNotifyNavigateIntent = justNotifyNavigateIntent;
            _customNavigation = customNavigation;
            _isNew = isNew;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Icon
        {
            get
            {
                return _icon;
            }
        }

        public string BackgroundImage
        {
            get
            {
                return _backgroundImage;
            }
        }

        public async Task NavigateToSample(INavigation navigation)
        {
            //SampleCoordinator.RaiseSampleSelected(this);

            //if (_justNotifyNavigateIntent)
            //{
            //    return;
            //}

            //if (_customNavigation != null)
            //{
            //    _customNavigation(navigation);
            //    return;
            //}

            //int popCount = 0;
            //int firstPageToPopIndex = 0;

            //if (_pageType == typeof(MainPage))
            //{
            //    // navigation.PopToRootAsync() does't work in old Android versions
            //    // and we need to go back to the top anyways
            //    popCount = navigation.NavigationStack.Count - 1;
            //}
            //else
            //{
            //    for (int i = navigation.NavigationStack.Count - 1; i >= 0; i--)
            //    {
            //        if (navigation.NavigationStack[i].GetType() == _pageType)
            //        {
            //            firstPageToPopIndex = i + 1;
            //            popCount = navigation.NavigationStack.Count - 1 - i;
            //            break;
            //        }
            //    }
            //}

            //if (popCount > 0)
            //{
            //    for (int i = 1; i < popCount; i++)
            //    {
            //        navigation.RemovePage(navigation.NavigationStack[firstPageToPopIndex]);
            //    }

            //    await navigation.PopAsync();

            //    return;
            //}

            //var page = CreateContentPage();

            //if (_modal)
            //{
            //    await navigation.PushModalAsync(NavigationPageHelper.Create(page));
            //}
            //else
            //{
            //    await navigation.PushAsync(page);
            //}
        }

        private Page CreateContentPage()
        {
            var page = Activator.CreateInstance(_pageType) as Page;

            return page;
        }

        public Type PageType
        {
            get
            {
                return _pageType;
            }
        }

        public bool IsNew
        {
            get
            {
                return _isNew;
            }
        }
    }
}
