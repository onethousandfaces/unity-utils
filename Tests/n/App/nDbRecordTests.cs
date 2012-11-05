using UnityEngine;
using System.Collections;
using n.Test;
using System.Linq;
using System;

namespace Tests.n.App {
  public class nDbRecordTests : nTestBase {
  
    private MyRecordType setup() {
      var rtn = new MyRecordType() {
        Ref = null,
        Value1 = 1,
        Value2 = 1,
        Value3 = true,
        Value4 = 1,
        Value5 = "1",
        Value6 = "2",
        Value7 = DateTime.Now
      };
      return rtn;
    }
    
    [nTest]
    public void test_can_create_instance() {
      var instance = setup();
      instance.ShouldNotBe(null);
      instance.Valid.ShouldBe(false);
    }
    
    [nTest]
    public void test_id_is_set_by_default() {
      var instance = setup();
      instance.Id.ShouldBe(-1);
    }
    
    [nTest]
    public void test_can_read_fields() {
      var instance = setup();
      var fields = instance.AsRecordFields();
      foreach (var i in fields) {
        Debug("{0} -- {1}", i.Name, i.Value);
      }
      fields.Any().ShouldBe(true);
      fields.Count().ShouldBe(9); // 8 + 1 for the inbuilt id field
    }
    
    [nTest]
    public void test_can_get_validation_errors() {
      var instance = setup();
      instance.Valid.ShouldBe(false);
      var errors = instance.Errors;
      Debug(errors.Summary);
    }
    
    [nTest]
    public void test_can_fix_validation_errors_and_read_fields() {
      var instance = setup();
      instance.Valid.ShouldBe(false);
      
      instance.Value2 = 5;
      instance.Value6 = "Value6";
      instance.Valid.ShouldBe(true);
      
      var fields = instance.AsRecordFields();
      var value2 = (from f in fields where f.Name == "Value2" select f).First().As<long>();
      var value6 = (from f in fields where f.Name == "Value6" select f).First().As<string>();
      value2.ShouldBe(5);
      value6.ShouldBe("Value6");
    }
  }
}
