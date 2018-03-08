using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using UXDivers.Artina.Shared;
using System.Collections.Generic;

namespace Agate
{
	public enum Theme
	{
		Light,
		Dark,
		Enterprise,
		Custom
	}

	public static class Settings
	{
		public static void SetTheme(Theme theme)
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				switch (theme)
				{
					case Theme.Dark:
						Application.Current.Resources.MergedWith = typeof(GrialDarkTheme);
						break;
					case Theme.Enterprise:
						Application.Current.Resources.MergedWith = typeof(GrialEnterpriseTheme);
						break;
					case Theme.Light:
						Application.Current.Resources.MergedWith = typeof(GrialLightTheme);
						break;
					default:
						Application.Current.Resources.MergedWith = typeof(MyAppTheme);
						break;
				}
			});
		}
	}
}
