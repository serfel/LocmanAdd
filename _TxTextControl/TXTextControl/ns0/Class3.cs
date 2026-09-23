using TXTextControl.Barcode;

namespace ns0
{
	internal class Class3 : BarcodeInfo
	{
		internal Class3()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.Code93;
			base.m_strDefaultText = "01A";
			base.m_qzQuietZone = new QuietZone(10, 0, 10, 0);
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
