using System;
using SQLite;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace Branderra
{
	public class BranderraDatabase : IDatabase
	{
		private SQLiteConnection dataBase;
		private object locker = new object ();

		public BranderraDatabase()
		{
			dataBase = DependencyService.Get<ISQLite>().GetConnection();
			InitDb();
		}

		private void InitDb()
		{
			dataBase.CreateTable<ItemBrandModel>();
			dataBase.CreateTable<ItemBrandType>();
			dataBase.CreateTable<ItemBrand>();
			dataBase.CreateTable<ItemCategory>();
			dataBase.CreateTable<NewPostInfoModel>();
			dataBase.CreateTable<UserCommentModel>();
			dataBase.CreateTable<UserFeedItemModel>();
			dataBase.CreateTable<UserListModel>();
		}

		public IEnumerable<TObject> Get<TObject>() where TObject : class, IObjectId, new()
		{
			lock (locker) 			
			{				
				return (from i in dataBase.Table<TObject> () select i).ToList ();
			}
		}

		public TObject Get<TObject>(Guid id) where TObject : class, IObjectId, new()
		{
			lock(locker)
			{
				return dataBase.Get<TObject>(id);
			}
		}

		public void Save<TObject>(TObject item) where TObject : class, IObjectId, new()
		{
			lock(locker)
			{ 
				var obj = dataBase.Find<TObject>(item.Id);

				if (obj != null) 
				{
					dataBase.Update(item);				
				}
				else 
				{
					dataBase.Insert (item);		
				}
			}
		}

		public void Delete<TObject>(TObject item) where TObject : class, IObjectId, new()
		{
			lock(locker)
			{
				dataBase.Delete<TObject>(item.Id);
			}
		}

		public void Clear<TObject>() where TObject : class, IObjectId, new()
		{
			lock(locker)
			{
				dataBase.DropTable<TObject>();
				dataBase.CreateTable<TObject>();
			}
		}
	}
}

