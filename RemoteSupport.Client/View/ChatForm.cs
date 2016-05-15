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

		public string UserName { get; set; }

		private string rtfInner = "";

		public ChatForm()
		{
			InitializeComponent();
			chat = new ChatController(this);
			txtSendMessage.GotFocus += txtSendMessage_GotFocus;
			txtSendMessage.LostFocus += txtSendMessage_LostFocus;
			txtSendMessage_LostFocus(this, null);
		}		

		private string placeholder = "Your message ...";

		void txtSendMessage_LostFocus(object sender, EventArgs e)
		{
			if(String.IsNullOrWhiteSpace(txtSendMessage.Text))
			{
				txtSendMessage.ForeColor = Color.Gray;
				txtSendMessage.Text = placeholder;
			}
		}

		void txtSendMessage_GotFocus(object sender, EventArgs e)
		{
			if (txtSendMessage.ForeColor == Color.Gray)
			{
				txtSendMessage.ForeColor = Color.Black;
				txtSendMessage.Text = "";
			}
		}

		public void ApplyChanges()
		{
			richTextBox1.Rtf = @"{\rtf1\utf8 " + rtfInner + @" }";
		}

		public void AppendLine(string rtfText)
		{
			rtfInner = rtfText +  @" \line " + rtfInner;
			ApplyChanges();
		}

		public void Clear()
		{
			rtfInner = "";
			ApplyChanges();
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

		private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			Hide();
		}
    }

    public interface IChatForm : IInvokable
	{
		void AppendLine(string line);
		string UserName { get; set; }
    }
}
