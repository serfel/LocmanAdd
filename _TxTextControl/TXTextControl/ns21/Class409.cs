using System;
using System.Reflection;
using System.Threading;

namespace ns21
{
	internal class Class409 : Class407, IDisposable
	{
		private static Mutex mutex = new Mutex(initiallyOwned: false);
		private static int int_0 = 0;

		//private static Type type_0 = null;
		//private static Assembly assembly_0 = null;

		private bool bool_0;

		internal Class409()
		{
			Class409.mutex.WaitOne();
			if (Class409.int_0 == 0)
			{
				//Class409.type_0 = base.method_0("txtools", "29.0.1200.500", "TXTextControl.txtools", out Class409.assembly_0);
				TXTextControl.txtools.Initialize();
			}
			Class409.int_0++;
			Class409.mutex.ReleaseMutex();
		}

		~Class409()
		{
			this.Dispose(disposing: false);
		}

		public void Dispose()
		{
			this.Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			Class409.mutex.WaitOne();
			if (!this.bool_0)
			{
				Class409.int_0--;
				if (Class409.int_0 == 0)// && Class409.type_0 != null)
				{
					TXTextControl.txtools.Terminate();
				}
			}
			this.bool_0 = true;
			Class409.mutex.ReleaseMutex();
		}
	}
}
