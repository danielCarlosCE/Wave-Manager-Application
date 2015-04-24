using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WaveManagerApp
{
	public partial class MdiChild : Form
	{
		private static int _count = 0;
		private bool _isNormal = true;
		private Wave _wave = null;
		private bool _modified = false;

		public bool Modified
		{
			get { return _modified; }
			set { _modified = value; }
		}

		public bool IsNormal
		{
			get { return _isNormal; }
			set { _isNormal = value; }
		}

		public Wave Wave
		{
			get { return _wave; }
			set { _wave = value; }
		}


		public MdiChild()
		{
			InitializeComponent();
			DoubleBuffered = true;
			ResizeRedraw = true;
			_count++;
		}
	
		private void OnLoad(object sender, EventArgs e)
		{
			Text =  _wave!=null ?  _wave.FileName : "Wave "+_count;
		}

		private void OnPaint(object sender, PaintEventArgs e)
		{
			if (_wave == null)
				return;

			Graphics g = e.Graphics;

			if (_isNormal)
			{
				// Scrolling
				AutoScrollMinSize = new Size(_wave.NumberOfSamples, Wave.MaxSampleValue);
				g.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);
			}
			else
			{
				// Zooming
				float xScaleFactor = (float)ClientRectangle.Width / _wave.NumberOfSamples;
				float yScaleFactor = (float)ClientRectangle.Height / Wave.MaxSampleValue;
				g.ScaleTransform(xScaleFactor, yScaleFactor);
			}
			for (int i = 0; i < _wave.NumberOfSamples - 1; i++)
			{
				g.DrawLine(Pens.Red, i, _wave.Samples[i], i + 1, _wave.Samples[i + 1]);
			}
		}

		private void OnViewNormal(object sender, EventArgs e)
		{
			IsNormal = !IsNormal;
			Invalidate();
			Modified = true;

		}
	

	
	}
}
