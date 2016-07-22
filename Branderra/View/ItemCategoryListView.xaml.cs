using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Branderra
{
	public partial class ItemCategoryListView : ContentPage
	{
		public ItemCategoryListView()
		{
			this.BindingContext = App.Locator.GetViewModel<ItemCategoryListViewModel>();
			InitializeComponent();
		}
	}
}

