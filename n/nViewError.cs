using System;
using System.Collections.Generic;

namespace n
{
	public class nViewError
	{
    /** Summary of this error */
		public string Message { get; set; }

    /** The exception for this error, if any */
		public Exception Error { get; set; }
    
    public nViewError(string message) {
      Message = message;
      Error = null;
    }

    public nViewError (string message, Exception e)
    {
      Message = message;
      Error = e;
    }
    
		public override string ToString()
		{
			var rtn = "";
			if (Error != null) 
				rtn = string.Format ("[nViewError: Message={1}, Error={2}]", Message, Error);
			else
				rtn = string.Format ("[nViewError: Message={1}", Message);
			return rtn;
		}
	}
}

