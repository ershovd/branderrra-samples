using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;

namespace Branderra
{
	public class UserListViewModel : ListBaseViewModel<UserListModel>
	{
		public UserListViewModel(IServerAPIProvider service, INavigationService navigationService) : base(service, navigationService)
		{
			Title = "Люди";
			Icon = "people.png";
		}

		public override IEnumerable<UserListModel> GetItems()
		{
			return service.GetAllUsers();
		}

		public override void Navigate()
		{
			navigationService.NavigateTo(App.ProfileFeedNewsView);

			SendMessage(new UserListModelMessage(ItemSelected));
		}
	}
}
