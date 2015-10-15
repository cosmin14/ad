using System;
using System.Data;
using MySql.Data.MySqlClient;
using PArticulo;

namespace PArticulo
{
	public class App
	{
		
		private static App instance = new App();
		public static App Instance {
			get { return instance;}
		}

		private App ()
		{
		}

		private IDbConnection connection;
		public IDbConnection DbConnection{
			get {
				if (connection == null) {
					connection = new MySqlConnection (
						"Database=dbprueba;Data Source=localhost;User Id=root;Password=root"
						);
					connection.Open ();
				}
				return connection; }
		}

	}
}

