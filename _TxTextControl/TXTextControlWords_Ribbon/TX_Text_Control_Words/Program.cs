using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using TXTextControl;

namespace TX_Text_Control_Words
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.ThreadException += Application_ThreadException;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			Application.Run(new MainWindow());
		}

		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			string product = ((AssemblyProductAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyProductAttribute))).Product;
			LicenseLevelException ex = e.Exception as LicenseLevelException;
			_ = e.Exception;
			if (e.Exception.GetType() == typeof(TargetInvocationException) && e.Exception.InnerException != null && e.Exception.InnerException.Source == "TXSpell")
			{
				MessageBox.Show(e.Exception.InnerException.Message, product, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (ex != null)
			{
				MessageBox.Show(e.Exception.Message, product, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				MessageBox.Show(e.Exception.Message, product, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
