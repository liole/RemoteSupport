using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteSupport.Server
{
	class EmptyLogger : ILogger
	{
		public void OnConnected(string clientId)
		{
		}

		public void OnDisconnected(string clientId, bool stopCalled)
		{
		}

		public void OnMethodCalled(string methodName, params object[] args)
		{
		}
	}
}
