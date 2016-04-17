namespace MusicManager
{
    partial class frmVolumnController
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVolumnController));
            this.grpBoxBassTreble = new System.Windows.Forms.GroupBox();
            this.lbltreble = new System.Windows.Forms.Label();
            this.TrebleBar = new System.Windows.Forms.TrackBar();
            this.lblBass = new System.Windows.Forms.Label();
            this.BassBar = new System.Windows.Forms.TrackBar();
            this.grpBoxMasterVolume = new System.Windows.Forms.GroupBox();
            this.lblMasterVolume = new System.Windows.Forms.Label();
            this.masterVolume = new System.Windows.Forms.TrackBar();
            this.grpBoxLeftRight = new System.Windows.Forms.GroupBox();
            this.lblLV = new System.Windows.Forms.Label();
            this.lblRV = new System.Windows.Forms.Label();
            this.rightVolume = new System.Windows.Forms.TrackBar();
            this.leftVolume = new System.Windows.Forms.TrackBar();
            this.grpBoxBassTreble.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrebleBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BassBar)).BeginInit();
            this.grpBoxMasterVolume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterVolume)).BeginInit();
            this.grpBoxLeftRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxBassTreble
            // 
            this.grpBoxBassTreble.Controls.Add(this.lbltreble);
            this.grpBoxBassTreble.Controls.Add(this.TrebleBar);
            this.grpBoxBassTreble.Controls.Add(this.lblBass);
            this.grpBoxBassTreble.Controls.Add(this.BassBar);
            this.grpBoxBassTreble.Location = new System.Drawing.Point(375, 14);
            this.grpBoxBassTreble.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpBoxBassTreble.Name = "grpBoxBassTreble";
            this.grpBoxBassTreble.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpBoxBassTreble.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpBoxBassTreble.Size = new System.Drawing.Size(225, 242);
            this.grpBoxBassTreble.TabIndex = 16;
            this.grpBoxBassTreble.TabStop = false;
            this.grpBoxBassTreble.Text = "Sound";
            // 
            // lbltreble
            // 
            this.lbltreble.AutoSize = true;
            this.lbltreble.Location = new System.Drawing.Point(139, 209);
            this.lbltreble.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltreble.Name = "lbltreble";
            this.lbltreble.Size = new System.Drawing.Size(49, 17);
            this.lbltreble.TabIndex = 13;
            this.lbltreble.Text = "Treble";
            // 
            // TrebleBar
            // 
            this.TrebleBar.LargeChange = 1;
            this.TrebleBar.Location = new System.Drawing.Point(136, 23);
            this.TrebleBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TrebleBar.Name = "TrebleBar";
            this.TrebleBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrebleBar.Size = new System.Drawing.Size(56, 182);
            this.TrebleBar.TabIndex = 12;
            this.TrebleBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TrebleBar.Value = 5;
            this.TrebleBar.Scroll += new System.EventHandler(this.TrebleBar_Scroll);
            // 
            // lblBass
            // 
            this.lblBass.AutoSize = true;
            this.lblBass.Location = new System.Drawing.Point(36, 209);
            this.lblBass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBass.Name = "lblBass";
            this.lblBass.Size = new System.Drawing.Size(39, 17);
            this.lblBass.TabIndex = 11;
            this.lblBass.Text = "Bass";
            // 
            // BassBar
            // 
            this.BassBar.LargeChange = 1;
            this.BassBar.Location = new System.Drawing.Point(28, 23);
            this.BassBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BassBar.Name = "BassBar";
            this.BassBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.BassBar.Size = new System.Drawing.Size(56, 182);
            this.BassBar.TabIndex = 10;
            this.BassBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.BassBar.Value = 5;
            this.BassBar.Scroll += new System.EventHandler(this.BassBar_Scroll);
            // 
            // grpBoxMasterVolume
            // 
            this.grpBoxMasterVolume.Controls.Add(this.lblMasterVolume);
            this.grpBoxMasterVolume.Controls.Add(this.masterVolume);
            this.grpBoxMasterVolume.Location = new System.Drawing.Point(224, 15);
            this.grpBoxMasterVolume.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpBoxMasterVolume.Name = "grpBoxMasterVolume";
            this.grpBoxMasterVolume.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpBoxMasterVolume.Size = new System.Drawing.Size(116, 242);
            this.grpBoxMasterVolume.TabIndex = 15;
            this.grpBoxMasterVolume.TabStop = false;
            this.grpBoxMasterVolume.Text = "Main Volume";
            // 
            // lblMasterVolume
            // 
            this.lblMasterVolume.AutoSize = true;
            this.lblMasterVolume.Location = new System.Drawing.Point(29, 209);
            this.lblMasterVolume.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMasterVolume.Name = "lblMasterVolume";
            this.lblMasterVolume.Size = new System.Drawing.Size(51, 17);
            this.lblMasterVolume.TabIndex = 11;
            this.lblMasterVolume.Text = "Master";
            // 
            // masterVolume
            // 
            this.masterVolume.LargeChange = 1;
            this.masterVolume.Location = new System.Drawing.Point(28, 23);
            this.masterVolume.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.masterVolume.Name = "masterVolume";
            this.masterVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.masterVolume.Size = new System.Drawing.Size(56, 182);
            this.masterVolume.TabIndex = 10;
            this.masterVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.masterVolume.Value = 5;
            this.masterVolume.Scroll += new System.EventHandler(this.masterVolume_Scroll);
            // 
            // grpBoxLeftRight
            // 
            this.grpBoxLeftRight.Controls.Add(this.lblLV);
            this.grpBoxLeftRight.Controls.Add(this.lblRV);
            this.grpBoxLeftRight.Controls.Add(this.rightVolume);
            this.grpBoxLeftRight.Controls.Add(this.leftVolume);
            this.grpBoxLeftRight.Location = new System.Drawing.Point(12, 15);
            this.grpBoxLeftRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpBoxLeftRight.Name = "grpBoxLeftRight";
            this.grpBoxLeftRight.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpBoxLeftRight.Size = new System.Drawing.Size(171, 242);
            this.grpBoxLeftRight.TabIndex = 14;
            this.grpBoxLeftRight.TabStop = false;
            this.grpBoxLeftRight.Text = "Left/Right Volume";
            // 
            // lblLV
            // 
            this.lblLV.AutoSize = true;
            this.lblLV.Location = new System.Drawing.Point(36, 209);
            this.lblLV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLV.Name = "lblLV";
            this.lblLV.Size = new System.Drawing.Size(32, 17);
            this.lblLV.TabIndex = 12;
            this.lblLV.Text = "Left";
            // 
            // lblRV
            // 
            this.lblRV.AutoSize = true;
            this.lblRV.Location = new System.Drawing.Point(96, 209);
            this.lblRV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRV.Name = "lblRV";
            this.lblRV.Size = new System.Drawing.Size(41, 17);
            this.lblRV.TabIndex = 11;
            this.lblRV.Text = "Right";
            // 
            // rightVolume
            // 
            this.rightVolume.LargeChange = 1;
            this.rightVolume.Location = new System.Drawing.Point(89, 23);
            this.rightVolume.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rightVolume.Name = "rightVolume";
            this.rightVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.rightVolume.Size = new System.Drawing.Size(56, 182);
            this.rightVolume.TabIndex = 10;
            this.rightVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.rightVolume.Value = 5;
            this.rightVolume.Scroll += new System.EventHandler(this.rightVolume_Scroll);
            // 
            // leftVolume
            // 
            this.leftVolume.LargeChange = 1;
            this.leftVolume.Location = new System.Drawing.Point(25, 23);
            this.leftVolume.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.leftVolume.Name = "leftVolume";
            this.leftVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.leftVolume.Size = new System.Drawing.Size(56, 182);
            this.leftVolume.TabIndex = 9;
            this.leftVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.leftVolume.Value = 5;
            this.leftVolume.Scroll += new System.EventHandler(this.leftVolume_Scroll);
            // 
            // frmVolumnController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 271);
            this.Controls.Add(this.grpBoxBassTreble);
            this.Controls.Add(this.grpBoxMasterVolume);
            this.Controls.Add(this.grpBoxLeftRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVolumnController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Volumn Controller";
            this.Load += new System.EventHandler(this.frmVolumnController_Load);
            this.grpBoxBassTreble.ResumeLayout(false);
            this.grpBoxBassTreble.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrebleBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BassBar)).EndInit();
            this.grpBoxMasterVolume.ResumeLayout(false);
            this.grpBoxMasterVolume.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterVolume)).EndInit();
            this.grpBoxLeftRight.ResumeLayout(false);
            this.grpBoxLeftRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftVolume)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxBassTreble;
        private System.Windows.Forms.Label lbltreble;
        private System.Windows.Forms.TrackBar TrebleBar;
        private System.Windows.Forms.Label lblBass;
        private System.Windows.Forms.TrackBar BassBar;
        private System.Windows.Forms.GroupBox grpBoxMasterVolume;
        private System.Windows.Forms.Label lblMasterVolume;
        private System.Windows.Forms.TrackBar masterVolume;
        private System.Windows.Forms.GroupBox grpBoxLeftRight;
        private System.Windows.Forms.Label lblLV;
        private System.Windows.Forms.Label lblRV;
        private System.Windows.Forms.TrackBar rightVolume;
        private System.Windows.Forms.TrackBar leftVolume;
    }
}