using System;
using SQLite;

namespace Branderra
{

	[Table("ItemBrand")]
	public class ItemBrand : IObjectId
	{
		#region GuidID

		[PrimaryKey]
		public Guid Id { get; set; }

		public bool Equals(ItemBrand other)
		{
			return Id == other.Id;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != typeof(ItemBrand))
				return false;

			return Equals((ItemBrand)obj);
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
		public Guid CategoryId { get; set; }

		public override string ToString()
		{
			return string.Format("{0} Stars={1}", Title, Rating);
		}
	}

}
