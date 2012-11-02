using System;
using System.Collections.Generic;

namespace n.Infrastructure
{

	/** The target application needs to implement and create an instance of this to use. */
	public abstract class nApp
	{
		public nApp() {
			setup(_resolver);
			_dispatcher = _resolver.Resolve<nDispatcher>();
		}

		/** 
		 * Bind service details for the application.
		 * <p>
		 * At a minimum the function should bind classes that implement:
		 * IStateFactory, IDispatcher
		 */
		protected abstract void setup(nResolver resolver);

		/** The resolver to use for everything */
		private nResolver _resolver = new nResolver();

		/** The dispatcher to use for everything */
		private nDispatcher _dispatcher;

		/** Return a controller instance */
		public T Controller<T> (object context) where T : nController
		{
			var rtn = _resolver.Resolve<T>();
			rtn.SetContext(context);
			return rtn;
		}

		/** Dispatch a view */
		public void Activiate (nView view)
		{
			if (view.HasAction) {
				_dispatcher.Dispatch(view);
			}
		}
	}
}

