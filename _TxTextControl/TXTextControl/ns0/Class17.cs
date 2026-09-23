using TXTextControl.Barcode;

namespace ns0
{
	internal class Class17 : BarcodeInfo
	{
		internal Class17()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.Interleaved2of5;
			base.m_qzQuietZone = new QuietZone(9, 0, 9, 0);
			base.m_iMinimumTextLength = 1;
			base.m_iMaximumTextLength = 1000;
			base.m_bIsUpperTextLengthVariable = true;
			base.m_strDefaultText = "1";
			base.m_bDefaultHasCheckValue = true;
			base.m_bHasCheckValueIsOptional = true;
			base.m_bDefaultShowCheckValue = true;
			base.m_bShowCheckValueIsOptional = true;
		}
	}
}
