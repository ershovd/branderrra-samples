using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace Branderra
{
	public class ItemCategoryListViewModel : ListBaseViewModel<ItemCategory>
	{
		public ItemCategoryListViewModel(IServerAPIProvider service, INavigationService navigationService) : base(service, navigationService)
		{
			Title = "Бренды";
			Icon = "like.png";
		}

		public override void Navigate()
		{
			
		}

		public override IEnumerable<ItemCategory> GetItems()
		{
			return service.GetAllCategories();
		}

		public RelayCommand<object> NavigateToCategory
		{
			get { return new RelayCommand<object>(NavigateToBrands); }
		}

		private void NavigateToBrands(object parameter)
		{
			// TODO: fix issue with commandParameter
			var item = Items.FirstOrDefault();

			navigationService.NavigateTo(App.ItemTypeListView);

			Messenger.Default.Send<ItemCategoryMessage>(new ItemCategoryMessage(item));
		}
	}
}
