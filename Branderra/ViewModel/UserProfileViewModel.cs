using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;

namespace Branderra
{
	public class UserProfileViewModel : ListBaseViewModel<UserFeedItemModel>
	{
		public UserProfileViewModel(IServerAPIProvider service, GalaSoft.MvvmLight.Views.INavigationService navigationService) : base(service, navigationService)
		{
			Title = "Лента";
			Icon = "feed.png";
		}		
		
		public override IEnumerable<UserFeedItemModel> GetItems()
		{			
			var api = SimpleIoc.Default.GetInstance<IServerAPIProvider>();

			return api.GetAllFeedItems();
		}
		public override void Navigate()
		{
			
		}		


	}
}

