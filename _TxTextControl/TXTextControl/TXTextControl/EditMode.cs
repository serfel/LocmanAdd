using System.ComponentModel;

namespace TXTextControl
{
	public enum EditMode
	{
		Edit = 1,
		ReadAndSelect = 2,
		ReadOnly = 3,
		[Browsable(false)]
		UsePassword = 0x800
	}
}
