using System;
using SQLite;

namespace Branderra
{

	[Table("ItemBrandType")]
	public class ItemBrandType : IObjectId
	{
		#region GuidID

		[PrimaryKey]
		public Guid Id { get; set; }

		public bool Equals(ItemBrandType other)
		{
			return Id == other.Id;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != typeof(ItemBrandType))
				return false;

			return Equals((ItemBrandType)obj);
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
		public Guid BrandId { get; set; }

		public override string ToString()
		{
			return string.Format("{0} Stars={1}", Title, Rating);
		}
	}

}
