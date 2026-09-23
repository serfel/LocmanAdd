/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** Class InsertBreakDialog
	** Implements a dialog for inserting pagebreaks, linebreaks or columns at TextControl's inputposition or
	** inserting sectionbreaks at the beginning or end of a page.
	**-----------------------------------------------------------------------------------------------------------*/
	public class InsertBreakDialog : System.Windows.Forms.Form {

		/*-------------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------------*/

		private TXTextControl.TextControl m_tx;
		internal TableLayoutPanel TableLayoutPanel1;
		internal Button m_btnOK;
		internal Button m_btnCancel;
		private GroupBox m_grpSectionBreak;
		internal TableLayoutPanel TableLayoutPanel2;
		private RadioButton m_rbBeginAtNewLine;
		private RadioButton m_rbBeginAtNewPage;
		private GroupBox m_grpBreak;
		internal TableLayoutPanel TableLayoutPanel3;
		private RadioButton m_rbInsertColumn;
		private RadioButton m_rbInsertTextBreak;
		private RadioButton m_rbInsertPageBreak;
		private TXTextControl.SectionBreakKind m_breakKind;

		/*-------------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**-----------------------------------------------------------------------------------------------------------*/

		public InsertBreakDialog(TXTextControl.TextControl textControl) {
			InitializeComponent();

			m_tx = textControl;

			// Enable / disable groups
			m_grpSectionBreak.Enabled = m_tx.CanDocumentFormat;
			m_grpBreak.Enabled = m_tx.CanEdit;

			Localize();
		}

		private void Localize() {
			m_btnCancel.Text = Properties.Resources.INSERTBREAK_DLG_btnCancel_Text;
			m_btnOK.Text = Properties.Resources.BTN_OK;
			m_grpBreak.Text = Properties.Resources.INSERTBREAK_DLG_grpBreak_Text;
			m_rbInsertColumn.Text = Properties.Resources.INSERTBREAK_DLG_rbInsertColumn_Text;
			m_rbInsertPageBreak.Text = Properties.Resources.INSERTBREAK_DLG_rbInsertPageBreak_Text;
			m_rbInsertTextBreak.Text = Properties.Resources.INSERTBREAK_DLG_rbInsertTextBreak_Text;

			m_grpSectionBreak.Text = Properties.Resources.INSERTBREAK_DLG_grpSectionBreak_Text;
			m_rbBeginAtNewLine.Text = Properties.Resources.INSERTBREAK_DLG_rbBeginAtNewLine_Text;
			m_rbBeginAtNewPage.Text = Properties.Resources.INSERTBREAK_DLG_rbBeginAtNewPage_Text;

			this.Text = Properties.Resources.INSERTBREAK_DLG_TITLE;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** D E S I G N E R    C O D E
		**-----------------------------------------------------------------------------------------------------------*/

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}


		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_grpSectionBreak = new System.Windows.Forms.GroupBox();
			this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.m_rbBeginAtNewLine = new System.Windows.Forms.RadioButton();
			this.m_rbBeginAtNewPage = new System.Windows.Forms.RadioButton();
			this.m_grpBreak = new System.Windows.Forms.GroupBox();
			this.TableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.m_rbInsertColumn = new System.Windows.Forms.RadioButton();
			this.m_rbInsertTextBreak = new System.Windows.Forms.RadioButton();
			this.m_rbInsertPageBreak = new System.Windows.Forms.RadioButton();
			this.TableLayoutPanel1.SuspendLayout();
			this.m_grpSectionBreak.SuspendLayout();
			this.TableLayoutPanel2.SuspendLayout();
			this.m_grpBreak.SuspendLayout();
			this.TableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// TableLayoutPanel1
			// 
			this.TableLayoutPanel1.AutoSize = true;
			this.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TableLayoutPanel1.ColumnCount = 3;
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TableLayoutPanel1.Controls.Add(this.m_btnOK, 1, 3);
			this.TableLayoutPanel1.Controls.Add(this.m_btnCancel, 2, 3);
			this.TableLayoutPanel1.Controls.Add(this.m_grpSectionBreak, 0, 1);
			this.TableLayoutPanel1.Controls.Add(this.m_grpBreak, 0, 0);
			this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 4;
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel1.Size = new System.Drawing.Size(345, 204);
			this.TableLayoutPanel1.TabIndex = 9;
			// 
			// m_btnOK
			// 
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btnOK.Location = new System.Drawing.Point(195, 179);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(72, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(72, 25);
			this.m_btnOK.TabIndex = 6;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btnCancel.Location = new System.Drawing.Point(273, 179);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.m_btnCancel.MinimumSize = new System.Drawing.Size(72, 23);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(72, 25);
			this.m_btnCancel.TabIndex = 7;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// m_grpSectionBreak
			// 
			this.m_grpSectionBreak.AutoSize = true;
			this.TableLayoutPanel1.SetColumnSpan(this.m_grpSectionBreak, 3);
			this.m_grpSectionBreak.Controls.Add(this.TableLayoutPanel2);
			this.m_grpSectionBreak.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_grpSectionBreak.Location = new System.Drawing.Point(0, 106);
			this.m_grpSectionBreak.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.m_grpSectionBreak.Name = "m_grpSectionBreak";
			this.m_grpSectionBreak.Size = new System.Drawing.Size(345, 72);
			this.m_grpSectionBreak.TabIndex = 3;
			this.m_grpSectionBreak.TabStop = false;
			this.m_grpSectionBreak.Text = "Section break types";
			// 
			// TableLayoutPanel2
			// 
			this.TableLayoutPanel2.AutoSize = true;
			this.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TableLayoutPanel2.ColumnCount = 1;
			this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TableLayoutPanel2.Controls.Add(this.m_rbBeginAtNewLine, 0, 1);
			this.TableLayoutPanel2.Controls.Add(this.m_rbBeginAtNewPage, 0, 0);
			this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TableLayoutPanel2.Location = new System.Drawing.Point(3, 19);
			this.TableLayoutPanel2.Name = "TableLayoutPanel2";
			this.TableLayoutPanel2.RowCount = 1;
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel2.Size = new System.Drawing.Size(339, 50);
			this.TableLayoutPanel2.TabIndex = 6;
			// 
			// m_rbBeginAtNewLine
			// 
			this.m_rbBeginAtNewLine.AutoCheck = false;
			this.m_rbBeginAtNewLine.AutoSize = true;
			this.m_rbBeginAtNewLine.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbBeginAtNewLine.Location = new System.Drawing.Point(3, 28);
			this.m_rbBeginAtNewLine.Name = "m_rbBeginAtNewLine";
			this.m_rbBeginAtNewLine.Size = new System.Drawing.Size(115, 19);
			this.m_rbBeginAtNewLine.TabIndex = 5;
			this.m_rbBeginAtNewLine.Text = "Begin at &new line";
			this.m_rbBeginAtNewLine.UseVisualStyleBackColor = true;
			this.m_rbBeginAtNewLine.Click += new System.EventHandler(this.BeginAtNewLineRadio_Click);
			// 
			// m_rbBeginAtNewPage
			// 
			this.m_rbBeginAtNewPage.AutoCheck = false;
			this.m_rbBeginAtNewPage.AutoSize = true;
			this.m_rbBeginAtNewPage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbBeginAtNewPage.Location = new System.Drawing.Point(3, 3);
			this.m_rbBeginAtNewPage.Name = "m_rbBeginAtNewPage";
			this.m_rbBeginAtNewPage.Size = new System.Drawing.Size(122, 19);
			this.m_rbBeginAtNewPage.TabIndex = 4;
			this.m_rbBeginAtNewPage.TabStop = true;
			this.m_rbBeginAtNewPage.Text = "Begin &at new page";
			this.m_rbBeginAtNewPage.UseVisualStyleBackColor = true;
			this.m_rbBeginAtNewPage.Click += new System.EventHandler(this.BeginAtNewPageRadio_Click);
			// 
			// m_grpBreak
			// 
			this.m_grpBreak.AutoSize = true;
			this.m_grpBreak.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TableLayoutPanel1.SetColumnSpan(this.m_grpBreak, 3);
			this.m_grpBreak.Controls.Add(this.TableLayoutPanel3);
			this.m_grpBreak.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_grpBreak.Location = new System.Drawing.Point(0, 3);
			this.m_grpBreak.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.m_grpBreak.Name = "m_grpBreak";
			this.m_grpBreak.Size = new System.Drawing.Size(345, 97);
			this.m_grpBreak.TabIndex = 2;
			this.m_grpBreak.TabStop = false;
			this.m_grpBreak.Text = "Break types";
			// 
			// TableLayoutPanel3
			// 
			this.TableLayoutPanel3.AutoSize = true;
			this.TableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TableLayoutPanel3.ColumnCount = 1;
			this.TableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TableLayoutPanel3.Controls.Add(this.m_rbInsertColumn, 0, 1);
			this.TableLayoutPanel3.Controls.Add(this.m_rbInsertTextBreak, 0, 2);
			this.TableLayoutPanel3.Controls.Add(this.m_rbInsertPageBreak, 0, 0);
			this.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
			this.TableLayoutPanel3.Name = "TableLayoutPanel3";
			this.TableLayoutPanel3.RowCount = 2;
			this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TableLayoutPanel3.Size = new System.Drawing.Size(339, 75);
			this.TableLayoutPanel3.TabIndex = 7;
			// 
			// m_rbInsertColumn
			// 
			this.m_rbInsertColumn.AutoCheck = false;
			this.m_rbInsertColumn.AutoSize = true;
			this.m_rbInsertColumn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbInsertColumn.Location = new System.Drawing.Point(3, 28);
			this.m_rbInsertColumn.Name = "m_rbInsertColumn";
			this.m_rbInsertColumn.Size = new System.Drawing.Size(130, 19);
			this.m_rbInsertColumn.TabIndex = 2;
			this.m_rbInsertColumn.Text = "Insert &column break";
			this.m_rbInsertColumn.UseVisualStyleBackColor = true;
			this.m_rbInsertColumn.Click += new System.EventHandler(this.InsertColumnRadio_Click);
			// 
			// m_rbInsertTextBreak
			// 
			this.m_rbInsertTextBreak.AutoCheck = false;
			this.m_rbInsertTextBreak.AutoSize = true;
			this.m_rbInsertTextBreak.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbInsertTextBreak.Location = new System.Drawing.Point(3, 53);
			this.m_rbInsertTextBreak.Name = "m_rbInsertTextBreak";
			this.m_rbInsertTextBreak.Size = new System.Drawing.Size(162, 19);
			this.m_rbInsertTextBreak.TabIndex = 3;
			this.m_rbInsertTextBreak.Text = "Insert text &wrapping break";
			this.m_rbInsertTextBreak.UseVisualStyleBackColor = true;
			this.m_rbInsertTextBreak.Click += new System.EventHandler(this.InsertTextBreakRadio_Click);
			// 
			// m_rbInsertPageBreak
			// 
			this.m_rbInsertPageBreak.AutoCheck = false;
			this.m_rbInsertPageBreak.AutoSize = true;
			this.m_rbInsertPageBreak.Checked = true;
			this.m_rbInsertPageBreak.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_rbInsertPageBreak.Location = new System.Drawing.Point(3, 3);
			this.m_rbInsertPageBreak.Name = "m_rbInsertPageBreak";
			this.m_rbInsertPageBreak.Size = new System.Drawing.Size(115, 19);
			this.m_rbInsertPageBreak.TabIndex = 1;
			this.m_rbInsertPageBreak.TabStop = true;
			this.m_rbInsertPageBreak.Text = "Insert page &break";
			this.m_rbInsertPageBreak.UseVisualStyleBackColor = true;
			this.m_rbInsertPageBreak.Click += new System.EventHandler(this.InsertPageRadio_Click);
			// 
			// InsertBreakDialog
			// 
			this.AcceptButton = this.m_btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.CancelButton = this.m_btnCancel;
			this.ClientSize = new System.Drawing.Size(359, 218);
			this.Controls.Add(this.TableLayoutPanel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InsertBreakDialog";
			this.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Insert Break";
			this.TopMost = true;
			this.TableLayoutPanel1.ResumeLayout(false);
			this.TableLayoutPanel1.PerformLayout();
			this.m_grpSectionBreak.ResumeLayout(false);
			this.m_grpSectionBreak.PerformLayout();
			this.TableLayoutPanel2.ResumeLayout(false);
			this.TableLayoutPanel2.PerformLayout();
			this.m_grpBreak.ResumeLayout(false);
			this.m_grpBreak.PerformLayout();
			this.TableLayoutPanel3.ResumeLayout(false);
			this.TableLayoutPanel3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		/*-------------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** cmdOK_Click method
		** Inserts the break in the TextControl and scrolls to the position. Close dialog and return DialogResult.OK.
		**-----------------------------------------------------------------------------------------------------------*/
		private void cmdOK_Click(object sender, System.EventArgs e) {
			int dpi = (int)(1440 / m_tx.CreateGraphics().DpiX);

			if (m_rbInsertPageBreak.Checked) {
				m_tx.Selection.Text = "\f";
			}
			else if (m_rbInsertColumn.Checked) {
				m_tx.Selection.Text = "\x0E";
			}
			else if (m_rbInsertTextBreak.Checked) {
				m_tx.Selection.Text = "\v";
			}
			else {
				try {
					m_tx.Sections.Add(m_breakKind);
				}
				catch (Exception ex) {
					Utils.MessageBox.Show(this, ex.Message, ProductName);
					return;
				}
			}

			m_tx.ScrollLocation = new Point(m_tx.ScrollLocation.X, (int)(m_tx.InputPosition.Location.Y - (m_tx.Selection.SectionFormat.PageMargins.Top * dpi)));
			this.DialogResult = DialogResult.OK;
			Close();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** cmdCancel_Click method
		** Close dialog.
		**-----------------------------------------------------------------------------------------------------------*/
		private void cmdCancel_Click(object sender, System.EventArgs e) {
			Close();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** InsertPageRadio_Click method
		** Update group of radio buttons.
		**-----------------------------------------------------------------------------------------------------------*/
		private void InsertPageRadio_Click(object sender, EventArgs e) {
			m_rbBeginAtNewLine.Checked = false;
			m_rbBeginAtNewPage.Checked = false;
			m_rbInsertColumn.Checked = false;
			m_rbInsertPageBreak.Checked = true;
			m_rbInsertTextBreak.Checked = false;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** InsertColumnRadio_Click method
		** Update group of radio buttons.
		**-----------------------------------------------------------------------------------------------------------*/
		private void InsertColumnRadio_Click(object sender, EventArgs e) {
			m_rbBeginAtNewLine.Checked = false;
			m_rbBeginAtNewPage.Checked = false;
			m_rbInsertColumn.Checked = true;
			m_rbInsertPageBreak.Checked = false;
			m_rbInsertTextBreak.Checked = false;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BeginAtNewPageRadio_Click method
		** Update group of radio buttons and set breakkind to BeginAtNewPage.
		**-----------------------------------------------------------------------------------------------------------*/
		private void BeginAtNewPageRadio_Click(object sender, EventArgs e) {
			m_rbBeginAtNewLine.Checked = false;
			m_rbBeginAtNewPage.Checked = true;
			m_rbInsertColumn.Checked = false;
			m_rbInsertPageBreak.Checked = false;
			m_rbInsertTextBreak.Checked = false;
			m_breakKind = TXTextControl.SectionBreakKind.BeginAtNewPage;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BeginAtNewLineRadio_Click method
		** Update group of radio buttons and set breakkind to BeginAtNewLine.
		**-----------------------------------------------------------------------------------------------------------*/
		private void BeginAtNewLineRadio_Click(object sender, EventArgs e) {
			m_rbBeginAtNewLine.Checked = true;
			m_rbBeginAtNewPage.Checked = false;
			m_rbInsertColumn.Checked = false;
			m_rbInsertPageBreak.Checked = false;
			m_rbInsertTextBreak.Checked = false;
			m_breakKind = TXTextControl.SectionBreakKind.BeginAtNewLine;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** InsertTextBreakRadio_Click method
		** Update group of radio buttons.
		**-----------------------------------------------------------------------------------------------------------*/
		private void InsertTextBreakRadio_Click(object sender, EventArgs e) {
			m_rbBeginAtNewLine.Checked = false;
			m_rbBeginAtNewPage.Checked = false;
			m_rbInsertColumn.Checked = false;
			m_rbInsertPageBreak.Checked = false;
			m_rbInsertTextBreak.Checked = true;
		}
	}
}
