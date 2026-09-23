/*------------------------------------------------------------------------------------------------
** program:			TX Text Control DataSourceManagerSample
** description:	Shows you how to use the DataSourceManager to create your own template designer 
**                  for templates that are compatible with MailMerge.
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;

namespace DataSourceManagerSample {

    static class Program {

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
