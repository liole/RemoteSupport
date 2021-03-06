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
		public static MainForm MainForm { get; set; }
		public static StreamForm StreamForm { get; set; }
		public static StatusForm StatusForm { get; set; }
		public static ChatForm ChatForm { get; set; }
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			ConnectionController = new ConnectionController();
			Program.StatusForm = new StatusForm();
			Program.MainForm = new MainForm();
			Program.StreamForm = new StreamForm();
			Program.ChatForm = new ChatForm();
			Application.Run(Program.MainForm);
		}
	}
}
