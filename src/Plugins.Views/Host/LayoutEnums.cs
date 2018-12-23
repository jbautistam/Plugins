using System;

namespace Bau.Libraries.Plugins.Views.Host
{
	/// <summary>
	///		Enumerados del layout
	/// </summary>
	public static class LayoutEnums
	{
		/// <summary>
		///		Posición en la que se puede colocar un panel
		/// </summary>
		public enum DockPosition
		{
			/// <summary>Izquierda</summary>
			Left,
			/// <summary>Superior</summary>
			Top,
			/// <summary>Derecha</summary>
			Right,
			/// <summary>Abajo</summary>
			Bottomm
		}

		/// <summary>
		///		Temas para el layout
		/// </summary>
		public enum Theme
		{
			Aero,
			Metro,
			Vs2010
		}

		/// <summary>
		///		Tipos de editores
		/// </summary>
		public enum Editor
		{
			/// <summary>Desconocido / texto</summary>
			Unknown,
			/// <summary>Editor de XML</summary>
			Xml,
			/// <summary>Editor de HTML</summary>
			Html,
			/// <summary>Otros editores</summary>
			Other
		}
	}
}
