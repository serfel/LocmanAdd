using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class505 : Class500
	{
		private Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_1 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_2 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_3 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_4 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_5 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_6 = new Dictionary<string, object>();

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_ObjectArrangeGroup_Items => this.dictionary_0;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_ObjectSizeGroup_Items => this.dictionary_1;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_Drawing_BordersandBackgroundGroup_Items => this.dictionary_4;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_Barcode_ColorsAndAlignmentGroup_Items => this.dictionary_5;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_TextFrame_BordersandBackgroundGroup_Items => this.dictionary_3;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_Chart_TypeAndAppearanceGroup_Items => this.dictionary_6;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_ObjectPropertiesGroup_Items => this.dictionary_2;

		internal Class505(Control control_1, BindingAdapter bindingAdapter_1)
			: base(control_1, bindingAdapter_1)
		{
		}

		internal void method_10(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.DialogBoxLauncher.ToolTip.Title = base.resourceManager_0.GetString("TOOLTIPTITLE_LayoutAndPosition");
			ribbonGroup.DialogBoxLauncher.ToolTip.Description = base.resourceManager_0.GetString("TOOLTIP_LayoutAndPosition");
			ribbonGroup.DialogBoxLauncher.String_0 = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectArrangeGroup_DialogBoxLauncher.ToString();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_0, ribbonGroup, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectArrangeGroup.ToString(), "Click", "TXITEM_ArrangeGroup_Handler");
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_WrapText.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BringToFront.ToString();
			ribbonMenuButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			RibbonMenuButton ribbonMenuButton5 = new RibbonMenuButton();
			ribbonMenuButton5.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_SendToBack.ToString();
			ribbonMenuButton5.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton6 = ribbonMenuButton5;
			RibbonMenuButton ribbonMenuButton7 = new RibbonMenuButton();
			ribbonMenuButton7.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Position.ToString();
			ribbonMenuButton7.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton8 = ribbonMenuButton7;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonMenuButton4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonMenuButton6, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonMenuButton8, null, hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[4] { ribbonMenuButton2, ribbonMenuButton4, ribbonMenuButton6, ribbonMenuButton8 });
			base.list_0.Add(ribbonGroup);
			Class517.smethod_29(this.dictionary_0);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_11(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.RowCount = 2;
			RibbonGroup ribbonGroup2 = ribbonGroup;
			ribbonGroup2.DialogBoxLauncher.ToolTip.Title = base.resourceManager_0.GetString("TOOLTIPTITLE_SizeAndDistance");
			ribbonGroup2.DialogBoxLauncher.ToolTip.Description = base.resourceManager_0.GetString("TOOLTIP_SizeAndDistance");
			ribbonGroup2.DialogBoxLauncher.String_0 = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectSizeGroup_DialogBoxLauncher.ToString();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_1, ribbonGroup2, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectSizeGroup.ToString(), "Click", "TXITEM_ObjectSizeGroup_Handler");
			RibbonTextBox ribbonTextBox = new RibbonTextBox();
			ribbonTextBox.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectHeight.ToString();
			ribbonTextBox.TextBoxWidth = Class519.Class536.Int32_0;
			RibbonTextBox ribbonTextBox2 = ribbonTextBox;
			RibbonTextBox ribbonTextBox3 = new RibbonTextBox();
			ribbonTextBox3.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectWidth.ToString();
			ribbonTextBox3.TextBoxWidth = Class519.Class536.Int32_1;
			RibbonTextBox ribbonTextBox4 = ribbonTextBox3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonTextBox2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonTextBox4, null, hasImage: true);
			ribbonGroup2.RibbonItems.AddRange(new Control[2] { ribbonTextBox2, ribbonTextBox4 });
			base.list_0.Add(ribbonGroup2);
			Class517.smethod_29(this.dictionary_1);
			ribbonGroupCollection_0.Add(ribbonGroup2);
		}

		internal void method_12(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.RowCount = 2;
			RibbonGroup ribbonGroup2 = ribbonGroup;
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_2, ribbonGroup2, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectPropertiesGroup.ToString(), null, null);
			RibbonTextBox ribbonTextBox = new RibbonTextBox();
			ribbonTextBox.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectName.ToString();
			ribbonTextBox.TextBoxWidth = Class519.Class536.Int32_2;
			ribbonTextBox.TextAlign = (System.Windows.Forms.HorizontalAlignment)HorizontalAlignment.Left;
			RibbonTextBox ribbonTextBox2 = ribbonTextBox;
			RibbonTextBox ribbonTextBox3 = new RibbonTextBox();
			ribbonTextBox3.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectID.ToString();
			ribbonTextBox3.TextBoxWidth = Class519.Class536.Int32_3;
			ribbonTextBox3.TextAlign = (System.Windows.Forms.HorizontalAlignment)HorizontalAlignment.Left;
			RibbonTextBox ribbonTextBox4 = ribbonTextBox3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonTextBox2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonTextBox4, null, hasImage: true);
			ribbonGroup2.RibbonItems.AddRange(new Control[2] { ribbonTextBox2, ribbonTextBox4 });
			base.list_0.Add(ribbonGroup2);
			Class517.smethod_29(this.dictionary_2);
			ribbonGroupCollection_0.Add(ribbonGroup2);
		}

		internal void method_13(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.Visible = false;
			RibbonGroup ribbonGroup2 = ribbonGroup;
			ribbonGroup2.DialogBoxLauncher.ToolTip.Title = base.resourceManager_0.GetString("TOOLTIPTITLE_FrameAndColor");
			ribbonGroup2.DialogBoxLauncher.ToolTip.Description = base.resourceManager_0.GetString("TOOLTIP_FrameAndColor");
			ribbonGroup2.DialogBoxLauncher.String_0 = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrame_BordersandBackgroundGroup_DialogBoxLauncher.ToString();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_3, ribbonGroup2, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrame_BordersandBackgroundGroup.ToString(), "Click", "TXITEM_TextFrame_BordersandBackgroundGroup_Handler");
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameBackColor.ToString();
			ribbonMenuButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameLineWidth.ToString();
			ribbonMenuButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			RibbonMenuButton ribbonMenuButton5 = new RibbonMenuButton();
			ribbonMenuButton5.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameTransparency.ToString();
			ribbonMenuButton5.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton6 = ribbonMenuButton5;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonMenuButton6, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonMenuButton4, null, hasImage: true);
			ribbonGroup2.RibbonItems.AddRange(new Control[3] { ribbonMenuButton2, ribbonMenuButton6, ribbonMenuButton4 });
			base.list_0.Add(ribbonGroup2);
			Class517.smethod_29(this.dictionary_3);
			ribbonGroupCollection_0.Add(ribbonGroup2);
		}

		internal void method_14(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.Visible = false;
			RibbonGroup ribbonGroup2 = ribbonGroup;
			ribbonGroup2.DialogBoxLauncher.ToolTip.Title = base.resourceManager_0.GetString("TOOLTIPTITLE_OutlineAndFill");
			ribbonGroup2.DialogBoxLauncher.ToolTip.Description = base.resourceManager_0.GetString("TOOLTIP_OutlineAndFill");
			ribbonGroup2.DialogBoxLauncher.String_0 = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Drawing_BordersandBackgroundGroup_DialogBoxLauncher.ToString();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_4, ribbonGroup2, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Drawing_BordersandBackgroundGroup.ToString(), "Click", "TXITEM_Drawing_BordersandBackgroundGroup_Handler");
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingLineColor.ToString();
			ribbonMenuButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingBackColor.ToString();
			ribbonMenuButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			RibbonMenuButton ribbonMenuButton5 = new RibbonMenuButton();
			ribbonMenuButton5.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingLineWidth.ToString();
			ribbonMenuButton5.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton6 = ribbonMenuButton5;
			RibbonMenuButton ribbonMenuButton7 = new RibbonMenuButton();
			ribbonMenuButton7.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingTransparency.ToString();
			ribbonMenuButton7.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton8 = ribbonMenuButton7;
			RibbonMenuButton ribbonMenuButton9 = new RibbonMenuButton();
			ribbonMenuButton9.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingRotation.ToString();
			ribbonMenuButton9.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton10 = ribbonMenuButton9;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonMenuButton4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonMenuButton6, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonMenuButton8, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonMenuButton10, null, hasImage: true);
			ribbonGroup2.RibbonItems.AddRange(new Control[5] { ribbonMenuButton2, ribbonMenuButton4, ribbonMenuButton6, ribbonMenuButton8, ribbonMenuButton10 });
			base.list_0.Add(ribbonGroup2);
			Class517.smethod_29(this.dictionary_4);
			ribbonGroupCollection_0.Add(ribbonGroup2);
		}

		internal void method_15(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.Visible = false;
			RibbonGroup ribbonGroup2 = ribbonGroup;
			ribbonGroup2.DialogBoxLauncher.ToolTip.Title = base.resourceManager_0.GetString("TOOLTIPTITLE_TypeAndColor");
			ribbonGroup2.DialogBoxLauncher.ToolTip.Description = base.resourceManager_0.GetString("TOOLTIP_TypeAndColor");
			ribbonGroup2.DialogBoxLauncher.String_0 = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Barcode_ColorsAndAlignmentGroup_DialogBoxLauncher.ToString();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_5, ribbonGroup2, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Barcode_ColorsAndAlignmentGroup.ToString(), "Click", "TXITEM_Barcode_ColorsAndAlignmentGroup_Handler");
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeForeColor.ToString();
			ribbonMenuButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeBackColor.ToString();
			ribbonMenuButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			RibbonMenuButton ribbonMenuButton5 = new RibbonMenuButton();
			ribbonMenuButton5.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeTransparency.ToString();
			ribbonMenuButton5.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton6 = ribbonMenuButton5;
			RibbonMenuButton ribbonMenuButton7 = new RibbonMenuButton();
			ribbonMenuButton7.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeHorizontalAlignment.ToString();
			ribbonMenuButton7.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton8 = ribbonMenuButton7;
			RibbonMenuButton ribbonMenuButton9 = new RibbonMenuButton();
			ribbonMenuButton9.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeVerticalAlignment.ToString();
			ribbonMenuButton9.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton10 = ribbonMenuButton9;
			RibbonMenuButton ribbonMenuButton11 = new RibbonMenuButton();
			ribbonMenuButton11.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeRotation.ToString();
			ribbonMenuButton11.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton12 = ribbonMenuButton11;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_5, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_5, ribbonMenuButton4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_5, ribbonMenuButton6, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_5, ribbonMenuButton8, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_5, ribbonMenuButton10, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_5, ribbonMenuButton12, null, hasImage: true);
			ribbonGroup2.RibbonItems.AddRange(new Control[6] { ribbonMenuButton2, ribbonMenuButton4, ribbonMenuButton6, ribbonMenuButton8, ribbonMenuButton10, ribbonMenuButton12 });
			base.list_0.Add(ribbonGroup2);
			Class517.smethod_29(this.dictionary_5);
			ribbonGroupCollection_0.Add(ribbonGroup2);
		}

		internal void method_16(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.Visible = false;
			RibbonGroup ribbonGroup2 = ribbonGroup;
			ribbonGroup2.DialogBoxLauncher.ToolTip.Title = base.resourceManager_0.GetString("TOOLTIPTITLE_TypeAndAppearance");
			ribbonGroup2.DialogBoxLauncher.ToolTip.Description = base.resourceManager_0.GetString("TOOLTIP_TypeAndAppearance");
			ribbonGroup2.DialogBoxLauncher.String_0 = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Chart_TypeAndAppearanceGroup_DialogBoxLauncher.ToString();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_6, ribbonGroup2, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Chart_TypeAndAppearanceGroup.ToString(), "Click", "TXITEM_Chart_TypeAndAppearanceGroup_Handler");
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType.ToString();
			ribbonMenuButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartIs3D.ToString();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartRotation.ToString();
			ribbonMenuButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartHasRightAngleAxes.ToString();
			ribbonToggleButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			RibbonMenuButton ribbonMenuButton5 = new RibbonMenuButton();
			ribbonMenuButton5.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartInclination.ToString();
			ribbonMenuButton5.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton6 = ribbonMenuButton5;
			RibbonMenuButton ribbonMenuButton7 = new RibbonMenuButton();
			ribbonMenuButton7.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartPerspective.ToString();
			ribbonMenuButton7.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton8 = ribbonMenuButton7;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_6, ribbonMenuButton2, "DropDownOpening", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_6, ribbonMenuButton4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_6, ribbonToggleButton4, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_6, ribbonMenuButton6, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_6, ribbonMenuButton8, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_6, ribbonToggleButton2, "CheckedChanged", hasImage: true);
			ribbonGroup2.RibbonItems.AddRange(new Control[6] { ribbonMenuButton2, ribbonToggleButton2, ribbonMenuButton4, ribbonToggleButton4, ribbonMenuButton6, ribbonMenuButton8 });
			base.list_0.Add(ribbonGroup2);
			Class517.smethod_29(this.dictionary_6);
			ribbonGroupCollection_0.Add(ribbonGroup2);
		}

		internal void method_17(bool bool_0)
		{
			bool flag = false;
			if (base.bindingAdapter_0.TextControl != null)
			{
				Class517.smethod_34(base.bindingAdapter_0.TextControl, out var class440_, out var _);
				if (class440_ != null)
				{
					flag = Class517.smethod_35(class440_);
				}
			}
			RibbonToggleButton ribbonToggleButton = this.dictionary_6[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartHasRightAngleAxes.ToString()] as RibbonToggleButton;
			ribbonToggleButton.Enabled = bool_0 && !flag;
			Control obj = this.dictionary_6[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartRotation.ToString()] as Control;
			bool enabled = ((this.dictionary_6[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartInclination.ToString()] as Control).Enabled = bool_0);
			obj.Enabled = enabled;
			(this.dictionary_6[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartPerspective.ToString()] as Control).Enabled = bool_0 && ribbonToggleButton.Enabled && !ribbonToggleButton.Checked;
		}

		internal void method_18(bool bool_0)
		{
			foreach (IEnabledItem item in base.list_0)
			{
				item.Enabled = bool_0;
			}
		}

		internal void method_19(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.ShowSeperator = false;
			RibbonGroup ribbonGroup2 = ribbonGroup;
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_3, ribbonGroup2, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrame_BordersandBackgroundGroup.ToString(), null, null);
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameBackColor.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameLineWidth.ToString();
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			RibbonMenuButton ribbonMenuButton5 = new RibbonMenuButton();
			ribbonMenuButton5.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameTransparency.ToString();
			RibbonMenuButton ribbonMenuButton6 = ribbonMenuButton5;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonMenuButton4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonMenuButton6, null, hasImage: true);
			ribbonGroup2.RibbonItems.AddRange(new Control[3] { ribbonMenuButton2, ribbonMenuButton4, ribbonMenuButton6 });
			Class517.smethod_29(this.dictionary_3);
			ribbonGroupCollection_0.Add(ribbonGroup2);
		}

		internal void method_20(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.ShowSeperator = false;
			RibbonGroup ribbonGroup2 = ribbonGroup;
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_4, ribbonGroup2, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Drawing_BordersandBackgroundGroup.ToString(), null, null);
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingBackColor.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingTransparency.ToString();
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			RibbonMenuButton ribbonMenuButton5 = new RibbonMenuButton();
			ribbonMenuButton5.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingLineColor.ToString();
			RibbonMenuButton ribbonMenuButton6 = ribbonMenuButton5;
			RibbonMenuButton ribbonMenuButton7 = new RibbonMenuButton();
			ribbonMenuButton7.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingLineWidth.ToString();
			RibbonMenuButton ribbonMenuButton8 = ribbonMenuButton7;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonMenuButton4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonMenuButton6, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonMenuButton8, null, hasImage: true);
			ribbonGroup2.RibbonItems.AddRange(new Control[4] { ribbonMenuButton2, ribbonMenuButton6, ribbonMenuButton4, ribbonMenuButton8 });
			Class517.smethod_29(this.dictionary_4);
			ribbonGroupCollection_0.Add(ribbonGroup2);
		}

		internal void method_21(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.ShowSeperator = false;
			RibbonGroup ribbonGroup2 = ribbonGroup;
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_5, ribbonGroup2, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Barcode_ColorsAndAlignmentGroup.ToString(), null, null);
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeBackColor.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeForeColor.ToString();
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			RibbonMenuButton ribbonMenuButton5 = new RibbonMenuButton();
			ribbonMenuButton5.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeTransparency.ToString();
			RibbonMenuButton ribbonMenuButton6 = ribbonMenuButton5;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_5, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_5, ribbonMenuButton4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_5, ribbonMenuButton6, null, hasImage: true);
			ribbonGroup2.RibbonItems.AddRange(new Control[3] { ribbonMenuButton2, ribbonMenuButton4, ribbonMenuButton6 });
			Class517.smethod_29(this.dictionary_5);
			ribbonGroupCollection_0.Add(ribbonGroup2);
		}
	}
}
