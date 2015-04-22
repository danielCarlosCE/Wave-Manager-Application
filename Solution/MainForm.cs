using System;
using System.IO;
using System.Windows.Forms;

public delegate void OpenFileEventHandler(String fileName);


namespace WaveManagerApp
{
	public partial class MainForm : Form
	{
		public static event OpenFileEventHandler OpenFileEvent;


		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			FileViewControl.DoubleClickEvent += OnFileViewControlDoubleClick;
		}

		void OnFileViewControlDoubleClick(string fileName)
		{
			LaunchWaveChild(new string[]{fileName});
		}
		private void OnFileNew(object sender, EventArgs e)
		{
			MdiChild f = new MdiChild();
			f.MdiParent = this;
			f.Show();
		}

		private void OnWindowTileHorizontally(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}

		private void OnWindowTileVertically(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void OnFileCloseAll(object sender, EventArgs e)
		{
			foreach (Form f in MdiChildren)
			{
				f.Close();
			}
		}

		private void LaunchWaveChild(string[] fileNames)
		{
			foreach (String fileName in fileNames)
			{
				if (!WaveMgr.IsValid(fileName))
					return;

				Wave w = WaveMgr.Read(fileName);

				MdiChild c = new MdiChild();
				c.SetWave(w);
				c.MdiParent = this;
				c.Show();
				if (OpenFileEvent != null)
				{
					OpenFileEvent(fileName);
				}
			}
		}

		private void OnFileOpen(object sender, EventArgs e)
		{
			OpenFileDialog d = new OpenFileDialog();
			d.Multiselect = true;
			d.Filter = @"Wave Files|*" +  Wave.Extension;
			using (d)
			{
				if (d.ShowDialog(this) != DialogResult.OK)
					return;

				LaunchWaveChild(d.FileNames);
			}
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

		// This is no longer used.
		private void OnViewNormalFull(object sender, EventArgs e)
		{
			//MdiChildForm form = (MdiChildForm)ActiveMdiChild;
			//form.IsNormal = !form.IsNormal;
			//form.Invalidate();
		}

		private void OnTest(object sender, EventArgs e)
		{
			System.Drawing.Font f = new System.Drawing.Font("Arial", 14);

		}

	}
}
