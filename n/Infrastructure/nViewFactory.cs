using System;

namespace n.Infrastructure
{
	/** Creates a view from a set of vargs */
	public interface nViewFactory
	{
		/** Return a new view instance */
		nView View (params object[] args);
	}
}

