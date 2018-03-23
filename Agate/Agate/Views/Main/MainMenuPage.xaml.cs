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
	    private readonly INavigation navigation;

	    public MainMenuPage()
	    {	        
	    }

	    public MainMenuPage(INavigation navigation)
	    {
	        InitializeComponent();

	        this.navigation = navigation;

	        BindingContext = new MainMenuViewModel();
	    }

        public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //if (sampleListView.SelectedItem is MenuItem sample)
            //{
            //    if (sample.PageType == typeof(HomePage))
            //    {
            //        await DisplayAlert("Hey", string.Format("You are already here, on sample {0}.", sample.Name), "OK");
            //    }
            //    else
            //    {
            //        await sample.NavigateToSample(navigation);
            //    }

            //    sampleListView.SelectedItem = null;
            //}
        }
    }
}