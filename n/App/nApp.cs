using System;
using System.Collections.Generic;
using n.Platform;

namespace n.App
{

	/** The target application needs to implement and create an instance of this to use. */
	public abstract class nApp
	{
		public nApp() {
			setup(_resolver);
		}

		/** Bind service details for the application. */
		protected abstract void setup(nResolver resolver);

		/** The resolver to use for everything */
		private nResolver _resolver = new nResolver();

		/** Return a controller instance */
		public T Get<T> (nContext context) where T : nController
		{
			var rtn = _resolver.Resolve<T>();
			rtn.SetContext(context);
			return rtn;
		}
	}
}

