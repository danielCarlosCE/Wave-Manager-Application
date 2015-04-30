namespace WaveManagerApp
{
	partial class StatusStripControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.samplesCount = new System.Windows.Forms.Label();
			this._logListBox = new System.Windows.Forms.ComboBox();
			this.wavesCount = new System.Windows.Forms.Label();
			this._trackBar = new System.Windows.Forms.TrackBar();
			this._tlpMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._trackBar)).BeginInit();
			this.SuspendLayout();
			// 
			// _tlpMain
			// 
			this._tlpMain.BackColor = System.Drawing.Color.SteelBlue;
			this._tlpMain.ColumnCount = 4;
			this._tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.56976F));
			this._tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.37163F));
			this._tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this._tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this._tlpMain.Controls.Add(this.samplesCount, 2, 0);
			this._tlpMain.Controls.Add(this._logListBox, 0, 0);
			this._tlpMain.Controls.Add(this.wavesCount, 1, 0);
			this._tlpMain.Controls.Add(this._trackBar, 3, 0);
			this._tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this._tlpMain.Location = new System.Drawing.Point(0, 0);
			this._tlpMain.Margin = new System.Windows.Forms.Padding(4);
			this._tlpMain.Name = "_tlpMain";
			this._tlpMain.RowCount = 1;
			this._tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this._tlpMain.Size = new System.Drawing.Size(853, 32);
			this._tlpMain.TabIndex = 0;
			// 
			// samplesCount
			// 
			this.samplesCount.AutoSize = true;
			this.samplesCount.Dock = System.Windows.Forms.DockStyle.Fill;
			this.samplesCount.ForeColor = System.Drawing.Color.White;
			this.samplesCount.Location = new System.Drawing.Point(429, 0);
			this.samplesCount.Name = "samplesCount";
			this.samplesCount.Size = new System.Drawing.Size(207, 32);
			this.samplesCount.TabIndex = 2;
			this.samplesCount.Text = "Samples: 0";
			this.samplesCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _logListBox
			// 
			this._logListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this._logListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._logListBox.FormattingEnabled = true;
			this._logListBox.Location = new System.Drawing.Point(3, 3);
			this._logListBox.Name = "_logListBox";
			this._logListBox.Size = new System.Drawing.Size(323, 25);
			this._logListBox.TabIndex = 0;
			// 
			// wavesCount
			// 
			this.wavesCount.AutoSize = true;
			this.wavesCount.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wavesCount.ForeColor = System.Drawing.Color.White;
			this.wavesCount.Location = new System.Drawing.Point(332, 0);
			this.wavesCount.Name = "wavesCount";
			this.wavesCount.Size = new System.Drawing.Size(91, 32);
			this.wavesCount.TabIndex = 1;
			this.wavesCount.Text = "Waves: 0";
			this.wavesCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _trackBar
			// 
			this._trackBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this._trackBar.Location = new System.Drawing.Point(642, 3);
			this._trackBar.Name = "_trackBar";
			this._trackBar.Size = new System.Drawing.Size(208, 26);
			this._trackBar.TabIndex = 3;
			this._trackBar.ValueChanged += new System.EventHandler(this.OnTrackBarValueChanged);
			// 
			// StatusStripControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._tlpMain);
			this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "StatusStripControl";
			this.Size = new System.Drawing.Size(853, 32);
			this.Load += new System.EventHandler(this.OnLoad);
			this._tlpMain.ResumeLayout(false);
			this._tlpMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._trackBar)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel _tlpMain;
		private System.Windows.Forms.ComboBox _logListBox;
		private System.Windows.Forms.TrackBar _trackBar;
		public System.Windows.Forms.Label wavesCount;
		public System.Windows.Forms.Label samplesCount;
	}
}
