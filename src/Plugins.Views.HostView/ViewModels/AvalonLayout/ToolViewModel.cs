using System;

using Bau.Libraries.BauMvvm.ViewModels.Controllers;
using Bau.Libraries.Plugins.Views.Host;

namespace Bau.Libraries.Plugins.Views.HostView.ViewModels.AvalonLayout
{
	/// <summary>
	///		ViewModel para las barras de herramientas
	/// </summary>
	public class ToolViewModel : PaneViewModel
	{   
		// Variables privadas
		private bool _isVisible = true;

		public ToolViewModel(string windowID, string name, Xceed.Wpf.AvalonDock.Layout.LayoutContent layoutPane,
							 System.Windows.Controls.UserControl control,
							 LayoutEnums.DockPosition position) : base(windowID, name, layoutPane, control)
		{
			Name = name;
			Title = name;
			DockPosition = position;
		}

		/// <summary>
		///		Nombre de la barra de herramientas
		/// </summary>
		public string Name { get; }

		/// <summary>
		///		Posición en la que se debe colocar el panel
		/// </summary>
		public LayoutEnums.DockPosition DockPosition { get; }

		/// <summary>
		///		Indica si la barra de herramientas está visible
		/// </summary>
		public bool IsVisible
		{
			get { return _isVisible; }
			set { CheckProperty(ref _isVisible, value); }
		}
	}
}
