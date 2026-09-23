using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl
{
	/// <summary>The ObjectMiniToolbar class is a mini toolbar that appears when the ShowMiniToolbar property is set to MiniToolbarButton.RightButton or MiniToolbarButton.LeftButton | MiniToolbarButton.RightButton, the right mouse button is released and the current context is a selected text frame, drawing frame or barcode frame (ContextMenuLocation.SelectedFrame).</summary>
	public class ObjectMiniToolbar : MiniToolbar
	{
		/// <summary>Each RibbonItem represents an item in a ObjectMiniToolbar.</summary>
		public enum RibbonItem
		{
			/// <summary>Identifies the BordersandBackground group for the selected text frame.</summary>
			TXITEM_TextFrame_BordersandBackgroundGroup,
			/// <summary>Identifies the Back Color button for the selected text frame.</summary>
			TXITEM_TextFrameBackColor,
			/// <summary>Identifies the Line Width button for the selected text frame.</summary>
			TXITEM_TextFrameLineWidth,
			/// <summary>Identifies the Transparency button for the selected text frame.</summary>
			TXITEM_TextFrameTransparency,
			/// <summary>Identifies the BordersandBackground group for the selected drawing frame.</summary>
			TXITEM_Drawing_BordersandBackgroundGroup,
			/// <summary>Identifies the Back Color button for the selected drawing frame.</summary>
			TXITEM_DrawingBackColor,
			/// <summary>Identifies the Transparency button for the selected drawing frame.</summary>
			TXITEM_DrawingTransparency,
			/// <summary>Identifies the Line Color button for the selected drawing frame.</summary>
			TXITEM_DrawingLineColor,
			/// <summary>Identifies the Line Width button for the selected drawing frame.</summary>
			TXITEM_DrawingLineWidth,
			/// <summary>Identifies the ColorsAndAlignment group for the selected barcode frame.</summary>
			TXITEM_Barcode_ColorsAndAlignmentGroup,
			/// <summary>Identifies the Back Color button for the selected barcode frame.</summary>
			TXITEM_BarcodeBackColor,
			/// <summary>Identifies the Fore Color button for the selected barcode frame.</summary>
			TXITEM_BarcodeForeColor,
			/// <summary>Identifies the Transparency button for the selected barcode frame.</summary>
			TXITEM_BarcodeTransparency
		}

		private Class505 class505_0;

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private List<Dictionary<string, object>> list_0 = new List<Dictionary<string, object>>();

		internal ObjectMiniToolbar(TextControl textControl)
		{
			this.method_7(textControl);
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

		internal override void vmethod_0(PointF pointF_1)
		{
			base.vmethod_0(pointF_1);
			if (this.class505_0 != null)
			{
				this.class505_0.BindingAdapter_0.AwareOfDPI_MiniToolbar(pointF_1);
			}
		}

		private void method_7(TextControl textControl_0)
		{
			base.m_txTextControl = textControl_0;
			this.class505_0 = new Class505(this, new Class476
			{
				TextControl = base.m_txTextControl
			});
			this.class505_0.method_19(base.RibbonGroups);
			this.list_0.Add(this.class505_0.TXITEM_TextFrame_BordersandBackgroundGroup_Items);
			this.class505_0.method_20(base.RibbonGroups);
			this.list_0.Add(this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items);
			this.class505_0.method_21(base.RibbonGroups);
			this.list_0.Add(this.class505_0.TXITEM_Barcode_ColorsAndAlignmentGroup_Items);
		}

		internal void method_8(FrameBase frameBase_0)
		{
			if (frameBase_0 != null)
			{
				Class476 @class = this.class505_0.BindingAdapter_0 as Class476;
				@class.method_16(frameBase_0);
			}
		}
	}
}
