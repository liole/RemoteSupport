using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteSupport.Client.View
{
	public partial class StatusForm : Form
	{
		public event EventHandler<EventArgs> OnDisconnectClicked;

		int duration = 0;
		public StatusForm()
		{
			InitializeComponent();
		}

		public void ShowStatus(string name)
		{
			this.duration = 0;
			timer1.Start();
			ShowTime();
			pcNameLabel.Text = name;
			int x = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
			int y = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
			this.Location = new Point(x, y);
			Show();
		}

		public void HideStatus()
		{
			Hide();
			timer1.Stop();
		}

		public void ShowTime()
		{
			int min = duration / 60;
			int sec = duration % 60;
			time.Text = String.Format("{0:00}:{1:00}", min, sec);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			duration++;
			ShowTime();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (OnDisconnectClicked != null)
			{
				OnDisconnectClicked(this, new EventArgs());
			}
		}
	}
}
