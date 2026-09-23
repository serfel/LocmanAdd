/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TX_Text_Control_Words {

	static class _Program {

		//[STAThread]
		static void Main1() {

			// Add an event handler for handling UI thread exceptions
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.ThreadException += Application_ThreadException;


			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow());
		}


		/*-------------------------------------------------------------------------------------------------------------
		** Application_ThreadException
		**-----------------------------------------------------------------------------------------------------------*/
		static void Application_ThreadException(object sender, ThreadExceptionEventArgs e) {
			string strProductName = ((AssemblyProductAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyProductAttribute))).Product;
			var licenseLevelException = e.Exception as TXTextControl.LicenseLevelException;
			var fileNotFoundException = e.Exception as System.IO.FileNotFoundException;

			// TX Spell not available
			if (e.Exception.GetType() == typeof(TargetInvocationException) &&
				e.Exception.InnerException != null &&
				e.Exception.InnerException.Source == "TXSpell") {
				MessageBox.Show(e.Exception.InnerException.Message, strProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// TX Text Control Feature is not available
			if (licenseLevelException != null) {
				MessageBox.Show(e.Exception.Message, strProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			// Not Handled
			MessageBox.Show(e.Exception.Message, strProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

	}
}
