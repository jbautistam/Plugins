using System;
using System.Windows;

using Bau.Libraries.BauMvvm.ViewModels.Controllers;
using Bau.Libraries.BauMvvm.Views.Controllers;
using Bau.Libraries.Plugins.ViewModels;
using Bau.Libraries.Plugins.Views.Host;

namespace Bau.Libraries.Plugins.Views.HostView
{
	/// <summary>
	///		Controlador del host de Plugins
	/// </summary>
	public class HostPluginsController : IHostPluginsController
	{
		public HostPluginsController(string applicationName, IHostViewsController hostViewsController, IHostViewModelController hostViewModelController, 
									 Window mainWindow, Xceed.Wpf.AvalonDock.DockingManager dockmanager)
		{
			ApplicationName = applicationName;
			Instance = this;
			MainWindow = mainWindow;
			HostViewsController = hostViewsController;
			HostViewModelController = hostViewModelController;
			LayoutController = new ViewModels.HostPluginsLayoutController(dockmanager);
			ControllerWindow = new HostSystemController(applicationName, mainWindow);
			DialogsController = new HostDialogsController(applicationName, mainWindow);
			DataTemplateManager = new Controllers.DataTemplateManager();
		}

		/// <summary>
		///		Muestra un panel de log
		/// </summary>
		public void ShowLogPane(string windowId, LayoutEnums.DockPosition position)
		{
			LayoutController.ShowDockPane(windowId, LayoutEnums.DockPosition.Bottomm, "Log", new Views.Tools.Log.ListLogView());
		}

		/// <summary>
		///		Muestra un panel de errores
		/// </summary>
		public void ShowErrorPane(string windowId, LayoutEnums.DockPosition position)
		{	
			LayoutController.ShowDockPane("ERROR_WINDOW", LayoutEnums.DockPosition.Bottomm, "Errores", new Views.Tools.Errors.ListErrorView());
		}

		/// <summary>
		///		Muestra un panel de proceso
		/// </summary>
		public void ShowProcessPane(string windowId, LayoutEnums.DockPosition position)
		{
			LayoutController.ShowDockPane("PROCESS_WINDOW", LayoutEnums.DockPosition.Bottomm, "Procesos", new Views.Tools.Log.ListLogProgressView());
		}

		/// <summary>
		///		Muestra el navegador Web de una URL
		/// </summary>
		public void ShowWebBrowser(string url)
		{
			MainWindow.Dispatcher.Invoke
						(new Action(() => LayoutController.ShowDocument($"WEB_BROWSER_{url}", "Browser", new Views.WebBrowsers.WebBrowserView(url))), 
						 null);
		}

		/// <summary>
		///		Abre el editor de código
		/// </summary>
		public void ShowCodeEditor(string fileName, string template, LayoutEnums.Editor editor, string fileNameHelp = null)
		{
			MainWindow.Dispatcher.Invoke
					(new Action(() =>
								{
									if (string.IsNullOrEmpty(fileNameHelp))
										LayoutController.ShowDocument($"TEXT_VISUALIZER_{fileName}", System.IO.Path.GetFileName(fileName), 
																	  new Views.Tools.TextFiles.TextFileView(fileName, template, editor));
									else
										LayoutController.ShowDocument($"HELP_TEXT_VISUALIZER_{fileName}", System.IO.Path.GetFileName(fileName), 
																	  new Views.Tools.TextFiles.TextFileHelpView(fileName, template, editor, fileNameHelp));
								}
					), null);
		}

		/// <summary>
		///		Muestra una imagen a partir de un nombre de archivo
		/// </summary>
		public void ShowImage(string fileName)
		{
			MainWindow.Dispatcher.Invoke(new Action(() => LayoutController.ShowDocument($"IMAGE_VISUALIZER_{fileName}", "Image", 
																						new Views.Tools.Graphical.ImageView(fileName))),
										 null);
		}

		/// <summary>
		///		Muestra un archivo de texto a partir de un nombre de archivo
		/// </summary>
		public void ShowTextFile(string fileName)
		{
			MainWindow.Dispatcher.Invoke(new Action(() => LayoutController.ShowDocument($"TEXT_VISUALIZER_{fileName}", System.IO.Path.GetFileName(fileName), 
																						new Views.Tools.TextFiles.TextFileView(fileName))),
										  null);
		}

		/// <summary>
		///		Nombre de la aplicación
		/// </summary>
		public string ApplicationName { get; }

		/// <summary>
		///		Instancia
		/// </summary>
		internal static HostPluginsController Instance { get; private set; }

		/// <summary>
		///		Ventana principal
		/// </summary>
		internal Window MainWindow { get; }

		/// <summary>
		///		Formulario de la ventana principal
		/// </summary>
		public IHostPluginsLayoutController LayoutController { get; }

		/// <summary>
		///		Controlador de ventanas
		/// </summary>
		public IHostSystemController ControllerWindow { get; }

		/// <summary>
		///		Controlador de cuadros de diálogo
		/// </summary>
		public IHostDialogsController DialogsController { get; }

		/// <summary>
		///		Controlador de plantillas de datos
		/// </summary>
		internal Controllers.DataTemplateManager DataTemplateManager { get; }

		/// <summary>
		///		Controlador para las comunicación entre elementos de plugins
		/// </summary>
		public IHostViewModelController HostViewModelController { get; }

		/// <summary>
		///		Controlador de vistas principal
		/// </summary>
		public IHostViewsController HostViewsController { get; }
	}
}
