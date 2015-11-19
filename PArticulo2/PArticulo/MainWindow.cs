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

	// Boton actualizar
		refreshAction.Activated += delegate {
			fillTreeView();
		};

	// Boton nuevo
		newAction.Activated += delegate {
			new ArticuloView ();
			fillTreeView();
		};

	// Boton eliminar 
		removeAction.Sensitive = false; //Deshabilita el boton de eliminar
		removeAction.Activated += delegate {
			object id = TreeViewHelper.GetId(treeView);
			delete(id);
		};

	// Boton de editar
		editAction.Sensitive = false; //Deshabilita el boton de editar
		editAction.Activated += delegate {
			object id = TreeViewHelper.GetId(treeView);
			new ArticuloView(id);
			fillTreeView();
		};
			

	// Deteccion de cambio de elemento seleccionado
		treeView.Selection.Changed += delegate {
			removeAction.Sensitive = TreeViewHelper.isSelected(treeView);
			editAction.Sensitive = TreeViewHelper.isSelected(treeView);
			//Sirve para ver los cambios
		};
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

	private void delete(object id){
		if (confirmDelete (this)) {
			QueryResult queryResult = PersisterHelper.Get ("DELETE FROM `articulo` WHERE id = "+id.ToString());
			fillTreeView ();
		}
	}



	// Dialog
	private static bool confirmDelete(Window window){
		MessageDialog messageDialog = new MessageDialog (
			                              window,
			                              DialogFlags.DestroyWithParent,
			                              MessageType.Question,
			                              ButtonsType.YesNo,
			                              "¿Quieres elimnar el elemento seleccionado?"
		                              );
		messageDialog.Title = window.Title;
		ResponseType response = (ResponseType)messageDialog.Run ();
		messageDialog.Destroy ();
		return response == ResponseType.Yes;
	}
}
