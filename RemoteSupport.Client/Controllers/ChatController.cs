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
			MessageBox.Show(user + ":" + message);
			//TODO: show message on form
		}

		public void SendMessage(string message)
		{
			Program.ConnectionController.CommandHub.Invoke("SendMessage", message);
		}
	}
}
