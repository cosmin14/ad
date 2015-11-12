using System;
using Gtk;
using System.Collections;
using SerpisAd;
using PArticulo;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		Console.WriteLine ("MainWindow ctor.");
		QueryResult queryResult = PersisterHelper.Get ("select * from articulo");
		TreeViewHelper.Fill (treeView, queryResult);

		refreshAction.Activated += delegate {
			fillTreeView();
		};

		newAction.Activated += delegate {
			new ArticuloView ();
		};

		removeAction.Activated += delegate {
			object id = GetId(treeView);
		};

		treeView.Selection.Changed += delegate {
			removeAction.Sensitive = GetId(treeView) != null;
			//Sirve para ver los cambios
		};

	}

	public static object GetId (TreeView treeView) {
		TreeIter treeIter;
		if (!treeView.Selection.GetSelected (out treeIter))
			return null;
		IList row = (IList)treeView.Model.GetValue (treeIter, 0);
		return row [0];
	}

	private void fillTreeView(){
		QueryResult queryResult = PersisterHelper.Get ("select * from articulo");
		TreeViewHelper.Fill (treeView, queryResult);
	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
