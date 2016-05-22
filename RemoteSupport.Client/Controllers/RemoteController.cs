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

		private Bitmap prevImage = null;
		private string[] imageParts;
		private int partsReceived = 0;
		private Point imagePos;

		public static Size[] sizes = new[] {
			new Size(-1, -1),
			new Size(480, 270),
			new Size(640, 360),
			new Size(800, 450),
			new Size(1024, 576),
			new Size(1280, 720),
			new Size(1366, 768),
			new Size(1920, 1080),
		};
		public static int[] fpss = new[] { -1, 5, 10, 15, 20, 30 };
		private bool needRequestImage = false;

		public RemoteController (IStreamForm streamForm)
		{
			this.streamForm = streamForm;
			Program.ConnectionController.ImageHub.On("StartReceivingImage", (Action<int, int, int>)this.StartReceivingImage);
			Program.ConnectionController.ImageHub.On("ShowImage", (Action<string, int>)this.ReceiveImage);
			Program.ConnectionController.CommandHub.On("BroadcasterDisconnected", (Action)this.BroadcasterDisconnected);
			Program.ConnectionController.ImageHub.On("AccessDenied", (Action)this.AccessDenied);
		}

		private void AccessDenied()
		{
			streamForm.Invoke((Action)streamForm.AccessDenied);
		}

		public void MouseMove(int x, int y)
		{
			if (prevImage == null)
			{
				return;
			}
			var boxSize = streamForm.ImageSize;
			var imgSize = prevImage.Size;
			var boxRatio = (float)boxSize.Width / boxSize.Height;
			var imgRatio = (float)imgSize.Width / imgSize.Height;
			var posRatio = 1.0f;
			var xShift = 0;
			var yShift = 0;
			if (boxRatio > imgRatio)
			{
				posRatio = (float)imgSize.Height / boxSize.Height;
				var width = (int)(imgSize.Width / posRatio);
				xShift = (boxSize.Width - width) / 2;
			}
			else
			{
				posRatio = (float)imgSize.Width / boxSize.Width;
				var height = (int)(imgSize.Height / posRatio);
				yShift = (boxSize.Height - height) / 2;
			}
			var imgX = (int)((x - xShift)*posRatio);
			var imgY = (int)((y - yShift)*posRatio);
			if (imgX < 0 || imgX > imgSize.Width ||
				imgY < 0 || imgY > imgSize.Height)
			{
				return;
			}
            Program.ConnectionController.CommandHub.Invoke("MoveMouse", imgX, imgY);
		}

        public void MouseClick()
        {
            Program.ConnectionController.CommandHub.Invoke("ClickMouse", 0);
        }

		public void MouseDown()
		{
			Program.ConnectionController.CommandHub.Invoke("ClickMouse", 1);
		}

		public void MouseUp()
		{
			Program.ConnectionController.CommandHub.Invoke("ClickMouse", 2);
		}

		public void MouseDoubleClick()
		{
			Program.ConnectionController.CommandHub.Invoke("ClickMouse", 3);
		}

        public void KeyPress()
        {
            //return new NotImplementedException();
        }

		public void StartReceivingImage(int parts, int x, int y)
		{
			imageParts = new string[parts];
			partsReceived = 0;
			imagePos = new Point(x, y);
		}

        public void ReceiveImage(string image, int part)
        {
			imageParts[part] = image;
			partsReceived++;
			if (partsReceived == imageParts.Length)
			{
				if (needRequestImage)
				{
					Program.ConnectionController.CommandHub.Invoke("RequestImage");
				}
				ShowImage();
			}
        }

		public void ShowImage()
		{
			string image = String.Join("", imageParts);

			Bitmap bmpReturn = null;
			byte[] byteBuffer = Convert.FromBase64String(image);
			MemoryStream memoryStream = new MemoryStream(byteBuffer);

			memoryStream.Position = 0;

			bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);

			memoryStream.Close();

			if (prevImage != null)
			{
				if (imagePos.X != -1)
				{
					var g = Graphics.FromImage(prevImage);
					g.DrawImage(bmpReturn, imagePos);
					bmpReturn = prevImage;
				}
			}
			prevImage = bmpReturn;

			streamForm.Invoke((Action<Bitmap>)streamForm.ShowImage, bmpReturn);
			//streamForm.ShowImage(image as Bitmap);  
			//Program.ConnectionController.CommandHub.Invoke("RequestImage");
		}

        public void Disconnect()
        {
			prevImage = null;
            Program.ConnectionController.CommandHub.Invoke("Disconnect");
        }
		public void BroadcasterDisconnected()
		{
			streamForm.Invoke((Action)streamForm.Disconnected);
		}

		public void SetUseJPEG(bool use)
		{
			Program.ConnectionController.CommandHub.Invoke("SetUseJPEG", use);
		}
		public void SetResolution(int index)
		{
			Program.ConnectionController.CommandHub.Invoke("SetResolution", 
				sizes[index].Width, sizes[index].Height);
		}
		public void SetFPS(int index)
		{
			Program.ConnectionController.CommandHub.Invoke("SetFPS",
				fpss[index]);
			needRequestImage = index == 0;
		}
	}
}
