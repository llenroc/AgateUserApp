using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agate.Business.ViewModels.User;
using Agate.Infrastructure;
using EntryCustomReturn.Forms.Plugin.Abstractions;
using Triplezerooo.XMVVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agate
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUpPage_Merchant : ContentPage, IView
	{
	    public SignUpPage_Merchant()
	    {
	        InitializeComponent();
	        NavigationPage.SetHasNavigationBar(this, false);

	        FormHelpers.ChainEntries(BusinessNameEntry, CountryPicker, MobileNumberEntry, EmailEntry);	        
        }
	}
}