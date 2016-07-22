using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Branderra.IOS;
using UIKit;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(TabbedPageCustom))]
namespace Branderra.IOS
{
	public class TabbedPageCustom : TabbedRenderer 
	{
		public TabbedPageCustom ()
		{
			TabBar.TintColor = UIColor.Black;
			//TabBar.BarTintColor = UIColor.Blue;
			//TabBar.BackgroundColor = UIColor.Green;
		}
	}
}

