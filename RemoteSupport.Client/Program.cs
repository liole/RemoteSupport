﻿using RemoteSupport.Client.Controllers;
using RemoteSupport.Client.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteSupport.Client
{
	static class Program
	{
		public static ConnectionController ConnectionController { get; set; }
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			ConnectionController = new ConnectionController();
			Application.Run(new MainForm());
		}
	}
}
