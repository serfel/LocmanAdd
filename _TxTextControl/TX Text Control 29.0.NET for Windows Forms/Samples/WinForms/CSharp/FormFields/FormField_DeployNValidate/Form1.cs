/*-------------------------------------------------------------------------------------------------------------
** program:			FormField_DeployNValidate
** description:	This project demonstrates the basics for implementing a form completion editor.
**						The functionalities of the RibbonFormFieldsTab for navigating to FormFields is reused 
**						and an additional button is added for validating if any FormField has invalid data. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/

using FormField_DeployNValidate.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.Windows.Forms.Ribbon;

namespace FormField_DeployNValidate {
	public partial class Form1 : Form {

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {

			// Customize Ribbon
			// Use the form fields tab as a basis for a new tab for the fill-in protection mode.
			CustomizeFormFieldsTab();

			// Load the template that contains 'Form Fields' combined with 'Conditional Instructions'.
			textControl1.Load("travel-form.tx", StreamType.InternalUnicodeFormat);

			// Activate the highlighting of invalid values.
			(ribbonFormFieldsTab.FindItem(RibbonFormFieldsTab.RibbonItem.TXITEM_HighlightInvalidValues) as RibbonToggleButton).Checked = true;

			EnableFormFieldsProtection();
		}

		private void EnableFormFieldsProtection() {
			textControl1.DocumentPermissions.ReadOnly = true;
			textControl1.DocumentPermissions.AllowEditingFormFields = true;
			textControl1.EditMode = TXTextControl.EditMode.ReadAndSelect;
		}

		private void CustomizeFormFieldsTab() {

			// Remove ribbon elements for inserting, editing, removing FormFields.
			List<RibbonGroup> toRemove = new List<RibbonGroup>(); // List of groups to remove of FormFieldsTab

			foreach (RibbonGroup rGrp in ribbonFormFieldsTab.RibbonGroups) {

				switch (rGrp.Name) {
					case "TXITEM_EditFormFieldsGroup":
						CustomizeEditFormFieldsGroup(rGrp);
						break;

					case "TXITEM_FormValidationGroup":
						CustomizeFormFieldValidationGroup(rGrp);
						break;

					default:
						// Collect all groups for removing except "TXITEM_EditFormFieldsGroup" and "TXITEM_FormValidationGroup".
						toRemove.Add(rGrp);
						break;
				}
			}

			// Remove all groups except "TXITEM_EditFormFieldsGroup" and "TXITEM_FormValidationGroup".
			foreach (RibbonGroup rGrp in toRemove) {
				ribbonFormFieldsTab.RibbonGroups.Remove(rGrp);
			}

			AddValidateAndFinishGroup();
		}

		private void CustomizeEditFormFieldsGroup(RibbonGroup editFormFieldsGroup) {
			// Rename Group
			editFormFieldsGroup.Text = Properties.Resources.RIBBONGROUP_EDITFORMFIELDS_TEXT;

			// Remove 'TXITEM_DeleteFormField'
			editFormFieldsGroup.RibbonItems.Remove(ribbonFormFieldsTab.FindItem(RibbonFormFieldsTab.RibbonItem.TXITEM_DeleteFormField));
			// Remove 'TXITEM_RemoveFormFieldsContent'
			editFormFieldsGroup.RibbonItems.Remove(ribbonFormFieldsTab.FindItem(RibbonFormFieldsTab.RibbonItem.TXITEM_RemoveFormFieldsContent));
		}

		private void CustomizeFormFieldValidationGroup(RibbonGroup formFieldValidationGroup) {
			// Remove 'TXITEM_ManageConditionalInstructions'
			formFieldValidationGroup.RibbonItems.Remove(ribbonFormFieldsTab.FindItem(RibbonFormFieldsTab.RibbonItem.TXITEM_ManageConditionalInstructions));
			// Remove 'TXITEM_EnableFormValidation'
			formFieldValidationGroup.RibbonItems.Remove(ribbonFormFieldsTab.FindItem(RibbonFormFieldsTab.RibbonItem.TXITEM_EnableFormValidation));
		}

		private void AddValidateAndFinishGroup() {
			var grp = new RibbonGroup()
			{
				Text = Resources.RIBBONGROUP_VALIDATEANDFINISH_TEXT,
				HorizontalContentAlignment = TXTextControl.HorizontalAlignment.Center
			};
			grp.DialogBoxLauncher.Visible = false;

			ribbonFormFieldsTab.RibbonGroups.Add(grp);

			// Add additional button for validating the document.
			AddRibbonValidateButton(grp);
		}

		private void AddRibbonValidateButton(RibbonGroup grp) {
			RibbonButton btnValidate = new RibbonButton()
			{
				Text = Resources.RIBBONBUTTON_VALIDATEDOCUMENT_TEXT,
				LargeIcon = Resources.finishforms,
			};
			btnValidate.Click += btnValidate_Click;

			grp.RibbonItems.Add(btnValidate);
		}

		void btnValidate_Click(object sender, EventArgs e) {
			foreach (FormField ff in textControl1.FormFields) {
				if (!textControl1.FormFields.ConditionalInstructions.HasValidValue(ff)) {

					MessageBox.Show(this, Resources.MSG_INVALIDDOCUMENT_TEXT, 
                        Resources.MSG_VALIDATIONFINISHED_CAPTION, 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);

					// Scroll to first invalid form field.
					ff.ScrollTo();
					return;
				}
			}

			MessageBox.Show(this, Resources.MSG_VALIDDOCUMENT_TEXT, 
                Resources.MSG_VALIDATIONFINISHED_CAPTION, 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
		}
	}
}
