/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Charts Sample
** description:	    Describes how to add charting functionality to TX Text Control.
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;

namespace charts_step2 {

    static class Program {

        [STAThread]
        static void Main() {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
