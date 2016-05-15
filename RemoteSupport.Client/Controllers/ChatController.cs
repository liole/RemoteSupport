using RemoteSupport.Client.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using System.Windows.Forms;

namespace RemoteSupport.Client.Controllers
{
	public class ChatController
	{
		private IChatForm chatForm;

		public ChatController(IChatForm chatForm)
		{
			this.chatForm = chatForm;

			Program.ConnectionController.CommandHub.On("SendMessage", (Action<string, string>)this.ReceiveMessage);
		}

  

        public void ReceiveMessage(string user, string message)
		{
			try
			{
				Program.StatusForm.Invoke((Action<object, EventArgs>)Program.StatusForm.button2_Click, this, null);
			}
			catch (Exception)
			{
				Program.StreamForm.Invoke((Action<object, EventArgs>)Program.StreamForm.toolStripButton4_Click, this, null);
			}
            string tmpStr = (@" \b " + user + @" \b0 : " + message);
			if (user == chatForm.UserName)
			{
				tmpStr = @"\i Me \i0 : " + message;
			}
			chatForm.Invoke((Action<string>)chatForm.AppendLine, tmpStr);

        }

       

		public void SendMessage(string message)
        { 
			Program.ConnectionController.CommandHub.Invoke("SendMessage", message);
		}
	}
}
