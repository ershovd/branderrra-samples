using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Branderra
{
	public partial class SearchBarView : ContentPage
	{
		public SearchBarView()
		{
			this.BindingContext = App.Locator.GetViewModel<SearchBarViewModel>();
			InitializeComponent();
			this.barMainSearch.SearchButtonPressed += BarMainSearch_SearchButtonPressed;

			this.itemsSearchList.ItemTapped += BarMainSearch_SearchButtonPressed;
		}

		void BarMainSearch_SearchButtonPressed (object sender, EventArgs e)
		{
			this.itemsSearchList.SelectedItem = null;
			this.Navigation.PopAsync();
		}
	}
}

