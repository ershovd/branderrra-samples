using System;
using SQLite;

namespace Branderra
{
	/// <summary>
	/// Model for items of the user comments
	/// </summary>
	[Table("UserCommentModel")]
	public class UserCommentModel : IObjectId
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
			if (obj.GetType() != typeof(UserCommentModel))
				return false;
			UserCommentModel other = (UserCommentModel)obj;
			return Id == other.Id;
		}	

		public override int GetHashCode()
		{
			unchecked {
				return (Id != null ? Id.GetHashCode() : 0);
			}
		}

		#endregion

		public string ImageFilename { get; set;	}
		public string Title { get; set;	}
		public string Detail { get; set; }
		public string Time { get; set; }

		public override string ToString()
		{
			return string.Format("{0}: {1} [{2}]", Title, Detail, Time);
		}
		
	}
}

