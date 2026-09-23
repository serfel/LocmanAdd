/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Ribbon Modify Tutorial Sample
** description:	Describes how to add drawings functionality to TX Text Control.						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Shapes {

    static class Program {

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
