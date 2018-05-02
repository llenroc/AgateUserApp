using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agate.Views.Common
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class KeyPad : ContentView
	{
		public KeyPad ()
		{
			InitializeComponent ();
		}

	    public static readonly BindableProperty AmountProperty =
	        BindableProperty.Create(nameof(Amount), typeof(string), typeof(PinView), "0", BindingMode.TwoWay, null, AmountChanged);

	    public string Amount
	    {
	        get => (string)GetValue(AmountProperty);
	        set => SetValue(AmountProperty, value);
	    }

	    private static void AmountChanged(BindableObject bindable, object oldValue, object newValue)
	    {
	    }


        private void NumberButton_OnClicked(object sender, EventArgs e)
        {
            var button = (Button) sender;
            if(Amount == "0")
            {
                Amount = button.Text;
            }
            else
            {
                Amount = Amount + button.Text;
            }
        }

	    private void BackButton_OnClicked(object sender, EventArgs e)
	    {
            if(Amount.Length == 0)
                return;
	        Amount = Amount.Substring(0, Amount.Length - 1);
	    }

	    private void DotButton_OnClicked(object sender, EventArgs e)
	    {
	        Amount = Amount + ".";
	    }
    }
}