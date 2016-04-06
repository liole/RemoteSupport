using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteSupport.Server
{
	public class RSHub : Hub
	{
		public static ILogger Logger { get; set; }

		public void Send(string message)
		{
			Logger.OnMethodCalled("Send", message);
			Clients.All.Message(message);
		}
		public override Task OnConnected()
		{
			Logger.OnConnected(Context.ConnectionId);
			return base.OnConnected();
		}
		public override Task OnDisconnected(bool stopCalled)
		{
			Logger.OnDisconnected(Context.ConnectionId, stopCalled);
			return base.OnDisconnected(stopCalled);
		}
	}
}
