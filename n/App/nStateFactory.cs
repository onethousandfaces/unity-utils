using System;

namespace n.App
{
	/** Return a global instance of the application state */
	public interface nStateFactory
	{
		/** Return the global application state */
		object State { get; }
	}
}

