﻿using Microsoft.AspNet.SignalR.Client;
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
		private HubConnection connection;
		private IHubProxy proxy;

		public IHubProxy CommandHub { get { return proxy; } }
		public IHubProxy ImageHub { get { return proxy; } }

		const string ServerURI = "http://localhost:51001/signalr";

		public event EventHandler ConnectionSucceded;
		public event EventHandler ConnectionFailed;

		public  async void ConnectAsync()
		{
			connection = new HubConnection(ServerURI);
			//connection.Closed += Connection_Closed;
			proxy = connection.CreateHubProxy("RSHub");

			try
			{
				await connection.Start();
			}
			catch (HttpRequestException)
			{
				if (ConnectionFailed != null)
				{
					ConnectionFailed(this, null);
				}
			}

			if (ConnectionSucceded != null)
			{
				ConnectionSucceded(this, null);
			}
		}

		public void Dispose ()
		{
			connection.Dispose();
		}
	}
}
