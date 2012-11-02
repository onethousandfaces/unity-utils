using System;
using n.Infrastructure.TinyIoC;

namespace n.Infrastructure
{
	/** Wrapper around the IOC so we can swap the implementation out easily */
	public class nResolver
	{
		/** Resolve instance of type T */
		public T Resolve<T>() where T : class {
			var rtn = (T) TinyIoCContainer.Current.Resolve<T>();
			return rtn;
		}

		/** Bind interface T to type K */
		public void Bind<T, K>() where T : class where K : T {
			var instance = Resolve<K>();
			TinyIoCContainer.Current.Register<T>(instance);
		}
	}
}

