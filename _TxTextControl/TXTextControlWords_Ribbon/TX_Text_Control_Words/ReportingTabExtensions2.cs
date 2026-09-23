using System.Windows.Forms;
using TX_Text_Control_Words.FileHandling;

namespace TX_Text_Control_Words
{
	public static class ReportingTabExtensions2
	{
		public static MessageBoxButtons ToWinFormsButton(this MessageBoxButton button)
		{
			return button switch
			{
				MessageBoxButton.OKCancel => MessageBoxButtons.OKCancel, 
				MessageBoxButton.AbortRetryIgnore => MessageBoxButtons.AbortRetryIgnore, 
				MessageBoxButton.YesNoCancel => MessageBoxButtons.YesNoCancel, 
				MessageBoxButton.YesNo => MessageBoxButtons.YesNo, 
				MessageBoxButton.RetryCancel => MessageBoxButtons.RetryCancel, 
				_ => MessageBoxButtons.OK, 
			};
		}

		public static System.Windows.Forms.MessageBoxIcon ToWinFormsIcon(this TX_Text_Control_Words.FileHandling.MessageBoxIcon icon)
		{
			return icon switch
			{
				TX_Text_Control_Words.FileHandling.MessageBoxIcon.Error => System.Windows.Forms.MessageBoxIcon.Hand, 
				TX_Text_Control_Words.FileHandling.MessageBoxIcon.Question => System.Windows.Forms.MessageBoxIcon.Question, 
				TX_Text_Control_Words.FileHandling.MessageBoxIcon.Exclamation => System.Windows.Forms.MessageBoxIcon.Exclamation, 
				TX_Text_Control_Words.FileHandling.MessageBoxIcon.Information => System.Windows.Forms.MessageBoxIcon.Asterisk, 
				_ => System.Windows.Forms.MessageBoxIcon.None, 
			};
		}

		public static TX_Text_Control_Words.FileHandling.DialogResult ToFileHandlerDialogResult(this System.Windows.Forms.DialogResult res)
		{
			switch (res)
			{
			case System.Windows.Forms.DialogResult.None:
			case System.Windows.Forms.DialogResult.Cancel:
			case System.Windows.Forms.DialogResult.Abort:
			case System.Windows.Forms.DialogResult.Ignore:
				return TX_Text_Control_Words.FileHandling.DialogResult.Cancel;
			case System.Windows.Forms.DialogResult.No:
				return TX_Text_Control_Words.FileHandling.DialogResult.No;
			case System.Windows.Forms.DialogResult.Yes:
				return TX_Text_Control_Words.FileHandling.DialogResult.Yes;
			default:
				return TX_Text_Control_Words.FileHandling.DialogResult.OK;
			}
		}
	}
}
