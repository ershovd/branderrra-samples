using System;
using System.Collections.Generic;

namespace Branderra
{
	public class TestAPI
	{
		private static Guid cat1 = Guid.NewGuid();
		private static Guid cat2 = Guid.NewGuid();

		private static Guid type1 = Guid.NewGuid();
		private static Guid type2 = Guid.NewGuid();
		private static Guid type3 = Guid.NewGuid();

		private static Guid brand1 = Guid.NewGuid();
		private static Guid brand2 = Guid.NewGuid();
		private static Guid brand3 = Guid.NewGuid();


		private static Guid user1 = Guid.NewGuid();

		public static List<UserFeedItemModel> GetFeedItems()
		{
			return new List<UserFeedItemModel>() {
				new UserFeedItemModel()	{ Id=user1, UserName="Alina95", FeedPhotoSource="profile_image.png", TimeOfPost=DateTime.Now.Subtract(new TimeSpan(4, 5, 5)),
					UserAvatarSource="user1", ItemBrandInfo="Zara", ItemTypeInfo="Одежда", ItemCategoryInfo="Брюки", Rating=2, PostDescription="Купила отличное платье, что скажете девочки?"},
				new UserFeedItemModel()	{ Id=Guid.NewGuid(), UserName="Marina", FeedPhotoSource="profile_image.png", TimeOfPost=DateTime.Now.Subtract(new TimeSpan(4, 5, 5)),
					UserAvatarSource="user1", ItemBrandInfo="Zara", ItemTypeInfo="Шмотки", ItemCategoryInfo="Носки", Rating=4, PostDescription="не хватает шкафа, буду выкидывать"},
				new UserFeedItemModel()	{ Id=Guid.NewGuid(), UserName="Jackk", FeedPhotoSource="profile_image.png", TimeOfPost=DateTime.Now.Subtract(new TimeSpan(48, 5, 5)),
					UserAvatarSource="user1", ItemBrandInfo="Zara", ItemTypeInfo="Тряпки", ItemCategoryInfo="Юбки", Rating=5, PostDescription="Купила отличное платье, что скажете девочки?"},
			};
		}

		public static List<ItemBrandType>  GetItemsBrand()
		{
			return new List<ItemBrandType>() {
				new ItemBrandType() { Id=brand1, Title="Giorgio Armani", Rating=5, ImageFilename="armani.png", BrandId=type1},
				new ItemBrandType() { Id=brand2, Title="Mango", Rating=4, ImageFilename="mango.png", BrandId=type1 },
				new ItemBrandType() { Id=brand3, Title="Zara", Rating=2, ImageFilename="zara.png", BrandId=type2 },
				new ItemBrandType() { Id=Guid.NewGuid(), Title="Твое", Rating=2, ImageFilename="tvoe.png", BrandId=type2 },
				new ItemBrandType() { Id=Guid.NewGuid(), Title="Levi's", Rating=5, ImageFilename="levis.png", BrandId=type3 },
			};
		}

		public static List<ItemBrand> GetItemsTypes()
		{
			return new List<ItemBrand>() {
				new ItemBrand() { Id=type1, Title = "Платья", ImageFilename = "dress.png", Rating = 5, CategoryId=cat1 },
				new ItemBrand() { Id=type2, Title = "Юбки", ImageFilename = "skirt.png", Rating = 4, CategoryId=cat1 },
				new ItemBrand() { Id=type3, Title = "Рубашки", ImageFilename = "shirts.png", Rating = 3, CategoryId=cat2 },
				new ItemBrand() { Id=Guid.NewGuid(), Title = "Куртки", ImageFilename = "jacket.png", Rating = 2, CategoryId=cat2 },
				new ItemBrand() { Id=Guid.NewGuid(), Title = "Брюки", ImageFilename = "pants.png", Rating = 5, CategoryId=cat2 },
			};
		}

		public static List<UserListModel> GetUserList()
		{
			return new List<UserListModel>() {
				new UserListModel() { Id=Guid.NewGuid(), Title = "Kate_Petrova", ImageFilename = "user1.png" },
				new UserListModel() { Id=Guid.NewGuid(), Title = "Ekaterina_Petr", ImageFilename = "user2.png" },
				new UserListModel() { Id=Guid.NewGuid(), Title = "Ekaterina_Petrova", ImageFilename = "user3.png" },
				new UserListModel() { Id=Guid.NewGuid(), Title = "Kate_P", ImageFilename = "user4.png" },
				new UserListModel() { Id=Guid.NewGuid(), Title = "Kate_Petr", ImageFilename = "user5.png" },
			};
		}

		public static IList<ItemCategory> GetCategoryList()
		{
			return new List<ItemCategory>()
			{
				new ItemCategory() {Id=cat1, Title="Одежда и обувь", ImageFilename="clothes.png" },
				new ItemCategory() {Id=cat2, Title="Автомобили",  ImageFilename="cars.png"},
				new ItemCategory() {Id=Guid.NewGuid(), Title="Электроника", ImageFilename="electronics.png" },
				new ItemCategory() {Id=Guid.NewGuid(), Title="Косметика", ImageFilename="cosmetics.png" },
				new ItemCategory() {Id=Guid.NewGuid(), Title="Ювелирные изделия", ImageFilename="sports.png" }				
			};
		}		

		public static List<UserCommentModel> GetUserComments()
		{
			return new List<UserCommentModel>() {
				new UserCommentModel()	{ Id=user1, ImageFilename="user1.png", Title="Alina95", Detail="Купила отличное пальто, что скажете девочки?", Time="10 мин"},
				new UserCommentModel()	{ Id=Guid.NewGuid(), ImageFilename="user2.png", Title="KrisTi", Detail="Супер, тебе очень идет!", Time="35 мин"},
				new UserCommentModel()	{ Id=Guid.NewGuid(), ImageFilename="user3.png", Title="Emma26", Detail="Милое! Рассказывай где купила", Time="44 мин"},
				new UserCommentModel()	{ Id=Guid.NewGuid(), ImageFilename="user4.png", Title="EvgeniaR", Detail="Пальто в наличии \n Размеры 42, 44, 46-48 \n 4390 руб \n Омск, Маркса 18\\1", Time="4ч"},
			};
		}
	}
}

