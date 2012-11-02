using System;
using n.App;
using System.Collections.Generic;

namespace n.Platform
{
	/** Platform bindings for basic persistence operations */
	public interface nDb
	{
    /** Setup the database to accept records of a particular */
    bool Setup<T>() where T : nDbRecord;
    
    /** Save a new db record */
    bool Insert(nDbRecord record);
    
    /** Update an existing db record */
    bool Update(nDbRecord record);
    
    /** Delete an existing db record */
    bool Delete(nDbRecord record);
    
    /** Return a count of records */
    int Count<T>() where T : nDbRecord;
    
    /** Get a specific db record */
    T Get<T>(long id) where T : nDbRecord;
    
    /** Get a specific db record */
    IEnumerable<T> All<T>(long offset, long limit) where T : nDbRecord;
    
    /** Delete all records of a given type */
    void Clear<T>() where T : nDbRecord;
	}
}

