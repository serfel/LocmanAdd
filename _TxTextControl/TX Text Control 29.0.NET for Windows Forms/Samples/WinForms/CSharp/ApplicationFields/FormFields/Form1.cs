/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Mail Merge Sample
** description:	Shows how to use the DocumentServer.MailMerge class in Windows Forms projects 
**              to merge TXTextControl.ApplicationFields in template documents with data from 
**              various data sources. The MailMerge class encapsulates powerful mail merge 
**              capabilities in a ready-to-use component. The DocumentServer.MailMerge class 
**              is part of the TXTextControl.DocumentServer namespace.
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;

namespace FormFields {
    public partial class Form1 : Form {

        public Form1() {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // connect the TX Text Control controls
            textControl1.ButtonBar = buttonBar1;
            textControl1.RulerBar = rulerBar1;
            textControl1.VerticalRulerBar = rulerBar2;
            textControl1.StatusBar = statusBar1;
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e) {
            // inserts a new ApplicationField of type FORMTEXT
            TXTextControl.ApplicationField newField = new TXTextControl.ApplicationField(TXTextControl.ApplicationFieldFormat.MSWord, "FORMTEXT", "[New FormTextBoxField]", new string[] { "w:name w:val=\"newField\"" });
            newField.DoubledInputPosition = true;
            newField.HighlightMode = TXTextControl.HighlightMode.Activated;

            textControl1.ApplicationFields.Add(newField);
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e) {
            // casts an ApplicationField of type FORMTEXT to a FormTextBox object
            // and opens the appropriate dialog box
            if (textControl1.ApplicationFields.GetItem().TypeName == "FORMTEXT") {
                FormText curFormText = new FormText(textControl1.ApplicationFields.GetItem());

                TextFormFieldOptions TextFormFieldDialog = new TextFormFieldOptions(curFormText);
                TextFormFieldDialog.ShowDialog();
            }
        }

        private void formFieldsToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            // enables of disables the properties menu item
            if (textControl1.ApplicationFields.GetItem() == null)
                propertiesToolStripMenuItem.Enabled = false;
            else
                propertiesToolStripMenuItem.Enabled = true;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
            TXTextControl.LoadSettings ls = new TXTextControl.LoadSettings();
            ls.ApplicationFieldFormat = TXTextControl.ApplicationFieldFormat.MSWord;
            ls.ApplicationFieldTypeNames = new string[] { "FORMTEXT" };
            textControl1.Load(TXTextControl.StreamType.MSWord | TXTextControl.StreamType.WordprocessingML, ls);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Save(TXTextControl.StreamType.MSWord | TXTextControl.StreamType.WordprocessingML);
        }
    }
}