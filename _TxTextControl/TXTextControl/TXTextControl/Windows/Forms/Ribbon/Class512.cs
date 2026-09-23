using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class512 : Class500
	{
		private Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_1 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_2 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_3 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_4 = new Dictionary<string, object>();

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_TableLayoutGroup_Items => this.dictionary_0;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_RowsAndColumnsGroup_Items => this.dictionary_1;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_MergeGroup_Items => this.dictionary_2;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_BordersAndBackgroundGroup_Items => this.dictionary_3;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_TableAlignmentGroup_Items => this.dictionary_4;

		internal Class512(Control control_1, BindingAdapter bindingAdapter_1)
			: base(control_1, bindingAdapter_1)
		{
		}

		internal void method_10(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_0, ribbonGroup, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLayoutGroup.ToString(), null, null);
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_SelectTable.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableGridLines.ToString();
			ribbonToggleButton.Checked = true;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableProperties.ToString();
			RibbonButton ribbonButton2 = ribbonButton;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonToggleButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton2, "Click", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[3] { ribbonMenuButton2, ribbonToggleButton2, ribbonButton2 });
			Class517.smethod_29(this.dictionary_0);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_11(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_1, ribbonGroup, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_RowsAndColumnsGroup.ToString(), null, null);
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_DeleteTable.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_InsertTableRowAbove.ToString();
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_InsertTableRowBelow.ToString();
			RibbonButton ribbonButton4 = ribbonButton3;
			RibbonButton ribbonButton5 = new RibbonButton();
			ribbonButton5.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_InsertTableColLeft.ToString();
			RibbonButton ribbonButton6 = ribbonButton5;
			RibbonButton ribbonButton7 = new RibbonButton();
			ribbonButton7.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_InsertTableColRight.ToString();
			RibbonButton ribbonButton8 = ribbonButton7;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton4, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton6, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton8, "Click", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[5] { ribbonMenuButton2, ribbonButton2, ribbonButton4, ribbonButton6, ribbonButton8 });
			Class517.smethod_29(this.dictionary_1);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_12(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_2, ribbonGroup, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_MergeGroup.ToString(), null, null);
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_MergeTableCells.ToString();
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_SplitTableCells.ToString();
			RibbonButton ribbonButton4 = ribbonButton3;
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_SplitTable.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonButton4, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonMenuButton2, null, hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[3] { ribbonButton2, ribbonButton4, ribbonMenuButton2 });
			Class517.smethod_29(this.dictionary_2);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_13(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.DialogBoxLauncher.ToolTip.Title = base.resourceManager_0.GetString("TOOLTIPTITLE_Table_FrameAndColor");
			ribbonGroup.DialogBoxLauncher.ToolTip.Description = base.resourceManager_0.GetString("TOOLTIP_Table_FrameAndColor");
			ribbonGroup.DialogBoxLauncher.String_0 = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_BordersAndBackgroundGroup_DialogBoxLauncher.ToString();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_3, ribbonGroup, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_BordersAndBackgroundGroup.ToString(), "Click", "TXITEM_BordersAndBackgroundGroup_Handler");
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableFrameLines.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLineColor.ToString();
			ribbonMenuButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			RibbonMenuButton ribbonMenuButton5 = new RibbonMenuButton();
			ribbonMenuButton5.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableBackColor.ToString();
			ribbonMenuButton5.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton6 = ribbonMenuButton5;
			RibbonMenuButton ribbonMenuButton7 = new RibbonMenuButton();
			ribbonMenuButton7.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLineWidth.ToString();
			ribbonMenuButton7.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton8 = ribbonMenuButton7;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonMenuButton4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonMenuButton6, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonMenuButton8, null, hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[4] { ribbonMenuButton2, ribbonMenuButton4, ribbonMenuButton6, ribbonMenuButton8 });
			Class517.smethod_29(this.dictionary_3);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_14(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.DialogBoxLauncher.ToolTip.Title = base.resourceManager_0.GetString("TOOLTIPTITLE_SizeAndFormatting");
			ribbonGroup.DialogBoxLauncher.ToolTip.Description = base.resourceManager_0.GetString("TOOLTIP_SizeAndFormatting");
			ribbonGroup.DialogBoxLauncher.String_0 = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableAlignmentGroup_DialogBoxLauncher.ToString();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_4, ribbonGroup, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableAlignmentGroup.ToString(), "Click", "TXITEM_TableAlignmentGroup_Handler");
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignTopLeft.ToString();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignTopCentered.ToString();
			ribbonToggleButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			RibbonToggleButton ribbonToggleButton5 = new RibbonToggleButton();
			ribbonToggleButton5.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignTopRight.ToString();
			ribbonToggleButton5.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton6 = ribbonToggleButton5;
			RibbonToggleButton ribbonToggleButton7 = new RibbonToggleButton();
			ribbonToggleButton7.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignTopJustified.ToString();
			ribbonToggleButton7.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton8 = ribbonToggleButton7;
			RibbonToggleButton ribbonToggleButton9 = new RibbonToggleButton();
			ribbonToggleButton9.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignMiddleLeft.ToString();
			ribbonToggleButton9.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton10 = ribbonToggleButton9;
			RibbonToggleButton ribbonToggleButton11 = new RibbonToggleButton();
			ribbonToggleButton11.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignMiddleCentered.ToString();
			ribbonToggleButton11.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton12 = ribbonToggleButton11;
			RibbonToggleButton ribbonToggleButton13 = new RibbonToggleButton();
			ribbonToggleButton13.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignMiddleRight.ToString();
			ribbonToggleButton13.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton14 = ribbonToggleButton13;
			RibbonToggleButton ribbonToggleButton15 = new RibbonToggleButton();
			ribbonToggleButton15.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignMiddleJustified.ToString();
			ribbonToggleButton15.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton16 = ribbonToggleButton15;
			RibbonToggleButton ribbonToggleButton17 = new RibbonToggleButton();
			ribbonToggleButton17.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignBottomLeft.ToString();
			ribbonToggleButton17.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton18 = ribbonToggleButton17;
			RibbonToggleButton ribbonToggleButton19 = new RibbonToggleButton();
			ribbonToggleButton19.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignBottomCentered.ToString();
			ribbonToggleButton19.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton20 = ribbonToggleButton19;
			RibbonToggleButton ribbonToggleButton21 = new RibbonToggleButton();
			ribbonToggleButton21.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignBottomRight.ToString();
			ribbonToggleButton21.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton22 = ribbonToggleButton21;
			RibbonToggleButton ribbonToggleButton23 = new RibbonToggleButton();
			ribbonToggleButton23.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignBottomJustified.ToString();
			ribbonToggleButton23.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton24 = ribbonToggleButton23;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonToggleButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonToggleButton4, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonToggleButton6, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonToggleButton8, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonToggleButton10, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonToggleButton12, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonToggleButton14, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonToggleButton16, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonToggleButton18, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonToggleButton20, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonToggleButton22, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonToggleButton24, "Click", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[12]
			{
				ribbonToggleButton2, ribbonToggleButton10, ribbonToggleButton18, ribbonToggleButton4, ribbonToggleButton12, ribbonToggleButton20, ribbonToggleButton6, ribbonToggleButton14, ribbonToggleButton22, ribbonToggleButton8,
				ribbonToggleButton16, ribbonToggleButton24
			});
			Class517.smethod_29(this.dictionary_4);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal override void vmethod_0(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "CanEdit")
			{
				(base.bindingAdapter_0 as Class483).method_65();
			}
		}

		internal void method_15(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.ShowSeperator = false;
			RibbonGroup ribbonGroup2 = ribbonGroup;
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_0, ribbonGroup2, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLayoutGroup.ToString(), null, null);
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = TextMiniToolbar.InternalRibbonItem.TXITEM_TableSelect.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = TextMiniToolbar.InternalRibbonItem.TXITEM_TableMergeCells.ToString();
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = TextMiniToolbar.InternalRibbonItem.TXITEM_TableDelete.ToString();
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			RibbonMenuButton ribbonMenuButton5 = new RibbonMenuButton();
			ribbonMenuButton5.Name = TextMiniToolbar.InternalRibbonItem.TXITEM_TableInsert.ToString();
			RibbonMenuButton ribbonMenuButton6 = ribbonMenuButton5;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = TextMiniToolbar.InternalRibbonItem.TXITEM_TableSplitCells.ToString();
			RibbonButton ribbonButton4 = ribbonButton3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonMenuButton4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonMenuButton6, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton4, "Click", hasImage: true);
			ribbonGroup2.RibbonItems.AddRange(new Control[5] { ribbonMenuButton2, ribbonButton2, ribbonMenuButton4, ribbonMenuButton6, ribbonButton4 });
			Class517.smethod_29(this.dictionary_0);
			ribbonGroupCollection_0.Add(ribbonGroup2);
		}
	}
}
