using System;
using GalaSoft.MvvmLight.Views;

namespace Branderra
{
	public class ProfileFeedNewsViewModel : BranderraViewModelBase
	{
		public ProfileFeedNewsViewModel(IServerAPIProvider service, INavigationService navigationService) : base(service, navigationService)
		{
			this.Title = "Профиль";

			RegisterMessage<UserListModelMessage>(f => {
				var selectedUser = f.UserListModel;	
			});
		}		
	}
}

