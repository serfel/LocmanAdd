/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Drag and Drop Sample
** description:	    Describes how to handle drag and drop with TX Text Control.						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;

namespace Drag_and_Drop {

    static class Program {

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}