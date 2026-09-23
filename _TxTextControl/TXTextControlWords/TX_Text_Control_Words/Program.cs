using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using TX_Text_Control_Words.Properties;
using TXTextControl;

namespace TX_Text_Control_Words
{
	internal static class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.ThreadException += Application_ThreadException;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			Application.Run(new MainWindow());
			Settings.Default.Save();
		}

		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			string product = ((AssemblyProductAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyProductAttribute))).Product;
			LicenseLevelException ex = e.Exception as LicenseLevelException;
			FileNotFoundException ex2 = e.Exception as FileNotFoundException;
			if (e.Exception.GetType() == typeof(TargetInvocationException) && e.Exception.InnerException != null && e.Exception.InnerException.Source == "TXSpell")
			{
				MessageBox.Show(e.Exception.InnerException.Message, product, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (ex != null)
			{
				MessageBox.Show(e.Exception.Message, product, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else if (ex2 != null && ex2.FileName.StartsWith("TXDrawing"))
			{
				MessageBox.Show(Resources.ERR_NEEDSPROFLICENSE, product, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				MessageBox.Show(e.Exception.Message, product, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
