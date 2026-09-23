using TXTextControl.Barcode;

namespace ns0
{
	internal class Code11 : BarcodeInfo
	{
		internal Code11()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.Code11;
			base.m_strDefaultText = "012";
			base.m_qzQuietZone = new QuietZone(10, 0, 10, 0);
			base.m_iMaximumTextLength = 50;
			base.m_iMinimumTextLength = 3;
			base.m_bIsUpperTextLengthVariable = true;
			base.m_bDefaultHasCheckValue = true;
			base.m_bHasCheckValueIsOptional = true;
			base.m_bDefaultShowCheckValue = false;
			base.m_bShowCheckValueIsOptional = true;
		}
	}
}
