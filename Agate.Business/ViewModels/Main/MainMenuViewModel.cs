using System.Collections.Generic;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class MainMenuViewModel : BaseViewModel
    {
        //private List<MenuCategory> menuCategories;
        //private List<MenuGroup> menusGroupedByCategory;
        private List<MenuItem> allMenuItems;

        public MainMenuViewModel()
        {
            LoadData();
        }

        //public List<MenuCategory> MenuCategories
        //{
        //    get { return menuCategories; }
        //    set
        //    {
        //        menuCategories = value;
        //        Raise(nameof(MenuCategories));
        //    }
        //}

        public List<MenuItem> AllMenuItems
        {
            get { return allMenuItems; }
            set
            {
                allMenuItems = value;
                Raise(nameof(AllMenuItems));
            }
        }

        //public List<MenuGroup> MenusGroupedByCategory
        //{
        //    get { return menusGroupedByCategory; }
        //    set
        //    {
        //        menusGroupedByCategory = value;
        //        Raise(nameof(MenusGroupedByCategory));
        //    }
        //}

        private void LoadData()
        {
            //MenuCategories = SamplesDefinition.SamplesCategoryList;
            AllMenuItems = new List<MenuItem>(new []{
                new MenuItem("Manage Assets", typeof(object), "#921243", "\ue90f"),
                new MenuItem("Manage Cards", typeof(object), "#921243", "\ue870"),
                new MenuItem("Settings", typeof(object), "#921243", "\ue90f"),
                new MenuItem("Tools", typeof(object), "#921243", "\ue8b8"),
                new MenuItem("Help Center", typeof(object), "#921243", "\ue887"),
                new MenuItem("Feedback", typeof(object), "#921243", "\ue0ca"),

            });
            //MenusGroupedByCategory = SamplesDefinition.SamplesGroupedByCategory;
        }
    }
}