using TXTextControl.Barcode;

namespace ns0
{
	internal class Maxicode : BarcodeInfo
	{
		internal Maxicode()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.Maxicode;
			base.m_qzQuietZone = new QuietZone(4, 4, 4, 4);
			base.m_iMinimumTextLength = 15;
			base.m_iMaximumTextLength = 500;
			base.m_bIsUpperTextLengthVariable = true;
			base.m_bIs2DBarcode = true;
			base.m_strDefaultText = "999~056~A12345~";
		}
	}
}
