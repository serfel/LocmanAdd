using TXTextControl.Barcode;

namespace ns0
{
	internal class Class14 : BarcodeInfo
	{
		internal Class14()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.RoyalMail;
			base.m_strDefaultText = "012";
			base.m_qzQuietZone = new QuietZone(1, 0, 1, 0);
			base.m_iMaximumTextLength = 50;
			base.m_iMinimumTextLength = 3;
			base.m_bIsUpperTextLengthVariable = true;
			base.m_bDefaultHasCheckValue = true;
			base.m_bHasCheckValueIsOptional = false;
			base.m_bDefaultShowCheckValue = false;
			base.m_bShowCheckValueIsOptional = true;
		}
	}
}
