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
	}
}
