//
//  Copyright 2012  douglasl
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;

namespace n.Test
{
  /** Base class for all tests */
  public class nTestBase
  {
    /** The result set for this test */
    public nTestResult Results { get; set; }
    
    /** Log a debug message */
    public void Debug(string message) {
      Results.Log.AppendLine(message);
    }
    
    /** Log a message with params */
    public void Debug(string fmt, params object[] values) {
      var msg = String.Format(fmt, values);
      Debug(msg);
    }
  }
}

