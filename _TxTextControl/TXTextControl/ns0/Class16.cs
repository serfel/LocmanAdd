using TXTextControl.Barcode;

namespace ns0
{
	internal class Class16 : BarcodeInfo
	{
		internal Class16()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.Code128;
			base.m_qzQuietZone = new QuietZone(10, 0, 10, 0);
			base.m_iMinimumTextLength = 4;
			base.m_iMaximumTextLength = 1000;
			base.m_bIsUpperTextLengthVariable = true;
			base.m_strDefaultText = "01AB";
			base.m_bDefaultHasCheckValue = true;
			base.m_bHasCheckValueIsOptional = false;
			base.m_bDefaultShowCheckValue = false;
			base.m_bShowCheckValueIsOptional = true;
		}
	}
}
