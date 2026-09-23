using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonReferencesTab class represents a Windows Forms ribbon tab for creating and editing tables of contents.</summary>
	[ToolboxBitmap(typeof(RibbonReferencesTab))]
	public class RibbonReferencesTab : RibbonTab
	{
		/// <summary>Each RibbonItem represents an item in the RibbonReferencesTab that is not a drop-down item.</summary>
		public enum RibbonItem
		{
			/// <summary>Identifies the TXITEM_TableOfContentsGroup ribbon group inside the RibbonReferencesTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_TableOfContentsGroup,
			/// <summary>Identifies the TXITEM_InsertTableOfContents ribbon item inside the TXITEM_TableOfContentsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertTableOfContents,
			/// <summary>Identifies the TXITEM_DeleteTableOfContents ribbon item inside the TXITEM_TableOfContentsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DeleteTableOfContents,
			/// <summary>Identifies the TXITEM_UpdateTableOfContents ribbon item inside the TXITEM_TableOfContentsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_UpdateTableOfContents,
			/// <summary>Identifies the TXITEM_ModifyTableOfContents ribbon item inside the TXITEM_TableOfContentsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ModifyTableOfContents,
			/// <summary>Identifies the TXITEM_TableOfContentsPropertiesGroup ribbon group inside the RibbonReferencesTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_TableOfContentsPropertiesGroup,
			/// <summary>Identifies the TXITEM_TOCMinimumStructureLevel ribbon item inside the TXITEM_TableOfContentsPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TOCMinimumStructureLevel,
			/// <summary>Identifies the TXITEM_TOCMaximumStructureLevel ribbon item inside the TXITEM_TableOfContentsPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TOCMaximumStructureLevel,
			/// <summary>Identifies the TXITEM_TOCCreateHyperlinks ribbon item inside the TXITEM_TableOfContentsPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TOCCreateHyperlinks,
			/// <summary>Identifies the TXITEM_TOCTitle ribbon item inside the TXITEM_TableOfContentsPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TOCTitle,
			/// <summary>Identifies the TXITEM_TOCShowPageNumbers ribbon item inside the TXITEM_TableOfContentsPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TOCShowPageNumbers,
			/// <summary>Identifies the TXITEM_TOCRightAlignPageNumbers ribbon item inside the TXITEM_TableOfContentsPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TOCRightAlignPageNumbers,
			/// <summary>Identifies the TXITEM_ParagraphStructureLevelsGroup ribbon group inside the RibbonReferencesTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_ParagraphStructureLevelsGroup,
			/// <summary>Identifies the TXITEM_StructureLevelStyles ribbon item inside the TXITEM_ParagraphStructureLevelsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding KeyTip resource.</summary>
			TXITEM_StructureLevelStyles,
			/// <summary>Identifies the TXITEM_AddParagraph ribbon item inside the TXITEM_ParagraphStructureLevelsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_AddParagraph
		}

		/// <summary>Each RibbonDropDownItem represents a drop-down item in the RibbonReferencesTab.</summary>
		public enum RibbonDropDownItem
		{
			/// <summary>Identifies the TXITEM_AddParagraphBodyText drop-down item inside the TXITEM_AddParagraph's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_AddParagraphBodyText,
			/// <summary>Identifies the TXITEM_AddParagraphLevel1 drop-down item inside the TXITEM_AddParagraph's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_AddParagraphLevel1,
			/// <summary>Identifies the TXITEM_AddParagraphLevel2 drop-down item inside the TXITEM_AddParagraph's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_AddParagraphLevel2,
			/// <summary>Identifies the TXITEM_AddParagraphLevel3 drop-down item inside the TXITEM_AddParagraph's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_AddParagraphLevel3,
			/// <summary>Identifies the TXITEM_AddParagraphLevel4 drop-down item inside the TXITEM_AddParagraph's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_AddParagraphLevel4,
			/// <summary>Identifies the TXITEM_AddParagraphLevel5 drop-down item inside the TXITEM_AddParagraph's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_AddParagraphLevel5,
			/// <summary>Identifies the TXITEM_AddParagraphLevel6 drop-down item inside the TXITEM_AddParagraph's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_AddParagraphLevel6,
			/// <summary>Identifies the TXITEM_AddParagraphLevel7 drop-down item inside the TXITEM_AddParagraph's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_AddParagraphLevel7,
			/// <summary>Identifies the TXITEM_AddParagraphLevel8 drop-down item inside the TXITEM_AddParagraph's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_AddParagraphLevel8,
			/// <summary>Identifies the TXITEM_AddParagraphLevel9 drop-down item inside the TXITEM_AddParagraph's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_AddParagraphLevel9,
			/// <summary>Identifies the TXITEM_AddParagraphLevel10 drop-down item inside the TXITEM_AddParagraph's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_AddParagraphLevel10
		}

		internal enum InternalRibbonItem
		{
			TXITEM_TableOfContentsGroup,
			TXITEM_InsertTableOfContents,
			TXITEM_DeleteTableOfContents,
			TXITEM_UpdateTableOfContents,
			TXITEM_ModifyTableOfContents,
			TXITEM_TableOfContentsPropertiesGroup,
			TXITEM_TOCMinimumStructureLevel,
			TXITEM_TOCMaximumStructureLevel,
			TXITEM_TOCCreateHyperlinks,
			TXITEM_TOCTitle,
			TXITEM_TOCShowPageNumbers,
			TXITEM_TOCRightAlignPageNumbers,
			TXITEM_ParagraphStructureLevelsGroup,
			TXITEM_StructureLevelStyles,
			TXITEM_AddParagraph,
			TXITEM_AddParagraphBodyText,
			TXITEM_AddParagraphLevel1,
			TXITEM_AddParagraphLevel2,
			TXITEM_AddParagraphLevel3,
			TXITEM_AddParagraphLevel4,
			TXITEM_AddParagraphLevel5,
			TXITEM_AddParagraphLevel6,
			TXITEM_AddParagraphLevel7,
			TXITEM_AddParagraphLevel8,
			TXITEM_AddParagraphLevel9,
			TXITEM_AddParagraphLevel10
		}

		private Class510 class510_0;

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
					return this.resourceManager_0.GetString("KEYTIP_ReferencesTab");
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
					return this.resourceManager_0.GetString("HEADER_RibbonReferencesTab");
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
					this.class510_0.BindingAdapter_0.OnDisconnectingTextControl();
				}
				TextControl textControl3 = (base.TextControl_0 = (this.class510_0.BindingAdapter_0.TextControl = value));
				if (base.TextControl_0 != null)
				{
					this.class510_0.BindingAdapter_0.OnTextControlConnected();
					if (this.class510_0.Boolean_0)
					{
						this.vmethod_0();
					}
				}
				this.class510_0.method_5();
			}
		}

		/// <summary>Initializes a new instance of the RibbonReferencesTab class.</summary>
		public RibbonReferencesTab()
		{
			this.method_2();
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			PointF dpi = base.method_0();
			this.class510_0.BindingAdapter_0.AwareOfDPI(dpi);
			base.OnHandleCreated(eventArgs_0);
		}

		internal override void vmethod_0(params object[] object_0)
		{
			this.class510_0.BindingAdapter_0.UpdateRibbonTab();
		}

		internal override void vmethod_1(uint uint_1)
		{
			base.vmethod_1(uint_1);
			this.class510_0.BindingAdapter_0.AwareOfDPI(base.method_0());
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
			this.class510_0 = new Class510(this, new Class481());
			this.class510_0.method_10(base.RibbonGroups);
			this.class510_0.method_11(base.RibbonGroups);
			this.class510_0.method_12(base.RibbonGroups);
			this.list_0.Add(this.class510_0.TXITEM_TableOfContentsGroup_Items);
			this.list_0.Add(this.class510_0.TXITEM_TableOfContentsPropertiesGroup_Items);
			this.list_0.Add(this.class510_0.TXITEM_ParagraphStructureLevelsGroup_Items);
		}
	}
}
