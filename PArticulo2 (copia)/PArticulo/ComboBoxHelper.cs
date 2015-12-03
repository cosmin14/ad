using Gtk;
using System;
using System.Collections;
using SerpisAd;

namespace PArticulo
{
	public class ComboBoxHelper
	{
		public static void Fill(ComboBox combobox, QueryResult queryResult){
			CellRendererText cellRendererText = new CellRendererText ();
			combobox.PackStart (cellRendererText, false);
			combobox.SetCellDataFunc (cellRendererText, 
			                          delegate(CellLayout cell_layout, CellRenderer cell, TreeModel tree_model, TreeIter iter) {
				IList row = (IList)tree_model.GetValue (iter, 0);
				cellRendererText.Text = row [1].ToString ();
			});
			ListStore listStore = new ListStore (typeof(IList));
			foreach (IList row in queryResult.Rows)
				listStore.AppendValues (row);
			combobox.Model = listStore;
		}
	}
}

