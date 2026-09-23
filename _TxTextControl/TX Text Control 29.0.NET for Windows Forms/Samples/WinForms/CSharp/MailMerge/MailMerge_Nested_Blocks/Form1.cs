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
using TXTextControl;
using TXTextControl.DocumentServer;

namespace MailMerge_Nested_Blocks {

	public partial class Form1 : Form {

		public Form1() {
			InitializeComponent();
		}

		private void LoadTemplate() {
			// Load the DOCX template
			var ls = new LoadSettings {
				ApplicationFieldFormat = ApplicationFieldFormat.MSWord,
				LoadSubTextParts = true
			};
			textControl1.Load(Application.StartupPath + "\\Accruals Report.docx", StreamType.WordprocessingML, ls);
			textControl1.Tables.GridLines = false;
		}

		private void CreateReport() {
			try {
				// Load the XML file
				var ds = new DataSet();
				ds.ReadXml(tbDatabaseFile.Tag as string, XmlReadMode.Auto);

				// Add the relations for the main block and its child blocks
				DataRelation relCompanyEmployee = new DataRelation("company_employee",
					 ds.Tables["company"].Columns["company_number"],
					 ds.Tables["employee"].Columns["company_number"]);

				DataRelation relEmployeeSick = new DataRelation("employee_sick",
					 ds.Tables["employee"].Columns["employee_number"],
					 ds.Tables["sick"].Columns["employee_number"]);

				DataRelation relEmployeeVacation = new DataRelation("employee_vacation",
					 ds.Tables["employee"].Columns["employee_number"],
					 ds.Tables["vacation"].Columns["employee_number"]);

				ds.Relations.Add(relCompanyEmployee);
				ds.Relations.Add(relEmployeeSick);
				ds.Relations.Add(relEmployeeVacation);

				// Progress bar
				toolStripProgressBar1.Maximum = ds.Tables["employee"].Rows.Count;

				// Merge
				mailMerge1.Merge(ds.Tables["company"], true);

				// Reset the progress bar
				toolStripProgressBar1.Value = 0;
			}
			catch (Exception exc) {
				MessageBox.Show(this, exc.Message);
			}
		}

		void MailMerge1_BlockRowMerged(object sender, MailMerge.BlockRowMergedEventArgs e) {
			toolStripProgressBar1.PerformStep();
		}

		private void LoadXML() {
			var ofd = new OpenFileDialog {
				Filter = "XML Database | *.xml",
				InitialDirectory = Application.StartupPath
			};

			if (ofd.ShowDialog() == DialogResult.OK) {
				tbDatabaseFile.Tag = ofd.FileName;
				tbDatabaseFile.Text = ofd.SafeFileName;
				toolStripButton1.Enabled = true;
			}
		}

		private void ReportToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
			if (tbDatabaseFile.Tag == null) {
				createToolStripMenuItem.Enabled = false;
			}
			else {
				createToolStripMenuItem.Enabled = true;
			}
		}

		private void CreateToolStripMenuItem_Click(object sender, EventArgs e) {
			CreateReport();
		}

		private void ToolStripButton1_Click(object sender, EventArgs e) {
			CreateReport();
		}

		private void ToolStripButton2_Click(object sender, EventArgs e) {
			LoadXML();
		}

		private void LoadXMLToolStripMenuItem_Click(object sender, EventArgs e) {
			LoadXML();
		}

		private void Form1_Load(object sender, EventArgs e) {
			LoadTemplate();
		}
	}
}

