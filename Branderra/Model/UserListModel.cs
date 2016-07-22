using System;
using SQLite;

namespace Branderra
{
	/// <summary>
	/// Model for user name and image
	/// </summary>
	[Table("UserListModel")]
	public class UserListModel : IObjectId
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
			if (obj.GetType() != typeof(UserListModel))
				return false;
			UserListModel other = (UserListModel)obj;
			return Id == other.Id;
		}
		

		public override int GetHashCode()
		{
			unchecked {
				return (Id != null ? Id.GetHashCode() : 0);
			}
		}		
		#endregion

		public string Title { get; set; }
		public string ImageFilename { get; set;	}
		public override string ToString()
		{
			return string.Format("{0}", Title);
		}
		
	}
}

