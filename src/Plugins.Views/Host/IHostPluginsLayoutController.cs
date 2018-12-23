using System;
using System.Windows.Controls;

using Bau.Libraries.BauMvvm.ViewModels.Forms.Interfaces;

namespace Bau.Libraries.Plugins.Views.Host
{
	/// <summary>
	///		Interface para el host de layouts para plugins
	/// </summary>
	public interface IHostPluginsLayoutController : IPaneViewModel
	{
		/// <summary>
		///		Evento de cambio del documento activo
		/// </summary>
		event EventHandler<EventArguments.ActiveDocumentChangedEventArgs> ActiveDocumentChanged;

		/// <summary>
		///		Muestra un panel en uno de los paneles de la ventana principal
		/// </summary>
		void ShowDockPane(string windowID, LayoutEnums.DockPosition position, string title, UserControl innerControl);

		/// <summary>
		///		Muestra un documento
		/// </summary>
		void ShowDocument(string windowID, string title, UserControl document);

		/// <summary>
		///		Graba todos los documentos
		/// </summary>
		void SaveAllDocuments();

		/// <summary>
		///		Cierra todos los documentos
		/// </summary>
		void CloseAllDocuments();

		/// <summary>
		///		Cambia el tema del layout
		/// </summary>
		void SetTheme(LayoutEnums.Theme theme);
	}
}
