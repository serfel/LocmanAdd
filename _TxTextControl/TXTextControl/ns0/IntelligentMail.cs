using TXTextControl.Barcode;

namespace ns0
{
	internal class IntelligentMail : BarcodeInfo
	{
		internal IntelligentMail()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.IntelligentMail;
			base.m_qzQuietZone = new QuietZone(0, 0, 0, 0);
			base.m_iMaximumTextLength = 31;
			base.m_iMinimumTextLength = 20;
			base.m_bIsUpperTextLengthVariable = true;
			base.m_strDefaultText = "01234567890123456789";
			base.m_bDefaultHasCheckValue = false;
			base.m_bHasCheckValueIsOptional = false;
			base.m_bDefaultShowCheckValue = false;
			base.m_bShowCheckValueIsOptional = false;
		}
	}
}
