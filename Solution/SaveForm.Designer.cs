namespace WaveManagerApp
{
	partial class SaveForm
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.buttonNo = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Controls.Add(this.buttonNo, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonOk, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 133);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(387, 53);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// buttonNo
			// 
			this.buttonNo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonNo.Location = new System.Drawing.Point(132, 3);
			this.buttonNo.Name = "buttonNo";
			this.buttonNo.Size = new System.Drawing.Size(123, 47);
			this.buttonNo.TabIndex = 2;
			this.buttonNo.Text = "No";
			this.buttonNo.UseVisualStyleBackColor = true;
			this.buttonNo.Click += new System.EventHandler(this.OnNo);
			// 
			// buttonOk
			// 
			this.buttonOk.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonOk.Location = new System.Drawing.Point(3, 3);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(123, 47);
			this.buttonOk.TabIndex = 1;
			this.buttonOk.Text = "Yes";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.OnOk);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonCancel.Location = new System.Drawing.Point(261, 3);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(123, 47);
			this.buttonCancel.TabIndex = 0;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.OnCancel);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::WaveManagerApp.Properties.Resources.Help;
			this.pictureBox1.Location = new System.Drawing.Point(36, 51);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(54, 54);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(96, 67);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(233, 17);
			this.label1.TabIndex = 3;
			this.label1.Text = "Modified document. Save changes?";
			// 
			// SaveForm
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(387, 186);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "SaveForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SaveForm";
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.Button buttonNo;
	}
}