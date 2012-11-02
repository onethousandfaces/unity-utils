using System;
using System.Collections.Generic;
using n.Platform;

namespace n
{
	/** Container to hold impl specific activity navigation data */
	public class nAction
	{
    /** 
     * The id of the view to use; the dispatcher must magically 
     * know how to convert this into something useful like a Type
     */
    public string Id { get; set; }
    
    /** The context object associated with this request */
    public nContext Context { get; set; }
	}
}

