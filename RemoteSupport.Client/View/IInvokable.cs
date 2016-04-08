using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteSupport.Client.View
{
	public interface IInvokable
	{
		object Invoke(Delegate method);
		object Invoke(Delegate method, params object[] args);
	}
}
