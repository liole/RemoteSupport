using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RemoteSupport.Client.Controllers;

namespace RemoteSupport.Client.View
{
	public partial class StreamForm : Form, IStreamForm
	{
        public RemoteController remote;


		public StreamForm()
		{
            InitializeComponent();
			ClientSize = new Size(800+panel1.Width, 450);
            remote = new RemoteController(this); 
		}


		public Size ImageSize
		{
			get { return pictureBox1.Size;}
		}


        public void ShowImage(Bitmap img)
        {
            pictureBox1.Image = img;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            remote.MouseClick();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            remote.MouseMove(e.X, e.Y);
        }


        private void disconnect_Btn_Click(object sender, EventArgs e)
        {
            remote.Disconnect();
			Hide();
			Program.MainForm.Show();
        }
		public void Disconnected()
		{
			MessageBox.Show("Broadcaster disconnected!");
			Hide();
			Program.MainForm.Show();
		}

		private void StreamForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			remote.Disconnect();
			Hide();
			Program.MainForm.Show();
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			if (TopMost == false)
			{
				pictureBox1.SendToBack();
				panel1.Width = 2;
				toolStrip1.Hide();
				FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
				TopMost = true;
				WindowState = FormWindowState.Maximized;
			}
			else
			{
				WindowState = FormWindowState.Normal;
				TopMost = false;
				FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
				toolStrip1.Show();
				panel1.Width = 36;
				pictureBox1.BringToFront();
			}
		}

		private void panel1_MouseEnter(object sender, EventArgs e)
		{
			toolStrip1.Show();
			panel1.Width = 36;
		}

		private void panel1_MouseLeave(object sender, EventArgs e)
		{
			if (TopMost)
			{
				panel1.Width = 2;
				toolStrip1.Hide();
			}
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			remote.SetUseJPEG(toolStripButton3.Checked);
		}

		private void resolutionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			foreach(var item in toolStripDropDownButton1.DropDownItems)
			{
				(item as ToolStripMenuItem).Checked = false;
			}
			var btn = sender as ToolStripMenuItem;
			btn.Checked = true;
			remote.SetResolution(int.Parse(btn.Tag.ToString()));
		}
	}



	public interface IStreamForm : IInvokable
	{
		void ShowImage(Bitmap img);
		Size ImageSize { get; }
		void Disconnected();
	}
}