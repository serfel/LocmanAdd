/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Mini Toolbar Sample
** description:	 Explains the typical process of manipulating the MiniToolbar.		
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;

namespace MiniToolbar {

    static class Program {

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
