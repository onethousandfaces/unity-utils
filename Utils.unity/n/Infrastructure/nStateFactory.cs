using System;

namespace n.Infrastructure
{
	/** Return a global instance of the application state */
	public interface nStateFactory
	{
		/** Return the global application state */
		object State { get; }

		/** Return the type binding for a named view */
		Type View(string id);
	}
}

