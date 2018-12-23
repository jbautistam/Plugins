using System;

using Bau.Libraries.Plugins.ViewModels.Controllers.Messengers;
using Bau.Libraries.Plugins.ViewModels.Controllers.Processes;
using Bau.Libraries.Plugins.ViewModels.Controllers.Settings;

namespace Bau.Libraries.Plugins.ViewModels
{
	/// <summary>
	///		Interface para el controlador de ViewModel
	/// </summary>
	public interface IHostViewModelController
	{ 
		/// <summary>
		///		Nombre de la aplicación
		/// </summary>
		string ApplicationName { get; }

		/// <summary>
		///		Controlador de la configuración de las aplicaciones
		/// </summary>
		Configuration Configuration { get; }

		/// <summary>
		///		Controlador para envío de mensajes de la aplicación
		/// </summary>
		MessengerController Messenger { get; }

		/// <summary>
		///		Cola de procesos
		/// </summary>
		TasksQueue TasksProcessor { get; }

		/// <summary>
		///		Planificador de procesos
		/// </summary>
		SchedulerController Scheduler { get; }
	}
}
