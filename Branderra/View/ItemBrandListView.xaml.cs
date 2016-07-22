using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Branderra
{
	public partial class ItemBrandListView : ContentPage
	{
		public ItemBrandListView()
		{
			this.BindingContext = App.Locator.GetViewModel<ItemBrandListViewModel>();
			InitializeComponent();
		}

		protected override bool OnBackButtonPressed()
		{
			App.NavigationService.GoBack();
			return true;
		}
	}
}

