using RemoteSupport.Client.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteSupport.Client.Controllers
{
	public class LocalController
	{
		public static Size DefaultSize { get { return new Size(800, 450); } }
		private ILoginForm loginForm;

		public LocalController (ILoginForm loginForm)
		{
			this.loginForm = loginForm;
		}

		public void Disconnect()
		{

		}

		public void NewConnection(string remoteUserName)
		{
			loginForm.AskForPermission(remoteUserName);
		}

		public void StartStream()
		{
			//send image
		}

		public void DenyAccess()
		{

		}

		public void MoveMouse(int x, int y)
		{
			//int kx = k * x;
			//...
		}

        public void ClickMouse()
        {
            
        }
	}
}
