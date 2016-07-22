using System;
using System.IO;
using Xamarin.Forms;
using Branderra.Droid;
using SQLite;

[assembly: Dependency (typeof (SQLite_Android))]
namespace Branderra.Droid
{
	public class SQLite_Android : ISQLite
	{
		public SQLite_Android()
		{			
		}

		public SQLiteConnection GetConnection()
		{
			var sqliteFilename = "BranderraSQLite.db3";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine(documentsPath, sqliteFilename);

			return new SQLite.SQLiteConnection(path);
		}
	}
}

