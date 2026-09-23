using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class502 : Class500
	{
		private Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_1 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_2 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_3 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_4 = new Dictionary<string, object>();

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_ClipboardGroup_Items => this.dictionary_0;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_FontGroup_Items => this.dictionary_1;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_ParagraphGroup_Items => this.dictionary_2;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_StylesGroup_Items => this.dictionary_3;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_EditingGroup_Items => this.dictionary_4;

		internal Class502(Control control_1, BindingAdapter bindingAdapter_1)
			: base(control_1, bindingAdapter_1)
		{
		}

		internal void method_10(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_0, ribbonGroup, RibbonFormattingTab.InternalRibbonItem.TXITEM_ClipboardGroup.ToString(), null, null);
			RibbonSplitButton ribbonSplitButton = new RibbonSplitButton();
			ribbonSplitButton.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Paste.ToString();
			RibbonSplitButton ribbonSplitButton2 = ribbonSplitButton;
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Cut.ToString();
			ribbonButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Copy.ToString();
			ribbonButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonButton ribbonButton4 = ribbonButton3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonSplitButton2, "ButtonClick", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton4, "Click", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[3] { ribbonSplitButton2, ribbonButton2, ribbonButton4 });
			Class517.smethod_29(this.dictionary_0);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_11(RibbonGroupCollection ribbonGroupCollection_0)
		{
			HorizontalRibbonGroup horizontalRibbonGroup = new HorizontalRibbonGroup();
			horizontalRibbonGroup.DialogBoxLauncher.ToolTip.Title = base.resourceManager_0.GetString("TOOLTIPTITLE_CharacterFormatting");
			horizontalRibbonGroup.DialogBoxLauncher.ToolTip.Description = base.resourceManager_0.GetString("TOOLTIP_CharacterFormatting");
			horizontalRibbonGroup.DialogBoxLauncher.String_0 = RibbonFormattingTab.InternalRibbonItem.TXITEM_FontGroup_DialogBoxLauncher.ToString();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_1, horizontalRibbonGroup, RibbonFormattingTab.InternalRibbonItem.TXITEM_FontGroup.ToString(), "Click", "TXITEM_FontGroup_Handler");
			RibbonComboBox ribbonComboBox = new RibbonComboBox();
			ribbonComboBox.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_FontFamily.ToString();
			RibbonComboBox ribbonComboBox2 = ribbonComboBox;
			RibbonComboBox ribbonComboBox3 = new RibbonComboBox();
			ribbonComboBox3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_FontSize.ToString();
			RibbonComboBox ribbonComboBox4 = ribbonComboBox3;
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_IncreaseFont.ToString();
			ribbonButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_DecreaseFont.ToString();
			ribbonButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonButton ribbonButton4 = ribbonButton3;
			RibbonSeperator ribbonSeperator = new RibbonSeperator();
			ribbonSeperator.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_FontGroupSeperator1.ToString();
			RibbonSeperator ribbonSeperator2 = ribbonSeperator;
			RibbonButton ribbonButton5 = new RibbonButton();
			ribbonButton5.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_ClearFormatting.ToString();
			ribbonButton5.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonButton ribbonButton6 = ribbonButton5;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonComboBox2, null, hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonComboBox4, null, hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton2, "Click", hasImage: true);
			this.dictionary_1.Add(ribbonSeperator2.Name, ribbonSeperator2);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton4, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton6, "Click", hasImage: true);
			horizontalRibbonGroup.AddRange(new Control[6] { ribbonComboBox2, ribbonComboBox4, ribbonButton2, ribbonButton4, ribbonSeperator2, ribbonButton6 }, 0);
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Bold.ToString();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Italic.ToString();
			ribbonToggleButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			RibbonSplitButton ribbonSplitButton = new RibbonSplitButton();
			ribbonSplitButton.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Underline.ToString();
			ribbonSplitButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			ribbonSplitButton.Checkable = true;
			RibbonSplitButton ribbonSplitButton2 = ribbonSplitButton;
			RibbonToggleButton ribbonToggleButton5 = new RibbonToggleButton();
			ribbonToggleButton5.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Strikeout.ToString();
			ribbonToggleButton5.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton6 = ribbonToggleButton5;
			RibbonToggleButton ribbonToggleButton7 = new RibbonToggleButton();
			ribbonToggleButton7.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Subscript.ToString();
			ribbonToggleButton7.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton8 = ribbonToggleButton7;
			RibbonToggleButton ribbonToggleButton9 = new RibbonToggleButton();
			ribbonToggleButton9.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Superscript.ToString();
			ribbonToggleButton9.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton10 = ribbonToggleButton9;
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_ChangeCase.ToString();
			ribbonMenuButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonSeperator ribbonSeperator3 = new RibbonSeperator();
			ribbonSeperator3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_FontGroupSeperator2.ToString();
			RibbonSeperator ribbonSeperator4 = ribbonSeperator3;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_TextBackColor.ToString();
			ribbonMenuButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			RibbonMenuButton ribbonMenuButton5 = new RibbonMenuButton();
			ribbonMenuButton5.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_TextColor.ToString();
			ribbonMenuButton5.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonMenuButton ribbonMenuButton6 = ribbonMenuButton5;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonToggleButton2, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonToggleButton4, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonSplitButton2, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonToggleButton6, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonToggleButton8, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonToggleButton10, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonMenuButton2, null, hasImage: true);
			this.dictionary_1.Add(ribbonSeperator4.Name, ribbonSeperator4);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonMenuButton4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonMenuButton6, null, hasImage: true);
			horizontalRibbonGroup.AddRange(new Control[10] { ribbonToggleButton2, ribbonToggleButton4, ribbonSplitButton2, ribbonToggleButton6, ribbonToggleButton8, ribbonToggleButton10, ribbonMenuButton2, ribbonSeperator4, ribbonMenuButton4, ribbonMenuButton6 }, 1);
			base.list_0.Add(horizontalRibbonGroup);
			base.list_1.AddRange(new IEnabledItem[14]
			{
				horizontalRibbonGroup.DialogBoxLauncher, ribbonComboBox2, ribbonComboBox4, ribbonButton2, ribbonButton4, ribbonToggleButton2, ribbonToggleButton4, ribbonSplitButton2, ribbonToggleButton6, ribbonToggleButton8,
				ribbonToggleButton10, ribbonMenuButton2, ribbonMenuButton4, ribbonMenuButton6
			});
			Class517.smethod_29(this.dictionary_1);
			ribbonGroupCollection_0.Add(horizontalRibbonGroup);
		}

		internal void method_12(RibbonGroupCollection ribbonGroupCollection_0)
		{
			HorizontalRibbonGroup horizontalRibbonGroup = new HorizontalRibbonGroup();
			horizontalRibbonGroup.DialogBoxLauncher.ToolTip.Title = base.resourceManager_0.GetString("TOOLTIPTITLE_ParagraphFormatting");
			horizontalRibbonGroup.DialogBoxLauncher.ToolTip.Description = base.resourceManager_0.GetString("TOOLTIP_ParagraphFormatting");
			horizontalRibbonGroup.DialogBoxLauncher.String_0 = RibbonFormattingTab.InternalRibbonItem.TXITEM_ParagraphGroup_DialogBoxLauncher.ToString();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_2, horizontalRibbonGroup, RibbonFormattingTab.InternalRibbonItem.TXITEM_ParagraphGroup.ToString(), "Click", "TXITEM_ParagraphGroup_Handler");
			RibbonSplitButton ribbonSplitButton = new RibbonSplitButton();
			ribbonSplitButton.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_BulletedList.ToString();
			ribbonSplitButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			ribbonSplitButton.Checkable = true;
			RibbonSplitButton ribbonSplitButton2 = ribbonSplitButton;
			RibbonSplitButton ribbonSplitButton3 = new RibbonSplitButton();
			ribbonSplitButton3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_NumberedList.ToString();
			ribbonSplitButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			ribbonSplitButton3.Checkable = true;
			RibbonSplitButton ribbonSplitButton4 = ribbonSplitButton3;
			RibbonSplitButton ribbonSplitButton5 = new RibbonSplitButton();
			ribbonSplitButton5.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_StructuredList.ToString();
			ribbonSplitButton5.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			ribbonSplitButton5.Checkable = true;
			RibbonSplitButton ribbonSplitButton6 = ribbonSplitButton5;
			RibbonSeperator ribbonSeperator = new RibbonSeperator();
			ribbonSeperator.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_ParagraphGroupSeperator1.ToString();
			RibbonSeperator ribbonSeperator2 = ribbonSeperator;
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_DecreaseIndent.ToString();
			ribbonButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_IncreaseIndent.ToString();
			ribbonButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonButton ribbonButton4 = ribbonButton3;
			RibbonSeperator ribbonSeperator3 = new RibbonSeperator();
			ribbonSeperator3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_ParagraphGroupSeperator2.ToString();
			RibbonSeperator ribbonSeperator4 = ribbonSeperator3;
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_LeftToRight.ToString();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_RightToLeft.ToString();
			ribbonToggleButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			RibbonSeperator ribbonSeperator5 = new RibbonSeperator();
			ribbonSeperator5.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_ParagraphGroupSeperator3.ToString();
			RibbonSeperator ribbonSeperator6 = ribbonSeperator5;
			RibbonButton ribbonButton5 = new RibbonButton();
			ribbonButton5.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_EditTabs.ToString();
			ribbonButton5.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonButton ribbonButton6 = ribbonButton5;
			RibbonSeperator ribbonSeperator7 = new RibbonSeperator();
			ribbonSeperator7.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_ParagraphGroupSeperator4.ToString();
			RibbonSeperator ribbonSeperator8 = ribbonSeperator7;
			RibbonToggleButton ribbonToggleButton5 = new RibbonToggleButton();
			ribbonToggleButton5.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_ControlChars.ToString();
			ribbonToggleButton5.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton6 = ribbonToggleButton5;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonSplitButton2, "ButtonClick", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonSplitButton4, "ButtonClick", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonSplitButton6, "ButtonClick", hasImage: true);
			this.dictionary_2.Add(ribbonSeperator2.Name, ribbonSeperator2);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonButton4, "Click", hasImage: true);
			this.dictionary_2.Add(ribbonSeperator4.Name, ribbonSeperator4);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton2, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton4, "CheckedChanged", hasImage: true);
			this.dictionary_2.Add(ribbonSeperator6.Name, ribbonSeperator6);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonButton6, "Click", hasImage: true);
			this.dictionary_2.Add(ribbonSeperator8.Name, ribbonSeperator8);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton6, "Click", hasImage: true);
			horizontalRibbonGroup.AddRange(new Control[13]
			{
				ribbonSplitButton2, ribbonSplitButton4, ribbonSplitButton6, ribbonSeperator2, ribbonButton2, ribbonButton4, ribbonSeperator4, ribbonToggleButton2, ribbonToggleButton4, ribbonSeperator6,
				ribbonButton6, ribbonSeperator8, ribbonToggleButton6
			}, 0);
			RibbonToggleButton ribbonToggleButton7 = new RibbonToggleButton();
			ribbonToggleButton7.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_LeftAligned.ToString();
			ribbonToggleButton7.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton8 = ribbonToggleButton7;
			RibbonToggleButton ribbonToggleButton9 = new RibbonToggleButton();
			ribbonToggleButton9.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Centered.ToString();
			ribbonToggleButton9.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton10 = ribbonToggleButton9;
			RibbonToggleButton ribbonToggleButton11 = new RibbonToggleButton();
			ribbonToggleButton11.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_RightAligned.ToString();
			ribbonToggleButton11.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton12 = ribbonToggleButton11;
			RibbonToggleButton ribbonToggleButton13 = new RibbonToggleButton();
			ribbonToggleButton13.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Justified.ToString();
			ribbonToggleButton13.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton14 = ribbonToggleButton13;
			RibbonSeperator ribbonSeperator9 = new RibbonSeperator();
			ribbonSeperator9.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_ParagraphGroupSeperator5.ToString();
			RibbonSeperator ribbonSeperator10 = ribbonSeperator9;
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_LineSpacing.ToString();
			ribbonMenuButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonSeperator ribbonSeperator11 = new RibbonSeperator();
			ribbonSeperator11.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_ParagraphGroupSeperator6.ToString();
			RibbonSeperator ribbonSeperator12 = ribbonSeperator11;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Borders.ToString();
			ribbonMenuButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			RibbonMenuButton ribbonMenuButton5 = new RibbonMenuButton();
			ribbonMenuButton5.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_BackColor.ToString();
			ribbonMenuButton5.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonMenuButton ribbonMenuButton6 = ribbonMenuButton5;
			RibbonMenuButton ribbonMenuButton7 = new RibbonMenuButton();
			ribbonMenuButton7.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_FrameLineColor.ToString();
			ribbonMenuButton7.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonMenuButton ribbonMenuButton8 = ribbonMenuButton7;
			RibbonMenuButton ribbonMenuButton9 = new RibbonMenuButton();
			ribbonMenuButton9.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_FrameLineWidth.ToString();
			ribbonMenuButton9.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonMenuButton ribbonMenuButton10 = ribbonMenuButton9;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton8, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton10, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton12, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton14, "CheckedChanged", hasImage: true);
			this.dictionary_2.Add(ribbonSeperator10.Name, ribbonSeperator10);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonMenuButton2, null, hasImage: true);
			this.dictionary_2.Add(ribbonSeperator12.Name, ribbonSeperator12);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonMenuButton4, "DropDownOpening", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonMenuButton6, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonMenuButton8, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonMenuButton10, null, hasImage: true);
			horizontalRibbonGroup.AddRange(new Control[11]
			{
				ribbonToggleButton8, ribbonToggleButton10, ribbonToggleButton12, ribbonToggleButton14, ribbonSeperator10, ribbonMenuButton2, ribbonSeperator12, ribbonMenuButton4, ribbonMenuButton6, ribbonMenuButton8,
				ribbonMenuButton10
			}, 1);
			base.list_3.AddRange(new IEnabledItem[18]
			{
				horizontalRibbonGroup.DialogBoxLauncher, ribbonSplitButton2, ribbonSplitButton4, ribbonSplitButton6, ribbonButton2, ribbonButton4, ribbonToggleButton2, ribbonToggleButton4, ribbonButton6, ribbonToggleButton8,
				ribbonToggleButton10, ribbonToggleButton12, ribbonToggleButton14, ribbonMenuButton2, ribbonMenuButton4, ribbonMenuButton6, ribbonMenuButton8, ribbonMenuButton10
			});
			Class517.smethod_29(this.dictionary_2);
			ribbonGroupCollection_0.Add(horizontalRibbonGroup);
		}

		internal void method_13(RibbonGroupCollection ribbonGroupCollection_0)
		{
			HorizontalRibbonGroup horizontalRibbonGroup = new HorizontalRibbonGroup();
			horizontalRibbonGroup.DialogBoxLauncher.ToolTip.Title = base.resourceManager_0.GetString("TOOLTIPTITLE_StylesFormatting");
			horizontalRibbonGroup.DialogBoxLauncher.ToolTip.Description = base.resourceManager_0.GetString("TOOLTIP_StylesFormatting");
			horizontalRibbonGroup.DialogBoxLauncher.String_0 = RibbonFormattingTab.InternalRibbonItem.TXITEM_StylesGroup_DialogBoxLauncher.ToString();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_3, horizontalRibbonGroup, RibbonFormattingTab.InternalRibbonItem.TXITEM_StylesGroup.ToString(), "Click", "TXITEM_StylesGroup_Handler");
			RibbonListView ribbonListView = new RibbonListView();
			ribbonListView.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_StyleName.ToString();
			ribbonListView.BackColor = Color.White;
			ribbonListView.MinColumnCount = 1;
			ribbonListView.MaxVisibleRows = 1;
			ribbonListView.CellPadding = Class519.Class532.Padding_3;
			ribbonListView.ShowBorder = true;
			ribbonListView.Deselectable = false;
			ribbonListView.ShowItemsInDropDown = true;
			ribbonListView.ScrollButtonsVisible = false;
			ribbonListView.HideSelectedItems = true;
			RibbonListView ribbonListView2 = ribbonListView;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonListView2, null, hasImage: true);
			horizontalRibbonGroup.RibbonItems.Add(ribbonListView2);
			base.list_4.Add(horizontalRibbonGroup);
			Class517.smethod_29(this.dictionary_3);
			ribbonGroupCollection_0.Add(horizontalRibbonGroup);
		}

		internal void method_14(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_4, ribbonGroup, RibbonFormattingTab.InternalRibbonItem.TXITEM_EditingGroup.ToString(), null, null);
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Find.ToString();
			ribbonButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonSplitButton ribbonSplitButton = new RibbonSplitButton();
			ribbonSplitButton.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars.ToString();
			ribbonSplitButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			ribbonSplitButton.Checkable = true;
			RibbonSplitButton ribbonItem = ribbonSplitButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace.ToString();
			ribbonButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonButton ribbonButton4 = ribbonButton3;
			RibbonSplitButton ribbonSplitButton2 = new RibbonSplitButton();
			ribbonSplitButton2.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars.ToString();
			ribbonSplitButton2.DisplayMode = IconTextRelation.SmallIconLabeled;
			ribbonSplitButton2.Checkable = true;
			RibbonSplitButton ribbonItem2 = ribbonSplitButton2;
			RibbonButton ribbonButton5 = new RibbonButton();
			ribbonButton5.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto.ToString();
			ribbonButton5.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonButton ribbonButton6 = ribbonButton5;
			RibbonSplitButton ribbonSplitButton3 = new RibbonSplitButton();
			ribbonSplitButton3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars.ToString();
			ribbonSplitButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			ribbonSplitButton3.Checkable = true;
			RibbonSplitButton ribbonItem3 = ribbonSplitButton3;
			RibbonButton ribbonButton7 = new RibbonButton();
			ribbonButton7.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_SelectAll.ToString();
			ribbonButton7.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonButton ribbonButton8 = ribbonButton7;
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_SelectObjects.ToString();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonItem, "ButtonClick", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonButton4, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonItem2, "ButtonClick", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonButton6, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonItem3, "ButtonClick", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonButton8, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonToggleButton2, "CheckedChanged", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[5] { ribbonButton2, ribbonButton4, ribbonButton6, ribbonButton8, ribbonToggleButton2 });
			base.list_0.Add(ribbonButton4);
			Class517.smethod_29(this.dictionary_4);
			ribbonButton2.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Dialog.ToString();
			this.dictionary_4.Add(ribbonButton2.Name, ribbonButton2);
			ribbonButton6.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Dialog.ToString();
			this.dictionary_4.Add(ribbonButton6.Name, ribbonButton6);
			ribbonButton4.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Dialog.ToString();
			this.dictionary_4.Add(ribbonButton4.Name, ribbonButton4);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_15(object sender, PropertyChangedEventArgs e)
		{
			base.vmethod_0(sender, e);
			switch (e.PropertyName)
			{
			case "CanPaste":
				(base.bindingAdapter_0 as Class473).method_211();
				break;
			case "CanCopy":
				(base.bindingAdapter_0 as Class473).method_210();
				break;
			}
		}

		internal void method_16(RibbonGroupCollection ribbonGroupCollection_0)
		{
			HorizontalRibbonGroup horizontalRibbonGroup = new HorizontalRibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_1, horizontalRibbonGroup, RibbonFormattingTab.InternalRibbonItem.TXITEM_FontGroup.ToString(), null, null);
			RibbonComboBox ribbonComboBox = new RibbonComboBox();
			ribbonComboBox.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_FontFamily.ToString();
			RibbonComboBox ribbonComboBox2 = ribbonComboBox;
			RibbonComboBox ribbonComboBox3 = new RibbonComboBox();
			ribbonComboBox3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_FontSize.ToString();
			RibbonComboBox ribbonComboBox4 = ribbonComboBox3;
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_IncreaseFont.ToString();
			ribbonButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_DecreaseFont.ToString();
			ribbonButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonButton ribbonButton4 = ribbonButton3;
			RibbonSplitButton ribbonSplitButton = new RibbonSplitButton();
			ribbonSplitButton.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_BulletedList.ToString();
			ribbonSplitButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			ribbonSplitButton.Checkable = true;
			RibbonSplitButton ribbonSplitButton2 = ribbonSplitButton;
			RibbonSplitButton ribbonSplitButton3 = new RibbonSplitButton();
			ribbonSplitButton3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_NumberedList.ToString();
			ribbonSplitButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			ribbonSplitButton3.Checkable = true;
			RibbonSplitButton ribbonSplitButton4 = ribbonSplitButton3;
			RibbonSplitButton ribbonSplitButton5 = new RibbonSplitButton();
			ribbonSplitButton5.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_StructuredList.ToString();
			ribbonSplitButton5.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			ribbonSplitButton5.Checkable = true;
			RibbonSplitButton ribbonSplitButton6 = ribbonSplitButton5;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonComboBox2, null, hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonComboBox4, null, hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton4, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonSplitButton2, "ButtonClick", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonSplitButton4, "ButtonClick", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonSplitButton6, "ButtonClick", hasImage: true);
			horizontalRibbonGroup.AddRange(new Control[7] { ribbonComboBox2, ribbonComboBox4, ribbonButton2, ribbonButton4, ribbonSplitButton2, ribbonSplitButton4, ribbonSplitButton6 }, 0);
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Bold.ToString();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Italic.ToString();
			ribbonToggleButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			RibbonSplitButton ribbonSplitButton7 = new RibbonSplitButton();
			ribbonSplitButton7.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Underline.ToString();
			ribbonSplitButton7.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			ribbonSplitButton7.Checkable = true;
			RibbonSplitButton ribbonSplitButton8 = ribbonSplitButton7;
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_TextBackColor.ToString();
			ribbonMenuButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_TextColor.ToString();
			ribbonMenuButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			RibbonToggleButton ribbonToggleButton5 = new RibbonToggleButton();
			ribbonToggleButton5.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_LeftAligned.ToString();
			ribbonToggleButton5.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton6 = ribbonToggleButton5;
			RibbonToggleButton ribbonToggleButton7 = new RibbonToggleButton();
			ribbonToggleButton7.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Centered.ToString();
			ribbonToggleButton7.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton8 = ribbonToggleButton7;
			RibbonToggleButton ribbonToggleButton9 = new RibbonToggleButton();
			ribbonToggleButton9.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_RightAligned.ToString();
			ribbonToggleButton9.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton10 = ribbonToggleButton9;
			RibbonToggleButton ribbonToggleButton11 = new RibbonToggleButton();
			ribbonToggleButton11.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_Justified.ToString();
			ribbonToggleButton11.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton12 = ribbonToggleButton11;
			RibbonButton ribbonButton5 = new RibbonButton();
			ribbonButton5.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_ClearFormatting.ToString();
			ribbonButton5.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonButton ribbonButton6 = ribbonButton5;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonToggleButton2, "CheckedChanged", hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonToggleButton4, "CheckedChanged", hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonSplitButton8, "CheckedChanged", hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonMenuButton4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton6, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton8, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton10, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton12, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton6, "Click", hasImage: true);
			horizontalRibbonGroup.AddRange(new Control[10] { ribbonToggleButton2, ribbonToggleButton4, ribbonSplitButton8, ribbonMenuButton2, ribbonMenuButton4, ribbonToggleButton6, ribbonToggleButton8, ribbonToggleButton10, ribbonToggleButton12, ribbonButton6 }, 1);
			base.list_1.AddRange(new IEnabledItem[9] { ribbonComboBox2, ribbonComboBox4, ribbonButton2, ribbonButton4, ribbonToggleButton2, ribbonToggleButton4, ribbonSplitButton8, ribbonMenuButton2, ribbonMenuButton4 });
			base.list_3.AddRange(new IEnabledItem[7] { ribbonSplitButton2, ribbonSplitButton4, ribbonSplitButton6, ribbonToggleButton6, ribbonToggleButton8, ribbonToggleButton10, ribbonToggleButton12 });
			Class517.smethod_29(this.dictionary_1);
			Class517.smethod_29(this.dictionary_2);
			ribbonGroupCollection_0.Add(horizontalRibbonGroup);
		}

		internal void method_17(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.ShowSeperator = false;
			RibbonGroup ribbonGroup2 = ribbonGroup;
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_3, ribbonGroup2, RibbonFormattingTab.InternalRibbonItem.TXITEM_StylesGroup.ToString(), null, null);
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_StyleName.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonMenuButton2, null, hasImage: true);
			ribbonGroup2.RibbonItems.Add(ribbonMenuButton2);
			base.list_4.Add(ribbonGroup2);
			Class517.smethod_29(this.dictionary_3);
			ribbonGroupCollection_0.Add(ribbonGroup2);
		}

		internal void method_18()
		{
			base.method_9();
		}
	}
}
