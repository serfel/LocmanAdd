using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Interop.UIAutomationCore
{
	[ComImport]
	[TypeIdentifier]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CompilerGenerated]
	[Guid("620CE2A5-AB8F-40A9-86CB-DE3C75599B58")]
	public interface IRawElementProviderFragmentRoot
	{
		[return: MarshalAs(UnmanagedType.Interface)]
		IRawElementProviderFragment ElementProviderFromPoint([In] double x, [In] double y);

		[return: MarshalAs(UnmanagedType.Interface)]
		IRawElementProviderFragment GetFocus();
	}
}
