using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using ns21;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonFormFieldsTab class represents a Windows Forms ribbon tab for inserting and editing form fields.</summary>
	[ToolboxBitmap(typeof(RibbonFormFieldsTab))]
	public class RibbonFormFieldsTab : RibbonTab
	{
		/// <summary>Each RibbonItem represents an item in the RibbonFormFieldsTab that is not a drop-down item.</summary>
		public enum RibbonItem
		{
			/// <summary>Identifies the TXITEM_InsertFormFieldsGroup ribbon group inside the RibbonFormFieldsTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_InsertFormFieldsGroup,
			/// <summary>Identifies the TXITEM_InsertTextFormField ribbon item inside the TXITEM_InsertFormFieldsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertTextFormField,
			/// <summary>Identifies the TXITEM_InsertCheckBoxField ribbon item inside the TXITEM_InsertFormFieldsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertCheckBoxField,
			/// <summary>Identifies the TXITEM_InsertComboBoxField ribbon item inside the TXITEM_InsertFormFieldsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertComboBoxField,
			/// <summary>Identifies the TXITEM_InsertDropDownListField ribbon item inside the TXITEM_InsertFormFieldsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertDropDownListField,
			/// <summary>Identifies the TXITEM_InsertDateFormField ribbon item inside the TXITEM_InsertFormFieldsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertDateFormField,
			/// <summary>Identifies the TXITEM_EditFormFieldsGroup ribbon group inside the RibbonFormFieldsTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_EditFormFieldsGroup,
			/// <summary>Identifies the TXITEM_DeleteFormField ribbon item inside the TXITEM_EditFormFieldsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DeleteFormField,
			/// <summary>Identifies the TXITEM_RemoveFormFieldsContent ribbon item inside the TXITEM_EditFormFieldsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_RemoveFormFieldsContent,
			/// <summary>Identifies the TXITEM_HighlightFormFields ribbon item inside the TXITEM_EditFormFieldsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_HighlightFormFields,
			/// <summary>Identifies the TXITEM_PreviousFormField ribbon item inside the TXITEM_EditFormFieldsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_PreviousFormField,
			/// <summary>Identifies the TXITEM_NextFormField ribbon item inside the TXITEM_EditFormFieldsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_NextFormField,
			/// <summary>Identifies the TXITEM_FormValidationGroup ribbon group inside the RibbonFormFieldsTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_FormValidationGroup,
			/// <summary>Identifies the TXITEM_EnableFormValidation ribbon item inside the TXITEM_FormValidationGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_EnableFormValidation,
			/// <summary>Identifies the TXITEM_HighlightInvalidValues ribbon item inside the TXITEM_FormValidationGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_HighlightInvalidValues,
			/// <summary>Identifies the TXITEM_NextInvalidValueFormField ribbon item inside the TXITEM_FormValidationGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_NextInvalidValueFormField,
			/// <summary>Identifies the TXITEM_PreviousInvalidValueFormField ribbon item inside the TXITEM_FormValidationGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_PreviousInvalidValueFormField,
			/// <summary>Identifies the TXITEM_ManageConditionalInstructions ribbon item inside the TXITEM_FormValidationGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ManageConditionalInstructions,
			/// <summary>Identifies the TXITEM_ManageConditionalInstructions_Sidebars ribbon item inside the TXITEM_FormValidationGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ManageConditionalInstructions_Sidebars,
			/// <summary>Identifies the TXITEM_FormFieldPropertiesGroup ribbon group inside the RibbonFormFieldsTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_FormFieldPropertiesGroup,
			/// <summary>Identifies the TXITEM_FormFieldName ribbon item inside the TXITEM_FormFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_FormFieldName,
			/// <summary>Identifies the TXITEM_FormFieldID ribbon item inside the TXITEM_FormFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_FormFieldID,
			/// <summary>Identifies the TXITEM_CheckBoxFieldPropertiesGroup ribbon group inside the RibbonFormFieldsTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_CheckBoxFieldPropertiesGroup,
			/// <summary>Identifies the TXITEM_CheckedSymbolLabel ribbon item inside the TXITEM_CheckBoxFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_CheckedSymbolLabel,
			/// <summary>Identifies the TXITEM_UncheckedSymbolLabel ribbon item inside the TXITEM_CheckBoxFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_UncheckedSymbolLabel,
			/// <summary>Identifies the TXITEM_CheckedSymbol ribbon item inside the TXITEM_CheckBoxFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_CheckedSymbol,
			/// <summary>Identifies the TXITEM_UncheckedSymbol ribbon item inside the TXITEM_CheckBoxFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_UncheckedSymbol,
			/// <summary>Identifies the TXITEM_TextFormFieldPropertiesGroup ribbon group inside the RibbonFormFieldsTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_TextFormFieldPropertiesGroup,
			/// <summary>Identifies the TXITEM_TextFormFieldEmptyWidth ribbon item inside the TXITEM_TextFormFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TextFormFieldEmptyWidth,
			/// <summary>Identifies the TXITEM_TextFormFieldRemoveContent ribbon item inside the TXITEM_TextFormFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TextFormFieldRemoveContent,
			/// <summary>Identifies the TXITEM_ComboBoxFieldPropertiesGroup ribbon group inside the RibbonFormFieldsTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_ComboBoxFieldPropertiesGroup,
			/// <summary>Identifies the TXITEM_ComboBoxFieldEmptyWidth ribbon item inside the TXITEM_ComboBoxFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ComboBoxFieldEmptyWidth,
			/// <summary>Identifies the TXITEM_ComboBoxFieldRemoveContent ribbon item inside the TXITEM_ComboBoxFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ComboBoxFieldRemoveContent,
			/// <summary>Identifies the TXITEM_NewComboBoxListItem ribbon item inside the TXITEM_ComboBoxFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_NewComboBoxListItem,
			/// <summary>Identifies the TXITEM_DeleteComboBoxListItem ribbon item inside the TXITEM_ComboBoxFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DeleteComboBoxListItem,
			/// <summary>Identifies the TXITEM_ComboBoxListItems ribbon item inside the TXITEM_ComboBoxFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding KeyTip resource.</summary>
			TXITEM_ComboBoxListItems,
			/// <summary>Identifies the TXITEM_ComboBoxListItemMoveUp ribbon item inside the TXITEM_ComboBoxFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ComboBoxListItemMoveUp,
			/// <summary>Identifies the TXITEM_ComboBoxListItemMoveDown ribbon item inside the TXITEM_ComboBoxFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ComboBoxListItemMoveDown,
			/// <summary>Identifies the TXITEM_DropDownListFieldPropertiesGroup ribbon group inside the RibbonFormFieldsTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_DropDownListFieldPropertiesGroup,
			/// <summary>Identifies the TXITEM_DropDownListFieldEmptyWidth ribbon item inside the TXITEM_DropDownListFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DropDownListFieldEmptyWidth,
			/// <summary>Identifies the TXITEM_DropDownListFieldRemoveContent ribbon item inside the TXITEM_DropDownListFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DropDownListFieldRemoveContent,
			/// <summary>Identifies the TXITEM_NewDropDownListItem ribbon item inside the TXITEM_DropDownListFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_NewDropDownListItem,
			/// <summary>Identifies the TXITEM_DeleteDropDownListItem ribbon item inside the TXITEM_DropDownListFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DeleteDropDownListItem,
			/// <summary>Identifies the TXITEM_DropDownListItems ribbon item inside the TXITEM_DropDownListFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding KeyTip resource.</summary>
			TXITEM_DropDownListItems,
			/// <summary>Identifies the TXITEM_DropDownListItemMoveUp ribbon item inside the TXITEM_DropDownListFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DropDownListItemMoveUp,
			/// <summary>Identifies the TXITEM_DropDownListItemMoveDown ribbon item inside the TXITEM_DropDownListFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DropDownListItemMoveDown,
			/// <summary>Identifies the TXITEM_DateFormFieldPropertiesGroup ribbon group inside the RibbonFormFieldsTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_DateFormFieldPropertiesGroup,
			/// <summary>Identifies the TXITEM_DateFormFieldEmptyWidthLabel ribbon item inside the TXITEM_DateFormFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_DateFormFieldEmptyWidthLabel,
			/// <summary>Identifies the TXITEM_DateFormat ribbon item inside the TXITEM_DateFormFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_DateFormat,
			/// <summary>Identifies the TXITEM_DateFormFieldEmptyWidth ribbon item inside the TXITEM_DateFormFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DateFormFieldEmptyWidth,
			/// <summary>Identifies the TXITEM_SupportedDateFormats ribbon item inside the TXITEM_DateFormFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_SupportedDateFormats,
			/// <summary>Identifies the TXITEM_DateFormFieldRemoveContent ribbon item inside the TXITEM_DateFormFieldPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_DateFormFieldRemoveContent
		}

		/// <summary>Each RibbonDropDownItem represents a drop-down item in the RibbonFormFieldsTab.</summary>
		public enum RibbonDropDownItem
		{
			/// <summary>Identifies the TXITEM_ManageConditionalInstructions_Sidebars_Vertical drop-down item inside the TXITEM_ManageConditionalInstructions_Sidebars's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_ManageConditionalInstructions_Sidebars_Vertical,
			/// <summary>Identifies the TXITEM_ManageConditionalInstructions_Sidebars_Horizontal drop-down item inside the TXITEM_ManageConditionalInstructions_Sidebars's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_ManageConditionalInstructions_Sidebars_Horizontal,
			/// <summary>Identifies the TXITEM_CheckedSymbolList_Characters drop-down item inside the TXITEM_CheckedSymbol's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_CheckedSymbolList_Characters,
			/// <summary>Identifies the TXITEM_UncheckedSymbolList_Characters drop-down item inside the TXITEM_UncheckedSymbol's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_UncheckedSymbolList_Characters
		}

		internal enum InternalRibbonItem
		{
			TXITEM_InsertFormFieldsGroup,
			TXITEM_InsertCheckBoxField,
			TXITEM_InsertComboBoxField,
			TXITEM_InsertRadioButtonField,
			TXITEM_InsertDropDownListField,
			TXITEM_InsertTextFormField,
			TXITEM_InsertDateFormField,
			TXITEM_EditFormFieldsGroup,
			TXITEM_DeleteFormField,
			TXITEM_RemoveFormFieldsContent,
			TXITEM_HighlightFormFields,
			TXITEM_PreviousFormField,
			TXITEM_NextFormField,
			TXITEM_FormValidationGroup,
			TXITEM_EnableFormValidation,
			TXITEM_ManageConditionalInstructions,
			TXITEM_ManageConditionalInstructions_Dialog,
			TXITEM_ManageConditionalInstructions_Sidebars,
			TXITEM_ManageConditionalInstructions_Sidebars_Vertical,
			TXITEM_ManageConditionalInstructions_Sidebars_Horizontal,
			TXITEM_HighlightInvalidValues,
			TXITEM_NextInvalidValueFormField,
			TXITEM_PreviousInvalidValueFormField,
			TXITEM_FormFieldPropertiesGroup,
			TXITEM_FormFieldName,
			TXITEM_FormFieldID,
			TXITEM_CheckBoxFieldPropertiesGroup,
			TXITEM_CheckedSymbol,
			TXITEM_CheckedSymbolLabel,
			TXITEM_CheckedSymbolList_Characters,
			TXITEM_CheckedSymbolSeparator1,
			TXITEM_CheckedSymbolList_Gallery,
			TXITEM_UncheckedSymbolLabel,
			TXITEM_UncheckedSymbol,
			TXITEM_UncheckedSymbolList_Characters,
			TXITEM_UncheckedSymbolSeparator1,
			TXITEM_UncheckedSymbolList_Gallery,
			TXITEM_TextFormFieldPropertiesGroup,
			TXITEM_TextFormFieldEmptyWidth,
			TXITEM_TextFormFieldRemoveContent,
			TXITEM_DropDownListFieldPropertiesGroup,
			TXITEM_DropDownListFieldEmptyWidth,
			TXITEM_DropDownListFieldRemoveContent,
			TXITEM_NewDropDownListItem,
			TXITEM_DeleteDropDownListItem,
			TXITEM_DropDownListItems,
			TXITEM_DropDownListItemMoveUp,
			TXITEM_DropDownListItemMoveDown,
			TXITEM_ComboBoxFieldPropertiesGroup,
			TXITEM_ComboBoxFieldEmptyWidth,
			TXITEM_ComboBoxFieldRemoveContent,
			TXITEM_NewComboBoxListItem,
			TXITEM_DeleteComboBoxListItem,
			TXITEM_ComboBoxListItems,
			TXITEM_ComboBoxListItemMoveUp,
			TXITEM_ComboBoxListItemMoveDown,
			TXITEM_DateFormFieldPropertiesGroup,
			TXITEM_DateFormFieldEmptyWidthLabel,
			TXITEM_DateFormFieldEmptyWidth,
			TXITEM_DateFormat,
			TXITEM_SupportedDateFormats,
			TXITEM_DateFormFieldRemoveContent
		}

		private Class503 class503_0;

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private List<Dictionary<string, object>> list_0 = new List<Dictionary<string, object>>();

		private Sidebar sidebar_0;

		private Sidebar sidebar_1;

		/// <summary>Gets or sets the horizontal sidebar that is connected to the RibbonFormFieldsTab's TXITEM_ManageConditionalInstructions button and its horizontal sidebar drop down button.</summary>
		[Attribute3("PROP_CONDITIONALINSTRUCTIONSSIDEBAR")]
		[DefaultValue(null)]
		[Category("Behavior")]
		public Sidebar ConditionalInstructionsHorizontalSidebar
		{
			get
			{
				return this.sidebar_1;
			}
			set
			{
				Sidebar sidebar;
				if ((sidebar = this.sidebar_1) != (this.sidebar_1 = value))
				{
					if (this.sidebar_1 != null)
					{
						this.sidebar_1.TextControl = this.TextControl_0;
					}
					(this.class503_0.BindingAdapter_0 as Class474).method_45(sidebar);
				}
			}
		}

		/// <summary>Gets or sets the vertical sidebar that is connected to the RibbonFormFieldsTab's TXITEM_ManageConditionalInstructions button and its vertical sidebar drop down button.</summary>
		[Attribute3("PROP_CONDITIONALINSTRUCTIONSSIDEBAR")]
		[Category("Behavior")]
		[DefaultValue(null)]
		public Sidebar ConditionalInstructionsSidebar
		{
			get
			{
				return this.sidebar_0;
			}
			set
			{
				Sidebar sidebar;
				if ((sidebar = this.sidebar_0) != (this.sidebar_0 = value))
				{
					if (this.sidebar_0 != null)
					{
						this.sidebar_0.TextControl = this.TextControl_0;
					}
					(this.class503_0.BindingAdapter_0 as Class474).method_45(sidebar);
				}
			}
		}

		protected override Padding DefaultPadding => new Padding(0);

		protected override Padding DefaultMargin => new Padding(0);

		public override string KeyTip
		{
			get
			{
				if (base.KeyTip == string.Empty)
				{
					return this.resourceManager_0.GetString("KEYTIP_FormFieldsTab");
				}
				return base.KeyTip;
			}
			set
			{
				base.KeyTip = value;
			}
		}

		public override string Text
		{
			get
			{
				if (base.Text == string.Empty)
				{
					return this.resourceManager_0.GetString("HEADER_RibbonFormFieldsTab");
				}
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		internal override TextControl TextControl_0
		{
			get
			{
				return base.TextControl_0;
			}
			set
			{
				if (base.TextControl_0 == value)
				{
					return;
				}
				if (base.TextControl_0 != null)
				{
					this.class503_0.BindingAdapter_0.OnDisconnectingTextControl();
					this.class503_0.BindingAdapter_0.TextControl.PropertyChanged -= this.class503_0.vmethod_0;
				}
				TextControl textControl3 = (base.TextControl_0 = (this.class503_0.BindingAdapter_0.TextControl = value));
				if (this.sidebar_1 != null)
				{
					this.sidebar_1.TextControl = value;
				}
				if (this.sidebar_0 != null)
				{
					this.sidebar_0.TextControl = value;
				}
				this.class503_0.BindingAdapter_0.SetDialogUnit();
				if (base.TextControl_0 != null)
				{
					this.class503_0.BindingAdapter_0.OnTextControlConnected();
					if (this.class503_0.Boolean_0)
					{
						this.vmethod_0();
					}
					this.class503_0.BindingAdapter_0.TextControl.PropertyChanged += this.class503_0.vmethod_0;
				}
				Class474 @class = this.class503_0.BindingAdapter_0 as Class474;
				if (base.TextControl_0 != null && (base.TextControl_0.DisplayColors.FormFieldColor.A != 0 || base.TextControl_0.DisplayColors.FormFieldColor.R != byte.MaxValue || base.TextControl_0.DisplayColors.FormFieldColor.G != byte.MaxValue || base.TextControl_0.DisplayColors.FormFieldColor.B != byte.MaxValue))
				{
					@class.Color_0 = Color.FromArgb(255, base.TextControl_0.DisplayColors.FormFieldColor);
				}
				else
				{
					@class.Color_0 = default(Color);
				}
				this.class503_0.method_5();
				(this.class503_0.BindingAdapter_0 as Class474).method_45(null);
			}
		}

		/// <summary>Initializes a new instance of the RibbonFormFieldsTab class.</summary>
		public RibbonFormFieldsTab()
		{
			this.method_2();
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			PointF dpi = base.method_0();
			this.class503_0.BindingAdapter_0.AwareOfDPI(dpi);
			base.OnHandleCreated(eventArgs_0);
		}

		internal override void vmethod_0(params object[] object_0)
		{
			this.class503_0.BindingAdapter_0.UpdateRibbonTab();
		}

		internal override void vmethod_1(uint uint_1)
		{
			base.vmethod_1(uint_1);
			this.class503_0.BindingAdapter_0.AwareOfDPI(base.method_0());
		}

		public Control FindItem(RibbonItem ribbonItem)
		{
			object value = null;
			foreach (Dictionary<string, object> item in this.list_0)
			{
				if (item.TryGetValue(ribbonItem.ToString(), out value))
				{
					return (Control)value;
				}
			}
			return null;
		}

		public bool ShouldSerializeKeyTip()
		{
			return base.KeyTip != string.Empty;
		}

		public void ResetKeyTip()
		{
			this.KeyTip = string.Empty;
		}

		public bool ShouldSerializeText()
		{
			return base.Text != string.Empty;
		}

		private void method_2()
		{
			this.class503_0 = new Class503(this, new Class474());
			this.class503_0.method_10(base.RibbonGroups);
			this.class503_0.method_11(base.RibbonGroups);
			this.class503_0.method_13(base.RibbonGroups);
			this.class503_0.method_12(base.RibbonGroups);
			this.class503_0.method_14(base.RibbonGroups);
			this.class503_0.method_15(base.RibbonGroups);
			this.class503_0.method_16(base.RibbonGroups);
			this.class503_0.method_17(base.RibbonGroups);
			this.class503_0.method_18(base.RibbonGroups);
			this.list_0.Add(this.class503_0.TXITEM_InsertFormFieldsGroup_Items);
			this.list_0.Add(this.class503_0.TXITEM_EditFormFieldsGroup_Items);
			this.list_0.Add(this.class503_0.TXITEM_FormValidationGroup_Items);
			this.list_0.Add(this.class503_0.TXITEM_FormFieldPropertiesGroup_Items);
			this.list_0.Add(this.class503_0.TXITEM_CheckBoxFieldPropertiesGroup_Items);
			this.list_0.Add(this.class503_0.TXITEM_TextFormFieldPropertiesGroup_Items);
			this.list_0.Add(this.class503_0.TXITEM_ComboBoxFieldPropertiesGroup_Items);
			this.list_0.Add(this.class503_0.TXITEM_DropDownListFieldPropertiesGroup_Items);
			this.list_0.Add(this.class503_0.TXITEM_DateFormFieldPropertiesGroup_Items);
		}
	}
}
