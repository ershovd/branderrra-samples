using System;
using Simple.OData.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Branderra
{
	public class BranderraServerAPIProvider : IServerAPIProvider
	{
		private IDatabase database;

		public BranderraServerAPIProvider(IDatabase database)
		{
			this.database = database;

			ClearDataBase();
			CreateTestData();
		}

		void ClearDataBase()
		{
			database.Clear<ItemBrandModel>();
			database.Clear<ItemBrandType>();
			database.Clear<ItemBrand>();
			database.Clear<ItemCategory>();
			database.Clear<NewPostInfoModel>();
			database.Clear<UserCommentModel>();
			database.Clear<UserFeedItemModel>();
			database.Clear<UserListModel>();
		}

		private void CreateTestData()
		{
			foreach (var item in TestAPI.GetFeedItems())
			{
				database.Save(item);
			}

			foreach (var item in TestAPI.GetItemsBrand())
			{
				database.Save(item);
			}

			foreach (var item in TestAPI.GetItemsTypes())
			{
				database.Save(item);
			}

			foreach (var item in TestAPI.GetUserList())
			{
				database.Save(item);
			}

			foreach (var item in TestAPI.GetUserComments())
			{
				database.Save(item);
			}

			foreach (var item in TestAPI.GetCategoryList())
			{
				database.Save(item);
			}
		}

		public IEnumerable<UserFeedItemModel> GetAllFeedItems()
		{
			return database.Get<UserFeedItemModel>();
		}

		public IEnumerable<UserCommentModel> GetCommentForFeed(Guid postId)
		{
			return database.Get<UserCommentModel>();
		}

		public IEnumerable<ItemCategory> GetAllCategories()
		{
			return database.Get<ItemCategory>();
		}

		public IEnumerable<ItemBrand> GetBrandsByCategoryId(Guid categoryId)
		{
			return database.Get<ItemBrand>();
		}

		public IEnumerable<ItemBrandType> GetBrandsByCategoryAndBrandId(Guid categroyId, Guid brandId)
		{
			return database.Get<ItemBrandType>();
		}

		public IEnumerable<UserListModel> GetAllUsers()
		{
			return database.Get<UserListModel>();
		}

		public UserListModel GetSpecificUserById(Guid userId)
		{
			return database.Get<UserListModel>(userId);
		}

		public IEnumerable<UserFeedItemModel> GetFeedByUserId(Guid userId)
		{
			throw new NotImplementedException();
		}

		public void CreateNewPost(UserFeedItemModel postModel)
		{
			throw new NotImplementedException();
		}

		public void SubscribeToUser(Guid userId)
		{
			throw new NotImplementedException();
		}

		public void SharePostToSocialNetworks(Guid postId)
		{
			throw new NotImplementedException();
		}

		public void LoginWithCreds(string login, string passwordHash)
		{
			throw new NotImplementedException();
		}

		public void LoginWithSocialProviders()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<string> GetSearchSuggestions(string searchKey)
		{
			throw new NotImplementedException();
		}

		public void RegisterNewUser(string login, string passwordHash)
		{
			throw new NotImplementedException();
		}
	}

}

