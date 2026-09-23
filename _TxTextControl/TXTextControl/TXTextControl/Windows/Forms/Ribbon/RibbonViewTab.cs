using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonViewTab class represents a Windows Forms ribbon tab for customizing the view settings.</summary>
	[ToolboxBitmap(typeof(RibbonViewTab))]
	public class RibbonViewTab : RibbonTab
	{
		/// <summary>Each RibbonItem represents an item in the RibbonViewTab that is not a drop-down item.</summary>
		public enum RibbonItem
		{
			/// <summary>Identifies the TXITEM_DocumentViewsGroup ribbon group inside the RibbonViewTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_DocumentViewsGroup,
			/// <summary>Identifies the TXITEM_PrintLayout ribbon item inside the TXITEM_DocumentViewsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_PrintLayout,
			/// <summary>Identifies the TXITEM_Draft ribbon item inside the TXITEM_DocumentViewsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Draft,
			/// <summary>Identifies the TXITEM_ZoomGroup ribbon group inside the RibbonViewTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_ZoomGroup,
			/// <summary>Identifies the TXITEM_ZoomFactor ribbon item inside the TXITEM_ZoomGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ZoomFactor,
			/// <summary>Identifies the TXITEM_Zoom100 ribbon item inside the TXITEM_ZoomGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Zoom100,
			/// <summary>Identifies the TXITEM_FullPage ribbon item inside the TXITEM_ZoomGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_FullPage,
			/// <summary>Identifies the TXITEM_PageWidth ribbon item inside the TXITEM_ZoomGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_PageWidth,
			/// <summary>Identifies the TXITEM_TextWidth ribbon item inside the TXITEM_ZoomGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TextWidth,
			/// <summary>Identifies the TXITEM_ToolbarsGroup ribbon group inside the RibbonViewTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_ToolbarsGroup,
			/// <summary>Identifies the TXITEM_HorizontalRuler ribbon item inside the TXITEM_ToolbarsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_HorizontalRuler,
			/// <summary>Identifies the TXITEM_VerticalRuler ribbon item inside the TXITEM_ToolbarsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_VerticalRuler,
			/// <summary>Identifies the TXITEM_StatusBar ribbon item inside the TXITEM_ToolbarsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_StatusBar,
			/// <summary>Identifies the TXITEM_ShowGroup ribbon group inside the RibbonViewTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_ShowGroup,
			/// <summary>Identifies the TXITEM_ShowTableGridlines ribbon item inside the TXITEM_ShowGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ShowTableGridlines,
			/// <summary>Identifies the TXITEM_ShowBookmarkMarkers ribbon item inside the TXITEM_ShowGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ShowBookmarkMarkers,
			/// <summary>Identifies the TXITEM_ShowTextFrameMarkersLines ribbon item inside the TXITEM_ShowGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ShowTextFrameMarkersLines,
			/// <summary>Identifies the TXITEM_ShowDrawingFrameMarkersLines ribbon item inside the TXITEM_ShowGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ShowDrawingFrameMarkersLines,
			/// <summary>Identifies the TXITEM_ShowControlChars ribbon item inside the TXITEM_ShowGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ShowControlChars,
			/// <summary>Identifies the TXITEM_ShowFrameAnchors ribbon item inside the TXITEM_ShowGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ShowFrameAnchors
		}

		/// <summary>Each RibbonDropDownItem represents a drop-down item in the RibbonViewTab.</summary>
		public enum RibbonDropDownItem
		{
			/// <summary>Identifies the TXITEM_ZoomFactor_25 drop-down item inside the TXITEM_ZoomFactor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ZoomFactor_25,
			/// <summary>Identifies the TXITEM_ZoomFactor_50 drop-down item inside the TXITEM_ZoomFactor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ZoomFactor_50,
			/// <summary>Identifies the TXITEM_ZoomFactor_75 drop-down item inside the TXITEM_ZoomFactor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ZoomFactor_75,
			/// <summary>Identifies the TXITEM_ZoomFactor_100 drop-down item inside the TXITEM_ZoomFactor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ZoomFactor_100,
			/// <summary>Identifies the TXITEM_ZoomFactor_150 drop-down item inside the TXITEM_ZoomFactor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ZoomFactor_150,
			/// <summary>Identifies the TXITEM_ZoomFactor_200 drop-down item inside the TXITEM_ZoomFactor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ZoomFactor_200,
			/// <summary>Identifies the TXITEM_ZoomFactor_400 drop-down item inside the TXITEM_ZoomFactor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ZoomFactor_400
		}

		internal enum InternalRibbonItem
		{
			TXITEM_DocumentViewsGroup,
			TXITEM_PrintLayout,
			TXITEM_Draft,
			TXITEM_ZoomGroup,
			TXITEM_ZoomFactor,
			TXITEM_ZoomFactor_25,
			TXITEM_ZoomFactor_50,
			TXITEM_ZoomFactor_75,
			TXITEM_ZoomFactor_100,
			TXITEM_ZoomFactor_150,
			TXITEM_ZoomFactor_200,
			TXITEM_ZoomFactor_400,
			TXITEM_Zoom100,
			TXITEM_FullPage,
			TXITEM_PageWidth,
			TXITEM_TextWidth,
			TXITEM_ToolbarsGroup,
			TXITEM_HorizontalRuler,
			TXITEM_VerticalRuler,
			TXITEM_StatusBar,
			TXITEM_ShowGroup,
			TXITEM_ShowTableGridlines,
			TXITEM_ShowBookmarkMarkers,
			TXITEM_ShowTextFrameMarkersLines,
			TXITEM_ShowDrawingFrameMarkersLines,
			TXITEM_ShowControlChars,
			TXITEM_ShowFrameAnchors
		}

		private Class513 class513_0;

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
					return this.resourceManager_0.GetString("KEYTIP_ViewTab");
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
					return this.resourceManager_0.GetString("HEADER_RibbonViewTab");
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
					this.class513_0.BindingAdapter_0.OnDisconnectingTextControl();
				}
				TextControl textControl3 = (base.TextControl_0 = (this.class513_0.BindingAdapter_0.TextControl = value));
				if (base.TextControl_0 != null)
				{
					this.class513_0.BindingAdapter_0.OnTextControlConnected();
					if (this.class513_0.Boolean_0)
					{
						this.vmethod_0();
					}
				}
				this.class513_0.method_5();
			}
		}

		/// <summary>Initializes a new instance of the RibbonViewTab class.</summary>
		public RibbonViewTab()
		{
			this.method_2();
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			PointF dpi = base.method_0();
			this.class513_0.BindingAdapter_0.AwareOfDPI(dpi);
			base.OnHandleCreated(eventArgs_0);
		}

		internal override void vmethod_0(params object[] object_0)
		{
			this.class513_0.BindingAdapter_0.UpdateRibbonTab();
		}

		internal override void vmethod_1(uint uint_1)
		{
			base.vmethod_1(uint_1);
			this.class513_0.BindingAdapter_0.AwareOfDPI(base.method_0());
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
			this.class513_0 = new Class513(this, new Class484());
			this.class513_0.method_10(base.RibbonGroups);
			this.class513_0.method_11(base.RibbonGroups);
			this.class513_0.method_12(base.RibbonGroups);
			this.class513_0.method_13(base.RibbonGroups);
			this.list_0.Add(this.class513_0.TXITEM_DocumentViewsGroup_Items);
			this.list_0.Add(this.class513_0.TXITEM_ZoomGroup_Items);
			this.list_0.Add(this.class513_0.TXITEM_ToolbarsGroup_Items);
			this.list_0.Add(this.class513_0.TXITEM_ShowGroup_Items);
		}
	}
}
