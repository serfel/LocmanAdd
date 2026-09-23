using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class503 : Class500
	{
		private Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_1 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_2 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_3 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_4 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_5 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_6 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_7 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_8 = new Dictionary<string, object>();

		internal Class494 class494_0;

		internal Class494 class494_1;

		internal Class494 class494_2;

		internal Class494 class494_3;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_InsertFormFieldsGroup_Items => this.dictionary_0;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_EditFormFieldsGroup_Items => this.dictionary_1;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_FormValidationGroup_Items => this.dictionary_2;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_FormFieldPropertiesGroup_Items => this.dictionary_3;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_CheckBoxFieldPropertiesGroup_Items => this.dictionary_4;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_TextFormFieldPropertiesGroup_Items => this.dictionary_5;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_ComboBoxFieldPropertiesGroup_Items => this.dictionary_6;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_DropDownListFieldPropertiesGroup_Items => this.dictionary_7;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_DateFormFieldPropertiesGroup_Items => this.dictionary_8;

		internal Class503(Control control_1, BindingAdapter bindingAdapter_1)
			: base(control_1, bindingAdapter_1)
		{
		}

		internal void method_10(RibbonGroupCollection ribbonGroupCollection_0)
		{
			HorizontalRibbonGroup horizontalRibbonGroup = new HorizontalRibbonGroup();
			horizontalRibbonGroup.RowCount = 2;
			horizontalRibbonGroup.HorizontalContentAlignment = HorizontalAlignment.Center;
			HorizontalRibbonGroup horizontalRibbonGroup2 = horizontalRibbonGroup;
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_0, horizontalRibbonGroup2, RibbonFormFieldsTab.InternalRibbonItem.TXITEM_InsertFormFieldsGroup.ToString(), null, null);
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_InsertTextFormField.ToString();
			ribbonButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_InsertCheckBoxField.ToString();
			ribbonButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonButton ribbonButton4 = ribbonButton3;
			RibbonButton ribbonButton5 = new RibbonButton();
			ribbonButton5.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_InsertComboBoxField.ToString();
			ribbonButton5.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonButton ribbonButton6 = ribbonButton5;
			RibbonButton ribbonButton7 = new RibbonButton();
			ribbonButton7.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_InsertDropDownListField.ToString();
			ribbonButton7.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonButton ribbonButton8 = ribbonButton7;
			RibbonButton ribbonButton9 = new RibbonButton();
			ribbonButton9.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_InsertDateFormField.ToString();
			ribbonButton9.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonButton ribbonButton10 = ribbonButton9;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton4, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton6, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton8, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton10, "Click", hasImage: true);
			horizontalRibbonGroup2.AddRange(new Control[2] { ribbonButton2, ribbonButton4 }, 0);
			horizontalRibbonGroup2.AddRange(new Control[3] { ribbonButton6, ribbonButton8, ribbonButton10 }, 1);
			base.list_0.Add(horizontalRibbonGroup2);
			Class517.smethod_29(this.dictionary_0);
			ribbonGroupCollection_0.Add(horizontalRibbonGroup2);
		}

		internal void method_11(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_1, ribbonGroup, RibbonFormFieldsTab.InternalRibbonItem.TXITEM_EditFormFieldsGroup.ToString(), null, null);
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DeleteFormField.ToString();
			ribbonButton.DisplayMode = IconTextRelation.LargeIconLabeled;
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_RemoveFormFieldsContent.ToString();
			ribbonButton3.DisplayMode = IconTextRelation.LargeIconLabeled;
			RibbonButton ribbonButton4 = ribbonButton3;
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_HighlightFormFields.ToString();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			ribbonToggleButton.Checked = true;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonButton ribbonButton5 = new RibbonButton();
			ribbonButton5.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_PreviousFormField.ToString();
			ribbonButton5.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonButton ribbonButton6 = ribbonButton5;
			RibbonButton ribbonButton7 = new RibbonButton();
			ribbonButton7.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_NextFormField.ToString();
			ribbonButton7.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonButton ribbonButton8 = ribbonButton7;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton4, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonToggleButton2, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton6, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton8, "Click", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[5] { ribbonButton2, ribbonButton4, ribbonToggleButton2, ribbonButton6, ribbonButton8 });
			Class517.smethod_29(this.dictionary_1);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_12(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.Visible = false;
			ribbonGroup.RowCount = 2;
			RibbonGroup ribbonGroup2 = ribbonGroup;
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_3, ribbonGroup2, RibbonFormFieldsTab.InternalRibbonItem.TXITEM_FormFieldPropertiesGroup.ToString(), null, null);
			RibbonTextBox ribbonTextBox = new RibbonTextBox();
			ribbonTextBox.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_FormFieldName.ToString();
			ribbonTextBox.TextBoxWidth = Class519.Class538.Int32_0;
			ribbonTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			RibbonTextBox ribbonTextBox2 = ribbonTextBox;
			RibbonTextBox ribbonTextBox3 = new RibbonTextBox();
			ribbonTextBox3.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_FormFieldID.ToString();
			ribbonTextBox3.TextBoxWidth = Class519.Class538.Int32_1;
			ribbonTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			RibbonTextBox ribbonTextBox4 = ribbonTextBox3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonTextBox2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonTextBox4, null, hasImage: true);
			ribbonGroup2.RibbonItems.AddRange(new Control[2] { ribbonTextBox2, ribbonTextBox4 });
			base.list_0.Add(ribbonGroup2);
			Class517.smethod_29(this.dictionary_3);
			ribbonGroupCollection_0.Add(ribbonGroup2);
		}

		internal void method_13(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.HorizontalContentAlignment = HorizontalAlignment.Center;
			RibbonGroup ribbonGroup2 = ribbonGroup;
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_2, ribbonGroup2, RibbonFormFieldsTab.InternalRibbonItem.TXITEM_FormValidationGroup.ToString(), null, null);
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_EnableFormValidation.ToString();
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_HighlightInvalidValues.ToString();
			ribbonToggleButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_PreviousInvalidValueFormField.ToString();
			ribbonButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			ribbonButton.Enabled = true;
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_NextInvalidValueFormField.ToString();
			ribbonButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			ribbonButton3.Enabled = true;
			RibbonButton ribbonButton4 = ribbonButton3;
			RibbonButton ribbonButton5 = new RibbonButton();
			ribbonButton5.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions.ToString();
			RibbonButton ribbonButton6 = ribbonButton5;
			RibbonSplitButton ribbonSplitButton = new RibbonSplitButton();
			ribbonSplitButton.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars.ToString();
			ribbonSplitButton.Checkable = true;
			RibbonSplitButton ribbonItem = ribbonSplitButton;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton2, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton4, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonButton4, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonButton6, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonItem, "ButtonClick", hasImage: true);
			ribbonGroup2.RibbonItems.AddRange(new Control[5] { ribbonToggleButton2, ribbonToggleButton4, ribbonButton2, ribbonButton4, ribbonButton6 });
			Class517.smethod_29(this.dictionary_2);
			ribbonButton6.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Dialog.ToString();
			this.dictionary_2.Add(ribbonButton6.Name, ribbonButton6);
			ribbonGroupCollection_0.Add(ribbonGroup2);
		}

		internal void method_14(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.Visible = false;
			ribbonGroup.RowCount = 2;
			RibbonGroup ribbonGroup2 = ribbonGroup;
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_4, ribbonGroup2, RibbonFormFieldsTab.InternalRibbonItem.TXITEM_CheckBoxFieldPropertiesGroup.ToString(), null, null);
			RibbonLabel ribbonLabel = new RibbonLabel();
			ribbonLabel.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_CheckedSymbolLabel.ToString();
			RibbonLabel ribbonLabel2 = ribbonLabel;
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_CheckedSymbol.ToString();
			ribbonMenuButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonLabel ribbonLabel3 = new RibbonLabel();
			ribbonLabel3.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_UncheckedSymbolLabel.ToString();
			RibbonLabel ribbonLabel4 = ribbonLabel3;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_UncheckedSymbol.ToString();
			ribbonMenuButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonLabel2, null, hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonLabel4, null, hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonMenuButton2, null, hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonMenuButton4, null, hasImage: false);
			ribbonGroup2.RibbonItems.AddRange(new Control[4] { ribbonLabel2, ribbonLabel4, ribbonMenuButton2, ribbonMenuButton4 });
			base.list_0.Add(ribbonGroup2);
			Class517.smethod_29(this.dictionary_4);
			ribbonGroupCollection_0.Add(ribbonGroup2);
		}

		internal void method_15(RibbonGroupCollection ribbonGroupCollection_0)
		{
			this.class494_0 = new Class494(base.bindingAdapter_0 as Class474);
			RibbonGroup ribbonGroup2 = (this.class494_0.RibbonGroup_0 = new RibbonGroup
			{
				Visible = false,
				RowCount = 2
			});
			RibbonGroup ribbonGroup3 = ribbonGroup2;
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_5, ribbonGroup3, RibbonFormFieldsTab.InternalRibbonItem.TXITEM_TextFormFieldPropertiesGroup.ToString(), null, null);
			RibbonTextBox ribbonTextBox2 = (this.class494_0.RibbonTextBox_0 = new RibbonTextBox
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_TextFormFieldEmptyWidth.ToString()
			});
			RibbonTextBox ribbonTextBox3 = ribbonTextBox2;
			RibbonButton ribbonButton2 = (this.class494_0.RibbonButton_0 = new RibbonButton
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_TextFormFieldRemoveContent.ToString(),
				DisplayMode = IconTextRelation.SmallIconLabeled
			});
			RibbonButton ribbonButton3 = ribbonButton2;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_5, ribbonTextBox3, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_5, ribbonButton3, null, hasImage: true);
			ribbonGroup3.RibbonItems.AddRange(new Control[2] { ribbonTextBox3, ribbonButton3 });
			base.list_0.Add(ribbonGroup3);
			Class517.smethod_29(this.dictionary_5);
			ribbonGroupCollection_0.Add(ribbonGroup3);
		}

		internal void method_16(RibbonGroupCollection ribbonGroupCollection_0)
		{
			this.class494_1 = new Class494(base.bindingAdapter_0 as Class474);
			RibbonGroup ribbonGroup2 = (this.class494_1.RibbonGroup_0 = new RibbonGroup
			{
				Visible = false,
				RowCount = 2
			});
			RibbonGroup ribbonGroup3 = ribbonGroup2;
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_6, ribbonGroup3, RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ComboBoxFieldPropertiesGroup.ToString(), null, null);
			RibbonTextBox ribbonTextBox2 = (this.class494_1.RibbonTextBox_0 = new RibbonTextBox
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ComboBoxFieldEmptyWidth.ToString()
			});
			RibbonTextBox ribbonTextBox3 = ribbonTextBox2;
			RibbonButton ribbonButton2 = (this.class494_1.RibbonButton_0 = new RibbonButton
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ComboBoxFieldRemoveContent.ToString(),
				DisplayMode = IconTextRelation.SmallIconLabeled
			});
			RibbonButton ribbonButton3 = ribbonButton2;
			RibbonButton ribbonButton5 = (this.class494_1.RibbonButton_1 = new RibbonButton
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_NewComboBoxListItem.ToString(),
				DisplayMode = IconTextRelation.SmallIconLabeled,
				IsAddToQuickAccessToolbarEnabled = false
			});
			RibbonButton ribbonButton6 = ribbonButton5;
			RibbonButton ribbonButton8 = (this.class494_1.RibbonButton_2 = new RibbonButton
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DeleteComboBoxListItem.ToString(),
				DisplayMode = IconTextRelation.SmallIconLabeled,
				IsAddToQuickAccessToolbarEnabled = false
			});
			RibbonButton ribbonButton9 = ribbonButton8;
			RibbonButton ribbonButton11 = (this.class494_1.RibbonButton_3 = new RibbonButton
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ComboBoxListItemMoveUp.ToString(),
				DisplayMode = IconTextRelation.SmallIconLabeled,
				Enabled = false,
				IsAddToQuickAccessToolbarEnabled = false
			});
			RibbonButton ribbonButton12 = ribbonButton11;
			RibbonButton ribbonButton14 = (this.class494_1.RibbonButton_4 = new RibbonButton
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ComboBoxListItemMoveDown.ToString(),
				DisplayMode = IconTextRelation.SmallIconLabeled,
				Enabled = false,
				IsAddToQuickAccessToolbarEnabled = false
			});
			RibbonButton ribbonButton15 = ribbonButton14;
			RibbonListView ribbonListView2 = (this.class494_1.RibbonListView_0 = new RibbonListView
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ComboBoxListItems.ToString(),
				BackColor = Color.White,
				MinRowCount = 3,
				MaxVisibleRows = 3,
				EditItemTextBoxEmptyWidth = 250,
				MaxColumnWidth = 250,
				ViewMode = RibbonListView.ListViewMode.Text,
				MaxColumnCount = 1,
				ShowBorder = true,
				ShowItemsInDropDown = true,
				MultiSelect = true,
				ItemsSource = new RibbonListView.RibbonListViewItem[0],
				SelectWithArrowKeys = true,
				MinColumnWidth = 150
			});
			RibbonListView ribbonListView3 = ribbonListView2;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_6, ribbonTextBox3, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_6, ribbonButton3, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_6, ribbonButton6, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_6, ribbonButton9, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_6, ribbonListView3, null, hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_6, ribbonButton12, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_6, ribbonButton15, null, hasImage: true);
			ribbonGroup3.RibbonItems.AddRange(new Control[7] { ribbonTextBox3, ribbonButton3, ribbonButton6, ribbonButton9, ribbonListView3, ribbonButton12, ribbonButton15 });
			base.list_0.Add(ribbonGroup3);
			Class517.smethod_29(this.dictionary_6);
			ribbonGroupCollection_0.Add(ribbonGroup3);
		}

		internal void method_17(RibbonGroupCollection ribbonGroupCollection_0)
		{
			this.class494_2 = new Class494(base.bindingAdapter_0 as Class474);
			RibbonGroup ribbonGroup2 = (this.class494_2.RibbonGroup_0 = new RibbonGroup
			{
				Visible = false,
				RowCount = 2
			});
			RibbonGroup ribbonGroup3 = ribbonGroup2;
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_7, ribbonGroup3, RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DropDownListFieldPropertiesGroup.ToString(), null, null);
			RibbonTextBox ribbonTextBox2 = (this.class494_2.RibbonTextBox_0 = new RibbonTextBox
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DropDownListFieldEmptyWidth.ToString()
			});
			RibbonTextBox ribbonTextBox3 = ribbonTextBox2;
			RibbonButton ribbonButton2 = (this.class494_2.RibbonButton_0 = new RibbonButton
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DropDownListFieldRemoveContent.ToString(),
				DisplayMode = IconTextRelation.SmallIconLabeled
			});
			RibbonButton ribbonButton3 = ribbonButton2;
			RibbonButton ribbonButton5 = (this.class494_2.RibbonButton_1 = new RibbonButton
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_NewDropDownListItem.ToString(),
				DisplayMode = IconTextRelation.SmallIconLabeled,
				IsAddToQuickAccessToolbarEnabled = false
			});
			RibbonButton ribbonButton6 = ribbonButton5;
			RibbonButton ribbonButton8 = (this.class494_2.RibbonButton_2 = new RibbonButton
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DeleteDropDownListItem.ToString(),
				DisplayMode = IconTextRelation.SmallIconLabeled,
				IsAddToQuickAccessToolbarEnabled = false
			});
			RibbonButton ribbonButton9 = ribbonButton8;
			RibbonButton ribbonButton11 = (this.class494_2.RibbonButton_3 = new RibbonButton
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DropDownListItemMoveUp.ToString(),
				DisplayMode = IconTextRelation.SmallIconLabeled,
				Enabled = false,
				IsAddToQuickAccessToolbarEnabled = false
			});
			RibbonButton ribbonButton12 = ribbonButton11;
			RibbonButton ribbonButton14 = (this.class494_2.RibbonButton_4 = new RibbonButton
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DropDownListItemMoveDown.ToString(),
				DisplayMode = IconTextRelation.SmallIconLabeled,
				Enabled = false,
				IsAddToQuickAccessToolbarEnabled = false
			});
			RibbonButton ribbonButton15 = ribbonButton14;
			RibbonListView ribbonListView2 = (this.class494_2.RibbonListView_0 = new RibbonListView
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DropDownListItems.ToString(),
				BackColor = Color.White,
				MinRowCount = 3,
				MaxVisibleRows = 3,
				EditItemTextBoxEmptyWidth = 240,
				MaxColumnWidth = 250,
				ViewMode = RibbonListView.ListViewMode.Text,
				MaxColumnCount = 1,
				ShowBorder = true,
				ShowItemsInDropDown = true,
				MultiSelect = true,
				ItemsSource = new RibbonListView.RibbonListViewItem[0],
				SelectWithArrowKeys = true,
				MinColumnWidth = 250
			});
			RibbonListView ribbonListView3 = ribbonListView2;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_7, ribbonTextBox3, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_7, ribbonButton3, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_7, ribbonButton6, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_7, ribbonButton9, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_7, ribbonListView3, null, hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_7, ribbonButton12, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_7, ribbonButton15, null, hasImage: true);
			ribbonGroup3.RibbonItems.AddRange(new Control[7] { ribbonTextBox3, ribbonButton3, ribbonButton6, ribbonButton9, ribbonListView3, ribbonButton12, ribbonButton15 });
			base.list_0.Add(ribbonGroup3);
			Class517.smethod_29(this.dictionary_7);
			ribbonGroupCollection_0.Add(ribbonGroup3);
		}

		internal void method_18(RibbonGroupCollection ribbonGroupCollection_0)
		{
			this.class494_3 = new Class494(base.bindingAdapter_0 as Class474);
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.Visible = false;
			ribbonGroup.RowCount = 2;
			RibbonGroup ribbonGroup2 = ribbonGroup;
			this.class494_3.RibbonGroup_0 = ribbonGroup2;
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_8, ribbonGroup2, RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DateFormFieldPropertiesGroup.ToString(), null, null);
			RibbonLabel ribbonLabel = new RibbonLabel();
			ribbonLabel.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DateFormFieldEmptyWidthLabel.ToString();
			RibbonLabel ribbonLabel2 = ribbonLabel;
			RibbonTextBox ribbonTextBox2 = (this.class494_3.RibbonTextBox_0 = new RibbonTextBox
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DateFormFieldEmptyWidth.ToString(),
				DisplayMode = IconTextRelation.NoIconLabeled
			});
			RibbonTextBox ribbonTextBox3 = ribbonTextBox2;
			RibbonButton ribbonButton2 = (this.class494_3.RibbonButton_0 = new RibbonButton
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DateFormFieldRemoveContent.ToString(),
				DisplayMode = IconTextRelation.SmallIconLabeled
			});
			RibbonButton ribbonButton3 = ribbonButton2;
			RibbonLabel ribbonLabel3 = new RibbonLabel();
			ribbonLabel3.Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DateFormat.ToString();
			RibbonLabel ribbonLabel4 = ribbonLabel3;
			RibbonComboBox ribbonComboBox2 = (this.class494_3.RibbonComboBox_0 = new RibbonComboBox
			{
				Name = RibbonFormFieldsTab.InternalRibbonItem.TXITEM_SupportedDateFormats.ToString(),
				DropDownStyle = ComboBoxStyle.DropDownList,
				BackColor = SystemColors.Window
			});
			RibbonComboBox ribbonComboBox3 = ribbonComboBox2;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_8, ribbonLabel2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_8, ribbonTextBox3, null, hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_8, ribbonButton3, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_8, ribbonLabel4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_8, ribbonComboBox3, null, hasImage: false);
			ribbonGroup2.RibbonItems.AddRange(new Control[5] { ribbonLabel2, ribbonLabel4, ribbonTextBox3, ribbonComboBox3, ribbonButton3 });
			base.list_0.Add(ribbonGroup2);
			Class517.smethod_29(this.dictionary_8);
			ribbonGroupCollection_0.Add(ribbonGroup2);
		}

		protected override void vmethod_1()
		{
			base.vmethod_1();
			(base.bindingAdapter_0 as Class474).method_47();
		}

		internal override void vmethod_0(object sender, PropertyChangedEventArgs e)
		{
			base.vmethod_0(sender, e);
			if (e.PropertyName == "EditMode")
			{
				(base.bindingAdapter_0 as Class474).method_33();
			}
		}
	}
}
