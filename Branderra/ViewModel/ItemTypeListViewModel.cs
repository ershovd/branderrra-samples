using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;

namespace Branderra
{
	public class ItemTypeListViewModel : ListBaseViewModel<ItemBrand>
	{		
		public ItemTypeListViewModel(IServerAPIProvider service, INavigationService navigationService) : base(service, navigationService, true)
		{
			Title = "Типы";
			Icon = "icon.png";

			RegisterMessage<ItemCategoryMessage>(f => {
				ItemCategory = f.ItemCategory;
				base.Init();
			});
		}

		public override void Navigate()
		{
			// TODO: get with selected
			navigationService.NavigateTo(App.ItemBrandListView);

			SendMessage(new ItemBrandMessage(ItemSelected));
		}

		public ItemCategory ItemCategory 
		{
			get; set;
		}

		public override IEnumerable<ItemBrand> GetItems()
		{
			return service.GetBrandsByCategoryId(ItemCategory.Id);
		}		
	}

}

