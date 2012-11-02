using System;
using System.Data;

namespace n.Infrastructure
{
	public interface nDb
	{
		IDbConnection Connection { get; }
	}
}

