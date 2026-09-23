/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Mail Merge Sample
** description:	This chapter shows how to use the DocumentServer.MailMerge class in 
**                  Windows Forms projects to merge TXTextControl.ApplicationFields in 
**                  template documents with data from various data sources			
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;

namespace MailMerge_Blocks {

    static class Program {

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
