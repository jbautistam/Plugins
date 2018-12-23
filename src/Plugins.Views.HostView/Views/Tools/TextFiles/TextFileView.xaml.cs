using System;
using System.Windows.Controls;

using Bau.Libraries.Plugins.Views.HostView.ViewModels.Tools.TextFiles;
using Bau.Libraries.BauMvvm.Views.Forms;
using Bau.Libraries.BauMvvm.ViewModels.Controllers;
using Bau.Libraries.Plugins.Views.Host;

namespace Bau.Libraries.Plugins.Views.HostView.Views.Tools.TextFiles
{
	/// <summary>
	///		Formulario para editar archivos de texto
	/// </summary>
	public partial class TextFileView : UserControl, IFormView
	{
		public TextFileView(string fileName, string template = null, LayoutEnums.Editor editor = LayoutEnums.Editor.Unknown)
		{ 
			// Inicializa el componente
			InitializeComponent();
			// Inicializa la vista de datos
			grdData.DataContext = ViewModel = new TextFileViewModel(fileName, template);
			udtEditor.Text = ViewModel.Content;
			FormView = new BaseFormView(ViewModel);
			// Cambia el modo de resalte del archivo
			udtEditor.FileName = fileName;
			switch (editor)
			{
				case LayoutEnums.Editor.Xml:
						udtEditor.ChangeHighLightByExtension(".xml");
					break;
				case LayoutEnums.Editor.Html:
						udtEditor.ChangeHighLightByExtension(".htm");
					break;
			}
			// Indica que no se ha modificado el contenido
			ViewModel.IsUpdated = false;
		}

		/// <summary>
		///		Vista del formulario
		/// </summary>
		public BaseFormView FormView { get; }

		/// <summary>
		///		ViewModel
		/// </summary>
		public TextFileViewModel ViewModel { get; }

		private void udtEditor_Changed(object sender, EventArgs evntArgs)
		{
			ViewModel.Content = udtEditor.Text;
		}
	}
}
