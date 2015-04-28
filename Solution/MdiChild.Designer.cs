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
			this.components = new System.ComponentModel.Container();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nornalFullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.redoTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.cutTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.copyTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.copyAsBitmapTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteTSMI = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.modulateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.thicknessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
			this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem});
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
			// copyAsBitmapTSMI
			// 
			this.copyAsBitmapTSMI.Name = "copyAsBitmapTSMI";
			this.copyAsBitmapTSMI.Size = new System.Drawing.Size(182, 24);
			this.copyAsBitmapTSMI.Text = "Copy as Bitmap";
			this.copyAsBitmapTSMI.Click += new System.EventHandler(this.OnEditCopyBitmap);
			// 
			// pasteTSMI
			// 
			this.pasteTSMI.Name = "pasteTSMI";
			this.pasteTSMI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteTSMI.Size = new System.Drawing.Size(182, 24);
			this.pasteTSMI.Text = "Paste";
			this.pasteTSMI.Click += new System.EventHandler(this.OnEditPaste);
			// 
			// deleteTSMI
			// 
			this.deleteTSMI.Name = "deleteTSMI";
			this.deleteTSMI.Size = new System.Drawing.Size(182, 24);
			this.deleteTSMI.Text = "Delete";
			this.deleteTSMI.Click += new System.EventHandler(this.OnEditDelete);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.modulateToolStripMenuItem,
            this.rotateToolStripMenuItem});
			this.toolsToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// playToolStripMenuItem
			// 
			this.playToolStripMenuItem.Name = "playToolStripMenuItem";
			this.playToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
			this.playToolStripMenuItem.Text = "Play";
			this.playToolStripMenuItem.Click += new System.EventHandler(this.OnToolsPlay);
			// 
			// modulateToolStripMenuItem
			// 
			this.modulateToolStripMenuItem.Name = "modulateToolStripMenuItem";
			this.modulateToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
			this.modulateToolStripMenuItem.Text = "Modulate";
			this.modulateToolStripMenuItem.Click += new System.EventHandler(this.OnToolsModulate);
			// 
			// rotateToolStripMenuItem
			// 
			this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
			this.rotateToolStripMenuItem.Size = new System.Drawing.Size(142, 24);
			this.rotateToolStripMenuItem.Text = "Rotate";
			this.rotateToolStripMenuItem.Click += new System.EventHandler(this.OnToolsRotate);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem,
            this.thicknessToolStripMenuItem,
            this.backgroundToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(139, 70);
			// 
			// colorToolStripMenuItem
			// 
			this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
			this.colorToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.colorToolStripMenuItem.Text = "Color";
			this.colorToolStripMenuItem.Click += new System.EventHandler(this.OnFormatColor);
			// 
			// thicknessToolStripMenuItem
			// 
			this.thicknessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
			this.thicknessToolStripMenuItem.Name = "thicknessToolStripMenuItem";
			this.thicknessToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.thicknessToolStripMenuItem.Text = "Thickness";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
			this.toolStripMenuItem2.Text = "1";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.OnFormatThickness);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
			this.toolStripMenuItem3.Text = "2";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.OnFormatThickness);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
			this.toolStripMenuItem4.Text = "4";
			this.toolStripMenuItem4.Click += new System.EventHandler(this.OnFormatThickness);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(152, 22);
			this.toolStripMenuItem5.Text = "8";
			this.toolStripMenuItem5.Click += new System.EventHandler(this.OnFormatThickness);
			// 
			// backgroundToolStripMenuItem
			// 
			this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
			this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.backgroundToolStripMenuItem.Text = "Background";
			this.backgroundToolStripMenuItem.Click += new System.EventHandler(this.OnFormatBackground);
			// 
			// MdiChild
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(706, 464);
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "MdiChild";
			this.Text = "MdiChildForm";
			this.Load += new System.EventHandler(this.OnLoad);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
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
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem modulateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem thicknessToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;

	}
}