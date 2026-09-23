using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class508 : Class500
	{
		private Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_1 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_2 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_3 = new Dictionary<string, object>();

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_RestrictFormattingGroup_Items => this.dictionary_0;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_RestrictEditingGroup_Items => this.dictionary_1;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_ReadOnlyExceptionsGroup_Items => this.dictionary_2;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_EditRestrictedDocumentGroup_Items => this.dictionary_3;

		internal Class508(Control control_1, BindingAdapter bindingAdapter_1)
			: base(control_1, bindingAdapter_1)
		{
		}

		internal void method_10(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_0, ribbonGroup, RibbonPermissionsTab.InternalRibbonItem.TXITEM_RestrictFormattingGroup.ToString(), null, null);
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonPermissionsTab.InternalRibbonItem.TXITEM_AllowFormatting.ToString();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonPermissionsTab.InternalRibbonItem.TXITEM_AllowFormattingStyles.ToString();
			ribbonToggleButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonToggleButton2, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonToggleButton4, "CheckedChanged", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[2] { ribbonToggleButton2, ribbonToggleButton4 });
			Class517.smethod_29(this.dictionary_0);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_11(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_1, ribbonGroup, RibbonPermissionsTab.InternalRibbonItem.TXITEM_RestrictEditingGroup.ToString(), null, null);
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonPermissionsTab.InternalRibbonItem.TXITEM_AllowPrinting.ToString();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonPermissionsTab.InternalRibbonItem.TXITEM_AllowCopy.ToString();
			ribbonToggleButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			RibbonToggleButton ribbonToggleButton5 = new RibbonToggleButton();
			ribbonToggleButton5.Name = RibbonPermissionsTab.InternalRibbonItem.TXITEM_FillInFormFields.ToString();
			ribbonToggleButton5.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton6 = ribbonToggleButton5;
			RibbonToggleButton ribbonToggleButton7 = new RibbonToggleButton();
			ribbonToggleButton7.Name = RibbonPermissionsTab.InternalRibbonItem.TXITEM_ReadOnly.ToString();
			RibbonToggleButton ribbonToggleButton8 = ribbonToggleButton7;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonToggleButton2, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonToggleButton4, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonToggleButton6, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonToggleButton8, "CheckedChanged", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[4] { ribbonToggleButton2, ribbonToggleButton4, ribbonToggleButton6, ribbonToggleButton8 });
			Class517.smethod_29(this.dictionary_1);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_12(RibbonGroupCollection ribbonGroupCollection_0)
		{
			HorizontalRibbonGroup horizontalRibbonGroup = new HorizontalRibbonGroup();
			horizontalRibbonGroup.Visible = false;
			HorizontalRibbonGroup horizontalRibbonGroup2 = horizontalRibbonGroup;
			horizontalRibbonGroup2.DialogBoxLauncher.ToolTip.Title = base.resourceManager_0.GetString("TOOLTIPTITLE_AddUsers");
			horizontalRibbonGroup2.DialogBoxLauncher.ToolTip.Description = base.resourceManager_0.GetString("TOOLTIP_AddUsers");
			horizontalRibbonGroup2.DialogBoxLauncher.String_0 = RibbonPermissionsTab.InternalRibbonItem.TXITEM_ReadOnlyExceptionsGroup_DialogBoxLauncher.ToString();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_2, horizontalRibbonGroup2, RibbonPermissionsTab.InternalRibbonItem.TXITEM_ReadOnlyExceptionsGroup.ToString(), "Click", "TXITEM_ReadOnlyExceptionsGroup_Handler");
			RibbonListView ribbonListView = new RibbonListView();
			ribbonListView.Name = RibbonPermissionsTab.InternalRibbonItem.TXITEM_Users.ToString();
			ribbonListView.MaxVisibleRows = 3;
			ribbonListView.MaxColumnCount = 1;
			ribbonListView.MinColumnCount = 1;
			ribbonListView.MinRowCount = 3;
			ribbonListView.MultiSelect = true;
			ribbonListView.Deselectable = true;
			ribbonListView.ViewMode = (RibbonListView.ListViewMode)3;
			ribbonListView.ShowBorder = true;
			ribbonListView.ShowItemsInDropDown = true;
			ribbonListView.Boolean_3 = false;
			ribbonListView.Boolean_4 = true;
			RibbonListView ribbonListView2 = ribbonListView;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonListView2, null, hasImage: false);
			horizontalRibbonGroup2.RibbonItems.Add(ribbonListView2);
			Class517.smethod_29(this.dictionary_2);
			ribbonGroupCollection_0.Add(horizontalRibbonGroup2);
		}

		internal void method_13(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_3, ribbonGroup, RibbonPermissionsTab.InternalRibbonItem.TXITEM_EditRestrictedDocumentGroup.ToString(), null, null);
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonPermissionsTab.InternalRibbonItem.TXITEM_EnforceProtection.ToString();
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonPermissionsTab.InternalRibbonItem.TXITEM_HighlightEditableRegions.ToString();
			ribbonToggleButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			ribbonToggleButton3.Checked = true;
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonPermissionsTab.InternalRibbonItem.TXITEM_PreviousEditableRegion.ToString();
			ribbonButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonPermissionsTab.InternalRibbonItem.TXITEM_NextEditableRegion.ToString();
			ribbonButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonButton ribbonButton4 = ribbonButton3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonToggleButton2, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonToggleButton4, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonButton4, "Click", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[4] { ribbonToggleButton2, ribbonToggleButton4, ribbonButton2, ribbonButton4 });
			Class517.smethod_29(this.dictionary_3);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal override void vmethod_0(object sender, PropertyChangedEventArgs e)
		{
			string propertyName;
			if ((propertyName = e.PropertyName) != null && propertyName == "EditMode")
			{
				(base.bindingAdapter_0 as Class479).method_18();
			}
		}
	}
}
