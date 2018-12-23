using System;

namespace Bau.Libraries.Plugins.Views.Plugins
{
	/// <summary>
	///		Base para los controladores de plugins
	/// </summary>
	public abstract class BasePluginController : IPluginController
	{
		protected BasePluginController() : this(null, null) { }

		protected BasePluginController(Host.IHostPluginsController hostPluginsController, string name)
		{
			HostPluginsController = hostPluginsController;
			Name = name;
		}

		/// <summary>
		///		Inicializa las librerías del plugin
		/// </summary>
		public abstract void InitLibraries(Host.IHostPluginsController hostPluginsController);

		/// <summary>
		///		Inicializa las propiedades de las librerías que se asocian a otros plugin
		/// </summary>
		public virtual void InitComunicationBetweenPlugins()
		{ 
			// No hace nada, crea una interface
		}

		/// <summary>
		///		Muestra los paneles del plugin
		/// </summary>
		public abstract void ShowPanes();

		/// <summary>
		///		Obtiene el control de configuración
		/// </summary>
		public abstract System.Windows.Controls.UserControl GetConfigurationControl();

		/// <summary>
		///		Nombre del plugin
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		///		Controlador de la aplicación principal
		/// </summary>
		public Host.IHostPluginsController HostPluginsController { get; set; }
	}
}
