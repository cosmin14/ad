using Gtk;
using System;
using System.Collections;
using SerpisAd;
using System.Data;

namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		public ArticuloView () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			//entryNombre.Text = "nuevo";
			QueryResult queryResult = PersisterHelper.Get ("select * from categoria");
			ComboBoxHelper.Fill (comboBoxCategoria, queryResult);

			saveAction.Activated += delegate {
				save();
			};
			//comboBoxCategoria.
			//spinButtonPrecio.Value = 1.5;
		}

		public ArticuloView (object id) : 
			base(Gtk.WindowType.Toplevel)
		{
			this.Build ();

			QueryResult queryResult = PersisterHelper.Get ("SELECT * FROM `articulo` WHERE id = "+id);
			foreach (var row in queryResult.Rows) {
				entryNombre.Text = row [1].ToString ();
				QueryResult queryResultCategoria = PersisterHelper.Get ("SELECT * FROM categoria");
				ComboBoxHelper.Fill (comboBoxCategoria, queryResultCategoria);
				comboBoxCategoria.Active = Int32.Parse(row [2].ToString ());
				spinButtonPrecio.Value = Convert.ToDouble(row [3]);
			}
			saveAction.Activated += delegate {
				entryNombre.GrabFocus();
				update(id);
			};

		}

		private void save(){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = "insert into articulo (nombre, categoria, precio) " +
				"values (@nombre, @categoria, @precio)";

			string nombre = entryNombre.Text;
			object categoria = ComboBoxHelper.GetId (comboBoxCategoria);
			decimal precio = Convert.ToDecimal(spinButtonPrecio.Value);	

			DbCommandHelper.AddParameter (dbCommand, "nombre", nombre);
			DbCommandHelper.AddParameter (dbCommand, "categoria", categoria);
			DbCommandHelper.AddParameter (dbCommand, "precio", precio);
			dbCommand.ExecuteNonQuery ();
			Destroy ();
		}

		private void update(object id){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = "UPDATE articulo SET nombre=@nombre, categoria=@categoria, precio=@precio WHERE id="+id;

			string nombre = entryNombre.Text;
			object categoria = ComboBoxHelper.GetId (comboBoxCategoria);
			decimal precio = Convert.ToDecimal(spinButtonPrecio.Value);	

			DbCommandHelper.AddParameter (dbCommand, "nombre", nombre);
			DbCommandHelper.AddParameter (dbCommand, "categoria", categoria);
			DbCommandHelper.AddParameter (dbCommand, "precio", precio);
			dbCommand.ExecuteNonQuery ();
			Destroy ();
		}
	}
}

