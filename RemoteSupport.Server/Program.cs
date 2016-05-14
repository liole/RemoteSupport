using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;
using Microsoft.Owin.Hosting;

namespace RemoteSupport.Server
{
	class Program
	{
		public static string ServerURI = "http://localhost";

		static void Main(string[] args)
		{
			RSHub.Logger = new ConsoleLogger();
			Console.WriteLine("Starting server...");
			using (WebApp.Start(ServerURI))
			{
				Console.WriteLine("Server running at {0}", ServerURI);
				Console.WriteLine("Press any key to stop it.");
				Console.WriteLine();
				Console.WriteLine("<Server log>");
				Console.ReadKey();
			}
			Console.WriteLine("Server stopped.");
		}
	}
}
