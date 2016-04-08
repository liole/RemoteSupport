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
			var userName = ActiveUsers.FirstOrDefault(u => u.Value == Context.ConnectionId).Key;
			ActiveUsers.Remove(userName);
			Logger.OnDisconnected(Context.ConnectionId, stopCalled);
			return base.OnDisconnected(stopCalled);
		}

		// userName -> connectionId
		public static Dictionary<string, string> ActiveUsers { get; set; }
		public static List<BroadcastStatus> Broadcasts { get; set; }

		static RSHub()
		{
			ActiveUsers = new Dictionary<string, string>();
			Broadcasts = new List<BroadcastStatus>();
		}

		public void ChangeUserName (string userName)
		{
			Logger.OnMethodCalled("ChangeUserName", userName);
			if (ActiveUsers.ContainsKey(userName))
			{
				if (ActiveUsers[userName] != Context.ConnectionId)
				{
					Clients.Caller.LoginStatusChanged(false);
				}
				// else user name was the same
			}
			else
			{
				if (ActiveUsers.ContainsValue(Context.ConnectionId))
				{
					var oldUserName = ActiveUsers.FirstOrDefault(u => u.Value == Context.ConnectionId).Key;
					ActiveUsers.Remove(oldUserName);
				}
				ActiveUsers[userName] = Context.ConnectionId;
				Clients.Caller.LoginStatusChanged(true);
			}
		}

		public void AskForPermission(string userName)
		{
			Logger.OnMethodCalled("AskForPermission", userName);
			if (ActiveUsers.ContainsKey(userName))
			{
				var connectionId = ActiveUsers[userName];
				var broadcast = Broadcasts.FirstOrDefault(b => b.Broadcaster == connectionId);
				if (broadcast == null)
				{
					broadcast = new BroadcastStatus() { 
						Broadcaster = connectionId,
						Active = false
					};
					Broadcasts.Add(broadcast);
				}
				broadcast.Pending = Context.ConnectionId;
			}
			else
			{
				Clients.Caller.UserNotFound();
			}
		}

		public void StartStream()
		{
			Logger.OnMethodCalled("StartStream");
			var broadcast = Broadcasts.FirstOrDefault(b => b.Broadcaster == Context.ConnectionId);
			
			if (broadcast.Pending != null)
			{
				Clients.Client(broadcast.Pending).AccessAllowed();
				broadcast.Viewers.Add(broadcast.Pending);
				Groups.Add(broadcast.Pending, broadcast.Broadcaster);
				broadcast.Pending = null;
			}
			broadcast.Active = true;
		}

		public void DenyAccess()
		{
			Logger.OnMethodCalled("DenyAccess");
			var broadcast = Broadcasts.FirstOrDefault(b => b.Broadcaster == Context.ConnectionId);

			if (broadcast.Pending != null)
			{
				Clients.Client(broadcast.Pending).AccessDenied();
				broadcast.Pending = null;
			}
		}

		public void SendImage(object image)
		{
			Logger.OnMethodCalled("SendImage", image);
			Clients.Group(Context.ConnectionId).ShowImage(image);
		}

		public void MoveMouse (int x, int y)
		{
			Logger.OnMethodCalled("MoveMouse", x, y);
			var broadcast = Broadcasts.FirstOrDefault(b => b.Viewers.Contains(Context.ConnectionId));

			if (broadcast != null)
			{
				Clients.Client(broadcast.Broadcaster).MoveMouse(x, y);
			}
		}

		public void ClickMouse()
		{
			Logger.OnMethodCalled("ClickMouse");
			var broadcast = Broadcasts.FirstOrDefault(b => b.Viewers.Contains(Context.ConnectionId));

			if (broadcast != null)
			{
				Clients.Client(broadcast.Broadcaster).ClickMouse();
			}
		}

		public void Disconnect()
		{
			// for only one viewer!
			Logger.OnMethodCalled("Disconnect");
			var broadcast = Broadcasts.FirstOrDefault(b => b.Broadcaster == Context.ConnectionId);
			if (broadcast != null)
			{
				Clients.Group(Context.ConnectionId).BroadcasterDisconnected();
				Broadcasts.Remove(broadcast);
			}
			broadcast = Broadcasts.FirstOrDefault(b => b.Viewers.Contains(Context.ConnectionId));

			if (broadcast != null)
			{
				Clients.Client(broadcast.Broadcaster).ClientDisconnected();
			}
		}
	}
}
