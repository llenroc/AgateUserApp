using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agate.Infrastructure;
using Triplezerooo.XMVVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agate.Views.User
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SetPinPage : ContentPage, IView
	{
		public SetPinPage ()
		{
			InitializeComponent ();

            FormHelpers.ChainEntries(Pin1Entry,Pin2Entry);
		}
	}
}