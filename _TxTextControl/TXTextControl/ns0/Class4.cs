using TXTextControl.Barcode;

namespace ns0
{
	internal class Class4 : BarcodeInfo
	{
		internal Class4()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.Datamatrix;
			base.m_qzQuietZone = new QuietZone(1, 1, 1, 1);
			base.m_iMaximumTextLength = 1301;
			base.m_iMinimumTextLength = 1;
			base.m_bIsUpperTextLengthVariable = true;
			base.m_strDefaultText = "A";
			base.m_bIs2DBarcode = true;
		}
	}
}
