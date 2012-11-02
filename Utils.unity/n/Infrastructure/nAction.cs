using System;
using System.Collections.Generic;

namespace n.Infrastructure
{
	/** Container to hold impl specific activity navigation data */
	public class nAction
	{
		/** Properties of the the navigation */
		public IDictionary<string, object> Params = new Dictionary<string, object>();
	}
}

