using System;

namespace PArticulo
{
	public partial class CategoriaView : Gtk.Window
	{
		public CategoriaView () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

