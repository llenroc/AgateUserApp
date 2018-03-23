using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agate.Business.ViewModels.Main;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MenuItem = Agate.Business.ViewModels.Main.MenuItem;

namespace Agate.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPage : ContentPage
    {
        public ListView ListView;

        public MainMenuPage()
        {
            InitializeComponent();
            
            BindingContext = new MainMenuViewModel();
            ListView = MenuListView;
        }
    }
}