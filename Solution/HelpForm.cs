using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaveManagerApp
{
	public partial class HelpForm : Form
	{
		public HelpForm()
		{
			InitializeComponent();
		}

		private void OnLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://en.wikipedia.org/wiki/Wave");
		}
	}
}
