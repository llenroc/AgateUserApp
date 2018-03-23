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
	    public MainPage()	        
	    {
	        InitializeComponent();

            // Empty pages are initially set to get optimal launch experience
            //Master = new ContentPage { Title = "Agate User's App" };
            //Detail = NavigationPageHelper.Create(new ContentPage());
	        Master = new MainMenuPage(new NavigationService(Navigation, LaunchSampleInDetail));
	        Detail = NavigationPageHelper.Create(new HomePage());
	    }

        public async void OnSettingsTapped(object sender, EventArgs e)
	    {
	        //await Navigation.PushAsync(new SettingsPage());
	    }

	    protected async override void OnAppearing()
	    {
	        base.OnAppearing();

            //SampleCoordinator.SampleSelected += SampleCoordinator_SampleSelected;

            //if (_showWelcome)
            //{
            //    _showWelcome = false;

            //    await Navigation.PushModalAsync(NavigationPageHelper.Create(new WelcomePage()));

            //    await Task.Delay(500)
            //        .ContinueWith(t => NavigationService.BeginInvokeOnMainThreadAsync(InitializeMasterDetail));
	        //}

	        //await NavigationService.BeginInvokeOnMainThreadAsync(InitializeMasterDetail);
	    }

	    protected override void OnDisappearing()
	    {
	        base.OnDisappearing();

	        //SampleCoordinator.SampleSelected -= SampleCoordinator_SampleSelected;
	    }

	    private void InitializeMasterDetail()
	    {
	        Master = new MainMenuPage(new NavigationService(Navigation, LaunchSampleInDetail));
	        Detail = NavigationPageHelper.Create(new HomePage());
	    }

	    private void LaunchSampleInDetail(Page page, bool animated)
	    {
	        Detail = NavigationPageHelper.Create(page);
	        IsPresented = false;
	    }

	    //private void SampleCoordinator_SampleSelected(object sender, SampleEventArgs e)
	    //{
	    //    if (e.Sample.PageType == typeof(RootPage))
	    //    {
	    //        IsPresented = true;
	    //    }
	    //}

    }

    public static class NavigationPageHelper
    {
        public static NavigationPage Create(Page page)
        {
            return new NavigationPage(page) { BarTextColor = Color.White };
        }
    }
}