using System;
using System.Data;

namespace PArticulo
{
	public class App
	{
		public App ()
		{
		}

		private IDbConnection dbConnection;
		public IDbConnection DbConnection{
			get { return dbConnection; }
		}

		private static App instance;
		public static App Instance {
			get { return instance;}
		}
	}
}

