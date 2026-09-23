using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Interop.UIAutomationCore
{
	[ComImport]
	[CompilerGenerated]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeIdentifier]
	[Guid("D6DD68D1-86FD-4332-8666-9ABEDEA2D24C")]
	public interface IRawElementProviderSimple
	{
		ProviderOptions ProviderOptions { get; }

		IRawElementProviderSimple HostRawElementProvider
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		[return: MarshalAs(UnmanagedType.IUnknown)]
		object GetPatternProvider([In] int patternId);

		[return: MarshalAs(UnmanagedType.Struct)]
		object GetPropertyValue([In] int propertyId);
	}
}
