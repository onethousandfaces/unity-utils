using System;
using System.Collections.Generic;
using n;

namespace n.App
{
	/** Base type for persistable records */
	public abstract class nDbRecord
	{
    public nDbRecord() {
      Id = -1;
    }
    
    /** The id for this record, or -1 if it is not in the database */
    public long Id { get; set; } 
    
		/** Records should implement this to validate the record */
		protected abstract bool Validate();

		/** Set of errors associated with the object */
		public nDbRecordErrors Errors = new nDbRecordErrors();

		/** If there are any errors */
		public bool Valid { 
			get {
        Validate();
				return !Errors.Any;
			} 
		}
    
    /** Return field info */
    public IEnumerable<nDbRecordField> Fields() {
      return null; // TODO
    }
	}
}

