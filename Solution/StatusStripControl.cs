#region Header
// © 2011
// Author:      Youssef Hawili
// Date:        10/5/2011 8:38:35 PM
#endregion

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WaveManagerApp
{
	/// <summary>
	/// 
	/// </summary>
	public partial class StatusStripControl : UserControl
	{
		int _oldvalue;

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
			Log.logEvent += OnLogEvent;
		}

		void OnLogEvent(string message)
		{
			int i = _logListBox.Items.Add(message);
			_logListBox.SelectedIndex = i;
		}

		#endregion


		private void OnLoad(object sender, System.EventArgs e)
		{
			_trackBar.Maximum = 50;
			_trackBar.TickFrequency = 5;
			_trackBar.LargeChange = 25;
			_oldvalue = _trackBar.Value;
		}

		private void OnTrackBarValueChanged(object sender, EventArgs e)
		{
			if (_oldvalue == _trackBar.Value)
				return;

			int dif = (_trackBar.Value - _oldvalue);
			if (dif > 0)
			{		
				VolumeMgnr.IncreaseVolume(this.Handle, dif);	
			}
			else
			{
				dif = _oldvalue - _trackBar.Value;
				VolumeMgnr.DecreaseVolume(this.Handle,dif);
			}
			
			_oldvalue = _trackBar.Value;
		}



	}

	class VolumeMgnr
	{
		public const int APPCOMMAND_VOLUME_UP = 0xA0000;
		public const int APPCOMMAND_VOLUME_DOWN = 0x90000;
		public const int WM_APPCOMMAND = 0x319;

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
			IntPtr wParam, IntPtr lParam);

		
		public static void DecreaseVolume(IntPtr Handle, int mult)
		{
			for(int i =0;i<mult;i++){
			SendMessageW(Handle, WM_APPCOMMAND, Handle,
				(IntPtr)APPCOMMAND_VOLUME_DOWN);
			}
		}

		public static void IncreaseVolume(IntPtr Handle, int mult)
		{			
			for(int i =0;i<mult;i++){

				SendMessageW(Handle, WM_APPCOMMAND, Handle,
				(IntPtr)APPCOMMAND_VOLUME_UP);
			}
		}
		

	}
}
