namespace WaveManagerApp
{
	partial class MdiChild
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nornalFullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.redoTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.cutTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.copyTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.copyAsBitmapTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.editToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(706, 28);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nornalFullToolStripMenuItem});
			this.viewToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// nornalFullToolStripMenuItem
			// 
			this.nornalFullToolStripMenuItem.Name = "nornalFullToolStripMenuItem";
			this.nornalFullToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
			this.nornalFullToolStripMenuItem.Text = "Nornal/Full (2)";
			this.nornalFullToolStripMenuItem.Click += new System.EventHandler(this.OnViewNormal);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoTSMI,
            this.redoTSMI,
            this.toolStripSeparator1,
            this.cutTSMI,
            this.copyTSMI,
            this.copyAsBitmapTSMI,
            this.pasteTSMI,
            this.deleteTSMI});
			this.editToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
			this.editToolStripMenuItem.Text = "&Edit";
			// 
			// undoTSMI
			// 
			this.undoTSMI.Name = "undoTSMI";
			this.undoTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.undoTSMI.Size = new System.Drawing.Size(182, 24);
			this.undoTSMI.Text = "Undo";
			this.undoTSMI.Click += new System.EventHandler(this.OnEditUndo);
			// 
			// redoTSMI
			// 
			this.redoTSMI.Name = "redoTSMI";
			this.redoTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.redoTSMI.Size = new System.Drawing.Size(182, 24);
			this.redoTSMI.Text = "Redo";
			this.redoTSMI.Click += new System.EventHandler(this.OnEditRedo);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
			// 
			// cutTSMI
			// 
			this.cutTSMI.Name = "cutTSMI";
			this.cutTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.cutTSMI.Size = new System.Drawing.Size(182, 24);
			this.cutTSMI.Text = "Cut";
			this.cutTSMI.Click += new System.EventHandler(this.OnEditCut);
			// 
			// copyTSMI
			// 
			this.copyTSMI.Name = "copyTSMI";
			this.copyTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyTSMI.Size = new System.Drawing.Size(182, 24);
			this.copyTSMI.Text = "Copy";
			this.copyTSMI.Click += new System.EventHandler(this.OnEditCopy);
			// 
			// pasteTSMI
			// 
			this.pasteTSMI.Name = "pasteTSMI";
			this.pasteTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteTSMI.Size = new System.Drawing.Size(182, 24);
			this.pasteTSMI.Text = "Paste";
			this.pasteTSMI.Click += new System.EventHandler(this.OnEditPaste);
			// 
			// copyAsBitmapTSMI
			// 
			this.copyAsBitmapTSMI.Name = "copyAsBitmapTSMI";
			this.copyAsBitmapTSMI.Size = new System.Drawing.Size(182, 24);
			this.copyAsBitmapTSMI.Text = "Copy as Bitmap";
			this.copyAsBitmapTSMI.Click += new System.EventHandler(this.OnEditCopyBitmap);
			// 
			// deleteTSMI
			// 
			this.deleteTSMI.Name = "deleteTSMI";
			this.deleteTSMI.Size = new System.Drawing.Size(182, 24);
			this.deleteTSMI.Text = "Delete";
			this.deleteTSMI.Click += new System.EventHandler(this.OnEditDelete);
			// 
			// MdiChild
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(706, 464);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "MdiChild";
			this.Text = "MdiChildForm";
			this.Load += new System.EventHandler(this.OnLoad);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem nornalFullToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem undoTSMI;
		private System.Windows.Forms.ToolStripMenuItem redoTSMI;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem cutTSMI;
		private System.Windows.Forms.ToolStripMenuItem pasteTSMI;
		private System.Windows.Forms.ToolStripMenuItem copyTSMI;
		private System.Windows.Forms.ToolStripMenuItem copyAsBitmapTSMI;
		private System.Windows.Forms.ToolStripMenuItem deleteTSMI;

	}
}