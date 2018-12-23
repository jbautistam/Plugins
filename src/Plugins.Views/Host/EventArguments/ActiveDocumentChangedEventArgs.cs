using System;

using Bau.Libraries.BauMvvm.Views.Forms;

namespace Bau.Libraries.Plugins.Views.Host.EventArguments
{
	/// <summary>
	///		Argumentos del evento de cambio de documento activo
	/// </summary>
	public class ActiveDocumentChangedEventArgs : EventArgs
	{
		public ActiveDocumentChangedEventArgs(IFormView view)
		{
			View = view;
		}

		/// <summary>
		///		Vista activa
		/// </summary>
		public IFormView View { get; }
	}
}
