using System;

using Bau.Libraries.BauMvvm.ViewModels.Forms.Interfaces;
using Bau.Libraries.BauMvvm.ViewModels.Forms;
using Bau.Libraries.BauMvvm.ViewModels.Controllers;
using Bau.Libraries.Plugins.Views.Host;
using Bau.Libraries.Plugins.Views.Host.EventArguments;

namespace Bau.Libraries.Plugins.Views.HostView.ViewModels
{
	/// <summary>
	///		ViewModel de la ventana principal de un formulario MDI
	/// </summary>
	public class HostPluginsLayoutController : BasePaneViewModel, IHostPluginsLayoutController
	{ 
		// Eventos
		public event EventHandler<ActiveDocumentChangedEventArgs> ActiveDocumentChanged;
		// Variables privadas
		private AvalonLayout.PaneViewModel _activeDocument;
		private readonly AvalonLayout.EmptyViewModel _emptyViewModel = new AvalonLayout.EmptyViewModel();

		public HostPluginsLayoutController(Xceed.Wpf.AvalonDock.DockingManager dockManager) : base(false)
		{
			DockingController = new AvalonLayout.LayoutDockingController(dockManager);
			DockingController.ActiveDocumentChanged += (sender, args) => ActiveDocument = args.ActiveDocument;
		}

		/// <summary>
		///		Añade un panel a la ventana principal
		/// </summary>
		public void ShowDockPane(string windowID, LayoutEnums.DockPosition position, string title, System.Windows.Controls.UserControl innerControl)
		{
			DockingController.ShowPane(windowID, title, innerControl, position);
		}

		/// <summary>
		///		Añade documentos al administrador de paneles
		/// </summary>
		public void ShowDocument(string windowID, string title, System.Windows.Controls.UserControl document)
		{
			DockingController.ShowDocument(windowID, title, document);
		}

		/// <summary>
		///		Obtiene el ViewModel activo
		/// </summary>
		private BauMvvm.Views.Forms.IFormView GetActiveViewModel()
		{
			return ActiveDocument?.GetFormView();
		}

		/// <summary>
		///		Ejecuta una acción
		/// </summary>
		protected override void ExecuteAction(string action, object parameter)
		{
			BauMvvm.Views.Forms.IFormView viewModel = GetActiveViewModel();

				if (viewModel != null)
					switch (action)
					{
						case nameof(CloseCommand):
								Close(SystemControllerEnums.ResultType.Yes);
							break;
						case nameof(NewCommand):
								if (viewModel is IPaneViewModel)
									(viewModel as IPaneViewModel).NewCommand.Execute(parameter);
							break;
						case nameof(SaveCommand):
								if (viewModel is IFormViewModel)
									(viewModel as IFormViewModel).SaveCommand.Execute(parameter);
							break;
						case nameof(DeleteCommand):
								if (viewModel is IFormViewModel)
									(viewModel as IFormViewModel).DeleteCommand.Execute(parameter);
							break;
						case nameof(PropertiesCommand):
								if (viewModel is IPaneViewModel)
									(viewModel as IPaneViewModel).PropertiesCommand.Execute(parameter);
							break;
						case nameof(RefreshCommand):
								if (viewModel is IFormViewModel)
									(viewModel as IFormViewModel).RefreshCommand.Execute(parameter);
							break;
					}
		}

		/// <summary>
		///		Comprueba si se puede ejecutar una acción
		/// </summary>
		protected override bool CanExecuteAction(string action, object parameter)
		{
			BauMvvm.Views.Forms.IFormView viewModel = GetActiveViewModel();
			bool canExecute = false;

				// Comprueba si se puede ejecutar el comando
				if (viewModel != null)
					switch (action)
					{
						case nameof(CloseCommand):
								canExecute = true;
							break;
						case nameof(NewCommand):
								if (viewModel is IPaneViewModel)
									canExecute = (viewModel as IPaneViewModel).NewCommand.CanExecute(parameter);
							break;
						case nameof(SaveCommand):
								if (viewModel is IFormViewModel)
									canExecute = (viewModel as IFormViewModel).SaveCommand.CanExecute(parameter);
							break;
						case nameof(PropertiesCommand):
								if (viewModel is IPaneViewModel)
									canExecute = (viewModel as IPaneViewModel).PropertiesCommand.CanExecute(parameter);
							break;
						case nameof(DeleteCommand):
								if (viewModel is IFormViewModel)
									canExecute = (viewModel as IFormViewModel).DeleteCommand.CanExecute(parameter);
							break;
						case nameof(RefreshCommand):
								if (viewModel is IFormViewModel)
									canExecute = (viewModel as IFormViewModel).RefreshCommand.CanExecute(parameter);
							break;
					}
				// Ejecuta el comando
				return canExecute;
		}

		/// <summary>
		///		Cierra todos los documentos
		/// </summary>
		public void CloseAllDocuments()
		{
			DockingController.CloseAllDocuments();
		}

		/// <summary>
		///		Graba todos los documentos
		/// </summary>
		public void SaveAllDocuments()
		{
			DockingController.SaveAllDocuments();
		}

		/// <summary>
		///		Cambia el tema del layout
		/// </summary>
		public void SetTheme(LayoutEnums.Theme theme)
		{
			switch (theme)
			{
				case LayoutEnums.Theme.Aero:
						DockingController.DockManager.Theme = new Xceed.Wpf.AvalonDock.Themes.AeroTheme();
					break;
				case LayoutEnums.Theme.Metro:
						DockingController.DockManager.Theme = new Xceed.Wpf.AvalonDock.Themes.MetroTheme();
					break;
				default:
						DockingController.DockManager.Theme = new Xceed.Wpf.AvalonDock.Themes.VS2010Theme();
					break;
			}
		}

		/// <summary>
		///		Documento activo
		/// </summary>
		public AvalonLayout.PaneViewModel ActiveDocument
		{
			get { return _activeDocument; }
			set
			{
				if (CheckObject(ref _activeDocument, value))
				{ 
					// Cambia el documento activo
					_activeDocument = value;
					if (_activeDocument == null)
						_activeDocument = _emptyViewModel;
					// Lanza el evento de cambio de documento
					ActiveDocumentChanged?.Invoke(this, new ActiveDocumentChangedEventArgs(_activeDocument?.GetFormView()));
				}
			}
		}

		/// <summary>
		///		Controlador de AvalonDock
		/// </summary>
		public AvalonLayout.LayoutDockingController DockingController { get; }
	}
}