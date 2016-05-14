using RemoteSupport.Client.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace RemoteSupport.Client.Controllers
{
	public class LoginController
	{
		private ILoginForm loginForm;

		public LoginController (ILoginForm loginForm)
		{
			this.loginForm = loginForm;
			Program.ConnectionController.ConnectionSucceded += ConnectionSucceded;
			Program.ConnectionController.ConnectionFailed += ConnectionFailed;
			Program.ConnectionController.ConnectAsync();
			Program.ConnectionController.CommandHub.On("LoginStatusChanged", (Action<bool>)this.HandleStatusChange);
			Program.ConnectionController.CommandHub.On("UserNotFound", (Action)this.UserNotFound);
		}
		public void TryChange(string newName)
		{
            Program.ConnectionController.CommandHub.Invoke("ChangeUserName", newName);
		}

		public void HandleStatusChange(bool status)
		{
			loginForm.Invoke((Action<bool>)loginForm.LoginStatusChanged, status);
			//loginForm.LoginStatusChanged(status);
		}

		public void ConnectTo(string userName)
		{
			Program.ConnectionController.CommandHub.Invoke("AskForPermission", userName);
		}

		public string PCName ()
		{
			return Environment.MachineName;
		}

		public void ConnectionSucceded(object sender, EventArgs e)
		{
            TryChange(PCName());
			loginForm.Invoke((Action<string, bool>)loginForm.ChangeStatus, "Ready to connect", false);
			//loginForm.ChangeStatus("Connected", false);
		}
		public void ConnectionFailed(object sender, EventArgs e)
		{
			loginForm.Invoke((Action<string, bool>)loginForm.ChangeStatus, "Unable to connect", true);
			//loginForm.ChangeStatus("Unable to connect", true);
		}
		public void UserNotFound()
		{
			loginForm.Invoke((Action)loginForm.UserNotFound);
			//loginForm.UserNotFound();
		}
	}
}
