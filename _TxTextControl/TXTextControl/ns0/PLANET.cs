using TXTextControl.Barcode;

namespace ns0
{
	internal class PLANET : BarcodeInfo
	{
		internal PLANET()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.PLANET;
			base.m_strDefaultText = "01234567891";
			base.m_qzQuietZone = new QuietZone(1, 0, 1, 0);
			base.m_iMaximumTextLength = 13;
			base.m_iMinimumTextLength = 11;
			base.m_bIsUpperTextLengthVariable = true;
			base.m_bDefaultHasCheckValue = true;
			base.m_bHasCheckValueIsOptional = false;
			base.m_bDefaultShowCheckValue = false;
			base.m_bShowCheckValueIsOptional = true;
		}
	}
}
