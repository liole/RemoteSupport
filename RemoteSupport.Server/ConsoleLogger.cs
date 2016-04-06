using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteSupport.Server
{
	class ConsoleLogger : ILogger
	{
		public void OnConnected(string clientId)
		{
			Console.WriteLine("+ Client connected: {0}", clientId);
		}

		public void OnDisconnected(string clientId, bool stopCalled)
		{
			Console.WriteLine("- Client disconnected({1}): {0}", clientId, stopCalled ? "manual" : "timeout");
		}

		public void OnMethodCalled(string methodName, params object[] args)
		{
			Console.WriteLine("> {0}({1});", methodName, string.Join(", ", args));
		}
	}
}
