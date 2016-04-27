namespace MusicManager
{
	partial class Options
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

		#region Windows Form Designer Generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
			this.label2 = new System.Windows.Forms.Label();
			this.cmbFolderFormat = new System.Windows.Forms.ComboBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.nudGenrePriority = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.nudAlbumPriority = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.nudArtistPriority = new System.Windows.Forms.NumericUpDown();
			this.chkRepeat = new System.Windows.Forms.CheckBox();
			this.nudRepeatPriority = new System.Windows.Forms.NumericUpDown();
			this.chkUseRepeatPriority = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.nudGenrePriority)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudAlbumPriority)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudArtistPriority)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRepeatPriority)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 11);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(117, 19);
			this.label2.TabIndex = 14;
			this.label2.Text = "File Name Format";
			// 
			// cmbFolderFormat
			// 
			this.cmbFolderFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
			this.cmbFolderFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbFolderFormat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
			this.cmbFolderFormat.FormattingEnabled = true;
			this.cmbFolderFormat.Items.AddRange(new object[] {
            "{Album}\\{Artist}\\{FileName}",
            "{Artist}\\{Album}\\{FileName}",
            "{Artist}\\{FileName}",
            "{Album}\\{FileName}",
            "{FileName}",
            "{Album}\\{Artist}\\{Title}",
            "{Artist}\\{Album}\\{Title}",
            "{Artist}\\{Title}",
            "{Album}\\{Title}",
            "{Title}.{Extention}",
            "{Genre}\\{Album}\\{Artist}\\{FileName}",
            "{Genre}\\{Artist}\\{Album}\\{FileName}",
            "{Genre}\\{Album}\\{Artist}\\{Title}",
            "{Genre}\\{Artist}\\{Album}\\{Title}"});
			this.cmbFolderFormat.Location = new System.Drawing.Point(20, 36);
			this.cmbFolderFormat.Margin = new System.Windows.Forms.Padding(4);
			this.cmbFolderFormat.Name = "cmbFolderFormat";
			this.cmbFolderFormat.Size = new System.Drawing.Size(464, 25);
			this.cmbFolderFormat.TabIndex = 15;
			this.cmbFolderFormat.SelectedIndexChanged += new System.EventHandler(this.cmbFolderFormat_SelectedIndexChanged);
			// 
			// buttonOK
			// 
			this.buttonOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
			this.buttonOK.Location = new System.Drawing.Point(385, 206);
			this.buttonOK.Margin = new System.Windows.Forms.Padding(4);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(100, 28);
			this.buttonOK.TabIndex = 16;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = false;
			this.buttonOK.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
			this.buttonCancel.Location = new System.Drawing.Point(265, 206);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(100, 28);
			this.buttonCancel.TabIndex = 17;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = false;
			this.buttonCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// nudGenrePriority
			// 
			this.nudGenrePriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
			this.nudGenrePriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
			this.nudGenrePriority.Location = new System.Drawing.Point(20, 98);
			this.nudGenrePriority.Margin = new System.Windows.Forms.Padding(4);
			this.nudGenrePriority.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.nudGenrePriority.Name = "nudGenrePriority";
			this.nudGenrePriority.Size = new System.Drawing.Size(133, 25);
			this.nudGenrePriority.TabIndex = 20;
			this.nudGenrePriority.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudGenrePriority.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 73);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 19);
			this.label3.TabIndex = 21;
			this.label3.Text = "Genre Priority";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(352, 74);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(97, 19);
			this.label4.TabIndex = 23;
			this.label4.Text = "Album Priority";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// nudAlbumPriority
			// 
			this.nudAlbumPriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
			this.nudAlbumPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
			this.nudAlbumPriority.Location = new System.Drawing.Point(352, 100);
			this.nudAlbumPriority.Margin = new System.Windows.Forms.Padding(4);
			this.nudAlbumPriority.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.nudAlbumPriority.Name = "nudAlbumPriority";
			this.nudAlbumPriority.Size = new System.Drawing.Size(133, 25);
			this.nudAlbumPriority.TabIndex = 22;
			this.nudAlbumPriority.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.nudAlbumPriority.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(183, 74);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(90, 19);
			this.label5.TabIndex = 25;
			this.label5.Text = "Artist Priority";
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// nudArtistPriority
			// 
			this.nudArtistPriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
			this.nudArtistPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
			this.nudArtistPriority.Location = new System.Drawing.Point(183, 100);
			this.nudArtistPriority.Margin = new System.Windows.Forms.Padding(4);
			this.nudArtistPriority.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.nudArtistPriority.Name = "nudArtistPriority";
			this.nudArtistPriority.Size = new System.Drawing.Size(133, 25);
			this.nudArtistPriority.TabIndex = 24;
			this.nudArtistPriority.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
			this.nudArtistPriority.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
			// 
			// chkRepeat
			// 
			this.chkRepeat.AutoSize = true;
			this.chkRepeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkRepeat.Location = new System.Drawing.Point(20, 135);
			this.chkRepeat.Margin = new System.Windows.Forms.Padding(4);
			this.chkRepeat.Name = "chkRepeat";
			this.chkRepeat.Size = new System.Drawing.Size(271, 23);
			this.chkRepeat.TabIndex = 26;
			this.chkRepeat.Text = "&Do not repeat until all music are played ";
			this.chkRepeat.UseVisualStyleBackColor = true;
			this.chkRepeat.CheckedChanged += new System.EventHandler(this.chkRepeat_CheckedChanged);
			// 
			// nudRepeatPriority
			// 
			this.nudRepeatPriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
			this.nudRepeatPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
			this.nudRepeatPriority.Location = new System.Drawing.Point(183, 164);
			this.nudRepeatPriority.Margin = new System.Windows.Forms.Padding(4);
			this.nudRepeatPriority.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.nudRepeatPriority.Name = "nudRepeatPriority";
			this.nudRepeatPriority.Size = new System.Drawing.Size(133, 25);
			this.nudRepeatPriority.TabIndex = 27;
			this.nudRepeatPriority.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.nudRepeatPriority.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged_1);
			// 
			// chkUseRepeatPriority
			// 
			this.chkUseRepeatPriority.AutoSize = true;
			this.chkUseRepeatPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chkUseRepeatPriority.Location = new System.Drawing.Point(20, 164);
			this.chkUseRepeatPriority.Margin = new System.Windows.Forms.Padding(4);
			this.chkUseRepeatPriority.Name = "chkUseRepeatPriority";
			this.chkUseRepeatPriority.Size = new System.Drawing.Size(141, 23);
			this.chkUseRepeatPriority.TabIndex = 28;
			this.chkUseRepeatPriority.Text = "&Use repeat priority";
			this.chkUseRepeatPriority.UseVisualStyleBackColor = true;
			this.chkUseRepeatPriority.CheckedChanged += new System.EventHandler(this.chkUseRepeatPriority_CheckedChanged);
			// 
			// Options
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(501, 249);
			this.Controls.Add(this.chkUseRepeatPriority);
			this.Controls.Add(this.nudRepeatPriority);
			this.Controls.Add(this.chkRepeat);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.nudArtistPriority);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.nudAlbumPriority);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.nudGenrePriority);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmbFolderFormat);
			this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Options";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options";
			this.Load += new System.EventHandler(this.frmOption_Load);
			((System.ComponentModel.ISupportInitialize)(this.nudGenrePriority)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudAlbumPriority)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudArtistPriority)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRepeatPriority)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbFolderFormat;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.NumericUpDown nudGenrePriority;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nudAlbumPriority;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown nudArtistPriority;
		private System.Windows.Forms.CheckBox chkRepeat;
		private System.Windows.Forms.NumericUpDown nudRepeatPriority;
		private System.Windows.Forms.CheckBox chkUseRepeatPriority;
	}
}