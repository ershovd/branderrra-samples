using System;
using GalaSoft.MvvmLight.Command;
using SQLite;
using XLabs.Ioc;

namespace Branderra
{
	/// <summary>
	/// Model for user feed items in mai tab
	/// </summary>
	[Table("UserFeedItemModel")]
	public class UserFeedItemModel : IObjectId
	{
		#region GuidID

		[PrimaryKey]
		public Guid Id { get; set; }

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != typeof(UserFeedItemModel))
				return false;
			UserFeedItemModel other = (UserFeedItemModel)obj;
			return Id == other.Id;
		}
		

		public override int GetHashCode()
		{
			unchecked {
				return (Id != null ? Id.GetHashCode() : 0);
			}
		}

		#endregion

		public string UserName { get; set; }
		public string UserAvatarSource { get; set; }
		public DateTime TimeOfPost { get; set; }
		public string FeedPhotoSource { get; set; }
		public string ItemCategoryInfo { get; set; }
		public string ItemTypeInfo { get; set; }
		public string ItemBrandInfo { get; set; }
		public int Rating { get; set; }
		public string PostDescription { get; set; }

		public override string ToString()
		{
			return string.Format("{0} [{1}] {2}--{3}--{4}", UserName, TimeOfPost, ItemCategoryInfo, ItemTypeInfo, ItemBrandInfo);
		}
		

		// TODO: move commands out of model
		#region Commands

		[Ignore]
		public RelayCommand PublishPostCommand
		{
			get { return new RelayCommand (PublisPostInternal);}
		}

		void PublisPostInternal ()
		{
			var auth = Resolver.Resolve<IAuthenticator> ();
			auth.PublishPost (this);
		}

		[Ignore]
		public RelayCommand ProfileClickedCommand
		{
			get { return new RelayCommand(ProfileClicked); }
		}

		private void ProfileClicked()
		{
			// TODO: fix issue with commandParameter
			App.NavigationService.NavigateTo(App.ProfileFeedNewsView);
		}

		[Ignore]
		public RelayCommand CommentsClickCommand
		{
			get { return new RelayCommand(CommentsClick); }
		}

		private void CommentsClick()
		{
			// TODO: fix issue with commandParameter
			App.NavigationService.NavigateTo(App.CommentsListView);
		}

		[Ignore]
		public RelayCommand CategoryClickedCommand
		{
			get { return new RelayCommand(CategoryClicked); }
		}

		private void CategoryClicked()
		{
			// TODO: fix issue with commandParameter
			App.NavigationService.NavigateTo(App.ItemCategoryListView);
		}

		[Ignore]
		public RelayCommand TypeClickedCommand
		{
			get { return new RelayCommand(TypeClicked); }
		}

		private void TypeClicked()
		{
			// TODO: fix issue with commandParameter
			App.NavigationService.NavigateTo(App.ItemBrandListView);
		}

		[Ignore]
		public RelayCommand BrandClickedCommand
		{
			get { return new RelayCommand(BrandClicked); }
		}

		private void BrandClicked()
		{
			// TODO: fix issue with commandParameter
			App.NavigationService.NavigateTo(App.ItemTypeListView, null);
		}

		#endregion
	}
}

