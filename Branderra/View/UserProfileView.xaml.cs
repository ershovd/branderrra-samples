using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Branderra
{
	public partial class UserProfileView : ContentPage
	{
		public UserProfileView()
		{
			this.BindingContext = App.Locator.GetViewModel<UserProfileViewModel>();
			InitializeComponent();

			mainFeedlst.ItemTapped += MainFeedlst_ItemTapped;
		}

		void MainFeedlst_ItemTapped (object sender, ItemTappedEventArgs e)
		{
			this.mainFeedlst.SelectedItem = null;
		}
	}
}

