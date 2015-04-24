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
		private Wave _oldWave = null;
		private bool _modified = false;
		private bool _redoUsed = false;
		private bool _undoUsed = false; 

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
			Application.Idle += OnIdle;
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
		}

		private void OnIdle(object sender, EventArgs e)
		{
			undoTSMI.Enabled = !_undoUsed && _modified;
			redoTSMI.Enabled = !_redoUsed && _undoUsed;
			copyTSMI.Enabled = _wave != null;
			copyAsBitmapTSMI.Enabled = _wave != null;
			cutTSMI.Enabled = _wave != null;
			pasteTSMI.Enabled = WaveFromClipBoard() != null;
			
		}
		
		private void WillModify()
		{
			_oldWave = _wave;
			_modified = true;
			if (_undoUsed) _undoUsed = false;
		}

		#region Edit Menu
		private void OnEditUndo(object sender, EventArgs e)
		{
			_undoUsed = true;
			_redoUsed = false;
			UndoRedo();
		}

		private void OnEditRedo(object sender, EventArgs e)
		{
			_redoUsed = true;
			UndoRedo();
		}

		private void OnEditCut(object sender, EventArgs e)
		{
			WillModify();
			DataObject dataObject = new DataObject(Wave.DataObject, _wave);
			Clipboard.SetDataObject(dataObject, true);
			_wave = null;
			Invalidate();
		}

		private void OnEditCopy(object sender, EventArgs e)
		{
			DataObject dataObject = new DataObject(Wave.DataObject, _wave);
			Clipboard.SetDataObject(dataObject, true);

			Invalidate();
		}

		private void OnEditPaste(object sender, EventArgs e)
		{
			
			WillModify();
			_wave = WaveFromClipBoard();
			Invalidate();
		}

		private void OnEditCopyBitmap(object sender, EventArgs e)
		{
			Clipboard.SetImage(GenerateBitmap());
		}

		private void OnEditDelete(object sender, EventArgs e)
		{
			WillModify();
			_wave = null;
			Invalidate();
		}
		#endregion

		private Wave WaveFromClipBoard()
		{
			return (Wave) Clipboard.GetData(Wave.DataObject);
		}
	
		private void UndoRedo()
		{
			Wave temp = _wave;
			_wave = _oldWave;
			_oldWave = temp;
			Invalidate();
		}

		private Bitmap GenerateBitmap()
		{
			
				int width = IsNormal ? Wave.NumberOfSamples : ClientRectangle.Width;
				int height = IsNormal ? Wave.MaxSampleValue : ClientRectangle.Height;

				Bitmap newBitmap = new Bitmap(width, height, CreateGraphics());
				Graphics memryGraphics = Graphics.FromImage(newBitmap);
				paintDraw(memryGraphics);
			
				return newBitmap;
			
		}

		private void paintDraw(Graphics g)
		{

			if (_wave == null)
				return;

			if (IsNormal)
			{
				g.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);
			}
			else
			{
				// Zooming
				float xScaleFactor = (float)ClientRectangle.Width / Wave.NumberOfSamples;
				float yScaleFactor = (float)ClientRectangle.Height / Wave.MaxSampleValue;
				g.ScaleTransform(xScaleFactor, yScaleFactor);
			}



			for (int i = 0; i < Wave.NumberOfSamples - 1; i++)
			{
				int y1 = Wave.Samples[i];
				int y2 = Wave.Samples[i + 1];

				g.DrawLine(Pens.Red, i, y1, i + 1, y2);
			}

		}

		




	
	}
}
