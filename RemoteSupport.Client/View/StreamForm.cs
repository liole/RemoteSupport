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
	public partial class StreamForm : Form, IStreamForm
	{
		public StreamForm()
		{
			InitializeComponent();
		}

		public void ShowImage(Bitmap img)
		{
			throw new NotImplementedException();
		}


		public Size ImageSize
		{
			get { return null;/*return pictureBox.Size*/ }
		}
	}

	public interface IStreamForm
	{
		void ShowImage(Bitmap img);
		Size ImageSize { get; }
	}
}
