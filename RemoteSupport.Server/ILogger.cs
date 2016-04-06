using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteSupport.Server
{
	public interface ILogger
	{
		void OnConnected(string clientId);
		void OnDisconnected(string clientId, bool stopCalled);
		void OnMethodCalled(string methodName, params object[] args);
	}
}
