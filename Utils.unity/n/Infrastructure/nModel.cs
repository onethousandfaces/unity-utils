using System;

namespace n.Infrastructure
{
	/** Base type for models with helper function */
	public abstract class nModel {
		public T As<T>() where T : nModel {
			return (T) this;
		}
	}
}

