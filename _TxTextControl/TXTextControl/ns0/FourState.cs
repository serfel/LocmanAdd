using TXTextControl.Barcode;

namespace ns0
{
	internal class FourState : BarcodeInfo
	{
		internal FourState()
		{
			this.SetDefaultBarcodeInfo();
		}

		internal override void SetDefaultBarcodeInfo()
		{
			base.m_ctType = BarcodeType.FourState;
			base.m_strDefaultText = "01234567";
			base.m_qzQuietZone = new QuietZone(1, 0, 1, 0);
			base.m_iMaximumTextLength = 8;
			base.m_iMinimumTextLength = 8;
			base.m_bIsUpperTextLengthVariable = false;
			base.m_bDefaultHasCheckValue = true;
			base.m_bHasCheckValueIsOptional = false;
			base.m_bDefaultShowCheckValue = false;
			base.m_bShowCheckValueIsOptional = false;
		}
	}
}
