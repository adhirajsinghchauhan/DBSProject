using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MusicManager
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void frmOption_Load(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, false);
            string fileNameFormat = "";
            if (key != null)
            {
                if (key.GetValue("File Name Format") != null)
                    fileNameFormat = key.GetValue("File Name Format").ToString();
            }
            int index = 0;
            if (fileNameFormat != "")
            {
                index = cmbFolderFormat.FindString(fileNameFormat);
                if (index >= 0)
                    cmbFolderFormat.SelectedIndex = index;
            }
            else
                cmbFolderFormat.SelectedIndex = 0;
            nudGenrePriority.Value = ToolsManager.GetManager().GenrePriority;
            nudArtistPriority.Value = ToolsManager.GetManager().ArtistPriority;
            nudAlbumPriority.Value = ToolsManager.GetManager().AlbumPriority;
            chkRepeat.Checked = !ToolsManager.GetManager().AllowRepeat;
            chkUseRepeatPriority.Checked = ToolsManager.GetManager().UseRepeatPriority;
            nudRepeatPriority.Value = ToolsManager.GetManager().RepeatPriority;
        }

        private void cmbFolderFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string folderFormat = cmbFolderFormat.Text;
            Microsoft.Win32.RegistryKey key2 = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(ToolsManager.REGISTRY_KEY, true);
            if (key2 == null)
            {
                key2 = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(ToolsManager.REGISTRY_KEY);
            }
            key2.SetValue("File Name Format", folderFormat);
            ToolsManager.GetManager().FileFormat = folderFormat;
            ToolsManager.GetManager().GenrePriority = (int)nudGenrePriority.Value;
            ToolsManager.GetManager().ArtistPriority = (int)nudArtistPriority.Value;
            ToolsManager.GetManager().AlbumPriority = (int)nudAlbumPriority.Value;
            ToolsManager.GetManager().AllowRepeat = !chkRepeat.Checked;
            ToolsManager.GetManager().UseRepeatPriority = chkUseRepeatPriority.Checked;
            ToolsManager.GetManager().RepeatPriority = (int)nudRepeatPriority.Value;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbGroupBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkRepeat_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chkRepeat.Checked == true)
                chkUseRepeatPriority.Checked = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void chkUseRepeatPriority_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chkUseRepeatPriority.Checked == true)
                chkRepeat.Checked = false;
        }
    }
}