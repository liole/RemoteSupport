using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using RemoteSupport.Client.Controllers;

namespace RemoteSupport.Client.View
{
	public partial class MainForm : Form, ILoginForm
	{
		private IHubProxy HubProxy { get; set; }
		
		private HubConnection Connection { get; set; }

		public LoginController login;
        private bool firstTime = false;

        public MainForm()
		{
			InitializeComponent();
			login = new LoginController(this);
            userNameTxt.Text = login.PCName();
            connectBtn.Enabled = false;
            firstTime = true;
            //ChangeStatus("Ready to connect", true);
		}

		public void ShowMessage(string msg)
		{
			MessageBox.Show(msg);
		}

		//private async void ConnectAsync()
		//{
		//	Connection = new HubConnection(ServerURI);
		//	Connection.Closed += Connection_Closed;
		//	HubProxy = Connection.CreateHubProxy("RSHub");
		//	HubProxy.On("Message", (Action<string>)this.ShowMessage);

		//	try
		//	{
		//		testButton.Enabled = false;
		//		testButton.Text = "Connecting...";
		//		await Connection.Start();
		//	}
		//	catch (HttpRequestException)
		//	{
		//		testButton.Text = "Unable to connect";
		//		return;
		//	}

		//	testButton.Enabled = true;
		//	testButton.Text = "TEST";
		//}

		private void MainForm_Load(object sender, EventArgs e)
		{
			//ConnectAsync();
		}

		void Connection_Closed()
		{
			//this.Invoke((Action)(() =>
			//{
			//	testButton.Text = "Disconnected";
			//	testButton.Enabled = false;
			//}));
		}

		private void testButton_Click(object sender, EventArgs e)
		{
			HubProxy.Invoke("Send", "OK");
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Connection != null)
			{
				Connection.Stop();
				Connection.Dispose();
			}
		}



		public void LoginStatusChanged(bool status)
		{
            if (!firstTime)
            {
                if (!status)
                {
                    MessageBox.Show("ERRROR");
                }
                else
                {
                    MessageBox.Show("Changed");
                }
            }
            firstTime = false;
		}


		//void ILoginForm.LoginStatusChanged(bool status)
		//{
		//	throw new NotImplementedException();
		//}

		public void AskForPermission(string remoteUserName)
		{
			//var result = permissionDialog.ShowDialog();
			//if (result == allow)
			Hide();
			//statusForm.UserName = remoteUserName;
			//statusFrom.Show();
			//localController.StartStream();
			//else
			//localController.DenyAccess();
		}


		public void ChangeStatus(string status, bool error)
		{
            if (status ==  "Ready to connection")
            {
                StatusValueLbl.Text = "Ready to connection";
                connectBtn.Enabled = true;
            }
            else
            {
                StatusValueLbl.Text = status;
            }
          //  throw new NotImplementedException();
		}

        private void changeBtn_Click(object sender, EventArgs e)
        {
            login.TryChange(userNameTxt.Text);
        }
    }

    public interface ILoginForm: IInvokable
	{
		void LoginStatusChanged(bool status);
		void AskForPermission(string remoteUserName);
		void ChangeStatus(string status, bool error);
	}
}
