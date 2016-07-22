using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;

namespace Branderra
{
	public class ItemBrandListViewModel : ListBaseViewModel<ItemBrandType>
	{
		public ItemBrandListViewModel(IServerAPIProvider service, INavigationService navigationService) : base(service, navigationService, true)
		{
			Title = "Бренды";
			Icon = "icon.png";

			RegisterMessage<ItemBrandMessage>(f => {
				ItemBrand = f.ItemBrand;
				base.Init();
			});
		}
		public override IEnumerable<ItemBrandType> GetItems()
		{
			return service.GetBrandsByCategoryAndBrandId(ItemBrand.CategoryId, ItemBrand.Id);
		}

		public ItemBrand ItemBrand 
		{
			get; set;
		}

		public override void Navigate()
		{
			// no navigate
		}
		
	}
}

