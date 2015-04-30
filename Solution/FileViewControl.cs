using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Security.Permissions;

public delegate void DoubleClickEventHandler(String fileName);


namespace WaveManagerApp
{
	public partial class FileViewControl : UserControl
	{
		public static event DoubleClickEventHandler DoubleClickEvent;

		public FileViewControl()
		{
			InitializeComponent();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			MainForm.OpenFileEvent += OnOpenFile;
			LoadPreferences();

		}

		private void LoadPreferences()
		{
			Font = Preferences.FileViewFont;
			treeView1.BackColor = Preferences.FileViewBgColor;
			treeView1.ForeColor = Preferences.FileViewForeColor;
			
		}

		void OnOpenFile(string fileName)
		{
			string directoryName = Path.GetDirectoryName(fileName);
			AddNode(directoryName);
			
		}

		private void AddNode(string directoryName)
		{
			foreach (TreeNode tn in treeView1.Nodes)
			{
				if (tn.Text == directoryName)
					return;
			}

			Watch(directoryName);

			TreeNode[] children = LoadFiles(directoryName);

			TreeNode node = new TreeNode(directoryName, children);

			treeView1.Nodes.Add(node);
		}

		private static TreeNode[] LoadFiles(string directoryName)
		{
			string[] files = System.IO.Directory.GetFiles(directoryName, "*" + Wave.Extension);
			ArrayList nodes = new ArrayList();
			foreach (string name in files)
			{
				TreeNode nodeChild = new TreeNode(Path.GetFileName(name));
				nodeChild.ImageIndex = 1;
				nodeChild.SelectedImageIndex = 1;

				nodes.Add(nodeChild);
			}
			TreeNode[] children = new TreeNode[nodes.Count];
			for (int i = 0; i < nodes.Count; i++)
			{
				children[i] = (TreeNode)nodes[i];
			}
			return children;
		}

		#region FileWatch
		[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
		private  void Watch(string directoryName)
		{
			FileSystemWatcher watcher = new FileSystemWatcher();
			watcher.Path = directoryName;
			watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
			   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
			// Only watch text files.
			watcher.Filter = "*" + Wave.Extension;

			// Add event handlers.
			watcher.Created += new FileSystemEventHandler(OnChanged);
			watcher.Deleted += new FileSystemEventHandler(OnChanged);
			watcher.Renamed += new RenamedEventHandler(OnRenamed);

			watcher.EnableRaisingEvents = true;
		}

		private void OnChanged(object source, FileSystemEventArgs e)
		{
			// Specify what is done when a file is changed, created, or deleted.
			Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
			this.Invoke(new Action(() => ReloadDirectory(Path.GetDirectoryName(e.FullPath))));

		}

		private void OnRenamed(object source, RenamedEventArgs e)
		{
			// Specify what is done when a file is renamed.
			Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
			this.Invoke(new Action(() => ReloadDirectory(Path.GetDirectoryName(e.OldFullPath))));

		}

		private void ReloadDirectory(string directoryName)
		{
			
			foreach(TreeNode directory in treeView1.Nodes){
				if(directory.Text == directoryName){
					directory.Nodes.Clear();
					foreach (TreeNode tn in LoadFiles(directoryName))
					{
						directory.Nodes.Add(tn);
					}
				}
			}
		}
		#endregion

		private void OnTreeViewItemDrag(object sender, ItemDragEventArgs e)
		{

			TreeNode node = (TreeNode)e.Item;
			if (node.Parent == null)
				return;
			string fileName = node.Parent.Text + "\\" + node.Text;
			DoDragDrop(new DataObject(DataFormats.FileDrop, new string[] {fileName}), DragDropEffects.All);
		}

		private void OnDoubleClick(object sender, EventArgs e)
		{
			TreeNode node = ((TreeView)sender).SelectedNode;
			if (node.Parent == null)
				return;
			string fileName = node.Parent.Text + "\\" + node.Text;
			if (DoubleClickEvent != null)
				DoubleClickEvent(fileName);
		}

		#region Context Menu
		private void OnContextMenuFont(object sender, EventArgs e)
		{
			FontDialog fontDialog1 = new FontDialog();
			fontDialog1.ShowColor = true;
			fontDialog1.Font = Preferences.FileViewFont;

			if (fontDialog1.ShowDialog() != DialogResult.Cancel)
			{
				Preferences.FileViewFont = fontDialog1.Font;
				Preferences.FileViewForeColor = fontDialog1.Color;
				LoadPreferences();

			}

		}

		private void OnContextMenuBgColor(object sender, EventArgs e)
		{

			ColorDialog colorDialog = new ColorDialog();
			colorDialog.Color = Preferences.FileViewBgColor;
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				Preferences.FileViewBgColor = colorDialog.Color;
				LoadPreferences();

			}

		}
		#endregion


	}
}
