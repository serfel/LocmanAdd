using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Interop.UIAutomationCore
{
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CompilerGenerated]
	[TypeIdentifier]
	[Guid("3589C92C-63F3-4367-99BB-ADA653B77CF2")]
	public interface ITextProvider
	{
		ITextRangeProvider DocumentRange
		{
			[return: MarshalAs(UnmanagedType.Interface)]
			get;
		}

		SupportedTextSelection SupportedTextSelection { get; }

		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		ITextRangeProvider[] GetSelection();

		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		ITextRangeProvider[] GetVisibleRanges();

		[return: MarshalAs(UnmanagedType.Interface)]
		ITextRangeProvider RangeFromChild([In][MarshalAs(UnmanagedType.Interface)] IRawElementProviderSimple childElement);

		[return: MarshalAs(UnmanagedType.Interface)]
		ITextRangeProvider RangeFromPoint([In] UiaPoint point);
	}
}
