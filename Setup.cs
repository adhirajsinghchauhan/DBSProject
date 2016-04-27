using System;
using System.Windows.Forms;

namespace MusicManager
{
	public partial class Setup : Form
	{
		public Setup()
		{
			InitializeComponent();
			locationComboBox.Text = "E:\\Music";
		}

		private void yeahButton_Click(object sender, EventArgs e)
		{
			new Main(locationComboBox.Text).Show();
			this.Hide();
		}

		private void Setup_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
