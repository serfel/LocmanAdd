using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Interop.UIAutomationCore
{
	[ComImport]
	[Guid("5347AD7B-C355-46F8-AFF5-909033582F63")]
	[TypeIdentifier]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CompilerGenerated]
	public interface ITextRangeProvider
	{
		[return: MarshalAs(UnmanagedType.Interface)]
		ITextRangeProvider Clone();

		int Compare([In][MarshalAs(UnmanagedType.Interface)] ITextRangeProvider range);

		int CompareEndpoints([In] TextPatternRangeEndpoint endpoint, [In][MarshalAs(UnmanagedType.Interface)] ITextRangeProvider targetRange, [In] TextPatternRangeEndpoint targetEndpoint);

		void ExpandToEnclosingUnit([In] TextUnit unit);

		[return: MarshalAs(UnmanagedType.Interface)]
		ITextRangeProvider FindAttribute([In] int attributeId, [In][MarshalAs(UnmanagedType.Struct)] object val, [In] int backward);

		[return: MarshalAs(UnmanagedType.Interface)]
		ITextRangeProvider FindText([In][MarshalAs(UnmanagedType.BStr)] string text, [In] int backward, [In] int ignoreCase);

		[return: MarshalAs(UnmanagedType.Struct)]
		object GetAttributeValue([In] int attributeId);

		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_R8)]
		double[] GetBoundingRectangles();

		[return: MarshalAs(UnmanagedType.Interface)]
		IRawElementProviderSimple GetEnclosingElement();

		[return: MarshalAs(UnmanagedType.BStr)]
		string GetText([In] int maxLength);

		int Move([In] TextUnit unit, [In] int count);

		int MoveEndpointByUnit([In] TextPatternRangeEndpoint endpoint, [In] TextUnit unit, [In] int count);

		void MoveEndpointByRange([In] TextPatternRangeEndpoint endpoint, [In][MarshalAs(UnmanagedType.Interface)] ITextRangeProvider targetRange, [In] TextPatternRangeEndpoint targetEndpoint);

		void Select();

		void AddToSelection();

		void RemoveFromSelection();

		void ScrollIntoView([In] int alignToTop);

		[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
		IRawElementProviderSimple[] GetChildren();
	}
}
