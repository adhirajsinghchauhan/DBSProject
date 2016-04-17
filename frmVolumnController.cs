using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MusicManager
{
    public partial class frmVolumnController : Form
    {
        public frmVolumnController()
        {
            InitializeComponent();
        }

        private void leftVolume_Scroll(object sender, EventArgs e)
        {
            Player.GetPlayer().LeftVolume = leftVolume.Value * 100;
        }

        private void rightVolume_Scroll(object sender, EventArgs e)
        {
            Player.GetPlayer().RightVolume = rightVolume.Value * 100;
        }

        private void masterVolume_Scroll(object sender, EventArgs e)
        {
            Player.GetPlayer().MasterVolume = masterVolume.Value * 100;
        }

        private void BassBar_Scroll(object sender, EventArgs e)
        {
            Player.GetPlayer().Bass = BassBar.Value * 100;
        }

        private void TrebleBar_Scroll(object sender, EventArgs e)
        {
            Player.GetPlayer().Treble = TrebleBar.Value * 100;
        }

        private void frmVolumnController_Load(object sender, EventArgs e)
        {
            Player.GetPlayer().LeftVolume = leftVolume.Value * 100;
            Player.GetPlayer().RightVolume = rightVolume.Value * 100;
            Player.GetPlayer().MasterVolume = masterVolume.Value * 100;
            Player.GetPlayer().Bass = BassBar.Value * 100;
            Player.GetPlayer().Treble = TrebleBar.Value * 100;
        }        
    }
}