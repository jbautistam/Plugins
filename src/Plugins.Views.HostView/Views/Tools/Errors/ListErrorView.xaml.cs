using System;
using System.Windows.Controls;

using Bau.Libraries.Plugins.Views.HostView.ViewModels.Tools.Errors;
using Bau.Libraries.Plugins.ViewModels.Controllers.Messengers.Common;
using Bau.Libraries.BauMvvm.Views.Forms;

namespace Bau.Libraries.Plugins.Views.HostView.Views.Tools.Errors
{
	/// <summary>
	///		Ventana con la lista de errores
	/// </summary>
	public partial class ListErrorView : UserControl, IFormView
	{   
		public ListErrorView()
		{ 
			// Inicializa los componentes
			InitializeComponent();
			// Inicializa el DataContext
			lswLog.DataContext = ViewModel = new ErrorItemListViewModel();
			FormView = new BaseFormView(ViewModel);
			// Asigna los manejadores de eventos
			HostPluginsController.Instance.HostViewModelController.Messenger.Sent += (sender, evntArgs) =>
														{
															if (evntArgs.MessageSent is MessageError message)
																Dispatcher.Invoke(new Action(() => ViewModel.AddError(message)), null);
														};
		}

		/// <summary>
		///		Actualiza la lista
		/// </summary>
		internal void RefreshList()
		{
			ViewModel.RefreshList();
		}

		/// <summary>
		///		ViewModel de lista de log
		/// </summary>
		public BaseFormView FormView { get; }

		/// <summary>
		///		ViewModel de lista de log
		/// </summary>
		public ErrorItemListViewModel ViewModel { get; }
	}
}
