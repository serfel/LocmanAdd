using TXTextControl.Barcode;

namespace ns0
{
	internal class AztecCode : BarcodeInfo
	{
		internal AztecCode()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.AztecCode;
			base.m_qzQuietZone = new QuietZone(0, 0, 0, 0);
			base.m_iMaximumTextLength = 2107;
			base.m_iMinimumTextLength = 1;
			base.m_bIsUpperTextLengthVariable = true;
			base.m_strDefaultText = "A";
			base.m_bIs2DBarcode = true;
		}
	}
}
