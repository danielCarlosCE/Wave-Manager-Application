using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WaveManagerApp
{
	public partial class MdiChild : Form
	{
		private static int _count = 0;
		private Wave _wave = null;
		private bool _isNormal = true;

		public MdiChild()
		{
			InitializeComponent();
			DoubleBuffered = true;
			ResizeRedraw = true;
			_count++;
		}

		public bool IsNormal
		{
			get { return _isNormal; }
			set { _isNormal = value; }
		}

		//public Wave Wave
		//{
		//	get { return _wave; }
		//	set { _wave = Wave; }
		//}

		public void SetWave(Wave w)
		{
			_wave = w;
		}

		private void OnLoad(object sender, EventArgs e)
		{
			Text = "Mdi Child " + _count.ToString();
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
				Trace.WriteLine(@"=====> " + AutoScrollPosition.X.ToString() + ", " + AutoScrollPosition.Y.ToString());
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

		}
	}
}
