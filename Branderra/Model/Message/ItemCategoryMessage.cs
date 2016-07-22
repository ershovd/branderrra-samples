using System;

namespace Branderra
{
	public class ItemCategoryMessage
	{
		public ItemCategoryMessage(ItemCategory itemCategory)
		{
			this.ItemCategory = itemCategory;
		}		

		public ItemCategory ItemCategory 
		{
			get;
			set;
		}
	}
}

