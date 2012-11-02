using System;

namespace n.Platform
{
  /** Factory to create view instances for the platform implementation. */
	public interface nViewFactory
	{
    /** View with type only */
    nView View (nViewType type, object context);
    
		/** View with navigation target only */
    nView View (nViewType type, Type target, object context);

    /** View with model only */
    nView View (nViewType type, object model, object context);
                
    /** View with model and navigation target */
    nView View (nViewType type, object model, Type target, object context);
	}
}

