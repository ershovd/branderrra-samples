using System;
using System.Collections.Generic;

namespace Branderra
{
	public interface IDatabase
	{
		void Clear<TObject>() where TObject : class, IObjectId, new();
		void Delete<TObject>(TObject item) where TObject : class, IObjectId, new();
		IEnumerable<TObject> Get<TObject>() where TObject : class, IObjectId, new();
		TObject Get<TObject>(Guid id) where TObject : class, IObjectId, new();
		void Save<TObject>(TObject item) where TObject : class, IObjectId, new();
	}
}