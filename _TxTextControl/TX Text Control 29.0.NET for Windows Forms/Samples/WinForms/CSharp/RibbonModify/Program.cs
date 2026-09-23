/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Ribbon Modify Tutorial Sample
** description:	Shows how to create a word processor application with a ribbon interface from 
**                  scratch with just a few lines of code. Contextual ribbon tabs for table and 
**                  frame layout tasks are added and connected.						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;

namespace RibbonModify {

    static class Program {

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
