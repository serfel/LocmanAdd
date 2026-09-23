using TXTextControl.Barcode;

namespace ns0
{
	internal class Codabar : BarcodeInfo
	{
		internal Codabar()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.Codabar;
			base.m_strDefaultText = "012";
			base.m_qzQuietZone = new QuietZone(10, 0, 10, 0);
			base.m_iMaximumTextLength = 100;
			base.m_iMinimumTextLength = 3;
			base.m_bIsUpperTextLengthVariable = true;
			base.m_bDefaultHasCheckValue = false;
			base.m_bHasCheckValueIsOptional = true;
			base.m_bDefaultShowCheckValue = true;
			base.m_bShowCheckValueIsOptional = true;
		}
	}
}
