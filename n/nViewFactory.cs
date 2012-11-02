using System;

namespace n.Platform
{
  /** Factory to create view instances */
	public class nViewFactory
	{
    private nDispatcher _dispatcher;
    
    public nViewFactory (nDispatcher d)
    {
      _dispatcher = d;
    }
    
    /** Blank view that does nothing except return success */
    public nView View() {
      return new nView(_dispatcher);
    }
    
		/** View for navigating somewhere */
    public nView View(string target, nContext context) {
      var rtn = View();
      rtn.Action = new nAction() {
        Id = target,
        Context = context
      };
      return rtn;
    }

    /** View that returns data */
    public nView View(nModel model, nContext context) {
      var rtn = View();
      rtn.Model = model;
      return rtn;
    }
    
    /** View that is just an error */
    public nView Failed(string message) {
      var rtn = View();
      rtn.Error = new nViewError(message);
      return rtn;
    }
    
    /** View that is an error and exception */
    public nView Failed(string message, Exception e) {
      var rtn = View();
      rtn.Error = new nViewError(message, e);
      return rtn;
    }
	}
}

