using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.Linq;
using System.Reflection;

using Bau.Libraries.LibCommonHelper.Extensors;
using Bau.Libraries.Plugins.Views.Host;
using Bau.Libraries.Plugins.Views.Plugins;

namespace Bau.Libraries.Plugins.Views.HostView.Controllers
{
	/// <summary>
	///		Manager para plugins MEF
	/// </summary>
	public class PluginsManager : IDisposable
	{
		/// <summary>
		///		Inicializa los datos
		/// </summary>
		public void Initialize(Type mainAssemblyType, List<string> pathPlugins)
		{
			// Crea el contenedor
			Container = new ContainerConfiguration().WithAssemblies(GetPluginsAssemblies(mainAssemblyType, pathPlugins), GetConventions()).CreateContainer();
			// Obtiene el manager de plugins
			Plugins = Container.GetExports<IPluginController>().ToList();
		}

		/// <summary>
		///		Obtiene los plugins de los ensamblados
		/// </summary>
		private IEnumerable<Assembly> GetPluginsAssemblies(Type mainAssemblyType, List<string> pathPlugins)
		{
			List<Assembly> assemblies = new List<Assembly>();

				// Añade el ensamblado principal para los plugins que se encuentran en el programa rpincipal
				assemblies.Add(mainAssemblyType.Assembly);
				// Añade los directorios de plugins
					foreach (string path in pathPlugins)
						if (System.IO.Directory.Exists(path))
							foreach (string fileName in System.IO.Directory.GetFiles(path, "*.plugin.dll"))
								if (System.IO.File.Exists(fileName) && fileName.EndsWith(".plugin.dll", StringComparison.CurrentCultureIgnoreCase))
									try
									{
										assemblies.Add(Assembly.LoadFrom(fileName));
									}
									catch (Exception exception)
									{
										HostPluginsController.Instance.HostViewModelController.Messenger.SendLog
												(HostPluginsController.Instance.ApplicationName,
												 Libraries.Plugins.ViewModels.Controllers.Messengers.Common.MessageLog.LogType.Error,
												 $"Error al cargar la librería del plugin {fileName}",
												 exception.Message, null);
									}
				// Devuelve la lista de ensamblados
				return assemblies;
		}

		/// <summary>
		///		Obtiene las convenciones
		/// </summary>
		private System.Composition.Convention.ConventionBuilder GetConventions()
		{
			var conventions = new System.Composition.Convention.ConventionBuilder();

				// Inicializa las convenciones
				conventions.ForTypesDerivedFrom<IPluginController>().Export<IPluginController>().Shared();
				// Devuelve las convenciones
				return conventions;
		}

		/// <summary>
		///		Inicializa los plugins
		/// </summary>
		public void InitPlugins(IHostPluginsController hostController, out string error)
		{   
			// Inicializa los argumentos de salida
			error = "";
			// Añade los plugins
			if (Plugins != null)
			{ 
				// Inicializa las librerías
				foreach (IPluginController plugin in Plugins)
					try
					{
						plugin.InitLibraries(hostController);
					}
					catch (Exception exception)
					{
						error = error.AddWithSeparator(GetError("InitLibraries", plugin, exception), Environment.NewLine);
					}
				// Inicializa la comunicación con otros plugins
				foreach (IPluginController plugin in Plugins)
					try
					{
						plugin.InitComunicationBetweenPlugins();
					}
					catch (Exception exception)
					{
						error = error.AddWithSeparator(GetError("InitComunicationBetweenPlugins", plugin, exception), Environment.NewLine);
					}
			}
		}

		/// <summary>
		///		Muestra los paneles laterales de los plugins
		/// </summary>
		public void ShowPanes(out string error)
		{ 
			// Inicializa los argumentos de salida
			error = "";
			// Muestra los paneles				
			if (Plugins != null)
				foreach (IPluginController plugin in Plugins)
					try
					{
						plugin.ShowPanes();
					}
					catch (Exception exception)
					{
						error = error.AddWithSeparator(GetError("ShowPanes", plugin, exception), Environment.NewLine);
					}
		}

		/// <summary>
		///		Obtiene un mensaje de error
		/// </summary>
		private string GetError(string strMethod, IPluginController plugin, Exception exception)
		{
			return $"Error en el método {strMethod} del plugin {plugin.Name}.\nExcepción: {exception.Message}";
		}

		/// <summary>
		///		Libera el objeto
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (!Disposed)
			{
				// Libera la memoria
				if (disposing)
					Container = null;
				// Indica que se ha liberado
				Disposed = true;
			}
		}

		/// <summary>
		///		Libera el objeto
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
		}

		/// <summary>
		///		Manager de plugins
		/// </summary>
		[ImportMany]
		public IEnumerable<IPluginController> Plugins { get; private set; }

		/// <summary>
		///		Contenedor de MEF
		/// </summary>
		public CompositionContext Container { get; private set; }

		/// <summary>
		///		Indica si se ha liberado el objeto
		/// </summary>
		public bool Disposed { get; private set; }
	}
}
