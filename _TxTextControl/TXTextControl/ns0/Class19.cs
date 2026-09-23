using TXTextControl.Barcode;

namespace ns0
{
	internal class Class19 : BarcodeInfo
	{
		internal Class19()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.Code39;
			base.m_qzQuietZone = new QuietZone(10, 0, 10, 0);
			base.m_iMaximumTextLength = 1000;
			base.m_iMinimumTextLength = 1;
			base.m_bIsUpperTextLengthVariable = true;
			base.m_strDefaultText = "1";
			base.m_bDefaultHasCheckValue = false;
			base.m_bHasCheckValueIsOptional = true;
			base.m_bDefaultShowCheckValue = true;
			base.m_bShowCheckValueIsOptional = true;
		}
	}
}
