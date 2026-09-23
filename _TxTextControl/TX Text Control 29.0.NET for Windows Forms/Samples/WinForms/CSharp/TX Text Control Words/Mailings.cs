/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using TX_Text_Control_Words.Properties;
using TXTextControl;
using TXTextControl.DocumentServer.Fields;

namespace TX_Text_Control_Words
{

	/*-------------------------------------------------------------------------------------------------------------
	** partial class MainWindow
	** Capsulates all functionalities related to Mailmerging and Reporting.
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class MainWindow : Form {

		/*-------------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------------*/

		private FieldDisplayMode m_fldDispModeCur;
		private HighlightMode m_bHighlightFields = HighlightMode.Activated; // Specifies the current highlighting for fields.

		/*-------------------------------------------------------------------------------------------------------------
		** E N U M S
		**-----------------------------------------------------------------------------------------------------------*/

		private enum FieldDisplayMode {
			ShowFieldText,
			ShowFieldCodes,
		}


		/*-------------------------------------------------------------------------------------------------------------
		** M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** SetDefaultFieldAndBlockProperties method
		** Sets the application fields to default TX TextControl Words default values. 
		** The Default setting is
		** - Editable: Field is not editable.
		** - DoubledInputPosition: Field has doubled input position.
		** - HighlightMode: Show activated if hightlighting for fields is activated.
		** Sets also the Text Property to "{IF}" if field is IFField and not set.
		**-----------------------------------------------------------------------------------------------------------*/
		private void SetDefaultFieldAndBlockProperties() {
			try {
				foreach (TXTextControl.IFormattedText part in textControl.TextParts) {
					foreach (TXTextControl.ApplicationField fld in part.ApplicationFields) {
						if ((fld.TypeName == IfField.TYPE_NAME) && (fld.Length == 0)) {
							// Show invisible IF fields
							fld.Text = "{IF}";
						}
						fld.Editable = false;
						fld.DoubledInputPosition = true;
						fld.HighlightMode = m_bHighlightFields;
					}
				}
			}
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** InsertMergeField method
		** Create a new MergeField with the default setting and add to TextControl. 
		**-----------------------------------------------------------------------------------------------------------*/
		private MergeField InsertMergeField(string strName) {
			MergeField mf = CreateMergeField(strName);
			textControl.ApplicationFields.Add(mf.ApplicationField);
			return mf;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** CreateMergeField method
		** Returns a new MergeField with the default setting 
		** (see SetDefaultFieldAndBlockProperties method's description).
		**-----------------------------------------------------------------------------------------------------------*/
		private MergeField CreateMergeField(string strName) {
			var mf = new MergeField();

			mf.ApplicationField.DoubledInputPosition = true;
			mf.ApplicationField.Editable = false;
			mf.ApplicationField.HighlightMode = m_bHighlightFields;

			if (strName != string.Empty) {
				mf.Name = strName;

				switch (m_fldDispModeCur) {
					case FieldDisplayMode.ShowFieldCodes:
						string strSwitches
							= (mf.ApplicationField.Parameters != null) ? string.Join(" ", mf.ApplicationField.Parameters) : "";
						mf.Text = "{" + mf.TypeName + strSwitches + " }";
						break;

					case FieldDisplayMode.ShowFieldText:
						mf.Text = "«" + strName + "»";
						break;
				}
			}

			return mf;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** InsertMergeField method
		** Creates a new MergeField with the default setting 
		** (see SetDefaultFieldAndBlockProperties method's description) and TX TextControl's MergeField Dialog
		** providing the user the possiblity to edit certain settings of the MergeField. Inserts the edited 
		** MergeField in the TextControl.
		**-----------------------------------------------------------------------------------------------------------*/
		private void InsertMergeField() {
			bool bRTL = this.RightToLeft == System.Windows.Forms.RightToLeft.Yes;

			var newMergeField = CreateMergeField("");
			if (newMergeField.ShowDialog(this, bRTL) == TXTextControl.DocumentServer.Fields.DialogResult.OK) {
				newMergeField.Text = "«" + newMergeField.Name + "»";
				textControl.ApplicationFields.Add(newMergeField.ApplicationField);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** InsertIfField method
		** Creates a new IfField with the default setting 
		** (see SetDefaultFieldAndBlockProperties method's description) and TX TextControl's IfField Dialog
		** providing the user the possiblity to edit certain settings of the IfField. Inserts the edited 
		** IfField in the TextControl.
		**-----------------------------------------------------------------------------------------------------------*/
		private void InsertIfField() {
			bool bRTL = this.RightToLeft == System.Windows.Forms.RightToLeft.Yes;

			var newIfField = new IfField();
			newIfField.ApplicationField.DoubledInputPosition = true;
			newIfField.ApplicationField.Editable = false;
			newIfField.ApplicationField.HighlightMode = m_bHighlightFields;

			if (newIfField.ShowDialog(this, bRTL) == TXTextControl.DocumentServer.Fields.DialogResult.OK) {
				textControl.ApplicationFields.Add(newIfField.ApplicationField);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** InsertNextField method
		** Creates a new InsertNextFieldv with the default setting 
		** (see SetDefaultFieldAndBlockProperties method's description) and add to TextControl.
		**-----------------------------------------------------------------------------------------------------------*/
		private void InsertNextField() {
			var newField = new NextField();
			newField.ApplicationField.DoubledInputPosition = true;
			newField.ApplicationField.Editable = false;
			newField.ApplicationField.HighlightMode = m_bHighlightFields;

			textControl.ApplicationFields.Add(newField.ApplicationField);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** InsertNextIfField method
		** Creates a new NextIfField with the default setting 
		** (see SetDefaultFieldAndBlockProperties method's description) and and TX TextControl's NextIfField Dialog
		** providing the user the possiblity to edit certain settings of the NextIfField. Inserts the edited 
		** NextIfField in the TextControl.
		**-----------------------------------------------------------------------------------------------------------*/
		private void InsertNextIfField() {
			bool bRTL = this.RightToLeft == System.Windows.Forms.RightToLeft.Yes;

			var newField = new NextIfField();
			newField.ApplicationField.DoubledInputPosition = true;
			newField.ApplicationField.Editable = false;
			newField.ApplicationField.HighlightMode = m_bHighlightFields;

			if (newField.ShowDialog(this, bRTL) == TXTextControl.DocumentServer.Fields.DialogResult.OK) {
				textControl.ApplicationFields.Add(newField.ApplicationField);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** InsertDateField method
		** Creates a new DateField with the default setting 
		** (see SetDefaultFieldAndBlockProperties method's description) and and TX TextControl's DateField Dialog
		** providing the user the possiblity to edit certain settings of the DateField. Inserts the edited 
		** DateField in the TextControl.
		**-----------------------------------------------------------------------------------------------------------*/
		private void InsertDateField() {
			bool bRTL = this.RightToLeft == System.Windows.Forms.RightToLeft.Yes;

			var newDateField = new DateField() { Format = "dd.MM.yyyy" };
			newDateField.ApplicationField.DoubledInputPosition = true;
			newDateField.ApplicationField.Editable = false;
			newDateField.ApplicationField.HighlightMode = m_bHighlightFields;

			if (newDateField.ShowDialog(this, bRTL) == TXTextControl.DocumentServer.Fields.DialogResult.OK) {
				textControl.ApplicationFields.Add(newDateField.ApplicationField);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** InsertIncludeTextField method
		** Creates a new IncludeText with the default setting 
		** (see SetDefaultFieldAndBlockProperties method's description) and and TX TextControl's IncludeText Dialog
		** providing the user the possiblity to edit certain settings of the IncludeText. Inserts the edited 
		** IncludeText in the TextControl.
		**-----------------------------------------------------------------------------------------------------------*/
		private void InsertIncludeTextField() {
			bool bRTL = this.RightToLeft == System.Windows.Forms.RightToLeft.Yes;

			var newIncludeTextField = new IncludeText();
			newIncludeTextField.ApplicationField.DoubledInputPosition = true;
			newIncludeTextField.ApplicationField.Editable = false;
			newIncludeTextField.ApplicationField.HighlightMode = m_bHighlightFields;

			if (newIncludeTextField.ShowDialog(this, bRTL) == TXTextControl.DocumentServer.Fields.DialogResult.OK) {
				textControl.ApplicationFields.Add(newIncludeTextField.ApplicationField);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** DeleteField method
		** Remove the ApplicationField at the current input position of the TextControl.
		**-----------------------------------------------------------------------------------------------------------*/
		private void DeleteField() {
			try {
				var field = textControl.ApplicationFields.GetItem();
				if (field == null) return;
				textControl.ApplicationFields.Remove(field);
			}
			catch (Exception exc) {
				Utils.MessageBox.Show( this,
					exc.Message, ProductName,
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** DeleteField method
		** Checks for a ApplicationField at the current input position.
		**-----------------------------------------------------------------------------------------------------------*/
		private bool FieldAtCurrentPos() {
			try {
				var field = textControl.ApplicationFields.GetItem();
				return field != null;
			}
			catch { return false; }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** FieldSettings method
		** Shows the dialog of a specific ApplicationField (MergeField, DateField, IncludeText, IfField, NextIfField).
		**-----------------------------------------------------------------------------------------------------------*/
		private void FieldSettings() {
			bool bRTL = this.RightToLeft == System.Windows.Forms.RightToLeft.Yes;
			try {
				var field = textControl.ApplicationFields.GetItem();
				if (field == null) {
					Utils.MessageBox.Show(this,
						Resources.MSG_FIELDNOTAVAILABLE, ProductName,
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				switch (field.TypeName) {
					case MergeField.TYPE_NAME:
						var mergeField = new MergeField(field);
						mergeField.ShowDialog(this, bRTL);
						break;

					case DateField.TYPE_NAME:
						var dateField = new DateField(field);
						dateField.ShowDialog(this, bRTL);
						break;

					case IncludeText.TYPE_NAME:
						var includeTextField = new IncludeText(field);
						includeTextField.ShowDialog(this, bRTL);
						break;

					case IfField.TYPE_NAME:
						var ifField = new IfField(field);
						ifField.ShowDialog(this, bRTL);
						break;

					case NextIfField.TYPE_NAME:
						var nextIf = new NextIfField(field);
						nextIf.ShowDialog(this, bRTL);
						break;
				}
			}
			catch { }
		}

		/*-------------------------------------------------------------------------------------------------------------
		** UpdateFieldValues method
		** Updates all ApplicationField's Text Property depending on the FieldDisplayMode 
		** (see UpdateFieldValues overloaded method).
		** - ShowFieldText: Sets the text to { TypeName, [Parameter ] } with ApplicationField's Type 
		**						  and ApplicationField's Parameters.
		** - ShowFieldCodes: Creates a new specific MailMerge Field based on ApplicationField and sets the 
		**							field's typename in breakets as text.
		**-----------------------------------------------------------------------------------------------------------*/
		private void UpdateFieldValues() {
			if (textControl == null) return;

			foreach (TXTextControl.IFormattedText textPart in textControl.TextParts) {
				foreach (TXTextControl.ApplicationField appField in textPart.ApplicationFields) {
					UpdateFieldValues(appField);
				}
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** UpdateFieldValues method
		** Updates all ApplicationField's Text Property depending on the FieldDisplayMode:
		** - ShowFieldText: Sets the text to { TypeName, [Parameter ] } with ApplicationField's Type 
		**						  and ApplicationField's Parameters.
		** - ShowFieldCodes: Creates a new specific MailMerge Field based on ApplicationField and sets the 
		**							field's typename in breakets as text.
		**-----------------------------------------------------------------------------------------------------------*/
		private void UpdateFieldValues(TXTextControl.ApplicationField appField) {
			try {
				switch (m_fldDispModeCur) {
					case FieldDisplayMode.ShowFieldCodes:
						ShowFieldCodes(appField);
						break;

					case FieldDisplayMode.ShowFieldText:
						ShowFieldText(appField);
						break;
				}
			}
			catch { }
		}


		/*-------------------------------------------------------------------------------------------------------------
		** ShowFieldCodes method
		** Creates a new specific MailMerge Field based on ApplicationField and sets the 
		**	field's typename in breakets as text.
		**-----------------------------------------------------------------------------------------------------------*/
		private static void ShowFieldCodes(TXTextControl.ApplicationField appField) {
			string fieldSwitches
				= (appField.Parameters != null) ? string.Join(" ", appField.Parameters) : "";
			appField.Text = "{ " + appField.TypeName + " " + fieldSwitches + " }";
		}


		/*-------------------------------------------------------------------------------------------------------------
		** ShowFieldText method
		** ApplicationField's text to { TypeName, [Parameter ] } with ApplicationField's Type 
		**	and ApplicationField's Parameters.
		**-----------------------------------------------------------------------------------------------------------*/
		private static void ShowFieldText(TXTextControl.ApplicationField appField) {
			switch (appField.TypeName) {
				case MergeField.TYPE_NAME:
					var mergeField = new MergeField(appField);
					mergeField.Text = "«" + mergeField.Name + "»";
					break;

				case IfField.TYPE_NAME:
					var ifField = new IfField(appField);
					ifField.Text = "{" + ifField.TypeName + "}";
					break;

				case DateField.TYPE_NAME:
					var dateField = new DateField(appField);
					dateField.Text = "{" + dateField.TypeName + "}";
					break;

				case IncludeText.TYPE_NAME:
					var includeText = new IncludeText(appField);
					includeText.ApplicationField.Text = "{" + includeText.TypeName + "}";
					break;

				case NextField.TYPE_NAME:
					var next = new NextField(appField);
					next.ApplicationField.Text = "{" + next.TypeName + "}";
					break;

				case NextIfField.TYPE_NAME:
					var nextIf = new NextIfField(appField);
					nextIf.ApplicationField.Text = "{" + nextIf.TypeName + "}";
					break;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** DocumentContainsFields method
		** Checks if the TextControl contains any ApplicationField.
		**-----------------------------------------------------------------------------------------------------------*/
		private bool DocumentContainsFields() {
			foreach (TXTextControl.IFormattedText textPart in textControl.TextParts) {
				if ((textPart.ApplicationFields != null) && (textPart.ApplicationFields.Count > 0)) return true;
			}

			return false;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** DocumentContainsNamedObjects method
		** Checks if the TextControl contains any image, chart or barcode with a name.
		**-----------------------------------------------------------------------------------------------------------*/
		private bool DocumentContainsNamedObjects() {
			foreach (TXTextControl.IFormattedText textPart in textControl.TextParts) {
				foreach (TXTextControl.Image img in textPart.Images) {
					if (!string.IsNullOrEmpty(img.Name)) return true;
				}
			}

			foreach (TXTextControl.DataVisualization.ChartFrame chart in textControl.Charts) {
				if (!string.IsNullOrEmpty(chart.Name)) return true;
			}

			foreach (TXTextControl.DataVisualization.BarcodeFrame barcode in textControl.Barcodes) {
				if (!string.IsNullOrEmpty(barcode.Name)) return true;
			}

			return false;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** StreamTypeToFileExt method
		** Returns the default file extension for a streamtype.
		**-----------------------------------------------------------------------------------------------------------*/
		private string StreamTypeToFileExt(TXTextControl.StreamType streamType) {
			switch (streamType) {
				case TXTextControl.StreamType.AdobePDF:
				case TXTextControl.StreamType.AdobePDFA:
					return "pdf";

				case TXTextControl.StreamType.CascadingStylesheet:
					return "css";

				case TXTextControl.StreamType.HTMLFormat:
					return "html";

				case TXTextControl.StreamType.InternalFormat:
				case TXTextControl.StreamType.InternalUnicodeFormat:
					return "tx";

				case TXTextControl.StreamType.MSWord:
					return "doc";

				case TXTextControl.StreamType.PlainAnsiText:
				case TXTextControl.StreamType.PlainText:
					return "txt";

				case TXTextControl.StreamType.RichTextFormat:
					return "rtf";

				case TXTextControl.StreamType.WordprocessingML:
					return "docx";

				case TXTextControl.StreamType.XMLFormat:
					return "xml";
			}

			return string.Empty;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** FileExtToStreamType method
		** Returns the default streamtype for a file extension.
		**-----------------------------------------------------------------------------------------------------------*/
		private static TXTextControl.StreamType FileExtToStreamType(string fileExt) {
			TXTextControl.StreamType streamType = TXTextControl.StreamType.RichTextFormat;

			switch (fileExt.ToLower()) {
				case "pdf":
					streamType = TXTextControl.StreamType.AdobePDF;
					break;

				case "rtf":
					streamType = TXTextControl.StreamType.RichTextFormat;
					break;

				case "docx":
					streamType = TXTextControl.StreamType.WordprocessingML;
					break;

				case "doc":
					streamType = TXTextControl.StreamType.MSWord;
					break;

				case "html":
					streamType = TXTextControl.StreamType.HTMLFormat;
					break;

				case "txt":
					streamType = TXTextControl.StreamType.PlainText;
					break;

				case "tx":
					streamType = TXTextControl.StreamType.InternalUnicodeFormat;
					break;

				case "xml":
					streamType = TXTextControl.StreamType.XMLFormat;
					break;
			}
			return streamType;
		}
	}
}
