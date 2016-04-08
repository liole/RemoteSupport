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
		public StreamForm()
		{
			InitializeComponent();
		}


		public void ShowImage(Bitmap img)
		{
            pictureBox1.Image = img;
		}


		public Size ImageSize
		{
			get { return pictureBox1.Size;}
		}


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void disconnect_Btn_Click(object sender, EventArgs e)
        {
            
        }
	}

	public interface IStreamForm
	{
		void ShowImage(Bitmap img);
		Size ImageSize { get; }
	}
}
