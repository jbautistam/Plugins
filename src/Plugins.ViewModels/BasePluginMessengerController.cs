﻿using System;

using Bau.Libraries.Plugins.ViewModels.Controllers.Messengers;

namespace Bau.Libraries.Plugins.ViewModels
{
	/// <summary>
	///		Controlador de mensajes para un controlador
	/// </summary>
	public abstract class BasePluginMessengerController
	{
		protected BasePluginMessengerController(BaseControllerViewModel viewModelController, IHostViewModelController host, bool receiveMessage)
		{
			ViewModelController = viewModelController;
			Host = host;
			if (receiveMessage)
				host.Messenger.Sent += (sender, evntArgs) => TreatMessage(sender, evntArgs.MessageSent);
		}

		/// <summary>
		///		Trata el mensaje enviado por el host
		/// </summary>
		public abstract void TreatMessage(object sender, Message message);

		/// <summary>
		///		Controlador del ViewModel
		/// </summary>
		public BaseControllerViewModel ViewModelController { get; }

		/// <summary>
		///		Host de la aplicación
		/// </summary>
		public IHostViewModelController Host { get; }

		/// <summary>
		///		Mensajero del host
		/// </summary>
		public MessengerController HostMessenger
		{
			get { return Host.Messenger; }
		}
	}
}
