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
	public partial class AssetHomePage : TabbedPage, IView
	{
		public AssetHomePage ()
		{
			InitializeComponent ();

		    BarcodeImageView.BarcodeOptions.Margin = 4;
		    BarcodeImageView.BarcodeOptions.Width = 320;
		    BarcodeImageView.BarcodeOptions.Height = 320;

            FormHelpers.ChainEntries(SendAmountEntry, ReceiverAddressEntry);
		}
	}
}