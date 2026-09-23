using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonPermissionsTab class represents a Windows Forms ribbon tab for determining how the document can be edited, when it is enforced to be protected.</summary>
	[ToolboxBitmap(typeof(RibbonPermissionsTab))]
	public class RibbonPermissionsTab : RibbonTab
	{
		/// <summary>Each RibbonItem represents an item in the RibbonPermissionsTab that is not a drop-down item.</summary>
		public enum RibbonItem
		{
			/// <summary>Identifies the TXITEM_RestrictFormattingGroup ribbon group inside the RibbonPermissionsTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_RestrictFormattingGroup,
			/// <summary>Identifies the TXITEM_AllowFormatting ribbon item inside the TXITEM_RestrictFormattingGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_AllowFormatting,
			/// <summary>Identifies the TXITEM_AllowFormattingStyles ribbon item inside the TXITEM_RestrictFormattingGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_AllowFormattingStyles,
			/// <summary>Identifies the TXITEM_RestrictEditingGroup ribbon group inside the RibbonPermissionsTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_RestrictEditingGroup,
			/// <summary>Identifies the TXITEM_AllowPrinting ribbon item inside the TXITEM_RestrictEditingGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_AllowPrinting,
			/// <summary>Identifies the TXITEM_AllowCopy ribbon item inside the TXITEM_RestrictEditingGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_AllowCopy,
			/// <summary>Identifies the TXITEM_FillInFormFields ribbon item inside the TXITEM_RestrictEditingGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_FillInFormFields,
			/// <summary>Identifies the TXITEM_ReadOnly ribbon item inside the TXITEM_RestrictEditingGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ReadOnly,
			/// <summary>Identifies the TXITEM_ReadOnlyExceptionsGroup ribbon group inside the RibbonPermissionsTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_ReadOnlyExceptionsGroup,
			/// <summary>Identifies the dialog box launcher of the TXITEM_ReadOnlyExceptionsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle and ToolTipDescription resources. Limitations: The FindItem method returns null when passing this RibbonItem as an argument.</summary>
			TXITEM_ReadOnlyExceptionsGroup_DialogBoxLauncher,
			/// <summary>Identifies the TXITEM_Users ribbon item inside the TXITEM_ReadOnlyExceptionsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Users,
			/// <summary>Identifies the TXITEM_EditRestrictedDocumentGroup ribbon group inside the RibbonPermissionsTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_EditRestrictedDocumentGroup,
			/// <summary>Identifies the TXITEM_EnforceProtection ribbon item inside the TXITEM_EditRestrictedDocumentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_EnforceProtection,
			/// <summary>Identifies the TXITEM_HighlightEditableRegions ribbon item inside the TXITEM_EditRestrictedDocumentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_HighlightEditableRegions,
			/// <summary>Identifies the TXITEM_PreviousEditableRegion ribbon item inside the TXITEM_EditRestrictedDocumentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_PreviousEditableRegion,
			/// <summary>Identifies the TXITEM_NextEditableRegion ribbon item inside the TXITEM_EditRestrictedDocumentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_NextEditableRegion
		}

		/// <summary>Each RibbonDropDownItem represents a drop-down item in the RibbonPermissionsTab.</summary>
		public enum RibbonDropDownItem
		{
			/// <summary>Identifies the TXITEM_Users_Dialog drop-down item inside the TXITEM_Users's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_Users_Dialog
		}

		internal enum InternalRibbonItem
		{
			TXITEM_RestrictFormattingGroup,
			TXITEM_AllowFormatting,
			TXITEM_AllowFormattingStyles,
			TXITEM_RestrictEditingGroup,
			TXITEM_AllowPrinting,
			TXITEM_AllowCopy,
			TXITEM_FillInFormFields,
			TXITEM_ReadOnly,
			TXITEM_ReadOnlyExceptionsGroup,
			TXITEM_ReadOnlyExceptionsGroup_DialogBoxLauncher,
			TXITEM_Users,
			TXITEM_UsersSeperator1,
			TXITEM_Users_Dialog,
			TXITEM_EditRestrictedDocumentGroup,
			TXITEM_EnforceProtection,
			TXITEM_HighlightEditableRegions,
			TXITEM_PreviousEditableRegion,
			TXITEM_NextEditableRegion
		}

		private Class508 class508_0;

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private List<Dictionary<string, object>> list_0 = new List<Dictionary<string, object>>();

		private string[] string_1 = new string[0];

		private bool bool_3 = true;

		/// <summary>Gets or sets a value indicating whether the user can add user names by the RibbonPermissionsTab's Add Users dialog that are not represented by the RegisteredUserNames property.</summary>
		public bool AllowAddingUserNames
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
			}
		}

		/// <summary>Gets or sets an array of strings that represents those registered user names that can be added by the RibbonPermissionsTab's Add Users dialog.</summary>
		public string[] RegisteredUserNames
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
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
					return this.resourceManager_0.GetString("KEYTIP_PermissionsTab");
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
					return this.resourceManager_0.GetString("HEADER_RibbonPermissionsTab");
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
				if (base.TextControl_0 != null && !base.DesignMode)
				{
					this.class508_0.BindingAdapter_0.OnDisconnectingTextControl();
					this.class508_0.BindingAdapter_0.TextControl.PropertyChanged -= this.class508_0.vmethod_0;
				}
				TextControl textControl3 = (base.TextControl_0 = (this.class508_0.BindingAdapter_0.TextControl = value));
				if (base.TextControl_0 != null && !base.DesignMode)
				{
					(this.class508_0.BindingAdapter_0 as Class479).TextControl.DocumentPermissions.ReadOnly = false;
					this.class508_0.BindingAdapter_0.OnTextControlConnected();
					if (this.class508_0.Boolean_0)
					{
						this.vmethod_0();
					}
					this.class508_0.BindingAdapter_0.TextControl.PropertyChanged += this.class508_0.vmethod_0;
				}
				this.class508_0.method_5();
			}
		}

		/// <summary>Initializes a new instance of the RibbonPermissionsTab class.</summary>
		public RibbonPermissionsTab()
		{
			this.method_2();
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			PointF dpi = base.method_0();
			this.class508_0.BindingAdapter_0.AwareOfDPI(dpi);
			base.OnHandleCreated(eventArgs_0);
		}

		internal override void vmethod_0(params object[] object_0)
		{
			this.class508_0.BindingAdapter_0.UpdateRibbonTab();
		}

		internal override void vmethod_1(uint uint_1)
		{
			base.vmethod_1(uint_1);
			this.class508_0.BindingAdapter_0.AwareOfDPI(base.method_0());
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
			this.class508_0 = new Class508(this, new Class479());
			this.class508_0.method_10(base.RibbonGroups);
			this.class508_0.method_11(base.RibbonGroups);
			this.class508_0.method_12(base.RibbonGroups);
			this.class508_0.method_13(base.RibbonGroups);
			this.list_0.Add(this.class508_0.TXITEM_RestrictFormattingGroup_Items);
			this.list_0.Add(this.class508_0.TXITEM_RestrictEditingGroup_Items);
			this.list_0.Add(this.class508_0.TXITEM_EditRestrictedDocumentGroup_Items);
		}
	}
}
