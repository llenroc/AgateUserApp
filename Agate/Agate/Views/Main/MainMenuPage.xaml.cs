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
        public MainMenuPage()
        {
            InitializeComponent();

            MenuListView.ItemSelected += MenuListView_ItemSelected;
        }

        private void MenuListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MenuListView.SelectedItem = null;
        }
    }
}