using System;
using Xamarin.Forms;

namespace Branderra
{
	public class UserPostInfoViewCell : ViewCell
	{
		public UserPostInfoViewCell()
		{
			var titleLbl = new Label() {
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalTextAlignment = TextAlignment.Start,
				LineBreakMode = LineBreakMode.NoWrap,
				TextColor = Constants.ColorBlue,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
			};

			titleLbl.SetBinding(Label.TextProperty, "Title");

			var lblDetail = new Label() {
				HorizontalOptions = LayoutOptions.End,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalTextAlignment = TextAlignment.End,
				LineBreakMode = LineBreakMode.WordWrap,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
			};

			lblDetail.SetBinding(Label.TextProperty, "Detail");
				
			View = new StackLayout() {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Transparent,
				Spacing = 2,
				Padding = 5,
				Children = { titleLbl, lblDetail }
			};

		}

		public static readonly BindableProperty TitleProperty =
			BindableProperty.Create ("Title", typeof(string), typeof(UserPostInfoViewCell), "");

		public string Title {
			get { return (string)GetValue (TitleProperty); }
			set { SetValue (TitleProperty, value); }
		}

		public static readonly BindableProperty DetailProperty =
			BindableProperty.Create ("Detail", typeof(string), typeof(UserPostInfoViewCell), "");

		public string Detail {
			get { return (string)GetValue (DetailProperty); }
			set { SetValue (DetailProperty, value); }
		}
	}
}

