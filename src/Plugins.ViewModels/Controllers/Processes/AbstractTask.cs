﻿using System;

namespace Bau.Libraries.Plugins.ViewModels.Controllers.Processes
{
	/// <summary>
	///		Clase base para las tareas que se ejecutan en un hilo
	/// </summary>
	public abstract class AbstractTask : AbstractBaseProcess
	{
		protected AbstractTask(string source, string name = "", string description = "") : base(source, name, description) { }

		/// <summary>
		///		Procesa los datos
		/// </summary>
		public abstract void Process();
	}
}
