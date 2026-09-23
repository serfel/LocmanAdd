using TXTextControl.Barcode;

namespace ns0
{
	internal class PDF417 : BarcodeInfo
	{
		internal PDF417()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.PDF417;
			base.m_qzQuietZone = new QuietZone(2, 2, 2, 2);
			base.m_iMinimumTextLength = 1;
			base.m_iMaximumTextLength = 1500;
			base.m_bIsUpperTextLengthVariable = true;
			base.m_strDefaultText = "A";
			base.m_bIs2DBarcode = true;
		}
	}
}
