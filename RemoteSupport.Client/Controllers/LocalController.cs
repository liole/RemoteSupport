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
using System.Net.Http;
using System.Drawing.Imaging;

namespace RemoteSupport.Client.Controllers
{
	public class LocalController
	{
		public static Size DefaultSize { get { return new Size(800, 450); } }
		private ILoginForm loginForm;
        public float kw, kh;
        

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint cButtons, uint dwExtraInfo);

		public LocalController (ILoginForm loginForm)
		{
			this.loginForm = loginForm;
            kw = (float)Screen.PrimaryScreen.Bounds.Width / DefaultSize.Width;
            kh = (float)Screen.PrimaryScreen.Bounds.Height / DefaultSize.Height;
            //?
            Program.ConnectionController.CommandHub.On("NewConnection", (Action<string>)this.NewConnection);
			Program.ConnectionController.CommandHub.On("MoveMouse", (Action<int, int>)this.MoveMouse);
			Program.ConnectionController.CommandHub.On("ClickMouse", (Action)this.ClickMouse);
			Program.ConnectionController.CommandHub.On("RequestImage", (Action)this.SendImage);
			Program.ConnectionController.ImageHub.On("ClientDisconnected", (Action)this.ClientDisconnected);
		}

		public void Disconnect()
		{
            Program.ConnectionController.CommandHub.Invoke("Disconnect");
		}

		public void NewConnection(string remoteUserName)
		{
			loginForm.Invoke((Action<string>)loginForm.AskForPermission, remoteUserName);
			//loginForm.AskForPermission(remoteUserName);
		}

		public void StartStream()
		{
			SendImage();
		}

		public void SendImage()
		{
			Program.ConnectionController.CommandHub.Invoke("StartStream");
			Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
			Graphics graphics = Graphics.FromImage(printscreen as Image);
			graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
			var k = 9; // max experimental
			printscreen = new Bitmap(printscreen, new Size(16 * k, 9 * k));
			System.IO.MemoryStream stream = new System.IO.MemoryStream();
			printscreen.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
			byte[] imageBytes = stream.ToArray();
			string base64String = Convert.ToBase64String(imageBytes);
			Program.ConnectionController.ImageHub.Invoke("SendImage", base64String);
		}

		public void DenyAccess()
		{
            Program.ConnectionController.CommandHub.Invoke("DenyAccess");
		}

		public void MoveMouse(int x, int y)
		{
			//int kx = k * x;
			//...
			Cursor.Position = new Point((int)(x*kw), (int)(y*kh));
            //mouse_event(0x80 | 0x01, x * kw, y * kh, 0, 0);
		}

        public void ClickMouse()
        {
            mouse_event(0x02 | 0x04, 0, 0, 0, 0);
        }

		public void ClientDisconnected()
		{
			loginForm.Invoke((Action)loginForm.Disconnected);
		}
	}
}
