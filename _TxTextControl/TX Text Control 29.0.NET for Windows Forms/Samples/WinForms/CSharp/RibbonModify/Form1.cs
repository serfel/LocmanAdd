/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Ribbon Modify Tutorial Sample
** description:	Shows how to create a word processor application with a ribbon interface from 
**                  scratch with just a few lines of code. Contextual ribbon tabs for table and 
**                  frame layout tasks are added and connected.						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace RibbonModify {

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        // Click handler for button "btnRemove"
        private void btnRemove_Click(object sender, EventArgs e) {
            // use the FindItem method to retrieve the "Paste" button
            RibbonSplitButton ribbonItem = (RibbonSplitButton)ribbonFormattingTab1.FindItem(
                RibbonFormattingTab.RibbonItem.TXITEM_Paste);

            // remove the button from the parent collection (RibbonGroup)
            if (ribbonItem.ParentCollection != null)
                ribbonItem.ParentCollection.Remove(ribbonItem);
        }

        // Click handler for button "btnChangeText"
        private void btnChangeText_Click(object sender, EventArgs e) {
            RibbonSplitButton ribbonItem = (RibbonSplitButton)ribbonFormattingTab1.FindItem(
                RibbonFormattingTab.RibbonItem.TXITEM_Paste);

            // change the button text
            ribbonItem.Text = "New Text";
        }

        // Click handler for button "btnAddEvent"
        private void btnAddEvent_Click(object sender, EventArgs e) {
            RibbonSplitButton ribbonItem = (RibbonSplitButton)ribbonFormattingTab1.FindItem(
                RibbonFormattingTab.RibbonItem.TXITEM_Paste);

            // attach the ButtonClick event
            ribbonItem.ButtonClick += RibbonItem_ButtonClick;
        }

        private void RibbonItem_ButtonClick(object sender, EventArgs e) {
            MessageBox.Show("Button clicked!");
        }

        // Click handler for button "btnNewTab"
        private void btnNewTab_Click(object sender, EventArgs e) {
            // create a new RibbonTab control and set the text (tab title)
            RibbonTab myRibbonTab = new RibbonTab();
            myRibbonTab.Text = "MyRibbonTab";

            // create a new RibbonGroup
            RibbonGroup myRibbonGroup = new RibbonGroup() {
                Text = "My Group"
            };

            // make the dialog launcher icon invisible
            myRibbonGroup.DialogBoxLauncher.Visible = false;

            // add the new RibbonGroup to the RibbonGroup collection
            // of the newly created RibbonTab
            myRibbonTab.RibbonGroups.Add(myRibbonGroup);

            // create a new RibbonButton
            RibbonButton rbtnClickMe = new RibbonButton() {
                Text = "Click me!",
                IsAddToQuickAccessToolbarEnabled = true,
            };

            // set some properties of the button and attach a "Click" event
            rbtnClickMe.ToolTip.Title = "Tooltip Title";
            rbtnClickMe.ToolTip.Description = "Tooltip Description";
            rbtnClickMe.DisplayMode = IconTextRelation.LargeIconLabeled;
            rbtnClickMe.LargeIcon = Image.FromFile("previewclose.png");
            rbtnClickMe.Click += RbtnClickMe_Click;
            rbtnClickMe.BackColor = Color.LawnGreen;

            // add the button to the RibbonGroup
            myRibbonGroup.RibbonItems.Add(rbtnClickMe);

            // add the newly created RibbonTab to the Ribbon control
            ribbon1.Controls.Add(myRibbonTab);

            // set the selected tab to the new RibbonTab
            ribbon1.SelectedIndex = ribbon1.TabCount - 1;
        }

        private void RbtnClickMe_Click(object sender, EventArgs e) {
            textControl1.Selection.Text = "New text!";
        }

        // Click handler for button "btnRemoveGroup"
        private void btnRemoveGroup_Click(object sender, EventArgs e) {
            // iterate through all RibbonGroups and remove the Font group
            foreach (RibbonGroup group in ribbonFormattingTab1.RibbonGroups) {
                if (group.Name == "TXITEM_FontGroup") {
                    ribbonFormattingTab1.RibbonGroups.Remove(group);
                    break;
                }
            }
        }

        // Click handler for button "btnRemoveTab"
        private void btnRemoveTab_Click(object sender, EventArgs e) {
            // remove the "Insert" tab
            ribbon1.Controls.Remove(ribbonInsertTab1);
        }

    }
}
