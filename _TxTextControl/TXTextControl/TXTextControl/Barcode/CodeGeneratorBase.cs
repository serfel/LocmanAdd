using ns0;

namespace TXTextControl.Barcode
{
	internal abstract class CodeGeneratorBase
	{
		internal abstract Class37 GetBarcodeImage(Class38 p_bsSettings, string p_strText);

		internal abstract void UpdateBarcodeSettings(Class38 p_bstSettings);

		internal abstract bool IsTextValid(string input, int p_iUpperTextLength);
	}
}
