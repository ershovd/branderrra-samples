using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;

namespace Branderra
{
	public class ItemBrandMessage
	{
		public ItemBrandMessage(ItemBrand itemBrand)
		{
			this.ItemBrand = itemBrand;
		}
		
		public ItemBrand ItemBrand 
		{
			get;
			set;
		}
	}

}

