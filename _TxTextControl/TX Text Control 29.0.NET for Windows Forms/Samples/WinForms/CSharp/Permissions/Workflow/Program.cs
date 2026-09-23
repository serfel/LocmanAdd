/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Permissions Workflow Sample
** description:	Explains the typical workflow when working with document permissions and user 
**						specific editable regions.
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Workflow {

    static class Program {

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
