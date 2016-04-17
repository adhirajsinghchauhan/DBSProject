namespace MusicManager
{
    partial class frmOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOption));
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFolderFormat = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
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
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "File Name Format";
            // 
            // cmbFolderFormat
            // 
            this.cmbFolderFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cmbFolderFormat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbFolderFormat.Name = "cmbFolderFormat";
            this.cmbFolderFormat.Size = new System.Drawing.Size(464, 24);
            this.cmbFolderFormat.TabIndex = 15;
            this.cmbFolderFormat.SelectedIndexChanged += new System.EventHandler(this.cmbFolderFormat_SelectedIndexChanged);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(385, 206);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(265, 206);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // nudGenrePriority
            // 
            this.nudGenrePriority.Location = new System.Drawing.Point(20, 98);
            this.nudGenrePriority.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudGenrePriority.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudGenrePriority.Name = "nudGenrePriority";
            this.nudGenrePriority.Size = new System.Drawing.Size(133, 22);
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
            this.label3.Size = new System.Drawing.Size(96, 17);
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
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "Album Priority";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // nudAlbumPriority
            // 
            this.nudAlbumPriority.Location = new System.Drawing.Point(352, 100);
            this.nudAlbumPriority.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudAlbumPriority.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudAlbumPriority.Name = "nudAlbumPriority";
            this.nudAlbumPriority.Size = new System.Drawing.Size(133, 22);
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
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "Artist Priority";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // nudArtistPriority
            // 
            this.nudArtistPriority.Location = new System.Drawing.Point(183, 100);
            this.nudArtistPriority.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudArtistPriority.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudArtistPriority.Name = "nudArtistPriority";
            this.nudArtistPriority.Size = new System.Drawing.Size(133, 22);
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
            this.chkRepeat.Location = new System.Drawing.Point(20, 135);
            this.chkRepeat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRepeat.Name = "chkRepeat";
            this.chkRepeat.Size = new System.Drawing.Size(280, 21);
            this.chkRepeat.TabIndex = 26;
            this.chkRepeat.Text = "Do not repeat until all music are played ";
            this.chkRepeat.UseVisualStyleBackColor = true;
            this.chkRepeat.CheckedChanged += new System.EventHandler(this.chkRepeat_CheckedChanged);
            // 
            // nudRepeatPriority
            // 
            this.nudRepeatPriority.Location = new System.Drawing.Point(183, 164);
            this.nudRepeatPriority.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudRepeatPriority.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudRepeatPriority.Name = "nudRepeatPriority";
            this.nudRepeatPriority.Size = new System.Drawing.Size(133, 22);
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
            this.chkUseRepeatPriority.Location = new System.Drawing.Point(20, 164);
            this.chkUseRepeatPriority.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkUseRepeatPriority.Name = "chkUseRepeatPriority";
            this.chkUseRepeatPriority.Size = new System.Drawing.Size(147, 21);
            this.chkUseRepeatPriority.TabIndex = 28;
            this.chkUseRepeatPriority.Text = "Use repeat priority";
            this.chkUseRepeatPriority.UseVisualStyleBackColor = true;
            this.chkUseRepeatPriority.CheckedChanged += new System.EventHandler(this.chkUseRepeatPriority_CheckedChanged);
            // 
            // frmOption
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
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
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFolderFormat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Option";
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
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
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