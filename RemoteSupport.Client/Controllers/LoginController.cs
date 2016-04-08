using RemoteSupport.Client.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteSupport.Client.Controllers
{
	class LoginController
	{
		private ILoginForm loginForm;

		public LoginController (ILoginForm loginForm)
		{
			this.loginForm = loginForm;
			Program.ConnectionController.ConnectionSucceded += ConnectionSucceded;
			Program.ConnectionController.ConnectionFailed += ConnectionFailed;
			Program.ConnectionController.ConnectAsync();
			//hub.On("loginStatusChanged", this.handle...)
		}
		public void TryChange(string newName)
		{

		}

		public void HandleStatusChange(bool status)
		{
			loginForm.LoginStatusChanged(status);
		}

		public string PCName ()
		{
			return null;
		}

		public void ConnectionSucceded(object sender, EventArgs e)
		{
			loginForm.ChangeStatus("Connected");
		}
		public void ConnectionFailed(object sender, EventArgs e)
		{
			loginForm.ChangeStatus("Unable to connect");
		}
	}
}
