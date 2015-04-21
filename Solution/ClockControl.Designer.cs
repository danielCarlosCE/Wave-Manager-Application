namespace WaveManagerApp
{
	partial class ClockControl
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
			this.components = new System.ComponentModel.Container();
			this._lblTime = new System.Windows.Forms.Label();
			this._timer = new System.Windows.Forms.Timer(this.components);
			this._tlpMain = new System.Windows.Forms.TableLayoutPanel();
			this._tlpMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// _lblTime
			// 
			this._lblTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this._lblTime.ForeColor = System.Drawing.Color.White;
			this._lblTime.Location = new System.Drawing.Point(4, 0);
			this._lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this._lblTime.Name = "_lblTime";
			this._lblTime.Size = new System.Drawing.Size(193, 29);
			this._lblTime.TabIndex = 0;
			this._lblTime.Text = "Date and Time Control";
			this._lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _timer
			// 
			this._timer.Enabled = true;
			this._timer.Interval = 1000;
			this._timer.Tick += new System.EventHandler(this.OnTimer);
			// 
			// _tlpMain
			// 
			this._tlpMain.ColumnCount = 1;
			this._tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this._tlpMain.Controls.Add(this._lblTime, 0, 0);
			this._tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this._tlpMain.Location = new System.Drawing.Point(0, 0);
			this._tlpMain.Name = "_tlpMain";
			this._tlpMain.RowCount = 1;
			this._tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this._tlpMain.Size = new System.Drawing.Size(201, 29);
			this._tlpMain.TabIndex = 1;
			// 
			// ClockControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this._tlpMain);
			this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "ClockControl";
			this.Size = new System.Drawing.Size(201, 29);
			this._tlpMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label _lblTime;
		private System.Windows.Forms.Timer _timer;
		private System.Windows.Forms.TableLayoutPanel _tlpMain;
	}
}
