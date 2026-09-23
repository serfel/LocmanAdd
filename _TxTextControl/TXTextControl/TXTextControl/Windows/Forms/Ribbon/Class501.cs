using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class501 : Class500
	{
		private Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_1 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_2 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_3 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_4 = new Dictionary<string, object>();

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_DataGroup_Items => this.dictionary_0;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_LabelsGroup_Items => this.dictionary_1;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_TitlesGroup_Items => this.dictionary_2;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_XAxisGroup_Items => this.dictionary_3;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_YAxisGroup_Items => this.dictionary_4;

		internal Class501(Control control_1, BindingAdapter bindingAdapter_1)
			: base(control_1, bindingAdapter_1)
		{
		}

		internal void method_10(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_0, ribbonGroup, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_DataGroup.ToString(), null, null);
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_EditData.ToString();
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_SetDataRelation.ToString();
			ribbonButton3.Enabled = false;
			RibbonButton ribbonButton4 = ribbonButton3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton4, "Click", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[2] { ribbonButton2, ribbonButton4 });
			Class517.smethod_29(this.dictionary_0);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_11(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_1, ribbonGroup, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_LabelsGroup.ToString(), null, null);
			RibbonSplitButton ribbonSplitButton = new RibbonSplitButton();
			ribbonSplitButton.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_Legend.ToString();
			ribbonSplitButton.Checkable = true;
			RibbonSplitButton ribbonSplitButton2 = ribbonSplitButton;
			RibbonSplitButton ribbonSplitButton3 = new RibbonSplitButton();
			ribbonSplitButton3.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLabels.ToString();
			ribbonSplitButton3.Checkable = true;
			RibbonSplitButton ribbonSplitButton4 = ribbonSplitButton3;
			RibbonSplitButton ribbonSplitButton5 = new RibbonSplitButton();
			ribbonSplitButton5.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLabels.ToString();
			ribbonSplitButton5.Checkable = true;
			RibbonSplitButton ribbonSplitButton6 = ribbonSplitButton5;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonSplitButton2, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonSplitButton4, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonSplitButton6, "CheckedChanged", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[3] { ribbonSplitButton2, ribbonSplitButton4, ribbonSplitButton6 });
			Class517.smethod_29(this.dictionary_1);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_12(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_2, ribbonGroup, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_TitlesGroup.ToString(), null, null);
			RibbonTextBox ribbonTextBox = new RibbonTextBox();
			ribbonTextBox.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_ChartTitle.ToString();
			ribbonTextBox.TextBoxWidth = Class519.Class537.Int32_0;
			ribbonTextBox.TextAlign = (System.Windows.Forms.HorizontalAlignment)HorizontalAlignment.Left;
			RibbonTextBox ribbonTextBox2 = ribbonTextBox;
			RibbonTextBox ribbonTextBox3 = new RibbonTextBox();
			ribbonTextBox3.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisTitle.ToString();
			ribbonTextBox3.TextBoxWidth = Class519.Class537.Int32_1;
			ribbonTextBox3.TextAlign = (System.Windows.Forms.HorizontalAlignment)HorizontalAlignment.Left;
			RibbonTextBox ribbonTextBox4 = ribbonTextBox3;
			RibbonTextBox ribbonTextBox5 = new RibbonTextBox();
			ribbonTextBox5.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisTitle.ToString();
			ribbonTextBox5.TextBoxWidth = Class519.Class537.Int32_2;
			ribbonTextBox5.TextAlign = (System.Windows.Forms.HorizontalAlignment)HorizontalAlignment.Left;
			RibbonTextBox ribbonTextBox6 = ribbonTextBox5;
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_FormatChartTitle.ToString();
			ribbonMenuButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_FormatXAxisTitle.ToString();
			ribbonMenuButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			RibbonMenuButton ribbonMenuButton5 = new RibbonMenuButton();
			ribbonMenuButton5.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_FormatYAxisTitle.ToString();
			ribbonMenuButton5.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonMenuButton ribbonMenuButton6 = ribbonMenuButton5;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonTextBox2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonTextBox4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonTextBox6, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonMenuButton4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonMenuButton6, null, hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[6] { ribbonTextBox2, ribbonTextBox4, ribbonTextBox6, ribbonMenuButton2, ribbonMenuButton4, ribbonMenuButton6 });
			Class517.smethod_29(this.dictionary_2);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_13(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_3, ribbonGroup, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisGroup.ToString(), null, null);
			RibbonSplitButton ribbonSplitButton = new RibbonSplitButton();
			ribbonSplitButton.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLine.ToString();
			ribbonSplitButton.Checkable = true;
			RibbonSplitButton ribbonSplitButton2 = ribbonSplitButton;
			RibbonSplitButton ribbonSplitButton3 = new RibbonSplitButton();
			ribbonSplitButton3.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMajorGridlines.ToString();
			ribbonSplitButton3.Checkable = true;
			RibbonSplitButton ribbonSplitButton4 = ribbonSplitButton3;
			RibbonSplitButton ribbonSplitButton5 = new RibbonSplitButton();
			ribbonSplitButton5.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinorGridlines.ToString();
			ribbonSplitButton5.Checkable = true;
			RibbonSplitButton ribbonSplitButton6 = ribbonSplitButton5;
			RibbonTextBox ribbonTextBox = new RibbonTextBox();
			ribbonTextBox.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinimum.ToString();
			ribbonTextBox.TextBoxWidth = Class519.Class537.Int32_3;
			RibbonTextBox ribbonTextBox2 = ribbonTextBox;
			RibbonTextBox ribbonTextBox3 = new RibbonTextBox();
			ribbonTextBox3.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMaximum.ToString();
			ribbonTextBox3.TextBoxWidth = Class519.Class537.Int32_4;
			RibbonTextBox ribbonTextBox4 = ribbonTextBox3;
			RibbonTextBox ribbonTextBox5 = new RibbonTextBox();
			ribbonTextBox5.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisInterval.ToString();
			ribbonTextBox5.TextBoxWidth = Class519.Class537.Int32_5;
			RibbonTextBox ribbonTextBox6 = ribbonTextBox5;
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinimumAutomatic.ToString();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMaximumAutomatic.ToString();
			ribbonToggleButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			RibbonToggleButton ribbonToggleButton5 = new RibbonToggleButton();
			ribbonToggleButton5.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisIntervalAutomatic.ToString();
			ribbonToggleButton5.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton6 = ribbonToggleButton5;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonSplitButton2, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonSplitButton4, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonSplitButton6, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonToggleButton2, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonToggleButton4, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonToggleButton6, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonTextBox2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonTextBox4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonTextBox6, null, hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[9] { ribbonSplitButton2, ribbonSplitButton4, ribbonSplitButton6, ribbonToggleButton2, ribbonToggleButton4, ribbonToggleButton6, ribbonTextBox2, ribbonTextBox4, ribbonTextBox6 });
			Class517.smethod_29(this.dictionary_3);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_14(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_4, ribbonGroup, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisGroup.ToString(), null, null);
			RibbonSplitButton ribbonSplitButton = new RibbonSplitButton();
			ribbonSplitButton.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLine.ToString();
			ribbonSplitButton.Checkable = true;
			RibbonSplitButton ribbonSplitButton2 = ribbonSplitButton;
			RibbonSplitButton ribbonSplitButton3 = new RibbonSplitButton();
			ribbonSplitButton3.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMajorGridlines.ToString();
			ribbonSplitButton3.Checkable = true;
			RibbonSplitButton ribbonSplitButton4 = ribbonSplitButton3;
			RibbonSplitButton ribbonSplitButton5 = new RibbonSplitButton();
			ribbonSplitButton5.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinorGridlines.ToString();
			ribbonSplitButton5.Checkable = true;
			RibbonSplitButton ribbonSplitButton6 = ribbonSplitButton5;
			RibbonTextBox ribbonTextBox = new RibbonTextBox();
			ribbonTextBox.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinimum.ToString();
			ribbonTextBox.TextBoxWidth = Class519.Class537.Int32_6;
			RibbonTextBox ribbonTextBox2 = ribbonTextBox;
			RibbonTextBox ribbonTextBox3 = new RibbonTextBox();
			ribbonTextBox3.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMaximum.ToString();
			ribbonTextBox3.TextBoxWidth = Class519.Class537.Int32_6;
			RibbonTextBox ribbonTextBox4 = ribbonTextBox3;
			RibbonTextBox ribbonTextBox5 = new RibbonTextBox();
			ribbonTextBox5.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisInterval.ToString();
			ribbonTextBox5.TextBoxWidth = Class519.Class537.Int32_6;
			RibbonTextBox ribbonTextBox6 = ribbonTextBox5;
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinimumAutomatic.ToString();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMaximumAutomatic.ToString();
			ribbonToggleButton3.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			RibbonToggleButton ribbonToggleButton5 = new RibbonToggleButton();
			ribbonToggleButton5.Name = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisIntervalAutomatic.ToString();
			ribbonToggleButton5.DisplayMode = IconTextRelation.SmallIconUnlabeled;
			RibbonToggleButton ribbonToggleButton6 = ribbonToggleButton5;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonSplitButton2, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonSplitButton4, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonSplitButton6, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonToggleButton2, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonToggleButton4, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonToggleButton6, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonTextBox2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonTextBox4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonTextBox6, null, hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[9] { ribbonSplitButton2, ribbonSplitButton4, ribbonSplitButton6, ribbonToggleButton2, ribbonToggleButton4, ribbonToggleButton6, ribbonTextBox2, ribbonTextBox4, ribbonTextBox6 });
			Class517.smethod_29(this.dictionary_4);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal override void vmethod_0(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "CanEdit")
			{
				(base.bindingAdapter_0 as Class472).method_19();
			}
		}
	}
}
