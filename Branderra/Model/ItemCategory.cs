using System;
using SQLite;

namespace Branderra
{

	[Table("ItemCategory")]
	public class ItemCategory : IObjectId
	{
		#region GuidID

		[PrimaryKey]
		public Guid Id { get; set; }

		public bool Equals(ItemCategory other)
		{
			return Id == other.Id;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != typeof(ItemCategory))
				return false;

			return Equals((ItemCategory)obj);
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
		
		public override string ToString()
		{
			return string.Format("{0}", Title);
		}
	}

}
