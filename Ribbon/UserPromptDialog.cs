/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** class UserPromptDialog
	** Implements a dialog to input a text or password.
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class UserPromptDialog : Form {

		/*-------------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**-----------------------------------------------------------------------------------------------------------*/
		public UserPromptDialog(string caption, string label, string value) {
			InitializeComponent();
			LocalizeDialog();

			this.Text = caption;
			m_lblInput.Text = label ?? "";
			m_txtInput.Text = value ?? "";
		}

		/*-------------------------------------------------------------------------------------------------------------
		** P R O P E R T I E S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** Value
		** Value of the input box.
		**-----------------------------------------------------------------------------------------------------------*/
		public string Value {
			get { return m_txtInput.Text; }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** IsPassword method
		** Un-/set textbox for typing in a password.
		**-----------------------------------------------------------------------------------------------------------*/
		public bool IsPassword {
			get { return m_txtInput.PasswordChar != '\0' || m_txtInput.UseSystemPasswordChar; }
			set {
				if (value) {
					m_txtInput.PasswordChar = '*';
					m_txtInput.UseSystemPasswordChar = true;
				}
				else {
					m_txtInput.PasswordChar = '\0';
					m_txtInput.UseSystemPasswordChar = false;
				}
			}
		}


		/*-------------------------------------------------------------------------------------------------------------
		** H E L P E R    M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** LocalizeDialog method
		** Localize dialog's texts.
		**-----------------------------------------------------------------------------------------------------------*/
		private void LocalizeDialog() {
			m_btnOK.Text = Лоцман_добавка.Properties.Resources.BTN_OK;
			m_btnCancel.Text = Лоцман_добавка.Properties.Resources.BTN_CANCEL;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnOK_Click method
		** Accept the input.
		**-----------------------------------------------------------------------------------------------------------*/
		private void BtnOK_Click(object sender, EventArgs e) {
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}

	}
}
