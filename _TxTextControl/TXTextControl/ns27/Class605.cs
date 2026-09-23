using System;
using System.Runtime.InteropServices;
using Interop.UIAutomationCore;

namespace ns27
{
	internal class Class605
	{
		internal enum Enum145
		{
			const_0,
			const_1,
			const_2,
			const_3
		}

		internal enum Enum146
		{
			const_0 = 0,
			const_1 = 1,
			const_2 = 2,
			const_3 = 3,
			const_4 = 4,
			const_5 = 5,
			const_6 = 6,
			const_7 = 7,
			const_8 = 8,
			const_9 = 9,
			const_10 = 11,
			const_11 = 12,
			const_12 = 13,
			const_13 = 14,
			const_14 = 0xF,
			const_15 = 0x10,
			const_16 = 17,
			const_17 = 18,
			const_18 = -1
		}

		internal enum Enum147
		{
			const_0 = 0,
			const_1 = 1,
			const_2 = 2,
			const_3 = 4
		}

		[DllImport("UIAutomationCore.dll", CharSet = CharSet.Unicode)]
		internal static extern int UiaHostProviderFromHwnd(IntPtr intptr_0, [MarshalAs(UnmanagedType.Interface)] out IRawElementProviderSimple irawElementProviderSimple_0);

		[DllImport("UIAutomationCore.dll", CharSet = CharSet.Unicode)]
		internal static extern IntPtr UiaReturnRawElementProvider(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2, IRawElementProviderSimple irawElementProviderSimple_0);

		[DllImport("UIAutomationCore.dll", CharSet = CharSet.Unicode)]
		internal static extern int UiaRaiseAutomationEvent(IRawElementProviderSimple irawElementProviderSimple_0, int int_0);

		[DllImport("UIAutomationCore.dll", CharSet = CharSet.Unicode)]
		internal static extern int UiaRaiseAutomationPropertyChangedEvent(IRawElementProviderSimple irawElementProviderSimple_0, int int_0, object object_0, object object_1);

		[DllImport("UIAutomationCore.dll", CharSet = CharSet.Unicode)]
		private static extern int UiaGetReservedNotSupportedValue([MarshalAs(UnmanagedType.IUnknown)] out object object_0);

		[DllImport("UIAutomationCore.dll", CharSet = CharSet.Unicode)]
		private static extern int UiaGetReservedMixedAttributeValue([MarshalAs(UnmanagedType.IUnknown)] out object object_0);

		internal static object smethod_0()
		{
			Class605.smethod_2(Class605.UiaGetReservedNotSupportedValue(out var object_));
			return object_;
		}

		internal static object smethod_1()
		{
			Class605.smethod_2(Class605.UiaGetReservedMixedAttributeValue(out var object_));
			return object_;
		}

		private static void smethod_2(int int_0)
		{
			if (int_0 < 0)
			{
				Marshal.ThrowExceptionForHR(int_0);
			}
		}
	}
}
