using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Interop.UIAutomationCore
{
	[ComImport]
	[CompilerGenerated]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("C7935180-6FB3-4201-B174-7DF73ADBF64A")]
	[TypeIdentifier]
	public interface IValueProvider
	{
		string Value
		{
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		int IsReadOnly { get; }

		void SetValue([In][MarshalAs(UnmanagedType.LPWStr)] string val);
	}
}
