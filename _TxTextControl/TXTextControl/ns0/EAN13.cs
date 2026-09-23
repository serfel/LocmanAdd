using TXTextControl.Barcode;

namespace ns0
{
	internal class EAN13 : BarcodeInfo
	{
		internal EAN13()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.EAN13;
			base.m_strDefaultText = "012345678901";
			base.m_qzQuietZone = new QuietZone(9, 0, 9, 0);
			base.m_iMaximumTextLength = 12;
			base.m_iMinimumTextLength = 12;
			base.m_bIsUpperTextLengthVariable = false;
			base.m_bDefaultHasCheckValue = true;
			base.m_bHasCheckValueIsOptional = false;
			base.m_bDefaultShowCheckValue = true;
			base.m_bShowCheckValueIsOptional = false;
		}
	}
}
