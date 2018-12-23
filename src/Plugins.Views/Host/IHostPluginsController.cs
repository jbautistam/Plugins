using System;

using Bau.Libraries.BauMvvm.ViewModels.Controllers;
using Bau.Libraries.BauMvvm.Views.Controllers;
using Bau.Libraries.Plugins.ViewModels;

namespace Bau.Libraries.Plugins.Views.Host
{
	/// <summary>
	///		Interface para el host de plugins
	/// </summary>
	public interface IHostPluginsController
	{
		/// <summary>
		///		Muestra un panel de log
		/// </summary>
		void ShowLogPane(string windowId, LayoutEnums.DockPosition position);

		/// <summary>
		///		Muestra un panel de errores
		/// </summary>
		void ShowErrorPane(string windowId, LayoutEnums.DockPosition position);

		/// <summary>
		///		Muestra un panel de proceso
		/// </summary>
		void ShowProcessPane(string windowId, LayoutEnums.DockPosition position);

		/// <summary>
		///		Muestra una ventana de edición de código
		/// </summary>
		void ShowCodeEditor(string fileName, string template, LayoutEnums.Editor editor, string fileNameHelp = null);

		/// <summary>
		///		Muestra el navegador Web de una URL
		/// </summary>
		void ShowWebBrowser(string url);

		/// <summary>
		///		Muestra una imagen a partir de un nombre de archivo
		/// </summary>
		void ShowImage(string fileName);

		/// <summary>
		///		Muestra un archivo de texto a partir de un nombre de archivo
		/// </summary>
		void ShowTextFile(string fileName);

		/// <summary>
		///		Controlador de ViewModel principal
		/// </summary>
		IHostViewModelController HostViewModelController { get; }

		/// <summary>
		///		Controlador con funciones del sistema operativo
		/// </summary>
		IHostSystemController ControllerWindow { get; }

		/// <summary>
		///		Controlador de cuadros de diálogo
		/// </summary>
		IHostDialogsController DialogsController { get; }

		/// <summary>
		///		Controlador principal de las vistas
		/// </summary>
		IHostViewsController HostViewsController { get; }

		/// <summary>
		///		Controlador de layout
		/// </summary>
		IHostPluginsLayoutController LayoutController { get; }
	}
}
