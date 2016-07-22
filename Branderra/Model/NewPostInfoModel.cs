using System;
using SQLite;

namespace Branderra
{
	/// <summary>
	/// Model for the new post added by user
	/// </summary>
	[Table("NewPostInfoModel")]
	public class NewPostInfoModel : IObjectId
	{
		#region GuidID

		[PrimaryKey]
		public Guid Id { get; set; }
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != typeof(NewPostInfoModel))
				return false;
			NewPostInfoModel other = (NewPostInfoModel)obj;
			return Id == other.Id;
		}

		public override int GetHashCode()
		{
			unchecked {
				return (Id != null ? Id.GetHashCode() : 0);
			}
		}

		#endregion

		public string Description {	get; set; }
		public string Category { get; set; }
		public string Brand { get; set; }
		public int Rating { get; set; }
		public byte[] ImageData { get; set; }
	}
}

