﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triplezerooo.XMVVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agate.Views.User
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PinSignInPage : ContentPage, IView
	{
		public PinSignInPage ()
		{
			InitializeComponent ();
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();

	        PinEntry.Focus();
	    }
	}
}