#region Header
// © 2011
// Author:      Youssef Hawili
// Date:        10/5/2011 8:38:35 PM
#endregion

using System.Windows.Forms;

namespace WaveManagerApp
{
	/// <summary>
	/// 
	/// </summary>
	public partial class StatusStripControl : UserControl
	{
		#region Non-Public Data Members

		#endregion

		#region Non-Public Properties/Methods

		#endregion

		#region Public Interface

		/// <summary>
		/// 
		/// </summary>
		public StatusStripControl()
		{
			InitializeComponent();
			Log.errorEvent += OnErrorEvent;
		}

		void OnErrorEvent(string message)
		{
			int i = _errorListBox.Items.Add(message);
			_errorListBox.SelectedIndex = i;
		}

		#endregion

		#region Event Handlers

		#endregion


	}
}
