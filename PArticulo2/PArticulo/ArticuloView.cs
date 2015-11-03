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
			ComboBoxHelper.Fill (combobox1, queryResult);

			saveAction.Activated += delegate {
				save();
			};
			//comboBoxCategoria.
			//spinButtonPrecio.Value = 1.5;
		}
		private void save(){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
		}
	}
}

