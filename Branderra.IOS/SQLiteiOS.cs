using Branderra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;
using SQLite;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace Branderra
{
	public class SQLite_iOS : Branderra.ISQLite
	{
		public SQLite_iOS()
		{
			
		}
		
		public SQLiteConnection GetConnection()
		{
			var sqliteFilename = "BranderraSQLite.db3";
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine(libraryPath, sqliteFilename);
			
			return new SQLite.SQLiteConnection(path);
		}

	}
}
