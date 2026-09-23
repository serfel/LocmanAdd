using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class507 : Class500
	{
		private Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_1 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_2 = new Dictionary<string, object>();

		internal Dictionary<string, object> Dictionary_0 => this.dictionary_0;

		internal Dictionary<string, object> Dictionary_1 => this.dictionary_1;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_PageBackgroundAndBordersGroup_Items => this.dictionary_2;

		internal Class507(Control control_1, BindingAdapter bindingAdapter_1)
			: base(control_1, bindingAdapter_1)
		{
		}

		internal void method_10(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.DialogBoxLauncher.ToolTip.Title = base.resourceManager_0.GetString("TOOLTIPTITLE_MarginsAndPaper");
			ribbonGroup.DialogBoxLauncher.ToolTip.Description = base.resourceManager_0.GetString("TOOLTIP_MarginsAndPaper");
			ribbonGroup.DialogBoxLauncher.String_0 = RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageSetupGroup_DialogBoxLauncher.ToString();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_0, ribbonGroup, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageSetupGroup.ToString(), "Click", "TXITEM_PageSetupGroup_Handler");
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageMargins.ToString();
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Orientation.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageSize.ToString();
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonMenuButton4, null, hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[3] { ribbonButton2, ribbonMenuButton2, ribbonMenuButton4 });
			base.list_2.AddRange(new IEnabledItem[1] { ribbonGroup });
			Class517.smethod_29(this.dictionary_0);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_11(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.DialogBoxLauncher.ToolTip.Title = base.resourceManager_0.GetString("TOOLTIPTITLE_PageLayout_Columns");
			ribbonGroup.DialogBoxLauncher.ToolTip.Description = base.resourceManager_0.GetString("TOOLTIP_PageLayout_Columns");
			ribbonGroup.DialogBoxLauncher.String_0 = RibbonPageLayoutTab.InternalRibbonItem.TXITEM_ColumnsAndBreaksGroup_DialogBoxLauncher.ToString();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_1, ribbonGroup, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_ColumnsAndBreaksGroup.ToString(), "Click", "TXITEM_ColumnsAndBreaksGroup_Handler");
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Columns.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Breaks.ToString();
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonMenuButton4, null, hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[2] { ribbonMenuButton2, ribbonMenuButton4 });
			base.list_2.AddRange(new IEnabledItem[6]
			{
				ribbonMenuButton2,
				ribbonGroup.DialogBoxLauncher,
				this.dictionary_1[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Breaks_SectionBreaks.ToString()] as IEnabledItem,
				this.dictionary_1[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Breaks_Seperator2.ToString()] as IEnabledItem,
				this.dictionary_1[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Breaks_NextPage.ToString()] as IEnabledItem,
				this.dictionary_1[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Breaks_Continuous.ToString()] as IEnabledItem
			});
			base.list_0.Add(ribbonMenuButton4);
			Class517.smethod_29(this.dictionary_1);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_12(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.DialogBoxLauncher.ToolTip.Title = base.resourceManager_0.GetString("TOOLTIPTITLE_PageLayout_Frames");
			ribbonGroup.DialogBoxLauncher.ToolTip.Description = base.resourceManager_0.GetString("TOOLTIP_PageLayout_Frames");
			ribbonGroup.DialogBoxLauncher.String_0 = RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBackgroundAndBordersGroup_DialogBoxLauncher.ToString();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_2, ribbonGroup, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBackgroundAndBordersGroup.ToString(), "Click", "TXITEM_PageBackgroundAndBordersGroup_Handler");
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageColor.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBorders.ToString();
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			RibbonMenuButton ribbonMenuButton5 = new RibbonMenuButton();
			ribbonMenuButton5.Name = RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageLineColor.ToString();
			ribbonMenuButton5.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton6 = ribbonMenuButton5;
			RibbonMenuButton ribbonMenuButton7 = new RibbonMenuButton();
			ribbonMenuButton7.Name = RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageLineWidth.ToString();
			ribbonMenuButton7.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton8 = ribbonMenuButton7;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonMenuButton4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonMenuButton6, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonMenuButton8, null, hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[4] { ribbonMenuButton2, ribbonMenuButton4, ribbonMenuButton6, ribbonMenuButton8 });
			base.list_2.AddRange(new IEnabledItem[1] { ribbonGroup });
			Class517.smethod_29(this.dictionary_2);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}
	}
}
