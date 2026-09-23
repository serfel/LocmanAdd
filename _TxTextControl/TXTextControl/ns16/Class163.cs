using System.Globalization;
using System.Windows.Forms;

namespace ns16
{
	internal sealed class Class163
	{
		private Class163()
		{
		}

		public static DialogResult smethod_0(string string_0, string string_1, MessageBoxIcon messageBoxIcon_0)
		{
			MessageBoxOptions options = (MessageBoxOptions)0;
			if (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft)
			{
				options = MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading;
			}
			return MessageBox.Show(string_1, string_0, MessageBoxButtons.OK, messageBoxIcon_0, MessageBoxDefaultButton.Button1, options);
		}
	}
}
