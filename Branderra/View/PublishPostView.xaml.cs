using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Branderra
{
	public partial class PublishPostView : ContentPage
	{
		public PublishPostView()
		{
			this.BindingContext = App.Locator.GetViewModel<PublishPostViewModel>();
			InitializeComponent();
			FillPickerValues();
			this.starBehaviourUserRate.GroupName = "userGroupStar";
		}

		void Handle_CategoryIndexChanged (object sender, System.EventArgs e)
		{
			var context = BindingContext as PublishPostViewModel;
			if (context != null) 
			{
				this.pckBrand.IsVisible = false;
				this.pckTypes.SelectedIndex = -1;
				this.pckTypes.IsVisible = context.CategorySelectedIndex >= 0;

			}
		}

		void Handle_TypesIndexChanged (object sender, System.EventArgs e)
		{
			var context = BindingContext as PublishPostViewModel;
			if (context != null) 
			{
				this.pckBrand.IsVisible = context.TypesSelectedIndex >= 0;
				this.pckBrand.SelectedIndex = -1;
			}
		}

		void FillPickerValues()
		{
			var context = BindingContext as PublishPostViewModel;
			if (context != null) {
				FillPickerItems(this.pckBrand, context.BrandItems.ToList());
				FillPickerItems(this.pckCategory, context.CategoryItems.ToList());
				FillPickerItems (this.pckTypes, context.TypesItems.ToList ());
			}
		}

		private void FillPickerItems(Picker picker, List<string> items)
		{
			picker.Items.Clear();

			foreach (var item in items) 
			{
				if (!string.IsNullOrEmpty(item))
					picker.Items.Add(item);
			}
		}

	}
}

