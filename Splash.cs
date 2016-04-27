using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicManager
{
	public partial class Splash : Form
	{
		public Splash()
		{
			InitializeComponent();
		}

		private void getStartedButton_Click(object sender, EventArgs e)
		{
			new Setup().Show();
			this.Hide();
		}

		private void getStartedButton_MouseEnter(object sender, EventArgs e)
		{
			yeahButton.ForeColor = Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
		}

		private void getStartedButton_MouseLeave(object sender, EventArgs e)
		{
			yeahButton.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
		}

		private void nopeButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void nopeButton_MouseLeave(object sender, EventArgs e)
		{
			nopeButton.ForeColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
		}

		private void nopeButton_MouseEnter(object sender, EventArgs e)
		{
			nopeButton.ForeColor = Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
		}
	}
}
