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

		}

		void OnOpenFile(string fileName)
		{
			string directoryName = Path.GetDirectoryName(fileName);
			foreach (TreeNode tn in treeView1.Nodes)
			{
				if (tn.Text == directoryName)
					return ;
			}

			string[] files = System.IO.Directory.GetFiles(directoryName, "*"+Wave.Extension);
			ArrayList nodes = new ArrayList();
			foreach(string name in files){
				TreeNode nodeChild = new TreeNode(Path.GetFileName(name));
				nodeChild.ImageIndex = 1;
				nodeChild.SelectedImageIndex =  1;
				
				nodes.Add(nodeChild);
			}
			TreeNode[] children = new TreeNode[nodes.Count];
			for (int i = 0; i < nodes.Count; i++)
			{
				children[i] = (TreeNode)nodes[i];
			}



			TreeNode node = new TreeNode(directoryName,children);
			
			treeView1.Nodes.Add(node);
			
		}

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
	}
}
