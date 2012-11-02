using System;
using n.Platform;
using n.App;

namespace n
{
	/** Extend this class for application controllers */
	public abstract class nController
	{
		/** The context from the calling view */
		private nContext _context;

		/** Factory for creating views */
		private nViewFactory _factory;

		/** Raw copy of the global application state */
		protected nStateFactory _stateFactory;

		public nController() {
			var r = new nResolver();
			_factory = r.Resolve<nViewFactory>();
			_stateFactory = r.Resolve<nStateFactory>();
		}

		/** Return a dummy view with no action */
		protected nView View() {
			var rtn = _factory.View();
			return rtn;
		}

		/** Return a view with only a model */
		protected nView View (nModel model)
		{
			var rtn = _factory.View(model, _context);
			return rtn;
		}

		/** Return a view to navigate to the given type */
		protected nView View (string target)
		{
			var rtn = _factory.View(target, _context);
			return rtn;
		}
    
    /** Return an error message */
    protected nView Failed (string message)
    {
      var rtn = _factory.Failed(message);
      return rtn;
    }
    
    /** Return an error message with exception */
    protected nView Failed (string message, Exception error)
    {
      var rtn = _factory.Failed(message, error);
      return rtn;
    }

		/** Set the context the controller will need to use to create views */
		public void SetContext (nContext context)
		{
			_context = context;
		}
	}
}

