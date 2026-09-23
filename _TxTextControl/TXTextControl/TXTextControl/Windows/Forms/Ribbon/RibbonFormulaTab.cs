using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonFormulaTab class represents a Windows Forms ribbon tab for editing formulas in table cells.</summary>
	[ToolboxBitmap(typeof(RibbonFormulaTab))]
	public class RibbonFormulaTab : RibbonTab
	{
		/// <summary>Each RibbonItem represents an item in the RibbonFormulaTab that is not a drop-down item.</summary>
		public enum RibbonItem
		{
			/// <summary>Identifies the TXITEM_FormulaGroup ribbon group inside the RibbonFormulaTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_FormulaGroup,
			/// <summary>Identifies the dialog box launcher of the TXITEM_FormulaGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle and ToolTipDescription resources. Limitations: The FindItem method returns null when passing this RibbonItem as an argument.</summary>
			TXITEM_FormulaGroup_DialogBoxLauncher,
			/// <summary>Identifies the TXITEM_Formula ribbon item inside the TXITEM_FormulaGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_Formula,
			/// <summary>Identifies the TXITEM_FormulaTextBox ribbon item inside the TXITEM_FormulaGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_FormulaTextBox,
			/// <summary>Identifies the TXITEM_AcceptFormula ribbon item inside the TXITEM_FormulaGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_AcceptFormula,
			/// <summary>Identifies the TXITEM_CancelFormulaEditing ribbon item inside the TXITEM_FormulaGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_CancelFormulaEditing,
			/// <summary>Identifies the TXITEM_Functions ribbon item inside the TXITEM_FormulaGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_Functions,
			/// <summary>Identifies the TXITEM_SupportedFunctions ribbon item inside the TXITEM_FormulaGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_SupportedFunctions,
			/// <summary>Identifies the TXITEM_AddFunction ribbon item inside the TXITEM_FormulaGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_AddFunction,
			/// <summary>Identifies the TXITEM_SelectCellReferences ribbon item inside the TXITEM_FormulaGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_SelectCellReferences,
			/// <summary>Identifies the TXITEM_NumberFormatGroup ribbon group inside the RibbonFormulaTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_NumberFormatGroup,
			/// <summary>Identifies the dialog box launcher of the TXITEM_NumberFormatGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle and ToolTipDescription resources. Limitations: The FindItem method returns null when passing this RibbonItem as an argument.</summary>
			TXITEM_NumberFormatGroup_DialogBoxLauncher,
			/// <summary>Identifies the TXITEM_TableCellNumberFormat ribbon item inside the TXITEM_NumberFormatGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_TableCellNumberFormat,
			/// <summary>Identifies the TXITEM_TableCellNumberFormatComboBox ribbon item inside the TXITEM_NumberFormatGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TableCellNumberFormatComboBox,
			/// <summary>Identifies the TXITEM_TableCellAcceptNumberFormat ribbon item inside the TXITEM_NumberFormatGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TableCellAcceptNumberFormat,
			/// <summary>Identifies the TXITEM_TableCellTextType ribbon item inside the TXITEM_NumberFormatGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_TableCellTextType,
			/// <summary>Identifies the TXITEM_TableCellTextTypeText ribbon item inside the TXITEM_NumberFormatGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TableCellTextTypeText,
			/// <summary>Identifies the TXITEM_TableCellTextTypeNumber ribbon item inside the TXITEM_NumberFormatGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TableCellTextTypeNumber,
			/// <summary>Identifies the TXITEM_FormulaSettingsGroup ribbon group inside the RibbonFormulaTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_FormulaSettingsGroup,
			/// <summary>Identifies the TXITEM_EnableFormulaCalculation ribbon item inside the TXITEM_FormulaSettingsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_EnableFormulaCalculation,
			/// <summary>Identifies the TXITEM_EnableR1C1Style ribbon item inside the TXITEM_FormulaSettingsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_EnableR1C1Style,
			/// <summary>Identifies the TXITEM_EnableA1Style ribbon item inside the TXITEM_FormulaSettingsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_EnableA1Style,
			/// <summary>Identifies the TXITEM_ShowFormulaReferences ribbon item inside the TXITEM_FormulaSettingsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ShowFormulaReferences,
			/// <summary>Identifies the TXITEM_ShowAllReferences ribbon item inside the TXITEM_FormulaSettingsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ShowAllReferences
		}

		internal enum InternalRibbonItem
		{
			TXITEM_FormulaGroup,
			TXITEM_FormulaGroup_DialogBoxLauncher,
			TXITEM_Formula,
			TXITEM_FormulaTextBox,
			TXITEM_AcceptFormula,
			TXITEM_CancelFormulaEditing,
			TXITEM_Functions,
			TXITEM_SupportedFunctions,
			TXITEM_AddFunction,
			TXITEM_FormulaGroupSeparator,
			TXITEM_SelectCellReferences,
			TXITEM_NumberFormatGroup,
			TXITEM_NumberFormatGroup_DialogBoxLauncher,
			TXITEM_TableCellNumberFormat,
			TXITEM_TableCellNumberFormatComboBox,
			TXITEM_TableCellAcceptNumberFormat,
			TXITEM_TableCellTextType,
			TXITEM_TableCellTextTypeText,
			TXITEM_TableCellTextTypeNumber,
			TXITEM_FormulaSettingsGroup,
			TXITEM_EnableFormulaCalculation,
			TXITEM_EnableR1C1Style,
			TXITEM_EnableA1Style,
			TXITEM_ShowFormulaReferences,
			TXITEM_ShowAllReferences
		}

		private Class504 class504_0;

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private List<Dictionary<string, object>> list_0 = new List<Dictionary<string, object>>();

		protected override Padding DefaultPadding => new Padding(0);

		protected override Padding DefaultMargin => new Padding(0);

		public override string KeyTip
		{
			get
			{
				if (base.KeyTip == string.Empty)
				{
					return this.resourceManager_0.GetString("KEYTIP_FormulaTab");
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
					return this.resourceManager_0.GetString("HEADER_RibbonFormulaTab");
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
					this.class504_0.BindingAdapter_0.OnDisconnectingTextControl();
					this.class504_0.BindingAdapter_0.TextControl.PropertyChanged -= this.class504_0.vmethod_0;
				}
				TextControl textControl3 = (base.TextControl_0 = (this.class504_0.BindingAdapter_0.TextControl = value));
				if (base.TextControl_0 != null)
				{
					this.class504_0.BindingAdapter_0.OnTextControlConnected();
					if (this.class504_0.Boolean_0)
					{
						this.vmethod_0();
					}
					this.class504_0.BindingAdapter_0.TextControl.PropertyChanged += this.class504_0.vmethod_0;
				}
				this.class504_0.method_5();
			}
		}

		/// <summary>Initializes a new instance of the RibbonFormulaTab class.</summary>
		public RibbonFormulaTab()
		{
			this.method_2();
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			PointF dpi = base.method_0();
			this.class504_0.BindingAdapter_0.AwareOfDPI(dpi);
			base.OnHandleCreated(eventArgs_0);
		}

		internal override void vmethod_0(params object[] object_0)
		{
			this.class504_0.BindingAdapter_0.UpdateRibbonTab();
		}

		internal override void vmethod_1(uint uint_1)
		{
			base.vmethod_1(uint_1);
			this.class504_0.BindingAdapter_0.AwareOfDPI(base.method_0());
		}

		public Control FindItem(RibbonItem ribbonItem)
		{
			object value = null;
			foreach (Dictionary<string, object> item in this.list_0)
			{
				if (item.TryGetValue(ribbonItem.ToString(), out value))
				{
					return value as Control;
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
			this.class504_0 = new Class504(this, new Class475());
			this.class504_0.method_10(base.RibbonGroups);
			this.class504_0.method_11(base.RibbonGroups);
			this.class504_0.method_12(base.RibbonGroups);
			this.list_0.Add(this.class504_0.TXITEM_FormulaGroup_Items);
			this.list_0.Add(this.class504_0.TXITEM_NumberFormatGroup_Items);
			this.list_0.Add(this.class504_0.TXITEM_FormulaSettingsGroup_Items);
		}
	}
}
