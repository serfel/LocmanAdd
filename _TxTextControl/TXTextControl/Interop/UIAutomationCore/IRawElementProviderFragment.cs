using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Interop.UIAutomationCore
{
	[ComImport]
	[Guid("F7063DA8-8359-439C-9297-BBC5299A7D87")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CompilerGenerated]
	[TypeIdentifier]
	public interface IRawElementProviderFragment
	{
		IRawElementProviderFragmentRoot FragmentRoot
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		UiaRect BoundingRectangle { get; }

		[return: MarshalAs(UnmanagedType.Interface)]
		IRawElementProviderFragment Navigate([In] NavigateDirection direction);

		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_INT)]
		int[] GetRuntimeId();

		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		IRawElementProviderFragmentRoot[] GetEmbeddedFragmentRoots();

		void SetFocus();
	}
}
