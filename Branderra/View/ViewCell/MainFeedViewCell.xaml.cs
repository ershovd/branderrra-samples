using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Branderra
{
	public partial class MainFeedViewCell : ViewCell
	{
		public MainFeedViewCell() 
		{
			InitializeComponent();
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			var context = BindingContext as UserFeedItemModel;
			if (context != null)
			{				
				//this.starBehaviourUserRate.GroupName = context.UserName;
				//this.starBehaviourUserRate.IsReadOnly = true;
				this.starBehaviourUserRate.Rating = context.Rating;
			}
		}

		private void AddTapGesture(View view, EventHandler handler)
		{
			var tapGesture = new TapGestureRecognizer();
			tapGesture.Tapped += handler;
			view.GestureRecognizers.Add(tapGesture);
		}

		#region Commands

		public static readonly BindableProperty ProfileClickedCommandProperty =
			BindableProperty.Create ("ProfileClickedCommand", typeof(RelayCommand), typeof(MainFeedViewCell), null);

		public RelayCommand ProfileClickedCommand {
			get { return (RelayCommand)GetValue(ProfileClickedCommandProperty); }
			set { SetValue(ProfileClickedCommandProperty, value); }
		}

		public static readonly BindableProperty CommentsClickCommandProperty =
			BindableProperty.Create ("CommentsClickCommand", typeof(RelayCommand), typeof(MainFeedViewCell), null);

		public RelayCommand CommentsClickCommand {
			get { return (RelayCommand)GetValue(CommentsClickCommandProperty); }
			set { SetValue(CommentsClickCommandProperty, value); }
		}

		public static readonly BindableProperty BrandClickedCommandProperty =
			BindableProperty.Create ("BrandClickedCommand", typeof(RelayCommand), typeof(MainFeedViewCell), null);

		public RelayCommand BrandClickedCommand {
			get { return (RelayCommand)GetValue(BrandClickedCommandProperty); }
			set { SetValue(BrandClickedCommandProperty, value); }
		}

		public static readonly BindableProperty TypeClickedCommandProperty =
			BindableProperty.Create ("TypeClickedCommand", typeof(RelayCommand), typeof(MainFeedViewCell), null);

		public RelayCommand TypeClickedCommand {
			get { return (RelayCommand)GetValue(TypeClickedCommandProperty); }
			set { SetValue(TypeClickedCommandProperty, value); }
		}

		public static readonly BindableProperty CategoryClickedCommandProperty =
			BindableProperty.Create ("CategoryClickedCommand", typeof(RelayCommand), typeof(MainFeedViewCell), null);

		public RelayCommand CategoryClickedCommand {
			get { return (RelayCommand)GetValue(CategoryClickedCommandProperty); }
			set { SetValue(CategoryClickedCommandProperty, value); }
		}

		public static readonly BindableProperty PublishPostCommandProperty =
			BindableProperty.Create ("PublishPostCommand", typeof (RelayCommand), typeof (MainFeedViewCell), null);

		public RelayCommand PublishPostCommand {
			get { return (RelayCommand)GetValue (PublishPostCommandProperty); }
			set { SetValue (PublishPostCommandProperty, value); }
		}

		#endregion

		#region Simple get & set properties

		public static readonly BindableProperty UserNameProperty =
			BindableProperty.Create ("UserName", typeof(string), typeof(MainFeedViewCell), "");
		
		public string UserName {
			get { return (string)GetValue(UserNameProperty); }
			set { SetValue(UserNameProperty, value); }
		}

		public static readonly BindableProperty ItemCategoryInfoProperty =
			BindableProperty.Create ("ItemCategoryInfo", typeof(string), typeof(MainFeedViewCell), "");

		public string ItemCategoryInfo {
			get { return (string)GetValue(ItemCategoryInfoProperty); }
			set { SetValue(ItemCategoryInfoProperty, value); }
		}

		public static readonly BindableProperty ItemTypeInfoProperty =
			BindableProperty.Create ("ItemTypeInfo", typeof(string), typeof(MainFeedViewCell), "");

		public string ItemTypeInfo {
			get { return (string)GetValue(ItemTypeInfoProperty); }
			set { SetValue(ItemTypeInfoProperty, value); }
		}

		public static readonly BindableProperty ItemBrandInfoProperty =
			BindableProperty.Create ("ItemBrandInfo", typeof(string), typeof(MainFeedViewCell), "");

		public string ItemBrandInfo {
			get { return (string)GetValue(ItemBrandInfoProperty); }
			set { SetValue(ItemBrandInfoProperty, value); }
		}

		public static readonly BindableProperty UserAvatarSourceProperty =
			BindableProperty.Create ("UserAvatarSource", typeof(string), typeof(MainFeedViewCell), "");

		public string UserAvatarSource {
			get { return (string)GetValue(UserAvatarSourceProperty); }
			set { SetValue(UserAvatarSourceProperty, value); }
		}

		public static readonly BindableProperty FeedPhotoSourceProperty =
			BindableProperty.Create ("FeedPhotoSource", typeof(string), typeof(MainFeedViewCell), "");

		public string FeedPhotoSource {
			get { return (string)GetValue(FeedPhotoSourceProperty); }
			set { SetValue(FeedPhotoSourceProperty, value); }
		}

		public static readonly BindableProperty TimeOfPostProperty =
			BindableProperty.Create ("TimeOfPost", typeof(DateTime), typeof(MainFeedViewCell), DateTime.Now);

		public DateTime TimeOfPost {
			get { return (DateTime)GetValue(TimeOfPostProperty); }
			set { SetValue(TimeOfPostProperty, value); }
		}

		public static readonly BindableProperty RatingProperty =
			BindableProperty.Create ("Rating", typeof(int), typeof(MainFeedViewCell), default(int));

		public int Rating {
			get { return (int)GetValue(RatingProperty); }
			set { SetValue(RatingProperty, value); }
		}

		public static readonly BindableProperty PostDescriptionProperty =
			BindableProperty.Create ("PostDescription", typeof(string), typeof(MainFeedViewCell), "");

		public string PostDescription {
			get { return (string)GetValue(PostDescriptionProperty); }
			set { SetValue(PostDescriptionProperty, value); }
		}

		#endregion
	}
}

