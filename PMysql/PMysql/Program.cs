using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace PMysql
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			MySqlConnection mySqlConnection = new MySqlConnection (
				"Database=dbprueba;Data Source=localhost;User Id=root;Password=root"
			);

			mySqlConnection.Open ();

			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText = "SELECT * FROM articulo";

			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();


				showColumnNames (mySqlDataReader);
				showRows (mySqlDataReader);


			mySqlDataReader.Close ();
			mySqlConnection.Clone ();
		}



		private static void showColumnNames(MySqlDataReader mySqlDataReader){			
			Console.Write ("======================================================");
			Console.WriteLine ();
			for (int index = 0; index < mySqlDataReader.FieldCount; index++){
				Console.Write ("   " + mySqlDataReader.GetName(index) + "     ");
			}
			Console.WriteLine ();
			Console.Write ("======================================================");
			Console.WriteLine ();
		}



		private static void showRows(MySqlDataReader mySqlDataReader){
			while (mySqlDataReader.Read()) {
				//Console.WriteLine ("-------------------------------------------------------");
				Console.WriteLine ("    " + "{0}      {1}", mySqlDataReader ["id"], mySqlDataReader ["nombre"]);
				Console.WriteLine ("------------------------------------------------------");
			}
		}

		public static string[] getColumnNames(MySqlDataReader mysqlDataReader){
			int count = mysqlDataReader.FieldCount;
			List<String> columnNames = new List<String> ();
			for (int index = 0; index < count; index++){
				columnNames.Add (mysqlDataReader.GetName (index));
			}
			return columnNames;
		}

		public static void updateDataBase(MySqlConnection mySqlConnection){
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText = "UPDATE articulo SET categoria=null WHERE id=4";
			mySqlCommand.ExecuteNonQuery ();
		}

	}
}
