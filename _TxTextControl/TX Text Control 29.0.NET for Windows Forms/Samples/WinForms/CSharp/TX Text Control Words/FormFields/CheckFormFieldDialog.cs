/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Linq;
using System.Windows.Forms;
using TXTextControl;

namespace TX_Text_Control_Words.FormFields {

	/*----------------------------------------------------------------------------------------------------------
	** class CheckFormDialog
	**		A dialog for editing the CheckFormField's properties.
	**--------------------------------------------------------------------------------------------------------*/
	public partial class CheckFormFieldDialog : Form {

		/*-------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------*/
		CheckFormField m_field;

		/*-------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**-----------------------------------------------------------------------------------------------------*/
		public CheckFormFieldDialog(CheckFormField field) {
			InitializeComponent();

			m_field = field;

			// Add default characters
			cbCheckSymbol.Items.AddRange(new Object[] { '\x2612', '\x2611', '\x25C9', '\x25A3', '\x2714', '\x2713', '\x26AB', '\x25C6', '\x2795' });
			cbUncheckSymbol.Items.AddRange(new Object[] { '\x2610', '\x2B1C', '\x25CB', '\x2716', '\x2717', '\x26AA', '\x25C7', '\x2796', '\x2795' });
			
			// Add characters if the character is a custom character.
			if (!cbCheckSymbol.Items.Contains(field.CheckedCharacter)) cbCheckSymbol.Items.Add(field.CheckedCharacter);
			if (!cbUncheckSymbol.Items.Contains(field.UncheckedCharacter)) cbUncheckSymbol.Items.Add(field.UncheckedCharacter);

			// Select item of field.
			cbCheckSymbol.SelectedItem = field.CheckedCharacter;
			cbUncheckSymbol.SelectedItem = field.UncheckedCharacter;
		}

		/*-------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R S
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** btnOK_Click
		**		Applies the settings from dialog's fields to the CheckFormField.
		**-----------------------------------------------------------------------------------------------------*/
		private void btnOK_Click(object sender, EventArgs e) {
			m_field.UncheckedCharacter = cbUncheckSymbol.Text.First();
			m_field.CheckedCharacter = cbCheckSymbol.Text.First();
		}

		/*-------------------------------------------------------------------------------------------------------
		** checkbox_TextChanged
		**		Enables/Disables the OK-Button when the to applied data is valid/invalid. 
		**-----------------------------------------------------------------------------------------------------*/
		private void checkbox_TextChanged(object sender, EventArgs e) {
			btnOK.Enabled = IsDataValid();
		}

		/*-------------------------------------------------------------------------------------------------------
		** IsDataValid
		**		Checks whether the data in the input elements are valid. 
		**		The data is valid if one character is set for the check state 
		**		and one for the uncheck state.
		** Returns
		**		'True' if data is valid else 'False'.
		**-----------------------------------------------------------------------------------------------------*/
		private bool IsDataValid() {
			return cbCheckSymbol.Text.Length == 1 && cbUncheckSymbol.Text.Length == 1;
		}
	}
}
