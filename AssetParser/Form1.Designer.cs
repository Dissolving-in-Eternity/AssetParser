namespace AssetParser
{
	partial class Form1
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
			this.btnGetData = new System.Windows.Forms.Button();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.dataGrid = new System.Windows.Forms.DataGridView();
			this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColAsk = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// btnGetData
			// 
			this.btnGetData.Location = new System.Drawing.Point(12, 12);
			this.btnGetData.Name = "btnGetData";
			this.btnGetData.Size = new System.Drawing.Size(146, 23);
			this.btnGetData.TabIndex = 0;
			this.btnGetData.Text = "Get data";
			this.btnGetData.UseVisualStyleBackColor = true;
			this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.WorkerReportsProgress = true;
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
			this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
			// 
			// dataGrid
			// 
			this.dataGrid.AllowUserToAddRows = false;
			this.dataGrid.AllowUserToDeleteRows = false;
			this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.ColTime,
            this.ColBid,
            this.ColAsk});
			this.dataGrid.Location = new System.Drawing.Point(12, 41);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.Size = new System.Drawing.Size(544, 397);
			this.dataGrid.TabIndex = 1;
			// 
			// ColName
			// 
			this.ColName.HeaderText = "Asset Name";
			this.ColName.Name = "ColName";
			// 
			// ColTime
			// 
			this.ColTime.HeaderText = "Time";
			this.ColTime.Name = "ColTime";
			this.ColTime.Width = 200;
			// 
			// ColBid
			// 
			this.ColBid.HeaderText = "Bid";
			this.ColBid.Name = "ColBid";
			// 
			// ColAsk
			// 
			this.ColAsk.HeaderText = "Ask";
			this.ColAsk.Name = "ColAsk";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(568, 450);
			this.Controls.Add(this.dataGrid);
			this.Controls.Add(this.btnGetData);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnGetData;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private System.Windows.Forms.DataGridView dataGrid;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColTime;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColBid;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColAsk;
	}
}

