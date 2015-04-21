#region Header
// © 2011
// Author:      Youssef Hawili
// Date:        10/5/2011 8:38:35 PM
#endregion

using System;
using System.Windows.Forms;

namespace WaveManagerApp
{
	/// <summary>
	/// 
	/// </summary>
	public partial class ClockControl : UserControl
	{
		#region Non-Public Data Members

		#endregion

		#region Non-Public Properties/Methods

		#endregion

		#region Public Interface

		/// <summary>
		/// 
		/// </summary>
		public ClockControl()
		{
			InitializeComponent();
		}

		#endregion

		#region Event Handlers

		private void OnTimer(object sender, EventArgs e)
		{
			_lblTime.Text = DateTime.Now.ToString();
		}

		#endregion

	}
}
