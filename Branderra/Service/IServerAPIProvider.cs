using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Branderra
{
	public interface IServerAPIProvider
	{
		IEnumerable<UserFeedItemModel> GetAllFeedItems();
		IEnumerable<UserCommentModel> GetCommentForFeed(Guid postId);
		IEnumerable<ItemCategory> GetAllCategories();
		IEnumerable<ItemBrand> GetBrandsByCategoryId(Guid categoryId);
		IEnumerable<ItemBrandType> GetBrandsByCategoryAndBrandId(Guid categroyId, Guid brandId);
		IEnumerable<UserListModel> GetAllUsers();
		UserListModel GetSpecificUserById(Guid userId);
		IEnumerable<UserFeedItemModel> GetFeedByUserId(Guid userId);

		void CreateNewPost(UserFeedItemModel postModel);
		void SubscribeToUser(Guid userId);
		void SharePostToSocialNetworks(Guid postId);
		void LoginWithCreds(string login, string passwordHash);
		void RegisterNewUser(string login, string passwordHash);
		void LoginWithSocialProviders();

		IEnumerable<string> GetSearchSuggestions(string searchKey);
		// TODO: different search by diff objects
	}
}

