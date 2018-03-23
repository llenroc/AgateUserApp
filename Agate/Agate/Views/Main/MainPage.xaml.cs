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
	public partial class MainPage : MasterDetailPage, IView
	{
	    private MainMenuPage mainMenuPage;

	    public MainPage()	        
	    {
	        InitializeComponent();

            // Empty pages are initially set to get optimal launch experience
            Master = new ContentPage { Title = "Agate User's App" };
            Detail = NavigationPageHelper.Create(new ContentPage());
	    }

        public async void OnSettingsTapped(object sender, EventArgs e)
	    {
	        //await Navigation.PushAsync(new SettingsPage());
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
	        Detail = NavigationPageHelper.Create(new HomePage());
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
    }

    public static class NavigationPageHelper
    {
        public static NavigationPage Create(Page page)
        {
            return new NavigationPage(page) { BarTextColor = Color.White };
        }
    }
}