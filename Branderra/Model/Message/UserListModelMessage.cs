using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;

namespace Branderra
{
	public class UserListModelMessage
	{
		public UserListModelMessage(UserListModel userListModel)
		{
			this.UserListModel = userListModel;
		}
		
		public UserListModel UserListModel 
		{
			get;
			set;
		}
	}

}
