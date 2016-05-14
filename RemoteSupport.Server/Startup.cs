using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteSupport.Server
{
	class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			GlobalHost.Configuration.MaxIncomingWebSocketMessageSize = null;
			GlobalHost.Configuration.DefaultMessageBufferSize = 30;
			app.UseCors(CorsOptions.AllowAll);
			app.MapSignalR();
		}
	}
}
