using System;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;

namespace Branderra
{
	public class SearchBarViewModel : ListBaseViewModel<ItemCategory>
	{
		public SearchBarViewModel(IServerAPIProvider service, INavigationService navigationService) : base(service, navigationService)
		{
			Title = "Поиск";
		}

		public override IEnumerable<ItemCategory> GetItems()
		{
			return service.GetAllCategories();
			//return TestAPI.GetItemsBrand();
		}

		public override void Navigate()
		{
			// TODO: proper navigation to serched item
			App.NavigationService.GoBack();
		}

		private string searchText;
		public string SearchText
		{
			get 
			{
				return searchText;
			}
			set 
			{
				if (searchText != value)
				{
					searchText = value;
					RaisePropertyChanged();
				}
			}
		}

		public RelayCommand SearchCommand
		{
			get { return new RelayCommand(SearchCommandInternal); }
		}

		private void SearchCommandInternal()
		{
			// TODO: implement search
		}
	}
}

