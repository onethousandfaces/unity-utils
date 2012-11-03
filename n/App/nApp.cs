using System;
using System.Collections.Generic;
using n.Platform;
using System.Reflection;

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
		public T Get<T> (nContext context)
    {
      MethodInfo method = typeof(nResolver).GetMethod ("Resolve");
      MethodInfo item = method.MakeGenericMethod (new Type[] { typeof(T) });
      var rtn = (T) item.Invoke (_resolver, null);

      /* Attach context to controllers */
      method = typeof(T).GetMethod ("SetContext");
      if (method != null) {
        method.Invoke(rtn, new object[] { context });
      }

			return rtn;
		}
	}
}

