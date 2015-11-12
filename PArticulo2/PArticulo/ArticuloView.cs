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
		}
	}
}

