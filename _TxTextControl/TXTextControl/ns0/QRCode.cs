using TXTextControl.Barcode;

namespace ns0
{
	internal class QRCode : BarcodeInfo
	{
		internal QRCode()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.QRCode;
			base.m_qzQuietZone = new QuietZone(4, 4, 4, 4);
			base.m_iMaximumTextLength = 3700;
			base.m_iMinimumTextLength = 1;
			base.m_bIsUpperTextLengthVariable = true;
			base.m_strDefaultText = "A";
			base.m_bIs2DBarcode = true;
		}
	}
}
