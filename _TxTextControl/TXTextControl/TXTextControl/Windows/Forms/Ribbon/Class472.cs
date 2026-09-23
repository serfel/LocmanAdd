using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using ns25;
using ns27;
using TXTextControl;
using TXTextControl.DataVisualization;
using DocumentServer.Windows.Forms;
using TXTextControl.ProxyClasses.Charts;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class472 : BindingAdapter
	{
		private Class501 class501_0;

		private ColorDialog colorDialog_0;

		private bool bool_0;

		private double double_0 = 1.0;

		private double? nullable_0 = null;

		private double? nullable_1 = null;

		private double? nullable_2 = null;

		private double? nullable_3 = null;

		private double? nullable_4 = null;

		private double? nullable_5 = null;

		private ChartDashStyle chartDashStyle_0 = ChartDashStyle.Solid;

		private ChartDashStyle chartDashStyle_1 = ChartDashStyle.Solid;

		private ChartDashStyle chartDashStyle_2 = ChartDashStyle.Solid;

		private ChartDashStyle chartDashStyle_3 = ChartDashStyle.Solid;

		private ChartDashStyle chartDashStyle_4 = ChartDashStyle.Solid;

		private ChartDashStyle chartDashStyle_5 = ChartDashStyle.Solid;

		internal override Class500 RibbonGroupManager
		{
			get
			{
				return this.class501_0;
			}
			set
			{
				this.class501_0 = value as Class501;
			}
		}

		private void method_0(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton = control_0 as RibbonMenuButton;
			if (ribbonMenuButton != null)
			{
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_LegendShow.ToString(), null, this);
				ribbonToggleButton.CheckedChanged += TXITEM_Legend_Handler;
				RibbonMenuButton ribbonMenuButton2 = (RibbonMenuButton)Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_LegendDocking.ToString(), null, this);
				this.method_13(dictionary_0, ribbonMenuButton2);
				RibbonMenuButton ribbonMenuButton3 = (RibbonMenuButton)Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_LegendAlignment.ToString(), null, this);
				this.method_12(dictionary_0, ribbonMenuButton3);
				RibbonMenuButton ribbonMenuButton4 = (RibbonMenuButton)Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_LegendColor.ToString(), null, this);
				base.Set_TXITEM_Color_DropDown(dictionary_0, ribbonMenuButton4, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_LegendColor_Automatic.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_LegendColorSeperator1.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_LegendColor_Gallery.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_LegendColorSeperator2.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_LegendColor_MoreColors.ToString());
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_LegendFont.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[5] { ribbonToggleButton, ribbonMenuButton2, ribbonMenuButton3, ribbonMenuButton4, ribbonButton });
			}
		}

		private void method_1(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonSplitButton ribbonSplitButton = control_0 as RibbonSplitButton;
			if (ribbonSplitButton != null)
			{
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLabelsShow.ToString(), null, this);
				ribbonToggleButton.CheckedChanged += TXITEM_XAxisLabels_Handler;
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLabelsColor.ToString(), null, this);
				base.Set_TXITEM_Color_DropDown(dictionary_0, ribbonMenuButton, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLabelsColor_Automatic.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLabelsColorSeperator1.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLabelsColor_Gallery.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLabelsColorSeperator2.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLabelsColor_MoreColors.ToString());
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLabelsFont.ToString(), "Click", this);
				ribbonSplitButton.DropDownItems.AddRange(new Control[3] { ribbonToggleButton, ribbonMenuButton, ribbonButton });
			}
		}

		private void method_2(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonSplitButton ribbonSplitButton = control_0 as RibbonSplitButton;
			if (ribbonSplitButton != null)
			{
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLabelsShow.ToString(), null, this);
				ribbonToggleButton.CheckedChanged += TXITEM_YAxisLabels_Handler;
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLabelsColor.ToString(), null, this);
				base.Set_TXITEM_Color_DropDown(dictionary_0, ribbonMenuButton, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLabelsColor_Automatic.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLabelsColorSeperator1.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLabelsColor_Gallery.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLabelsColorSeperator2.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLabelsColor_MoreColors.ToString());
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLabelsFont.ToString(), "Click", this);
				ribbonSplitButton.DropDownItems.AddRange(new Control[3] { ribbonToggleButton, ribbonMenuButton, ribbonButton });
			}
		}

		private void method_3(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton = control_0 as RibbonMenuButton;
			if (ribbonMenuButton != null)
			{
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_ChartTitleDocking.ToString(), null, this);
				this.method_13(dictionary_0, ribbonButton);
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_ChartTitleOrientation.ToString(), null, this);
				this.method_14(dictionary_0, ribbonButton2);
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_ChartTitleColor.ToString(), null, this);
				base.Set_TXITEM_Color_DropDown(dictionary_0, ribbonButton3, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_ChartTitleColor_Automatic.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_ChartTitleColorSeperator1.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_ChartTitleColor_Gallery.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_ChartTitleSeperator2.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_ChartTitle_MoreColors.ToString());
				RibbonButton ribbonButton4 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_ChartTitleFont.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[4] { ribbonButton, ribbonButton2, ribbonButton3, ribbonButton4 });
			}
		}

		private void method_4(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton = control_0 as RibbonMenuButton;
			if (ribbonMenuButton != null)
			{
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisTitleAlignment.ToString(), null, this);
				this.method_12(dictionary_0, ribbonButton);
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisTitleOrientation.ToString(), null, this);
				this.method_14(dictionary_0, ribbonButton2);
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisTitleColor.ToString(), null, this);
				base.Set_TXITEM_Color_DropDown(dictionary_0, ribbonButton3, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisTitleColor_Automatic.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisTitleColorSeperator1.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisTitleColor_Gallery.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisTitleColorSeperator2.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisTitleColor_MoreColors.ToString());
				RibbonButton ribbonButton4 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisTitleFont.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[4] { ribbonButton, ribbonButton2, ribbonButton3, ribbonButton4 });
			}
		}

		private void method_5(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton = control_0 as RibbonMenuButton;
			if (ribbonMenuButton != null)
			{
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisTitleAlignment.ToString(), null, this);
				this.method_12(dictionary_0, ribbonButton);
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisTitleOrientation.ToString(), null, this);
				this.method_14(dictionary_0, ribbonButton2);
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisTitleColor.ToString(), null, this);
				base.Set_TXITEM_Color_DropDown(dictionary_0, ribbonButton3, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisTitleColor_Automatic.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisTitleColorSeperator1.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisTitleColor_Gallery.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisTitleColorSeperator2.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisTitleColor_MoreColors.ToString());
				RibbonButton ribbonButton4 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisTitleFont.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[4] { ribbonButton, ribbonButton2, ribbonButton3, ribbonButton4 });
			}
		}

		private void method_6(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonSplitButton ribbonSplitButton = control_0 as RibbonSplitButton;
			if (ribbonSplitButton != null)
			{
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLineShow.ToString(), null, this);
				ribbonToggleButton.CheckedChanged += TXITEM_XAxisLine_Handler;
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLineColor.ToString(), null, this);
				base.Set_TXITEM_Color_DropDown(dictionary_0, ribbonMenuButton, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLineColor_Automatic.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLineColorSeperator1.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLineColor_Gallery.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLineColorSeperator2.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLineColor_MoreColors.ToString());
				RibbonMenuButton ribbonMenuButton2 = (RibbonMenuButton)Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLineDashType.ToString(), null, this);
				this.method_15(dictionary_0, ribbonMenuButton2);
				ribbonSplitButton.DropDownItems.AddRange(new Control[3] { ribbonToggleButton, ribbonMenuButton, ribbonMenuButton2 });
			}
		}

		private void method_7(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonSplitButton ribbonSplitButton = control_0 as RibbonSplitButton;
			if (ribbonSplitButton != null)
			{
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMajorGridlinesShow.ToString(), null, this);
				ribbonToggleButton.CheckedChanged += TXITEM_XAxisMajorGridlines_Handler;
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMajorGridlinesColor.ToString(), null, this);
				base.Set_TXITEM_Color_DropDown(dictionary_0, ribbonButton, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMajorGridlinesColor_Automatic.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMajorGridlinesColorSeperator1.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMajorGridlinesColor_Gallery.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMajorGridlinesColorSeperator2.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMajorGridlinesColor_MoreColors.ToString());
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMajorGridlinesDashType.ToString(), null, this);
				this.method_15(dictionary_0, ribbonButton2);
				ribbonSplitButton.DropDownItems.AddRange(new Control[3] { ribbonToggleButton, ribbonButton, ribbonButton2 });
			}
		}

		private void method_8(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonSplitButton ribbonSplitButton = control_0 as RibbonSplitButton;
			if (ribbonSplitButton != null)
			{
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinorGridlinesShow.ToString(), null, this);
				ribbonToggleButton.CheckedChanged += TXITEM_XAxisMinorGridlines_Handler;
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinorGridlinesColor.ToString(), null, this);
				base.Set_TXITEM_Color_DropDown(dictionary_0, ribbonMenuButton, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinorGridlinesColor_Automatic.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinorGridlinesColorSeperator1.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinorGridlinesColor_Gallery.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinorGridlinesColorSeperator2.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinorGridlinesColor_MoreColors.ToString());
				RibbonMenuButton ribbonMenuButton2 = (RibbonMenuButton)Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinorGridlinesDashType.ToString(), null, this);
				this.method_15(dictionary_0, ribbonMenuButton2);
				ribbonSplitButton.DropDownItems.AddRange(new Control[3] { ribbonToggleButton, ribbonMenuButton, ribbonMenuButton2 });
			}
		}

		private void method_9(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonSplitButton ribbonSplitButton = control_0 as RibbonSplitButton;
			if (ribbonSplitButton != null)
			{
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLineShow.ToString(), null, this);
				ribbonToggleButton.CheckedChanged += TXITEM_YAxisLine_Handler;
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLineColor.ToString(), null, this);
				base.Set_TXITEM_Color_DropDown(dictionary_0, ribbonMenuButton, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLineColor_Automatic.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLineColorSeperator1.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLineColor_Gallery.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLineColorSeperator2.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLineColor_MoreColors.ToString());
				RibbonMenuButton ribbonMenuButton2 = (RibbonMenuButton)Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLineDashType.ToString(), null, this);
				this.method_15(dictionary_0, ribbonToggleButton);
				ribbonSplitButton.DropDownItems.AddRange(new Control[3] { ribbonToggleButton, ribbonMenuButton, ribbonMenuButton2 });
			}
		}

		private void method_10(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonSplitButton ribbonSplitButton = control_0 as RibbonSplitButton;
			if (ribbonSplitButton != null)
			{
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMajorGridlinesShow.ToString(), null, this);
				ribbonToggleButton.CheckedChanged += TXITEM_YAxisMajorGridlines_Handler;
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMajorGridlinesColor.ToString(), null, this);
				base.Set_TXITEM_Color_DropDown(dictionary_0, ribbonMenuButton, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMajorGridlinesColor_Automatic.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMajorGridlinesColorSeperator1.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMajorGridlinesColor_Gallery.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMajorGridlinesColorSeperator2.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMajorGridlinesColor_MoreColors.ToString());
				RibbonMenuButton ribbonMenuButton2 = (RibbonMenuButton)Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMajorGridlinesDashType.ToString(), null, this);
				this.method_15(dictionary_0, ribbonMenuButton2);
				ribbonSplitButton.DropDownItems.AddRange(new Control[3] { ribbonToggleButton, ribbonMenuButton, ribbonMenuButton2 });
			}
		}

		private void method_11(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonSplitButton ribbonSplitButton = control_0 as RibbonSplitButton;
			if (ribbonSplitButton != null)
			{
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinorGridlinesShow.ToString(), null, this);
				ribbonToggleButton.CheckedChanged += TXITEM_YAxisMinorGridlines_Handler;
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinorGridlinesColor.ToString(), null, this);
				base.Set_TXITEM_Color_DropDown(dictionary_0, ribbonMenuButton, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinorGridlinesColor_Automatic.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinorGridlinesColorSeperator1.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinorGridlinesColor_Gallery.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinorGridlinesColorSeperator2.ToString(), RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinorGridlinesColor_MoreColors.ToString());
				RibbonMenuButton ribbonMenuButton2 = (RibbonMenuButton)Class517.smethod_26(dictionary_0, Enum133.const_1, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinorGridlinesDashType.ToString(), null, this);
				this.method_15(dictionary_0, ribbonMenuButton2);
				ribbonSplitButton.DropDownItems.AddRange(new Control[3] { ribbonToggleButton, ribbonMenuButton, ribbonMenuButton2 });
			}
		}

		private void method_12(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				if (ribbonMenuButton.Name == RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisTitleAlignment.ToString())
				{
					this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "Far", null, ribbonMenuButton.Name);
					this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "Center", null, ribbonMenuButton.Name);
					this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "Near", null, ribbonMenuButton.Name);
				}
				else
				{
					this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "Near", null, ribbonMenuButton.Name);
					this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "Center", null, ribbonMenuButton.Name);
					this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "Far", null, ribbonMenuButton.Name);
				}
			}
		}

		private void method_13(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "Left", null, ribbonMenuButton.Name);
				this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "Top", null, ribbonMenuButton.Name);
				this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "Right", null, ribbonMenuButton.Name);
				this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "Bottom", null, ribbonMenuButton.Name);
			}
		}

		private void method_14(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "Auto", null, ribbonMenuButton.Name);
				this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "Horizontal", null, ribbonMenuButton.Name);
				this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "Rotated270", null, ribbonMenuButton.Name);
				this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "Rotated90", null, ribbonMenuButton.Name);
				this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "Stacked", null, ribbonMenuButton.Name);
			}
		}

		private void method_15(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "Dash", "line", ribbonMenuButton.Name);
				this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "DashDot", "line", ribbonMenuButton.Name);
				this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "DashDotDot", "line", ribbonMenuButton.Name);
				this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "Dot", "line", ribbonMenuButton.Name);
				this.method_16(dictionary_0, ribbonMenuButton.DropDownItems, "Solid", "line", ribbonMenuButton.Name);
			}
		}

		private void method_16(Dictionary<string, object> dictionary_0, RibbonItemCollection ribbonItemCollection_0, string string_0, string string_1, string string_2)
		{
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			ribbonToggleButton2.Tag = string_0;
			ribbonToggleButton2.Name = string_2 + "_" + string_0;
			ribbonToggleButton2.Text = base.m_rmResourceManager.GetString(ribbonToggleButton2.Name.Replace("TXITEM", "HEADER"));
			ribbonItemCollection_0.Add(ribbonToggleButton2);
			ribbonToggleButton2.Click += method_58;
			dictionary_0.Add(ribbonToggleButton2.Name, ribbonToggleButton2);
			IRibbonItem ribbonItem = ribbonToggleButton2;
			if (string_1 != null)
			{
				ribbonItem.HasSmallIcon = true;
			}
			ribbonItem.IsDefaultRibbonTabItem = true;
		}

		internal override void AwareOfDPI(PointF dpi)
		{
			base.AwareOfDPI(dpi);
			base.SetColorGalleryItems(this.class501_0.TXITEM_LabelsGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_LegendColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetColorGalleryItems(this.class501_0.TXITEM_LabelsGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLabelsColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetColorGalleryItems(this.class501_0.TXITEM_LabelsGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLabelsColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetColorGalleryItems(this.class501_0.TXITEM_TitlesGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_ChartTitleColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetColorGalleryItems(this.class501_0.TXITEM_TitlesGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisTitleColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetColorGalleryItems(this.class501_0.TXITEM_TitlesGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisTitleColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetColorGalleryItems(this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLineColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetColorGalleryItems(this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMajorGridlinesColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetColorGalleryItems(this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinorGridlinesColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetColorGalleryItems(this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLineColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetColorGalleryItems(this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMajorGridlinesColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetColorGalleryItems(this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinorGridlinesColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
		}

		internal override void SetRibbonItemAppearance(Dictionary<string, object> groupItemsDictionary, Control ribbonItem, string eventName, bool hasImage)
		{
			base.SetBasicRibbonItemAppearance(groupItemsDictionary, ribbonItem, hasImage);
			switch (ribbonItem.Name)
			{
			case "TXITEM_Legend":
				this.method_0(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_XAxisLabels":
				this.method_1(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_YAxisLabels":
				this.method_2(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_ChartTitle":
			case "TXITEM_XAxisTitle":
			case "TXITEM_YAxisTitle":
			{
				RibbonTextBox ribbonTextBox2 = ribbonItem as RibbonTextBox;
				base.SetBasicRibbonTextBoxAppearance(ribbonTextBox2, hasImage, showDropDownButtons: false, RibbonTextBox.InputValidationMode.All);
				ribbonTextBox2.TextValidated += method_54;
				break;
			}
			case "TXITEM_FormatChartTitle":
				this.method_3(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_FormatXAxisTitle":
				this.method_4(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_FormatYAxisTitle":
				this.method_5(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_XAxisLine":
				this.method_6(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_XAxisMajorGridlines":
				this.method_7(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_XAxisMinorGridlines":
				this.method_8(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_YAxisLine":
				this.method_9(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_YAxisMajorGridlines":
				this.method_10(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_YAxisMinorGridlines":
				this.method_11(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_XAxisMinimum":
			case "TXITEM_XAxisMaximum":
			case "TXITEM_XAxisInterval":
			case "TXITEM_YAxisMinimum":
			case "TXITEM_YAxisMaximum":
			case "TXITEM_YAxisInterval":
			{
				RibbonTextBox ribbonTextBox = ribbonItem as RibbonTextBox;
				base.SetBasicRibbonTextBoxAppearance(ribbonTextBox, hasImage, showDropDownButtons: true, RibbonTextBox.InputValidationMode.OnlyDigits);
				ribbonTextBox.Nullable_0 = 1;
				ribbonTextBox.UpButtonClicked += method_56;
				ribbonTextBox.DownButtonClicked += method_57;
				ribbonTextBox.TextValidated += method_55;
				break;
			}
			}
			if (!string.IsNullOrEmpty(eventName))
			{
				Class517.smethod_23(ribbonItem, eventName, ribbonItem.Name + "_Handler", this);
			}
		}

		internal override void OnDisconnectingTextControl()
		{
			base.m_txTextControl.ChartSelected -= method_86;
			base.m_txTextControl.ChartDeselected -= method_85;
		}

		internal override void OnTextControlConnected()
		{
			base.m_txTextControl.ChartSelected += method_86;
			base.m_txTextControl.ChartDeselected += method_85;
		}

		private void method_17()
		{
			this.UpdateRibbonTab(new object[1] { null });
		}

		private void method_18(ChartFrame chartFrame_0)
		{
			this.UpdateRibbonTab(chartFrame_0);
		}

		internal void method_19()
		{
			this.UpdateRibbonTab();
		}

		internal override void UpdateRibbonTab(params object[] args)
		{
			ChartFrame chartFrame = ((args.Length == 0) ? base.m_txTextControl.Charts.GetItem() : ((ChartFrame)args[0]));
			if (!this.class501_0.Boolean_0)
			{
				return;
			}
			RibbonGroup ribbonGroup = this.class501_0.TXITEM_DataGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_DataGroup.ToString()] as RibbonGroup;
			RibbonGroup ribbonGroup2 = this.class501_0.TXITEM_LabelsGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_LabelsGroup.ToString()] as RibbonGroup;
			RibbonGroup ribbonGroup3 = this.class501_0.TXITEM_TitlesGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_TitlesGroup.ToString()] as RibbonGroup;
			RibbonGroup ribbonGroup4 = this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisGroup.ToString()] as RibbonGroup;
			RibbonGroup ribbonGroup5 = this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisGroup.ToString()] as RibbonGroup;
			bool flag = chartFrame != null && base.m_txTextControl.CanEdit && Class440.Assembly_0 != null;
			bool flag3 = (ribbonGroup5.Enabled = flag);
			bool flag5 = (ribbonGroup4.Enabled = flag3);
			bool flag7 = (ribbonGroup3.Enabled = flag5);
			bool enabled = (ribbonGroup2.Enabled = flag7);
			ribbonGroup.Enabled = enabled;
			if (flag)
			{
				Class440 class440_ = new Class440(chartFrame);
				Class454.SeriesChartType seriesChartType = this.method_63(class440_);
				this.bool_0 = false;
				bool flag9 = false;
				switch (seriesChartType)
				{
				case Class454.SeriesChartType.Pie:
				case Class454.SeriesChartType.Doughnut:
					flag9 = true;
					break;
				case Class454.SeriesChartType.Bar:
				case Class454.SeriesChartType.StackedBar:
				case Class454.SeriesChartType.StackedBar100:
					this.bool_0 = true;
					break;
				}
				this.method_20(class440_);
				this.method_21(class440_);
				(this.class501_0.Control_0 as RibbonChartLayoutTab).method_2(flag9);
				if (!flag9)
				{
					this.method_22(class440_);
					this.method_23(class440_);
				}
			}
		}

		private void method_20(Class440 class440_0)
		{
			RibbonGroup ribbonGroup_ = this.class501_0.TXITEM_LabelsGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_LabelsGroup.ToString()] as RibbonGroup;
			if (this.class501_0.method_0(ribbonGroup_))
			{
				this.method_24(class440_0);
				this.method_25(class440_0, bool_1: true);
				this.method_25(class440_0, bool_1: false);
			}
		}

		private void method_21(Class440 class440_0)
		{
			RibbonGroup ribbonGroup_ = this.class501_0.TXITEM_TitlesGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_TitlesGroup.ToString()] as RibbonGroup;
			if (this.class501_0.method_0(ribbonGroup_))
			{
				this.method_26(class440_0);
				this.method_27(class440_0);
				this.method_28(class440_0, bool_1: true);
				this.method_28(class440_0, bool_1: false);
			}
		}

		private void method_22(Class440 class440_0)
		{
			RibbonGroup ribbonGroup_ = this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisGroup.ToString()] as RibbonGroup;
			if (this.class501_0.method_0(ribbonGroup_))
			{
				this.method_29(class440_0, bool_1: true);
				this.method_30(class440_0, bool_1: true, bool_2: true);
				this.method_30(class440_0, bool_1: true, bool_2: false);
				this.method_31(class440_0, bool_1: true);
			}
		}

		private void method_23(Class440 class440_0)
		{
			RibbonGroup ribbonGroup_ = this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisGroup.ToString()] as RibbonGroup;
			if (this.class501_0.method_0(ribbonGroup_))
			{
				this.method_29(class440_0, bool_1: false);
				this.method_30(class440_0, bool_1: false, bool_2: true);
				this.method_30(class440_0, bool_1: false, bool_2: false);
				this.method_31(class440_0, bool_1: false);
			}
		}

		private void method_24(Class440 class440_0)
		{
			RibbonSplitButton ribbonSplitButton = this.class501_0.TXITEM_LabelsGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_Legend.ToString()] as RibbonSplitButton;
			if (!this.class501_0.method_3(ribbonSplitButton))
			{
				return;
			}
			Docking docking = Docking.Right;
			StringAlignment stringAlignment = StringAlignment.Near;
			bool flag = true;
			bool flag2 = true;
			Color color_ = default(Color);
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			if (class440_0.Class449_0.Count > 0)
			{
				flag3 = true;
				flag4 = (flag5 = class440_0.Class449_0[0].Class447_0.Boolean_0);
				flag6 = true;
				flag = class440_0.Class449_0[0].Boolean_0;
				docking = class440_0.Class449_0[0].Docking_0;
				flag2 = class440_0.Class449_0[0].Docking_0 == Docking.Right || class440_0.Class449_0[0].Docking_0 == Docking.Left;
				stringAlignment = class440_0.Class449_0[0].StringAlignment_0;
				color_ = class440_0.Class449_0[0].Color_0;
				for (int i = 1; i < class440_0.Class449_0.Count; i++)
				{
					if (!flag3 && !flag4 && !flag5)
					{
						break;
					}
					if (flag3 && class440_0.Class449_0[i].Boolean_0 != flag)
					{
						flag3 = false;
					}
					if (flag4 && class440_0.Class449_0[i].Docking_0 != docking)
					{
						flag4 = false;
					}
					if (flag5 && class440_0.Class449_0[i].StringAlignment_0 != stringAlignment)
					{
						flag5 = false;
					}
					if (flag6 && class440_0.Class449_0[i].Color_0.ToArgb() != color_.ToArgb())
					{
						flag6 = false;
					}
					flag4 = flag4 && class440_0.Class449_0[i].Class447_0.Boolean_0;
					flag5 = flag5 && class440_0.Class449_0[i].Class447_0.Boolean_0;
				}
			}
			ribbonSplitButton.Checked = flag3 && flag;
			foreach (IRibbonItem dropDownItem in ribbonSplitButton.DropDownItems)
			{
				if (!dropDownItem.IsDefaultRibbonTabItem)
				{
					continue;
				}
				Control control = dropDownItem as Control;
				if (control.Name == RibbonChartLayoutTab.InternalRibbonItem.TXITEM_LegendShow.ToString())
				{
					(control as RibbonToggleButton).Checked = ribbonSplitButton.Checked;
				}
				else if (control.Name == RibbonChartLayoutTab.InternalRibbonItem.TXITEM_LegendDocking.ToString())
				{
					RibbonMenuButton ribbonMenuButton = control as RibbonMenuButton;
					foreach (IRibbonItem dropDownItem2 in ribbonMenuButton.DropDownItems)
					{
						if (dropDownItem2.IsDefaultRibbonTabItem && dropDownItem2 is RibbonToggleButton)
						{
							RibbonToggleButton ribbonToggleButton = dropDownItem2 as RibbonToggleButton;
							ribbonToggleButton.Checked = flag4 && ribbonToggleButton.Name.EndsWith(docking.ToString());
						}
					}
				}
				else if (control.Name == RibbonChartLayoutTab.InternalRibbonItem.TXITEM_LegendAlignment.ToString())
				{
					RibbonMenuButton ribbonMenuButton2 = control as RibbonMenuButton;
					string string_ = (flag2 ? "ChartLegendAlignmentVertical" : "ChartLegendAlignmentHorizontal");
					ribbonMenuButton2.SmallIcon = Class517.smethod_53(string_, ImageProvider.ImageKind.Small_16x16, base.m_pntDPI);
					foreach (IRibbonItem dropDownItem3 in ribbonMenuButton2.DropDownItems)
					{
						if (dropDownItem3.IsDefaultRibbonTabItem && dropDownItem3 is RibbonToggleButton)
						{
							RibbonToggleButton ribbonToggleButton2 = dropDownItem3 as RibbonToggleButton;
							ribbonToggleButton2.Checked = flag5 && ribbonToggleButton2.Name.EndsWith(stringAlignment.ToString());
							string text = ribbonToggleButton2.Name.Replace("TXITEM_", "HEADER_");
							ribbonToggleButton2.Text = ((!flag5) ? base.m_rmResourceManager.GetString(text) : (flag2 ? base.m_rmResourceManager.GetString(text + "_Vertical") : base.m_rmResourceManager.GetString(text + "_Horizontal")));
						}
					}
				}
				else if (control.Name == RibbonChartLayoutTab.InternalRibbonItem.TXITEM_LegendColor.ToString())
				{
					RibbonMenuButton ribbonMenuButton_ = control as RibbonMenuButton;
					this.method_84(ribbonMenuButton_, color_, Color.Black);
				}
			}
		}

		private void method_25(Class440 class440_0, bool bool_1)
		{
			RibbonSplitButton ribbonSplitButton = (bool_1 ? (this.class501_0.TXITEM_LabelsGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLabels.ToString()] as RibbonSplitButton) : (this.class501_0.TXITEM_LabelsGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLabels.ToString()] as RibbonSplitButton));
			if (!this.class501_0.method_3(ribbonSplitButton))
			{
				return;
			}
			bool flag = true;
			Color color = default(Color);
			bool flag2 = false;
			bool flag3 = false;
			if (class440_0.Class435_0.Count > 0)
			{
				Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_0.Class435_0[0].Class439_0 : class440_0.Class435_0[0].Class439_2);
				Class448 class448_ = @class.Class448_0;
				flag3 = true;
				flag2 = true;
				flag = class448_.Boolean_0;
				color = class448_.Color_0;
				for (int i = 1; i < class440_0.Class435_0.Count; i++)
				{
					if (!flag2 && !flag3)
					{
						break;
					}
					@class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_0.Class435_0[i].Class439_0 : class440_0.Class435_0[i].Class439_2);
					class448_ = @class.Class448_0;
					if (flag2 && class448_.Boolean_0 != flag)
					{
						flag2 = false;
					}
					if (flag3 && class448_.Color_0 != color)
					{
						flag3 = false;
					}
				}
			}
			RibbonChartLayoutTab.InternalRibbonItem internalRibbonItem = (bool_1 ? RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLabelsShow : RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLabelsShow);
			RibbonChartLayoutTab.InternalRibbonItem internalRibbonItem2 = (bool_1 ? RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLabelsColor : RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLabelsColor);
			ribbonSplitButton.Checked = flag2 && flag;
			foreach (IRibbonItem dropDownItem in ribbonSplitButton.DropDownItems)
			{
				if (dropDownItem.IsDefaultRibbonTabItem)
				{
					Control control = dropDownItem as Control;
					if (control.Name == internalRibbonItem.ToString())
					{
						(control as RibbonToggleButton).Checked = ribbonSplitButton.Checked;
					}
					else if (control.Name == internalRibbonItem2.ToString())
					{
						RibbonMenuButton ribbonMenuButton_ = control as RibbonMenuButton;
						this.method_84(ribbonMenuButton_, color, Color.Black);
					}
				}
			}
		}

		private void method_26(Class440 class440_0)
		{
			RibbonGroup object_ = this.class501_0.TXITEM_TitlesGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_ChartTitle.ToString()] as RibbonGroup;
			if (!this.class501_0.method_2(object_))
			{
				return;
			}
			string text = null;
			string text2 = null;
			string text3 = null;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			if (class440_0.Class441_0.Count > 0)
			{
				flag = true;
				text = class440_0.Class441_0[0].String_1;
				for (int i = 1; i < class440_0.Class441_0.Count; i++)
				{
					if (flag && class440_0.Class441_0[i].String_1 != text)
					{
						flag = false;
						break;
					}
				}
			}
			if (class440_0.Class435_0.Count > 0)
			{
				flag3 = true;
				flag2 = true;
				Class439 class439_ = class440_0.Class435_0[0].Class439_0;
				Class439 class439_2 = class440_0.Class435_0[0].Class439_2;
				text2 = class440_0.Class435_0[0].Class439_0.String_0;
				text3 = class440_0.Class435_0[0].Class439_2.String_0;
				for (int j = 1; j < class440_0.Class435_0.Count; j++)
				{
					if (!flag2 && !flag3)
					{
						break;
					}
					class439_ = class440_0.Class435_0[j].Class439_0;
					class439_2 = class440_0.Class435_0[j].Class439_2;
					if (flag2 && class439_.String_0 != text2)
					{
						flag2 = false;
					}
					if (flag3 && class439_2.String_0 != text3)
					{
						flag3 = false;
					}
				}
			}
			RibbonTextBox ribbonTextBox = this.class501_0.TXITEM_TitlesGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_ChartTitle.ToString()] as RibbonTextBox;
			ribbonTextBox.Text = ((!flag || text == null) ? "" : text);
			RibbonTextBox ribbonTextBox2 = ((!this.bool_0) ? (this.class501_0.TXITEM_TitlesGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisTitle.ToString()] as RibbonTextBox) : (this.class501_0.TXITEM_TitlesGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisTitle.ToString()] as RibbonTextBox));
			ribbonTextBox2.Text = ((!flag2 || text2 == null) ? "" : text2);
			RibbonTextBox ribbonTextBox3 = ((!this.bool_0) ? (this.class501_0.TXITEM_TitlesGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisTitle.ToString()] as RibbonTextBox) : (this.class501_0.TXITEM_TitlesGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisTitle.ToString()] as RibbonTextBox));
			ribbonTextBox3.Text = ((!flag3 || text3 == null) ? "" : text3);
		}

		private void method_27(Class440 class440_0)
		{
			RibbonMenuButton ribbonMenuButton = this.class501_0.TXITEM_TitlesGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_FormatChartTitle.ToString()] as RibbonMenuButton;
			if (!this.class501_0.method_3(ribbonMenuButton))
			{
				return;
			}
			Docking docking = Docking.Right;
			TextOrientation textOrientation = TextOrientation.Auto;
			Color color_ = default(Color);
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			if (class440_0.Class441_0.Count > 0)
			{
				flag3 = true;
				flag2 = true;
				flag = true;
				docking = class440_0.Class441_0[0].Docking_0;
				textOrientation = class440_0.Class441_0[0].TextOrientation_0;
				color_ = class440_0.Class441_0[0].Color_0;
				for (int i = 1; i < class440_0.Class441_0.Count; i++)
				{
					if (!flag && !flag2 && !flag3)
					{
						break;
					}
					if (flag && class440_0.Class441_0[i].Docking_0 != docking)
					{
						flag = false;
					}
					if (flag2 && class440_0.Class441_0[i].TextOrientation_0 != textOrientation)
					{
						flag2 = false;
					}
					if (flag3 && class440_0.Class441_0[i].Color_0.ToArgb() != color_.ToArgb())
					{
						flag3 = false;
					}
				}
			}
			foreach (IRibbonItem dropDownItem in ribbonMenuButton.DropDownItems)
			{
				if (!dropDownItem.IsDefaultRibbonTabItem)
				{
					continue;
				}
				Control control = dropDownItem as Control;
				if (control.Name == RibbonChartLayoutTab.InternalRibbonItem.TXITEM_ChartTitleDocking.ToString())
				{
					RibbonMenuButton ribbonMenuButton2 = control as RibbonMenuButton;
					foreach (IRibbonItem dropDownItem2 in ribbonMenuButton2.DropDownItems)
					{
						if (dropDownItem2.IsDefaultRibbonTabItem && dropDownItem2 is RibbonToggleButton)
						{
							RibbonToggleButton ribbonToggleButton = dropDownItem2 as RibbonToggleButton;
							ribbonToggleButton.Checked = flag && ribbonToggleButton.Name.EndsWith(docking.ToString());
						}
					}
				}
				else if (control.Name == RibbonChartLayoutTab.InternalRibbonItem.TXITEM_ChartTitleOrientation.ToString())
				{
					RibbonMenuButton ribbonMenuButton3 = control as RibbonMenuButton;
					foreach (IRibbonItem dropDownItem3 in ribbonMenuButton3.DropDownItems)
					{
						if (dropDownItem3.IsDefaultRibbonTabItem && dropDownItem3 is RibbonToggleButton)
						{
							RibbonToggleButton ribbonToggleButton2 = dropDownItem3 as RibbonToggleButton;
							ribbonToggleButton2.Checked = flag2 && ribbonToggleButton2.Name.EndsWith(textOrientation.ToString());
						}
					}
				}
				else if (control.Name == RibbonChartLayoutTab.InternalRibbonItem.TXITEM_ChartTitleColor.ToString())
				{
					RibbonMenuButton ribbonMenuButton_ = control as RibbonMenuButton;
					this.method_84(ribbonMenuButton_, color_, Color.Black);
				}
			}
		}

		private void method_28(Class440 class440_0, bool bool_1)
		{
			RibbonMenuButton ribbonMenuButton = (bool_1 ? (this.class501_0.TXITEM_TitlesGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_FormatXAxisTitle.ToString()] as RibbonMenuButton) : (this.class501_0.TXITEM_TitlesGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_FormatYAxisTitle.ToString()] as RibbonMenuButton));
			if (!this.class501_0.method_3(ribbonMenuButton))
			{
				return;
			}
			StringAlignment stringAlignment = StringAlignment.Center;
			TextOrientation textOrientation = TextOrientation.Auto;
			Color color_ = default(Color);
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			if (class440_0.Class435_0.Count > 0)
			{
				flag3 = true;
				flag2 = true;
				flag = true;
				Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_0.Class435_0[0].Class439_0 : class440_0.Class435_0[0].Class439_2);
				stringAlignment = @class.StringAlignment_0;
				textOrientation = @class.TextOrientation_0;
				color_ = @class.Color_1;
				for (int i = 1; i < class440_0.Class435_0.Count; i++)
				{
					if (!flag && !flag2 && !flag3)
					{
						break;
					}
					@class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_0.Class435_0[i].Class439_0 : class440_0.Class435_0[i].Class439_2);
					if (flag && @class.StringAlignment_0 != stringAlignment)
					{
						flag = false;
					}
					if (flag2 && @class.TextOrientation_0 != textOrientation)
					{
						flag2 = false;
					}
					if (flag3 && @class.Color_1.ToArgb() != color_.ToArgb())
					{
						flag3 = false;
					}
				}
			}
			string text = (bool_1 ? RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisTitleAlignment.ToString() : RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisTitleAlignment.ToString());
			string text2 = (bool_1 ? RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisTitleOrientation.ToString() : RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisTitleOrientation.ToString());
			string text3 = (bool_1 ? RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisTitleColor.ToString() : RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisTitleColor.ToString());
			foreach (IRibbonItem dropDownItem in ribbonMenuButton.DropDownItems)
			{
				if (!dropDownItem.IsDefaultRibbonTabItem)
				{
					continue;
				}
				Control control = dropDownItem as Control;
				if (control.Name == text)
				{
					RibbonMenuButton ribbonMenuButton2 = control as RibbonMenuButton;
					foreach (IRibbonItem dropDownItem2 in ribbonMenuButton2.DropDownItems)
					{
						if (dropDownItem2.IsDefaultRibbonTabItem && dropDownItem2 is RibbonToggleButton)
						{
							RibbonToggleButton ribbonToggleButton = dropDownItem2 as RibbonToggleButton;
							ribbonToggleButton.Checked = flag && ribbonToggleButton.Name.EndsWith(stringAlignment.ToString());
						}
					}
				}
				else if (control.Name == text2)
				{
					RibbonMenuButton ribbonMenuButton3 = control as RibbonMenuButton;
					foreach (IRibbonItem dropDownItem3 in ribbonMenuButton3.DropDownItems)
					{
						if (dropDownItem3.IsDefaultRibbonTabItem && dropDownItem3 is RibbonToggleButton)
						{
							RibbonToggleButton ribbonToggleButton2 = dropDownItem3 as RibbonToggleButton;
							ribbonToggleButton2.Checked = flag2 && ribbonToggleButton2.Name.EndsWith(textOrientation.ToString());
						}
					}
				}
				else if (control.Name == text3)
				{
					RibbonMenuButton ribbonMenuButton_ = control as RibbonMenuButton;
					this.method_84(ribbonMenuButton_, color_, Color.Black);
				}
			}
		}

		private void method_29(Class440 class440_0, bool bool_1)
		{
			RibbonSplitButton ribbonSplitButton = (bool_1 ? (this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLine.ToString()] as RibbonSplitButton) : (this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLine.ToString()] as RibbonSplitButton));
			if (!this.class501_0.method_3(ribbonSplitButton))
			{
				return;
			}
			bool flag = false;
			Color color = default(Color);
			ChartDashStyle chartDashStyle = ChartDashStyle.Solid;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			if (class440_0.Class435_0.Count > 0)
			{
				Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_0.Class435_0[0].Class439_0 : class440_0.Class435_0[0].Class439_2);
				flag4 = true;
				flag3 = true;
				flag2 = true;
				flag = @class.AxisEnabled_0 != Class439.AxisEnabled.False;
				color = @class.Color_0;
				chartDashStyle = @class.ChartDashStyle_0;
				for (int i = 1; i < class440_0.Class435_0.Count; i++)
				{
					if (!flag4 && !flag3 && !flag4)
					{
						break;
					}
					@class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_0.Class435_0[i].Class439_0 : class440_0.Class435_0[i].Class439_2);
					if (flag2 && flag && @class.AxisEnabled_0 == Class439.AxisEnabled.False)
					{
						flag2 = false;
					}
					if (flag3 && @class.Color_0 != color)
					{
						flag3 = false;
					}
					if (flag4 && @class.ChartDashStyle_0 != chartDashStyle)
					{
						flag3 = false;
					}
				}
			}
			string text = (bool_1 ? RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLineShow.ToString() : RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLineShow.ToString());
			string text2 = (bool_1 ? RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLineColor.ToString() : RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLineColor.ToString());
			string text3 = (bool_1 ? RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisLineDashType.ToString() : RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisLineDashType.ToString());
			if (ribbonSplitButton.Checked = flag && flag2 && chartDashStyle != ChartDashStyle.NotSet)
			{
				if (bool_1 ? (!this.bool_0) : this.bool_0)
				{
					this.chartDashStyle_0 = chartDashStyle;
				}
				else
				{
					this.chartDashStyle_1 = chartDashStyle;
				}
			}
			foreach (IRibbonItem dropDownItem in ribbonSplitButton.DropDownItems)
			{
				if (!dropDownItem.IsDefaultRibbonTabItem)
				{
					continue;
				}
				Control control = dropDownItem as Control;
				if (control.Name == text)
				{
					(control as RibbonToggleButton).Checked = ribbonSplitButton.Checked;
				}
				else if (control.Name == text2)
				{
					RibbonMenuButton ribbonMenuButton_ = control as RibbonMenuButton;
					this.method_84(ribbonMenuButton_, color, Color.Black);
				}
				else
				{
					if (!(control.Name == text3))
					{
						continue;
					}
					RibbonMenuButton ribbonMenuButton = control as RibbonMenuButton;
					foreach (IRibbonItem dropDownItem2 in ribbonMenuButton.DropDownItems)
					{
						if (dropDownItem2.IsDefaultRibbonTabItem && dropDownItem2 is RibbonToggleButton)
						{
							RibbonToggleButton ribbonToggleButton = dropDownItem2 as RibbonToggleButton;
							ribbonToggleButton.Checked = flag3 && ribbonToggleButton.Name.EndsWith("_" + chartDashStyle);
						}
					}
				}
			}
		}

		private void method_30(Class440 class440_0, bool bool_1, bool bool_2)
		{
			RibbonSplitButton ribbonSplitButton;
			RibbonChartLayoutTab.InternalRibbonItem internalRibbonItem;
			RibbonChartLayoutTab.InternalRibbonItem internalRibbonItem2;
			RibbonChartLayoutTab.InternalRibbonItem internalRibbonItem3;
			if (bool_1)
			{
				if (bool_2)
				{
					ribbonSplitButton = this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMajorGridlines.ToString()] as RibbonSplitButton;
					internalRibbonItem = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMajorGridlinesShow;
					internalRibbonItem2 = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMajorGridlinesColor;
					internalRibbonItem3 = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMajorGridlinesDashType;
				}
				else
				{
					ribbonSplitButton = this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinorGridlines.ToString()] as RibbonSplitButton;
					internalRibbonItem = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinorGridlinesShow;
					internalRibbonItem2 = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinorGridlinesColor;
					internalRibbonItem3 = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinorGridlinesDashType;
				}
			}
			else if (bool_2)
			{
				ribbonSplitButton = this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMajorGridlines.ToString()] as RibbonSplitButton;
				internalRibbonItem = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMajorGridlinesShow;
				internalRibbonItem2 = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMajorGridlinesColor;
				internalRibbonItem3 = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMajorGridlinesDashType;
			}
			else
			{
				ribbonSplitButton = this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinorGridlines.ToString()] as RibbonSplitButton;
				internalRibbonItem = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinorGridlinesShow;
				internalRibbonItem2 = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinorGridlinesColor;
				internalRibbonItem3 = RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinorGridlinesDashType;
			}
			if (!this.class501_0.method_3(ribbonSplitButton))
			{
				return;
			}
			bool flag = false;
			Color color = default(Color);
			ChartDashStyle chartDashStyle = ChartDashStyle.Solid;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			if (class440_0.Class435_0.Count > 0)
			{
				Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_0.Class435_0[0].Class439_0 : class440_0.Class435_0[0].Class439_2);
				Class438 class2 = (bool_2 ? @class.Class438_0 : @class.Class438_1);
				flag4 = true;
				flag3 = true;
				flag2 = true;
				flag = class2.Boolean_0;
				color = class2.Color_0;
				chartDashStyle = class2.ChartDashStyle_0;
				for (int i = 1; i < class440_0.Class435_0.Count; i++)
				{
					if (!flag2 && !flag4 && !flag3)
					{
						break;
					}
					@class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_0.Class435_0[i].Class439_0 : class440_0.Class435_0[i].Class439_2);
					class2 = (bool_2 ? @class.Class438_0 : @class.Class438_1);
					if (flag2 && class2.Boolean_0 != flag)
					{
						flag2 = false;
					}
					if (flag3 && class2.Color_0 != color)
					{
						flag3 = false;
					}
					if (flag4 && class2.ChartDashStyle_0 != chartDashStyle)
					{
						flag3 = false;
					}
				}
			}
			if (ribbonSplitButton.Checked = flag2 && flag && flag4 && chartDashStyle != ChartDashStyle.NotSet)
			{
				if (bool_1 ? (!this.bool_0) : this.bool_0)
				{
					if (bool_2)
					{
						this.chartDashStyle_2 = chartDashStyle;
					}
					else
					{
						this.chartDashStyle_3 = chartDashStyle;
					}
				}
				else if (bool_2)
				{
					this.chartDashStyle_4 = chartDashStyle;
				}
				else
				{
					this.chartDashStyle_5 = chartDashStyle;
				}
			}
			foreach (IRibbonItem dropDownItem in ribbonSplitButton.DropDownItems)
			{
				if (!dropDownItem.IsDefaultRibbonTabItem)
				{
					continue;
				}
				Control control = dropDownItem as Control;
				if (control.Name == internalRibbonItem.ToString())
				{
					(control as RibbonToggleButton).Checked = ribbonSplitButton.Checked;
				}
				else if (control.Name == internalRibbonItem2.ToString())
				{
					RibbonMenuButton ribbonMenuButton_ = control as RibbonMenuButton;
					this.method_84(ribbonMenuButton_, color, Color.Black);
				}
				else
				{
					if (!(control.Name == internalRibbonItem3.ToString()))
					{
						continue;
					}
					RibbonMenuButton ribbonMenuButton = control as RibbonMenuButton;
					foreach (IRibbonItem dropDownItem2 in ribbonMenuButton.DropDownItems)
					{
						if (dropDownItem2.IsDefaultRibbonTabItem && dropDownItem2 is RibbonToggleButton)
						{
							RibbonToggleButton ribbonToggleButton = dropDownItem2 as RibbonToggleButton;
							ribbonToggleButton.Checked = flag3 && ribbonToggleButton.Name.EndsWith("_" + chartDashStyle);
						}
					}
				}
			}
		}

		private void method_31(Class440 class440_0, bool bool_1)
		{
			RibbonGroup object_ = (bool_1 ? (this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisGroup.ToString()] as RibbonGroup) : (this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisGroup.ToString()] as RibbonGroup));
			RibbonToggleButton ribbonToggleButton = (bool_1 ? (this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinimumAutomatic.ToString()] as RibbonToggleButton) : (this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinimumAutomatic.ToString()] as RibbonToggleButton));
			RibbonToggleButton ribbonToggleButton2 = (bool_1 ? (this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMaximumAutomatic.ToString()] as RibbonToggleButton) : (this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMaximumAutomatic.ToString()] as RibbonToggleButton));
			RibbonToggleButton ribbonToggleButton3 = (bool_1 ? (this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisIntervalAutomatic.ToString()] as RibbonToggleButton) : (this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisIntervalAutomatic.ToString()] as RibbonToggleButton));
			if (!this.class501_0.method_2(object_) && !this.class501_0.method_2(ribbonToggleButton) && !this.class501_0.method_2(ribbonToggleButton2) && !this.class501_0.method_2(ribbonToggleButton3))
			{
				return;
			}
			double num = double.NaN;
			bool flag = false;
			double num2 = double.NaN;
			bool flag2 = false;
			double num3 = double.NaN;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			if (class440_0.Class435_0.Count > 0)
			{
				flag5 = true;
				flag4 = true;
				flag3 = true;
				Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_0.Class435_0[0].Class439_0 : class440_0.Class435_0[0].Class439_2);
				num = @class.Double_1;
				flag = @class.Boolean_0;
				num2 = @class.Double_2;
				flag2 = @class.Boolean_1;
				num3 = @class.Double_0;
				for (int i = 1; i < class440_0.Class435_0.Count; i++)
				{
					if (!flag3 && !flag4 && !flag5)
					{
						break;
					}
					@class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_0.Class435_0[i].Class439_0 : class440_0.Class435_0[i].Class439_2);
					if (flag3 && @class.Double_1 != num)
					{
						flag3 = false;
					}
					if (flag4 && @class.Double_1 != num2)
					{
						flag4 = false;
					}
					if (flag5 && @class.Double_0 != num3)
					{
						flag5 = false;
					}
				}
			}
			RibbonTextBox ribbonTextBox = (bool_1 ? (this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinimum.ToString()] as RibbonTextBox) : (this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinimum.ToString()] as RibbonTextBox));
			RibbonTextBox ribbonTextBox2 = (bool_1 ? (this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMaximum.ToString()] as RibbonTextBox) : (this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMaximum.ToString()] as RibbonTextBox));
			RibbonTextBox ribbonTextBox3 = (bool_1 ? (this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisInterval.ToString()] as RibbonTextBox) : (this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisInterval.ToString()] as RibbonTextBox));
			ribbonToggleButton.Checked = flag4 && (double.IsNaN(num2) || flag2);
			ribbonTextBox.Enabled = !ribbonToggleButton.Checked;
			if (flag4)
			{
				ribbonTextBox.Text = (flag2 ? "" : num2.ToString());
				if (bool_1)
				{
					this.nullable_0 = (flag2 ? null : new double?(num2));
				}
				else
				{
					this.nullable_3 = (flag2 ? null : new double?(num2));
				}
			}
			ribbonToggleButton2.Checked = flag3 && (double.IsNaN(num) || flag);
			ribbonTextBox2.Enabled = !ribbonToggleButton2.Checked;
			if (flag3)
			{
				ribbonTextBox2.Text = (flag ? "" : num.ToString());
				if (bool_1)
				{
					this.nullable_1 = (flag ? null : new double?(num));
				}
				else
				{
					this.nullable_4 = (flag ? null : new double?(num));
				}
			}
			ribbonToggleButton3.Checked = flag5 && num3 == 0.0;
			ribbonTextBox3.Enabled = !ribbonToggleButton3.Checked;
			if (flag5)
			{
				ribbonTextBox3.Text = (ribbonToggleButton3.Checked ? "" : num3.ToString());
				if (bool_1)
				{
					this.nullable_2 = (ribbonToggleButton3.Checked ? null : new double?(num3));
				}
				else
				{
					this.nullable_5 = (ribbonToggleButton3.Checked ? null : new double?(num3));
				}
			}
		}

		protected override Color? GetCurrentColor(string colorButtonName)
		{
			Color? result = null;
			if (base.m_txTextControl != null)
			{
				switch (colorButtonName)
				{
				case "TXITEM_LegendColor":
					return this.method_62(bool_1: false);
				case "TXITEM_XAxisLabelsColor":
					return this.method_59(bool_1: true, bool_2: false);
				case "TXITEM_YAxisLabelsColor":
					return this.method_59(bool_1: false, bool_2: false);
				case "TXITEM_ChartTitleColor":
					return this.method_62(bool_1: true);
				case "TXITEM_XAxisTitleColor":
					return this.method_59(bool_1: true, bool_2: true);
				case "TXITEM_YAxisTitleColor":
					return this.method_59(bool_1: true, bool_2: true);
				case "TXITEM_XAxisLineColor":
					return this.method_61(bool_1: true);
				case "TXITEM_XAxisMajorGridlinesColor":
					return this.method_60(bool_1: true, bool_2: true);
				case "TXITEM_XAxisMinorGridlinesColor":
					return this.method_60(bool_1: true, bool_2: false);
				case "TXITEM_YAxisLineColor":
					return this.method_61(bool_1: false);
				case "TXITEM_YAxisMajorGridlinesColor":
					return this.method_60(bool_1: false, bool_2: true);
				case "TXITEM_YAxisMinorGridlinesColor":
					return this.method_60(bool_1: false, bool_2: false);
				}
			}
			return result;
		}

		private void method_32()
		{
			if (base.m_txTextControl != null && Class440.Assembly_0 != null)
			{
				ChartFrame item = base.m_txTextControl.Charts.GetItem();
				if (item != null)
				{
					ChartDataGridDialog chartDataGridDialog = new ChartDataGridDialog(base.m_txTextControl, item);
					chartDataGridDialog.StartPosition = FormStartPosition.Manual;
					chartDataGridDialog.Location = Class517.smethod_36(chartDataGridDialog.Size, item.Bounds, base.m_txTextControl);
					chartDataGridDialog.ShowDialog(this.class501_0.Control_0.FindForm());
				}
			}
		}

		private void method_33()
		{
			if (base.m_txTextControl != null && !(Class440.Assembly_0 == null) && (this.class501_0.Control_0 as RibbonChartLayoutTab).dataSourceManager_0 != null)
			{
				ChartFrame item = base.m_txTextControl.Charts.GetItem();
				if (item != null)
				{
					ChartDataRelationDialog chartDataRelationDialog = new ChartDataRelationDialog(item, (this.class501_0.Control_0 as RibbonChartLayoutTab).dataSourceManager_0);
					chartDataRelationDialog.StartPosition = FormStartPosition.Manual;
					chartDataRelationDialog.Location = Class517.smethod_36(chartDataRelationDialog.Size, item.Bounds, base.m_txTextControl);
					chartDataRelationDialog.ShowDialog(this.class501_0.Control_0.FindForm());
				}
			}
		}

		private void method_34(bool bool_1)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			foreach (Class451 item in (IEnumerable<Class451>)class440_.Class449_0)
			{
				item.Boolean_0 = bool_1;
			}
			chartFrame_.Refresh();
			this.method_24(class440_);
		}

		private void method_35()
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			FontDialog fontDialog = new FontDialog();
			Font font = this.method_68(class440_);
			if (font != null)
			{
				fontDialog.Font = font;
			}
			if (fontDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			foreach (Class451 item in (IEnumerable<Class451>)class440_.Class449_0)
			{
				item.Font_0 = fontDialog.Font;
			}
			chartFrame_.Refresh();
		}

		private void method_36()
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			FontDialog fontDialog = new FontDialog();
			Font font = this.method_65(class440_, bool_1: true, bool_2: false);
			if (font != null)
			{
				fontDialog.Font = font;
			}
			if (fontDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			foreach (Class437 item in (IEnumerable<Class437>)class440_.Class435_0)
			{
				Class439 @class = ((!this.bool_0) ? item.Class439_0 : item.Class439_2);
				@class.Class448_0.Font_0 = fontDialog.Font;
			}
			chartFrame_.Refresh();
		}

		private void method_37()
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			FontDialog fontDialog = new FontDialog();
			Font font = this.method_65(class440_, bool_1: false, bool_2: false);
			if (font != null)
			{
				fontDialog.Font = font;
			}
			if (fontDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			foreach (Class437 item in (IEnumerable<Class437>)class440_.Class435_0)
			{
				Class439 @class = ((!this.bool_0) ? item.Class439_2 : item.Class439_0);
				@class.Class448_0.Font_0 = fontDialog.Font;
			}
			chartFrame_.Refresh();
		}

		private void method_38(IRibbonItem iribbonItem_0, bool bool_1)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			bool boolean_ = ((iribbonItem_0 is RibbonToggleButton) ? (iribbonItem_0 as RibbonToggleButton).Checked : (iribbonItem_0 as RibbonSplitButton).Checked);
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			foreach (Class437 item in (IEnumerable<Class437>)class440_.Class435_0)
			{
				Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? item.Class439_0 : item.Class439_2);
				@class.Class448_0.Boolean_0 = boolean_;
				@class.Class455_0.Boolean_0 = boolean_;
			}
			chartFrame_.Refresh();
			this.method_25(class440_, bool_1);
		}

		private void method_39(RibbonTextBox ribbonTextBox_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			if (chartFrame_ == null)
			{
				return;
			}
			switch (ribbonTextBox_0.Name)
			{
			case "TXITEM_YAxisTitle":
				foreach (Class437 item in (IEnumerable<Class437>)class440_.Class435_0)
				{
					Class439 class2 = ((!this.bool_0) ? item.Class439_2 : item.Class439_0);
					class2.String_0 = ribbonTextBox_0.Text;
				}
				break;
			case "TXITEM_XAxisTitle":
				foreach (Class437 item2 in (IEnumerable<Class437>)class440_.Class435_0)
				{
					Class439 @class = ((!this.bool_0) ? item2.Class439_0 : item2.Class439_2);
					@class.String_0 = ribbonTextBox_0.Text;
				}
				break;
			case "TXITEM_ChartTitle":
				foreach (Class443 item3 in (IEnumerable<Class443>)class440_.Class441_0)
				{
					item3.String_1 = ribbonTextBox_0.Text;
				}
				break;
			}
			chartFrame_.Refresh();
		}

		private void method_40()
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			FontDialog fontDialog = new FontDialog();
			Font font = this.method_67(class440_);
			if (font != null)
			{
				fontDialog.Font = font;
			}
			if (fontDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			foreach (Class443 item in (IEnumerable<Class443>)class440_.Class441_0)
			{
				item.Font_0 = fontDialog.Font;
			}
			chartFrame_.Refresh();
		}

		private void method_41()
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			FontDialog fontDialog = new FontDialog();
			Font font = this.method_65(class440_, bool_1: true, bool_2: true);
			if (font != null)
			{
				fontDialog.Font = font;
			}
			if (fontDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			foreach (Class437 item in (IEnumerable<Class437>)class440_.Class435_0)
			{
				Class439 @class = ((!this.bool_0) ? item.Class439_0 : item.Class439_2);
				@class.Font_0 = fontDialog.Font;
			}
			chartFrame_.Refresh();
		}

		private void method_42()
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			FontDialog fontDialog = new FontDialog();
			Font font = this.method_65(class440_, bool_1: false, bool_2: true);
			if (font != null)
			{
				fontDialog.Font = font;
			}
			if (fontDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			foreach (Class437 item in (IEnumerable<Class437>)class440_.Class435_0)
			{
				Class439 @class = ((!this.bool_0) ? item.Class439_2 : item.Class439_0);
				@class.Font_0 = fontDialog.Font;
			}
			chartFrame_.Refresh();
		}

		private void method_43(IRibbonItem iribbonItem_0, bool bool_1)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			bool flag = ((iribbonItem_0 is RibbonToggleButton) ? (iribbonItem_0 as RibbonToggleButton).Checked : (iribbonItem_0 as RibbonSplitButton).Checked);
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			foreach (Class437 item in (IEnumerable<Class437>)class440_.Class435_0)
			{
				Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? item.Class439_0 : item.Class439_2);
				if (flag)
				{
					@class.AxisEnabled_0 = ((@class.AxisEnabled_0 == Class439.AxisEnabled.False) ? Class439.AxisEnabled.True : @class.AxisEnabled_0);
					@class.ChartDashStyle_0 = ((bool_1 ? (!this.bool_0) : this.bool_0) ? this.chartDashStyle_0 : this.chartDashStyle_1);
				}
				else
				{
					@class.ChartDashStyle_0 = ChartDashStyle.NotSet;
				}
			}
			chartFrame_.Refresh();
			this.method_29(class440_, bool_1);
		}

		private void method_44(IRibbonItem iribbonItem_0, bool bool_1, bool bool_2)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			bool flag = ((iribbonItem_0 is RibbonToggleButton) ? (iribbonItem_0 as RibbonToggleButton).Checked : (iribbonItem_0 as RibbonSplitButton).Checked);
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			foreach (Class437 item in (IEnumerable<Class437>)class440_.Class435_0)
			{
				Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? item.Class439_0 : item.Class439_2);
				Class438 class2 = (bool_2 ? @class.Class438_0 : @class.Class438_1);
				if (flag)
				{
					class2.Boolean_0 = true;
					if (bool_1 ? (!this.bool_0) : this.bool_0)
					{
						if (bool_2)
						{
							class2.ChartDashStyle_0 = this.chartDashStyle_2;
						}
						else
						{
							class2.ChartDashStyle_0 = this.chartDashStyle_3;
						}
					}
					else if (bool_2)
					{
						class2.ChartDashStyle_0 = this.chartDashStyle_4;
					}
					else
					{
						class2.ChartDashStyle_0 = this.chartDashStyle_5;
					}
				}
				else
				{
					class2.ChartDashStyle_0 = ChartDashStyle.NotSet;
				}
			}
			chartFrame_.Refresh();
			this.method_30(class440_, bool_1, bool_2);
		}

		private void method_45(RibbonToggleButton ribbonToggleButton_0, bool bool_1, bool bool_2)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			RibbonTextBox ribbonTextBox = ((!bool_1) ? (bool_2 ? (this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMaximum.ToString()] as RibbonTextBox) : (this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinimum.ToString()] as RibbonTextBox)) : (bool_2 ? (this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMaximum.ToString()] as RibbonTextBox) : (this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinimum.ToString()] as RibbonTextBox)));
			double? num = null;
			if (!ribbonToggleButton_0.Checked)
			{
				string text = ribbonTextBox.Text;
				num = ((!double.TryParse(text, out var result)) ? this.method_66(class440_, bool_1, bool_2) : new double?(result));
			}
			else
			{
				num = double.NaN;
			}
			if (num.HasValue)
			{
				foreach (Class437 item in (IEnumerable<Class437>)class440_.Class435_0)
				{
					Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? item.Class439_0 : item.Class439_2);
					if (bool_2)
					{
						@class.Double_1 = num.Value;
					}
					else
					{
						@class.Double_2 = num.Value;
					}
				}
			}
			bool flag2 = (ribbonTextBox.Enabled = !ribbonToggleButton_0.Checked);
			ribbonTextBox.Text = (flag2 ? num.ToString() : "");
			if (bool_1)
			{
				if (bool_2)
				{
					this.nullable_1 = ((!ribbonTextBox.Enabled) ? null : num);
				}
				else
				{
					this.nullable_0 = ((!ribbonTextBox.Enabled) ? null : num);
				}
			}
			else if (bool_2)
			{
				this.nullable_4 = ((!ribbonTextBox.Enabled) ? null : num);
			}
			else
			{
				this.nullable_3 = ((!ribbonTextBox.Enabled) ? null : num);
			}
			chartFrame_.Refresh();
		}

		private void method_46(RibbonToggleButton ribbonToggleButton_0, bool bool_1)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			RibbonTextBox ribbonTextBox = (bool_1 ? (this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisInterval.ToString()] as RibbonTextBox) : (this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisInterval.ToString()] as RibbonTextBox));
			double? num = null;
			if (!ribbonToggleButton_0.Checked)
			{
				string text = ribbonTextBox.Text;
				num = ((!double.TryParse(text, out var result)) ? this.method_64(class440_, bool_1) : new double?(result));
			}
			else
			{
				num = double.NaN;
			}
			if (num.HasValue)
			{
				foreach (Class437 item in (IEnumerable<Class437>)class440_.Class435_0)
				{
					Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? item.Class439_0 : item.Class439_2);
					@class.Double_0 = num.Value;
				}
			}
			bool flag2 = (ribbonTextBox.Enabled = !ribbonToggleButton_0.Checked);
			ribbonTextBox.Text = (flag2 ? num.ToString() : "");
			if (bool_1)
			{
				this.nullable_2 = ((!ribbonTextBox.Enabled) ? null : num);
			}
			else
			{
				this.nullable_5 = ((!ribbonTextBox.Enabled) ? null : num);
			}
			chartFrame_.Refresh();
		}

		private void method_47(RibbonTextBox ribbonTextBox_0)
		{
			if (!double.TryParse(ribbonTextBox_0.Text, out var result))
			{
				return;
			}
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			if (chartFrame_ == null)
			{
				return;
			}
			if (this.method_83(ribbonTextBox_0, result, class440_))
			{
				chartFrame_.Refresh();
				return;
			}
			switch (ribbonTextBox_0.Name)
			{
			case "TXITEM_YAxisInterval":
				ribbonTextBox_0.Text = this.nullable_5.ToString();
				break;
			case "TXITEM_YAxisMaximum":
				ribbonTextBox_0.Text = this.nullable_4.ToString();
				break;
			case "TXITEM_YAxisMinimum":
				ribbonTextBox_0.Text = this.nullable_3.ToString();
				break;
			case "TXITEM_XAxisInterval":
				ribbonTextBox_0.Text = this.nullable_2.ToString();
				break;
			case "TXITEM_XAxisMaximum":
				ribbonTextBox_0.Text = this.nullable_1.ToString();
				break;
			case "TXITEM_XAxisMinimum":
				ribbonTextBox_0.Text = this.nullable_0.ToString();
				break;
			}
		}

		private void method_48(RibbonTextBox ribbonTextBox_0)
		{
			this.method_69(ribbonTextBox_0, this.double_0);
		}

		private void method_49(RibbonTextBox ribbonTextBox_0)
		{
			this.method_69(ribbonTextBox_0, 0.0 - this.double_0);
		}

		private void method_50(IRibbonItem iribbonItem_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			Control control = iribbonItem_0.ParentCollection.Object_0 as Control;
			foreach (IRibbonItem item in iribbonItem_0.ParentCollection)
			{
				if (item.IsDefaultRibbonTabItem && item is RibbonToggleButton)
				{
					(item as RibbonToggleButton).Checked = iribbonItem_0 == item;
				}
			}
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			switch (control.Name)
			{
			case "TXITEM_LegendDocking":
			case "TXITEM_ChartTitleDocking":
				this.method_72(iribbonItem_0, class440_);
				break;
			case "TXITEM_ChartTitleOrientation":
			case "TXITEM_XAxisTitleOrientation":
			case "TXITEM_YAxisTitleOrientation":
				this.method_73(iribbonItem_0, class440_);
				break;
			case "TXITEM_LegendAlignment":
			case "TXITEM_XAxisTitleAlignment":
			case "TXITEM_YAxisTitleAlignment":
				this.method_70(iribbonItem_0, class440_);
				break;
			case "TXITEM_XAxisLineDashType":
			case "TXITEM_XAxisMajorGridlinesDashType":
			case "TXITEM_XAxisMinorGridlinesDashType":
			case "TXITEM_YAxisLineDashType":
			case "TXITEM_YAxisMajorGridlinesDashType":
			case "TXITEM_YAxisMinorGridlinesDashType":
				this.method_71(iribbonItem_0, class440_);
				break;
			}
			chartFrame_.Refresh();
		}

		private void method_51(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				switch (ribbonToggleButton_0.Name)
				{
				case "TXITEM_LegendColor_Automatic":
					this.method_82(Color.Black, bool_1: false);
					break;
				case "TXITEM_XAxisLabelsColor_Automatic":
					this.method_80(Color.Black, bool_1: true, bool_2: false);
					break;
				case "TXITEM_YAxisLabelsColor_Automatic":
					this.method_80(Color.Black, bool_1: false, bool_2: false);
					break;
				case "TXITEM_ChartTitleColor_Automatic":
					this.method_82(Color.Black, bool_1: true);
					break;
				case "TXITEM_XAxisTitleColor_Automatic":
					this.method_80(Color.Black, bool_1: true, bool_2: true);
					break;
				case "TXITEM_YAxisTitleColor_Automatic":
					this.method_80(Color.Black, bool_1: false, bool_2: true);
					break;
				case "TXITEM_XAxisLineColor_Automatic":
					this.method_81(Color.Black, bool_1: true);
					break;
				case "TXITEM_XAxisMajorGridlinesColor_Automatic":
					this.method_79(Color.Black, bool_1: true, bool_2: true);
					break;
				case "TXITEM_XAxisMinorGridlinesColor_Automatic":
					this.method_79(Color.Black, bool_1: true, bool_2: false);
					break;
				case "TXITEM_YAxisLineColor_Automatic":
					this.method_81(Color.Black, bool_1: false);
					break;
				case "TXITEM_YAxisMajorGridlinesColor_Automatic":
					this.method_79(Color.Black, bool_1: false, bool_2: true);
					break;
				case "TXITEM_YAxisMinorGridlinesColor_Automatic":
					this.method_79(Color.Black, bool_1: false, bool_2: false);
					break;
				}
				ribbonToggleButton_0.Checked = true;
			}
		}

		private void method_52(RibbonListView ribbonListView_0, RibbonListView.RibbonListViewItemEventArgs ribbonListViewItemEventArgs_0)
		{
			if (base.m_txTextControl != null)
			{
				switch (ribbonListView_0.Name)
				{
				case "TXITEM_LegendColor_Gallery":
					this.method_82((Color)ribbonListViewItemEventArgs_0.Item.Tag, bool_1: false);
					break;
				case "TXITEM_XAxisLabelsColor_Gallery":
					this.method_80((Color)ribbonListViewItemEventArgs_0.Item.Tag, bool_1: true, bool_2: false);
					break;
				case "TXITEM_YAxisLabelsColor_Gallery":
					this.method_80((Color)ribbonListViewItemEventArgs_0.Item.Tag, bool_1: false, bool_2: false);
					break;
				case "TXITEM_ChartTitleColor_Gallery":
					this.method_82((Color)ribbonListViewItemEventArgs_0.Item.Tag, bool_1: true);
					break;
				case "TXITEM_XAxisTitleColor_Gallery":
					this.method_80((Color)ribbonListViewItemEventArgs_0.Item.Tag, bool_1: true, bool_2: true);
					break;
				case "TXITEM_YAxisTitleColor_Gallery":
					this.method_80((Color)ribbonListViewItemEventArgs_0.Item.Tag, bool_1: false, bool_2: true);
					break;
				case "TXITEM_XAxisLineColor_Gallery":
					this.method_81((Color)ribbonListViewItemEventArgs_0.Item.Tag, bool_1: true);
					break;
				case "TXITEM_XAxisMajorGridlinesColor_Gallery":
					this.method_79((Color)ribbonListViewItemEventArgs_0.Item.Tag, bool_1: true, bool_2: true);
					break;
				case "TXITEM_XAxisMinorGridlinesColor_Gallery":
					this.method_79((Color)ribbonListViewItemEventArgs_0.Item.Tag, bool_1: true, bool_2: false);
					break;
				case "TXITEM_YAxisLineColor_Gallery":
					this.method_81((Color)ribbonListViewItemEventArgs_0.Item.Tag, bool_1: false);
					break;
				case "TXITEM_YAxisMajorGridlinesColor_Gallery":
					this.method_79((Color)ribbonListViewItemEventArgs_0.Item.Tag, bool_1: false, bool_2: true);
					break;
				case "TXITEM_YAxisMinorGridlinesColor_Gallery":
					this.method_79((Color)ribbonListViewItemEventArgs_0.Item.Tag, bool_1: false, bool_2: false);
					break;
				}
			}
		}

		private void method_53(RibbonButton ribbonButton_0)
		{
			if (base.m_txTextControl != null)
			{
				switch (ribbonButton_0.Name)
				{
				case "TXITEM_LegendColor_MoreColors":
					this.method_77(bool_1: false);
					break;
				case "TXITEM_XAxisLabelsColor_MoreColors":
					this.method_75(bool_1: true, bool_2: false);
					break;
				case "TXITEM_YAxisLabelsColor_MoreColors":
					this.method_75(bool_1: false, bool_2: false);
					break;
				case "TXITEM_ChartTitleColor_MoreColors":
					this.method_77(bool_1: true);
					break;
				case "TXITEM_XAxisTitleColor_MoreColors":
					this.method_75(bool_1: true, bool_2: true);
					break;
				case "TXITEM_YAxisTitleColor_MoreColors":
					this.method_75(bool_1: false, bool_2: true);
					break;
				case "TXITEM_XAxisLineColor_MoreColors":
					this.method_76(bool_1: true);
					break;
				case "TXITEM_XAxisMajorGridlinesColor_MoreColors":
					this.method_74(bool_1: true, bool_2: true);
					break;
				case "TXITEM_XAxisMinorGridlinesColor_MoreColors":
					this.method_74(bool_1: true, bool_2: false);
					break;
				case "TXITEM_YAxisLineColor_MoreColors":
					this.method_76(bool_1: false);
					break;
				case "TXITEM_YAxisMajorGridlinesColor_MoreColors":
					this.method_74(bool_1: false, bool_2: true);
					break;
				case "TXITEM_YAxisMinorGridlinesColor_MoreColors":
					this.method_74(bool_1: false, bool_2: false);
					break;
				}
			}
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_EditData_Handler(object sender, EventArgs e)
		{
			this.method_32();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_SetDataRelation_Handler(object sender, EventArgs e)
		{
			this.method_33();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Legend_Handler(object sender, EventArgs e)
		{
			this.method_34((sender is RibbonToggleButton) ? (sender as RibbonToggleButton).Checked : (sender as RibbonSplitButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_LegendFont_Handler(object sender, EventArgs e)
		{
			this.method_35();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_XAxisLabels_Handler(object sender, EventArgs e)
		{
			this.method_38(sender as IRibbonItem, bool_1: true);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_XAxisLabelsFont_Handler(object sender, EventArgs e)
		{
			this.method_36();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_YAxisLabels_Handler(object sender, EventArgs e)
		{
			this.method_38(sender as IRibbonItem, bool_1: false);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_YAxisLabelsFont_Handler(object sender, EventArgs e)
		{
			this.method_37();
		}

		private void method_54(object sender, EventArgs e)
		{
			this.method_39(sender as RibbonTextBox);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ChartTitleFont_Handler(object sender, EventArgs e)
		{
			this.method_40();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_XAxisTitleFont_Handler(object sender, EventArgs e)
		{
			this.method_41();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_YAxisTitleFont_Handler(object sender, EventArgs e)
		{
			this.method_42();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_XAxisLine_Handler(object sender, EventArgs e)
		{
			this.method_43(sender as IRibbonItem, bool_1: true);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_XAxisMajorGridlines_Handler(object sender, EventArgs e)
		{
			this.method_44(sender as IRibbonItem, bool_1: true, bool_2: true);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_XAxisMinorGridlines_Handler(object sender, EventArgs e)
		{
			this.method_44(sender as IRibbonItem, bool_1: true, bool_2: false);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_XAxisMaximumAutomatic_Handler(object sender, EventArgs e)
		{
			this.method_45(sender as RibbonToggleButton, bool_1: true, bool_2: true);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_XAxisMinimumAutomatic_Handler(object sender, EventArgs e)
		{
			this.method_45(sender as RibbonToggleButton, bool_1: true, bool_2: false);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_XAxisIntervalAutomatic_Handler(object sender, EventArgs e)
		{
			this.method_46(sender as RibbonToggleButton, bool_1: true);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_YAxisLine_Handler(object sender, EventArgs e)
		{
			this.method_43(sender as IRibbonItem, bool_1: false);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_YAxisMajorGridlines_Handler(object sender, EventArgs e)
		{
			this.method_44(sender as IRibbonItem, bool_1: false, bool_2: true);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_YAxisMinorGridlines_Handler(object sender, EventArgs e)
		{
			this.method_44(sender as IRibbonItem, bool_1: false, bool_2: false);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_YAxisMaximumAutomatic_Handler(object sender, EventArgs e)
		{
			this.method_45(sender as RibbonToggleButton, bool_1: false, bool_2: true);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_YAxisMinimumAutomatic_Handler(object sender, EventArgs e)
		{
			this.method_45(sender as RibbonToggleButton, bool_1: false, bool_2: false);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_YAxisIntervalAutomatic_Handler(object sender, EventArgs e)
		{
			this.method_46(sender as RibbonToggleButton, bool_1: false);
		}

		private void method_55(object sender, EventArgs e)
		{
			this.method_47(sender as RibbonTextBox);
		}

		private void method_56(object sender, EventArgs e)
		{
			this.method_48(sender as RibbonTextBox);
		}

		private void method_57(object sender, EventArgs e)
		{
			this.method_49(sender as RibbonTextBox);
		}

		private void method_58(object sender, EventArgs e)
		{
			this.method_50(sender as IRibbonItem);
		}

		protected override void DefaultColorButton_Click(object sender, EventArgs e)
		{
			this.method_51(sender as RibbonToggleButton);
		}

		protected override void ColorListView_ItemClick(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			this.method_52(sender as RibbonListView, e);
		}

		protected override void MoreColorsButton_Click(object sender, EventArgs e)
		{
			this.method_53(sender as RibbonButton);
		}

		private Color? method_59(bool bool_1, bool bool_2)
		{
			Color? result = null;
			if (base.m_txTextControl != null)
			{
				Class517.smethod_34(base.m_txTextControl, out var class440_, out var _);
				if (class440_.Class435_0.Count > 0)
				{
					Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_.Class435_0[0].Class439_0 : class440_.Class435_0[0].Class439_2);
					result = (bool_2 ? @class.Color_1 : @class.Class448_0.Color_0);
					for (int i = 1; i < class440_.Class435_0.Count; i++)
					{
						@class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_.Class435_0[i].Class439_0 : class440_.Class435_0[i].Class439_2);
						if ((bool_2 ? @class.Color_1 : @class.Class448_0.Color_0).ToArgb() != result.Value.ToArgb())
						{
							return null;
						}
					}
				}
			}
			return result;
		}

		private Color? method_60(bool bool_1, bool bool_2)
		{
			Color? result = null;
			if (base.m_txTextControl != null)
			{
				Class517.smethod_34(base.m_txTextControl, out var class440_, out var _);
				if (class440_.Class435_0.Count > 0)
				{
					Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_.Class435_0[0].Class439_0 : class440_.Class435_0[0].Class439_2);
					Class438 class2 = (bool_2 ? @class.Class438_0 : @class.Class438_1);
					result = class2.Color_0;
					for (int i = 1; i < class440_.Class435_0.Count; i++)
					{
						@class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_.Class435_0[i].Class439_0 : class440_.Class435_0[i].Class439_2);
						class2 = (bool_2 ? @class.Class438_0 : @class.Class438_1);
						if (class2.Color_0.ToArgb() != result.Value.ToArgb())
						{
							return null;
						}
					}
				}
			}
			return result;
		}

		private Color? method_61(bool bool_1)
		{
			Color? result = null;
			if (base.m_txTextControl != null)
			{
				Class517.smethod_34(base.m_txTextControl, out var class440_, out var _);
				if (class440_.Class435_0.Count > 0)
				{
					Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_.Class435_0[0].Class439_0 : class440_.Class435_0[0].Class439_2);
					result = @class.Color_0;
					for (int i = 1; i < class440_.Class435_0.Count; i++)
					{
						@class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_.Class435_0[i].Class439_0 : class440_.Class435_0[i].Class439_2);
						if (@class.Color_0.ToArgb() != result.Value.ToArgb())
						{
							return null;
						}
					}
				}
			}
			return result;
		}

		private Color? method_62(bool bool_1)
		{
			Color? result = null;
			if (base.m_txTextControl != null)
			{
				Class517.smethod_34(base.m_txTextControl, out var class440_, out var _);
				if (class440_.Class449_0.Count > 0)
				{
					result = (bool_1 ? class440_.Class441_0[0].Color_0 : class440_.Class449_0[0].Color_0);
					for (int i = 1; i < class440_.Class435_0.Count; i++)
					{
						if ((bool_1 ? class440_.Class441_0[0].Color_0 : class440_.Class449_0[0].Color_0).ToArgb() != result.Value.ToArgb())
						{
							return null;
						}
					}
				}
			}
			return result;
		}

		private Class454.SeriesChartType method_63(Class440 class440_0)
		{
			Class454.SeriesChartType seriesChartType = Class454.SeriesChartType.UNKNOWN;
			if (class440_0.Class452_0.Count > 0)
			{
				seriesChartType = class440_0.Class452_0[0].SeriesChartType_0;
				for (int i = 1; i < class440_0.Class452_0.Count; i++)
				{
					if (class440_0.Class452_0[i].SeriesChartType_0 != seriesChartType)
					{
						return Class454.SeriesChartType.UNKNOWN;
					}
				}
			}
			return seriesChartType;
		}

		private double? method_64(Class440 class440_0, bool bool_1)
		{
			double? num = null;
			bool flag = false;
			if (class440_0.Class435_0.Count > 0)
			{
				flag = true;
				Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_0.Class435_0[0].Class439_0 : class440_0.Class435_0[0].Class439_2);
				num = @class.Double_0;
				for (int i = 1; i < class440_0.Class435_0.Count; i++)
				{
					if (!flag)
					{
						break;
					}
					@class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_0.Class435_0[i].Class439_0 : class440_0.Class435_0[i].Class439_2);
					if (flag && @class.Double_0 != num)
					{
						flag = false;
					}
				}
			}
			return num;
		}

		private Font method_65(Class440 class440_0, bool bool_1, bool bool_2)
		{
			Font font = null;
			if (class440_0.Class435_0.Count > 0)
			{
				Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_0.Class435_0[0].Class439_0 : class440_0.Class435_0[0].Class439_2);
				font = (bool_2 ? @class.Font_0 : @class.Class448_0.Font_0);
				for (int i = 1; i < class440_0.Class435_0.Count; i++)
				{
					@class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_0.Class435_0[0].Class439_0 : class440_0.Class435_0[0].Class439_2);
					Font obj = (bool_2 ? @class.Font_0 : @class.Class448_0.Font_0);
					if (!font.Equals(obj))
					{
						return null;
					}
				}
			}
			return font;
		}

		private double? method_66(Class440 class440_0, bool bool_1, bool bool_2)
		{
			double? num = null;
			bool flag = false;
			if (class440_0.Class435_0.Count > 0)
			{
				flag = true;
				Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_0.Class435_0[0].Class439_0 : class440_0.Class435_0[0].Class439_2);
				num = (bool_2 ? @class.Double_1 : @class.Double_2);
				for (int i = 1; i < class440_0.Class435_0.Count; i++)
				{
					if (!flag)
					{
						break;
					}
					@class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? class440_0.Class435_0[i].Class439_0 : class440_0.Class435_0[i].Class439_2);
					double num2 = (bool_2 ? @class.Double_1 : @class.Double_2);
					if (flag && num2 != num)
					{
						flag = false;
					}
				}
			}
			return num;
		}

		private Font method_67(Class440 class440_0)
		{
			Font font = null;
			if (class440_0.Class441_0.Count > 0)
			{
				font = class440_0.Class441_0[0].Font_0;
				for (int i = 1; i < class440_0.Class441_0.Count; i++)
				{
					if (!font.Equals(class440_0.Class441_0[i].Font_0))
					{
						return null;
					}
				}
			}
			return font;
		}

		private Font method_68(Class440 class440_0)
		{
			Font font = null;
			if (class440_0.Class449_0.Count > 0)
			{
				font = class440_0.Class449_0[0].Font_0;
				for (int i = 1; i < class440_0.Class449_0.Count; i++)
				{
					if (!font.Equals(class440_0.Class449_0[i].Font_0))
					{
						return null;
					}
				}
			}
			return font;
		}

		private void method_69(RibbonTextBox ribbonTextBox_0, double double_1)
		{
			if (base.m_txTextControl != null)
			{
				Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
				double? num = null;
				switch (ribbonTextBox_0.Name)
				{
				case "TXITEM_YAxisInterval":
					num = this.method_64(class440_, bool_1: false);
					break;
				case "TXITEM_YAxisMaximum":
					num = this.method_66(class440_, bool_1: false, bool_2: true);
					break;
				case "TXITEM_YAxisMinimum":
					num = this.method_66(class440_, bool_1: false, bool_2: false);
					break;
				case "TXITEM_XAxisInterval":
					num = this.method_64(class440_, bool_1: true);
					break;
				case "TXITEM_XAxisMaximum":
					num = this.method_66(class440_, bool_1: true, bool_2: true);
					break;
				case "TXITEM_XAxisMinimum":
					num = this.method_66(class440_, bool_1: true, bool_2: false);
					break;
				}
				if (num.HasValue && this.method_83(ribbonTextBox_0, num.Value + double_1, class440_))
				{
					ribbonTextBox_0.Text = (num.Value + double_1).ToString();
					chartFrame_.Refresh();
				}
			}
		}

		private void method_70(IRibbonItem iribbonItem_0, Class440 class440_0)
		{
			StringAlignment stringAlignment_ = StringAlignment.Near;
			switch ((iribbonItem_0 as Control).Tag.ToString())
			{
			case "Far":
				stringAlignment_ = StringAlignment.Far;
				break;
			case "Center":
				stringAlignment_ = StringAlignment.Center;
				break;
			case "Near":
				stringAlignment_ = StringAlignment.Near;
				break;
			}
			switch ((iribbonItem_0.ParentCollection.Object_0 as Control).Name)
			{
			case "TXITEM_XAxisTitleAlignment":
			case "TXITEM_YAxisTitleAlignment":
				foreach (Class437 item in (IEnumerable<Class437>)class440_0.Class435_0)
				{
					switch ((iribbonItem_0.ParentCollection.Object_0 as Control).Name)
					{
					case "TXITEM_YAxisTitleAlignment":
					{
						Class439 class2 = ((!this.bool_0) ? item.Class439_2 : item.Class439_0);
						class2.StringAlignment_0 = stringAlignment_;
						break;
					}
					case "TXITEM_XAxisTitleAlignment":
					{
						Class439 @class = ((!this.bool_0) ? item.Class439_0 : item.Class439_2);
						@class.StringAlignment_0 = stringAlignment_;
						break;
					}
					}
				}
				break;
			case "TXITEM_LegendAlignment":
				foreach (Class451 item2 in (IEnumerable<Class451>)class440_0.Class449_0)
				{
					item2.StringAlignment_0 = stringAlignment_;
				}
				break;
			}
		}

		private void method_71(IRibbonItem iribbonItem_0, Class440 class440_0)
		{
			ChartDashStyle chartDashStyle = ChartDashStyle.Solid;
			switch ((iribbonItem_0 as Control).Tag.ToString())
			{
			case "Solid":
				chartDashStyle = ChartDashStyle.Solid;
				break;
			case "Dot":
				chartDashStyle = ChartDashStyle.Dot;
				break;
			case "DashDotDot":
				chartDashStyle = ChartDashStyle.DashDotDot;
				break;
			case "DashDot":
				chartDashStyle = ChartDashStyle.DashDot;
				break;
			case "Dash":
				chartDashStyle = ChartDashStyle.Dash;
				break;
			}
			foreach (Class437 item in (IEnumerable<Class437>)class440_0.Class435_0)
			{
				switch ((iribbonItem_0.ParentCollection.Object_0 as Control).Name)
				{
				case "TXITEM_YAxisMinorGridlinesDashType":
				{
					Class439 class2 = ((!this.bool_0) ? item.Class439_2 : item.Class439_0);
					class2.Class438_1.ChartDashStyle_0 = chartDashStyle;
					this.method_30(class440_0, bool_1: false, bool_2: false);
					break;
				}
				case "TXITEM_YAxisMajorGridlinesDashType":
				{
					Class439 class2 = ((!this.bool_0) ? item.Class439_2 : item.Class439_0);
					class2.Class438_0.ChartDashStyle_0 = chartDashStyle;
					this.method_30(class440_0, bool_1: false, bool_2: true);
					break;
				}
				case "TXITEM_XAxisMinorGridlinesDashType":
				{
					Class439 @class = ((!this.bool_0) ? item.Class439_0 : item.Class439_2);
					@class.Class438_1.ChartDashStyle_0 = chartDashStyle;
					this.method_30(class440_0, bool_1: true, bool_2: false);
					break;
				}
				case "TXITEM_XAxisMajorGridlinesDashType":
				{
					Class439 @class = ((!this.bool_0) ? item.Class439_0 : item.Class439_2);
					@class.Class438_0.ChartDashStyle_0 = chartDashStyle;
					this.method_30(class440_0, bool_1: true, bool_2: true);
					break;
				}
				case "TXITEM_YAxisLineDashType":
				{
					Class439 class2 = ((!this.bool_0) ? item.Class439_2 : item.Class439_0);
					class2.ChartDashStyle_0 = chartDashStyle;
					this.method_29(class440_0, bool_1: false);
					break;
				}
				case "TXITEM_XAxisLineDashType":
				{
					Class439 @class = ((!this.bool_0) ? item.Class439_0 : item.Class439_2);
					@class.ChartDashStyle_0 = chartDashStyle;
					this.method_29(class440_0, bool_1: true);
					break;
				}
				}
			}
		}

		private void method_72(IRibbonItem iribbonItem_0, Class440 class440_0)
		{
			Docking docking_ = Docking.Top;
			switch ((iribbonItem_0 as Control).Tag.ToString())
			{
			case "Bottom":
				docking_ = Docking.Bottom;
				break;
			case "Right":
				docking_ = Docking.Right;
				break;
			case "Top":
				docking_ = Docking.Top;
				break;
			case "Left":
				docking_ = Docking.Left;
				break;
			}
			switch ((iribbonItem_0.ParentCollection.Object_0 as Control).Name)
			{
			case "TXITEM_LegendDocking":
				foreach (Class437 item in (IEnumerable<Class437>)class440_0.Class435_0)
				{
					_ = item;
					foreach (Class451 item2 in (IEnumerable<Class451>)class440_0.Class449_0)
					{
						item2.Docking_0 = docking_;
					}
				}
				this.method_24(class440_0);
				break;
			case "TXITEM_ChartTitleDocking":
				foreach (Class437 item3 in (IEnumerable<Class437>)class440_0.Class435_0)
				{
					_ = item3;
					foreach (Class443 item4 in (IEnumerable<Class443>)class440_0.Class441_0)
					{
						item4.Docking_0 = docking_;
					}
				}
				break;
			}
		}

		private void method_73(IRibbonItem iribbonItem_0, Class440 class440_0)
		{
			TextOrientation textOrientation_ = TextOrientation.Auto;
			switch ((iribbonItem_0 as Control).Tag.ToString())
			{
			case "Stacked":
				textOrientation_ = TextOrientation.Stacked;
				break;
			case "Rotated90":
				textOrientation_ = TextOrientation.Rotated90;
				break;
			case "Rotated270":
				textOrientation_ = TextOrientation.Rotated270;
				break;
			case "Horizontal":
				textOrientation_ = TextOrientation.Horizontal;
				break;
			case "Auto":
				textOrientation_ = TextOrientation.Auto;
				break;
			}
			foreach (Class437 item in (IEnumerable<Class437>)class440_0.Class435_0)
			{
				switch ((iribbonItem_0.ParentCollection.Object_0 as Control).Name)
				{
				case "TXITEM_YAxisTitleOrientation":
				{
					Class439 class2 = ((!this.bool_0) ? item.Class439_2 : item.Class439_0);
					class2.TextOrientation_0 = textOrientation_;
					break;
				}
				case "TXITEM_XAxisTitleOrientation":
				{
					Class439 @class = ((!this.bool_0) ? item.Class439_0 : item.Class439_2);
					@class.TextOrientation_0 = textOrientation_;
					break;
				}
				case "TXITEM_ChartTitleOrientation":
					foreach (Class443 item2 in (IEnumerable<Class443>)class440_0.Class441_0)
					{
						item2.TextOrientation_0 = textOrientation_;
					}
					break;
				}
			}
		}

		internal static void smethod_0(TextControl textControl_0, Action<Class440> action_0)
		{
			Class517.smethod_34(textControl_0, out var class440_, out var chartFrame_);
			if (class440_ != null)
			{
				action_0(class440_);
				chartFrame_.Refresh();
			}
		}

		private void method_74(bool bool_1, bool bool_2)
		{
			Color? nullable_ = this.method_60(bool_1 ? (!this.bool_0) : this.bool_0, bool_2);
			this.method_78(nullable_);
			if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
			{
				this.method_79(this.colorDialog_0.Color, bool_1, bool_2);
			}
		}

		private void method_75(bool bool_1, bool bool_2)
		{
			Color? nullable_ = this.method_59(bool_1 ? (!this.bool_0) : this.bool_0, bool_2);
			this.method_78(nullable_);
			if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
			{
				this.method_80(this.colorDialog_0.Color, bool_1, bool_2);
			}
		}

		private void method_76(bool bool_1)
		{
			Color? nullable_ = this.method_61(bool_1 ? (!this.bool_0) : this.bool_0);
			this.method_78(nullable_);
			if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
			{
				this.method_81(this.colorDialog_0.Color, bool_1);
			}
		}

		private void method_77(bool bool_1)
		{
			Color? nullable_ = this.method_62(bool_1);
			this.method_78(nullable_);
			if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
			{
				this.method_82(this.colorDialog_0.Color, bool_1);
			}
		}

		private void method_78(Color? nullable_6)
		{
			if (this.colorDialog_0 == null)
			{
				this.colorDialog_0 = new ColorDialog();
				this.colorDialog_0.CustomColors = new int[1] { Color.FromArgb(255, 208, 208, 208).ToArgb() & 0xFFFFFF };
			}
			if (nullable_6.HasValue)
			{
				this.colorDialog_0.Color = nullable_6.Value;
			}
		}

		private void method_79(Color color_0, bool bool_1, bool bool_2)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			foreach (Class437 item in (IEnumerable<Class437>)class440_.Class435_0)
			{
				Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? item.Class439_0 : item.Class439_2);
				Class438 class2 = (bool_2 ? @class.Class438_0 : @class.Class438_1);
				class2.Color_0 = color_0;
			}
			chartFrame_.Refresh();
			this.method_30(class440_, bool_1, bool_2);
		}

		private void method_80(Color color_0, bool bool_1, bool bool_2)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			foreach (Class437 item in (IEnumerable<Class437>)class440_.Class435_0)
			{
				Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? item.Class439_0 : item.Class439_2);
				if (bool_2)
				{
					@class.Color_1 = color_0;
				}
				else
				{
					@class.Class448_0.Color_0 = color_0;
				}
			}
			chartFrame_.Refresh();
			if (bool_2)
			{
				this.method_21(class440_);
			}
			else
			{
				this.method_25(class440_, bool_1);
			}
		}

		private void method_81(Color color_0, bool bool_1)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			foreach (Class437 item in (IEnumerable<Class437>)class440_.Class435_0)
			{
				Class439 @class = ((bool_1 ? (!this.bool_0) : this.bool_0) ? item.Class439_0 : item.Class439_2);
				@class.Color_0 = color_0;
				@class.Class455_0.Color_0 = color_0;
			}
			chartFrame_.Refresh();
			this.method_29(class440_, bool_1);
		}

		private void method_82(Color color_0, bool bool_1)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var chartFrame_);
			if (bool_1)
			{
				foreach (Class443 item in (IEnumerable<Class443>)class440_.Class441_0)
				{
					item.Color_0 = color_0;
				}
			}
			else
			{
				foreach (Class451 item2 in (IEnumerable<Class451>)class440_.Class449_0)
				{
					item2.Color_0 = color_0;
				}
			}
			chartFrame_.Refresh();
			this.method_24(class440_);
		}

		private bool method_83(RibbonTextBox ribbonTextBox_0, double double_1, Class440 class440_0)
		{
			bool result = false;
			switch (ribbonTextBox_0.Name)
			{
			case "TXITEM_YAxisInterval":
				if ((this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisIntervalAutomatic.ToString()] as RibbonToggleButton).Checked || !(double_1 > 0.0))
				{
					break;
				}
				foreach (Class437 item in (IEnumerable<Class437>)class440_0.Class435_0)
				{
					item.Class439_2.Double_0 = double_1;
				}
				this.nullable_5 = double_1;
				result = true;
				break;
			case "TXITEM_YAxisMaximum":
			{
				if ((this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMaximumAutomatic.ToString()] as RibbonToggleButton).Checked)
				{
					break;
				}
				double? num3 = this.method_66(class440_0, bool_1: false, bool_2: false);
				if (!num3.HasValue || !(num3.Value < double_1))
				{
					break;
				}
				foreach (Class437 item2 in (IEnumerable<Class437>)class440_0.Class435_0)
				{
					item2.Class439_2.Double_1 = double_1;
				}
				this.nullable_4 = double_1;
				result = true;
				break;
			}
			case "TXITEM_YAxisMinimum":
			{
				if ((this.class501_0.TXITEM_YAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_YAxisMinimumAutomatic.ToString()] as RibbonToggleButton).Checked)
				{
					break;
				}
				double? num2 = this.method_66(class440_0, bool_1: false, bool_2: true);
				if (!num2.HasValue || !(num2.Value > double_1))
				{
					break;
				}
				foreach (Class437 item3 in (IEnumerable<Class437>)class440_0.Class435_0)
				{
					item3.Class439_2.Double_2 = double_1;
				}
				this.nullable_3 = double_1;
				result = true;
				break;
			}
			case "TXITEM_XAxisInterval":
				if ((this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisIntervalAutomatic.ToString()] as RibbonToggleButton).Checked || !(double_1 > 0.0))
				{
					break;
				}
				foreach (Class437 item4 in (IEnumerable<Class437>)class440_0.Class435_0)
				{
					Class439 class2 = ((!this.bool_0) ? item4.Class439_0 : item4.Class439_2);
					class2.Double_0 = double_1;
				}
				this.nullable_2 = double_1;
				result = true;
				break;
			case "TXITEM_XAxisMaximum":
			{
				if ((this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMaximumAutomatic.ToString()] as RibbonToggleButton).Checked)
				{
					break;
				}
				double? num4 = this.method_66(class440_0, bool_1: true, bool_2: false);
				if (!num4.HasValue || !(num4.Value < double_1))
				{
					break;
				}
				foreach (Class437 item5 in (IEnumerable<Class437>)class440_0.Class435_0)
				{
					Class439 class3 = ((!this.bool_0) ? item5.Class439_0 : item5.Class439_2);
					class3.Double_1 = double_1;
				}
				this.nullable_1 = double_1;
				result = true;
				break;
			}
			case "TXITEM_XAxisMinimum":
			{
				if ((this.class501_0.TXITEM_XAxisGroup_Items[RibbonChartLayoutTab.InternalRibbonItem.TXITEM_XAxisMinimumAutomatic.ToString()] as RibbonToggleButton).Checked)
				{
					break;
				}
				double? num = this.method_66(class440_0, bool_1: true, bool_2: true);
				if (!num.HasValue || !(num.Value > double_1))
				{
					break;
				}
				foreach (Class437 item6 in (IEnumerable<Class437>)class440_0.Class435_0)
				{
					Class439 @class = ((!this.bool_0) ? item6.Class439_0 : item6.Class439_2);
					@class.Double_2 = double_1;
				}
				this.nullable_0 = double_1;
				result = true;
				break;
			}
			}
			return result;
		}

		private void method_84(RibbonMenuButton ribbonMenuButton_0, Color color_0, Color color_1)
		{
			Class517.smethod_59(ribbonMenuButton_0, color_0, bool_0: false, base.m_pntDPI);
			foreach (IRibbonItem dropDownItem in ribbonMenuButton_0.DropDownItems)
			{
				if (dropDownItem.IsDefaultRibbonTabItem && (dropDownItem as Control).Name.EndsWith("_Automatic"))
				{
					(dropDownItem as RibbonToggleButton).Checked = color_0.ToArgb() == color_1.ToArgb();
					break;
				}
			}
		}

		internal void method_85(object sender, ChartEventArgs e)
		{
			this.method_17();
		}

		internal void method_86(object sender, ChartEventArgs e)
		{
			this.method_18(e.ChartFrame);
		}
	}
}
