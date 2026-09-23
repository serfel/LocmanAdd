using ns0;

namespace TXTextControl.Barcode
{
	internal abstract class BarcodeInfo
	{
		internal BarcodeType m_ctType;

		internal QuietZone m_qzQuietZone;

		internal int m_iMaximumTextLength;

		internal int m_iMinimumTextLength;

		internal bool m_bIsUpperTextLengthVariable;

		internal string m_strDefaultText;

		internal bool m_bIs2DBarcode;

		internal bool m_bDefaultHasCheckValue;

		internal bool m_bHasCheckValueIsOptional;

		internal bool m_bDefaultShowCheckValue;

		internal bool m_bShowCheckValueIsOptional;

		internal abstract void SetDefaultBarcodeInfo();
	}
}
