using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class504 : Class500
	{
		private Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_1 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_2 = new Dictionary<string, object>();

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_FormulaGroup_Items => this.dictionary_0;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_NumberFormatGroup_Items => this.dictionary_1;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_FormulaSettingsGroup_Items => this.dictionary_2;

		internal Class504(Control control_1, BindingAdapter bindingAdapter_1)
			: base(control_1, bindingAdapter_1)
		{
		}

		internal void method_10(RibbonGroupCollection ribbonGroupCollection_0)
		{
			HorizontalRibbonGroup horizontalRibbonGroup = new HorizontalRibbonGroup();
			horizontalRibbonGroup.DialogBoxLauncher.ToolTip.Title = base.resourceManager_0.GetString("TOOLTIPTITLE_FormulaEditing");
			horizontalRibbonGroup.DialogBoxLauncher.ToolTip.Description = base.resourceManager_0.GetString("TOOLTIP_FormulaEditing");
			horizontalRibbonGroup.DialogBoxLauncher.String_0 = RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaGroup_DialogBoxLauncher.ToString();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_0, horizontalRibbonGroup, RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaGroup.ToString(), "Click", "TXITEM_FormulaGroup_Handler");
			RibbonLabel ribbonLabel = new RibbonLabel();
			ribbonLabel.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_Formula.ToString();
			RibbonLabel ribbonLabel2 = ribbonLabel;
			RibbonTextBox ribbonTextBox = new RibbonTextBox();
			ribbonTextBox.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaTextBox.ToString();
			ribbonTextBox.DisplayMode = IconTextRelation.NoIconLabeled;
			ribbonTextBox.TextBoxWidth = Class519.Class535.Int32_0;
			ribbonTextBox.TextAlign = (System.Windows.Forms.HorizontalAlignment)HorizontalAlignment.Left;
			RibbonTextBox ribbonTextBox2 = ribbonTextBox;
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_AcceptFormula.ToString();
			ribbonButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			ribbonButton.Enabled = false;
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_CancelFormulaEditing.ToString();
			ribbonButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			ribbonButton3.Enabled = false;
			RibbonButton ribbonButton4 = ribbonButton3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonLabel2, null, hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonTextBox2, "TextChanged", hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton4, "Click", hasImage: true);
			horizontalRibbonGroup.AddRange(new Control[4] { ribbonLabel2, ribbonTextBox2, ribbonButton2, ribbonButton4 }, 0);
			RibbonLabel ribbonLabel3 = new RibbonLabel();
			ribbonLabel3.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_Functions.ToString();
			RibbonLabel ribbonLabel4 = ribbonLabel3;
			RibbonComboBox ribbonComboBox = new RibbonComboBox();
			ribbonComboBox.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_SupportedFunctions.ToString();
			ribbonComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ribbonComboBox.BackColor = SystemColors.Window;
			RibbonComboBox ribbonComboBox2 = ribbonComboBox;
			RibbonButton ribbonButton5 = new RibbonButton();
			ribbonButton5.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_AddFunction.ToString();
			ribbonButton5.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonButton ribbonButton6 = ribbonButton5;
			RibbonSeperator ribbonSeperator = new RibbonSeperator();
			ribbonSeperator.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaGroupSeparator.ToString();
			RibbonSeperator ribbonSeperator2 = ribbonSeperator;
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_SelectCellReferences.ToString();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonLabel4, null, hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonComboBox2, null, hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton6, "Click", hasImage: true);
			this.dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonToggleButton2, "CheckedChanged", hasImage: true);
			horizontalRibbonGroup.AddRange(new Control[5] { ribbonLabel4, ribbonComboBox2, ribbonButton6, ribbonSeperator2, ribbonToggleButton2 }, 1);
			int num = Math.Max(ribbonLabel2.Width, ribbonLabel4.Width) + 10;
			ribbonLabel2.MinimumSize = new Size(num, 0);
			ribbonLabel4.MinimumSize = new Size(num + 2, 0);
			Class517.smethod_29(this.dictionary_0);
			ribbonGroupCollection_0.Add(horizontalRibbonGroup);
			(base.bindingAdapter_0 as Class475).class487_0 = new Class487(ribbonTextBox2, ribbonToggleButton2, base.bindingAdapter_0 as Class475);
		}

		internal void method_11(RibbonGroupCollection ribbonGroupCollection_0)
		{
			HorizontalRibbonGroup horizontalRibbonGroup = new HorizontalRibbonGroup();
			horizontalRibbonGroup.DialogBoxLauncher.ToolTip.Title = base.resourceManager_0.GetString("TOOLTIPTITLE_FormulaEditing");
			horizontalRibbonGroup.DialogBoxLauncher.ToolTip.Description = base.resourceManager_0.GetString("TOOLTIP_FormulaEditing");
			horizontalRibbonGroup.DialogBoxLauncher.String_0 = RibbonFormulaTab.InternalRibbonItem.TXITEM_NumberFormatGroup_DialogBoxLauncher.ToString();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_1, horizontalRibbonGroup, RibbonFormulaTab.InternalRibbonItem.TXITEM_NumberFormatGroup.ToString(), "Click", "TXITEM_FormulaGroup_Handler");
			RibbonLabel ribbonLabel = new RibbonLabel();
			ribbonLabel.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellNumberFormat.ToString();
			RibbonLabel ribbonLabel2 = ribbonLabel;
			RibbonComboBox ribbonComboBox = new RibbonComboBox();
			ribbonComboBox.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellNumberFormatComboBox.ToString();
			RibbonComboBox ribbonComboBox2 = ribbonComboBox;
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellAcceptNumberFormat.ToString();
			ribbonButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonButton ribbonButton2 = ribbonButton;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonLabel2, null, hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonComboBox2, "TextChanged", hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton2, "Click", hasImage: true);
			horizontalRibbonGroup.AddRange(new Control[3] { ribbonLabel2, ribbonComboBox2, ribbonButton2 }, 0);
			RibbonLabel ribbonLabel3 = new RibbonLabel();
			ribbonLabel3.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellTextType.ToString();
			RibbonLabel ribbonLabel4 = ribbonLabel3;
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellTextTypeText.ToString();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellTextTypeNumber.ToString();
			ribbonToggleButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonLabel4, null, hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonToggleButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonToggleButton4, null, hasImage: true);
			horizontalRibbonGroup.AddRange(new Control[3] { ribbonLabel4, ribbonToggleButton2, ribbonToggleButton4 }, 1);
			int width = Math.Max(ribbonLabel2.Width, ribbonLabel4.Width) + 10;
			ribbonLabel2.MinimumSize = new Size(width, 0);
			ribbonLabel4.MinimumSize = new Size(width, 0);
			Class517.smethod_29(this.dictionary_1);
			ribbonGroupCollection_0.Add(horizontalRibbonGroup);
		}

		internal void method_12(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_2, ribbonGroup, RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaSettingsGroup.ToString(), null, null);
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_EnableFormulaCalculation.ToString();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_EnableR1C1Style.ToString();
			ribbonToggleButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			RibbonToggleButton ribbonToggleButton5 = new RibbonToggleButton();
			ribbonToggleButton5.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_EnableA1Style.ToString();
			ribbonToggleButton5.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton6 = ribbonToggleButton5;
			RibbonToggleButton ribbonToggleButton7 = new RibbonToggleButton();
			ribbonToggleButton7.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_ShowFormulaReferences.ToString();
			ribbonToggleButton7.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton8 = ribbonToggleButton7;
			RibbonToggleButton ribbonToggleButton9 = new RibbonToggleButton();
			ribbonToggleButton9.Name = RibbonFormulaTab.InternalRibbonItem.TXITEM_ShowAllReferences.ToString();
			ribbonToggleButton9.DisplayMode = IconTextRelation.SmallIconLabeled;
			ribbonToggleButton9.Checked = true;
			RibbonToggleButton ribbonToggleButton10 = ribbonToggleButton9;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton2, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton4, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton6, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton8, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton10, "Click", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[5] { ribbonToggleButton2, ribbonToggleButton4, ribbonToggleButton6, ribbonToggleButton8, ribbonToggleButton10 });
			Class517.smethod_29(this.dictionary_2);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal override void vmethod_0(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "CanEdit")
			{
				(base.bindingAdapter_0 as Class475).method_23();
			}
		}
	}
}
