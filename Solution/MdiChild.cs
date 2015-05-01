using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace WaveManagerApp
{
	public partial class MdiChild : Form
	{


		#region properties
		private const string _filterOpen = "Wave Files|*" + Wave.Extension;
		private const string PngExtension = ".png";
		private const string _filterSave = _filterOpen + "|" + "Png Files|*" + PngExtension;


		private static int _count = 0;
		private bool _isNormal = true;
		private Wave _wave = null;
		private Wave _oldWave = null;
		private Wave _original = null;
		private bool _modified = false;
		private bool _redoUsed = false;
		private bool _undoUsed = false;
		
		public bool Modified
		{
			get { return _wave != null && !_wave.Equals(_original); }
		
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
		public MainForm MainForm
		{
			get { return (MainForm)MdiParent; }
		}
		#endregion
	
		public MdiChild()
		{
			InitializeComponent();
			DoubleBuffered = true;
			ResizeRedraw = true;
			_count++;
		}


		#region UI Events
		private void OnLoad(object sender, EventArgs e)
		{
			Text =  _wave!=null ?  _wave.FileName : "Wave "+_count;
			_original = (Text.Contains("\\")) ? Wave.CopyWave(_wave) : null;
			Application.Idle += OnIdle;
		}

		private void OnFormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = !CheckIfWantSaveChanges(true);
		}

		
		#endregion
	
		#region Menu Events

		#region Edit Menu
		public void OnEditUndo(object sender, EventArgs e)
		{
			_undoUsed = true;
			_redoUsed = false;
			UndoRedo();
		}

		public void OnEditRedo(object sender, EventArgs e)
		{
			_redoUsed = true;
			UndoRedo();
		}

		public void OnEditCut(object sender, EventArgs e)
		{
			WillModify();
			DataObject dataObject = new DataObject(Wave.DataObject, _wave);
			Clipboard.SetDataObject(dataObject, true);
			_wave = null;
			Invalidate();
		}

		public void OnEditCopy(object sender, EventArgs e)
		{
			DataObject dataObject = new DataObject(Wave.DataObject, _wave);
			Clipboard.SetDataObject(dataObject, true);

			Invalidate();
		}

		public void OnEditPaste(object sender, EventArgs e)
		{
			
			WillModify();
			_wave = WaveFromClipBoard();
			Invalidate();
		}

		public void OnEditCopyBitmap(object sender, EventArgs e)
		{
			Clipboard.SetImage(GenerateBitmap());
		}

		public void OnEditDelete(object sender, EventArgs e)
		{
			WillModify();
			_wave = null;
			Invalidate();
		}
		#endregion

		#region View Menu
		public void OnViewNormal(object sender, EventArgs e)
		{
			IsNormal = !IsNormal;
			Invalidate();
		}
		#endregion

		#region Tools Menu
		public void OnToolsPlay(object sender, EventArgs e)
		{
			if (Wave == null) return;
			if (Modified ){
				if ( !CheckIfWantSaveChanges(false)) return;
			}
			System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"" + Text);
			player.Play();
			
		}
		#endregion

		#region File Menu
		private void OnFileSaveAs(object sender, EventArgs e)
		{
			SaveWaveAs();
		}


		private void OnFileSave(object sender, EventArgs e)
		{
			SaveWave();
		}
		#endregion

		#region Tools Menu
		public void OnToolsModulate(object sender, EventArgs e)
		{

			WillModify();
			for (int i = 0; i < Wave.NumberOfSamples; i++)
			{
				Wave.Samples[i] = (byte)(Math.Sin(i + 3.2f) * 20 + Wave.Samples[i]);
			}
			Invalidate();
		}

		public void OnToolsRotate(object sender, EventArgs e)
		{
			WillModify();
			Array.Reverse(Wave.Samples);
			Invalidate();
		}

		#endregion

		#region Format Menu
		public void OnFormatColor(object sender, EventArgs e)
		{
			MainForm.OnFormatColor(sender, e);
		}

		public void OnFormatThickness(object sender, EventArgs e)
		{
			MainForm.OnFormatThickness(sender, e);
		}

		public void OnFormatBackground(object sender, EventArgs e)
		{
			MainForm.OnFormatBackground(sender, e);
		}
		#endregion

		#endregion

		#region Other Events
		private void OnIdle(object sender, EventArgs e)
		{
			saveTSMI.Enabled = Modified;
			saveAsTSMI.Enabled = _wave != null;
			undoTSMI.Enabled = !_undoUsed && _modified;
			redoTSMI.Enabled = !_redoUsed && _undoUsed;
			nornalFullToolStripMenuItem.Enabled =  playToolStripMenuItem.Enabled = rotateToolStripMenuItem.Enabled =	modulateToolStripMenuItem.Enabled
			= copyTSMI.Enabled = copyAsBitmapTSMI.Enabled = cutTSMI.Enabled = deleteTSMI.Enabled = _wave != null;
			pasteTSMI.Enabled = WaveFromClipBoard() != null;
		}
		private void OnPaint(object sender, PaintEventArgs e)
		{
			paintDraw(e.Graphics, true);
		}
		#endregion
		
		private void WillModify()
		{
			
			_oldWave = (Wave==null)? null : Wave.CopyWave(_wave);
			_modified = true;
			if (_undoUsed) _undoUsed = false;
		}
		
		public static Wave WaveFromClipBoard()
		{
			
			return (Wave) Clipboard.GetData(Wave.DataObject);
			
		}
	
		private void UndoRedo()
		{
			Wave temp = (_wave==null)? null : Wave.CopyWave(_wave);
			_wave = _oldWave;
			_oldWave = temp;
			_modified = true;
			Invalidate();
		}

		private Bitmap GenerateBitmap()
		{
			
				int width = IsNormal ? Wave.NumberOfSamples : ClientRectangle.Width;
				int height = IsNormal ? Wave.MaxSampleValue : ClientRectangle.Height;

				Bitmap newBitmap = new Bitmap(width, height, CreateGraphics());
				Graphics memryGraphics = Graphics.FromImage(newBitmap);
				paintDraw(memryGraphics, false);
			
				return newBitmap;
			
		}

		public bool CheckIfWantSaveChanges(bool hasNoOption)
		{
			if (!Modified)
				return true;

			SaveForm saveform = new SaveForm();
			saveform.buttonNo.Visible = hasNoOption;
			using (saveform)
			{

				DialogResult dialogResult = saveform.ShowDialog();

				if (dialogResult == DialogResult.Yes)
				{
					return SaveWave();
				}
				else if (dialogResult == DialogResult.No)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

		}

		public bool SaveWave()
		{
			if (!File.Exists(Text))
			{
				return SaveWaveAs();

			}
			if (WaveMgr.Save(Wave, Text))
			{
				_original = Wave.CopyWave(_wave);
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool SaveWaveAs()
		{
			SaveFileDialog saveDialog = new SaveFileDialog();
			saveDialog.Filter = _filterSave;

			using (saveDialog)
			{
				if (saveDialog.ShowDialog() == DialogResult.OK)
				{
					if (Path.GetExtension(saveDialog.FileName).ToLower() == PngExtension)
					{
						return SaveAsPNG(saveDialog.FileName);
					}
					else
					{
						MdiChild active = (MdiChild)this.ActiveMdiChild;
						if (WaveMgr.Save(Wave, saveDialog.FileName))
						{
							_original = Wave.CopyWave(_wave);
							Text = saveDialog.FileName;
							return true;
						}
						else
						{
							return false;
						}
					}
				}
				return false;
			}
		}

		private bool SaveAsPNG(string fileName)
		{
			try
			{
				GenerateBitmap().Save(fileName, ImageFormat.Png);
				return true;
			}
			catch (Exception e)
			{
				Log.error(e.Message);
				return false;
			}
		}

		private void paintDraw(Graphics g, bool setAutoScroll)
		{
			g.Clear(Preferences.WaveBgColor);
			if (_wave == null)
				return;

			if (IsNormal)
			{
				if (setAutoScroll)
					AutoScrollMinSize = new Size(_wave.NumberOfSamples, Wave.MaxSampleValue);
				
				g.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);
			}
			else
			{
				// Zooming
				float xScaleFactor = (float)ClientRectangle.Width / Wave.NumberOfSamples;
				float yScaleFactor = (float)ClientRectangle.Height / Wave.MaxSampleValue;
				g.ScaleTransform(xScaleFactor, yScaleFactor);
				if (setAutoScroll)
					AutoScrollMinSize = new Size(0, 0);

			}


			for (int i = 0; i < Wave.NumberOfSamples - 1; i++)
			{
				int y1 = Wave.Samples[i];
				int y2 = Wave.Samples[i + 1];

				g.DrawLine(Preferences.PenForWave(), i, y1, i + 1, y2);
			}

		}

		private Color ChangeColorWithDialog(Color defaultValue)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.Color = defaultValue;
			DialogResult result = colorDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				return colorDialog.Color;
			}
			return defaultValue;

		}



	
	}
}
