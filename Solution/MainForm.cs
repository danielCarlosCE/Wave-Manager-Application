using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

public delegate void OpenFileEventHandler(String fileName);


namespace WaveManagerApp
{
	public partial class MainForm : Form
	{
		public static event OpenFileEventHandler OpenFileEvent;
		private const string _filterOpen = "Wave Files|*" + Wave.Extension;
		private const string PngExtension = ".png";
		private const string _filterSave = _filterOpen + "|" + "Png Files|*"+PngExtension;

		private PrintDocument _printDoc = new PrintDocument();
		private int count = 0;


		public MainForm()
		{
			InitializeComponent();
		}

		#region FileMenu
		private void OnFileNew(object sender, EventArgs e)
		{
			MdiChild f = new MdiChild();
			f.MdiParent = this;
			f.Show();
		}

		private void OnFileOpen(object sender, EventArgs e)
		{
			OpenFileDialog d = new OpenFileDialog();
			d.Multiselect = true;
			d.Filter = _filterOpen;
			using (d)
			{
				if (d.ShowDialog(this) != DialogResult.OK)
					return;

				LaunchWaveChild(d.FileNames);
			}
		}

		private void OnFileSave(object sender, EventArgs e)
		{
			SaveWave();
			
		}

		private void OnFileSaveAs(object sender, EventArgs e)
		{
			SaveWaveAs();
		}

		private void OnFileCloseAll(object sender, EventArgs e)
		{
			foreach (Form f in MdiChildren)
			{
				MdiChild active = (MdiChild) f;
				CloseChild(active);
			}
		}

		private void OnFileClose(object sender, EventArgs e)
		{
			MdiChild active = (MdiChild)this.ActiveMdiChild;
			CloseChild(active);
			
		}

		private void OnFilePageSetup(object sender, EventArgs e)
		{
			PageSetupDialog psDialog = new PageSetupDialog();
			
			psDialog.PageSettings = _printDoc.DefaultPageSettings;
			psDialog.PrinterSettings = _printDoc.PrinterSettings;

			if (psDialog.ShowDialog() == DialogResult.OK)
			{
				_printDoc.DefaultPageSettings = psDialog.PageSettings;
				_printDoc.PrinterSettings = psDialog.PrinterSettings;
			}
		}

		private void OnFilePrintPreview(object sender, EventArgs e)
		{
			PrintPreviewDialog _printViewDialog = new PrintPreviewDialog();
			((Form)_printViewDialog).WindowState = FormWindowState.Maximized;
			
			_printViewDialog.Document = _printDoc;
			_printViewDialog.ShowDialog();
			Console.Write("\nend");
		}

		private void OnFilePrint(object sender, EventArgs e)
		{
			PrintDialog dlg = new PrintDialog();
			dlg.Document = _printDoc;
			if (dlg.ShowDialog() != DialogResult.OK)
				return;

			_printDoc.Print();

		}
		#endregion

		#region UI Events
		private void OnLoad(object sender, EventArgs e)
		{
			FileViewControl.DoubleClickEvent += OnFileViewControlDoubleClick;
			Application.Idle += OnIdle;
			_printDoc.PrintPage += OnPrintPage;
		}

		private void OnDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				foreach (String fileName in (string[])e.Data.GetData(DataFormats.FileDrop))
				{
					if (Path.GetExtension(fileName).ToLower() != Wave.Extension)
					{
						e.Effect = DragDropEffects.None;
						return;
					}
				}
				e.Effect = DragDropEffects.All;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void OnDragDrop(object sender, DragEventArgs e)
		{

			LaunchWaveChild((string[])e.Data.GetData(DataFormats.FileDrop));

		}

		#endregion

		#region Other Events
		private void OnFileViewControlDoubleClick(string fileName)
		{
			LaunchWaveChild(new string[]{fileName});
		}
		private void OnIdle(object sender, EventArgs e) {
			MdiChild active = (MdiChild)this.ActiveMdiChild;
			saveTSMI.Enabled = active!=null && active.Wave != null && active.Modified;
			saveAsTSMI.Enabled = active != null && active.Wave != null;
		}
		private void OnPrintPage(object sender, PrintPageEventArgs e)
		{
			MdiChild active = (MdiChild)this.ActiveMdiChild;

			int end = count + e.PageBounds.Width;

			if (end > active.Wave.NumberOfSamples || !active.IsNormal)
			{
				end = active.Wave.NumberOfSamples;
			}
			
			if (!active.IsNormal)
			{
				// Zooming
				float xScaleFactor = (float)e.PageBounds.Width / active.Wave.NumberOfSamples;
				float yScaleFactor = (float)e.PageBounds.Height / Wave.MaxSampleValue;
				e.Graphics.ScaleTransform(xScaleFactor, yScaleFactor);
			}


			Console.Write("count:" + count + "end:" + end);
			int x1 = 0;
			for (int i = count; i < end - 1; i++, x1++)
			{
				int y1 = active.Wave.Samples[i];
				int y2 = active.Wave.Samples[i + 1];
				e.Graphics.DrawLine(Pens.Red, x1, y1, x1 + 1, y2);
			}
			if (!active.IsNormal)
			{
				e.HasMorePages = false;
				return;
			}
			if (end >= active.Wave.NumberOfSamples)
			{
				e.HasMorePages = false;
				count = 0;
			}
			else
			{
				e.HasMorePages = true;
				count = end + 1;
			}
			

		}

		#endregion
		private void OnWindowTileHorizontally(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void OnWindowTileVertically(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void LaunchWaveChild(string[] fileNames)
		{
			foreach (String fileName in fileNames)
			{
				if (!WaveMgr.IsValid(fileName))
					return;
				Wave w = null;
				try
				{

					 w = WaveMgr.Read(fileName);

				}
				catch (Exception e)
				{
					MessageBox.Show("Invalid wave file ");
					return;
				}
				MdiChild c = new MdiChild();
				c.Wave = w;
				c.MdiParent = this;
				c.Show();
				if (OpenFileEvent != null)
				{
					OpenFileEvent(fileName);
				}
			}
		}

		private void OnTest(object sender, EventArgs e)
		{
			System.Drawing.Font f = new System.Drawing.Font("Arial", 14);

		}

		private bool SaveWave()
		{
			MdiChild active = (MdiChild)this.ActiveMdiChild;
			if (!File.Exists(active.Text))
			{
				return SaveWaveAs();

			}
			return WaveMgr.Save(active.Wave, active.Text);
		}

		private bool SaveWaveAs()
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
						return WaveMgr.Save(active.Wave, saveDialog.FileName);
					}
				}
				return false;
			}
		}

		private bool SaveAsPNG(string fileName)
		{
			try
			{
				MdiChild active = (MdiChild)this.ActiveMdiChild;
				int width = active.IsNormal ? active.Wave.NumberOfSamples : ClientRectangle.Width;
				int height = active.IsNormal ? Wave.MaxSampleValue : ClientRectangle.Height;

				Image newBitmap = new Bitmap(width, height, CreateGraphics());
				Graphics memryGraphics = Graphics.FromImage(newBitmap);
				paintDraw(memryGraphics);
				newBitmap.Save(fileName, ImageFormat.Png);
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		private void paintDraw(Graphics g)
		{
			MdiChild active = (MdiChild)this.ActiveMdiChild;

			if (active == null || active.Wave == null)
				return;

			if (active.IsNormal)
			{
				g.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);
			}
			else
			{
				// Zooming
				float xScaleFactor = (float)ClientRectangle.Width / active.Wave.NumberOfSamples;
				float yScaleFactor = (float)ClientRectangle.Height / Wave.MaxSampleValue;
				g.ScaleTransform(xScaleFactor, yScaleFactor);
			}


		
			for (int i = 0; i < active.Wave.NumberOfSamples-1; i++)
			{
				int  y1 = active.Wave.Samples[i];
				int  y2 = active.Wave.Samples[i + 1] ;
				
				g.DrawLine(Pens.Red, i, y1, i+1, y2);
			}
			
		}

		private void CloseChild(MdiChild child)
		{
			if (child.Modified)
			{
				if (CheckIfWantSaveChanges())
				{
					child.Close();
				}
				return;
			}

			child.Close();
		}

		/** Return false when user clicks Cancel button*/
		private bool CheckIfWantSaveChanges()
		{
			if (!saveToolStripButton.Enabled)
				return true;

			SaveForm saveform = new SaveForm();
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

		
		

	}
}
