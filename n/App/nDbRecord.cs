using System;
using System.Collections.Generic;

namespace n.App
{
	/** Base type for persistable records */
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

