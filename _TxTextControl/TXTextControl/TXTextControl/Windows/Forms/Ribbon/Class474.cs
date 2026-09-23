using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class474 : BindingAdapter
	{
		private const int int_0 = 2000;

		private Class503 class503_0;

		internal MeasuringUnit measuringUnit_0 = MeasuringUnit.Millimeter;

		internal int int_1 = 1;

		internal double double_0 = 1.0;

		internal double double_1 = 1.0;

		private Color color_0 = default(Color);

		private RibbonTextBox ribbonTextBox_0;

		private bool bool_0;

		private string string_0 = "Segoe UI Emoji";

		private Point point_0 = Point.Empty;

		private Size size_0 = Size.Empty;

		internal bool bool_1;

		private Point point_1 = Point.Empty;

		private Size size_1 = Size.Empty;

		internal bool bool_2;

		private bool bool_3 = true;

		private bool bool_4 = true;

		internal override Class500 RibbonGroupManager
		{
			get
			{
				return this.class503_0;
			}
			set
			{
				this.class503_0 = value as Class503;
			}
		}

		internal Color Color_0
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				RibbonToggleButton ribbonToggleButton = this.class503_0.TXITEM_EditFormFieldsGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_HighlightFormFields.ToString()] as RibbonToggleButton;
				ribbonToggleButton.Checked = ((base.m_txTextControl != null && base.m_txTextControl.DisplayColors.FormFieldColor.A != 0) ? true : false);
				this.TXITEM_HighlightFormFields_Handler(ribbonToggleButton, EventArgs.Empty);
			}
		}

		private void method_0(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonSplitButton)
			{
				RibbonSplitButton ribbonSplitButton = (RibbonSplitButton)control_0;
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars_Vertical.ToString(), "null", this);
				ribbonToggleButton.CheckedChanged += method_51;
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars_Horizontal.ToString(), null, this);
				ribbonToggleButton2.CheckedChanged += method_51;
				ribbonSplitButton.DropDownItems.AddRange(new Control[2] { ribbonToggleButton, ribbonToggleButton2 });
			}
		}

		private void method_1(Dictionary<string, object> dictionary_0, RibbonMenuButton ribbonMenuButton_0, string string_1, string string_2, string string_3)
		{
			ribbonMenuButton_0.DropDownOpening += method_54;
			RibbonLabel ribbonLabel = new RibbonLabel();
			ribbonLabel.Text = base.m_rmResourceManager.GetString(string_1.Replace("TXITEM_", "HEADER_"));
			ribbonLabel.Name = string_1;
			RibbonLabel ribbonLabel2 = ribbonLabel;
			((IRibbonItem)ribbonLabel2).IsDefaultRibbonTabItem = true;
			dictionary_0.Add(ribbonLabel2.Name, ribbonLabel2);
			RibbonSeperator ribbonSeperator = new RibbonSeperator();
			ribbonSeperator.Name = string_2;
			RibbonSeperator ribbonSeperator2 = ribbonSeperator;
			((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
			dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
			RibbonListView ribbonListView = this.method_2(dictionary_0, string_3);
			ribbonMenuButton_0.DropDownItems.AddRange(new Control[3] { ribbonLabel2, ribbonSeperator2, ribbonListView });
		}

		private RibbonListView method_2(Dictionary<string, object> dictionary_0, string string_1)
		{
			RibbonListView ribbonListView = new RibbonListView();
			((IRibbonItem)ribbonListView).IsDefaultRibbonTabItem = true;
			ribbonListView.Name = string_1;
			ribbonListView.Deselectable = false;
			ribbonListView.MinColumnCount = 6;
			ribbonListView.ItemClick += method_55;
			dictionary_0.Add(ribbonListView.Name, ribbonListView);
			return ribbonListView;
		}

		internal override void AwareOfDPI(PointF dpi)
		{
			base.AwareOfDPI(dpi);
			RibbonListView ribbonListView = this.class503_0.TXITEM_ComboBoxFieldPropertiesGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ComboBoxListItems.ToString()] as RibbonListView;
			ribbonListView.Width = Class517.smethod_45(270, dpi.X);
			RibbonListView ribbonListView2 = this.class503_0.TXITEM_DropDownListFieldPropertiesGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DropDownListItems.ToString()] as RibbonListView;
			ribbonListView2.Width = Class517.smethod_45(270, dpi.X);
			Font font_ = ((base.m_txTextControl != null) ? new Font(base.m_txTextControl.InputFormat.FontFamily, 12f) : new Font(this.string_0, 12f));
			RibbonMenuButton ribbonMenuButton = this.class503_0.TXITEM_CheckBoxFieldPropertiesGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_CheckedSymbol.ToString()] as RibbonMenuButton;
			ribbonMenuButton.SmallIcon = this.method_38('☒', new Size(16, 16), base.m_pntDPI, font_);
			RibbonMenuButton ribbonMenuButton2 = this.class503_0.TXITEM_CheckBoxFieldPropertiesGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_UncheckedSymbol.ToString()] as RibbonMenuButton;
			ribbonMenuButton2.SmallIcon = this.method_38('☐', new Size(16, 16), base.m_pntDPI, font_);
			this.method_44(this.class503_0.TXITEM_CheckBoxFieldPropertiesGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_CheckedSymbolList_Gallery.ToString()] as RibbonListView, new char[9] { '☒', '☑', '◉', '▣', '✔', '✓', '⚫', '◆', '➕' }, dpi);
			this.method_44(this.class503_0.TXITEM_CheckBoxFieldPropertiesGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_UncheckedSymbolList_Gallery.ToString()] as RibbonListView, new char[8] { '☐', '⬜', '○', '✖', '✗', '⚪', '◇', '➖' }, dpi);
			RibbonTextBox ribbonTextBox = this.class503_0.TXITEM_DateFormFieldPropertiesGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DateFormFieldEmptyWidth.ToString()] as RibbonTextBox;
			ribbonTextBox.TextBoxWidth = Class517.smethod_45(Class519.Class538.Int32_3, base.m_pntDPI.X);
			RibbonComboBox ribbonComboBox = this.class503_0.TXITEM_DateFormFieldPropertiesGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_SupportedDateFormats.ToString()] as RibbonComboBox;
			ribbonComboBox.Size = new Size(Class517.smethod_45(Class519.Class538.Int32_2, base.m_pntDPI.X), ribbonComboBox.Height);
			this.SetDialogUnit();
		}

		internal override bool SetDialogUnit()
		{
			if (base.SetDialogUnit())
			{
				switch (base.m_iDialogUnit)
				{
				case 0:
				{
					bool flag = true;
					try
					{
						RegionInfo regionInfo = new RegionInfo(Thread.CurrentThread.CurrentCulture.LCID);
						flag = regionInfo.IsMetric;
					}
					catch
					{
					}
					this.measuringUnit_0 = ((!flag) ? MeasuringUnit.CentiInch : MeasuringUnit.Millimeter);
					this.int_1 = (flag ? 1 : 3);
					this.double_0 = (flag ? 1 : 100);
					this.double_1 = (flag ? 1.0 : 0.1);
					break;
				}
				case 1:
					this.measuringUnit_0 = MeasuringUnit.Millimeter;
					this.int_1 = 1;
					this.double_0 = 1.0;
					this.double_1 = 1.0;
					break;
				case 2:
					this.measuringUnit_0 = MeasuringUnit.CentiInch;
					this.int_1 = 3;
					this.double_0 = 100.0;
					this.double_1 = 0.1;
					break;
				case 3:
					this.measuringUnit_0 = MeasuringUnit.Centimeter;
					this.int_1 = 2;
					this.double_0 = 1.0;
					this.double_1 = 0.1;
					break;
				}
				this.class503_0.class494_1.method_20();
				this.class503_0.class494_3.method_20();
				this.class503_0.class494_2.method_20();
				this.class503_0.class494_0.method_20();
				return true;
			}
			return false;
		}

		internal override void SetRibbonItemAppearance(Dictionary<string, object> groupItemsDictionary, Control ribbonItem, string eventName, bool hasImage)
		{
			base.SetBasicRibbonItemAppearance(groupItemsDictionary, ribbonItem, hasImage);
			switch (ribbonItem.Name)
			{
			case "TXITEM_FormFieldName":
				base.SetBasicRibbonTextBoxAppearance(ribbonItem as RibbonTextBox, hasImage, showDropDownButtons: false, RibbonTextBox.InputValidationMode.All);
				(ribbonItem as RibbonTextBox).TextValidated += method_52;
				break;
			case "TXITEM_FormFieldID":
			{
				base.SetBasicRibbonTextBoxAppearance(ribbonItem as RibbonTextBox, hasImage, showDropDownButtons: false, RibbonTextBox.InputValidationMode.OnlyDigits);
				RibbonTextBox ribbonTextBox = ribbonItem as RibbonTextBox;
				ribbonTextBox.Nullable_0 = 0;
				ribbonTextBox.TextValidated += method_53;
				break;
			}
			case "TXITEM_UncheckedSymbolLabel":
			case "TXITEM_CheckedSymbolLabel":
				base.SetBasicRibbonLabelAppearance(ribbonItem as RibbonLabel, hasImage);
				break;
			case "TXITEM_CheckedSymbol":
				this.method_1(groupItemsDictionary, ribbonItem as RibbonMenuButton, RibbonFormFieldsTab.InternalRibbonItem.TXITEM_CheckedSymbolList_Characters.ToString(), RibbonFormFieldsTab.InternalRibbonItem.TXITEM_CheckedSymbolSeparator1.ToString(), RibbonFormFieldsTab.InternalRibbonItem.TXITEM_CheckedSymbolList_Gallery.ToString());
				break;
			case "TXITEM_UncheckedSymbol":
				this.method_1(groupItemsDictionary, ribbonItem as RibbonMenuButton, RibbonFormFieldsTab.InternalRibbonItem.TXITEM_UncheckedSymbolList_Characters.ToString(), RibbonFormFieldsTab.InternalRibbonItem.TXITEM_UncheckedSymbolSeparator1.ToString(), RibbonFormFieldsTab.InternalRibbonItem.TXITEM_UncheckedSymbolList_Gallery.ToString());
				break;
			case "TXITEM_DateFormFieldEmptyWidth":
				(ribbonItem as RibbonTextBox).Label = "";
				break;
			case "TXITEM_DateFormFieldEmptyWidthLabel":
			case "TXITEM_DateFormat":
			{
				RibbonLabel ribbonLabel = ribbonItem as RibbonLabel;
				base.SetBasicRibbonLabelAppearance(ribbonLabel, hasImage);
				break;
			}
			case "TXITEM_ManageConditionalInstructions_Sidebars":
				this.method_0(groupItemsDictionary, ribbonItem);
				break;
			}
			if (eventName != null)
			{
				Class517.smethod_23(ribbonItem, eventName, ribbonItem.Name + "_Handler", this);
			}
		}

		internal override void OnDisconnectingTextControl()
		{
			base.m_txTextControl.TextFieldEntered -= method_57;
			base.m_txTextControl.TextFieldLeft -= method_58;
			base.m_txTextControl.TextFieldDeleted -= method_58;
			base.m_txTextControl.DocumentLoaded -= method_59;
			base.m_txTextControl.ContentsReset -= method_58;
			base.m_txTextControl.CharFormatChanged -= method_60;
			base.m_txTextControl.TextFrameActivated -= method_56;
			base.m_txTextControl.HeaderFooterActivated -= method_56;
			base.m_txTextControl.MainTextActivated -= method_56;
			this.bool_0 = false;
		}

		internal override void OnTextControlConnected()
		{
			base.m_txTextControl.TextFieldEntered += method_57;
			base.m_txTextControl.TextFieldLeft += method_58;
			base.m_txTextControl.TextFieldDeleted += method_58;
			base.m_txTextControl.DocumentLoaded += method_59;
			base.m_txTextControl.ContentsReset += method_58;
			base.m_txTextControl.CharFormatChanged += method_60;
			base.m_txTextControl.TextFrameActivated += method_56;
			base.m_txTextControl.HeaderFooterActivated += method_56;
			base.m_txTextControl.MainTextActivated += method_56;
			RibbonToggleButton obj = this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_HighlightInvalidValues.ToString()] as RibbonToggleButton;
			bool enabled = ((this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_EnableFormValidation.ToString()] as RibbonToggleButton).Checked = base.m_txTextControl != null && base.m_txTextControl.IsFormFieldValidationEnabled);
			obj.Enabled = enabled;
		}

		private void method_3()
		{
			if (base.m_txTextControl != null)
			{
				TextFormField formField = new TextFormField(this.method_42());
				base.m_txTextControl.FormFields.Add(formField);
			}
		}

		private void method_4()
		{
			if (base.m_txTextControl != null)
			{
				CheckFormField formField = new CheckFormField(isChecked: true);
				base.m_txTextControl.FormFields.Add(formField);
			}
		}

		private void method_5()
		{
			if (base.m_txTextControl != null)
			{
				SelectionFormField selectionFormField = new SelectionFormField(this.method_42());
				selectionFormField.IsDropDownArrowVisible = true;
				SelectionFormField formField = selectionFormField;
				base.m_txTextControl.FormFields.Add(formField);
			}
		}

		private void method_6()
		{
			if (base.m_txTextControl != null)
			{
				SelectionFormField selectionFormField = new SelectionFormField(this.method_42());
				selectionFormField.Editable = false;
				selectionFormField.IsDropDownArrowVisible = true;
				SelectionFormField formField = selectionFormField;
				base.m_txTextControl.FormFields.Add(formField);
			}
		}

		private void method_7()
		{
			if (base.m_txTextControl != null)
			{
				DateFormField dateFormField = new DateFormField(0);
				dateFormField.IsDateControlVisible = true;
				DateFormField formField = dateFormField;
				base.m_txTextControl.FormFields.Add(formField);
			}
		}

		private void method_8()
		{
			if (base.m_txTextControl != null)
			{
				FormField item = base.m_txTextControl.FormFields.GetItem();
				if (item != null)
				{
					base.m_txTextControl.FormFields.Remove(item);
				}
			}
		}

		private void method_9()
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			base.m_txTextControl.BeginUndoAction("ResetFormFields");
			foreach (FormField formField in base.m_txTextControl.FormFields)
			{
				switch (formField.GetType().Name)
				{
				case "TextFormField":
					(formField as TextFormField).Text = "";
					break;
				case "SelectionFormField":
					(formField as SelectionFormField).SelectedIndex = -1;
					break;
				case "DateFormField":
					(formField as DateFormField).Date = null;
					break;
				}
			}
			base.m_txTextControl.EndUndoAction();
		}

		private void method_10(bool bool_5)
		{
			if (base.m_txTextControl != null)
			{
				if (bool_5)
				{
					base.m_txTextControl.DisplayColors.FormFieldColor = this.color_0;
				}
				else
				{
					base.m_txTextControl.DisplayColors.FormFieldColor = Color.Transparent;
				}
			}
		}

		private void method_11()
		{
			if (base.m_txTextControl != null)
			{
				this.method_41(base.m_txTextControl.InputPosition.TextPosition + 1, bool_5: false)?.ScrollTo();
			}
		}

		private void method_12()
		{
			if (base.m_txTextControl != null)
			{
				this.method_40(base.m_txTextControl.InputPosition.TextPosition + 1, bool_5: false)?.ScrollTo();
			}
		}

		private void method_13(bool bool_5)
		{
			if (base.m_txTextControl != null)
			{
				RibbonToggleButton ribbonToggleButton = this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_HighlightInvalidValues.ToString()] as RibbonToggleButton;
				RibbonButton ribbonButton = this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_NextInvalidValueFormField.ToString()] as RibbonButton;
				RibbonButton ribbonButton2 = this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_PreviousInvalidValueFormField.ToString()] as RibbonButton;
				RibbonButton ribbonButton3 = this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Dialog.ToString()] as RibbonButton;
				if (base.m_txTextControl.EditMode == EditMode.ReadAndSelect && base.m_txTextControl.DocumentPermissions.ReadOnly && base.m_txTextControl.IsFormFieldValidationEnabled)
				{
					this.method_46(ribbonToggleButton.Checked && bool_5);
				}
				bool enabled = (base.m_txTextControl.IsFormFieldValidationEnabled = bool_5);
				ribbonToggleButton.Enabled = enabled;
				bool enabled2 = (ribbonButton2.Enabled = base.m_txTextControl.EditMode == EditMode.ReadAndSelect && base.m_txTextControl.DocumentPermissions.ReadOnly && base.m_txTextControl.IsFormFieldValidationEnabled);
				ribbonButton.Enabled = enabled2;
				ribbonButton3.Enabled = !ribbonButton3.IsHandleCreated || base.m_txTextControl.IsFormFieldValidationEnabled;
				if (base.m_txTextControl.EditMode == EditMode.ReadAndSelect && base.m_txTextControl.DocumentPermissions.ReadOnly && base.m_txTextControl.IsFormFieldValidationEnabled)
				{
					this.method_46(ribbonToggleButton.Checked && bool_5);
				}
			}
		}

		private void method_14(bool bool_5)
		{
			if (base.m_txTextControl != null && base.m_txTextControl.IsFormFieldValidationEnabled && base.m_txTextControl.EditMode == EditMode.ReadAndSelect && base.m_txTextControl.DocumentPermissions.ReadOnly)
			{
				this.method_46(bool_5);
			}
		}

		private void method_15()
		{
			if (base.m_txTextControl != null)
			{
				this.method_41(base.m_txTextControl.InputPosition.TextPosition + 1, bool_5: true)?.ScrollTo();
			}
		}

		private void method_16()
		{
			if (base.m_txTextControl != null)
			{
				this.method_40(base.m_txTextControl.InputPosition.TextPosition + 1, bool_5: true)?.ScrollTo();
			}
		}

		private void method_17()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.ManageConditionalInstructionsDialog();
			}
		}

		private void method_18(RibbonSplitButton ribbonSplitButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonFormFieldsTab ribbonFormFieldsTab = this.class503_0.Control_0 as RibbonFormFieldsTab;
			if (ribbonFormFieldsTab == null)
			{
				return;
			}
			if (ribbonSplitButton_0.Checked)
			{
				bool @checked = (this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars_Vertical.ToString()] as RibbonToggleButton).Checked;
				bool checked2 = (this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars_Horizontal.ToString()] as RibbonToggleButton).Checked;
				bool flag = ribbonFormFieldsTab.ConditionalInstructionsSidebar != null && @checked;
				bool flag2 = ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar != null && checked2;
				if (ribbonFormFieldsTab.ConditionalInstructionsSidebar != null && (flag || (!ribbonFormFieldsTab.ConditionalInstructionsSidebar.IsShown && !flag2)))
				{
					if (ribbonFormFieldsTab.ConditionalInstructionsSidebar.ContentLayout != Sidebar.SidebarContentLayout.ConditionalInstructions)
					{
						if (ribbonFormFieldsTab.ConditionalInstructionsSidebar.IsShown && !ribbonFormFieldsTab.ConditionalInstructionsSidebar.IsPinned)
						{
							ribbonFormFieldsTab.ConditionalInstructionsSidebar.IsShown = false;
						}
						ribbonFormFieldsTab.ConditionalInstructionsSidebar.ContentLayout = Sidebar.SidebarContentLayout.ConditionalInstructions;
						this.bool_4 = false;
					}
					ribbonFormFieldsTab.ConditionalInstructionsSidebar.IsPinned = @checked;
					this.bool_4 = true;
					ribbonFormFieldsTab.ConditionalInstructionsSidebar.IsShown = true;
				}
				else if (ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar != null)
				{
					if (ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.ContentLayout != Sidebar.SidebarContentLayout.ConditionalInstructions)
					{
						if (ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.IsShown && !ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.IsPinned)
						{
							ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.IsShown = false;
						}
						ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.ContentLayout = Sidebar.SidebarContentLayout.ConditionalInstructions;
						this.bool_4 = false;
					}
					ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.IsPinned = checked2;
					this.bool_4 = true;
					ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.IsShown = true;
				}
				else
				{
					ribbonSplitButton_0.Checked = false;
				}
			}
			else
			{
				if (ribbonFormFieldsTab.ConditionalInstructionsSidebar != null && ribbonFormFieldsTab.ConditionalInstructionsSidebar.ContentLayout == Sidebar.SidebarContentLayout.ConditionalInstructions)
				{
					ribbonFormFieldsTab.ConditionalInstructionsSidebar.IsShown = false;
				}
				if (ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar != null && ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.ConditionalInstructions)
				{
					ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.IsShown = false;
				}
			}
		}

		private void method_19(Sidebar sidebar_0, string string_1)
		{
			if (!this.bool_3)
			{
				return;
			}
			switch (string_1)
			{
			case "ContentLayout":
			{
				if (sidebar_0.ContentLayout == Sidebar.SidebarContentLayout.ConditionalInstructions)
				{
					break;
				}
				if (!sidebar_0.IsPinned && sidebar_0.SidebarContentLayout_0 == Sidebar.SidebarContentLayout.ConditionalInstructions)
				{
					this.point_0 = sidebar_0.DialogLocation;
					this.size_0 = sidebar_0.DialogSize;
				}
				RibbonSplitButton ribbonSplitButton = this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions.ToString()] as RibbonSplitButton;
				RibbonFormFieldsTab ribbonFormFieldsTab2 = this.class503_0.Control_0 as RibbonFormFieldsTab;
				if (ribbonSplitButton != null && ribbonSplitButton.Name == RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars.ToString())
				{
					if (sidebar_0 == ribbonFormFieldsTab2.ConditionalInstructionsSidebar)
					{
						bool flag = ribbonFormFieldsTab2.ConditionalInstructionsHorizontalSidebar != null && ribbonFormFieldsTab2.ConditionalInstructionsHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.ConditionalInstructions;
						ribbonSplitButton.Checked = flag && ribbonFormFieldsTab2.ConditionalInstructionsHorizontalSidebar.IsShown;
					}
					else if (sidebar_0 == ribbonFormFieldsTab2.ConditionalInstructionsHorizontalSidebar)
					{
						bool flag2 = ribbonFormFieldsTab2.ConditionalInstructionsSidebar != null && ribbonFormFieldsTab2.ConditionalInstructionsSidebar.ContentLayout == Sidebar.SidebarContentLayout.ConditionalInstructions;
						ribbonSplitButton.Checked = flag2 && ribbonFormFieldsTab2.ConditionalInstructionsSidebar.IsShown;
					}
				}
				break;
			}
			case "IsShown":
			case "IsPinned":
			{
				if (sidebar_0.ContentLayout != Sidebar.SidebarContentLayout.ConditionalInstructions)
				{
					break;
				}
				RibbonButton ribbonButton = this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions.ToString()] as RibbonButton;
				RibbonFormFieldsTab ribbonFormFieldsTab = this.class503_0.Control_0 as RibbonFormFieldsTab;
				switch (string_1)
				{
				case "IsPinned":
					Class517.smethod_38(new Sidebar[3] { sidebar_0, ribbonFormFieldsTab.ConditionalInstructionsSidebar, ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar }, RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars.ToString(), new object[3]
					{
						ribbonButton,
						this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars_Vertical.ToString()],
						this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars_Horizontal.ToString()]
					});
					break;
				case "IsShown":
				{
					if (!(ribbonButton.Name == RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars.ToString()))
					{
						break;
					}
					RibbonToggleButton ribbonToggleButton = this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars_Vertical.ToString()] as RibbonToggleButton;
					RibbonToggleButton ribbonToggleButton2 = this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars_Horizontal.ToString()] as RibbonToggleButton;
					if (sidebar_0 == ribbonFormFieldsTab.ConditionalInstructionsSidebar)
					{
						if (sidebar_0.IsShown)
						{
							ribbonToggleButton.Checked = sidebar_0.IsPinned;
						}
						if (ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar != null && ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.ConditionalInstructions)
						{
							this.bool_3 = false;
							ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.IsShown = false;
							this.bool_3 = true;
						}
					}
					else if (sidebar_0 == ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar)
					{
						if (sidebar_0.IsShown)
						{
							ribbonToggleButton2.Checked = sidebar_0.IsPinned;
						}
						if (ribbonFormFieldsTab.ConditionalInstructionsSidebar != null && ribbonFormFieldsTab.ConditionalInstructionsSidebar.ContentLayout == Sidebar.SidebarContentLayout.ConditionalInstructions)
						{
							this.bool_3 = false;
							ribbonFormFieldsTab.ConditionalInstructionsSidebar.IsShown = false;
							this.bool_3 = true;
						}
					}
					(ribbonButton as RibbonSplitButton).Checked = sidebar_0.IsShown;
					break;
				}
				}
				break;
			}
			}
		}

		private void method_20(Sidebar sidebar_0)
		{
			Sidebar.SidebarContentLayout contentLayout = sidebar_0.ContentLayout;
			if (contentLayout == Sidebar.SidebarContentLayout.ConditionalInstructions)
			{
				Class517.smethod_39(sidebar_0, this.point_0, this.size_0, bool_0: true);
			}
		}

		private void method_21(Sidebar sidebar_0)
		{
			if (sidebar_0.ContentLayout == Sidebar.SidebarContentLayout.ConditionalInstructions && this.bool_4)
			{
				this.point_0 = sidebar_0.DialogLocation;
				this.size_0 = sidebar_0.DialogSize;
			}
		}

		private void method_22(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonFormFieldsTab ribbonFormFieldsTab = this.class503_0.Control_0 as RibbonFormFieldsTab;
			if (ribbonToggleButton_0 == null)
			{
				return;
			}
			switch (ribbonToggleButton_0.Name)
			{
			case "TXITEM_ManageConditionalInstructions_Sidebars_Horizontal":
				if (ribbonToggleButton_0.Checked)
				{
					(this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars_Vertical.ToString()] as RibbonToggleButton).Checked = false;
					if (ribbonFormFieldsTab.ConditionalInstructionsSidebar != null && ribbonFormFieldsTab.ConditionalInstructionsSidebar.ContentLayout == Sidebar.SidebarContentLayout.ConditionalInstructions)
					{
						this.bool_3 = false;
						ribbonFormFieldsTab.ConditionalInstructionsSidebar.IsShown = false;
						this.bool_3 = true;
					}
					if (ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.ContentLayout != Sidebar.SidebarContentLayout.ConditionalInstructions)
					{
						ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.ContentLayout = Sidebar.SidebarContentLayout.ConditionalInstructions;
						this.bool_4 = false;
					}
					this.bool_3 = false;
					ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.IsPinned = true;
					this.bool_4 = true;
					this.bool_3 = true;
					ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.IsShown = true;
					(this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars.ToString()] as RibbonSplitButton).Checked = true;
				}
				else
				{
					ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.IsShown = false;
				}
				break;
			case "TXITEM_ManageConditionalInstructions_Sidebars_Vertical":
				if (ribbonToggleButton_0.Checked)
				{
					(this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars_Horizontal.ToString()] as RibbonToggleButton).Checked = false;
					if (ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar != null && ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.ConditionalInstructions)
					{
						this.bool_3 = false;
						ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.IsShown = false;
						this.bool_3 = true;
					}
					if (ribbonFormFieldsTab.ConditionalInstructionsSidebar.ContentLayout != Sidebar.SidebarContentLayout.ConditionalInstructions)
					{
						ribbonFormFieldsTab.ConditionalInstructionsSidebar.ContentLayout = Sidebar.SidebarContentLayout.ConditionalInstructions;
						this.bool_4 = false;
					}
					this.bool_3 = false;
					ribbonFormFieldsTab.ConditionalInstructionsSidebar.IsPinned = true;
					this.bool_4 = true;
					this.bool_3 = true;
					ribbonFormFieldsTab.ConditionalInstructionsSidebar.IsShown = true;
					(this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars.ToString()] as RibbonSplitButton).Checked = true;
				}
				else
				{
					ribbonFormFieldsTab.ConditionalInstructionsSidebar.IsShown = false;
				}
				break;
			}
		}

		private void method_23(RibbonTextBox ribbonTextBox_1)
		{
			this.ribbonTextBox_0 = ribbonTextBox_1;
			if (base.m_txTextControl == null)
			{
				return;
			}
			FormField item = base.m_txTextControl.FormFields.GetItem();
			if (item != null)
			{
				item.Name = this.ribbonTextBox_0.Text;
				if (base.m_txTextControl.IsFormFieldValidationEnabled)
				{
					base.m_txTextControl.Class456_0.method_1(item);
				}
				this.ribbonTextBox_0 = null;
			}
		}

		private void method_24(RibbonTextBox ribbonTextBox_1)
		{
			this.ribbonTextBox_0 = ribbonTextBox_1;
			if (base.m_txTextControl == null)
			{
				return;
			}
			FormField item = base.m_txTextControl.FormFields.GetItem();
			if (item != null)
			{
				if (ribbonTextBox_1.Text != null && ribbonTextBox_1.Text.Length > 0)
				{
					item.Int32_0 = int.Parse(ribbonTextBox_1.Text);
				}
				else
				{
					ribbonTextBox_1.Text = item.Int32_0.ToString();
				}
				this.ribbonTextBox_0 = null;
			}
		}

		private void method_25(RibbonMenuButton ribbonMenuButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			CheckFormField checkFormField = base.m_txTextControl.FormFields.GetItem() as CheckFormField;
			if (checkFormField != null)
			{
				RibbonListView ribbonListView_ = ribbonMenuButton_0.DropDownItems[2] as RibbonListView;
				if (ribbonMenuButton_0.Name.StartsWith("TXITEM_Unc"))
				{
					this.method_43(ribbonListView_, checkFormField.UncheckedCharacter);
				}
				else
				{
					this.method_43(ribbonListView_, checkFormField.CheckedCharacter);
				}
			}
		}

		private void method_26(RibbonListView ribbonListView_0, char char_0)
		{
			if (ribbonListView_0 == null || !this.class503_0.TXITEM_CheckBoxFieldPropertiesGroup_Items.TryGetValue(ribbonListView_0.Name.Substring(0, ribbonListView_0.Name.Length - 12), out var value))
			{
				return;
			}
			RibbonMenuButton ribbonMenuButton = value as RibbonMenuButton;
			Font font_ = ((base.m_txTextControl != null) ? new Font(base.m_txTextControl.InputFormat.FontFamily, 12f) : new Font(this.string_0, 12f));
			ribbonMenuButton.SmallIcon = this.method_38(char_0, new Size(16, 16), base.m_pntDPI, font_);
			if (base.m_txTextControl == null)
			{
				return;
			}
			CheckFormField checkFormField = base.m_txTextControl.FormFields.GetItem() as CheckFormField;
			if (checkFormField != null)
			{
				if (ribbonListView_0.Name.StartsWith("TXITEM_Unc"))
				{
					checkFormField.UncheckedCharacter = char_0;
				}
				else
				{
					checkFormField.CheckedCharacter = char_0;
				}
			}
		}

		private void method_27()
		{
			if (this.class503_0.Boolean_0)
			{
				FormField formField_ = ((base.m_txTextControl.EditMode != EditMode.ReadAndSelect || !base.m_txTextControl.DocumentPermissions.ReadOnly) ? base.m_txTextControl.FormFields.GetItem() : null);
				this.method_34(formField_);
			}
			if (base.m_txTextControl.IsFormFieldValidationEnabled)
			{
				this.method_46((this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_HighlightInvalidValues.ToString()] as RibbonToggleButton).Checked);
			}
		}

		private void method_28(TextFieldEventArgs textFieldEventArgs_0)
		{
			if (this.class503_0.Boolean_0)
			{
				FormField formField_ = ((base.m_txTextControl.EditMode != EditMode.ReadAndSelect || !base.m_txTextControl.DocumentPermissions.ReadOnly) ? (textFieldEventArgs_0.TextField as FormField) : null);
				this.method_34(formField_);
			}
		}

		private void method_29()
		{
			if (this.class503_0.Boolean_0)
			{
				this.method_34(null);
			}
		}

		private void method_30()
		{
			if (this.class503_0.Boolean_0)
			{
				FormField formField_ = ((base.m_txTextControl.EditMode != EditMode.ReadAndSelect || !base.m_txTextControl.DocumentPermissions.ReadOnly) ? base.m_txTextControl.FormFields.GetItem() : null);
				this.method_34(formField_);
			}
		}

		private void method_31()
		{
			RibbonGroup ribbonGroup = null;
			if (this.bool_0 && this.class503_0.method_0(ribbonGroup = this.class503_0.TXITEM_CheckBoxFieldPropertiesGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_CheckBoxFieldPropertiesGroup.ToString()] as RibbonGroup))
			{
				CheckFormField checkFormField = base.m_txTextControl.FormFields.GetItem() as CheckFormField;
				if (checkFormField != null)
				{
					this.method_37(checkFormField, ribbonGroup);
				}
			}
		}

		private void method_32(FormField formField_0)
		{
			ConditionalInstruction[] items = base.m_txTextControl.FormFields.ConditionalInstructions.GetItems(formField_0);
			if (items == null)
			{
				return;
			}
			List<FormField> list = new List<FormField>();
			ConditionalInstruction[] array = items;
			foreach (ConditionalInstruction conditionalInstruction in array)
			{
				Instruction[] instructions = conditionalInstruction.Instructions;
				foreach (Instruction instruction in instructions)
				{
					if (instruction.InstructionType == Instruction.InstructionTypes.IsValueValid && !list.Contains(instruction.FormField))
					{
						list.Add(instruction.FormField);
					}
				}
			}
			foreach (FormField item in list)
			{
				if (base.m_txTextControl.FormFields.ConditionalInstructions.HasValidValue(item))
				{
					item.HighlightColor = Color.FromArgb(60, 0, 0, 0);
					item.HighlightMode = HighlightMode.Never;
				}
				else
				{
					item.HighlightColor = Color.FromArgb(60, Color.Yellow);
					item.HighlightMode = HighlightMode.Always;
				}
			}
		}

		internal void method_33()
		{
			if (base.m_txTextControl.IsFormFieldValidationEnabled)
			{
				this.method_46((this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_HighlightInvalidValues.ToString()] as RibbonToggleButton).Checked);
			}
		}

		internal override void UpdateRibbonTab(params object[] args)
		{
			this.method_34(base.m_txTextControl.FormFields.GetItem());
		}

		private void method_34(FormField formField_0)
		{
			this.bool_0 = formField_0 is CheckFormField;
			RibbonGroup ribbonGroup_ = this.class503_0.TXITEM_CheckBoxFieldPropertiesGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_CheckBoxFieldPropertiesGroup.ToString()] as RibbonGroup;
			if (this.class503_0.method_0(ribbonGroup_))
			{
				this.method_37(formField_0 as CheckFormField, ribbonGroup_);
			}
			this.class503_0.class494_0.method_17(formField_0 as TextFormField);
			SelectionFormField selectionFormField_ = ((!(formField_0 is SelectionFormField) || !(formField_0 as SelectionFormField).Editable) ? null : (formField_0 as SelectionFormField));
			this.class503_0.class494_1.method_18(selectionFormField_, -1, null);
			SelectionFormField selectionFormField_2 = ((!(formField_0 is SelectionFormField) || (formField_0 as SelectionFormField).Editable) ? null : (formField_0 as SelectionFormField));
			this.class503_0.class494_2.method_18(selectionFormField_2, -1, null);
			this.class503_0.class494_3.method_19(formField_0 as DateFormField);
			this.method_35(formField_0);
			this.method_36(formField_0);
		}

		private void method_35(FormField formField_0)
		{
			RibbonGroup ribbonGroup_ = this.class503_0.TXITEM_EditFormFieldsGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_EditFormFieldsGroup.ToString()] as RibbonGroup;
			if (this.class503_0.method_0(ribbonGroup_))
			{
				RibbonButton ribbonButton = this.class503_0.TXITEM_EditFormFieldsGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DeleteFormField.ToString()] as RibbonButton;
				if (this.class503_0.method_2(ribbonButton))
				{
					ribbonButton.Enabled = base.m_txTextControl == null || (formField_0 != null && base.m_txTextControl.CanEdit);
				}
			}
		}

		private void method_36(FormField formField_0)
		{
			RibbonGroup ribbonGroup = this.class503_0.TXITEM_FormFieldPropertiesGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_FormFieldPropertiesGroup.ToString()] as RibbonGroup;
			if (this.class503_0.method_0(ribbonGroup) && (ribbonGroup.Visible = formField_0 != null && (base.m_txTextControl.EditMode != EditMode.ReadAndSelect || !base.m_txTextControl.DocumentPermissions.ReadOnly)))
			{
				RibbonTextBox ribbonTextBox = this.class503_0.TXITEM_FormFieldPropertiesGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_FormFieldName.ToString()] as RibbonTextBox;
				ribbonTextBox.Text = formField_0.Name;
				RibbonTextBox ribbonTextBox2 = this.class503_0.TXITEM_FormFieldPropertiesGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_FormFieldID.ToString()] as RibbonTextBox;
				ribbonTextBox2.Text = formField_0.Int32_0.ToString();
			}
		}

		private void method_37(CheckFormField checkFormField_0, RibbonGroup ribbonGroup_0)
		{
			if (checkFormField_0 != null && (base.m_txTextControl.EditMode != EditMode.ReadAndSelect || !base.m_txTextControl.DocumentPermissions.ReadOnly))
			{
				ribbonGroup_0.Visible = true;
				Font font_ = ((base.m_txTextControl == null || base.m_txTextControl.InputFormat.FontFamily == null) ? new Font(this.string_0, 12f) : new Font(base.m_txTextControl.InputFormat.FontFamily, 12f));
				RibbonMenuButton ribbonMenuButton = this.class503_0.TXITEM_CheckBoxFieldPropertiesGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_CheckedSymbol.ToString()] as RibbonMenuButton;
				if (this.class503_0.method_2(ribbonMenuButton))
				{
					ribbonMenuButton.SmallIcon = this.method_38(checkFormField_0.CheckedCharacter, new Size(16, 16), base.m_pntDPI, font_);
					this.method_44(this.class503_0.TXITEM_CheckBoxFieldPropertiesGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_CheckedSymbolList_Gallery.ToString()] as RibbonListView, checkFormField_0.SupportedCheckedCharacters, base.m_pntDPI);
				}
				RibbonMenuButton ribbonMenuButton2 = this.class503_0.TXITEM_CheckBoxFieldPropertiesGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_UncheckedSymbol.ToString()] as RibbonMenuButton;
				if (this.class503_0.method_2(ribbonMenuButton2))
				{
					ribbonMenuButton2.SmallIcon = this.method_38(checkFormField_0.UncheckedCharacter, new Size(16, 16), base.m_pntDPI, font_);
					this.method_44(this.class503_0.TXITEM_CheckBoxFieldPropertiesGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_UncheckedSymbolList_Gallery.ToString()] as RibbonListView, checkFormField_0.SupportedUncheckedCharacters, base.m_pntDPI);
				}
			}
			else
			{
				ribbonGroup_0.Visible = false;
			}
		}

		private Bitmap method_38(char char_0, Size size_2, PointF pointF_0, Font font_0)
		{
			if (!pointF_0.IsEmpty)
			{
				float num = pointF_0.X / 96f;
				float num2 = pointF_0.Y / 96f;
				Bitmap bitmap = new Bitmap((int)((float)size_2.Width * num), (int)((float)size_2.Height * num2), PixelFormat.Format32bppArgb);
				using Graphics dc = Graphics.FromImage(bitmap);
				Size size = TextRenderer.MeasureText(dc, char_0.ToString(), font_0, bitmap.Size, TextFormatFlags.HorizontalCenter | TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
				float num3 = Math.Max(size.Width, size.Height);
				float num4 = ((num3 > (float)bitmap.Width) ? ((float)bitmap.Width / num3) : 1f);
				TextRenderer.DrawText(dc, char_0.ToString(), new Font(font_0.FontFamily, font_0.Size * num4), new Rectangle(0, 0, bitmap.Width, bitmap.Height), Color.Black, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
				return bitmap;
			}
			return null;
		}

		private RibbonButton method_39(bool bool_5, bool bool_6, RibbonButton ribbonButton_0, bool bool_7, bool bool_8, bool bool_9, bool bool_10, bool bool_11, bool bool_12)
		{
			RibbonButton ribbonButton = this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars.ToString()] as RibbonSplitButton;
			(ribbonButton as RibbonSplitButton).Checked = (bool_5 && bool_9) || (bool_6 && bool_10);
			RibbonToggleButton ribbonToggleButton = this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars_Vertical.ToString()] as RibbonToggleButton;
			if (ribbonToggleButton.Visible = bool_7)
			{
				ribbonToggleButton.Checked = (bool_11 && bool_5) || !bool_12 || !bool_6;
			}
			RibbonToggleButton ribbonToggleButton2 = this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Sidebars_Horizontal.ToString()] as RibbonToggleButton;
			if (ribbonToggleButton2.Visible = bool_8)
			{
				ribbonToggleButton2.Checked = bool_12 && bool_6 && (!bool_11 || !bool_5);
			}
			if (ribbonButton_0 == ribbonButton)
			{
				return null;
			}
			return ribbonButton;
		}

		private FormField method_40(int int_2, bool bool_5)
		{
			if (base.m_txTextControl.FormFields.Count > 0)
			{
				ConditionalInstructionCollection conditionalInstructionCollection = (bool_5 ? base.m_txTextControl.FormFields.ConditionalInstructions : null);
				FormField formField = null;
				{
					foreach (FormField formField2 in base.m_txTextControl.FormFields)
					{
						if (formField == null)
						{
							formField = ((!bool_5 || !conditionalInstructionCollection.HasValidValue(formField2)) ? formField2 : null);
						}
						if (formField2.Start > int_2 && (!bool_5 || !conditionalInstructionCollection.HasValidValue(formField2)))
						{
							return formField2;
						}
					}
					return formField;
				}
			}
			return null;
		}

		private FormField method_41(int int_2, bool bool_5)
		{
			if (base.m_txTextControl.FormFields.Count > 0)
			{
				ConditionalInstructionCollection conditionalInstructionCollection = (bool_5 ? base.m_txTextControl.FormFields.ConditionalInstructions : null);
				FormField formField = null;
				int num = base.m_txTextControl.FormFields.Count;
				FormField formField2;
				while (true)
				{
					if (num > 0)
					{
						formField2 = base.m_txTextControl.FormFields[num];
						if (formField == null)
						{
							formField = ((!bool_5 || !conditionalInstructionCollection.HasValidValue(formField2)) ? formField2 : null);
						}
						if (formField2.Start < int_2 && (!bool_5 || !conditionalInstructionCollection.HasValidValue(formField2)))
						{
							break;
						}
						num--;
						continue;
					}
					return formField;
				}
				return formField2;
			}
			return null;
		}

		internal int method_42()
		{
			int num = 114;
			Table item = base.m_txTextControl.Tables.GetItem();
			if (item != null)
			{
				TableCell item2 = item.Cells.GetItem();
				if (item2 != null)
				{
					return item2.Width - num;
				}
			}
			else
			{
				TextFrame textFrame = base.m_txTextControl.TextParts.GetItem() as TextFrame;
				if (textFrame != null)
				{
					return Math.Min(2000, textFrame.Size.Width - num);
				}
			}
			return 0;
		}

		private void method_43(RibbonListView ribbonListView_0, char char_0)
		{
			foreach (RibbonListView.RibbonListViewItem ribbonListViewItem in ribbonListView_0.RibbonListViewItems)
			{
				if (char_0 == (char)ribbonListViewItem.Tag)
				{
					ribbonListView_0.SelectedItems = new RibbonListView.RibbonListViewItem[1] { ribbonListViewItem };
					break;
				}
			}
		}

		private void method_44(RibbonListView ribbonListView_0, char[] char_0, PointF pointF_0)
		{
			if (char_0 != null)
			{
				ribbonListView_0.RibbonListViewItems.Clear();
				foreach (char c in char_0)
				{
					ribbonListView_0.RibbonListViewItems.Add(new RibbonListView.RibbonListViewItem
					{
						Icon = this.method_38(c, new Size(24, 24), pointF_0, new Font((base.m_txTextControl == null || !base.m_txTextControl.IsHandleCreated) ? this.string_0 : base.m_txTextControl.InputFormat.FontFamily, 12f)),
						Tag = c
					});
				}
			}
		}

		internal void method_45(Sidebar sidebar_0)
		{
			if (sidebar_0 != null)
			{
				sidebar_0.PropertyChanged -= method_48;
			}
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonFormFieldsTab ribbonFormFieldsTab = this.class503_0.Control_0 as RibbonFormFieldsTab;
			if (ribbonFormFieldsTab == null)
			{
				return;
			}
			RibbonButton ribbonButton = this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions.ToString()] as RibbonButton;
			RibbonButton ribbonButton2;
			if (ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar == null && ribbonFormFieldsTab.ConditionalInstructionsSidebar == null)
			{
				if (!(ribbonButton is RibbonSplitButton) && !(ribbonButton is RibbonToggleButton))
				{
					return;
				}
				ribbonButton2 = this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Dialog.ToString()] as RibbonButton;
			}
			else
			{
				bool bool_ = false;
				bool bool_2 = false;
				bool bool_3 = false;
				bool bool_4 = false;
				bool bool_5 = false;
				bool bool_6 = false;
				bool bool_7;
				if (bool_7 = ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar != null)
				{
					bool_6 = ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.ConditionalInstructions;
					this.point_1 = ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.DialogLocation;
					this.size_1 = ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.DialogSize;
					bool_ = ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.IsShown;
					bool_3 = ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.IsPinned;
					ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.PropertyChanged -= method_48;
					ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.PropertyChanged += method_48;
					ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.DialogOpening -= method_49;
					ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.DialogOpening += method_49;
					ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.DialogClosed -= method_50;
					ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar.DialogClosed += method_50;
				}
				bool bool_8;
				if (bool_8 = ribbonFormFieldsTab.ConditionalInstructionsSidebar != null)
				{
					bool_5 = ribbonFormFieldsTab.ConditionalInstructionsSidebar.ContentLayout == Sidebar.SidebarContentLayout.ConditionalInstructions;
					this.point_1 = ribbonFormFieldsTab.ConditionalInstructionsSidebar.DialogLocation;
					this.size_1 = ribbonFormFieldsTab.ConditionalInstructionsSidebar.DialogSize;
					bool_2 = ribbonFormFieldsTab.ConditionalInstructionsSidebar.IsShown;
					bool_4 = ribbonFormFieldsTab.ConditionalInstructionsSidebar.IsPinned;
					ribbonFormFieldsTab.ConditionalInstructionsSidebar.PropertyChanged -= method_48;
					ribbonFormFieldsTab.ConditionalInstructionsSidebar.PropertyChanged += method_48;
					ribbonFormFieldsTab.ConditionalInstructionsSidebar.DialogOpening -= method_49;
					ribbonFormFieldsTab.ConditionalInstructionsSidebar.DialogOpening += method_49;
					ribbonFormFieldsTab.ConditionalInstructionsSidebar.DialogClosed -= method_50;
					ribbonFormFieldsTab.ConditionalInstructionsSidebar.DialogClosed += method_50;
				}
				ribbonButton2 = this.method_39(bool_5, bool_6, ribbonButton, bool_8, bool_7, bool_2, bool_, bool_4, bool_3);
			}
			if (ribbonButton2 != null)
			{
				Class517.smethod_37(RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions.ToString(), ribbonButton, this.class503_0.TXITEM_FormValidationGroup_Items, ribbonButton2);
			}
		}

		internal void method_46(bool bool_5)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			ConditionalInstructionCollection conditionalInstructions = base.m_txTextControl.FormFields.ConditionalInstructions;
			List<FormField> list = new List<FormField>();
			foreach (ConditionalInstruction item in conditionalInstructions)
			{
				Instruction[] instructions = item.Instructions;
				foreach (Instruction instruction in instructions)
				{
					if (instruction.InstructionType == Instruction.InstructionTypes.IsValueValid && !list.Contains(instruction.FormField))
					{
						list.Add(instruction.FormField);
					}
				}
			}
			bool flag = base.m_txTextControl.EditMode == EditMode.ReadAndSelect && base.m_txTextControl.DocumentPermissions.ReadOnly && bool_5;
			foreach (FormField item2 in list)
			{
				if (flag)
				{
					if (conditionalInstructions.HasValidValue(item2))
					{
						item2.HighlightColor = Color.FromArgb(60, 0, 0, 0);
						item2.HighlightMode = HighlightMode.Never;
					}
					else
					{
						item2.HighlightColor = Color.FromArgb(60, Color.Yellow);
						item2.HighlightMode = HighlightMode.Always;
					}
				}
				else
				{
					item2.HighlightColor = Color.FromArgb(60, 0, 0, 0);
					item2.HighlightMode = HighlightMode.Never;
				}
			}
			base.m_txTextControl.FormFieldTextChanged -= method_61;
			base.m_txTextControl.FormFieldCheckChanged -= method_62;
			base.m_txTextControl.FormFieldSelectionChanged -= method_63;
			base.m_txTextControl.FormFieldDateChanged -= method_64;
			if (flag)
			{
				base.m_txTextControl.FormFieldTextChanged += method_61;
				base.m_txTextControl.FormFieldCheckChanged += method_62;
				base.m_txTextControl.FormFieldSelectionChanged += method_63;
				base.m_txTextControl.FormFieldDateChanged += method_64;
			}
		}

		internal void method_47()
		{
			(this.class503_0.TXITEM_EditFormFieldsGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DeleteFormField.ToString()] as RibbonButton).Enabled = base.m_txTextControl == null || (base.m_txTextControl.CanEdit && base.m_txTextControl.IsFormFieldValidationEnabled && base.m_txTextControl.FormFields.GetItem() != null);
			RibbonButton obj = this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_NextInvalidValueFormField.ToString()] as RibbonButton;
			bool enabled = ((this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_PreviousInvalidValueFormField.ToString()] as RibbonButton).Enabled = base.m_txTextControl == null || (base.m_txTextControl.EditMode == EditMode.ReadAndSelect && base.m_txTextControl.DocumentPermissions.ReadOnly && base.m_txTextControl.IsFormFieldValidationEnabled));
			obj.Enabled = enabled;
			RibbonButton ribbonButton = this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_ManageConditionalInstructions_Dialog.ToString()] as RibbonButton;
			RibbonFormFieldsTab ribbonFormFieldsTab = this.class503_0.Control_0 as RibbonFormFieldsTab;
			ribbonButton.Enabled = (base.m_txTextControl != null && base.m_txTextControl.IsFormFieldValidationEnabled) || ribbonFormFieldsTab.ConditionalInstructionsHorizontalSidebar != null || ribbonFormFieldsTab.ConditionalInstructionsSidebar != null;
			if (base.m_txTextControl != null && base.m_txTextControl.IsFormFieldValidationEnabled)
			{
				this.method_46((this.class503_0.TXITEM_FormValidationGroup_Items[RibbonFormFieldsTab.InternalRibbonItem.TXITEM_HighlightInvalidValues.ToString()] as RibbonToggleButton).Checked);
			}
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertTextFormField_Handler(object sender, EventArgs e)
		{
			this.method_3();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertCheckBoxField_Handler(object sender, EventArgs e)
		{
			this.method_4();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertComboBoxField_Handler(object sender, EventArgs e)
		{
			this.method_5();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertDropDownListField_Handler(object sender, EventArgs e)
		{
			this.method_6();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertDateFormField_Handler(object sender, EventArgs e)
		{
			this.method_7();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DeleteFormField_Handler(object sender, EventArgs e)
		{
			this.method_8();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_RemoveFormFieldsContent_Handler(object sender, EventArgs e)
		{
			this.method_9();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_HighlightFormFields_Handler(object sender, EventArgs e)
		{
			this.method_10((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_PreviousFormField_Handler(object sender, EventArgs e)
		{
			this.method_11();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_NextFormField_Handler(object sender, EventArgs e)
		{
			this.method_12();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_EnableFormValidation_Handler(object sender, EventArgs e)
		{
			this.method_13((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_HighlightInvalidValues_Handler(object sender, EventArgs e)
		{
			this.method_14((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_PreviousInvalidValueFormField_Handler(object sender, EventArgs e)
		{
			this.method_15();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_NextInvalidValueFormField_Handler(object sender, EventArgs e)
		{
			this.method_16();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ManageConditionalInstructions_Handler(object sender, EventArgs e)
		{
			this.method_17();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ManageConditionalInstructions_Sidebars_Handler(object sender, EventArgs e)
		{
			this.method_18(sender as RibbonSplitButton);
		}

		private void method_48(object sender, PropertyChangedEventArgs e)
		{
			this.method_19(sender as Sidebar, e.PropertyName);
		}

		private void method_49(object sender, EventArgs e)
		{
			this.method_20(sender as Sidebar);
		}

		private void method_50(object sender, EventArgs e)
		{
			this.method_21(sender as Sidebar);
		}

		private void method_51(object sender, EventArgs e)
		{
			this.method_22(sender as RibbonToggleButton);
		}

		private void method_52(object sender, EventArgs e)
		{
			this.method_23(sender as RibbonTextBox);
		}

		private void method_53(object sender, EventArgs e)
		{
			this.method_24(sender as RibbonTextBox);
		}

		private void method_54(object sender, EventArgs e)
		{
			this.method_25(sender as RibbonMenuButton);
		}

		private void method_55(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			this.method_26(sender as RibbonListView, (char)e.Item.Tag);
		}

		internal void method_56(object sender, EventArgs e)
		{
			this.method_27();
		}

		internal void method_57(object sender, TextFieldEventArgs e)
		{
			this.method_28(e);
		}

		internal void method_58(object sender, EventArgs e)
		{
			this.method_29();
		}

		internal void method_59(object sender, EventArgs e)
		{
			this.method_30();
		}

		internal void method_60(object sender, EventArgs e)
		{
			this.method_31();
		}

		private void method_61(object sender, TextFormFieldEventArgs e)
		{
			this.method_32(e.TextFormField);
		}

		private void method_62(object sender, CheckFormFieldEventArgs e)
		{
			this.method_32(e.CheckFormField);
		}

		private void method_63(object sender, SelectionFormFieldEventArgs e)
		{
			this.method_32(e.SelectionFormField);
		}

		private void method_64(object sender, DateFormFieldEventArgs e)
		{
			this.method_32(e.DateFormField);
		}
	}
}
