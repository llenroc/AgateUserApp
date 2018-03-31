using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agate.Infrastructure;
using Triplezerooo.XMVVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agate.Views.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditAddressPage : ContentPage, IView
	{
		public EditAddressPage ()
		{
			InitializeComponent ();

            FormHelpers.ChainEntries(FirstNameEntry, LastNameEntry, AddressLine1Entry,AddressLine2Entry, CityEntry, StateEntry, CountryEntry, PostCodeEntry);
		}
	}
}