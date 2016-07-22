using System;
using SQLite;

namespace Branderra
{
	[Table("ItemBrandModel")]
	public class ItemBrandModel : IObjectId
	{		
		#region GuidID

		[PrimaryKey]
		public Guid Id { get; set; }

		public bool Equals(ItemBrandModel other)
		{			
			return Id == other.Id;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != typeof(ItemBrandModel))
				return false;

			return Equals((ItemBrandModel)obj);
		}

		public override int GetHashCode()
		{
			unchecked 
			{	
				return (Id != null ? Id.GetHashCode() : 0);	
			}
		}
		#endregion

		public string Title { get; set; }
		public string ImageFilename { get; set; }
		public int Rating { get; set; }
		public Guid BrandTypeId { get; set; }
		public override string ToString()
		{
			return string.Format("{0} Stars={1}", Title, Rating);
		}		
	}
		
}

