/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using TXTextControl;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** class OptionsDialog
	** Implements a dialog for managing the document's save- and loadsettings. The Save- and LoadSettings are
	** managed by the filehandler which will be used in this dialog for changing these settings.
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class OptionsDialog : Form {


		/*-------------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------------*/
		private TextControl m_textControl;
		private FileHandling.FileHandler m_fileHandler;

		/*-------------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**-----------------------------------------------------------------------------------------------------------*/

		public OptionsDialog(TextControl textControl, FileHandling.FileHandler fileHandler) {
			InitializeComponent();
			LocalizeDialog();

			this.m_textControl = textControl;
			this.m_fileHandler = fileHandler;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** LocalizeDialog method
		** Localize the dialog's elements like labels and text by using the application's resources.
		**-----------------------------------------------------------------------------------------------------------*/
		private void LocalizeDialog() {
			// Window title
			Text = Properties.Resources.OPT_DLG_TITLE;

			// Button texts
			m_btnOK.Text = Properties.Resources.BTN_OK;
			m_btnCancel.Text = Properties.Resources.BTN_CANCEL;

			// Tab pages
			m_tabPageHTML.Text = Properties.Resources.OPT_DLG_TAB_HTMLOPTS;
			m_tabPagePDFSecurity.Text = Properties.Resources.OPT_DLG_TAB_PDFSEC;
			m_tabPagePDFExport.Text = Properties.Resources.OPT_DLG_TAB_PDFEXP;
			m_tabPagePDFImport.Text = Properties.Resources.OPT_DLG_TAB_PDFIMP;

			// HTML options
			m_grpCSS.Text = Properties.Resources.OPT_DLG_CSS_GRP_SAVEOPTS;
			m_optNoStylesheet.Text = Properties.Resources.OPT_DLG_CSS_NONE;
			m_optInlineStylesheet.Text = Properties.Resources.OPT_DLG_CSS_INLINE;
			m_optSaveStylesheetInSeperateFile.Text = Properties.Resources.OPT_DLG_CSS_SEPARATE_FILE;
			m_optSaveButDoNotOverwriteExistingFile.Text = Properties.Resources.OPT_DLG_CSS_SAVE_NOT_OVR;
			m_lblStylesheetFile.Text = Properties.Resources.OPT_DLG_CSS_LBL_FILE;

			// PDF security
			m_grpPDFDigSig.Text = Properties.Resources.OPT_DLG_PDFSEC_GRP_DIG_SIG;
			m_grpPDFDocPwd.Text = Properties.Resources.OPT_DLG_PDFSEC_GRP_DOC_PWD;
			m_lblCertFile.Text = Properties.Resources.OPT_DLG_PDFSEC_LBL_CERT_FILE;
			m_lblCertPwd.Text = Properties.Resources.OPT_DLG_PDFSEC_LBL_CERT_PWD;
			m_chkUserPassword.Text = Properties.Resources.OPT_DLG_PDFSEC_REQ_DOC_PWD;
			m_lblDocumentPassword.Text = Properties.Resources.OPT_DLG_PDFSEC_LBL_DOC_PWD;

			// PDF import
			m_grpPDFImport.Text = Properties.Resources.OPT_DLG_PDFIMP_GRP_OPTS;
			m_lblPDFImportMode.Text = Properties.Resources.OPT_DLG_PDFIMP_LBL_MODE;
			m_chbxLoadEmbeddedFiles.Text = Properties.Resources.OPT_DLG_PDFIMP_MODE_EMBEDDEDFILES;
			m_chbxLoadAdditionalEmbeddedData.Text = Properties.Resources.OPT_DLG_PDFIMP_MODE_ADDITIONAL_EMBEDDED_DATA;

			// PDF export
			m_grpPDFExport.Text = Properties.Resources.OPT_DLG_PDFEXP_GRP_OPTS;
			m_chkPDFEmbeddableFontsOnly.Text = Properties.Resources.OPT_DLG_PDFEXP_ENABLE_PDFA;
		}//LocalizeDialog


		/*-------------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** BtnOK_Click method
		** Applies the settings of the OptionsDialog to filehandler and TextControl.
		**-----------------------------------------------------------------------------------------------------------*/
		private void BtnOK_Click(object sender, System.EventArgs e) {
			// Transfer options to FileHandler 
			if (!ValidateDialogContent()) return;

			// Digital signature
			if (m_txtCertFile.Text != "") {
				try {
					m_txtCertFile.Text = m_txtCertFile.Text.Trim();
					var cert = new X509Certificate2(m_txtCertFile.Text, m_txtCertPwd.Text);
					m_fileHandler.PDFSignature = new DigitalSignature(cert, null);
					m_fileHandler.PDFCertFilePath = m_txtCertFile.Text;
					m_fileHandler.PDFCertPasswd = m_txtCertPwd.Text;
				} catch (Exception exc) {
					Utils.MessageBox.Show(this,
						string.Format(Properties.Resources.EXC_PDF_SIGNATURE, exc.Message),
						ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}

			m_fileHandler.PDFUserPassword = m_txtUserPassword.Text;

			// Set CSS Setting
			m_fileHandler.CssFileName = m_txtStylesheetFile.Text;
			if (m_optNoStylesheet.Checked) {
				m_fileHandler.CssSaveMode = CssSaveMode.None;
			} else if (m_optInlineStylesheet.Checked) {
				m_fileHandler.CssSaveMode = CssSaveMode.Inline;
			} else if (m_optSaveStylesheetInSeperateFile.Checked) {
				m_fileHandler.CssSaveMode = CssSaveMode.OverwriteFile;
			} else {
				m_fileHandler.CssSaveMode = CssSaveMode.CreateFile;
			}

			// Set PDFImportSettings
			PDFImportSettings newSettings = 0;
			switch (m_cbPDFImportMode.SelectedIndex) {
				case 0:
					newSettings = PDFImportSettings.GenerateTextFrames;
					break;

				case 1:
					newSettings = PDFImportSettings.GenerateParagraphs;
					break;

				case 2:
					newSettings = PDFImportSettings.GenerateLines;
					break;

			}

			if (m_chbxLoadEmbeddedFiles.Checked) {
				newSettings |= PDFImportSettings.LoadEmbeddedFiles;
			}
			if (m_chbxLoadAdditionalEmbeddedData.Checked) {
				newSettings |= PDFImportSettings.LoadEmbeddedData;
			}

			m_fileHandler.PDFImportSettings = newSettings;

			// PDF/A setting
			m_textControl.FontSettings.EmbeddableFontsOnly = m_chkPDFEmbeddableFontsOnly.Checked;

			// Close the dialog
			Close();
		}//BtnOK_Click

		/*-------------------------------------------------------------------------------------------------------------
		** ValidateDialogContent method
		** Validate the set dialogcontent.
		**-----------------------------------------------------------------------------------------------------------*/
		private bool ValidateDialogContent() {
			if (m_chkUserPassword.Checked && m_txtUserPassword.Text.Length == 0) {
				Utils.MessageBox.Show(this, Properties.Resources.OPT_DLG_PDFSEC_ERR_NO_DOC_PWD, ProductName);
				return false;
			}
			return true;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** OptSaveButDoNotOverwriteExistingFile_CheckedChanged method
		**-----------------------------------------------------------------------------------------------------------*/
		private void OptSaveButDoNotOverwriteExistingFile_CheckedChanged(object sender, System.EventArgs e) {
			m_lblStylesheetFile.Enabled = true;
			m_txtStylesheetFile.Enabled = true;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** OptSaveStylesheetInSeperateFile_CheckedChanged method
		**-----------------------------------------------------------------------------------------------------------*/
		private void OptSaveStylesheetInSeperateFile_CheckedChanged(object sender, System.EventArgs e) {
			m_lblStylesheetFile.Enabled = true;
			m_txtStylesheetFile.Enabled = true;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** OptInlineStylesheet_CheckedChanged method
		**-----------------------------------------------------------------------------------------------------------*/
		private void OptInlineStylesheet_CheckedChanged(object sender, System.EventArgs e) {
			m_lblStylesheetFile.Enabled = true;
			m_txtStylesheetFile.Enabled = true;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** OptNoStylesheet_CheckedChanged method
		**-----------------------------------------------------------------------------------------------------------*/
		private void OptNoStylesheet_CheckedChanged(object sender, System.EventArgs e) {
			m_lblStylesheetFile.Enabled = false;
			m_txtStylesheetFile.Enabled = false;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnBrowseCertFile_Click method
		** Shows a dialog for choosing a certificate file.
		**-----------------------------------------------------------------------------------------------------------*/
		private void BtnBrowseCertFile_Click(object sender, System.EventArgs e) {
			// Get certificate file
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.CheckPathExists = true;
			ofd.Filter = "Personal Information Exchange File (*.pfx)|*.pfx";
			ofd.ValidateNames = true;
			if (ofd.ShowDialog(this) != DialogResult.OK) return;
			m_txtCertFile.Text = ofd.FileName;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** ChkUserPassword_Click method
		** Clear and disable the textbox for typing in the userpassword if CheckBox is unchecked.
		**-----------------------------------------------------------------------------------------------------------*/
		private void ChkUserPassword_Click(object sender, System.EventArgs e) {
			if (!m_chkUserPassword.Checked) m_txtUserPassword.Text = "";
			m_txtUserPassword.Enabled = m_chkUserPassword.Checked;
			m_chkPDFEmbeddableFontsOnly.Enabled = !m_chkUserPassword.Checked;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** ChkPDFEmbeddableFontsOnly_CheckedChanged method
		** Update the enable state of the group for a PDF's password.
		**-----------------------------------------------------------------------------------------------------------*/
		private void ChkPDFEmbeddableFontsOnly_CheckedChanged(object sender, System.EventArgs e) {
			m_grpPDFDocPwd.Enabled = !m_chkPDFEmbeddableFontsOnly.Checked;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** OptionsDialog_Load method
		** Transfer the filehandler's setting to the corresponding dialog's user interface.
		**-----------------------------------------------------------------------------------------------------------*/
		private void OptionsDialog_Load(object sender, System.EventArgs e) {
			// Get option-setup by FileHandler
			m_txtStylesheetFile.Text = m_fileHandler.CssFileName;

			switch (m_fileHandler.CssSaveMode) {
				case CssSaveMode.None:
					m_optNoStylesheet.Checked = true;
					break;

				case CssSaveMode.Inline:
					m_optInlineStylesheet.Checked = true;
					break;

				case CssSaveMode.OverwriteFile:
					m_optSaveStylesheetInSeperateFile.Checked = true;
					break;

				case CssSaveMode.CreateFile:
					m_optSaveButDoNotOverwriteExistingFile.Checked = true;
					break;
			}

			m_txtUserPassword.Text = m_fileHandler.PDFUserPassword;
			m_chkUserPassword.Checked = (m_fileHandler.PDFUserPassword.Length > 0);
			m_txtUserPassword.Enabled = m_chkUserPassword.Checked;

			m_txtCertFile.Text = m_fileHandler.PDFCertFilePath;
			m_txtCertPwd.Text = m_fileHandler.PDFCertPasswd;

			// PDF import combo box
			m_cbPDFImportMode.Items.Clear();
			m_cbPDFImportMode.Items.Add(Properties.Resources.OPT_DLG_PDFIMP_MODE_FRAMES);
			m_cbPDFImportMode.Items.Add(Properties.Resources.OPT_DLG_PDFIMP_MODE_PAR);
			m_cbPDFImportMode.Items.Add(Properties.Resources.OPT_DLG_PDFIMP_MODE_PLAIN);

			// Select item
			if ((m_fileHandler.PDFImportSettings & PDFImportSettings.GenerateTextFrames) == PDFImportSettings.GenerateTextFrames) {
				m_cbPDFImportMode.SelectedIndex = 0;
			}
			if ((m_fileHandler.PDFImportSettings & PDFImportSettings.GenerateParagraphs) == PDFImportSettings.GenerateParagraphs) {
				m_cbPDFImportMode.SelectedIndex = 1;
			}
			if ((m_fileHandler.PDFImportSettings & PDFImportSettings.GenerateLines) == PDFImportSettings.GenerateLines) {
				m_cbPDFImportMode.SelectedIndex = 2;
			}

			// PDF embedded files/data check boxes
			m_chbxLoadEmbeddedFiles.Checked = (m_fileHandler.PDFImportSettings & PDFImportSettings.LoadEmbeddedFiles) == PDFImportSettings.LoadEmbeddedFiles;
			m_chbxLoadAdditionalEmbeddedData.Checked = (m_fileHandler.PDFImportSettings & PDFImportSettings.LoadEmbeddedData) == PDFImportSettings.LoadEmbeddedData;


			m_chkPDFEmbeddableFontsOnly.Checked = m_textControl.FontSettings.EmbeddableFontsOnly;
		}//OptionsDialog_Load
	}
}
