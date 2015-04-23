using System;
using System.Drawing;
using System.Drawing.Imaging;
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
			MdiChild active = (MdiChild)this.ActiveMdiChild;
			if (!File.Exists(active.Text))
			{
				OnFileSaveAs(sender, e);
				return;
			}
			WaveMgr.Save(active.Wave, active.Text);
			
		}
		
		private void OnFileSaveAs(object sender, EventArgs e)
		{
			SaveFileDialog saveDialog = new SaveFileDialog();
			saveDialog.Filter = _filterSave;

			using (saveDialog)
			{
				if (saveDialog.ShowDialog() == DialogResult.OK)
				{
					if (Path.GetExtension(saveDialog.FileName).ToLower() == PngExtension)
					{
						SaveAsPNG(saveDialog.FileName);	
					}
					else
					{
						MdiChild active = (MdiChild)this.ActiveMdiChild;
						WaveMgr.Save(active.Wave, saveDialog.FileName);
					}
				}
			}
		}

		private  void SaveAsPNG(string fileName)
		{
			MdiChild active = (MdiChild)this.ActiveMdiChild;
			int width = active.IsNormal ? active.Wave.NumberOfSamples : ClientRectangle.Width;
			int height = active.IsNormal ? Wave.MaxSampleValue : ClientRectangle.Height;
			
			Image newBitmap = new Bitmap(width, height, CreateGraphics());
			Graphics memryGraphics = Graphics.FromImage(newBitmap);
			paintDraw(memryGraphics);
			newBitmap.Save(fileName, ImageFormat.Png);
		}

		private void paintDraw(Graphics g)
		{
			MdiChild active = (MdiChild)this.ActiveMdiChild;

			if (active==null || active.Wave == null)
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
			for (int i = 0; i < active.Wave.NumberOfSamples - 1; i++)
			{
				g.DrawLine(Pens.Red, i, active.Wave.Samples[i], i + 1, active.Wave.Samples[i + 1]);
			}
		}

		private void OnFileCloseAll(object sender, EventArgs e)
		{
			foreach (Form f in MdiChildren)
			{
				f.Close();
			}
		}

		#endregion

		#region UI Events
		private void OnLoad(object sender, EventArgs e)
		{
			FileViewControl.DoubleClickEvent += OnFileViewControlDoubleClick;
			Application.Idle += OnIdle;

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

		

	}
}
