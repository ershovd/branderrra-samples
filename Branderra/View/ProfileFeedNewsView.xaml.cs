using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Branderra
{
	public partial class ProfileFeedNewsView : ContentPage
	{
		public ProfileFeedNewsView()
		{
			this.BindingContext = App.Locator.GetViewModel<ProfileFeedNewsViewModel>();
			InitializeComponent();
		}
	}
}

