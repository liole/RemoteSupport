using RemoteSupport.Client.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteSupport.Client.View
{
	public partial class ChatForm : Form, IChatForm
	{
		public ChatController chat;

		public ChatForm()
		{
			InitializeComponent();
			chat = new ChatController(this);
		}

		public void Clear()
		{
			//TODO: clear chat window
		}

		private void button1_Click(object sender, EventArgs e)
		{
			chat.SendMessage("Hello world!");
		}
	}

	public interface IChatForm
	{

	}
}
