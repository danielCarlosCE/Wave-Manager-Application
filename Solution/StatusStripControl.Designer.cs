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
			this._lblKeys = new System.Windows.Forms.Label();
			this._cbxStatus = new System.Windows.Forms.ComboBox();
			this._lblGroups = new System.Windows.Forms.Label();
			this.clockControl1 = new WaveManagerApp.ClockControl();
			this._tlpMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// _tlpMain
			// 
			this._tlpMain.BackColor = System.Drawing.Color.SteelBlue;
			this._tlpMain.ColumnCount = 4;
			this._tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this._tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this._tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this._tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this._tlpMain.Controls.Add(this._lblKeys, 2, 0);
			this._tlpMain.Controls.Add(this._cbxStatus, 0, 0);
			this._tlpMain.Controls.Add(this._lblGroups, 1, 0);
			this._tlpMain.Controls.Add(this.clockControl1, 3, 0);
			this._tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this._tlpMain.Location = new System.Drawing.Point(0, 0);
			this._tlpMain.Margin = new System.Windows.Forms.Padding(4);
			this._tlpMain.Name = "_tlpMain";
			this._tlpMain.RowCount = 1;
			this._tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this._tlpMain.Size = new System.Drawing.Size(853, 32);
			this._tlpMain.TabIndex = 0;
			// 
			// _lblKeys
			// 
			this._lblKeys.AutoSize = true;
			this._lblKeys.Dock = System.Windows.Forms.DockStyle.Fill;
			this._lblKeys.ForeColor = System.Drawing.Color.White;
			this._lblKeys.Location = new System.Drawing.Point(515, 0);
			this._lblKeys.Name = "_lblKeys";
			this._lblKeys.Size = new System.Drawing.Size(126, 32);
			this._lblKeys.TabIndex = 2;
			this._lblKeys.Text = "x of y selected keys";
			this._lblKeys.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _cbxStatus
			// 
			this._cbxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
			this._cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cbxStatus.FormattingEnabled = true;
			this._cbxStatus.Location = new System.Drawing.Point(3, 3);
			this._cbxStatus.Name = "_cbxStatus";
			this._cbxStatus.Size = new System.Drawing.Size(414, 25);
			this._cbxStatus.TabIndex = 0;
			// 
			// _lblGroups
			// 
			this._lblGroups.AutoSize = true;
			this._lblGroups.Dock = System.Windows.Forms.DockStyle.Fill;
			this._lblGroups.ForeColor = System.Drawing.Color.White;
			this._lblGroups.Location = new System.Drawing.Point(423, 0);
			this._lblGroups.Name = "_lblGroups";
			this._lblGroups.Size = new System.Drawing.Size(86, 32);
			this._lblGroups.TabIndex = 1;
			this._lblGroups.Text = "Total Groups";
			this._lblGroups.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// clockControl1
			// 
			this.clockControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.clockControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clockControl1.Location = new System.Drawing.Point(648, 4);
			this.clockControl1.Margin = new System.Windows.Forms.Padding(4);
			this.clockControl1.Name = "clockControl1";
			this.clockControl1.Size = new System.Drawing.Size(201, 24);
			this.clockControl1.TabIndex = 3;
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
			this._tlpMain.ResumeLayout(false);
			this._tlpMain.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel _tlpMain;
		private System.Windows.Forms.Label _lblKeys;
		private System.Windows.Forms.ComboBox _cbxStatus;
		private System.Windows.Forms.Label _lblGroups;
		private ClockControl clockControl1;
	}
}
