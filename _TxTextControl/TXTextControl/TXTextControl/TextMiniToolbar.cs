using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl
{
	/// <summary>The TextMiniToolbar class is a mini toolbar that appears when ShowMiniToolbar property is set to MiniToolbarButton.LeftButton, MiniToolbarButton.RightButton or MiniToolbarButton.LeftButton | MiniToolbarButton.RightButton, the left or right mouse button is released and the current context is selected text (ContextMenuLocation.TextSelection), text at the input position (ContextMenuLocation.TextInputPosition) or an input position inside a table (ContextMenuLocation.Table).</summary>
	public class TextMiniToolbar : MiniToolbar
	{
		/// <summary>Each RibbonItem represents an item in a TextMiniToolbar.</summary>
		public enum RibbonItem
		{
			/// <summary>Identifies the Font group of the TextMiniToolbar.</summary>
			TXITEM_FontGroup,
			/// <summary>Identifies the FontFamily combobox of the TextMiniToolbar.</summary>
			TXITEM_FontFamily,
			/// <summary>Identifies the FontSize combobox of the TextMiniToolbar.</summary>
			TXITEM_FontSize,
			/// <summary>Identifies the IncreaseFont button of the TextMiniToolbar.</summary>
			TXITEM_IncreaseFont,
			/// <summary>Identifies the DecreaseFont button of the TextMiniToolbar.</summary>
			TXITEM_DecreaseFont,
			/// <summary>Identifies the BulletedList button of the TextMiniToolbar.</summary>
			TXITEM_BulletedList,
			/// <summary>Identifies the NumberedList button of the TextMiniToolbar.</summary>
			TXITEM_NumberedList,
			/// <summary>Identifies the StructuredList button of the TextMiniToolbar.</summary>
			TXITEM_StructuredList,
			/// <summary>Identifies the Bold button of the TextMiniToolbar.</summary>
			TXITEM_Bold,
			/// <summary>Identifies the Italic button of the TextMiniToolbar.</summary>
			TXITEM_Italic,
			/// <summary>Identifies the Underline button of the TextMiniToolbar.</summary>
			TXITEM_Underline,
			/// <summary>Identifies the TextBackColor button of the TextMiniToolbar.</summary>
			TXITEM_TextBackColor,
			/// <summary>Identifies the TextColor button of the TextMiniToolbar.</summary>
			TXITEM_TextColor,
			/// <summary>Identifies the LeftAligned button of the TextMiniToolbar.</summary>
			TXITEM_LeftAligned,
			/// <summary>Identifies the Centered button of the TextMiniToolbar.</summary>
			TXITEM_Centered,
			/// <summary>Identifies the RightAligned button of the TextMiniToolbar.</summary>
			TXITEM_RightAligned,
			/// <summary>Identifies the Justified button of the TextMiniToolbar.</summary>
			TXITEM_Justified,
			/// <summary>Identifies the ClearFormatting button of the TextMiniToolbar.</summary>
			TXITEM_ClearFormatting,
			/// <summary>Identifies the Styles group of the TextMiniToolbar.</summary>
			TXITEM_StylesGroup,
			/// <summary>Identifies the StyleName gallery of the TextMiniToolbar.</summary>
			TXITEM_StyleName,
			/// <summary>Identifies the TableLayout group of the TextMiniToolbar.</summary>
			TXITEM_TableLayoutGroup,
			/// <summary>Identifies the TableSelect button of the TextMiniToolbar.</summary>
			TXITEM_TableSelect,
			/// <summary>Identifies the TableMergeCells button of the TextMiniToolbar.</summary>
			TXITEM_TableMergeCells,
			/// <summary>Identifies the TableDelete button of the TextMiniToolbar.</summary>
			TXITEM_TableDelete,
			/// <summary>Identifies the TableInsert button of the TextMiniToolbar.</summary>
			TXITEM_TableInsert,
			/// <summary>Identifies the TableSplitCells button of the TextMiniToolbar.</summary>
			TXITEM_TableSplitCells
		}

		internal enum InternalRibbonItem
		{
			TXITEM_StyleNameGallery,
			TXITEM_TableSelect,
			TXITEM_TableMergeCells,
			TXITEM_TableDelete,
			TXITEM_TableInsert,
			TXITEM_TableSplitCells
		}

		private Class502 class502_0;

		private Class512 class512_0;

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private List<Dictionary<string, object>> list_0 = new List<Dictionary<string, object>>();

		internal TextMiniToolbar(TextControl textControl)
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
			if (this.class502_0 != null)
			{
				this.class502_0.BindingAdapter_0.AwareOfDPI_MiniToolbar(pointF_1);
			}
		}

		private void method_7(TextControl textControl_0)
		{
			base.m_txTextControl = textControl_0;
			this.class502_0 = new Class502(this, new Class473(this)
			{
				TextControl = base.m_txTextControl
			});
			this.class502_0.method_16(base.RibbonGroups);
			(this.class502_0.BindingAdapter_0 as Class473).method_21();
			this.list_0.Add(this.class502_0.TXITEM_FontGroup_Items);
			this.class502_0.method_17(base.RibbonGroups);
			this.class502_0.method_18();
			this.list_0.Add(this.class502_0.TXITEM_StylesGroup_Items);
			this.class512_0 = new Class512(this, new Class483
			{
				TextControl = base.m_txTextControl
			});
			this.class512_0.method_15(base.RibbonGroups);
			this.class512_0.BindingAdapter_0.TextControl = base.m_txTextControl;
			this.list_0.Add(this.class512_0.TXITEM_TableLayoutGroup_Items);
			this.class502_0.BindingAdapter_0.TextControl.PropertyChanged += this.class502_0.vmethod_0;
		}

		internal void method_8(ContextMenuLocation contextMenuLocation_0)
		{
			(this.class502_0.BindingAdapter_0 as Class473).method_22();
			Table table = (((contextMenuLocation_0 & ContextMenuLocation.Table) != 0) ? base.m_txTextControl.Tables.GetItem() : null);
			if (table != null)
			{
				(this.class512_0.TXITEM_TableLayoutGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLayoutGroup.ToString()] as RibbonGroup).Visible = true;
				(this.class502_0.TXITEM_StylesGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_StylesGroup.ToString()] as RibbonGroup).Visible = false;
				(this.class512_0.BindingAdapter_0 as Class483).method_85(table);
			}
			else
			{
				(this.class512_0.TXITEM_TableLayoutGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLayoutGroup.ToString()] as RibbonGroup).Visible = false;
				(this.class502_0.TXITEM_StylesGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_StylesGroup.ToString()] as RibbonGroup).Visible = true;
			}
		}
	}
}
