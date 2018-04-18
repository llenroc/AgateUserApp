using System.Collections.Generic;
using Triplezerooo.XMVVM;

namespace Agate.Business.ViewModels.Main
{
    public class MainMenuViewModel : BaseViewModel
    {
        private List<MenuItem> allMenuItems;

        public MainMenuViewModel()
        {
            AllMenuItems = new List<MenuItem>(new[]{
                new MenuItem("Manage Assets", typeof(object), "#921243", "\ue90f"),
                new MenuItem("Manage Cards", typeof(object), "#921243", "\ue870"),
                new MenuItem("Trader Bot", typeof(object), "#921243", "\ue80c"),
                new MenuItem("AI Engine", typeof(object), "#921243", "\ue906"),
                new MenuItem("Settings", typeof(object), "#921243", "\ue90f"),
                new MenuItem("Tools", typeof(object), "#921243", "\ue8b8"),
                new MenuItem("Help Center", typeof(object), "#921243", "\ue887"),
                new MenuItem("Feedback", typeof(object), "#921243", "\ue0ca"),
            });
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
    }
}