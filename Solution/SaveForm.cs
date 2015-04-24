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
	public partial class SaveForm : Form
	{
		public SaveForm()
		{
			InitializeComponent();
		}

		private void OnCancel(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void OnOk(object sender, EventArgs e)
		{
			//code goes here. ex. validation

			DialogResult = DialogResult.Yes;
			Close();
		}

		private void OnNo(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			Close();
		}
	}
}
