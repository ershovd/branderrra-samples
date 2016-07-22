using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Branderra
{
	public partial class UsersListView : ContentPage
	{
		public UsersListView()
		{
			this.BindingContext = App.Locator.GetViewModel<UserListViewModel>();
			InitializeComponent();
		}

		protected override bool OnBackButtonPressed()
		{
			App.NavigationService.GoBack();
			return true;
		}
	}
}

