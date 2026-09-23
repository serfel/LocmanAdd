/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Mail Merge Sample
** description:	This chapter shows how to use the DocumentServer.MailMerge class in 
**                  Windows Forms projects to merge TXTextControl.ApplicationFields in 
**                  template documents with data from various data sources			
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;

namespace MailMerge_Blocks {

	public partial class Form1 : Form {

		private DataSet m_ds;

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			// Create a new DataSet and load the XML file
			m_ds = new DataSet();
			m_ds.ReadXml(Application.StartupPath + "\\data.xml");

			var ls = new TXTextControl.LoadSettings {
				ApplicationFieldFormat = TXTextControl.ApplicationFieldFormat.MSWord,
				LoadSubTextParts = true
			};
			textControl1.Load(Application.StartupPath + "\\template.docx", TXTextControl.StreamType.WordprocessingML, ls);
		}

		private void mergeToolStripMenuItem_Click(object sender, EventArgs e) {
			mailMerge1.Merge(m_ds.Tables["orders"], true);
		}
	}
}
