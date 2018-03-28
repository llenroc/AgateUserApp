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
	public partial class AssetHomePage : TabbedPage, IView
	{
		public AssetHomePage ()
		{
			InitializeComponent ();
		}
	}
}