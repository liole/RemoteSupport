using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteSupport.Server
{
	public class BroadcastStatus
	{
		public string Broadcaster { get; set; }
		public List<string> Viewers { get; set; }
		public string Pending { get; set; }
		public bool Active { get; set; }

		public BroadcastStatus()
		{
			Viewers = new List<string>();
		}
	}
}
