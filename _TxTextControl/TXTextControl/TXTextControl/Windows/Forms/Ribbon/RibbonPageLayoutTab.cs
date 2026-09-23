using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonPageLayoutTab class represents a Windows Forms ribbon tab for editing the page setup and layout.</summary>
	[ToolboxBitmap(typeof(RibbonPageLayoutTab))]
	public class RibbonPageLayoutTab : RibbonTab
	{
		/// <summary>Each RibbonItem represents an item in the RibbonPageLayoutTab that is not a drop-down item.</summary>
		public enum RibbonItem
		{
			/// <summary>Identifies the TXITEM_PageSetupGroup ribbon group inside the RibbonPageLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_PageSetupGroup,
			/// <summary>Identifies the dialog box launcher of the TXITEM_PageSetupGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle and ToolTipDescription resources. Limitations: The FindItem method returns null when passing this RibbonItem as an argument.</summary>
			TXITEM_PageSetupGroup_DialogBoxLauncher,
			/// <summary>Identifies the TXITEM_PageMargins ribbon item inside the TXITEM_PageSetupGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_PageMargins,
			/// <summary>Identifies the TXITEM_Orientation ribbon item inside the TXITEM_PageSetupGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Orientation,
			/// <summary>Identifies the TXITEM_PageSize ribbon item inside the TXITEM_PageSetupGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_PageSize,
			/// <summary>Identifies the TXITEM_ColumnsAndBreaksGroup ribbon group inside the RibbonPageLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_ColumnsAndBreaksGroup,
			/// <summary>Identifies the dialog box launcher of the TXITEM_ColumnsAndBreaksGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle and ToolTipDescription resources. Limitations: The FindItem method returns null when passing this RibbonItem as an argument.</summary>
			TXITEM_ColumnsAndBreaksGroup_DialogBoxLauncher,
			/// <summary>Identifies the TXITEM_Columns ribbon item inside the TXITEM_ColumnsAndBreaksGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Columns,
			/// <summary>Identifies the TXITEM_Breaks ribbon item inside the TXITEM_ColumnsAndBreaksGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Breaks,
			/// <summary>Identifies the TXITEM_PageBackgroundAndBordersGroup ribbon group inside the RibbonPageLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_PageBackgroundAndBordersGroup,
			/// <summary>Identifies the dialog box launcher of the TXITEM_PageBackgroundAndBordersGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle and ToolTipDescription resources. Limitations: The FindItem method returns null when passing this RibbonItem as an argument.</summary>
			TXITEM_PageBackgroundAndBordersGroup_DialogBoxLauncher,
			/// <summary>Identifies the TXITEM_PageColor ribbon item inside the TXITEM_PageBackgroundAndBordersGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_PageColor,
			/// <summary>Identifies the TXITEM_PageBorders ribbon item inside the TXITEM_PageBackgroundAndBordersGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_PageBorders,
			/// <summary>Identifies the TXITEM_PageLineColor ribbon item inside the TXITEM_PageBackgroundAndBordersGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_PageLineColor,
			/// <summary>Identifies the TXITEM_PageLineWidth ribbon item inside the TXITEM_PageBackgroundAndBordersGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_PageLineWidth
		}

		/// <summary>Each RibbonDropDownItem represents a drop-down item in the RibbonPageLayoutTab.</summary>
		public enum RibbonDropDownItem
		{
			/// <summary>Identifies the TXITEM_Orientation_Portrait drop-down item inside the TXITEM_Orientation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_Orientation_Portrait,
			/// <summary>Identifies the TXITEM_Orientation_Landscape drop-down item inside the TXITEM_Orientation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_Orientation_Landscape,
			/// <summary>Identifies the TXITEM_Columns_One drop-down item inside the TXITEM_Columns's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_Columns_One,
			/// <summary>Identifies the TXITEM_Columns_Two drop-down item inside the TXITEM_Columns's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_Columns_Two,
			/// <summary>Identifies the TXITEM_Columns_Three drop-down item inside the TXITEM_Columns's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_Columns_Three,
			/// <summary>Identifies the TXITEM_Columns_MoreColumns drop-down item inside the TXITEM_Columns's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_Columns_MoreColumns,
			/// <summary>Identifies the TXITEM_Breaks_PageBreaks drop-down item inside the TXITEM_Breaks's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_Breaks_PageBreaks,
			/// <summary>Identifies the TXITEM_Breaks_Page drop-down item inside the TXITEM_Breaks's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_Breaks_Page,
			/// <summary>Identifies the TXITEM_Breaks_Column drop-down item inside the TXITEM_Breaks's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_Breaks_Column,
			/// <summary>Identifies the TXITEM_Breaks_TextWrapping drop-down item inside the TXITEM_Breaks's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_Breaks_TextWrapping,
			/// <summary>Identifies the TXITEM_Breaks_SectionBreaks drop-down item inside the TXITEM_Breaks's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_Breaks_SectionBreaks,
			/// <summary>Identifies the TXITEM_Breaks_NextPage drop-down item inside the TXITEM_Breaks's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_Breaks_NextPage,
			/// <summary>Identifies the TXITEM_Breaks_Continuous drop-down item inside the TXITEM_Breaks's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_Breaks_Continuous,
			/// <summary>Identifies the TXITEM_PageColor_Automatic drop-down item inside the TXITEM_PageColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_PageColor_Automatic,
			/// <summary>Identifies the TXITEM_PageColor_MoreColors drop-down item inside the TXITEM_PageColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_PageColor_MoreColors,
			/// <summary>Identifies the TXITEM_PageBorders_Left drop-down item inside the TXITEM_PageBorders's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_PageBorders_Left,
			/// <summary>Identifies the TXITEM_PageBorders_Top drop-down item inside the TXITEM_PageBorders's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_PageBorders_Top,
			/// <summary>Identifies the TXITEM_PageBorders_Right drop-down item inside the TXITEM_PageBorders's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_PageBorders_Right,
			/// <summary>Identifies the TXITEM_PageBorders_Bottom drop-down item inside the TXITEM_PageBorders's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_PageBorders_Bottom,
			/// <summary>Identifies the TXITEM_PageBorders_All drop-down item inside the TXITEM_PageBorders's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_PageBorders_All,
			/// <summary>Identifies the TXITEM_PageLineColor_Automatic drop-down item inside the TXITEM_PageLineColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_PageLineColor_Automatic,
			/// <summary>Identifies the TXITEM_PageLineColor_MoreColors drop-down item inside the TXITEM_PageLineColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_PageLineColor_MoreColors,
			/// <summary>Identifies the TXITEM_PageLineWidth_NoLine drop-down item inside the TXITEM_PageLineWidth's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_PageLineWidth_NoLine
		}

		internal enum InternalRibbonItem
		{
			TXITEM_PageSetupGroup,
			TXITEM_PageSetupGroup_DialogBoxLauncher,
			TXITEM_PageMargins,
			TXITEM_Orientation,
			TXITEM_Orientation_Portrait,
			TXITEM_Orientation_Landscape,
			TXITEM_PageSize,
			TXITEM_ColumnsAndBreaksGroup,
			TXITEM_ColumnsAndBreaksGroup_DialogBoxLauncher,
			TXITEM_Columns,
			TXITEM_Columns_One,
			TXITEM_Columns_Two,
			TXITEM_Columns_Three,
			TXITEM_ColumnsSeperator1,
			TXITEM_Columns_MoreColumns,
			TXITEM_Breaks,
			TXITEM_Breaks_PageBreaks,
			TXITEM_Breaks_Seperator1,
			TXITEM_Breaks_Page,
			TXITEM_Breaks_Column,
			TXITEM_Breaks_TextWrapping,
			TXITEM_Breaks_SectionBreaks,
			TXITEM_Breaks_Seperator2,
			TXITEM_Breaks_NextPage,
			TXITEM_Breaks_Continuous,
			TXITEM_PageBackgroundAndBordersGroup,
			TXITEM_PageBackgroundAndBordersGroup_DialogBoxLauncher,
			TXITEM_PageColor,
			TXITEM_PageColor_Automatic,
			TXITEM_PageColorSeperator1,
			TXITEM_PageColor_Gallery,
			TXITEM_PageColorSeperator2,
			TXITEM_PageColor_MoreColors,
			TXITEM_PageBorders,
			TXITEM_PageBorders_Left,
			TXITEM_PageBorders_Top,
			TXITEM_PageBorders_Right,
			TXITEM_PageBorders_Bottom,
			TXITEM_PageBordersSeperator1,
			TXITEM_PageBorders_All,
			TXITEM_PageLineColor,
			TXITEM_PageLineColor_Automatic,
			TXITEM_PageLineColorSeperator1,
			TXITEM_PageLineColor_Gallery,
			TXITEM_PageLineColorSeperator2,
			TXITEM_PageLineColor_MoreColors,
			TXITEM_PageLineWidth,
			TXITEM_PageLineWidth_NoLine,
			TXITEM_PageLineWidthSeperator1,
			TXITEM_PageLineWidth_25,
			TXITEM_PageLineWidth_50,
			TXITEM_PageLineWidth_75,
			TXITEM_PageLineWidth_100,
			TXITEM_PageLineWidth_150,
			TXITEM_PageLineWidth_225,
			TXITEM_PageLineWidth_300,
			TXITEM_PageLineWidth_450,
			TXITEM_PageLineWidth_600
		}

		private Class507 class507_0;

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
					return this.resourceManager_0.GetString("KEYTIP_PageLayoutTab");
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
					return this.resourceManager_0.GetString("HEADER_RibbonPageLayoutTab");
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
					this.class507_0.BindingAdapter_0.OnDisconnectingTextControl();
					this.class507_0.BindingAdapter_0.TextControl.PropertyChanged -= this.class507_0.vmethod_0;
				}
				TextControl textControl3 = (base.TextControl_0 = (this.class507_0.BindingAdapter_0.TextControl = value));
				this.class507_0.BindingAdapter_0.SetDialogUnit();
				if (base.TextControl_0 != null)
				{
					this.class507_0.BindingAdapter_0.OnTextControlConnected();
					if (this.class507_0.Boolean_0)
					{
						this.vmethod_0();
					}
					this.class507_0.BindingAdapter_0.TextControl.PropertyChanged += this.class507_0.vmethod_0;
				}
				this.class507_0.method_5();
			}
		}

		/// <summary>Initializes a new instance of the RibbonPageLayoutTab class.</summary>
		public RibbonPageLayoutTab()
		{
			this.method_2();
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			PointF dpi = base.method_0();
			this.class507_0.BindingAdapter_0.AwareOfDPI(dpi);
			base.OnHandleCreated(eventArgs_0);
		}

		internal override void vmethod_0(params object[] object_0)
		{
			this.class507_0.BindingAdapter_0.UpdateRibbonTab();
		}

		internal override void vmethod_1(uint uint_1)
		{
			base.vmethod_1(uint_1);
			this.class507_0.BindingAdapter_0.AwareOfDPI(base.method_0());
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
			this.class507_0 = new Class507(this, new Class478());
			this.class507_0.method_10(base.RibbonGroups);
			this.class507_0.method_11(base.RibbonGroups);
			this.class507_0.method_12(base.RibbonGroups);
			this.list_0.Add(this.class507_0.Dictionary_0);
			this.list_0.Add(this.class507_0.Dictionary_1);
			this.list_0.Add(this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items);
		}
	}
}
