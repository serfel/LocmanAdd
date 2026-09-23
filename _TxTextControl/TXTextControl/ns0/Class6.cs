using TXTextControl.Barcode;

namespace ns0
{
	internal class Class6 : BarcodeInfo
	{
		internal Class6()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.EAN8;
			base.m_qzQuietZone = new QuietZone(10, 0, 10, 0);
			base.m_iMaximumTextLength = 7;
			base.m_iMinimumTextLength = 7;
			base.m_bIsUpperTextLengthVariable = false;
			base.m_strDefaultText = "0123456";
			base.m_bDefaultHasCheckValue = true;
			base.m_bHasCheckValueIsOptional = false;
			base.m_bDefaultShowCheckValue = true;
			base.m_bShowCheckValueIsOptional = false;
		}
	}
}
