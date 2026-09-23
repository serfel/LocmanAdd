using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using ns21;
using TXTextControl.Windows.Forms.Ribbon;
using DocumentServer.DataSources;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonReportingTab class represents a Windows Forms ribbon tab to integrate mail merge and reporting functionality.</summary>
	[ToolboxBitmap(typeof(RibbonReportingTab))]
	public class RibbonReportingTab : RibbonTab
	{
		/// <summary>Each RibbonItem represents an item in the RibbonReportingTab that is not a drop-down item.</summary>
		public enum RibbonItem
		{
			/// <summary>Identifies the TXITEM_DataSourceGroup ribbon group inside the RibbonReportingTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_DataSourceGroup,
			/// <summary>Identifies the TXITEM_DataSource ribbon item inside the TXITEM_DataSourceGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DataSource,
			/// <summary>Identifies the TXITEM_SelectMasterTable ribbon item inside the TXITEM_DataSourceGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_SelectMasterTable,
			/// <summary>Identifies the TXITEM_EditDataRelations ribbon item inside the TXITEM_DataSourceGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_EditDataRelations,
			/// <summary>Identifies the TXITEM_ConfigFile ribbon item inside the TXITEM_DataSourceGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ConfigFile,
			/// <summary>Identifies the TXITEM_MergeFieldsGroup ribbon group inside the RibbonReportingTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_MergeFieldsGroup,
			/// <summary>Identifies the TXITEM_InsertMergeField ribbon item inside the TXITEM_MergeFieldsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertMergeField,
			/// <summary>Identifies the TXITEM_InsertSpecialField ribbon item inside the TXITEM_MergeFieldsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertSpecialField,
			/// <summary>Identifies the TXITEM_FieldProperties ribbon item inside the TXITEM_MergeFieldsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_FieldProperties,
			/// <summary>Identifies the TXITEM_DeleteField ribbon item inside the TXITEM_MergeFieldsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DeleteField,
			/// <summary>Identifies the TXITEM_MergeBlocksGroup ribbon group inside the RibbonReportingTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_MergeBlocksGroup,
			/// <summary>Identifies the TXITEM_InsertMergeBlock ribbon item inside the TXITEM_MergeBlocksGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertMergeBlock,
			/// <summary>Identifies the TXITEM_EditMergeBlocks ribbon item inside the TXITEM_MergeBlocksGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_EditMergeBlocks,
			/// <summary>Identifies the TXITEM_ViewGroup ribbon group inside the RibbonReportingTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_ViewGroup,
			/// <summary>Identifies the TXITEM_ShowFieldCodes ribbon item inside the TXITEM_ViewGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ShowFieldCodes,
			/// <summary>Identifies the TXITEM_ShowFieldText ribbon item inside the TXITEM_ViewGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ShowFieldText,
			/// <summary>Identifies the TXITEM_FieldNavigation ribbon item inside the TXITEM_ViewGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_FieldNavigation
		}

		/// <summary>Each RibbonDropDownItem represents a drop-down item in the RibbonReportingTab.</summary>
		public enum RibbonDropDownItem
		{
			/// <summary>Identifies the TXITEM_DataSource_DataSource drop-down item inside the TXITEM_DataSource's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_DataSource_DataSource,
			/// <summary>Identifies the TXITEM_DataSource_LoadXMLFile drop-down item inside the TXITEM_DataSource's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_DataSource_LoadXMLFile,
			/// <summary>Identifies the TXITEM_DataSource_LoadAssembly drop-down item inside the TXITEM_DataSource's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_DataSource_LoadAssembly,
			/// <summary>Identifies the TXITEM_DataSource_LoadJSON drop-down item inside the TXITEM_DataSource's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_DataSource_LoadJSON,
			/// <summary>Identifies the TXITEM_DataSource_SaveExcerpt drop-down item inside the TXITEM_DataSource's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_DataSource_SaveExcerpt,
			/// <summary>Identifies the TXITEM_SelectMasterTable_TablesHeader drop-down item inside the TXITEM_SelectMasterTable's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_SelectMasterTable_TablesHeader,
			/// <summary>Identifies the TXITEM_ConfigFile_LoadConfiguration drop-down item inside the TXITEM_ConfigFile's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_ConfigFile_LoadConfiguration,
			/// <summary>Identifies the TXITEM_ConfigFile_SaveConfiguration drop-down item inside the TXITEM_ConfigFile's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_ConfigFile_SaveConfiguration,
			/// <summary>Identifies the TXITEM_InsertMergeField_TablesHeader drop-down item inside the TXITEM_InsertMergeField's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_InsertMergeField_TablesHeader,
			/// <summary>Identifies the TXITEM_InsertMergeField_InsertCustomMergeField drop-down item inside the TXITEM_InsertMergeField's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_InsertMergeField_InsertCustomMergeField,
			/// <summary>Identifies the TXITEM_InsertMergeField_HighlightMergeFields drop-down item inside the TXITEM_InsertMergeField's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_InsertMergeField_HighlightMergeFields,
			/// <summary>Identifies the TXITEM_InsertSpecialField_IF drop-down item inside the TXITEM_InsertSpecialField's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_InsertSpecialField_IF,
			/// <summary>Identifies the TXITEM_InsertSpecialField_IncludeText drop-down item inside the TXITEM_InsertSpecialField's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_InsertSpecialField_IncludeText,
			/// <summary>Identifies the TXITEM_InsertSpecialField_Date drop-down item inside the TXITEM_InsertSpecialField's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_InsertSpecialField_Date,
			/// <summary>Identifies the TXITEM_InsertSpecialField_Next drop-down item inside the TXITEM_InsertSpecialField's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_InsertSpecialField_Next,
			/// <summary>Identifies the TXITEM_InsertSpecialField_NextIf drop-down item inside the TXITEM_InsertSpecialField's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_InsertSpecialField_NextIf,
			/// <summary>Identifies the TXITEM_InsertMergeBlock_TablesHeader drop-down item inside the TXITEM_InsertMergeBlock's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_InsertMergeBlock_TablesHeader,
			/// <summary>Identifies the TXITEM_InsertMergeBlock_InsertCustomMergeBlock drop-down item inside the TXITEM_InsertMergeBlock's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_InsertMergeBlock_InsertCustomMergeBlock,
			/// <summary>Identifies the TXITEM_InsertMergeBlock_HighlightMergeBlocks drop-down item inside the TXITEM_InsertMergeBlock's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_InsertMergeBlock_HighlightMergeBlocks
		}

		internal enum InternalRibbonItem
		{
			TXITEM_DataSourceGroup,
			TXITEM_DataSource,
			TXITEM_DataSource_DataSource,
			TXITEM_DataSource_LoadXMLFile,
			TXITEM_DataSource_LoadAssembly,
			TXITEM_DataSource_LoadJSON,
			TXITEM_DataSource_Seperator1,
			TXITEM_DataSource_SaveExcerpt,
			TXITEM_SelectMasterTable,
			TXITEM_SelectMasterTable_TablesHeader,
			TXITEM_SelectMasterTable_Seperator1,
			TXITEM_EditDataRelations,
			TXITEM_ConfigFile,
			TXITEM_ConfigFile_LoadConfiguration,
			TXITEM_ConfigFile_SaveConfiguration,
			TXITEM_MergeFieldsGroup,
			TXITEM_InsertMergeField,
			TXITEM_InsertMergeField_TablesHeader,
			TXITEM_InsertMergeField_Seperator1,
			TXITEM_InsertMergeField_Seperator2,
			TXITEM_InsertMergeField_InsertCustomMergeField,
			TXITEM_InsertMergeField_HighlightMergeFields,
			TXITEM_InsertSpecialField,
			TXITEM_InsertSpecialField_IF,
			TXITEM_InsertSpecialField_IncludeText,
			TXITEM_InsertSpecialField_Date,
			TXITEM_InsertSpecialField_Next,
			TXITEM_InsertSpecialField_NextIf,
			TXITEM_FieldProperties,
			TXITEM_DeleteField,
			TXITEM_MergeBlocksGroup,
			TXITEM_InsertMergeBlock,
			TXITEM_InsertMergeBlock_TablesHeader,
			TXITEM_InsertMergeBlock_Seperator1,
			TXITEM_InsertMergeBlock_Seperator2,
			TXITEM_InsertMergeBlock_InsertCustomMergeBlock,
			TXITEM_InsertMergeBlock_HighlightMergeBlocks,
			TXITEM_EditMergeBlocks,
			TXITEM_ViewGroup,
			TXITEM_ShowFieldCodes,
			TXITEM_ShowFieldText,
			TXITEM_FieldNavigation
		}

		private Class511 class511_0;

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private List<Dictionary<string, object>> list_0 = new List<Dictionary<string, object>>();

		private Sidebar sidebar_0;

		/// <summary>Provides the DataSourceManager that is connected with the RibbonReportingTab.</summary>
		[CLSCompliant(false)]
		public DataSourceManager DataSourceManager => (this.class511_0.BindingAdapter_0 as Class482).DataSourceManager_0;

		/// <summary>Gets or sets the sidebar that is connected to the RibbonReportingTab's TXITEM_FieldNavigation button.</summary>
		[Attribute3("PROP_FIELDNAVIGATORSIDEBAR")]
		[Category("Behavior")]
		[DefaultValue(null)]
		public Sidebar FieldNavigatorSidebar
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
					(this.class511_0.BindingAdapter_0 as Class482).method_55(sidebar);
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
					return this.resourceManager_0.GetString("KEYTIP_ReportingTab");
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
					return this.resourceManager_0.GetString("HEADER_RibbonReportingTab");
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
					this.class511_0.BindingAdapter_0.OnDisconnectingTextControl();
					this.class511_0.BindingAdapter_0.TextControl.PropertyChanged -= this.class511_0.vmethod_0;
				}
				TextControl textControl3 = (base.TextControl_0 = ((this.class511_0.BindingAdapter_0 as Class482).TextControl = value));
				if (this.sidebar_0 != null)
				{
					this.sidebar_0.TextControl = value;
				}
				if (base.TextControl_0 != null)
				{
					this.class511_0.BindingAdapter_0.OnTextControlConnected();
					if (this.class511_0.Boolean_0)
					{
						this.vmethod_0();
					}
					this.class511_0.BindingAdapter_0.TextControl.PropertyChanged += this.class511_0.vmethod_0;
				}
				this.class511_0.method_5();
				(this.class511_0.BindingAdapter_0 as Class482).method_55(null);
			}
		}

		/// <summary>Initializes a new instance of the RibbonReportingTab class.</summary>
		public RibbonReportingTab()
		{
			this.method_2();
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			PointF dpi = base.method_0();
			this.class511_0.BindingAdapter_0.AwareOfDPI(dpi);
			base.OnHandleCreated(eventArgs_0);
		}

		internal override void vmethod_0(params object[] object_0)
		{
			this.class511_0.BindingAdapter_0.UpdateRibbonTab();
		}

		internal override void vmethod_1(uint uint_1)
		{
			base.vmethod_1(uint_1);
			this.class511_0.BindingAdapter_0.AwareOfDPI(base.method_0());
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
			this.class511_0 = new Class511(this, new Class482());
			this.class511_0.method_10(base.RibbonGroups);
			this.class511_0.method_11(base.RibbonGroups);
			this.class511_0.method_12(base.RibbonGroups);
			this.class511_0.method_13(base.RibbonGroups);
			this.list_0.Add(this.class511_0.TXITEM_DataSourceGroup_Items);
			this.list_0.Add(this.class511_0.TXITEM_MergeFieldsGroup_Items);
			this.list_0.Add(this.class511_0.TXITEM_MergeBlocksGroup_Items);
			this.list_0.Add(this.class511_0.TXITEM_ViewGroup_Items);
		}
	}
}
