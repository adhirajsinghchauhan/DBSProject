namespace MusicManager
{
	partial class Setup
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup));
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.locationComboBox = new System.Windows.Forms.ComboBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.nopeButton = new System.Windows.Forms.Button();
			this.yeahButton = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))));
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(703, 105);
			this.panel1.TabIndex = 3;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox1.Location = new System.Drawing.Point(155, 26);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(62, 55);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Product Sans", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Orange;
			this.label1.Location = new System.Drawing.Point(225, 26);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(361, 61);
			this.label1.TabIndex = 0;
			this.label1.Text = "Music Manager";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label2.Location = new System.Drawing.Point(0, 105);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(10, 20, 10, 20);
			this.label2.Size = new System.Drawing.Size(703, 276);
			this.label2.TabIndex = 5;
			this.label2.Text = resources.GetString("label2.Text");
			// 
			// locationComboBox
			// 
			this.locationComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.locationComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.locationComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
			this.locationComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
			this.locationComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.locationComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
			this.locationComboBox.FormattingEnabled = true;
			this.locationComboBox.Location = new System.Drawing.Point(14, 261);
			this.locationComboBox.Margin = new System.Windows.Forms.Padding(5);
			this.locationComboBox.Name = "locationComboBox";
			this.locationComboBox.Size = new System.Drawing.Size(675, 31);
			this.locationComboBox.TabIndex = 20;
			this.locationComboBox.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.nopeButton);
			this.panel2.Controls.Add(this.yeahButton);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 335);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(703, 46);
			this.panel2.TabIndex = 21;
			// 
			// nopeButton
			// 
			this.nopeButton.AutoSize = true;
			this.nopeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
			this.nopeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.nopeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.nopeButton.Font = new System.Drawing.Font("Segoe UI", 10.2F);
			this.nopeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
			this.nopeButton.Location = new System.Drawing.Point(522, 4);
			this.nopeButton.Margin = new System.Windows.Forms.Padding(4);
			this.nopeButton.Name = "nopeButton";
			this.nopeButton.Size = new System.Drawing.Size(83, 35);
			this.nopeButton.TabIndex = 5;
			this.nopeButton.TabStop = false;
			this.nopeButton.Text = "&Nope";
			this.nopeButton.UseVisualStyleBackColor = false;
			// 
			// yeahButton
			// 
			this.yeahButton.AutoSize = true;
			this.yeahButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
			this.yeahButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.yeahButton.Font = new System.Drawing.Font("Segoe UI", 10.2F);
			this.yeahButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
			this.yeahButton.Location = new System.Drawing.Point(613, 4);
			this.yeahButton.Margin = new System.Windows.Forms.Padding(4);
			this.yeahButton.Name = "yeahButton";
			this.yeahButton.Size = new System.Drawing.Size(83, 35);
			this.yeahButton.TabIndex = 3;
			this.yeahButton.TabStop = false;
			this.yeahButton.Text = "&Yeah";
			this.yeahButton.UseVisualStyleBackColor = false;
			this.yeahButton.Click += new System.EventHandler(this.yeahButton_Click);
			// 
			// Setup
			// 
			this.AcceptButton = this.yeahButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
			this.CancelButton = this.nopeButton;
			this.ClientSize = new System.Drawing.Size(703, 381);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.locationComboBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.panel1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Setup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Setup";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Setup_FormClosed);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox locationComboBox;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button nopeButton;
		private System.Windows.Forms.Button yeahButton;
	}
}