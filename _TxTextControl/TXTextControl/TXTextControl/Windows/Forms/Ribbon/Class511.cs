using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class511 : Class500
	{
		private Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_1 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_2 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_3 = new Dictionary<string, object>();

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_DataSourceGroup_Items => this.dictionary_0;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_MergeFieldsGroup_Items => this.dictionary_1;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_MergeBlocksGroup_Items => this.dictionary_2;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_ViewGroup_Items => this.dictionary_3;

		internal Class511(Control control_1, BindingAdapter bindingAdapter_1)
			: base(control_1, bindingAdapter_1)
		{
		}

		internal void method_10(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_0, ribbonGroup, RibbonReportingTab.InternalRibbonItem.TXITEM_DataSourceGroup.ToString(), null, null);
			RibbonSplitButton ribbonSplitButton = new RibbonSplitButton();
			ribbonSplitButton.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_DataSource.ToString();
			RibbonSplitButton ribbonSplitButton2 = ribbonSplitButton;
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_SelectMasterTable.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_EditDataRelations.ToString();
			ribbonButton.Enabled = false;
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_ConfigFile.ToString();
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonSplitButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonMenuButton4, null, hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[4] { ribbonSplitButton2, ribbonMenuButton2, ribbonButton2, ribbonMenuButton4 });
			Class517.smethod_29(this.dictionary_0);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_11(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_1, ribbonGroup, RibbonReportingTab.InternalRibbonItem.TXITEM_MergeFieldsGroup.ToString(), null, null);
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeField.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_InsertSpecialField.ToString();
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_FieldProperties.ToString();
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_DeleteField.ToString();
			RibbonButton ribbonButton4 = ribbonButton3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonMenuButton4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton4, "Click", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[4] { ribbonMenuButton2, ribbonMenuButton4, ribbonButton2, ribbonButton4 });
			base.list_0.AddRange(new IEnabledItem[3] { ribbonMenuButton4, ribbonButton2, ribbonButton4 });
			Class517.smethod_29(this.dictionary_1);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_12(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_2, ribbonGroup, RibbonReportingTab.InternalRibbonItem.TXITEM_MergeBlocksGroup.ToString(), null, null);
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeBlock.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_EditMergeBlocks.ToString();
			RibbonButton ribbonButton2 = ribbonButton;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonButton2, "Click", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[2] { ribbonMenuButton2, ribbonButton2 });
			base.list_0.Add(ribbonButton2);
			Class517.smethod_29(this.dictionary_2);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_13(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_3, ribbonGroup, RibbonReportingTab.InternalRibbonItem.TXITEM_ViewGroup.ToString(), null, null);
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_ShowFieldCodes.ToString();
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_ShowFieldText.ToString();
			ribbonToggleButton3.Checked = true;
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			RibbonToggleButton ribbonToggleButton5 = new RibbonToggleButton();
			ribbonToggleButton5.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_FieldNavigation.ToString();
			ribbonToggleButton5.Visible = false;
			RibbonToggleButton ribbonToggleButton6 = ribbonToggleButton5;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonToggleButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonToggleButton4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonToggleButton6, "CheckedChanged", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[3] { ribbonToggleButton2, ribbonToggleButton4, ribbonToggleButton6 });
			Class517.smethod_29(this.dictionary_3);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal override void vmethod_0(object sender, PropertyChangedEventArgs e)
		{
			base.vmethod_0(sender, e);
			if (e.PropertyName == "CanEdit")
			{
				(base.bindingAdapter_0 as Class482).method_39();
			}
		}
	}
}
