using Microsoft.AspNet.SignalR;
using RemoteSupport.Client.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using System.IO;

namespace RemoteSupport.Client.Controllers
{
	public class RemoteController
	{
		private IStreamForm streamForm;

		public RemoteController (IStreamForm streamForm)
		{
			this.streamForm = streamForm;
			Program.ConnectionController.ImageHub.On("ShowImage", (Action<string>)this.ReceiveImage);
			Program.ConnectionController.CommandHub.On("BroadcasterDisconnected", (Action)this.BroadcasterDisconnected);
		}

		public void MouseMove(int x, int y)
		{
            Program.ConnectionController.CommandHub.Invoke("MoveMouse", x, y);
		}

        public void MouseClick()
        {
            Program.ConnectionController.CommandHub.Invoke("ClickMouse");
        }

        public void KeyPress()
        {
            //return new NotImplementedException();
        }

        public void ReceiveImage(string image)
        {
			Bitmap bmpReturn = null;

			byte[] byteBuffer = Convert.FromBase64String(image);
			MemoryStream memoryStream = new MemoryStream(byteBuffer);

			memoryStream.Position = 0;

			bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);

			memoryStream.Close();

			streamForm.Invoke((Action<Bitmap>)streamForm.ShowImage, bmpReturn);
            //streamForm.ShowImage(image as Bitmap);  
			Program.ConnectionController.CommandHub.Invoke("RequestImage");
        }

        public void Disconnect()
        {
            Program.ConnectionController.CommandHub.Invoke("Disconnect");
        }
		public void BroadcasterDisconnected()
		{
			streamForm.Invoke((Action)streamForm.Disconnected);
		}
	}
}
