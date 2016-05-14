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
            txtPrintRecMess.Clear();
		}

        private void btnSend_Click(object sender, EventArgs e)
        {
            string str = txtSendMessage.Text;
            chat.SendMessage(str);
            txtSendMessage.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }

    public interface IChatForm
	{

    }
}
