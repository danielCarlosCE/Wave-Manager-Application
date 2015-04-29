using System;
using System.Collections.Generic;
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

		public MdiChild ActiveChild
		{
			get
			{
				MdiChild active = (MdiChild)this.ActiveMdiChild;
				return active;
			}
		}


		public MainForm()
		{
			Preferences.LoadPreferences();
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
			ActiveChild.SaveWave();
			
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
			CloseChild(ActiveChild);
			
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
			LaunchWaveChild(Preferences.OpenedWaves);
			CheckThicknessMenu();

			
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
			
			saveTSB.Enabled = ActiveChild!=null && ActiveChild.Modified;
			printTSB.Enabled = ActiveChild != null;
			statusStripControl.wavesCount.Text = "Waves: "+MdiChildren.Length;
			statusStripControl.samplesCount.Text = "Samples: " + (ActiveChild == null || ActiveChild.Wave == null ? 0 : ActiveChild.Wave.NumberOfSamples);
			playTSB.Enabled = modulateTSB.Enabled = rotateTSB.Enabled = normalTSB.Enabled = deleteTSB.Enabled = cutTSB.Enabled = copyTSB.Enabled = ActiveChild != null && ActiveChild.Wave != null;
			pasteTSB.Enabled = MdiChild.WaveFromClipBoard() != null;
		}
		private void OnPrintPage(object sender, PrintPageEventArgs e)
		{

			int end = count + e.PageBounds.Width;

			if (end > ActiveChild.Wave.NumberOfSamples || !ActiveChild.IsNormal)
			{
				end = ActiveChild.Wave.NumberOfSamples;
			}

			if (!ActiveChild.IsNormal)
			{
				// Zooming
				float xScaleFactor = (float)e.PageBounds.Width / ActiveChild.Wave.NumberOfSamples;
				float yScaleFactor = (float)e.PageBounds.Height / Wave.MaxSampleValue;
				e.Graphics.ScaleTransform(xScaleFactor, yScaleFactor);
			}


			int x1 = 0;
			for (int i = count; i < end - 1; i++, x1++)
			{
				int y1 = ActiveChild.Wave.Samples[i];
				int y2 = ActiveChild.Wave.Samples[i + 1];
				e.Graphics.DrawLine(Preferences.PenForWave(), x1, y1, x1 + 1, y2);
			}
			if (!ActiveChild.IsNormal)
			{
				e.HasMorePages = false;
				return;
			}
			if (end >= ActiveChild.Wave.NumberOfSamples)
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
		private void OnWindowCascade(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
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
					MessageBox.Show("Invalid wave file.");
					Log.error(e.Message);
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

		


		private void CloseChild(MdiChild child)
		{
			if (child.Modified)
			{
				if (ActiveChild.CheckIfWantSaveChanges(true))
				{
					child.Close();
				}
				return;
			}

			child.Close();
		}

		

		private void OnViewToolBar(object sender, EventArgs e)
		{
			toolStrip.Visible = !toolStrip.Visible;
		}

		private void OnViewStatusBar(object sender, EventArgs e)
		{
			statusStripControl.Visible = !statusStripControl.Visible;
		}

		

		public void InvalidadeChildren()
		{
			foreach (Form f in MdiChildren)
			{
				f.Invalidate();
			}
		}

		private Color ChangeColorWithDialog(Color defaultValue)
		{
			ColorDialog colorDialog = new ColorDialog();
			colorDialog.Color = defaultValue;
			DialogResult result = colorDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				return  colorDialog.Color;
			}
			return defaultValue;
			
		}

		public void OnFormatColor(object sender, EventArgs e)
		{
			Preferences.WaveColor = ChangeColorWithDialog(Preferences.WaveColor);
			InvalidadeChildren();
		}

		public void OnFormatThickness(object sender, EventArgs e)
		{
			
			Preferences.Thickness = float.Parse(((ToolStripMenuItem)sender).Text);
			CheckThicknessMenu();
			InvalidadeChildren();
			
		}

		private void CheckThicknessMenu()
		{
			foreach (ToolStripMenuItem i in thickTSB.DropDownItems)
			{
				if (i.Text == Preferences.Thickness.ToString())
				{
					i.CheckState = CheckState.Checked;
				}
				else
				{
					i.CheckState = CheckState.Unchecked;
				}
			}
		}

		public void OnFormatBackground(object sender, EventArgs e)
		{
			Preferences.WaveBgColor = ChangeColorWithDialog(Preferences.WaveBgColor);
			InvalidadeChildren();
		}

		private void OnHelpAbout(object sender, EventArgs e)
		{
			new HelpForm().ShowDialog();
		}

		private void OnFormClosing(object sender, FormClosingEventArgs e)
		{
			List<string> files = new List<string>();
			foreach (Form f in MdiChildren)
			{
				MdiChild child = (MdiChild)f;
				if (!child.CheckIfWantSaveChanges(true))
				{
					e.Cancel = true;
					return;
				}
				files.Add(child.Text);
			}
			Preferences.OpenedWaves = files.ToArray();
			Preferences.PersistPreferences(); 
		}

		private void OnEditCopy(object sender, EventArgs e)
		{
			ActiveChild.OnEditCopy(sender, e);
		}

		private void OnEditCut(object sender, EventArgs e)
		{
			ActiveChild.OnEditCut(sender, e);
		}

		private void OnEditPaste(object sender, EventArgs e)
		{
			ActiveChild.OnEditPaste(sender, e);

		}
		private void OnEditDelete(object sender, EventArgs e)
		{
			ActiveChild.OnEditDelete(sender, e);

		}

		private void OnViewNormalFull(object sender, EventArgs e)
		{
			ActiveChild.OnViewNormal(sender, e);

		}

		private void OnToolsPlay(object sender, EventArgs e)
		{
			ActiveChild.OnToolsPlay(sender, e);

		}

		private void OnToolsModulate(object sender, EventArgs e)
		{
			ActiveChild.OnToolsModulate(sender, e);

		}

		private void OnToolsRotate(object sender, EventArgs e)
		{
			ActiveChild.OnToolsRotate(sender, e);

		}

		
		

	}
}
