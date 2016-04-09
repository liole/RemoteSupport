using RemoteSupport.Client.View;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Client;
using System.Drawing;
using System.Net.Http;
using System.Drawing.Imaging;

namespace RemoteSupport.Client.Controllers
{
	public class LocalController
	{
		public static Size DefaultSize { get { return new Size(800, 450); } }
		private ILoginForm loginForm;
        public int kw, kh;
        

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint cButtons, uint dwExtraInfo);

		public LocalController (ILoginForm loginForm)
		{
			this.loginForm = loginForm;
            kw = Screen.PrimaryScreen.Bounds.Width / DefaultSize.Width;
            kh = Screen.PrimaryScreen.Bounds.Height / DefaultSize.Height;
            //?
            Program.ConnectionController.CommandHub.On("NewConnection", (Action<string>)this.NewConnection);
            Program.ConnectionController.CommandHub.On("MoveMouse", (Action<int, int>)this.MoveMouse);
            Program.ConnectionController.ConnectAsync();

		}

		public void Disconnect()
		{
            Program.ConnectionController.CommandHub.Invoke("Disconnect");
		}

		public void NewConnection(string remoteUserName)
		{
			loginForm.AskForPermission(remoteUserName);
		}

		public void StartStream()
		{
			//send image
            Program.ConnectionController.CommandHub.Invoke("StartStream");
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            Program.ConnectionController.ImageHub.Invoke("SendImage", new Bitmap(printscreen, DefaultSize));
		}

		public void DenyAccess()
		{
            Program.ConnectionController.CommandHub.Invoke("DenyAccess");
		}

		public void MoveMouse(int x, int y)
		{
			//int kx = k * x;
			//...
            mouse_event(0x80 | 0x01, x * kw, y * kh, 0, 0);
		}

        public void ClickMouse()
        {
            mouse_event(0x02 | 0x04, 0, 0, 0, 0);
        }
	}
}
