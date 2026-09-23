/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using TXTextControl;

namespace TX_Text_Control_Words.FormFields {

	/*----------------------------------------------------------------------------------------------------------
	** class TextFormFieldDialog
	**		A dialog for editing the TextFormField's properties.
	**--------------------------------------------------------------------------------------------------------*/
	public partial class TextFormFieldDialog : Form {

		/*-------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------*/
		TextFormField m_field;

		/*-------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**-----------------------------------------------------------------------------------------------------*/
		public TextFormFieldDialog(TextFormField field) {
			InitializeComponent();

			m_field = field;

			// Fill dialog
			emptyWidthControl.Value = field.EmptyWidth;
		}

		/*-------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R S
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** btnOK_Click
		**		Applies the new fieldsettings.
		**-----------------------------------------------------------------------------------------------------*/

		private void btnOK_Click(object sender, EventArgs e) {
			m_field.EmptyWidth = emptyWidthControl.Value;
		}
	}


}
