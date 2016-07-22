using System;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Abstractions;

namespace Branderra
{
	public class UsersListViewCell : ViewCell
	{
		public UsersListViewCell()
		{
			var image = new CircleImage()
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				HeightRequest = 100,
				WidthRequest = 100,
			};
			image.SetBinding(Image.SourceProperty, "ImageFilename");

			var label = new Label()
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Large,typeof(Label)),
			};
			label.SetBinding(Label.TextProperty, "Title");

			View = new StackLayout() {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.White,
				HeightRequest = 110,
				Spacing = 10,
				Padding = 5,
				Children = { image, label }
			};
		}

		public static readonly BindableProperty TitleProperty =
			BindableProperty.Create ("Title", typeof(string), typeof(UsersListViewCell), "");

		public string Title {
			get { return (string)GetValue (TitleProperty); }
			set { SetValue (TitleProperty, value); }
		}

		public static readonly BindableProperty ImageFilenameProperty =
			BindableProperty.Create ("ImageFilename", typeof(string), typeof(UsersListViewCell), "");

		public string ImageFilename {
			get { return (string)GetValue (ImageFilenameProperty); }
			set { SetValue (ImageFilenameProperty, value); }
		}
	}
}

