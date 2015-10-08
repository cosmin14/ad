using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		IDataReader dataReader = conexion ();

			int columnas = dataReader.FieldCount;

		crearCabeceras (columnas, dataReader);

			ListStore listStore = crearTypes (columnas, dataReader);
			treeview1.Model = listStore;


		mostrarValores (columnas, dataReader, listStore);


		//connection.Clone ();
	}



	/**
	 * 
	 * Creamos la conexion a la base de datos y la consulta
	 * 
	 */
	public IDataReader conexion(){
		Console.WriteLine ("MainWindow ctor.");
		IDbConnection connection = new MySqlConnection (
			"Database=dbprueba;Data Source=localhost;User Id=root;Password=root"
			);
		connection.Open ();

		IDbCommand command = connection.CreateCommand ();
		command.CommandText = "select * from articulo";
		IDataReader dataReader = command.ExecuteReader ();

		return dataReader;
	}


	/**
	 * 
	 * Creamos las cabeceras de las columnas
	 * 
	 */
	public void crearCabeceras(int columnas, IDataReader dataReader){
		for (int i = 0; i < columnas; i++) {
			treeview1.AppendColumn (dataReader.GetName (i), new CellRendererText (), "text", i);
		}
	}


	/**
	 * 
	 * Creamos los tipos de los campos en el liststore
	 * 
	 */
	public ListStore crearTypes (int columnas, IDataReader dataReader){
		// Creamos una lista tipo Type, donde vamos añadiendo typeOf()
			Type[] types = new Type[columnas];
			for (int i = 0; i < columnas; i++) {
				types [i] = typeof(string);
			}
		// Creamos un liststore con los types y retornamos este liststore creada
			ListStore listStore = new ListStore(types);
		return listStore;
	}


	/**
	 * 
	 * Mostramos los valores de la base de datos
	 * 
	 */
	public void mostrarValores (int columnas, IDataReader dataReader, ListStore listStore){
		// Creamos una lista de tipo String donde añadimos los valores de cada fila en una posicion
			String[] datos = new String[columnas];
			while (dataReader.Read()) {
				for (int i = 0; i < columnas; i++) {// Añado los valores de cada campo en una posicion
					datos [i] = dataReader [i].ToString();
				}
			// Añado fila a fila con este metodo
				listStore.AppendValues (datos);
			}
	}



	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}


	protected void _refresh (object sender, EventArgs e)
	{
		//throw new NotImplementedException ();
	}
}
