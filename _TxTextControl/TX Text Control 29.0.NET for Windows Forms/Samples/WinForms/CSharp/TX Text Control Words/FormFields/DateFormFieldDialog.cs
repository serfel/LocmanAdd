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
	** class DateFormFieldDialog
	**		A dialog for editing the DateFormField's properties.
	**--------------------------------------------------------------------------------------------------------*/
	public partial class DateFormFieldDialog : Form {

		readonly string PLACEHOLDER_DEFAULT = Properties.Resources.DATEFORMFIELD_DLG_PLACEHOLDER_DEFAULT;

		/*-------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------*/
		string[] m_supportedDateFormats;
		DateFormField m_dateFormField;

		/*-------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**-----------------------------------------------------------------------------------------------------*/
		public DateFormFieldDialog(DateFormField dateFormField) {
			InitializeComponent();

			m_dateFormField = dateFormField;
			m_supportedDateFormats = m_dateFormField.SupportedDateFormats;

			// Fill listbox with available DateFormats
			m_listBoxDateFormat.Items.Add(PLACEHOLDER_DEFAULT);
			m_listBoxDateFormat.Items.AddRange(m_supportedDateFormats);

			// Select item
			try {
				m_listBoxDateFormat.SelectedItem = String.IsNullOrEmpty(m_dateFormField.DateFormat) ? PLACEHOLDER_DEFAULT : m_dateFormField.DateFormat;
			}
			catch { }

			// Show Empty Width
			m_emptyWidthControl.Value = dateFormField.EmptyWidth;
		}

		/*-------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R S
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** m_listBoxDateFormat_SelectedValueChanged
		**		Show the format of the selected item in the textbox.
		**-----------------------------------------------------------------------------------------------------*/
		private void m_listBoxDateFormat_SelectedValueChanged(object sender, EventArgs e) {
			var selectedIndex = m_listBoxDateFormat.SelectedIndex;
			if (selectedIndex >= 0) {
				m_tbCurrentDateFormat.Text = GetTextBoxText((string)m_listBoxDateFormat.SelectedItem);
			}
		}

		/*-------------------------------------------------------------------------------------------------------
		** m_btnOK_Click
		**		Apply the settings to the DateFormField.
		**-----------------------------------------------------------------------------------------------------*/
		private void m_btnOK_Click(object sender, EventArgs e) {
			// Set DateFormat to the default value when no item is selected or the default item is selected.
			// The DateFormat can be set to the default value by using an empty string.
			var selectedItem = (string)m_listBoxDateFormat.SelectedItem;
			m_dateFormField.DateFormat = (selectedItem != null && selectedItem != PLACEHOLDER_DEFAULT) ?
				selectedItem : String.Empty;

			m_dateFormField.EmptyWidth = m_emptyWidthControl.Value;
		}

		/*-------------------------------------------------------------------------------------------------------
		** HELPERS
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** GetTextBoxText
		**		Returns a text for showing in the textbox.
		**-----------------------------------------------------------------------------------------------------*/
		private string GetTextBoxText(string dateFormat) {
			var date = m_dateFormField.Date;
			if (String.IsNullOrEmpty(dateFormat) || dateFormat == PLACEHOLDER_DEFAULT) {
				return PLACEHOLDER_DEFAULT;
			}
			else if(date == null) {
				return DateTime.Now.ToString(dateFormat);
			}
			else {
				return ((DateTime)date).ToString(dateFormat);
			}
		}
	}
}
