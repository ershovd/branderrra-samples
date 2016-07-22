using System;
using SQLite;

namespace Branderra
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

