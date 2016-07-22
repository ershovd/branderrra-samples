using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Branderra
{
	public partial class ItemBrandListViewCell : ViewCell
	{
		public ItemBrandListViewCell ()
		{
			InitializeComponent ();
		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();

			var context = BindingContext as ItemBrand;
			if (context != null) {
				this.starBehaviourUserRate.Rating = context.Rating;
			}

			// TODO: fix this haclk with 2 contexts
			var context1 = BindingContext as ItemBrandType;
			if (context1 != null) {
				this.starBehaviourUserRate.Rating = context1.Rating;
			}

		}

		public static readonly BindableProperty TitleProperty =
			BindableProperty.Create ("Title", typeof (string), typeof (ItemBrandListViewCell), "");

		public string Title {
			get { return (string)GetValue (TitleProperty); }
			set { SetValue (TitleProperty, value); }
		}

		public static readonly BindableProperty ImageFilenameProperty =
			BindableProperty.Create ("ImageFilename", typeof (string), typeof (ItemBrandListViewCell), "");

		public string ImageFilename {
			get { return (string)GetValue (ImageFilenameProperty); }
			set { SetValue (ImageFilenameProperty, value); }
		}

		public static readonly BindableProperty RatingProperty =
			BindableProperty.Create ("Rating", typeof (int), typeof (MainFeedViewCell), default (int), BindingMode.TwoWay);

		public int Rating {
			get { return (int)GetValue (RatingProperty); }
			set {
				SetValue (RatingProperty, value);
				OnPropertyChanged ();
			}
		}
	}
}

