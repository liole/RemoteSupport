using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;
using Microsoft.Owin.Hosting;
using System.Runtime.InteropServices;

namespace RemoteSupport.Server
{
	class Program
	{

		[DllImport("kernel32.dll")]
		static extern IntPtr GetConsoleWindow();

		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		const int SW_HIDE = 0;
		const int SW_SHOW = 5;

		public static string ServerURI = "http://localhost:51001";

		static void Main(string[] args)
		{
			var handle = GetConsoleWindow();

			// Hide
			//ShowWindow(handle, SW_HIDE);

			RSHub.Logger = new ConsoleLogger(); // new EmptyLogger(); 
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
