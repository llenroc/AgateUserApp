using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agate.Views.Merchant
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReceivePaymentPage : ContentPage
	{
		public ReceivePaymentPage ()
		{
			InitializeComponent ();

		    BarcodeImageView.BarcodeOptions.Margin = 4;
		    BarcodeImageView.BarcodeOptions.Width = 320;
		    BarcodeImageView.BarcodeOptions.Height = 320;
        }
    }
}