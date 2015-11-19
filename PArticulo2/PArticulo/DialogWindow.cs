using System;
using Gtk;

namespace PArticulo
{
	public class DialogWindow
	{
		public DialogWindow ()
		{
			
		}
		public bool confirmDialog (Window window)
		{
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
}

