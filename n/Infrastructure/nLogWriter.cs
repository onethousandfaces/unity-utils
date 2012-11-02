using System;
using System.Data;

namespace n.Infrastructure
{
	public interface nLogWriter
	{
		void Trace(string message);
	}
}

