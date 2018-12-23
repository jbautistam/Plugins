﻿using System;

namespace Bau.Libraries.Plugins.Views.HostView.ViewModels.AvalonLayout
{
	/// <summary>
	///		Argumentos de los eventos de <see cref="LayoutDockingController"/>
	/// </summary>
	public class LayoutDockingEventArgs
	{
		/// <summary>
		///		Constructor
		/// </summary>
		public LayoutDockingEventArgs(PaneViewModel activeDocument)
		{
			ActiveDocument = activeDocument;
		}

		/// <summary>
		///		Documento activo
		/// </summary>
		public PaneViewModel ActiveDocument { get; }
	}
}
