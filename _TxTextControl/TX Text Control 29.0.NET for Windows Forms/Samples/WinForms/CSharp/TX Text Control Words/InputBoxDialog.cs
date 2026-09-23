/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** Class InputBoxDialog
	** Implements a dialog with a inputbox for typing in text and a button for getting font settings by showing
	** the FontDialog. The font button is invisible by default.
	**-----------------------------------------------------------------------------------------------------------*/
	public class InputBoxDialog : Form {

		/*-------------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------------*/

		private bool _bAllowEmptyString = false;

		/*-------------------------------------------------------------------------------------------------------------
		** P R O P E R T I E S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** HasFontButton
		**-----------------------------------------------------------------------------------------------------------*/
		public bool HasFontButton {
			get { return m_btnFont.Visible; }
			set { m_btnFont.Visible = value; }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** SelectedFont
		**-----------------------------------------------------------------------------------------------------------*/
		public Font SelectedFont { get; set; }

		/*-------------------------------------------------------------------------------------------------------------
		** TextInput
		**-----------------------------------------------------------------------------------------------------------*/
		public string TextInput { get { return m_txtInput.Text; } }

		/*-------------------------------------------------------------------------------------------------------------
		** AllowEmptyString
		**-----------------------------------------------------------------------------------------------------------*/
		public bool AllowEmptyString {
			get { return _bAllowEmptyString; }

			set {
				_bAllowEmptyString = value;
				if (_bAllowEmptyString) m_btnOK.Enabled = true;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**-----------------------------------------------------------------------------------------------------------*/

		public InputBoxDialog(string strCaption, string strText) {
			InitializeComponent();

			AllowEmptyString = false;
			SelectedFont = new System.Drawing.Font("Calibri", 12);  // Set an arbitrary font
			Text = strCaption;
			m_txtInput.Text = strText;
		}


		/*-------------------------------------------------------------------------------------------------------------
		** D E S I G N E R    C O D E
		**-----------------------------------------------------------------------------------------------------------*/

		private TextBox m_txtInput;
		private Button m_btnCancel;
		private Button m_btnOK;
		private Button m_btnFont;
		private TableLayoutPanel tableLayoutPanel1;
		private Container _components = null;

		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (_components != null) {
					_components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputBoxDialog));
			this.m_txtInput = new System.Windows.Forms.TextBox();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnFont = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_txtInput
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.m_txtInput, 4);
			resources.ApplyResources(this.m_txtInput, "m_txtInput");
			this.m_txtInput.Name = "m_txtInput";
			this.m_txtInput.TextChanged += new System.EventHandler(this.TxtInput_TextChanged);
			// 
			// m_btnCancel
			// 
			resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// m_btnOK
			// 
			resources.ApplyResources(this.m_btnOK, "m_btnOK");
			this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Click += new System.EventHandler(this.BtnOK_Click);
			// 
			// m_btnFont
			// 
			resources.ApplyResources(this.m_btnFont, "m_btnFont");
			this.m_btnFont.Name = "m_btnFont";
			this.m_btnFont.Click += new System.EventHandler(this.BtnFont_Click);
			// 
			// tableLayoutPanel1
			// 
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.m_btnFont, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.m_txtInput, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_btnCancel, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.m_btnOK, 2, 2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			// 
			// InputBoxDialog
			// 
			this.AcceptButton = this.m_btnOK;
			resources.ApplyResources(this, "$this");
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.CancelButton = this.m_btnCancel;
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InputBoxDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		/*-------------------------------------------------------------------------------------------------------------
		** P U B L I C    M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** ShowInputBox method
		** Shows the Input Box Dialog with the passed caption and owner. Use the strInput parameter for storing the
		** inputbox's data.
		**-----------------------------------------------------------------------------------------------------------*/
		public static bool ShowInputBox(string strCaption, ref string strInput, Form owner) {
			return ShowInputBox(strCaption, ref strInput, owner, false);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** ShowInputBox method
		** Shows the Input Box Dialog with the passed caption and owner. Use the strInput parameter for storing the
		** inputbox's data.
		** Returns whether the dialog is closed by accepting the value.
		**-----------------------------------------------------------------------------------------------------------*/
		public static bool ShowInputBox(string strCaption, ref string strInput, Form owner, bool allowEmptyString) {
			DialogResult result;

			var box = new InputBoxDialog(strCaption, strInput);
			box.RightToLeft = owner.RightToLeft;
			box.AllowEmptyString = allowEmptyString;
			result = box.ShowDialog(owner);

			if (result == DialogResult.OK) strInput = box.m_txtInput.Text;

			return (result == DialogResult.OK);
		}


		/*-------------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** BtnOK_Click method
		** Close dialog and return DialogResult.OK.
		**-----------------------------------------------------------------------------------------------------------*/
		private void BtnOK_Click(object sender, System.EventArgs e) {
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			Close();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnCancel_Click method
		** Close dialog and return DialogResult.Cancel.
		**-----------------------------------------------------------------------------------------------------------*/
		private void BtnCancel_Click(object sender, System.EventArgs e) {
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			Close();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** TxtInput_TextChanged method
		** Refresh OK Button's enabling on text changed.
		**-----------------------------------------------------------------------------------------------------------*/
		private void TxtInput_TextChanged(object sender, System.EventArgs e) {
			if (_bAllowEmptyString) return;
			m_btnOK.Enabled = (m_txtInput.Text.Length > 0);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnFont_Click method
		** Show dialog for selecting the font and apply this to InputBoxDialog's SelectedFont Property.
		**-----------------------------------------------------------------------------------------------------------*/
		private void BtnFont_Click(object sender, System.EventArgs e) {
			var fntDlg = new FontDialog { Font = this.SelectedFont };
			if (fntDlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
				this.SelectedFont = fntDlg.Font;
			}
		}
	}
}
