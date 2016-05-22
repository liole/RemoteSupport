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

		public string UserName { get; set; }

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
			centerLabel.Hide();
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
			Program.ChatForm.Hide();
			Program.MainForm.Show();
        }
		public void Disconnected()
		{
			MessageBox.Show("Broadcaster disconnected!");
			Hide();
			Program.ChatForm.Hide();
			Program.StatusForm.HideStatus();
			Program.MainForm.Show();
		}

		private void StreamForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			remote.Disconnect();
			Hide();
			Program.ChatForm.Hide();
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

		public void ShowMessage(string msg)
		{
			centerLabel.Show();
			centerLabel.Text = msg;
		}

		public void AccessDenied()
		{
			ShowMessage("Access denied!");
		}

		private void StreamForm_Shown(object sender, EventArgs e)
		{
			ShowMessage("Connecting ...");
		}

		private void pictureBox1_DoubleClick(object sender, EventArgs e)
		{
			remote.MouseDoubleClick();
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			remote.MouseDown();
		}

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			remote.MouseUp();
		}

		public void toolStripButton4_Click(object sender, EventArgs e)
		{
			Program.ChatForm.UserName = UserName;
			Program.ChatForm.Show();
		}

		private void fpsToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			foreach (var item in toolStripDropDownButton2.DropDownItems)
			{
				(item as ToolStripMenuItem).Checked = false;
			}
			var btn = sender as ToolStripMenuItem;
			btn.Checked = true;
			remote.SetFPS(int.Parse(btn.Tag.ToString()));
		}

		private void StreamForm_Resize(object sender, EventArgs e)
		{
			int sizeIndex;
			if (!int.TryParse(
				toolStripDropDownButton1.DropDownItems
				.OfType<ToolStripMenuItem>()
				.FirstOrDefault(m => m.Checked)
				.Tag.ToString(),
				out sizeIndex))
			{
				return;
			}
			var size = pictureBox1.Size;
			var newSize = RemoteController.sizes
				.FirstOrDefault(s => s.Width >= size.Width || s.Height >= size.Height);
			if (newSize == null)
			{
				newSize = RemoteController.sizes.Last();
			}
			var newIndex = RemoteController.sizes.ToList().IndexOf(newSize);
			if (newIndex > 0 && newIndex != sizeIndex)
			{
				//remote.SetResolution(newIndex);
				toolStripDropDownButton1.DropDownItems
				.OfType<ToolStripMenuItem>()
				.FirstOrDefault(m => m.Tag.ToString() == newIndex.ToString()).PerformClick();
			}
		}
	}



	public interface IStreamForm : IInvokable
	{
		void ShowImage(Bitmap img);
		Size ImageSize { get; }
		void Disconnected();
		void AccessDenied();
		string UserName { get; set; }
	}
}