using System;
using ImageCircle.Forms.Plugin.Abstractions;
using Xamarin.Forms;

namespace Branderra
{
	public class CommentListViewCell : ViewCell
	{
		public CommentListViewCell()
		{
			var image = new CircleImage()
			{
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Start,
				HeightRequest = 60,
				WidthRequest = 60,
			};
			image.SetBinding(Image.SourceProperty, "ImageFilename");

			var titleLabel = new Label()
			{ 
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Start,
				TextColor = Constants.ColorBlue,
			};				
			titleLabel.SetBinding(Label.TextProperty, "Title");

			var detailLabel = new Label()
			{ 
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.End,
				LineBreakMode = LineBreakMode.WordWrap,
				FontSize = Device.GetNamedSize(NamedSize.Small,typeof(Label)),
			};				
			detailLabel.SetBinding(Label.TextProperty, "Detail");

			var timeLabel = new Label()
			{ 
				HorizontalOptions = LayoutOptions.EndAndExpand,
				VerticalTextAlignment =  TextAlignment.Start,
				HorizontalTextAlignment = TextAlignment.Center,
				LineBreakMode = LineBreakMode.NoWrap,
				FontSize = Device.GetNamedSize(NamedSize.Micro,typeof(Label)),
			};				
			timeLabel.SetBinding(Label.TextProperty, "Time");

			var textstack = new StackLayout() {
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Fill,
				Padding = new Thickness(10, 0, 0, 0),
				Children = {titleLabel, detailLabel}
			};

			View = new StackLayout() {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 2,
				Padding = 5,
				Children = {image, textstack, timeLabel}
			};

		}

		public static readonly BindableProperty TitleProperty =
			BindableProperty.Create ("Title", typeof(string), typeof(CommentListViewCell), "");

		public string Title {
			get { return (string)GetValue (TitleProperty); }
			set { SetValue (TitleProperty, value); }
		}

		public static readonly BindableProperty ImageFilenameProperty =
			BindableProperty.Create ("ImageFilename", typeof(string), typeof(CommentListViewCell), "");

		public string ImageFilename {
			get { return (string)GetValue (ImageFilenameProperty); }
			set { SetValue (ImageFilenameProperty, value); }
		}

		public static readonly BindableProperty DetailProperty =
			BindableProperty.Create ("Detail", typeof(string), typeof(CommentListViewCell), "");

		public string Detail {
			get { return (string)GetValue (DetailProperty); }
			set { SetValue (DetailProperty, value); }
		}

		public static readonly BindableProperty TimeProperty =
			BindableProperty.Create ("Time", typeof(string), typeof(CommentListViewCell), "");

		public string Time {
			get { return (string)GetValue (TimeProperty); }
			set { SetValue (TimeProperty, value); }
		}
	}
}

