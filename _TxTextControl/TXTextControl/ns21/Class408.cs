using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using TXTextControl;

namespace ns21
{
	internal class Class408 : Class407, IDisposable
	{
		private static Mutex mutex_0 = new Mutex(initiallyOwned: false);

		private static int int_0 = 0;

		//private static Type type_0 = null;

		//private static Assembly assembly_0 = null;

		private bool bool_0;

		internal Class408()
		{
			Class408.mutex_0.WaitOne();
			if (Class408.int_0 == 0)
			{
				//Class408.type_0 = base.method_0("txkernel", "29.0.2900.500", "TXTextControl.TXKernel", out Class408.assembly_0);
				TXTextControl.TXKernel.Initialize();
			}
			Class408.int_0++;
			Class408.mutex_0.ReleaseMutex();
		}

		~Class408()
		{
			this.method_3(bool_1: false);
		}

		public void Dispose()
		{
			this.method_3(bool_1: true);
			GC.SuppressFinalize(this);
		}

		private void method_3(bool bool_1)
		{
			Class408.mutex_0.WaitOne();
			if (!this.bool_0)
			{
				Class408.int_0--;
				if (Class408.int_0 == 0)// && Class408.type_0 != null)
				{
					TXTextControl.TXKernel.Terminate();
					//Class408.type_0.GetMethod("Terminate").Invoke(null, null);
				}
			}
			this.bool_0 = true;
			Class408.mutex_0.ReleaseMutex();
		}

		internal IntPtr method_4()
		{
			Module[] modules = Assembly.GetAssembly(typeof(TXTextControl.TXKernel)).GetModules();// Class408.assembly_0.GetModules();
			return Marshal.GetHINSTANCE(modules[0]);
		}

		internal int GetErrorCode()
		{
			//if (Class408.type_0 != null)
			{
				return (int)//Class408.type_0.GetMethod("GetErrorCode").Invoke(null, null);
							TXTextControl.TXKernel.GetErrorCode();
			}
			return 0;
		}

		internal int method_6()
		{
			//if (Class408.type_0 != null)
			{
				return (int)//Class408.type_0.GetMethod("GetVersion").Invoke(null, null);
							TXTextControl.TXKernel.GetVersion();
			}
			return 0;
		}

		internal int method_7()
		{
			//if (Class408.type_0 != null)
			{
				return (int)//Class408.type_0.GetMethod("GetBuildNumber").Invoke(null, null);
							TXTextControl.TXKernel.GetBuildNumber();
			}
			return 0;
		}

		internal uint method_8(IntPtr intptr_0, Enum83 enum83_0, ref Struct74 struct74_0)
		{
			/*
			if (Class408.type_0 != null)
			{
				IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf((object)struct74_0));
				Marshal.StructureToPtr((object)struct74_0, intPtr, fDeleteOld: false);
				object[] parameters = new object[3]
				{
					intptr_0,
					(uint)enum83_0,
					intPtr
				};
				uint result = (uint)Class408.type_0.GetMethod("TXDropTarget").Invoke(null, parameters);
				Marshal.FreeHGlobal(intPtr);
				return result;
			}
			*/
			
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf((object)struct74_0));
			Marshal.StructureToPtr((object)struct74_0, intPtr, fDeleteOld: false);
			uint result = TXTextControl.TXKernel.TXDropTarget(intptr_0, (uint)enum83_0, intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		internal string[] method_9(IntPtr intptr_0, IntPtr intptr_1, uint uint_0)
		{
			/*
			if (Class408.type_0 != null)
			{
				object[] parameters = new object[3] { intptr_0, intptr_1, uint_0 };
				IntPtr intPtr = (IntPtr)Class408.type_0.GetMethod("GetDocumentPartNames").Invoke(null, parameters);
				if (intPtr != IntPtr.Zero)
				{
					string[] result = KernelHelper.Ptr2StringArray(intPtr);
					Class429.GlobalFree(intPtr);
					return result;
				}
			}
			*/
			IntPtr intPtr = TXTextControl.TXKernel.GetDocumentPartNames(intptr_0, intptr_1, uint_0);
			if (intPtr != IntPtr.Zero)
			{
				string[] result = KernelHelper.Ptr2StringArray(intPtr);
				Class429.GlobalFree(intPtr);
				return result;
			}
			return null;
		}

		internal static MethodInfo smethod_0()
		{
			//if (Class408.type_0 != null)
			{
				return typeof(TXTextControl.TXKernel).GetMethod("TX_WndProc"); //Class408.type_0.GetMethod("TX_WndProc");
			}
			return null;
		}
	}
}
