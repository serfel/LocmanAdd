/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Mini Toolbar Sample
** description:	 Explains the typical process of manipulating the MiniToolbar.		
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.Windows.Forms.Ribbon;

namespace MiniToolbar {

    public partial class frmMain : Form {

        public frmMain() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            textControl1.Load("sample.tx", TXTextControl.StreamType.InternalFormat);
        }

        // Modify the basic structure of the TextMiniTolbar.
        private void textControl1_TextMiniToolbarInitialized(object sender, TXTextControl.MiniToolbarInitializedEventArgs e) {
            // Ensure that the TextMiniToolbar's table layout group won't be displayed if the input position is inside a table
            e.MiniToolbar.RibbonGroups.Remove((e.MiniToolbar as TextMiniToolbar).FindItem(TextMiniToolbar.RibbonItem.TXITEM_TableLayoutGroup) as RibbonGroup);

            // Create and add a ribbon group to the TextMiniToolbar that provides an "Edit Hyperlink" button.
            e.MiniToolbar.RibbonGroups.Add(CreateEditHyperlinkGroup());
        }

        // Update the TextMiniToolbar's content visibility.
        private void textControl1_MiniToolbarOpening(object sender, TXTextControl.MiniToolbarOpeningEventArgs e) {
            // Check whether the opening mini tool bar is type of TextMiniToolbar
            if (e.MiniToolbar is TextMiniToolbar) {
                e.MiniToolbar.RibbonGroups[1].Visible = true;	// Ensure that the TextMiniToolbar's Styles group is always shown (even the input position is inside a table)
                e.MiniToolbar.RibbonGroups[1].ShowSeperator =	// Ensure that the Styles group's seperator and...
                e.MiniToolbar.RibbonGroups[2].Visible = 	    // ... and the "Edit Hyperlink" group are displayed if...

                (e.MiniToolbarContext & ContextMenuLocation.TextField) == ContextMenuLocation.TextField && // ... the current context is TextField and ...
                textControl1.HypertextLinks.GetItem() != null; // ... the text field is type of TXTextControl.HypertextLink
            }
        }

        // Creates an Edit Hyperlink ribbon gropup
        private RibbonGroup CreateEditHyperlinkGroup() {
            // Create a ribbon group that contains...
            RibbonGroup rgEditHyperlinkGroup = new RibbonGroup() {
                ShowSeperator = false
            };
            // ... a button to open the TextControl Edit HyperlinkDialog
            Bitmap bmpEditHyperLink = new Bitmap("edithyperlink.png");
            RibbonButton rbtnEditHyperlink = new RibbonButton() {
                Text = "Edit Hyperlink",
                LargeIcon = bmpEditHyperLink
            };
            rbtnEditHyperlink.Click += EditHyperlink_Click;

            // Add the edit hyperlink button to group.
            rgEditHyperlinkGroup.RibbonItems.Add(rbtnEditHyperlink);

            return rgEditHyperlinkGroup;
        }

        // Opens the TextControl HyperlinkDialog
        private void EditHyperlink_Click(object sender, EventArgs e) {
            new HyperlinkDialog(textControl1).ShowDialog(textControl1);
        }
    }
}
