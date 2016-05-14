using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
				var pendingClientName = ActiveUsers.FirstOrDefault(u => u.Value == Context.ConnectionId).Key;
				Clients.Client(connectionId).NewConnection(pendingClientName);
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

		public void StartSendingImage(int parts, int x, int y)
		{
			Logger.OnMethodCalled("StartSendingImage", parts, x, y);
			Clients.Group(Context.ConnectionId).StartReceivingImage(parts, x, y);
		}

		public void SendImage(string image, int part)
		{
			Logger.OnMethodCalled("SendImage", "[Base64Image]", part);
			Clients.Group(Context.ConnectionId).ShowImage(image, part);
		}

		public void SetUseJPEG(bool use)
		{
			Logger.OnMethodCalled("SetUserJPEG", use);
			var broadcast = Broadcasts.FirstOrDefault(b => b.Viewers.Contains(Context.ConnectionId));

			if (broadcast != null)
			{
				Clients.Client(broadcast.Broadcaster).SetUseJPEG(use);
			}
		}
		public void SetResolution(int width, int height)
		{
			Logger.OnMethodCalled("SetResolution", width, height);
			var broadcast = Broadcasts.FirstOrDefault(b => b.Viewers.Contains(Context.ConnectionId));

			if (broadcast != null)
			{
				Clients.Client(broadcast.Broadcaster).SetResolution(width, height);
			}
		}
		public void SetFPS(int fps)
		{
			Logger.OnMethodCalled("SetFPS", fps);
			var broadcast = Broadcasts.FirstOrDefault(b => b.Viewers.Contains(Context.ConnectionId));

			if (broadcast != null)
			{
				Clients.Client(broadcast.Broadcaster).SetFPS(fps);
			}
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

		public void ClickMouse(int clickType = 0)
		{
			Logger.OnMethodCalled("ClickMouse");
			var broadcast = Broadcasts.FirstOrDefault(b => b.Viewers.Contains(Context.ConnectionId));

			if (broadcast != null)
			{
				Clients.Client(broadcast.Broadcaster).ClickMouse(clickType);
			}
		}

		public void RequestImage()
		{
			Logger.OnMethodCalled("RequestImage");
			var broadcast = Broadcasts.FirstOrDefault(b => b.Viewers.Contains(Context.ConnectionId));

			if (broadcast != null)
			{
				Clients.Client(broadcast.Broadcaster).RequestImage();
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
				Broadcasts.Remove(broadcast);
			}
		}

		public void SendMessage(string message)
		{
			Logger.OnMethodCalled("SendMessage", message);
			var userName = ActiveUsers.FirstOrDefault(u => u.Value == Context.ConnectionId).Key;
			var broadcast = Broadcasts.FirstOrDefault(b => b.Broadcaster == Context.ConnectionId);
			if (broadcast == null)
			{
				broadcast = Broadcasts.FirstOrDefault(b => b.Viewers.Contains(Context.ConnectionId));
				
			}
			Clients.Group(broadcast.Broadcaster).SendMessage(userName, message);
			if (!broadcast.Viewers.Contains(broadcast.Broadcaster))
			{
				Clients.Client(broadcast.Broadcaster).SendMessage(userName, message);
			}
		}
	}
}
