using System;
using System.Data;

namespace n.Infrastructure
{
	public class nLog
	{
		private static nLogWriter _writer = null;

		private static nLogWriter Instance() {
			if (_writer == null) {
				var r = new nResolver();
				_writer = r.Resolve<nLogWriter>();
			}
			return _writer;
		}

		public static void Debug(string message) {
			Instance().Trace(message);
		}

		public static void Info(string message) {
			Instance().Trace(message);
		}

		public static void Error(string message, Exception e) {
			Instance().Trace(message + e.ToString());
		}
	}
}

