using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonTableLayoutTab class represents a Windows Forms ribbon tab for editing tables.</summary>
	[ToolboxBitmap(typeof(RibbonTableLayoutTab))]
	public class RibbonTableLayoutTab : RibbonTab
	{
		/// <summary>Each RibbonItem represents an item in the RibbonTableLayoutTab that is not a drop-down item.</summary>
		public enum RibbonItem
		{
			/// <summary>Identifies the TXITEM_TableLayoutGroup ribbon group inside the RibbonTableLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_TableLayoutGroup,
			/// <summary>Identifies the TXITEM_SelectTable ribbon item inside the TXITEM_TableLayoutGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_SelectTable,
			/// <summary>Identifies the TXITEM_TableGridLines ribbon item inside the TXITEM_TableLayoutGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TableGridLines,
			/// <summary>Identifies the TXITEM_TableProperties ribbon item inside the TXITEM_TableLayoutGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TableProperties,
			/// <summary>Identifies the TXITEM_RowsAndColumnsGroup ribbon group inside the RibbonTableLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_RowsAndColumnsGroup,
			/// <summary>Identifies the TXITEM_DeleteTable ribbon item inside the TXITEM_RowsAndColumnsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DeleteTable,
			/// <summary>Identifies the TXITEM_InsertTableRowAbove ribbon item inside the TXITEM_RowsAndColumnsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertTableRowAbove,
			/// <summary>Identifies the TXITEM_InsertTableRowBelow ribbon item inside the TXITEM_RowsAndColumnsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertTableRowBelow,
			/// <summary>Identifies the TXITEM_InsertTableColLeft ribbon item inside the TXITEM_RowsAndColumnsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertTableColLeft,
			/// <summary>Identifies the TXITEM_InsertTableColRight ribbon item inside the TXITEM_RowsAndColumnsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertTableColRight,
			/// <summary>Identifies the TXITEM_MergeGroup ribbon group inside the RibbonTableLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_MergeGroup,
			/// <summary>Identifies the TXITEM_MergeTableCells ribbon item inside the TXITEM_MergeGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_MergeTableCells,
			/// <summary>Identifies the TXITEM_SplitTableCells ribbon item inside the TXITEM_MergeGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_SplitTableCells,
			/// <summary>Identifies the TXITEM_SplitTable ribbon item inside the TXITEM_MergeGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_SplitTable,
			/// <summary>Identifies the TXITEM_BordersAndBackgroundGroup ribbon group inside the RibbonTableLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_BordersAndBackgroundGroup,
			/// <summary>Identifies the dialog box launcher of the TXITEM_BordersAndBackgroundGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle and ToolTipDescription resources. Limitations: The FindItem method returns null when passing this RibbonItem as an argument.</summary>
			TXITEM_BordersAndBackgroundGroup_DialogBoxLauncher,
			/// <summary>Identifies the TXITEM_TableFrameLines ribbon item inside the TXITEM_BordersAndBackgroundGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TableFrameLines,
			/// <summary>Identifies the TXITEM_TableLineColor ribbon item inside the TXITEM_BordersAndBackgroundGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TableLineColor,
			/// <summary>Identifies the TXITEM_TableBackColor ribbon item inside the TXITEM_BordersAndBackgroundGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TableBackColor,
			/// <summary>Identifies the TXITEM_TableLineWidth ribbon item inside the TXITEM_BordersAndBackgroundGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TableLineWidth,
			/// <summary>Identifies the TXITEM_TableAlignmentGroup ribbon group inside the RibbonTableLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_TableAlignmentGroup,
			/// <summary>Identifies the dialog box launcher of the TXITEM_TableAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle and ToolTipDescription resources. Limitations: The FindItem method returns null when passing this RibbonItem as an argument.</summary>
			TXITEM_TableAlignmentGroup_DialogBoxLauncher,
			/// <summary>Identifies the TXITEM_CellAlignTopLeft ribbon item inside the TXITEM_TableAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_CellAlignTopLeft,
			/// <summary>Identifies the TXITEM_CellAlignMiddleLeft ribbon item inside the TXITEM_TableAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_CellAlignMiddleLeft,
			/// <summary>Identifies the TXITEM_CellAlignBottomLeft ribbon item inside the TXITEM_TableAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_CellAlignBottomLeft,
			/// <summary>Identifies the TXITEM_CellAlignTopCentered ribbon item inside the TXITEM_TableAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_CellAlignTopCentered,
			/// <summary>Identifies the TXITEM_CellAlignMiddleCentered ribbon item inside the TXITEM_TableAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_CellAlignMiddleCentered,
			/// <summary>Identifies the TXITEM_CellAlignBottomCentered ribbon item inside the TXITEM_TableAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_CellAlignBottomCentered,
			/// <summary>Identifies the TXITEM_CellAlignTopRight ribbon item inside the TXITEM_TableAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_CellAlignTopRight,
			/// <summary>Identifies the TXITEM_CellAlignMiddleRight ribbon item inside the TXITEM_TableAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_CellAlignMiddleRight,
			/// <summary>Identifies the TXITEM_CellAlignBottomRight ribbon item inside the TXITEM_TableAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_CellAlignBottomRight,
			/// <summary>Identifies the TXITEM_CellAlignTopJustified ribbon item inside the TXITEM_TableAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_CellAlignTopJustified,
			/// <summary>Identifies the TXITEM_CellAlignMiddleJustified ribbon item inside the TXITEM_TableAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_CellAlignMiddleJustified,
			/// <summary>Identifies the TXITEM_CellAlignBottomJustified ribbon item inside the TXITEM_TableAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_CellAlignBottomJustified
		}

		/// <summary>Each RibbonDropDownItem represents a drop-down item in the RibbonTableLayoutTab.</summary>
		public enum RibbonDropDownItem
		{
			/// <summary>Identifies the TXITEM_SelectTableCell drop-down item inside the TXITEM_SelectTable's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_SelectTableCell,
			/// <summary>Identifies the TXITEM_SelectTableCol drop-down item inside the TXITEM_SelectTable's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_SelectTableCol,
			/// <summary>Identifies the TXITEM_SelectTableRow drop-down item inside the TXITEM_SelectTable's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_SelectTableRow,
			/// <summary>Identifies the TXITEM_SelectTableAll drop-down item inside the TXITEM_SelectTable's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_SelectTableAll,
			/// <summary>Identifies the TXITEM_DeleteTableCell drop-down item inside the TXITEM_DeleteTable's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_DeleteTableCell,
			/// <summary>Identifies the TXITEM_DeleteTableCol drop-down item inside the TXITEM_DeleteTable's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_DeleteTableCol,
			/// <summary>Identifies the TXITEM_DeleteTableRow drop-down item inside the TXITEM_DeleteTable's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_DeleteTableRow,
			/// <summary>Identifies the TXITEM_DeleteTableAll drop-down item inside the TXITEM_DeleteTable's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_DeleteTableAll,
			/// <summary>Identifies the TXITEM_SplitTableAbove drop-down item inside the TXITEM_SplitTable's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_SplitTableAbove,
			/// <summary>Identifies the TXITEM_SplitTableBelow drop-down item inside the TXITEM_SplitTable's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_SplitTableBelow,
			/// <summary>Identifies the TXITEM_TableLeftFrameLine drop-down item inside the TXITEM_TableFrameLines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TableLeftFrameLine,
			/// <summary>Identifies the TXITEM_TableTopFrameLine drop-down item inside the TXITEM_TableFrameLines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TableTopFrameLine,
			/// <summary>Identifies the TXITEM_TableRightFrameLine drop-down item inside the TXITEM_TableFrameLines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TableRightFrameLine,
			/// <summary>Identifies the TXITEM_TableBottomFrameLine drop-down item inside the TXITEM_TableFrameLines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TableBottomFrameLine,
			/// <summary>Identifies the TXITEM_TableBoxFrame drop-down item inside the TXITEM_TableFrameLines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TableBoxFrame,
			/// <summary>Identifies the TXITEM_TableAllFrameLines drop-down item inside the TXITEM_TableFrameLines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TableAllFrameLines,
			/// <summary>Identifies the TXITEM_TableInnerHorizontalFrameLines drop-down item inside the TXITEM_TableFrameLines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TableInnerHorizontalFrameLines,
			/// <summary>Identifies the TXITEM_TableInnerVerticalFrameLines drop-down item inside the TXITEM_TableFrameLines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TableInnerVerticalFrameLines,
			/// <summary>Identifies the TXITEM_TableLineColor_Automatic drop-down item inside the TXITEM_TableLineColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TableLineColor_Automatic,
			/// <summary>Identifies the TXITEM_TableLineColor_MoreColors drop-down item inside the TXITEM_TableLineColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TableLineColor_MoreColors,
			/// <summary>Identifies the TXITEM_TableBackColor_Transparent drop-down item inside the TXITEM_TableBackColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TableBackColor_Transparent,
			/// <summary>Identifies the TXITEM_TableBackColor_MoreColors drop-down item inside the TXITEM_TableBackColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TableBackColor_MoreColors
		}

		internal enum InternalRibbonItem
		{
			TXITEM_TableLayoutGroup,
			TXITEM_SelectTable,
			TXITEM_SelectTableCell,
			TXITEM_SelectTableCol,
			TXITEM_SelectTableRow,
			TXITEM_SelectTableAll,
			TXITEM_TableGridLines,
			TXITEM_TableProperties,
			TXITEM_RowsAndColumnsGroup,
			TXITEM_DeleteTable,
			TXITEM_DeleteTableCell,
			TXITEM_DeleteTableCol,
			TXITEM_DeleteTableRow,
			TXITEM_DeleteTableAll,
			TXITEM_InsertTableRowAbove,
			TXITEM_InsertTableRowBelow,
			TXITEM_InsertTableColLeft,
			TXITEM_InsertTableColRight,
			TXITEM_MergeGroup,
			TXITEM_MergeTableCells,
			TXITEM_SplitTableCells,
			TXITEM_SplitTable,
			TXITEM_SplitTableAbove,
			TXITEM_SplitTableBelow,
			TXITEM_BordersAndBackgroundGroup,
			TXITEM_BordersAndBackgroundGroup_DialogBoxLauncher,
			TXITEM_TableFrameLines,
			TXITEM_TableLeftFrameLine,
			TXITEM_TableTopFrameLine,
			TXITEM_TableRightFrameLine,
			TXITEM_TableBottomFrameLine,
			TXITEM_TableFrameLinesSeperator1,
			TXITEM_TableBoxFrame,
			TXITEM_TableAllFrameLines,
			TXITEM_TableFrameLinesSeperator2,
			TXITEM_TableInnerHorizontalFrameLines,
			TXITEM_TableInnerVerticalFrameLines,
			TXITEM_TableLineColor,
			TXITEM_TableLineColor_Automatic,
			TXITEM_TableLineColorSeperator1,
			TXITEM_TableLineColor_Gallery,
			TXITEM_TableLineColorSeperator2,
			TXITEM_TableLineColor_MoreColors,
			TXITEM_TableBackColor,
			TXITEM_TableBackColor_Transparent,
			TXITEM_TableBackColorSeperator1,
			TXITEM_TableBackColor_Gallery,
			TXITEM_TableBackColorSeperator2,
			TXITEM_TableBackColor_MoreColors,
			TXITEM_TableLineWidth,
			TXITEM_TableLineWidth_25,
			TXITEM_TableLineWidth_50,
			TXITEM_TableLineWidth_75,
			TXITEM_TableLineWidth_100,
			TXITEM_TableLineWidth_150,
			TXITEM_TableLineWidth_225,
			TXITEM_TableLineWidth_300,
			TXITEM_TableLineWidth_450,
			TXITEM_TableLineWidth_600,
			TXITEM_TableAlignmentGroup,
			TXITEM_TableAlignmentGroup_DialogBoxLauncher,
			TXITEM_CellAlignTopLeft,
			TXITEM_CellAlignTopCentered,
			TXITEM_CellAlignTopRight,
			TXITEM_CellAlignTopJustified,
			TXITEM_CellAlignMiddleLeft,
			TXITEM_CellAlignMiddleCentered,
			TXITEM_CellAlignMiddleRight,
			TXITEM_CellAlignMiddleJustified,
			TXITEM_CellAlignBottomLeft,
			TXITEM_CellAlignBottomCentered,
			TXITEM_CellAlignBottomRight,
			TXITEM_CellAlignBottomJustified
		}

		private Class512 class512_0;

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
					return this.resourceManager_0.GetString("KEYTIP_TableLayoutTab");
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
					return this.resourceManager_0.GetString("HEADER_RibbonTableLayoutTab");
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
					this.class512_0.BindingAdapter_0.OnDisconnectingTextControl();
					this.class512_0.BindingAdapter_0.TextControl.PropertyChanged -= this.class512_0.vmethod_0;
				}
				TextControl textControl3 = (base.TextControl_0 = (this.class512_0.BindingAdapter_0.TextControl = value));
				if (base.TextControl_0 != null)
				{
					this.class512_0.BindingAdapter_0.OnTextControlConnected();
					if (this.class512_0.Boolean_0)
					{
						this.vmethod_0();
					}
					this.class512_0.BindingAdapter_0.TextControl.PropertyChanged += this.class512_0.vmethod_0;
				}
				this.class512_0.method_5();
			}
		}

		/// <summary>Initializes a new instance of the RibbonTableLayoutTab class.</summary>
		public RibbonTableLayoutTab()
		{
			this.method_2();
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			PointF dpi = base.method_0();
			this.class512_0.BindingAdapter_0.AwareOfDPI(dpi);
			base.OnHandleCreated(eventArgs_0);
		}

		internal override void vmethod_0(params object[] object_0)
		{
			this.class512_0.BindingAdapter_0.UpdateRibbonTab();
		}

		internal override void vmethod_1(uint uint_1)
		{
			base.vmethod_1(uint_1);
			this.class512_0.BindingAdapter_0.AwareOfDPI(base.method_0());
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
			this.class512_0 = new Class512(this, new Class483());
			this.class512_0.method_10(base.RibbonGroups);
			this.class512_0.method_11(base.RibbonGroups);
			this.class512_0.method_12(base.RibbonGroups);
			this.class512_0.method_13(base.RibbonGroups);
			this.class512_0.method_14(base.RibbonGroups);
			this.list_0.Add(this.class512_0.TXITEM_TableLayoutGroup_Items);
			this.list_0.Add(this.class512_0.TXITEM_RowsAndColumnsGroup_Items);
			this.list_0.Add(this.class512_0.TXITEM_MergeGroup_Items);
			this.list_0.Add(this.class512_0.TXITEM_BordersAndBackgroundGroup_Items);
			this.list_0.Add(this.class512_0.TXITEM_TableAlignmentGroup_Items);
		}
	}
}
