using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteSupport.Client.View
{
	interface IInvokable
	{
		public object Invoke(Delegate method);
		public object Invoke(Delegate method, params object[] args);
	}
}
