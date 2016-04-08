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
        }
	}



	public interface IStreamForm
	{
		void ShowImage(Bitmap img);
		Size ImageSize { get; }
	}
}