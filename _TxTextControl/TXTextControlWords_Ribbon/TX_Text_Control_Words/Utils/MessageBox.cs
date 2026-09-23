using System.Windows.Forms;

namespace TX_Text_Control_Words.Utils
{
	internal static class MessageBox
	{
		internal static DialogResult Show(Control owner, string text, string caption, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Hand)
		{
			if (owner.RightToLeft == RightToLeft.Yes)
			{
				return System.Windows.Forms.MessageBox.Show(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
			}
			return System.Windows.Forms.MessageBox.Show(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
		}
	}
}
