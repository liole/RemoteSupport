using Microsoft.AspNet.SignalR;
using RemoteSupport.Client.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteSupport.Client.Controllers
{
	public class RemoteController
	{
		private IStreamForm streamForm;

		public RemoteController (IStreamForm streamForm)
		{
;			this.streamForm = streamForm;
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

        public void ReceiveImage(object image)
        {
            streamForm.ShowImage(image as Bitmap);    
        }

        public void Disconnect()
        {
            Program.ConnectionController.CommandHub.Invoke("Disconnect");
        }
	}
}
