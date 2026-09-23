using TXTextControl.Barcode;

namespace ns0
{
	internal class MicroPDF : BarcodeInfo
	{
		internal MicroPDF()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.MicroPDF;
			base.m_qzQuietZone = new QuietZone(1, 1, 1, 1);
			base.m_iMinimumTextLength = 1;
			base.m_iMaximumTextLength = 250;
			base.m_bIsUpperTextLengthVariable = true;
			base.m_strDefaultText = "A";
			base.m_bIs2DBarcode = true;
		}
	}
}
