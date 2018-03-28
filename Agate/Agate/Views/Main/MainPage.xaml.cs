using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triplezerooo.XMVVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agate.Views.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MasterDetailPage, IView, INavigationView
	{
	    private MainMenuPage mainMenuPage;

	    public MainPage()
	    {
	        InitializeComponent();

            // Empty pages are initially set to get optimal launch experience
            Master = new ContentPage { Title = "Agate User's App" };
            Detail = NavigationPageHelper.Create(new ContentPage());
	    }

        protected override async void OnAppearing()
	    {
	        base.OnAppearing();

	        await NavigationService.BeginInvokeOnMainThreadAsync(InitializeMasterDetail);
	    }

	    protected override void OnDisappearing()
	    {
	        base.OnDisappearing();
	    }

	    private void InitializeMasterDetail()
	    {
	        mainMenuPage = new MainMenuPage();
	        mainMenuPage.ListView.ItemSelected += MenuOnItemSelected;
	        Master = mainMenuPage;
	    }

	    private void MenuOnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        if (e.SelectedItem is MenuItem sample)
	        {
	            //await sample.NavigateToSample(navigation);

	            mainMenuPage.ListView.SelectedItem = null;
	        }
        }

        private void LaunchSampleInDetail(Page page, bool animated)
	    {
	        Detail = NavigationPageHelper.Create(page);
	        IsPresented = false;
	    }

	    public async Task SetCurrentPage(Page page)
	    {
	        Detail = NavigationPageHelper.Create(page);
	        IsPresented = false;
	    }

	    public async Task Push(Page page)
	    {
	        if (!(Detail is NavigationPage navigationPage))
	            return;
	        await navigationPage.PushAsync(page);
	    }
    }

    public static class NavigationPageHelper
    {
        public static NavigationPage Create(Page page)
        {
            return new NavigationPage(page) { BarTextColor = Color.White };
        }
    }
}