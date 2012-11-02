using System;
using System.Data;
using System.Collections.Generic;

namespace n.Infrastructure
{
	public abstract class nDbRecord
	{
		/** Records should implement this to validate the record */
		public abstract bool Validate();

		/** Set of errors associated with the object */
		public nDbRecordErrors Errors = new nDbRecordErrors();

		/** If there are any errors */
		public bool Valid { 
			get {
				return !Errors.Any;
			} 
		}
	}
}

