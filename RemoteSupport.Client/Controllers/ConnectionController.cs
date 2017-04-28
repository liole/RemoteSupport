using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RemoteSupport.Client.Controllers
{
	public class ConnectionController : IDisposable
	{
		public HubConnection connection;
		private IHubProxy proxy;

		public IHubProxy CommandHub { get { return proxy; } }
		public IHubProxy ImageHub { get { return proxy; } }

		public string ServerURI = "http://172.16.4.106:51001";

		public event EventHandler ConnectionSucceded;
		public event EventHandler ConnectionFailed;

		public  async void ConnectAsync()
		{
			if (connection != null)
			{
				return;
			}
			connection = new HubConnection(ServerURI);
			//connection.Closed += Connection_Closed;
			proxy = connection.CreateHubProxy("RSHub");

			try
			{
				await connection.Start();
				if (ConnectionSucceded != null)
				{
					ConnectionSucceded(this, null);
				}
			}
			catch (HttpRequestException)
			{
				if (ConnectionFailed != null)
				{
					ConnectionFailed(this, null);
				}
				connection = null;
			}
		}

		public void Dispose ()
		{
			connection.Stop();
			connection.Dispose();
		}
	}
}
