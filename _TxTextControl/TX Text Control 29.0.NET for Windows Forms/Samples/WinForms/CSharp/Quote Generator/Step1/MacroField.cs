/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Quote Generator Sample
** description:	This sample program shows how to use Text Control in office applications.  						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/

namespace QuoteGenerator {

    // This class contains functions to extend Text Control's marked text fields.
    //
    // In order to be able to specify a field identifier from code and later
    // access a field using this identifier, an additional identifier is stored
    // in the FieldName property.
    public class MacroField {
        public enum ID {
            FieldAddress = 1,		// The complete address as printed on top of a letter
            FieldDate = 2,          // The current date
            FieldCustomerID = 3,	// The customer number
            FieldDearXX = 4			// The "Dear Mr Miller" line
        }

      
        // Select a field by its ID
        public TXTextControl.TextField SelectByID(TXTextControl.TextControl tx, ID FieldID) {
            TXTextControl.TextField SelectedField = null;

            foreach (TXTextControl.TextField Field in tx.TextFields) {
                if ((int)FieldID == Field.ID)
                    SelectedField = Field;
            }
            return SelectedField;
        }

        // Create a field. A document can contain one field of each type defined in the ID 
        // enumeration. These fields act as placeholders and will be filled with data from 
        // an address database.
        public void Create(TXTextControl.TextControl tx, ID FieldID) {
            TXTextControl.TextField Field = new TXTextControl.TextField();

            Field.Text = "<-------->";
            Field.DoubledInputPosition = true;
            Field.HighlightMode = TXTextControl.HighlightMode.Activated;
            Field.ID = (int)FieldID;
            tx.TextFields.Add(Field);
        }

        // Process Text Control's FieldClicked event. Show the type of macro field
        // that has been clicked on in the status bar.
        public void DoClick(TXTextControl.TextControl tx, TXTextControl.StatusBar ctlStatusBar, ID FieldID) {
            ctlStatusBar.Text = "";
            ctlStatusBar.Text = GetFieldDescription(FieldID);
        }

        // Return a short description of each of the field types. This is used as a
        // placeholder for empty fields, and is displayed in the status bar when a
        // field has been clicked on.
        private string GetFieldDescription(ID FieldID) {
            switch (FieldID) {
                case ID.FieldAddress:
                    return "Address field";
                case ID.FieldDate:
                    return "Date field";
                case ID.FieldCustomerID:
                    return "Customer no. field";
                case ID.FieldDearXX:
                    return "Customer name field";
                default:
                    return "undefined field";
            }
        }
    }
}
