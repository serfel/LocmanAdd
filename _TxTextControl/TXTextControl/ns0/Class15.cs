using TXTextControl.Barcode;

namespace ns0
{
	internal class Class15 : BarcodeInfo
	{
		internal Class15()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.UPCA;
			base.m_qzQuietZone = new QuietZone(11, 0, 11, 0);
			base.m_iMaximumTextLength = 11;
			base.m_iMinimumTextLength = 11;
			base.m_bIsUpperTextLengthVariable = false;
			base.m_strDefaultText = "01234567890";
			base.m_bDefaultHasCheckValue = true;
			base.m_bHasCheckValueIsOptional = false;
			base.m_bDefaultShowCheckValue = true;
			base.m_bShowCheckValueIsOptional = false;
		}
	}
}
