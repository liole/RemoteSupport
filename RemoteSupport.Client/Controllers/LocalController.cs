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
        private IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://localhost:51001/signalr";
        private HubConnection Connection { get; set; }
        private async void ConnectAsync()
        {
            Connection = new HubConnection(ServerURI);
            HubProxy = Connection.CreateHubProxy("RSHub");
            HubProxy.On("NewConnection", (Action<string>)this.NewConnection);
            HubProxy.On("MoveMouse", (Action<int, int>)this.MoveMouse);
            //?
            try
            {
                await Connection.Start();
            }
            catch (HttpRequestException)
            {
                return;
            }

        }

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint cButtons, uint dwExtraInfo);

		public LocalController (ILoginForm loginForm)
		{
			this.loginForm = loginForm;
            kw = Screen.PrimaryScreen.Bounds.Width / DefaultSize.Width;
            kh = Screen.PrimaryScreen.Bounds.Height / DefaultSize.Height;
            //?
            ConnectAsync();
		}

		public void Disconnect()
		{
            HubProxy.Invoke("Disconnect");
		}

		public void NewConnection(string remoteUserName)
		{
			loginForm.AskForPermission(remoteUserName);
		}

		public void StartStream()
		{
			//send image
            HubProxy.Invoke("StartStream");
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            HubProxy.Invoke("SendImage", new Bitmap(printscreen, DefaultSize));
		}

		public void DenyAccess()
		{
            HubProxy.Invoke("DenyAccess");
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
