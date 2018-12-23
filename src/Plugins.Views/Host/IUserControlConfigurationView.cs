﻿using System;

namespace Bau.Libraries.Plugins.Views.Host
{
	/// <summary>
	///		Interface de las vistas de los controles de usuario de configuración
	/// </summary>
	public interface IUserControlConfigurationView
	{
		/// <summary>
		///		Comprueba los datos introducidos por el usuario
		/// </summary>
		bool ValidateData(out string error);

		/// <summary>
		///		Graba los datos introducidos por el usuario
		/// </summary>
		void Save();
	}
}
