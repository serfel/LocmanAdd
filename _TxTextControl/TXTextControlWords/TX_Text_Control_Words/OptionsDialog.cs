using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using TX_Text_Control_Words.FileHandling;
using TX_Text_Control_Words.Properties;
using TX_Text_Control_Words.Utils;
using TXTextControl;

namespace TX_Text_Control_Words
{
	public class OptionsDialog : Form
	{
		private TextControl m_textControl;

		private FileHandler m_fileHandler;

		private IContainer components;

		internal System.Windows.Forms.Button m_btnCancel;

		internal System.Windows.Forms.Button m_btnOK;

		private TabControl m_tabOptions;

		private TabPage m_tabPagePDFExport;

		private CheckBox m_chkPDFEmbeddableFontsOnly;

		private TabPage m_tabPagePDFImport;

		private GroupBox m_grpPDFImport;

		private ComboBox m_cbPDFImportMode;

		private TabPage m_tabPagePDFSecurity;

		private GroupBox m_grpPDFDigSig;

		private System.Windows.Forms.Button m_btnBrowseCertFile;

		private TextBox m_txtCertPwd;

		private Label m_lblCertPwd;

		private Label m_lblCertFile;

		private TextBox m_txtCertFile;

		private GroupBox m_grpPDFDocPwd;

		private TextBox m_txtUserPassword;

		private CheckBox m_chkUserPassword;

		private Label m_lblDocumentPassword;

		private TabPage m_tabPageHTML;

		internal GroupBox m_grpCSS;

		internal TextBox m_txtStylesheetFile;

		internal Label m_lblStylesheetFile;

		internal RadioButton m_optSaveButDoNotOverwriteExistingFile;

		internal RadioButton m_optSaveStylesheetInSeperateFile;

		internal RadioButton m_optInlineStylesheet;

		internal RadioButton m_optNoStylesheet;

		private Label m_lblPDFImportMode;

		private TableLayoutPanel m_tlpMainPanel;

		private TableLayoutPanel m_tlpHTML;

		private TableLayoutPanel m_tlpHTML_StylesheetGroup;

		private TableLayoutPanel m_tlpPDFSecurity;

		private TableLayoutPanel m_tlpDigitalSignatureGroup;

		private TableLayoutPanel m_tlpDocumentPasswordGroup;

		private TableLayoutPanel m_tlpPDFImport;

		private TableLayoutPanel m_tlpPDFImportOptions;

		private CheckBox m_chbxLoadEmbeddedFiles;

		private CheckBox m_chbxLoadAdditionalEmbeddedData;

		private TableLayoutPanel m_tlpPDFExport;

		private GroupBox m_grpPDFExport;

		private TableLayoutPanel m_tlpExportOptionsGroup;

		public OptionsDialog(TextControl textControl, FileHandler fileHandler)
		{
			this.InitializeComponent();
			this.LocalizeDialog();
			this.m_textControl = textControl;
			this.m_fileHandler = fileHandler;
		}

		private void LocalizeDialog()
		{
			this.Text = Resources.OPT_DLG_TITLE;
			this.m_btnOK.Text = Resources.BTN_OK;
			this.m_btnCancel.Text = Resources.BTN_CANCEL;
			this.m_tabPageHTML.Text = Resources.OPT_DLG_TAB_HTMLOPTS;
			this.m_tabPagePDFSecurity.Text = Resources.OPT_DLG_TAB_PDFSEC;
			this.m_tabPagePDFExport.Text = Resources.OPT_DLG_TAB_PDFEXP;
			this.m_tabPagePDFImport.Text = Resources.OPT_DLG_TAB_PDFIMP;
			this.m_grpCSS.Text = Resources.OPT_DLG_CSS_GRP_SAVEOPTS;
			this.m_optNoStylesheet.Text = Resources.OPT_DLG_CSS_NONE;
			this.m_optInlineStylesheet.Text = Resources.OPT_DLG_CSS_INLINE;
			this.m_optSaveStylesheetInSeperateFile.Text = Resources.OPT_DLG_CSS_SEPARATE_FILE;
			this.m_optSaveButDoNotOverwriteExistingFile.Text = Resources.OPT_DLG_CSS_SAVE_NOT_OVR;
			this.m_lblStylesheetFile.Text = Resources.OPT_DLG_CSS_LBL_FILE;
			this.m_grpPDFDigSig.Text = Resources.OPT_DLG_PDFSEC_GRP_DIG_SIG;
			this.m_grpPDFDocPwd.Text = Resources.OPT_DLG_PDFSEC_GRP_DOC_PWD;
			this.m_lblCertFile.Text = Resources.OPT_DLG_PDFSEC_LBL_CERT_FILE;
			this.m_lblCertPwd.Text = Resources.OPT_DLG_PDFSEC_LBL_CERT_PWD;
			this.m_chkUserPassword.Text = Resources.OPT_DLG_PDFSEC_REQ_DOC_PWD;
			this.m_lblDocumentPassword.Text = Resources.OPT_DLG_PDFSEC_LBL_DOC_PWD;
			this.m_grpPDFImport.Text = Resources.OPT_DLG_PDFIMP_GRP_OPTS;
			this.m_lblPDFImportMode.Text = Resources.OPT_DLG_PDFIMP_LBL_MODE;
			this.m_chbxLoadEmbeddedFiles.Text = Resources.OPT_DLG_PDFIMP_MODE_EMBEDDEDFILES;
			this.m_chbxLoadAdditionalEmbeddedData.Text = Resources.OPT_DLG_PDFIMP_MODE_ADDITIONAL_EMBEDDED_DATA;
			this.m_grpPDFExport.Text = Resources.OPT_DLG_PDFEXP_GRP_OPTS;
			this.m_chkPDFEmbeddableFontsOnly.Text = Resources.OPT_DLG_PDFEXP_ENABLE_PDFA;
		}

		private void BtnOK_Click(object sender, EventArgs e)
		{
			if (!this.ValidateDialogContent())
			{
				return;
			}
			if (this.m_txtCertFile.Text != "")
			{
				try
				{
					this.m_txtCertFile.Text = this.m_txtCertFile.Text.Trim();
					X509Certificate2 x = new X509Certificate2(this.m_txtCertFile.Text, this.m_txtCertPwd.Text);
					this.m_fileHandler.PDFSignature = new DigitalSignature(x, null);
					this.m_fileHandler.PDFCertFilePath = this.m_txtCertFile.Text;
					this.m_fileHandler.PDFCertPasswd = this.m_txtCertPwd.Text;
				}
				catch (Exception ex)
				{
					TX_Text_Control_Words.Utils.MessageBox.Show(this, string.Format(Resources.EXC_PDF_SIGNATURE, ex.Message), base.ProductName);
					return;
				}
			}
			this.m_fileHandler.PDFUserPassword = this.m_txtUserPassword.Text;
			this.m_fileHandler.CssFileName = this.m_txtStylesheetFile.Text;
			if (this.m_optNoStylesheet.Checked)
			{
				this.m_fileHandler.CssSaveMode = CssSaveMode.None;
			}
			else if (this.m_optInlineStylesheet.Checked)
			{
				this.m_fileHandler.CssSaveMode = CssSaveMode.Inline;
			}
			else if (this.m_optSaveStylesheetInSeperateFile.Checked)
			{
				this.m_fileHandler.CssSaveMode = CssSaveMode.OverwriteFile;
			}
			else
			{
				this.m_fileHandler.CssSaveMode = CssSaveMode.CreateFile;
			}
			PDFImportSettings pDFImportSettings = (PDFImportSettings)0;
			switch (this.m_cbPDFImportMode.SelectedIndex)
			{
			case 0:
				pDFImportSettings = PDFImportSettings.GenerateTextFrames;
				break;
			case 1:
				pDFImportSettings = PDFImportSettings.GenerateParagraphs;
				break;
			case 2:
				pDFImportSettings = PDFImportSettings.GenerateLines;
				break;
			}
			if (this.m_chbxLoadEmbeddedFiles.Checked)
			{
				pDFImportSettings |= PDFImportSettings.LoadEmbeddedFiles;
			}
			if (this.m_chbxLoadAdditionalEmbeddedData.Checked)
			{
				pDFImportSettings |= PDFImportSettings.LoadEmbeddedData;
			}
			this.m_fileHandler.PDFImportSettings = pDFImportSettings;
			this.m_textControl.FontSettings.EmbeddableFontsOnly = this.m_chkPDFEmbeddableFontsOnly.Checked;
			base.Close();
		}

		private bool ValidateDialogContent()
		{
			if (this.m_chkUserPassword.Checked && this.m_txtUserPassword.Text.Length == 0)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, Resources.OPT_DLG_PDFSEC_ERR_NO_DOC_PWD, base.ProductName);
				return false;
			}
			return true;
		}

		private void OptSaveButDoNotOverwriteExistingFile_CheckedChanged(object sender, EventArgs e)
		{
			this.m_lblStylesheetFile.Enabled = true;
			this.m_txtStylesheetFile.Enabled = true;
		}

		private void OptSaveStylesheetInSeperateFile_CheckedChanged(object sender, EventArgs e)
		{
			this.m_lblStylesheetFile.Enabled = true;
			this.m_txtStylesheetFile.Enabled = true;
		}

		private void OptInlineStylesheet_CheckedChanged(object sender, EventArgs e)
		{
			this.m_lblStylesheetFile.Enabled = true;
			this.m_txtStylesheetFile.Enabled = true;
		}

		private void OptNoStylesheet_CheckedChanged(object sender, EventArgs e)
		{
			this.m_lblStylesheetFile.Enabled = false;
			this.m_txtStylesheetFile.Enabled = false;
		}

		private void BtnBrowseCertFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.CheckPathExists = true;
			openFileDialog.Filter = "Personal Information Exchange File (*.pfx)|*.pfx";
			openFileDialog.ValidateNames = true;
			if (openFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				this.m_txtCertFile.Text = openFileDialog.FileName;
			}
		}

		private void ChkUserPassword_Click(object sender, EventArgs e)
		{
			if (!this.m_chkUserPassword.Checked)
			{
				this.m_txtUserPassword.Text = "";
			}
			this.m_txtUserPassword.Enabled = this.m_chkUserPassword.Checked;
			this.m_chkPDFEmbeddableFontsOnly.Enabled = !this.m_chkUserPassword.Checked;
		}

		private void ChkPDFEmbeddableFontsOnly_CheckedChanged(object sender, EventArgs e)
		{
			this.m_grpPDFDocPwd.Enabled = !this.m_chkPDFEmbeddableFontsOnly.Checked;
		}

		private void OptionsDialog_Load(object sender, EventArgs e)
		{
			this.m_txtStylesheetFile.Text = this.m_fileHandler.CssFileName;
			switch (this.m_fileHandler.CssSaveMode)
			{
			case CssSaveMode.None:
				this.m_optNoStylesheet.Checked = true;
				break;
			case CssSaveMode.Inline:
				this.m_optInlineStylesheet.Checked = true;
				break;
			case CssSaveMode.OverwriteFile:
				this.m_optSaveStylesheetInSeperateFile.Checked = true;
				break;
			case CssSaveMode.CreateFile:
				this.m_optSaveButDoNotOverwriteExistingFile.Checked = true;
				break;
			}
			this.m_txtUserPassword.Text = this.m_fileHandler.PDFUserPassword;
			this.m_chkUserPassword.Checked = this.m_fileHandler.PDFUserPassword.Length > 0;
			this.m_txtUserPassword.Enabled = this.m_chkUserPassword.Checked;
			this.m_txtCertFile.Text = this.m_fileHandler.PDFCertFilePath;
			this.m_txtCertPwd.Text = this.m_fileHandler.PDFCertPasswd;
			this.m_cbPDFImportMode.Items.Clear();
			this.m_cbPDFImportMode.Items.Add(Resources.OPT_DLG_PDFIMP_MODE_FRAMES);
			this.m_cbPDFImportMode.Items.Add(Resources.OPT_DLG_PDFIMP_MODE_PAR);
			this.m_cbPDFImportMode.Items.Add(Resources.OPT_DLG_PDFIMP_MODE_PLAIN);
			if ((this.m_fileHandler.PDFImportSettings & PDFImportSettings.GenerateTextFrames) == PDFImportSettings.GenerateTextFrames)
			{
				this.m_cbPDFImportMode.SelectedIndex = 0;
			}
			if ((this.m_fileHandler.PDFImportSettings & PDFImportSettings.GenerateParagraphs) == PDFImportSettings.GenerateParagraphs)
			{
				this.m_cbPDFImportMode.SelectedIndex = 1;
			}
			if ((this.m_fileHandler.PDFImportSettings & PDFImportSettings.GenerateLines) == PDFImportSettings.GenerateLines)
			{
				this.m_cbPDFImportMode.SelectedIndex = 2;
			}
			this.m_chbxLoadEmbeddedFiles.Checked = (this.m_fileHandler.PDFImportSettings & PDFImportSettings.LoadEmbeddedFiles) == PDFImportSettings.LoadEmbeddedFiles;
			this.m_chbxLoadAdditionalEmbeddedData.Checked = (this.m_fileHandler.PDFImportSettings & PDFImportSettings.LoadEmbeddedData) == PDFImportSettings.LoadEmbeddedData;
			this.m_chkPDFEmbeddableFontsOnly.Checked = this.m_textControl.FontSettings.EmbeddableFontsOnly;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_tabOptions = new System.Windows.Forms.TabControl();
			this.m_tabPageHTML = new System.Windows.Forms.TabPage();
			this.m_tlpHTML = new System.Windows.Forms.TableLayoutPanel();
			this.m_grpCSS = new System.Windows.Forms.GroupBox();
			this.m_tlpHTML_StylesheetGroup = new System.Windows.Forms.TableLayoutPanel();
			this.m_optNoStylesheet = new System.Windows.Forms.RadioButton();
			this.m_optInlineStylesheet = new System.Windows.Forms.RadioButton();
			this.m_optSaveStylesheetInSeperateFile = new System.Windows.Forms.RadioButton();
			this.m_optSaveButDoNotOverwriteExistingFile = new System.Windows.Forms.RadioButton();
			this.m_lblStylesheetFile = new System.Windows.Forms.Label();
			this.m_txtStylesheetFile = new System.Windows.Forms.TextBox();
			this.m_tabPagePDFSecurity = new System.Windows.Forms.TabPage();
			this.m_tlpPDFSecurity = new System.Windows.Forms.TableLayoutPanel();
			this.m_grpPDFDigSig = new System.Windows.Forms.GroupBox();
			this.m_tlpDigitalSignatureGroup = new System.Windows.Forms.TableLayoutPanel();
			this.m_lblCertFile = new System.Windows.Forms.Label();
			this.m_btnBrowseCertFile = new System.Windows.Forms.Button();
			this.m_lblCertPwd = new System.Windows.Forms.Label();
			this.m_txtCertPwd = new System.Windows.Forms.TextBox();
			this.m_txtCertFile = new System.Windows.Forms.TextBox();
			this.m_grpPDFDocPwd = new System.Windows.Forms.GroupBox();
			this.m_tlpDocumentPasswordGroup = new System.Windows.Forms.TableLayoutPanel();
			this.m_chkUserPassword = new System.Windows.Forms.CheckBox();
			this.m_txtUserPassword = new System.Windows.Forms.TextBox();
			this.m_lblDocumentPassword = new System.Windows.Forms.Label();
			this.m_tabPagePDFImport = new System.Windows.Forms.TabPage();
			this.m_tlpPDFImport = new System.Windows.Forms.TableLayoutPanel();
			this.m_grpPDFImport = new System.Windows.Forms.GroupBox();
			this.m_tlpPDFImportOptions = new System.Windows.Forms.TableLayoutPanel();
			this.m_cbPDFImportMode = new System.Windows.Forms.ComboBox();
			this.m_lblPDFImportMode = new System.Windows.Forms.Label();
			this.m_chbxLoadEmbeddedFiles = new System.Windows.Forms.CheckBox();
			this.m_chbxLoadAdditionalEmbeddedData = new System.Windows.Forms.CheckBox();
			this.m_tabPagePDFExport = new System.Windows.Forms.TabPage();
			this.m_tlpPDFExport = new System.Windows.Forms.TableLayoutPanel();
			this.m_chkPDFEmbeddableFontsOnly = new System.Windows.Forms.CheckBox();
			this.m_tlpMainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.m_tlpExportOptionsGroup = new System.Windows.Forms.TableLayoutPanel();
			this.m_grpPDFExport = new System.Windows.Forms.GroupBox();
			this.m_tabOptions.SuspendLayout();
			this.m_tabPageHTML.SuspendLayout();
			this.m_tlpHTML.SuspendLayout();
			this.m_grpCSS.SuspendLayout();
			this.m_tlpHTML_StylesheetGroup.SuspendLayout();
			this.m_tabPagePDFSecurity.SuspendLayout();
			this.m_tlpPDFSecurity.SuspendLayout();
			this.m_grpPDFDigSig.SuspendLayout();
			this.m_tlpDigitalSignatureGroup.SuspendLayout();
			this.m_grpPDFDocPwd.SuspendLayout();
			this.m_tlpDocumentPasswordGroup.SuspendLayout();
			this.m_tabPagePDFImport.SuspendLayout();
			this.m_tlpPDFImport.SuspendLayout();
			this.m_grpPDFImport.SuspendLayout();
			this.m_tlpPDFImportOptions.SuspendLayout();
			this.m_tabPagePDFExport.SuspendLayout();
			this.m_tlpPDFExport.SuspendLayout();
			this.m_tlpMainPanel.SuspendLayout();
			this.m_tlpExportOptionsGroup.SuspendLayout();
			this.m_grpPDFExport.SuspendLayout();
			base.SuspendLayout();
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnCancel.Location = new System.Drawing.Point(487, 225);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(7, 0, 0, 0);
			this.m_btnCancel.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
			this.m_btnCancel.TabIndex = 1;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnOK.Location = new System.Drawing.Point(405, 225);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(7, 0, 0, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 25);
			this.m_btnOK.TabIndex = 0;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.Click += new System.EventHandler(BtnOK_Click);
			this.m_tlpMainPanel.SetColumnSpan(this.m_tabOptions, 3);
			this.m_tabOptions.Controls.Add(this.m_tabPageHTML);
			this.m_tabOptions.Controls.Add(this.m_tabPagePDFSecurity);
			this.m_tabOptions.Controls.Add(this.m_tabPagePDFImport);
			this.m_tabOptions.Controls.Add(this.m_tabPagePDFExport);
			this.m_tabOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tabOptions.Location = new System.Drawing.Point(0, 3);
			this.m_tabOptions.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.m_tabOptions.Name = "m_tabOptions";
			this.m_tabOptions.SelectedIndex = 0;
			this.m_tabOptions.Size = new System.Drawing.Size(562, 219);
			this.m_tabOptions.TabIndex = 4;
			this.m_tabPageHTML.Controls.Add(this.m_tlpHTML);
			this.m_tabPageHTML.Location = new System.Drawing.Point(4, 24);
			this.m_tabPageHTML.Margin = new System.Windows.Forms.Padding(3, 3, 7, 7);
			this.m_tabPageHTML.Name = "m_tabPageHTML";
			this.m_tabPageHTML.Padding = new System.Windows.Forms.Padding(3);
			this.m_tabPageHTML.Size = new System.Drawing.Size(507, 191);
			this.m_tabPageHTML.TabIndex = 3;
			this.m_tabPageHTML.Text = "HTML";
			this.m_tabPageHTML.UseVisualStyleBackColor = true;
			this.m_tlpHTML.AutoSize = true;
			this.m_tlpHTML.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpHTML.ColumnCount = 1;
			this.m_tlpHTML.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpHTML.Controls.Add(this.m_grpCSS, 0, 0);
			this.m_tlpHTML.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpHTML.Location = new System.Drawing.Point(3, 3);
			this.m_tlpHTML.Margin = new System.Windows.Forms.Padding(0);
			this.m_tlpHTML.Name = "m_tlpHTML";
			this.m_tlpHTML.RowCount = 2;
			this.m_tlpHTML.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpHTML.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpHTML.Size = new System.Drawing.Size(501, 185);
			this.m_tlpHTML.TabIndex = 4;
			this.m_grpCSS.AutoSize = true;
			this.m_grpCSS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_grpCSS.Controls.Add(this.m_tlpHTML_StylesheetGroup);
			this.m_grpCSS.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_grpCSS.Location = new System.Drawing.Point(3, 3);
			this.m_grpCSS.Name = "m_grpCSS";
			this.m_grpCSS.Size = new System.Drawing.Size(495, 180);
			this.m_grpCSS.TabIndex = 3;
			this.m_grpCSS.TabStop = false;
			this.m_grpCSS.Text = "HTML stylesheet save options";
			this.m_tlpHTML_StylesheetGroup.AutoSize = true;
			this.m_tlpHTML_StylesheetGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpHTML_StylesheetGroup.ColumnCount = 1;
			this.m_tlpHTML_StylesheetGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpHTML_StylesheetGroup.Controls.Add(this.m_optNoStylesheet, 0, 0);
			this.m_tlpHTML_StylesheetGroup.Controls.Add(this.m_optInlineStylesheet, 0, 1);
			this.m_tlpHTML_StylesheetGroup.Controls.Add(this.m_optSaveStylesheetInSeperateFile, 0, 2);
			this.m_tlpHTML_StylesheetGroup.Controls.Add(this.m_optSaveButDoNotOverwriteExistingFile, 0, 3);
			this.m_tlpHTML_StylesheetGroup.Controls.Add(this.m_lblStylesheetFile, 0, 4);
			this.m_tlpHTML_StylesheetGroup.Controls.Add(this.m_txtStylesheetFile, 0, 5);
			this.m_tlpHTML_StylesheetGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpHTML_StylesheetGroup.Location = new System.Drawing.Point(3, 19);
			this.m_tlpHTML_StylesheetGroup.Name = "m_tlpHTML_StylesheetGroup";
			this.m_tlpHTML_StylesheetGroup.RowCount = 7;
			this.m_tlpHTML_StylesheetGroup.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpHTML_StylesheetGroup.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpHTML_StylesheetGroup.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpHTML_StylesheetGroup.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpHTML_StylesheetGroup.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpHTML_StylesheetGroup.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpHTML_StylesheetGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpHTML_StylesheetGroup.Size = new System.Drawing.Size(489, 158);
			this.m_tlpHTML_StylesheetGroup.TabIndex = 4;
			this.m_optNoStylesheet.AutoSize = true;
			this.m_optNoStylesheet.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_optNoStylesheet.Location = new System.Drawing.Point(3, 3);
			this.m_optNoStylesheet.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
			this.m_optNoStylesheet.Name = "m_optNoStylesheet";
			this.m_optNoStylesheet.Size = new System.Drawing.Size(483, 19);
			this.m_optNoStylesheet.TabIndex = 0;
			this.m_optNoStylesheet.TabStop = true;
			this.m_optNoStylesheet.Text = "&No stylesheet";
			this.m_optNoStylesheet.CheckedChanged += new System.EventHandler(OptNoStylesheet_CheckedChanged);
			this.m_optInlineStylesheet.AutoSize = true;
			this.m_optInlineStylesheet.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_optInlineStylesheet.Location = new System.Drawing.Point(3, 29);
			this.m_optInlineStylesheet.Margin = new System.Windows.Forms.Padding(3, 0, 3, 7);
			this.m_optInlineStylesheet.Name = "m_optInlineStylesheet";
			this.m_optInlineStylesheet.Size = new System.Drawing.Size(483, 19);
			this.m_optInlineStylesheet.TabIndex = 1;
			this.m_optInlineStylesheet.Text = "&Inline stylesheet";
			this.m_optInlineStylesheet.CheckedChanged += new System.EventHandler(OptInlineStylesheet_CheckedChanged);
			this.m_optSaveStylesheetInSeperateFile.AutoSize = true;
			this.m_optSaveStylesheetInSeperateFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_optSaveStylesheetInSeperateFile.Location = new System.Drawing.Point(3, 55);
			this.m_optSaveStylesheetInSeperateFile.Margin = new System.Windows.Forms.Padding(3, 0, 3, 7);
			this.m_optSaveStylesheetInSeperateFile.Name = "m_optSaveStylesheetInSeperateFile";
			this.m_optSaveStylesheetInSeperateFile.Size = new System.Drawing.Size(483, 19);
			this.m_optSaveStylesheetInSeperateFile.TabIndex = 2;
			this.m_optSaveStylesheetInSeperateFile.Text = "&Save stylesheet in separate file";
			this.m_optSaveStylesheetInSeperateFile.CheckedChanged += new System.EventHandler(OptSaveStylesheetInSeperateFile_CheckedChanged);
			this.m_optSaveButDoNotOverwriteExistingFile.AutoSize = true;
			this.m_optSaveButDoNotOverwriteExistingFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_optSaveButDoNotOverwriteExistingFile.Location = new System.Drawing.Point(3, 81);
			this.m_optSaveButDoNotOverwriteExistingFile.Margin = new System.Windows.Forms.Padding(3, 0, 3, 7);
			this.m_optSaveButDoNotOverwriteExistingFile.Name = "m_optSaveButDoNotOverwriteExistingFile";
			this.m_optSaveButDoNotOverwriteExistingFile.Size = new System.Drawing.Size(483, 19);
			this.m_optSaveButDoNotOverwriteExistingFile.TabIndex = 3;
			this.m_optSaveButDoNotOverwriteExistingFile.Text = "Sa&ve but do not overwrite existing file";
			this.m_optSaveButDoNotOverwriteExistingFile.CheckedChanged += new System.EventHandler(OptSaveButDoNotOverwriteExistingFile_CheckedChanged);
			this.m_lblStylesheetFile.AutoSize = true;
			this.m_lblStylesheetFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblStylesheetFile.Location = new System.Drawing.Point(3, 107);
			this.m_lblStylesheetFile.Margin = new System.Windows.Forms.Padding(3, 0, 3, 7);
			this.m_lblStylesheetFile.Name = "m_lblStylesheetFile";
			this.m_lblStylesheetFile.Size = new System.Drawing.Size(483, 15);
			this.m_lblStylesheetFile.TabIndex = 4;
			this.m_lblStylesheetFile.Text = "Stylesheet &file:";
			this.m_txtStylesheetFile.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_txtStylesheetFile.Location = new System.Drawing.Point(3, 132);
			this.m_txtStylesheetFile.Name = "m_txtStylesheetFile";
			this.m_txtStylesheetFile.Size = new System.Drawing.Size(187, 23);
			this.m_txtStylesheetFile.TabIndex = 5;
			this.m_txtStylesheetFile.Tag = "";
			this.m_tabPagePDFSecurity.Controls.Add(this.m_tlpPDFSecurity);
			this.m_tabPagePDFSecurity.Location = new System.Drawing.Point(4, 24);
			this.m_tabPagePDFSecurity.Name = "m_tabPagePDFSecurity";
			this.m_tabPagePDFSecurity.Padding = new System.Windows.Forms.Padding(3);
			this.m_tabPagePDFSecurity.Size = new System.Drawing.Size(554, 191);
			this.m_tabPagePDFSecurity.TabIndex = 0;
			this.m_tabPagePDFSecurity.Text = "PDF Security";
			this.m_tabPagePDFSecurity.UseVisualStyleBackColor = true;
			this.m_tlpPDFSecurity.AutoSize = true;
			this.m_tlpPDFSecurity.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpPDFSecurity.ColumnCount = 1;
			this.m_tlpPDFSecurity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpPDFSecurity.Controls.Add(this.m_grpPDFDigSig, 0, 0);
			this.m_tlpPDFSecurity.Controls.Add(this.m_grpPDFDocPwd, 0, 1);
			this.m_tlpPDFSecurity.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpPDFSecurity.Location = new System.Drawing.Point(3, 3);
			this.m_tlpPDFSecurity.Margin = new System.Windows.Forms.Padding(0);
			this.m_tlpPDFSecurity.Name = "m_tlpPDFSecurity";
			this.m_tlpPDFSecurity.RowCount = 3;
			this.m_tlpPDFSecurity.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpPDFSecurity.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpPDFSecurity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpPDFSecurity.Size = new System.Drawing.Size(548, 185);
			this.m_tlpPDFSecurity.TabIndex = 1;
			this.m_grpPDFDigSig.AutoSize = true;
			this.m_grpPDFDigSig.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_grpPDFDigSig.Controls.Add(this.m_tlpDigitalSignatureGroup);
			this.m_grpPDFDigSig.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_grpPDFDigSig.Location = new System.Drawing.Point(3, 3);
			this.m_grpPDFDigSig.Name = "m_grpPDFDigSig";
			this.m_grpPDFDigSig.Size = new System.Drawing.Size(542, 82);
			this.m_grpPDFDigSig.TabIndex = 0;
			this.m_grpPDFDigSig.TabStop = false;
			this.m_grpPDFDigSig.Text = "Digital Signature";
			this.m_tlpDigitalSignatureGroup.AutoSize = true;
			this.m_tlpDigitalSignatureGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpDigitalSignatureGroup.ColumnCount = 4;
			this.m_tlpDigitalSignatureGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpDigitalSignatureGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpDigitalSignatureGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpDigitalSignatureGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpDigitalSignatureGroup.Controls.Add(this.m_lblCertFile, 0, 0);
			this.m_tlpDigitalSignatureGroup.Controls.Add(this.m_btnBrowseCertFile, 2, 0);
			this.m_tlpDigitalSignatureGroup.Controls.Add(this.m_lblCertPwd, 0, 1);
			this.m_tlpDigitalSignatureGroup.Controls.Add(this.m_txtCertPwd, 1, 1);
			this.m_tlpDigitalSignatureGroup.Controls.Add(this.m_txtCertFile, 1, 0);
			this.m_tlpDigitalSignatureGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_tlpDigitalSignatureGroup.Location = new System.Drawing.Point(3, 19);
			this.m_tlpDigitalSignatureGroup.Name = "m_tlpDigitalSignatureGroup";
			this.m_tlpDigitalSignatureGroup.RowCount = 3;
			this.m_tlpDigitalSignatureGroup.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpDigitalSignatureGroup.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpDigitalSignatureGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpDigitalSignatureGroup.Size = new System.Drawing.Size(536, 60);
			this.m_tlpDigitalSignatureGroup.TabIndex = 5;
			this.m_lblCertFile.AutoSize = true;
			this.m_lblCertFile.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_lblCertFile.Location = new System.Drawing.Point(3, 0);
			this.m_lblCertFile.Name = "m_lblCertFile";
			this.m_lblCertFile.Size = new System.Drawing.Size(121, 31);
			this.m_lblCertFile.TabIndex = 0;
			this.m_lblCertFile.Text = "Certificate File (*.pfx):";
			this.m_lblCertFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_btnBrowseCertFile.AutoSize = true;
			this.m_btnBrowseCertFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnBrowseCertFile.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_btnBrowseCertFile.Location = new System.Drawing.Point(337, 3);
			this.m_btnBrowseCertFile.Name = "m_btnBrowseCertFile";
			this.m_btnBrowseCertFile.Size = new System.Drawing.Size(26, 25);
			this.m_btnBrowseCertFile.TabIndex = 2;
			this.m_btnBrowseCertFile.Text = "...";
			this.m_btnBrowseCertFile.UseVisualStyleBackColor = true;
			this.m_btnBrowseCertFile.Click += new System.EventHandler(BtnBrowseCertFile_Click);
			this.m_lblCertPwd.AutoSize = true;
			this.m_lblCertPwd.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_lblCertPwd.Location = new System.Drawing.Point(3, 31);
			this.m_lblCertPwd.Name = "m_lblCertPwd";
			this.m_lblCertPwd.Size = new System.Drawing.Size(117, 29);
			this.m_lblCertPwd.TabIndex = 3;
			this.m_lblCertPwd.Text = "Certificate Password:";
			this.m_lblCertPwd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_txtCertPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtCertPwd.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_txtCertPwd.Location = new System.Drawing.Point(130, 34);
			this.m_txtCertPwd.Name = "m_txtCertPwd";
			this.m_txtCertPwd.PasswordChar = '*';
			this.m_txtCertPwd.Size = new System.Drawing.Size(201, 23);
			this.m_txtCertPwd.TabIndex = 4;
			this.m_txtCertPwd.UseSystemPasswordChar = true;
			this.m_txtCertFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtCertFile.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_txtCertFile.Location = new System.Drawing.Point(130, 3);
			this.m_txtCertFile.Name = "m_txtCertFile";
			this.m_txtCertFile.Size = new System.Drawing.Size(201, 23);
			this.m_txtCertFile.TabIndex = 1;
			this.m_grpPDFDocPwd.AutoSize = true;
			this.m_grpPDFDocPwd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_grpPDFDocPwd.Controls.Add(this.m_tlpDocumentPasswordGroup);
			this.m_grpPDFDocPwd.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_grpPDFDocPwd.Location = new System.Drawing.Point(3, 95);
			this.m_grpPDFDocPwd.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
			this.m_grpPDFDocPwd.Name = "m_grpPDFDocPwd";
			this.m_grpPDFDocPwd.Size = new System.Drawing.Size(542, 76);
			this.m_grpPDFDocPwd.TabIndex = 0;
			this.m_grpPDFDocPwd.TabStop = false;
			this.m_grpPDFDocPwd.Text = "PDF Document Password";
			this.m_tlpDocumentPasswordGroup.AutoSize = true;
			this.m_tlpDocumentPasswordGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpDocumentPasswordGroup.ColumnCount = 3;
			this.m_tlpDocumentPasswordGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpDocumentPasswordGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpDocumentPasswordGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpDocumentPasswordGroup.Controls.Add(this.m_chkUserPassword, 0, 0);
			this.m_tlpDocumentPasswordGroup.Controls.Add(this.m_txtUserPassword, 1, 1);
			this.m_tlpDocumentPasswordGroup.Controls.Add(this.m_lblDocumentPassword, 0, 1);
			this.m_tlpDocumentPasswordGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_tlpDocumentPasswordGroup.Location = new System.Drawing.Point(3, 19);
			this.m_tlpDocumentPasswordGroup.Name = "m_tlpDocumentPasswordGroup";
			this.m_tlpDocumentPasswordGroup.RowCount = 3;
			this.m_tlpDocumentPasswordGroup.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpDocumentPasswordGroup.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpDocumentPasswordGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpDocumentPasswordGroup.Size = new System.Drawing.Size(536, 54);
			this.m_tlpDocumentPasswordGroup.TabIndex = 8;
			this.m_chkUserPassword.AutoSize = true;
			this.m_tlpDocumentPasswordGroup.SetColumnSpan(this.m_chkUserPassword, 2);
			this.m_chkUserPassword.Location = new System.Drawing.Point(3, 3);
			this.m_chkUserPassword.Name = "m_chkUserPassword";
			this.m_chkUserPassword.Size = new System.Drawing.Size(250, 19);
			this.m_chkUserPassword.TabIndex = 5;
			this.m_chkUserPassword.Text = "&Require a password to open the document";
			this.m_chkUserPassword.Click += new System.EventHandler(ChkUserPassword_Click);
			this.m_txtUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtUserPassword.Location = new System.Drawing.Point(128, 28);
			this.m_txtUserPassword.Name = "m_txtUserPassword";
			this.m_txtUserPassword.PasswordChar = '*';
			this.m_txtUserPassword.Size = new System.Drawing.Size(133, 23);
			this.m_txtUserPassword.TabIndex = 7;
			this.m_txtUserPassword.UseSystemPasswordChar = true;
			this.m_lblDocumentPassword.AutoSize = true;
			this.m_lblDocumentPassword.Location = new System.Drawing.Point(3, 28);
			this.m_lblDocumentPassword.Margin = new System.Windows.Forms.Padding(3);
			this.m_lblDocumentPassword.Name = "m_lblDocumentPassword";
			this.m_lblDocumentPassword.Size = new System.Drawing.Size(119, 15);
			this.m_lblDocumentPassword.TabIndex = 6;
			this.m_lblDocumentPassword.Text = "&Document Password:";
			this.m_tabPagePDFImport.Controls.Add(this.m_tlpPDFImport);
			this.m_tabPagePDFImport.Location = new System.Drawing.Point(4, 24);
			this.m_tabPagePDFImport.Name = "m_tabPagePDFImport";
			this.m_tabPagePDFImport.Padding = new System.Windows.Forms.Padding(3);
			this.m_tabPagePDFImport.Size = new System.Drawing.Size(554, 191);
			this.m_tabPagePDFImport.TabIndex = 1;
			this.m_tabPagePDFImport.Text = "PDF Import";
			this.m_tabPagePDFImport.UseVisualStyleBackColor = true;
			this.m_tlpPDFImport.AutoSize = true;
			this.m_tlpPDFImport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpPDFImport.ColumnCount = 1;
			this.m_tlpPDFImport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpPDFImport.Controls.Add(this.m_grpPDFImport, 0, 0);
			this.m_tlpPDFImport.Controls.Add(this.m_chbxLoadEmbeddedFiles, 0, 1);
			this.m_tlpPDFImport.Controls.Add(this.m_chbxLoadAdditionalEmbeddedData, 0, 2);
			this.m_tlpPDFImport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpPDFImport.Location = new System.Drawing.Point(3, 3);
			this.m_tlpPDFImport.Margin = new System.Windows.Forms.Padding(0);
			this.m_tlpPDFImport.Name = "m_tlpPDFImport";
			this.m_tlpPDFImport.RowCount = 4;
			this.m_tlpPDFImport.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpPDFImport.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpPDFImport.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpPDFImport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpPDFImport.Size = new System.Drawing.Size(548, 185);
			this.m_tlpPDFImport.TabIndex = 8;
			this.m_grpPDFImport.AutoSize = true;
			this.m_grpPDFImport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_grpPDFImport.Controls.Add(this.m_tlpPDFImportOptions);
			this.m_grpPDFImport.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_grpPDFImport.Location = new System.Drawing.Point(3, 3);
			this.m_grpPDFImport.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
			this.m_grpPDFImport.Name = "m_grpPDFImport";
			this.m_grpPDFImport.Size = new System.Drawing.Size(542, 51);
			this.m_grpPDFImport.TabIndex = 7;
			this.m_grpPDFImport.TabStop = false;
			this.m_grpPDFImport.Text = "PDF Import Options:";
			this.m_tlpPDFImportOptions.AutoSize = true;
			this.m_tlpPDFImportOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpPDFImportOptions.ColumnCount = 3;
			this.m_tlpPDFImportOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpPDFImportOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpPDFImportOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpPDFImportOptions.Controls.Add(this.m_cbPDFImportMode, 1, 0);
			this.m_tlpPDFImportOptions.Controls.Add(this.m_lblPDFImportMode, 0, 0);
			this.m_tlpPDFImportOptions.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_tlpPDFImportOptions.Location = new System.Drawing.Point(3, 19);
			this.m_tlpPDFImportOptions.Name = "m_tlpPDFImportOptions";
			this.m_tlpPDFImportOptions.RowCount = 2;
			this.m_tlpPDFImportOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpPDFImportOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpPDFImportOptions.Size = new System.Drawing.Size(536, 29);
			this.m_tlpPDFImportOptions.TabIndex = 14;
			this.m_cbPDFImportMode.AccessibleName = "";
			this.m_cbPDFImportMode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_cbPDFImportMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cbPDFImportMode.FormattingEnabled = true;
			this.m_cbPDFImportMode.Items.AddRange(new object[3] { "Best match the original appearance using tables, images and text frames", "Text and paragraph formatting, images are discarded", "Text only, images and paragraph formatting are discarded" });
			this.m_cbPDFImportMode.Location = new System.Drawing.Point(89, 3);
			this.m_cbPDFImportMode.MaxDropDownItems = 3;
			this.m_cbPDFImportMode.MinimumSize = new System.Drawing.Size(405, 0);
			this.m_cbPDFImportMode.Name = "m_cbPDFImportMode";
			this.m_cbPDFImportMode.Size = new System.Drawing.Size(420, 23);
			this.m_cbPDFImportMode.TabIndex = 13;
			this.m_lblPDFImportMode.AutoSize = true;
			this.m_lblPDFImportMode.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_lblPDFImportMode.Location = new System.Drawing.Point(3, 0);
			this.m_lblPDFImportMode.Name = "m_lblPDFImportMode";
			this.m_lblPDFImportMode.Size = new System.Drawing.Size(80, 29);
			this.m_lblPDFImportMode.TabIndex = 12;
			this.m_lblPDFImportMode.Text = "&Import mode:";
			this.m_lblPDFImportMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_chbxLoadEmbeddedFiles.AutoSize = true;
			this.m_chbxLoadEmbeddedFiles.Checked = true;
			this.m_chbxLoadEmbeddedFiles.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_chbxLoadEmbeddedFiles.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_chbxLoadEmbeddedFiles.Location = new System.Drawing.Point(3, 64);
			this.m_chbxLoadEmbeddedFiles.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
			this.m_chbxLoadEmbeddedFiles.Name = "m_chbxLoadEmbeddedFiles";
			this.m_chbxLoadEmbeddedFiles.Size = new System.Drawing.Size(542, 19);
			this.m_chbxLoadEmbeddedFiles.TabIndex = 8;
			this.m_chbxLoadEmbeddedFiles.Text = "Load embedded files";
			this.m_chbxLoadEmbeddedFiles.UseVisualStyleBackColor = true;
			this.m_chbxLoadAdditionalEmbeddedData.AutoSize = true;
			this.m_chbxLoadAdditionalEmbeddedData.Location = new System.Drawing.Point(3, 90);
			this.m_chbxLoadAdditionalEmbeddedData.Margin = new System.Windows.Forms.Padding(3, 0, 3, 7);
			this.m_chbxLoadAdditionalEmbeddedData.Name = "m_chbxLoadAdditionalEmbeddedData";
			this.m_chbxLoadAdditionalEmbeddedData.Size = new System.Drawing.Size(383, 19);
			this.m_chbxLoadAdditionalEmbeddedData.TabIndex = 9;
			this.m_chbxLoadAdditionalEmbeddedData.Text = "Load additional embedded data (coordinates, formfields, metadata)";
			this.m_chbxLoadAdditionalEmbeddedData.UseVisualStyleBackColor = true;
			this.m_tabPagePDFExport.Controls.Add(this.m_tlpPDFExport);
			this.m_tabPagePDFExport.Location = new System.Drawing.Point(4, 24);
			this.m_tabPagePDFExport.Name = "m_tabPagePDFExport";
			this.m_tabPagePDFExport.Padding = new System.Windows.Forms.Padding(3);
			this.m_tabPagePDFExport.Size = new System.Drawing.Size(554, 191);
			this.m_tabPagePDFExport.TabIndex = 2;
			this.m_tabPagePDFExport.Text = "PDF/A Export";
			this.m_tabPagePDFExport.UseVisualStyleBackColor = true;
			this.m_tlpPDFExport.AutoSize = true;
			this.m_tlpPDFExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpPDFExport.ColumnCount = 1;
			this.m_tlpPDFExport.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpPDFExport.Controls.Add(this.m_grpPDFExport, 0, 0);
			this.m_tlpPDFExport.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_tlpPDFExport.Location = new System.Drawing.Point(3, 3);
			this.m_tlpPDFExport.Margin = new System.Windows.Forms.Padding(0);
			this.m_tlpPDFExport.Name = "m_tlpPDFExport";
			this.m_tlpPDFExport.RowCount = 2;
			this.m_tlpPDFExport.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpPDFExport.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpPDFExport.Size = new System.Drawing.Size(548, 57);
			this.m_tlpPDFExport.TabIndex = 9;
			this.m_chkPDFEmbeddableFontsOnly.AutoSize = true;
			this.m_chkPDFEmbeddableFontsOnly.Location = new System.Drawing.Point(3, 5);
			this.m_chkPDFEmbeddableFontsOnly.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.m_chkPDFEmbeddableFontsOnly.Name = "m_chkPDFEmbeddableFontsOnly";
			this.m_chkPDFEmbeddableFontsOnly.Size = new System.Drawing.Size(170, 19);
			this.m_chkPDFEmbeddableFontsOnly.TabIndex = 0;
			this.m_chkPDFEmbeddableFontsOnly.Text = "&Use embeddable fonts only";
			this.m_chkPDFEmbeddableFontsOnly.UseVisualStyleBackColor = true;
			this.m_chkPDFEmbeddableFontsOnly.CheckedChanged += new System.EventHandler(ChkPDFEmbeddableFontsOnly_CheckedChanged);
			this.m_tlpMainPanel.AutoSize = true;
			this.m_tlpMainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpMainPanel.ColumnCount = 3;
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpMainPanel.Controls.Add(this.m_btnCancel, 2, 1);
			this.m_tlpMainPanel.Controls.Add(this.m_tabOptions, 0, 0);
			this.m_tlpMainPanel.Controls.Add(this.m_btnOK, 1, 1);
			this.m_tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpMainPanel.Location = new System.Drawing.Point(7, 7);
			this.m_tlpMainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.m_tlpMainPanel.Name = "m_tlpMainPanel";
			this.m_tlpMainPanel.RowCount = 2;
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.Size = new System.Drawing.Size(562, 250);
			this.m_tlpMainPanel.TabIndex = 5;
			this.m_tlpExportOptionsGroup.AutoSize = true;
			this.m_tlpExportOptionsGroup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpExportOptionsGroup.ColumnCount = 1;
			this.m_tlpExportOptionsGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpExportOptionsGroup.Controls.Add(this.m_chkPDFEmbeddableFontsOnly, 0, 0);
			this.m_tlpExportOptionsGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_tlpExportOptionsGroup.Location = new System.Drawing.Point(3, 19);
			this.m_tlpExportOptionsGroup.Name = "m_tlpExportOptionsGroup";
			this.m_tlpExportOptionsGroup.RowCount = 2;
			this.m_tlpExportOptionsGroup.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpExportOptionsGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpExportOptionsGroup.Size = new System.Drawing.Size(536, 29);
			this.m_tlpExportOptionsGroup.TabIndex = 10;
			this.m_grpPDFExport.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.m_grpPDFExport.AutoSize = true;
			this.m_grpPDFExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_grpPDFExport.Controls.Add(this.m_tlpExportOptionsGroup);
			this.m_grpPDFExport.Location = new System.Drawing.Point(3, 3);
			this.m_grpPDFExport.Name = "m_grpPDFExport";
			this.m_grpPDFExport.Size = new System.Drawing.Size(542, 51);
			this.m_grpPDFExport.TabIndex = 8;
			this.m_grpPDFExport.TabStop = false;
			this.m_grpPDFExport.Text = "PDF/A Export Options";
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.CancelButton = this.m_btnCancel;
			base.ClientSize = new System.Drawing.Size(576, 264);
			base.Controls.Add(this.m_tlpMainPanel);
			this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "OptionsDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options";
			base.Load += new System.EventHandler(OptionsDialog_Load);
			this.m_tabOptions.ResumeLayout(false);
			this.m_tabPageHTML.ResumeLayout(false);
			this.m_tabPageHTML.PerformLayout();
			this.m_tlpHTML.ResumeLayout(false);
			this.m_tlpHTML.PerformLayout();
			this.m_grpCSS.ResumeLayout(false);
			this.m_grpCSS.PerformLayout();
			this.m_tlpHTML_StylesheetGroup.ResumeLayout(false);
			this.m_tlpHTML_StylesheetGroup.PerformLayout();
			this.m_tabPagePDFSecurity.ResumeLayout(false);
			this.m_tabPagePDFSecurity.PerformLayout();
			this.m_tlpPDFSecurity.ResumeLayout(false);
			this.m_tlpPDFSecurity.PerformLayout();
			this.m_grpPDFDigSig.ResumeLayout(false);
			this.m_grpPDFDigSig.PerformLayout();
			this.m_tlpDigitalSignatureGroup.ResumeLayout(false);
			this.m_tlpDigitalSignatureGroup.PerformLayout();
			this.m_grpPDFDocPwd.ResumeLayout(false);
			this.m_grpPDFDocPwd.PerformLayout();
			this.m_tlpDocumentPasswordGroup.ResumeLayout(false);
			this.m_tlpDocumentPasswordGroup.PerformLayout();
			this.m_tabPagePDFImport.ResumeLayout(false);
			this.m_tabPagePDFImport.PerformLayout();
			this.m_tlpPDFImport.ResumeLayout(false);
			this.m_tlpPDFImport.PerformLayout();
			this.m_grpPDFImport.ResumeLayout(false);
			this.m_grpPDFImport.PerformLayout();
			this.m_tlpPDFImportOptions.ResumeLayout(false);
			this.m_tlpPDFImportOptions.PerformLayout();
			this.m_tabPagePDFExport.ResumeLayout(false);
			this.m_tabPagePDFExport.PerformLayout();
			this.m_tlpPDFExport.ResumeLayout(false);
			this.m_tlpPDFExport.PerformLayout();
			this.m_tlpMainPanel.ResumeLayout(false);
			this.m_tlpMainPanel.PerformLayout();
			this.m_tlpExportOptionsGroup.ResumeLayout(false);
			this.m_tlpExportOptionsGroup.PerformLayout();
			this.m_grpPDFExport.ResumeLayout(false);
			this.m_grpPDFExport.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
