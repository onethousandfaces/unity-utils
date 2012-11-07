using System;
using System.Collections.Generic;
using n;
using System.Reflection;

namespace n.App
{
	/** Base type for persistable records */
	public abstract class nDbRecord
	{
    public nDbRecord() {
      Id = -1;
      Errors = new nDbRecordErrors();
    }
    
    /** Records should implement this to validate the record */
    protected abstract void Validate();
    
    /** Fields not to include when reading fields and values */
    private List<string> _ignoredFields = new List<string>() { "Errors", "Valid", "Persisted" };
    
    /** The id for this record, or -1 if it is not in the database */
    public long Id { get; set; } 

		/** Set of errors associated with the object */
		public nDbRecordErrors Errors { get; set; }

		/** If there are any errors */
		public bool Valid { 
			get {
        Errors.Clear();
        Validate();
				return !Errors.Any;
			} 
		}
    
    /** If this object has been persisted */
    public bool Persisted {
      get {
        return Id != -1;
      }
    }
    
    /** Return field info */
    public IEnumerable<nDbRecordField> AsRecordFields()
    {
      var rtn = new List<nDbRecordField>();
      var props = GetType ().GetProperties (BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance);
      foreach (var p in props) {
        var value = p.GetValue (this, new object[] {});
        var type = ParseFieldType(p.PropertyType);
        var name = p.Name;
        if (!_ignoredFields.Contains(name)) {
          var item = new nDbRecordField() {
            Name = name, 
            Value = value,
            Type = type
          };
          rtn.Add(item);
        }
      }
      return rtn;
    }
    
    /** Parse a type as a db field type */
    public nDbRecordFieldType ParseFieldType (Type t)
    {
      if (t == typeof(int)) return nDbRecordFieldType.INT;
      else if (t == typeof(long)) return nDbRecordFieldType.INT;
      else if (t == typeof(long)) return nDbRecordFieldType.LONG;
      else if (t == typeof(bool)) return nDbRecordFieldType.BOOL;
      else if (t == typeof(DateTime)) return nDbRecordFieldType.DATETIME;
      else if (t == typeof(double)) return nDbRecordFieldType.DOUBLE;
      else if (t == typeof(string) || t == typeof(String)) return nDbRecordFieldType.STRING;
      return nDbRecordFieldType.POINTER;
    }
	}
}

