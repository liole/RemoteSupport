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
using RemoteSupport.Client.Helpers;

namespace RemoteSupport.Client.Controllers
{
	public class LocalController
	{
		public bool AllowControl { get; set; }

		public static Size ImageSize { get; set; }
		public static int MaxPartSize = 3000000;
		private ILoginForm loginForm;
        public float kw, kh;

		private Bitmap prevImage = null;
		private Timer timer = new Timer();

		public static int intervalsCount = 5;
		private long prevTime = 0;
		private List<int> intervals = new List<int>();

		public bool useJPEG = false;
        

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint cButtons, uint dwExtraInfo);

		public LocalController (ILoginForm loginForm)
		{
			this.loginForm = loginForm;

			ImageSize = new Size(800, 450);
			timer.Interval = 1000/15;
			timer.Tick += timer_Tick;

            //?
            Program.ConnectionController.CommandHub.On("NewConnection", (Action<string>)this.NewConnection);
			Program.ConnectionController.CommandHub.On("MoveMouse", (Action<int, int>)this.MoveMouse);
			Program.ConnectionController.CommandHub.On("ClickMouse", (Action<int>)this.ClickMouse);
			Program.ConnectionController.CommandHub.On("RequestImage", (Action)this.RequestImage);
			Program.ConnectionController.ImageHub.On("ClientDisconnected", (Action)this.ClientDisconnected);
			Program.ConnectionController.CommandHub.On("SetUseJPEG", use => useJPEG = use);
			Program.ConnectionController.CommandHub.On("SetResolution", (Action<int, int>)(
				(w, h) => ImageSize = new Size(w, h)));
			Program.ConnectionController.CommandHub.On("SetFPS", fps => timer.Interval = 1000/fps);
		}

		void timer_Tick(object sender, EventArgs e)
		{
			SendImage();
		}

		public void Disconnect()
		{
			timer.Stop();
			prevImage = null;
			intervals = new List<int>();
            Program.ConnectionController.CommandHub.Invoke("Disconnect");
		}

		public void NewConnection(string remoteUserName)
		{
			loginForm.Invoke((Action<string>)loginForm.AskForPermission, remoteUserName);
			//loginForm.AskForPermission(remoteUserName);
		}

		public void RequestImage()
		{
			/*
			var currTime = DateTime.Now.Ticks;
			intervals.Insert(0, (int)((currTime - prevTime) / TimeSpan.TicksPerMillisecond));
			if (intervals.Count > intervalsCount)
			{
				intervals = intervals.Take(intervalsCount).ToList();
			}
			timer.Interval = (int)intervals.Average();
			 * */
		}

		public void StartStream()
		{
			Program.ConnectionController.CommandHub.Invoke("StartStream");
			timer.Start();
			SendImage();
		}

		public void SendImage()
		{
			Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
			Graphics graphics = Graphics.FromImage(printscreen as Image);
			graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
			var cursor = System.Windows.Forms.Cursor.Position;
			var bounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Location;
			var pos = new Point(cursor.X - bounds.X, cursor.Y - bounds.Y);
			if (System.Windows.Forms.Cursor.Current != null)
			{
				var CurBounds = new System.Drawing.Rectangle(pos, System.Windows.Forms.Cursor.Current.Size);
				System.Windows.Forms.Cursors.Default.Draw(graphics, CurBounds);
			}
			printscreen = new Bitmap(printscreen, ImageSize);
			printscreen = printscreen.Clone(new Rectangle(0, 0, printscreen.Width, printscreen.Height), PixelFormat.Format16bppRgb555);
			
			Rectangle diffRect = new Rectangle(-1, -1, printscreen.Width, printscreen.Height);

			if (prevImage != null)
			{
				if (prevImage.Width == printscreen.Width && prevImage.Height == printscreen.Height)
				{
					var rect = ImageHelper.DiffBounds(prevImage, printscreen);
					if (rect != null)
					{
						diffRect = (Rectangle)rect;
					}
					else
					{
						return;
					}
				}
			}
			 
			prevImage = printscreen;

			if (diffRect.X != -1)
			{
				printscreen = printscreen.Clone(diffRect, PixelFormat.Format16bppRgb555);
			}
			
			System.IO.MemoryStream stream = new System.IO.MemoryStream();
			if (!useJPEG)
			{
				printscreen.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
			}
			else
			{
				ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
				System.Drawing.Imaging.Encoder myEncoder =
					System.Drawing.Imaging.Encoder.Quality;
				EncoderParameters myEncoderParameters = new EncoderParameters(1);
				EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 30L);
				myEncoderParameters.Param[0] = myEncoderParameter;
				printscreen.Save(stream, jgpEncoder, myEncoderParameters);
			}

			byte[] imageBytes = stream.ToArray();
			string base64String = Convert.ToBase64String(imageBytes);
			int parts = (int)Math.Ceiling((float)base64String.Length / MaxPartSize);
			prevTime = DateTime.Now.Ticks;
			Program.ConnectionController.ImageHub.Invoke("StartSendingImage", parts, diffRect.X, diffRect.Y);

			for (int i = 0; i < parts; ++i)
			{
				string partImage = "";
				if (i == parts - 1)
				{
					partImage = base64String.Substring(i * MaxPartSize);
				}
				else
				{
					partImage = base64String.Substring(i * MaxPartSize, MaxPartSize);
				}
				Program.ConnectionController.ImageHub.Invoke("SendImage", partImage, i);
			}
		}

		public void DenyAccess()
		{
            Program.ConnectionController.CommandHub.Invoke("DenyAccess");
		}

		public void MoveMouse(int x, int y)
		{
			if (!AllowControl)
			{
				return;
			}
			//int kx = k * x;
			//...
			kw = (float)Screen.PrimaryScreen.Bounds.Width / ImageSize.Width;
			kh = (float)Screen.PrimaryScreen.Bounds.Height / ImageSize.Height;
			Cursor.Position = new Point((int)(x*kw), (int)(y*kh));
			//Cursor.Position = new Point(x, y);
            //mouse_event(0x80 | 0x01, x * kw, y * kh, 0, 0);
		}

		private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
		private const uint MOUSEEVENTF_LEFTUP = 0x04;
		private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
		private const uint MOUSEEVENTF_RIGHTUP = 0x10;

        public void ClickMouse(int clickType)
        {
			if (!AllowControl)
			{
				return;
			}
			switch (clickType)
			{
				case 0:
					mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
					break;
				case 1:
					mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
					break;
				case 2:
					mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
					break;
				case 3:
					mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
					mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
					break;
			}
        }

		public void ClientDisconnected()
		{
			timer.Stop();
			prevImage = null;
			intervals = new List<int>();
			loginForm.Invoke((Action)loginForm.Disconnected);
		}

		private ImageCodecInfo GetEncoder(ImageFormat format)
		{

			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

			foreach (ImageCodecInfo codec in codecs)
			{
				if (codec.FormatID == format.Guid)
				{
					return codec;
				}
			}
			return null;
		}
	}
}
