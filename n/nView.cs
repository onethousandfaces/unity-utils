using System;
using n.Platform;

namespace n
{
	/** Controller actions should always return a view object */
	public class nView
	{
    public nView (nDispatcher dispatcher)
    {
      _dispatcher = dispatcher;
      Error = null;
    }
    
    /** For activating this view */
    private nDispatcher _dispatcher;
    
    /** If the request was successful */
    public bool Success { get { return Error == null; } }
    
    /** Error message associated with this view, if any */
    public nViewError Error { get; set; }
    
		/** The model returned by the controller */
		public nModel Model { get; set; }

		/** Any navigation information from the controller */
		public nAction Action { get; set; }
    
    /** Perform the action associated with this view. */
    public void Activate () {
      if (Success) {
        try {
          _dispatcher.Dispatch(this);
        }
        catch(Exception e) {
          Error = new nViewError("Failed to dispatch action", e);
        }
      }
    }
	}
}

