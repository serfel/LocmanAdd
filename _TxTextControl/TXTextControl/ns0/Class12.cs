using TXTextControl.Barcode;

namespace ns0
{
	internal class Class12 : BarcodeInfo
	{
		internal Class12()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.Postnet;
			base.m_qzQuietZone = new QuietZone(0, 0, 0, 0);
			base.m_iMaximumTextLength = 11;
			base.m_iMinimumTextLength = 5;
			base.m_bIsUpperTextLengthVariable = true;
			base.m_strDefaultText = "01234";
			base.m_bDefaultHasCheckValue = true;
			base.m_bHasCheckValueIsOptional = false;
			base.m_bDefaultShowCheckValue = true;
			base.m_bShowCheckValueIsOptional = true;
		}
	}
}
