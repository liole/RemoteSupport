using RemoteSupport.Client.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteSupport.Client.Controllers
{
	class RemoteController
	{
		private IStreamForm streamForm;

		public RemoteController (IStreamForm streamForm)
		{
			this.streamForm = streamForm;
		}

		public void MouseMove(int x, int y)
		{
			
		}

		public void Connect(string remoteUserName)
		{

		}
	}
}
