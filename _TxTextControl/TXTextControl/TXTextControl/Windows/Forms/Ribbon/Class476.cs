using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using ns20;
using ns25;
using TXTextControl;
using TXTextControl.Barcode;
using TXTextControl.DataVisualization;
using TXTextControl.Drawing;
using TXTextControl.ProxyClasses.Charts;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class476 : BindingAdapter
	{
		private Class505 class505_0;

		private MeasuringUnit measuringUnit_0 = MeasuringUnit.Millimeter;

		private int int_0 = 1;

		private double double_0 = 1.0;

		private double double_1 = 1.0;

		private DrawingFrame drawingFrame_0;

		private FrameBase frameBase_0;

		private RibbonTextBox ribbonTextBox_0;

		internal override Class500 RibbonGroupManager
		{
			get
			{
				return this.class505_0;
			}
			set
			{
				this.class505_0 = value as Class505;
			}
		}

		private bool Boolean_0
		{
			get
			{
				Class517.smethod_34(base.m_txTextControl, out var class440_, out var _);
				if (class440_ != null)
				{
					return class440_.Nullable_0 == true;
				}
				return false;
			}
			set
			{
				Class472.smethod_0(base.m_txTextControl, delegate(Class440 chart)
				{
					foreach (Class437 item in (IEnumerable<Class437>)chart.Class435_0)
					{
						item.Class434_0.Boolean_0 = value;
					}
				});
			}
		}

		private bool Boolean_1
		{
			get
			{
				Class517.smethod_34(base.m_txTextControl, out var class440_, out var _);
				return Class476.smethod_0(class440_);
			}
			set
			{
				Class472.smethod_0(base.m_txTextControl, delegate(Class440 chart)
				{
					foreach (Class437 item in (IEnumerable<Class437>)chart.Class435_0)
					{
						item.Class434_0.Boolean_2 = value;
					}
				});
			}
		}

		private void method_0(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.NoIconLabeled, bool_0: false, ribbonMenuButton.Name + "_0", null, this);
				ribbonToggleButton.Tag = 0;
				ribbonToggleButton.Click += method_124;
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.NoIconLabeled, bool_0: false, ribbonMenuButton.Name + "_10", null, this);
				ribbonToggleButton2.Tag = Convert.ToInt32(25.5);
				ribbonToggleButton2.Click += method_124;
				RibbonToggleButton ribbonToggleButton3 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.NoIconLabeled, bool_0: false, ribbonMenuButton.Name + "_20", null, this);
				ribbonToggleButton3.Tag = Convert.ToInt32(51.0);
				ribbonToggleButton3.Click += method_124;
				RibbonToggleButton ribbonToggleButton4 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.NoIconLabeled, bool_0: false, ribbonMenuButton.Name + "_30", null, this);
				ribbonToggleButton4.Tag = Convert.ToInt32(76.5);
				ribbonToggleButton4.Click += method_124;
				RibbonToggleButton ribbonToggleButton5 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.NoIconLabeled, bool_0: false, ribbonMenuButton.Name + "_40", null, this);
				ribbonToggleButton5.Click += method_124;
				ribbonToggleButton5.Tag = Convert.ToInt32(102.0);
				RibbonToggleButton ribbonToggleButton6 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.NoIconLabeled, bool_0: false, ribbonMenuButton.Name + "_50", null, this);
				ribbonToggleButton6.Tag = Convert.ToInt32(127.5);
				ribbonToggleButton6.Click += method_124;
				RibbonToggleButton ribbonToggleButton7 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.NoIconLabeled, bool_0: false, ribbonMenuButton.Name + "_60", null, this);
				ribbonToggleButton7.Click += method_124;
				ribbonToggleButton7.Tag = Convert.ToInt32(153.0);
				RibbonToggleButton ribbonToggleButton8 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.NoIconLabeled, bool_0: false, ribbonMenuButton.Name + "_70", null, this);
				ribbonToggleButton8.Tag = Convert.ToInt32(178.5);
				ribbonToggleButton8.Click += method_124;
				RibbonToggleButton ribbonToggleButton9 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.NoIconLabeled, bool_0: false, ribbonMenuButton.Name + "_80", null, this);
				ribbonToggleButton9.Click += method_124;
				ribbonToggleButton9.Tag = Convert.ToInt32(204.0);
				RibbonToggleButton ribbonToggleButton10 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.NoIconLabeled, bool_0: false, ribbonMenuButton.Name + "_90", null, this);
				ribbonToggleButton10.Tag = Convert.ToInt32(229.5);
				ribbonToggleButton10.Click += method_124;
				RibbonToggleButton ribbonToggleButton11 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.NoIconLabeled, bool_0: false, ribbonMenuButton.Name + "_100", null, this);
				ribbonToggleButton11.Click += method_124;
				ribbonToggleButton11.Tag = 255;
				ribbonMenuButton.DropDownItems.AddRange(new Control[11]
				{
					ribbonToggleButton, ribbonToggleButton2, ribbonToggleButton3, ribbonToggleButton4, ribbonToggleButton5, ribbonToggleButton6, ribbonToggleButton7, ribbonToggleButton8, ribbonToggleButton9, ribbonToggleButton10,
					ribbonToggleButton11
				});
			}
		}

		private void method_1(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_WrapText_InLineWithText.ToString(), null, this);
				ribbonToggleButton.CheckedChanged += method_125;
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_WrapText_TopAndBottom.ToString(), null, this);
				ribbonToggleButton2.CheckedChanged += method_125;
				RibbonToggleButton ribbonToggleButton3 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_WrapText_Square.ToString(), null, this);
				ribbonToggleButton3.CheckedChanged += method_125;
				RibbonToggleButton ribbonToggleButton4 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_WrapText_BehindText.ToString(), null, this);
				ribbonToggleButton4.CheckedChanged += method_125;
				RibbonToggleButton ribbonToggleButton5 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_WrapText_InFrontOfText.ToString(), null, this);
				ribbonToggleButton5.CheckedChanged += method_125;
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_WrapTextSeperator1.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_WrapText_MoreLayoutOptions.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[7] { ribbonToggleButton, ribbonToggleButton2, ribbonToggleButton3, ribbonToggleButton4, ribbonToggleButton5, ribbonSeperator2, ribbonButton });
			}
		}

		private void method_2(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BringToFront_ToFront.ToString(), "Click", this);
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BringToFront_Forward.ToString(), "Click", this);
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BringToFront_InFrontOfText.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[3] { ribbonButton, ribbonButton2, ribbonButton3 });
			}
		}

		private void method_3(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_SendToBack_ToBack.ToString(), "Click", this);
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_SendToBack_Backward.ToString(), "Click", this);
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_SendToBack_BehindText.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[3] { ribbonButton, ribbonButton2, ribbonButton3 });
			}
		}

		private void method_4(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Position_Left.ToString(), null, this);
				ribbonToggleButton.CheckedChanged += method_126;
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Position_Center.ToString(), null, this);
				ribbonToggleButton2.CheckedChanged += method_126;
				RibbonToggleButton ribbonToggleButton3 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Position_Right.ToString(), null, this);
				ribbonToggleButton3.CheckedChanged += method_126;
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_PositionSeperator1.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				RibbonToggleButton ribbonToggleButton4 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Position_OtherPosition.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[5] { ribbonToggleButton, ribbonToggleButton2, ribbonToggleButton3, ribbonSeperator2, ribbonToggleButton4 });
			}
		}

		private void method_5(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingRotation_Right90.ToString(), "Click", this);
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingRotation_Left90.ToString(), "Click", this);
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingRotation_FlipHorizontal.ToString(), "Click", this);
				RibbonButton ribbonButton4 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingRotation_FlipVertical.ToString(), "Click", this);
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingRotationSeperator1.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				RibbonButton ribbonButton5 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingRotation_MoreRotationOptions.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[6] { ribbonButton, ribbonButton2, ribbonButton3, ribbonButton4, ribbonSeperator2, ribbonButton5 });
			}
		}

		private void method_6(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeHorizontalAlignment_Left.ToString(), null, this);
				ribbonToggleButton.Click += method_132;
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeHorizontalAlignment_Center.ToString(), null, this);
				ribbonToggleButton2.Click += method_132;
				RibbonToggleButton ribbonToggleButton3 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeHorizontalAlignment_Right.ToString(), null, this);
				ribbonToggleButton3.Click += method_132;
				ribbonMenuButton.DropDownItems.AddRange(new Control[3] { ribbonToggleButton, ribbonToggleButton2, ribbonToggleButton3 });
			}
		}

		private void method_7(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeVerticalAlignment_Top.ToString(), null, this);
				ribbonToggleButton.Click += method_132;
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeVerticalAlignment_Middle.ToString(), null, this);
				ribbonToggleButton2.Click += method_132;
				RibbonToggleButton ribbonToggleButton3 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeVerticalAlignment_Bottom.ToString(), null, this);
				ribbonToggleButton3.Click += method_132;
				ribbonMenuButton.DropDownItems.AddRange(new Control[3] { ribbonToggleButton, ribbonToggleButton2, ribbonToggleButton3 });
			}
		}

		private void method_8(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeRotation_Right90.ToString(), null, this);
				ribbonButton.Tag = 90;
				ribbonButton.Click += method_133;
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeRotation_Left90.ToString(), null, this);
				ribbonButton2.Click += method_133;
				ribbonButton2.Tag = -90;
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeRotation_180.ToString(), null, this);
				ribbonButton3.Click += method_133;
				ribbonButton3.Tag = 180;
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeRotationSeperator1.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				RibbonButton ribbonButton4 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeRotation_MoreRotationOptions.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[5] { ribbonButton, ribbonButton2, ribbonButton3, ribbonSeperator2, ribbonButton4 });
			}
		}

		private void method_9(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton = control_0 as RibbonMenuButton;
			if (ribbonMenuButton != null)
			{
				base.AddChartCategory(dictionary_0, ribbonMenuButton.DropDownItems, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_ColumnCategory.ToString(), null, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_ColumnGallery.ToString(), new RibbonInsertTab.ChartTemplate[7]
				{
					RibbonInsertTab.ChartTemplate.ClusteredColumn,
					RibbonInsertTab.ChartTemplate.StackedColumn,
					RibbonInsertTab.ChartTemplate.StackedColumn100Percent,
					RibbonInsertTab.ChartTemplate.ClusteredColumn3D,
					RibbonInsertTab.ChartTemplate.StackedColumn3D,
					RibbonInsertTab.ChartTemplate.StackedColumn100Percent3D,
					RibbonInsertTab.ChartTemplate.Column3D
				});
				base.AddChartCategory(dictionary_0, ribbonMenuButton.DropDownItems, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_LineCategory.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_LineSeperator.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_LineGallery.ToString(), new RibbonInsertTab.ChartTemplate[3]
				{
					RibbonInsertTab.ChartTemplate.Line,
					RibbonInsertTab.ChartTemplate.LineWithMarkers,
					RibbonInsertTab.ChartTemplate.Line3D
				});
				base.AddChartCategory(dictionary_0, ribbonMenuButton.DropDownItems, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_PieCategory.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_PieSeperator.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_PieGallery.ToString(), new RibbonInsertTab.ChartTemplate[3]
				{
					RibbonInsertTab.ChartTemplate.Pie,
					RibbonInsertTab.ChartTemplate.Pie3D,
					RibbonInsertTab.ChartTemplate.Doughnut
				});
				base.AddChartCategory(dictionary_0, ribbonMenuButton.DropDownItems, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_BarCategory.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_BarSeperator.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_BarGallery.ToString(), new RibbonInsertTab.ChartTemplate[6]
				{
					RibbonInsertTab.ChartTemplate.ClusteredBar,
					RibbonInsertTab.ChartTemplate.StackedBar,
					RibbonInsertTab.ChartTemplate.StackedBar100Percent,
					RibbonInsertTab.ChartTemplate.ClusteredBar3D,
					RibbonInsertTab.ChartTemplate.StackedBar3D,
					RibbonInsertTab.ChartTemplate.StackedBar100Percent3D
				});
				base.AddChartCategory(dictionary_0, ribbonMenuButton.DropDownItems, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_AreaCategory.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_AreaSeperator.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_AreaGallery.ToString(), new RibbonInsertTab.ChartTemplate[6]
				{
					RibbonInsertTab.ChartTemplate.Area,
					RibbonInsertTab.ChartTemplate.StackedArea,
					RibbonInsertTab.ChartTemplate.StackedArea100Percent,
					RibbonInsertTab.ChartTemplate.Area3D,
					RibbonInsertTab.ChartTemplate.StackedArea3D,
					RibbonInsertTab.ChartTemplate.StackedArea100Percent3D
				});
				base.AddChartCategory(dictionary_0, ribbonMenuButton.DropDownItems, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_XYScatterCategory.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_XYScatterSeperator.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_XYScatterGallery.ToString(), new RibbonInsertTab.ChartTemplate[7]
				{
					RibbonInsertTab.ChartTemplate.Scatter,
					RibbonInsertTab.ChartTemplate.ScatterWithSmoothLinesAndMarkers,
					RibbonInsertTab.ChartTemplate.ScatterWithSmoothLines,
					RibbonInsertTab.ChartTemplate.ScatterWithStraightLinesAndMarkers,
					RibbonInsertTab.ChartTemplate.ScatterWithStraightLines,
					RibbonInsertTab.ChartTemplate.Bubble,
					RibbonInsertTab.ChartTemplate.Bubble3D
				});
				base.AddChartCategory(dictionary_0, ribbonMenuButton.DropDownItems, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_StockCategory.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_StockSeperator.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_StockGallery.ToString(), new RibbonInsertTab.ChartTemplate[2]
				{
					RibbonInsertTab.ChartTemplate.HighLowClose,
					RibbonInsertTab.ChartTemplate.OpenHighLowClose
				});
				base.AddChartCategory(dictionary_0, ribbonMenuButton.DropDownItems, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_RadarCategory.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_RadarSeperator.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_RadarGallery.ToString(), new RibbonInsertTab.ChartTemplate[3]
				{
					RibbonInsertTab.ChartTemplate.Radar,
					RibbonInsertTab.ChartTemplate.RadarWithMarkers,
					RibbonInsertTab.ChartTemplate.FilledRadar
				});
			}
		}

		private void method_10(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton = control_0 as RibbonMenuButton;
			if (ribbonMenuButton != null)
			{
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.NoIconLabeled, bool_0: false, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartRotation_Right90.ToString(), null, this);
				ribbonButton.Tag = 90;
				ribbonButton.Click += method_134;
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.NoIconLabeled, bool_0: false, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartRotation_Left90.ToString(), null, this);
				ribbonButton2.Tag = -90;
				ribbonButton2.Click += method_134;
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.NoIconLabeled, bool_0: false, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartRotation_180.ToString(), null, this);
				ribbonButton3.Tag = 180;
				ribbonButton3.Click += method_134;
				ribbonMenuButton.DropDownItems.AddRange(new Control[3] { ribbonButton, ribbonButton2, ribbonButton3 });
			}
		}

		private void method_11(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton = control_0 as RibbonMenuButton;
			if (ribbonMenuButton != null)
			{
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartInclination_0.ToString(), null, this);
				ribbonToggleButton.Tag = 0;
				ribbonToggleButton.Click += method_135;
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartInclination_30.ToString(), null, this);
				ribbonToggleButton2.Tag = 30;
				ribbonToggleButton2.Click += method_135;
				RibbonToggleButton ribbonToggleButton3 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartInclination_60.ToString(), null, this);
				ribbonToggleButton3.Tag = 60;
				ribbonToggleButton3.Click += method_135;
				ribbonMenuButton.DropDownItems.AddRange(new Control[3] { ribbonToggleButton, ribbonToggleButton2, ribbonToggleButton3 });
			}
		}

		private void method_12(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton = control_0 as RibbonMenuButton;
			if (ribbonMenuButton != null)
			{
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartPerspective_Telephoto.ToString(), null, this);
				ribbonToggleButton.Tag = 0;
				ribbonToggleButton.Click += method_136;
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartPerspective_Normal.ToString(), null, this);
				ribbonToggleButton2.Tag = 2;
				ribbonToggleButton2.Click += method_136;
				RibbonToggleButton ribbonToggleButton3 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartPerspective_WideAngle.ToString(), null, this);
				ribbonToggleButton3.Tag = 10;
				ribbonToggleButton3.Click += method_136;
				ribbonMenuButton.DropDownItems.AddRange(new Control[3] { ribbonToggleButton, ribbonToggleButton2, ribbonToggleButton3 });
			}
		}

		internal override void AwareOfDPI(PointF dpi)
		{
			base.AwareOfDPI(dpi);
			base.SetColorGalleryItems(this.class505_0.TXITEM_TextFrame_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameBackColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetLineWidthItemsImages(this.class505_0.TXITEM_TextFrame_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameLineWidth.ToString()] as RibbonMenuButton, base.m_pntDPI);
			base.SetColorGalleryItems(this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingLineColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetColorGalleryItems(this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingBackColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetLineWidthItemsImages(this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingLineWidth.ToString()] as RibbonMenuButton, base.m_pntDPI);
			base.SetColorGalleryItems(this.class505_0.TXITEM_Barcode_ColorsAndAlignmentGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeForeColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetColorGalleryItems(this.class505_0.TXITEM_Barcode_ColorsAndAlignmentGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeBackColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetGalleryItemsImagesByID(this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_ColumnGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Large_32x32);
			base.SetGalleryItemsImagesByID(this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_LineGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Large_32x32);
			base.SetGalleryItemsImagesByID(this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_PieGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Large_32x32);
			base.SetGalleryItemsImagesByID(this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_BarGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Large_32x32);
			base.SetGalleryItemsImagesByID(this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_AreaGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Large_32x32);
			base.SetGalleryItemsImagesByID(this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_XYScatterGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Large_32x32);
			base.SetGalleryItemsImagesByID(this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_StockGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Large_32x32);
			base.SetGalleryItemsImagesByID(this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartType_RadarGallery.ToString()] as RibbonListView, dpi, ImageProvider.ImageKind.Large_32x32);
			this.SetDialogUnit();
		}

		internal override void AwareOfDPI_MiniToolbar(PointF dpi)
		{
			if (base.m_pntDPI.X != dpi.X || base.m_pntDPI.Y != dpi.Y)
			{
				base.AwareOfDPI_MiniToolbar(dpi);
				base.SetColorGalleryItems(this.class505_0.TXITEM_TextFrame_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameBackColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
				base.SetLineWidthItemsImages(this.class505_0.TXITEM_TextFrame_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameLineWidth.ToString()] as RibbonMenuButton, base.m_pntDPI);
				base.SetColorGalleryItems(this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingLineColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
				base.SetColorGalleryItems(this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingBackColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
				base.SetLineWidthItemsImages(this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingLineWidth.ToString()] as RibbonMenuButton, base.m_pntDPI);
				base.SetColorGalleryItems(this.class505_0.TXITEM_Barcode_ColorsAndAlignmentGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeForeColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
				base.SetColorGalleryItems(this.class505_0.TXITEM_Barcode_ColorsAndAlignmentGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeBackColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
				this.method_16(this.frameBase_0);
			}
		}

		internal override bool SetDialogUnit()
		{
			if (base.SetDialogUnit())
			{
				switch (base.m_iDialogUnit)
				{
				case 0:
				{
					bool flag = true;
					try
					{
						RegionInfo regionInfo = new RegionInfo(Thread.CurrentThread.CurrentCulture.LCID);
						flag = regionInfo.IsMetric;
					}
					catch
					{
					}
					this.measuringUnit_0 = ((!flag) ? MeasuringUnit.CentiInch : MeasuringUnit.Millimeter);
					this.int_0 = (flag ? 1 : 3);
					this.double_0 = (flag ? 1 : 100);
					this.double_1 = (flag ? 1.0 : 0.1);
					break;
				}
				case 1:
					this.measuringUnit_0 = MeasuringUnit.Millimeter;
					this.int_0 = 1;
					this.double_0 = 1.0;
					this.double_1 = 1.0;
					break;
				case 2:
					this.measuringUnit_0 = MeasuringUnit.CentiInch;
					this.int_0 = 3;
					this.double_0 = 100.0;
					this.double_1 = 0.1;
					break;
				case 3:
					this.measuringUnit_0 = MeasuringUnit.Centimeter;
					this.int_0 = 2;
					this.double_0 = 1.0;
					this.double_1 = 0.1;
					break;
				}
				RibbonTextBox ribbonTextBox = this.class505_0.TXITEM_ObjectSizeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectHeight.ToString()] as RibbonTextBox;
				base.SetBasicRibbonTextBoxAppearance(ribbonTextBox, hasImage: true, showDropDownButtons: true, RibbonTextBox.InputValidationMode.OnlyDigits);
				ribbonTextBox.SmallIcon = Class517.smethod_53(ribbonTextBox.String_0, ImageProvider.ImageKind.Small_16x16, base.m_pntDPI);
				RibbonTextBox ribbonTextBox2 = this.class505_0.TXITEM_ObjectSizeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectWidth.ToString()] as RibbonTextBox;
				base.SetBasicRibbonTextBoxAppearance(ribbonTextBox2, hasImage: true, showDropDownButtons: true, RibbonTextBox.InputValidationMode.OnlyDigits);
				ribbonTextBox2.SmallIcon = Class517.smethod_53(ribbonTextBox2.String_0, ImageProvider.ImageKind.Small_16x16, base.m_pntDPI);
				return true;
			}
			return false;
		}

		internal override void SetRibbonItemAppearance(Dictionary<string, object> groupItemsDictionary, Control ribbonItem, string eventName, bool hasImage)
		{
			base.SetBasicRibbonItemAppearance(groupItemsDictionary, ribbonItem, hasImage);
			switch (ribbonItem.Name)
			{
			case "TXITEM_WrapText":
				this.method_1(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_BringToFront":
				this.method_2(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_SendToBack":
				this.method_3(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_Position":
				this.method_4(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_ObjectHeight":
			case "TXITEM_ObjectWidth":
			{
				RibbonTextBox ribbonTextBox2 = ribbonItem as RibbonTextBox;
				ribbonTextBox2.UpButtonClicked += method_128;
				ribbonTextBox2.DownButtonClicked += method_129;
				ribbonTextBox2.TextValidated += method_127;
				break;
			}
			case "TXITEM_ObjectName":
				base.SetBasicRibbonTextBoxAppearance(ribbonItem as RibbonTextBox, hasImage, showDropDownButtons: false, RibbonTextBox.InputValidationMode.All);
				(ribbonItem as RibbonTextBox).TextValidated += method_131;
				break;
			case "TXITEM_ObjectID":
			{
				base.SetBasicRibbonTextBoxAppearance(ribbonItem as RibbonTextBox, hasImage, showDropDownButtons: false, RibbonTextBox.InputValidationMode.OnlyDigits);
				RibbonTextBox ribbonTextBox = ribbonItem as RibbonTextBox;
				ribbonTextBox.Nullable_0 = 0;
				ribbonTextBox.TextValidated += method_130;
				break;
			}
			case "TXITEM_TextFrameBackColor":
				base.Set_TXITEM_Color_DropDown(groupItemsDictionary, ribbonItem, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameBackColor_Automatic.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameBackColorSeperator1.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameBackColor_Gallery.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameBackColorSeperator2.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameBackColor_MoreColors.ToString());
				break;
			case "TXITEM_TextFrameLineWidth":
				base.Set_TXITEM_LineWidth_DropDown(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_TextFrameTransparency":
				this.method_0(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_DrawingLineColor":
				base.Set_TXITEM_Color_DropDown(groupItemsDictionary, ribbonItem, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingLineColor_Automatic.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingLineColorSeperator1.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingLineColor_Gallery.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingLineColorSeperator2.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingLineColor_MoreColors.ToString());
				break;
			case "TXITEM_DrawingBackColor":
				base.Set_TXITEM_Color_DropDown(groupItemsDictionary, ribbonItem, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingBackColor_Automatic.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingBackColorSeperator1.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingBackColor_Gallery.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingBackColorSeperator2.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingBackColor_MoreColors.ToString());
				break;
			case "TXITEM_DrawingLineWidth":
				base.Set_TXITEM_LineWidth_DropDown(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_DrawingTransparency":
				this.method_0(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_DrawingRotation":
				this.method_5(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_BarcodeForeColor":
				base.Set_TXITEM_Color_DropDown(groupItemsDictionary, ribbonItem, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeForeColor_Automatic.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeForeColorSeperator1.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeForeColor_Gallery.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeForeColorSeperator2.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeForeColor_MoreColors.ToString());
				break;
			case "TXITEM_BarcodeBackColor":
				base.Set_TXITEM_Color_DropDown(groupItemsDictionary, ribbonItem, RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeBackColor_Automatic.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeBackColorSeperator1.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeBackColor_Gallery.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeBackColorSeperator2.ToString(), RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeBackColor_MoreColors.ToString());
				break;
			case "TXITEM_BarcodeTransparency":
				this.method_0(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_BarcodeHorizontalAlignment":
				this.method_6(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_BarcodeVerticalAlignment":
				this.method_7(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_BarcodeRotation":
				this.method_8(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_ChartType":
				this.method_9(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_ChartIs3D":
			{
				bool boolean_ = this.Boolean_0;
				this.method_43(boolean_);
				break;
			}
			case "TXITEM_ChartRotation":
				this.method_10(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_ChartHasRightAngleAxes":
				(ribbonItem as RibbonToggleButton).Checked = this.Boolean_1;
				break;
			case "TXITEM_ChartInclination":
				this.method_11(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_ChartPerspective":
				this.method_12(groupItemsDictionary, ribbonItem);
				break;
			}
			if (eventName != null)
			{
				Class517.smethod_23(ribbonItem, eventName, ribbonItem.Name + "_Handler", this);
			}
		}

		internal override void OnDisconnectingTextControl()
		{
			base.m_txTextControl.FrameSelected -= method_137;
			base.m_txTextControl.FrameLayoutChanged -= method_139;
			base.m_txTextControl.FrameMoved -= method_140;
			base.m_txTextControl.FrameSized -= method_141;
			base.m_txTextControl.TextFrameAppearanceChanged -= method_142;
			base.m_txTextControl.DrawingActivated -= method_144;
			base.m_txTextControl.DrawingDeactivated -= method_143;
			base.m_txTextControl.FrameDeselected -= method_138;
			foreach (DrawingFrame drawing in base.m_txTextControl.Drawings)
			{
				TXDrawingControl tXDrawingControl = drawing.Drawing as TXDrawingControl;
				if (tXDrawingControl != null)
				{
					tXDrawingControl.PropertyChanged -= method_145;
					tXDrawingControl.ShapeFormatChanged -= method_146;
					tXDrawingControl.ShapeSelected -= method_148;
					tXDrawingControl.ShapeDeselected -= method_148;
					tXDrawingControl.ShapeSized -= method_147;
				}
			}
		}

		internal override void OnTextControlConnected()
		{
			base.m_txTextControl.FrameSelected += method_137;
			base.m_txTextControl.FrameSized += method_141;
			base.m_txTextControl.FrameLayoutChanged += method_139;
			base.m_txTextControl.FrameMoved += method_140;
			base.m_txTextControl.TextFrameAppearanceChanged += method_142;
			base.m_txTextControl.DrawingActivated += method_144;
			base.m_txTextControl.DrawingDeactivated += method_143;
			base.m_txTextControl.FrameDeselected += method_138;
		}

		internal void method_13(TextFrame textFrame_0)
		{
			this.frameBase_0 = textFrame_0;
			this.method_152(textFrame_0);
			this.method_153(textFrame_0);
			this.method_154(textFrame_0);
		}

		internal void method_14(TXDrawingControl txdrawingControl_0, DrawingFrame drawingFrame_1)
		{
			TXDrawingControl txdrawingControl_ = ((txdrawingControl_0 == null) ? (drawingFrame_1.Drawing as TXDrawingControl) : txdrawingControl_0);
			this.method_79(txdrawingControl_, drawingFrame_1);
			this.method_80(txdrawingControl_, drawingFrame_1);
			this.method_82(txdrawingControl_, drawingFrame_1);
			this.method_81(txdrawingControl_, drawingFrame_1);
		}

		internal void method_15(BarcodeFrame barcodeFrame_0)
		{
			TXBarcodeControl tXBarcodeControl = this.method_26(null, out barcodeFrame_0);
			if (tXBarcodeControl != null)
			{
				this.method_24(bool_0: true, tXBarcodeControl);
				this.method_25(tXBarcodeControl);
				this.method_24(bool_0: false, tXBarcodeControl);
			}
		}

		internal void method_16(FrameBase frameBase_1)
		{
			this.frameBase_0 = frameBase_1;
			if (frameBase_1 is TextFrame)
			{
				(this.class505_0.TXITEM_TextFrame_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrame_BordersandBackgroundGroup.ToString()] as RibbonGroup).Visible = true;
				(this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Drawing_BordersandBackgroundGroup.ToString()] as RibbonGroup).Visible = false;
				(this.class505_0.TXITEM_Barcode_ColorsAndAlignmentGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Barcode_ColorsAndAlignmentGroup.ToString()] as RibbonGroup).Visible = false;
				this.method_13(frameBase_1 as TextFrame);
			}
			else if (frameBase_1 is DrawingFrame)
			{
				(this.class505_0.TXITEM_TextFrame_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrame_BordersandBackgroundGroup.ToString()] as RibbonGroup).Visible = false;
				(this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Drawing_BordersandBackgroundGroup.ToString()] as RibbonGroup).Visible = true;
				(this.class505_0.TXITEM_Barcode_ColorsAndAlignmentGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Barcode_ColorsAndAlignmentGroup.ToString()] as RibbonGroup).Visible = false;
				DrawingFrame drawingFrame = frameBase_1 as DrawingFrame;
				TXDrawingControl txdrawingControl_ = drawingFrame.Drawing as TXDrawingControl;
				this.method_14(txdrawingControl_, drawingFrame);
			}
			else if (frameBase_1 is BarcodeFrame)
			{
				(this.class505_0.TXITEM_TextFrame_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrame_BordersandBackgroundGroup.ToString()] as RibbonGroup).Visible = false;
				(this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Drawing_BordersandBackgroundGroup.ToString()] as RibbonGroup).Visible = false;
				(this.class505_0.TXITEM_Barcode_ColorsAndAlignmentGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Barcode_ColorsAndAlignmentGroup.ToString()] as RibbonGroup).Visible = true;
				this.method_15(frameBase_1 as BarcodeFrame);
			}
		}

		private void method_17()
		{
			if (base.m_txTextControl != null && base.m_txTextControl.Barcodes.GetItem() != null)
			{
				base.m_txTextControl.BarcodeLayoutDialog(2);
			}
		}

		private void method_18(RibbonButton ribbonButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			BarcodeFrame barcodeFrame_;
			TXBarcodeControl tXBarcodeControl = this.method_26(null, out barcodeFrame_);
			if (tXBarcodeControl == null)
			{
				return;
			}
			Alignment alignment = tXBarcodeControl.Alignment;
			switch (ribbonButton_0.Name)
			{
			case "TXITEM_BarcodeVerticalAlignment_Bottom":
				if (this.method_28(alignment))
				{
					tXBarcodeControl.Alignment = Alignment.BottomLeft;
				}
				if (this.method_29(alignment))
				{
					tXBarcodeControl.Alignment = Alignment.BottomCenter;
				}
				if (this.method_30(alignment))
				{
					tXBarcodeControl.Alignment = Alignment.BottomRight;
				}
				break;
			case "TXITEM_BarcodeVerticalAlignment_Middle":
				if (this.method_28(alignment))
				{
					tXBarcodeControl.Alignment = Alignment.MiddleLeft;
				}
				if (this.method_29(alignment))
				{
					tXBarcodeControl.Alignment = Alignment.MiddleCenter;
				}
				if (this.method_30(alignment))
				{
					tXBarcodeControl.Alignment = Alignment.MiddleRight;
				}
				break;
			case "TXITEM_BarcodeVerticalAlignment_Top":
				if (this.method_28(alignment))
				{
					tXBarcodeControl.Alignment = Alignment.TopLeft;
				}
				if (this.method_29(alignment))
				{
					tXBarcodeControl.Alignment = Alignment.TopCenter;
				}
				if (this.method_30(alignment))
				{
					tXBarcodeControl.Alignment = Alignment.TopRight;
				}
				break;
			case "TXITEM_BarcodeHorizontalAlignment_Right":
				if (this.method_31(alignment))
				{
					tXBarcodeControl.Alignment = Alignment.TopRight;
				}
				if (this.method_32(alignment))
				{
					tXBarcodeControl.Alignment = Alignment.MiddleRight;
				}
				if (this.method_33(alignment))
				{
					tXBarcodeControl.Alignment = Alignment.BottomRight;
				}
				break;
			case "TXITEM_BarcodeHorizontalAlignment_Center":
				if (this.method_31(alignment))
				{
					tXBarcodeControl.Alignment = Alignment.TopLeft;
				}
				if (this.method_32(alignment))
				{
					tXBarcodeControl.Alignment = Alignment.MiddleCenter;
				}
				if (this.method_33(alignment))
				{
					tXBarcodeControl.Alignment = Alignment.BottomCenter;
				}
				break;
			case "TXITEM_BarcodeHorizontalAlignment_Left":
				if (this.method_31(alignment))
				{
					tXBarcodeControl.Alignment = Alignment.TopLeft;
				}
				if (this.method_32(alignment))
				{
					tXBarcodeControl.Alignment = Alignment.MiddleLeft;
				}
				if (this.method_33(alignment))
				{
					tXBarcodeControl.Alignment = Alignment.MiddleLeft;
				}
				break;
			}
			barcodeFrame_?.Refresh();
			this.method_22(tXBarcodeControl);
			this.method_23(tXBarcodeControl);
		}

		private void method_19(RibbonButton ribbonButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			BarcodeFrame barcodeFrame_;
			object obj = this.method_26(null, out barcodeFrame_);
			if (obj != null)
			{
				Control7 control = new Control7(obj);
				control.Int32_1 = Class517.smethod_30(control.Int32_1 + (int)ribbonButton_0.Tag);
				if (barcodeFrame_ != null)
				{
					barcodeFrame_.AddUndoUnit();
					barcodeFrame_.Refresh();
				}
			}
		}

		private void method_20()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.BarcodeLayoutDialog(2);
			}
		}

		private void method_21(FrameBase frameBase_1)
		{
			RibbonGroup ribbonGroup = this.class505_0.TXITEM_Barcode_ColorsAndAlignmentGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Barcode_ColorsAndAlignmentGroup.ToString()] as RibbonGroup;
			if (this.class505_0.method_0(ribbonGroup))
			{
				BarcodeFrame barcodeFrame_;
				TXBarcodeControl tXBarcodeControl = this.method_26(frameBase_1 as BarcodeFrame, out barcodeFrame_);
				bool flag;
				if (flag = tXBarcodeControl != null)
				{
					this.method_22(tXBarcodeControl);
					this.method_23(tXBarcodeControl);
					this.method_24(bool_0: true, tXBarcodeControl);
					this.method_25(tXBarcodeControl);
					this.method_24(bool_0: false, tXBarcodeControl);
				}
				ribbonGroup.Enabled = flag || base.m_txTextControl == null;
			}
		}

		internal void method_22(TXBarcodeControl txbarcodeControl_0)
		{
			RibbonMenuButton ribbonMenuButton = this.class505_0.TXITEM_Barcode_ColorsAndAlignmentGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeHorizontalAlignment.ToString()] as RibbonMenuButton;
			if (!this.class505_0.method_3(ribbonMenuButton))
			{
				return;
			}
			Alignment alignment_ = txbarcodeControl_0?.Alignment ?? ((Alignment)(-1));
			foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
			{
				RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
				if (ribbonToggleButton != null && ((IRibbonItem)ribbonToggleButton).IsDefaultRibbonTabItem)
				{
					switch (dropDownItem.Name)
					{
					case "TXITEM_BarcodeHorizontalAlignment_Right":
						ribbonToggleButton.Checked = this.method_30(alignment_);
						break;
					case "TXITEM_BarcodeHorizontalAlignment_Center":
						ribbonToggleButton.Checked = this.method_29(alignment_);
						break;
					case "TXITEM_BarcodeHorizontalAlignment_Left":
						ribbonToggleButton.Checked = this.method_28(alignment_);
						break;
					}
				}
			}
		}

		internal void method_23(TXBarcodeControl txbarcodeControl_0)
		{
			RibbonMenuButton ribbonMenuButton = this.class505_0.TXITEM_Barcode_ColorsAndAlignmentGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeVerticalAlignment.ToString()] as RibbonMenuButton;
			if (!this.class505_0.method_3(ribbonMenuButton))
			{
				return;
			}
			Alignment alignment_ = txbarcodeControl_0?.Alignment ?? ((Alignment)(-1));
			foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
			{
				RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
				if (ribbonToggleButton != null && ((IRibbonItem)ribbonToggleButton).IsDefaultRibbonTabItem)
				{
					switch (dropDownItem.Name)
					{
					case "TXITEM_BarcodeVerticalAlignment_Bottom":
						ribbonToggleButton.Checked = this.method_33(alignment_);
						break;
					case "TXITEM_BarcodeVerticalAlignment_Middle":
						ribbonToggleButton.Checked = this.method_32(alignment_);
						break;
					case "TXITEM_BarcodeVerticalAlignment_Top":
						ribbonToggleButton.Checked = this.method_31(alignment_);
						break;
					}
				}
			}
		}

		internal void method_24(bool bool_0, TXBarcodeControl txbarcodeControl_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonToggleButton ribbonToggleButton = this.class505_0.TXITEM_Barcode_ColorsAndAlignmentGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeBackColor_Automatic.ToString()] as RibbonToggleButton;
			RibbonMenuButton ribbonMenuButton = ((!bool_0) ? (this.class505_0.TXITEM_Barcode_ColorsAndAlignmentGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeForeColor.ToString()] as RibbonMenuButton) : (this.class505_0.TXITEM_Barcode_ColorsAndAlignmentGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeBackColor.ToString()] as RibbonMenuButton));
			if (this.class505_0.method_2(ribbonMenuButton) || this.class505_0.method_2(ribbonToggleButton))
			{
				Color? color = null;
				if (txbarcodeControl_0 != null)
				{
					color = (bool_0 ? txbarcodeControl_0.BackColor : txbarcodeControl_0.ForeColor);
				}
				if (color.HasValue && color.Value.A != byte.MaxValue)
				{
					color = Color.FromArgb(255, color.Value);
				}
				Class517.smethod_59(ribbonMenuButton, color, this.class505_0.Control_0 is ObjectMiniToolbar, base.m_pntDPI);
				ribbonToggleButton.Checked = ((!bool_0) ? (color == SystemColors.WindowText) : (color == SystemColors.Window));
			}
		}

		internal void method_25(TXBarcodeControl txbarcodeControl_0)
		{
			RibbonMenuButton ribbonMenuButton = this.class505_0.TXITEM_Barcode_ColorsAndAlignmentGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BarcodeTransparency.ToString()] as RibbonMenuButton;
			if (!this.class505_0.method_3(ribbonMenuButton))
			{
				return;
			}
			double num = ((txbarcodeControl_0 != null) ? (255.0 - Convert.ToDouble(txbarcodeControl_0.BackColor.A)) : (-1.0));
			foreach (IRibbonItem dropDownItem in ribbonMenuButton.DropDownItems)
			{
				if (dropDownItem.IsDefaultRibbonTabItem)
				{
					RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
					if (ribbonToggleButton != null)
					{
						ribbonToggleButton.Checked = Convert.ToDouble(ribbonToggleButton.Tag) == num;
					}
				}
			}
		}

		internal TXBarcodeControl method_26(FrameBase frameBase_1, out BarcodeFrame barcodeFrame_0)
		{
			barcodeFrame_0 = ((base.m_txTextControl == null || frameBase_1 != null) ? (frameBase_1 as BarcodeFrame) : base.m_txTextControl.Barcodes.GetItem());
			if (barcodeFrame_0 != null)
			{
				return barcodeFrame_0.Barcode as TXBarcodeControl;
			}
			return null;
		}

		internal Control7 method_27(FrameBase frameBase_1, out BarcodeFrame barcodeFrame_0)
		{
			if ((barcodeFrame_0 = frameBase_1 as BarcodeFrame) == null)
			{
				barcodeFrame_0 = base.m_txTextControl.Barcodes.GetItem();
			}
			if (barcodeFrame_0 != null)
			{
				return base.m_txTextControl.textControlCore_0.control4_0[barcodeFrame_0.int_1] as Control7;
			}
			return null;
		}

		private bool method_28(Alignment alignment_0)
		{
			if (alignment_0 != Alignment.TopLeft && alignment_0 != Alignment.MiddleLeft)
			{
				return alignment_0 == Alignment.BottomLeft;
			}
			return true;
		}

		private bool method_29(Alignment alignment_0)
		{
			if (alignment_0 != Alignment.TopCenter && alignment_0 != Alignment.MiddleCenter)
			{
				return alignment_0 == Alignment.BottomCenter;
			}
			return true;
		}

		private bool method_30(Alignment alignment_0)
		{
			if (alignment_0 != Alignment.TopRight && alignment_0 != Alignment.MiddleRight)
			{
				return alignment_0 == Alignment.BottomRight;
			}
			return true;
		}

		private bool method_31(Alignment alignment_0)
		{
			if (alignment_0 != Alignment.TopLeft && alignment_0 != Alignment.TopCenter)
			{
				return alignment_0 == Alignment.TopRight;
			}
			return true;
		}

		private bool method_32(Alignment alignment_0)
		{
			if (alignment_0 != Alignment.MiddleLeft && alignment_0 != Alignment.MiddleCenter)
			{
				return alignment_0 == Alignment.MiddleRight;
			}
			return true;
		}

		private bool method_33(Alignment alignment_0)
		{
			if (alignment_0 != Alignment.BottomCenter && alignment_0 != Alignment.BottomLeft)
			{
				return alignment_0 == Alignment.BottomRight;
			}
			return true;
		}

		private void method_34()
		{
			if (base.m_txTextControl != null)
			{
				ChartFrame item = base.m_txTextControl.Charts.GetItem();
				if (item != null)
				{
					base.m_txTextControl.ChartLayoutDialog(2);
				}
			}
		}

		private void method_35(RibbonMenuButton ribbonMenuButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			Class517.smethod_34(base.m_txTextControl, out var class440_, out var _);
			bool flag = false;
			Class454.SeriesChartType seriesChartType = Class454.SeriesChartType.UNKNOWN;
			bool enabled = false;
			bool enabled2 = false;
			bool enabled3 = false;
			if (class440_.Class452_0.Count > 0)
			{
				flag = true;
				seriesChartType = class440_.Class452_0[0].SeriesChartType_0;
				for (int i = 1; i < class440_.Class452_0.Count; i++)
				{
					Class454 @class = class440_.Class452_0[i];
					if (@class.SeriesChartType_0 != seriesChartType)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				switch (seriesChartType)
				{
				default:
					enabled = false;
					enabled2 = false;
					enabled3 = true;
					break;
				case Class454.SeriesChartType.Pie:
				case Class454.SeriesChartType.Doughnut:
					enabled = true;
					enabled2 = false;
					enabled3 = false;
					break;
				case Class454.SeriesChartType.Stock:
				case Class454.SeriesChartType.Candlestick:
					enabled = false;
					enabled2 = true;
					enabled3 = false;
					break;
				}
			}
			foreach (IRibbonItem dropDownItem in ribbonMenuButton_0.DropDownItems)
			{
				if (dropDownItem.IsDefaultRibbonTabItem)
				{
					Control control = dropDownItem as Control;
					switch (control.Name.Substring(control.Name.LastIndexOf("_") + 1))
					{
					case "StockCategory":
					case "StockGallery":
						control.Enabled = enabled2;
						break;
					case "PieCategory":
					case "PieGallery":
						control.Enabled = enabled;
						break;
					default:
						control.Enabled = enabled3;
						break;
					}
				}
			}
		}

		private void method_36(RibbonListView ribbonListView_0, RibbonListView.RibbonListViewItemEventArgs ribbonListViewItemEventArgs_0)
		{
			if (base.m_txTextControl != null)
			{
				switch (ribbonListView_0.Name)
				{
				case "TXITEM_ChartType_ColumnGallery":
				case "TXITEM_ChartType_LineGallery":
				case "TXITEM_ChartType_PieGallery":
				case "TXITEM_ChartType_BarGallery":
				case "TXITEM_ChartType_AreaGallery":
				case "TXITEM_ChartType_XYScatterGallery":
				case "TXITEM_ChartType_StockGallery":
				case "TXITEM_ChartType_RadarGallery":
					this.method_47((RibbonInsertTab.ChartTemplate)Enum.Parse(typeof(RibbonInsertTab.ChartTemplate), ribbonListViewItemEventArgs_0.Item.Tag.ToString()));
					ribbonListView_0.SelectedItems = new RibbonListView.RibbonListViewItem[0];
					break;
				}
			}
		}

		private void method_37(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				this.Boolean_0 = bool_0;
				this.class505_0.method_17(bool_0);
				this.method_42(null);
			}
		}

		private void method_38(RibbonButton ribbonButton_0)
		{
			if (base.m_txTextControl != null)
			{
				this.method_48((int)ribbonButton_0.Tag);
			}
		}

		private void method_39(bool bool_0)
		{
			RibbonMenuButton ribbonMenuButton = this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartPerspective.ToString()] as RibbonMenuButton;
			RibbonToggleButton ribbonToggleButton = this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartIs3D.ToString()] as RibbonToggleButton;
			this.Boolean_1 = bool_0;
			ribbonMenuButton.Enabled = !bool_0 && ribbonToggleButton.Checked;
			this.method_46(this.method_51(null));
		}

		private void method_40(RibbonButton ribbonButton_0)
		{
			if (base.m_txTextControl != null)
			{
				this.method_50((int)ribbonButton_0.Tag);
			}
		}

		private void method_41(RibbonButton ribbonButton_0)
		{
			if (base.m_txTextControl != null)
			{
				this.method_52((int)ribbonButton_0.Tag);
			}
		}

		private void method_42(FrameBase frameBase_1)
		{
			RibbonGroup ribbonGroup = this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Chart_TypeAndAppearanceGroup.ToString()] as RibbonGroup;
			if (this.class505_0.method_0(ribbonGroup))
			{
				ChartFrame chartFrame_ = frameBase_1 as ChartFrame;
				Class440 class440_;
				if (chartFrame_ == null)
				{
					Class517.smethod_34(base.m_txTextControl, out class440_, out chartFrame_);
				}
				else
				{
					class440_ = new Class440(chartFrame_);
				}
				if (class440_ != null)
				{
					this.method_43(class440_.Nullable_0 == true);
					this.method_44(class440_);
					this.method_45(this.method_49(class440_));
					this.method_46(this.method_51(class440_));
				}
				ribbonGroup.Enabled = class440_ != null || base.m_txTextControl == null;
			}
		}

		private void method_43(bool bool_0)
		{
			RibbonToggleButton ribbonToggleButton = this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartIs3D.ToString()] as RibbonToggleButton;
			RibbonToggleButton object_ = this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartHasRightAngleAxes.ToString()] as RibbonToggleButton;
			RibbonMenuButton object_2 = this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartRotation.ToString()] as RibbonMenuButton;
			_ = this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartInclination.ToString()];
			RibbonMenuButton object_3 = this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartPerspective.ToString()] as RibbonMenuButton;
			if (this.class505_0.method_2(ribbonToggleButton) || this.class505_0.method_2(object_) || this.class505_0.method_2(object_2) || this.class505_0.method_2(object_3) || this.class505_0.method_2(object_3))
			{
				ribbonToggleButton.Checked = bool_0;
				this.class505_0.method_17(bool_0);
			}
		}

		private void method_44(Class440 class440_0)
		{
			RibbonToggleButton ribbonToggleButton = this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartHasRightAngleAxes.ToString()] as RibbonToggleButton;
			RibbonMenuButton ribbonMenuButton = this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartPerspective.ToString()] as RibbonMenuButton;
			RibbonToggleButton ribbonToggleButton2 = this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartIs3D.ToString()] as RibbonToggleButton;
			if ((this.class505_0.method_2(ribbonToggleButton) || this.class505_0.method_2(ribbonMenuButton) || this.class505_0.method_2(ribbonToggleButton2)) && ribbonToggleButton.Enabled)
			{
				bool flag2 = (ribbonToggleButton.Checked = Class476.smethod_0(class440_0));
				ribbonMenuButton.Enabled = !flag2 && ribbonToggleButton2.Checked;
			}
		}

		private void method_45(int int_1)
		{
			RibbonMenuButton ribbonMenuButton = this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartInclination.ToString()] as RibbonMenuButton;
			if (!this.class505_0.method_3(ribbonMenuButton))
			{
				return;
			}
			foreach (IRibbonItem dropDownItem in ribbonMenuButton.DropDownItems)
			{
				if (dropDownItem.IsDefaultRibbonTabItem)
				{
					RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
					if (ribbonToggleButton != null)
					{
						ribbonToggleButton.Checked = (int)ribbonToggleButton.Tag == int_1;
					}
				}
			}
		}

		private void method_46(int int_1)
		{
			RibbonMenuButton ribbonMenuButton = this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ChartPerspective.ToString()] as RibbonMenuButton;
			if (!this.class505_0.method_3(ribbonMenuButton))
			{
				return;
			}
			foreach (IRibbonItem dropDownItem in ribbonMenuButton.DropDownItems)
			{
				if (dropDownItem.IsDefaultRibbonTabItem)
				{
					RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
					if (ribbonToggleButton != null)
					{
						ribbonToggleButton.Checked = (int)ribbonToggleButton.Tag == int_1;
					}
				}
			}
		}

		private void method_47(RibbonInsertTab.ChartTemplate chartTemplate_0)
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
			Class454.SeriesChartType seriesChartType = Class454.SeriesChartType.UNKNOWN;
			string string_ = "";
			string[][] array = null;
			bool boolean_ = chartTemplate_0.ToString().EndsWith("3D");
			bool boolean_2 = false;
			MarkerStyle markerStyle_ = MarkerStyle.None;
			switch (chartTemplate_0)
			{
			case RibbonInsertTab.ChartTemplate.ClusteredColumn3D:
				seriesChartType = Class454.SeriesChartType.Column;
				boolean_2 = true;
				break;
			case RibbonInsertTab.ChartTemplate.StackedColumn:
			case RibbonInsertTab.ChartTemplate.StackedColumn3D:
				seriesChartType = Class454.SeriesChartType.StackedColumn;
				break;
			case RibbonInsertTab.ChartTemplate.StackedColumn100Percent:
			case RibbonInsertTab.ChartTemplate.StackedColumn100Percent3D:
				seriesChartType = Class454.SeriesChartType.StackedColumn100;
				string_ = "{0}%";
				break;
			case RibbonInsertTab.ChartTemplate.ClusteredColumn:
			case RibbonInsertTab.ChartTemplate.Column3D:
				seriesChartType = Class454.SeriesChartType.Column;
				break;
			case RibbonInsertTab.ChartTemplate.LineWithMarkers:
				seriesChartType = Class454.SeriesChartType.Line;
				markerStyle_ = MarkerStyle.Circle;
				break;
			case RibbonInsertTab.ChartTemplate.Line:
			case RibbonInsertTab.ChartTemplate.Line3D:
				seriesChartType = Class454.SeriesChartType.Line;
				break;
			case RibbonInsertTab.ChartTemplate.Pie:
			case RibbonInsertTab.ChartTemplate.Pie3D:
				seriesChartType = Class454.SeriesChartType.Pie;
				break;
			case RibbonInsertTab.ChartTemplate.Doughnut:
				seriesChartType = Class454.SeriesChartType.Doughnut;
				array = new string[1][] { new string[2] { "Disabled", "PieLabelStyle" } };
				break;
			case RibbonInsertTab.ChartTemplate.ClusteredBar:
				seriesChartType = Class454.SeriesChartType.Bar;
				break;
			case RibbonInsertTab.ChartTemplate.ClusteredBar3D:
				seriesChartType = Class454.SeriesChartType.Bar;
				boolean_2 = true;
				break;
			case RibbonInsertTab.ChartTemplate.StackedBar:
			case RibbonInsertTab.ChartTemplate.StackedBar3D:
				seriesChartType = Class454.SeriesChartType.StackedBar;
				break;
			case RibbonInsertTab.ChartTemplate.StackedBar100Percent:
			case RibbonInsertTab.ChartTemplate.StackedBar100Percent3D:
				seriesChartType = Class454.SeriesChartType.StackedBar100;
				string_ = "{0}%";
				break;
			case RibbonInsertTab.ChartTemplate.Area:
			case RibbonInsertTab.ChartTemplate.Area3D:
				seriesChartType = Class454.SeriesChartType.Area;
				break;
			case RibbonInsertTab.ChartTemplate.StackedArea:
			case RibbonInsertTab.ChartTemplate.StackedArea3D:
				seriesChartType = Class454.SeriesChartType.StackedArea;
				break;
			case RibbonInsertTab.ChartTemplate.StackedArea100Percent:
			case RibbonInsertTab.ChartTemplate.StackedArea100Percent3D:
				seriesChartType = Class454.SeriesChartType.StackedArea100;
				string_ = "{0}%";
				break;
			case RibbonInsertTab.ChartTemplate.Scatter:
				seriesChartType = Class454.SeriesChartType.Point;
				markerStyle_ = MarkerStyle.Circle;
				break;
			case RibbonInsertTab.ChartTemplate.ScatterWithSmoothLinesAndMarkers:
				seriesChartType = Class454.SeriesChartType.Spline;
				markerStyle_ = MarkerStyle.Circle;
				break;
			case RibbonInsertTab.ChartTemplate.ScatterWithSmoothLines:
				seriesChartType = Class454.SeriesChartType.Spline;
				break;
			case RibbonInsertTab.ChartTemplate.ScatterWithStraightLinesAndMarkers:
				seriesChartType = Class454.SeriesChartType.Line;
				markerStyle_ = MarkerStyle.Circle;
				break;
			case RibbonInsertTab.ChartTemplate.ScatterWithStraightLines:
				seriesChartType = Class454.SeriesChartType.Line;
				break;
			case RibbonInsertTab.ChartTemplate.Bubble:
			case RibbonInsertTab.ChartTemplate.Bubble3D:
				seriesChartType = Class454.SeriesChartType.Bubble;
				markerStyle_ = MarkerStyle.Circle;
				array = new string[1][] { new string[2] { "30", "BubbleMinSize" } };
				break;
			case RibbonInsertTab.ChartTemplate.HighLowClose:
				seriesChartType = Class454.SeriesChartType.Stock;
				array = new string[1][] { new string[2] { "Close", "ShowOpenClose" } };
				break;
			case RibbonInsertTab.ChartTemplate.OpenHighLowClose:
				seriesChartType = Class454.SeriesChartType.Candlestick;
				array = new string[2][]
				{
					new string[2] { "Green", "PriceUpColor" },
					new string[2] { "Red", "PriceDownColor" }
				};
				break;
			case RibbonInsertTab.ChartTemplate.Radar:
				seriesChartType = Class454.SeriesChartType.Radar;
				array = new string[2][]
				{
					new string[2] { "Line", "RadarDrawingStyle" },
					new string[2] { "Polygon", "AreaDrawingStyle" }
				};
				break;
			case RibbonInsertTab.ChartTemplate.RadarWithMarkers:
				seriesChartType = Class454.SeriesChartType.Radar;
				markerStyle_ = MarkerStyle.Circle;
				array = new string[2][]
				{
					new string[2] { "Marker", "RadarDrawingStyle" },
					new string[2] { "Polygon", "AreaDrawingStyle" }
				};
				break;
			case RibbonInsertTab.ChartTemplate.FilledRadar:
				seriesChartType = Class454.SeriesChartType.Radar;
				array = new string[2][]
				{
					new string[2] { "Area", "RadarDrawingStyle" },
					new string[2] { "Polygon", "AreaDrawingStyle" }
				};
				break;
			}
			if (seriesChartType == Class454.SeriesChartType.UNKNOWN)
			{
				return;
			}
			foreach (Class454 item in (IEnumerable<Class454>)class440_.Class452_0)
			{
				item.SeriesChartType_0 = seriesChartType;
				item.Int32_0 = 2;
				item.Int32_1 = 7;
				item.MarkerStyle_0 = markerStyle_;
				if (array != null)
				{
					PropertyInfo property = item.Object_0.GetType().GetProperty("Item", new Type[1] { typeof(string) });
					string[][] array2 = array;
					foreach (string[] array3 in array2)
					{
						property.SetValue(item.Object_0, array3[0], new object[1] { array3[1] });
					}
				}
			}
			foreach (Class437 item2 in (IEnumerable<Class437>)class440_.Class435_0)
			{
				item2.Class434_0.Boolean_0 = boolean_;
				item2.Class434_0.Boolean_1 = boolean_2;
				item2.Class439_2.Class448_0.String_0 = string_;
				item2.Class439_0.Double_2 = double.NaN;
				item2.Class439_0.Double_1 = double.NaN;
				item2.Class439_0.Double_0 = double.NaN;
				item2.Class439_2.Double_2 = double.NaN;
				item2.Class439_2.Double_1 = double.NaN;
				item2.Class439_2.Double_0 = double.NaN;
			}
			chartFrame_.AddUndoUnit();
			chartFrame_.Refresh();
			Ribbon ribbon = this.class505_0.Control_0.Parent as Ribbon;
			if (ribbon != null)
			{
				foreach (RibbonTab control in ribbon.Controls)
				{
					if (control is RibbonChartLayoutTab)
					{
						control.vmethod_0(chartFrame_);
					}
				}
			}
			this.method_42(this.frameBase_0);
		}

		private void method_48(int int_1)
		{
			Class472.smethod_0(base.m_txTextControl, delegate(Class440 chart)
			{
				foreach (Class437 item in (IEnumerable<Class437>)chart.Class435_0)
				{
					int num = (item.Class434_0.Int32_2 + 180 + int_1) % 360;
					if (num < 0)
					{
						num += 360;
					}
					item.Class434_0.Int32_2 = num - 180;
				}
			});
		}

		private int method_49(Class440 class440_0)
		{
			int result = -1;
			if (class440_0 == null)
			{
				Class517.smethod_34(base.m_txTextControl, out class440_0, out var _);
			}
			if (class440_0 != null && class440_0.Class435_0.Count > 0)
			{
				result = class440_0.Class435_0[0].Class434_0.Int32_1;
			}
			return result;
		}

		private void method_50(int int_1)
		{
			Class472.smethod_0(base.m_txTextControl, delegate(Class440 chart)
			{
				foreach (Class437 item in (IEnumerable<Class437>)chart.Class435_0)
				{
					item.Class434_0.Int32_1 = int_1;
				}
			});
			this.method_45(int_1);
		}

		private int method_51(Class440 class440_0)
		{
			int result = -1;
			if (class440_0 == null)
			{
				Class517.smethod_34(base.m_txTextControl, out class440_0, out var _);
			}
			if (class440_0 != null && class440_0.Class435_0.Count > 0)
			{
				result = class440_0.Class435_0[0].Class434_0.Int32_0;
			}
			return result;
		}

		private void method_52(int int_1)
		{
			Class472.smethod_0(base.m_txTextControl, delegate(Class440 chart)
			{
				foreach (Class437 item in (IEnumerable<Class437>)chart.Class435_0)
				{
					item.Class434_0.Int32_0 = int_1;
				}
			});
			this.method_46(int_1);
		}

		private static bool smethod_0(Class440 class440_0)
		{
			if (class440_0 != null && class440_0.Class435_0.Count > 0)
			{
				return class440_0.Class435_0[0].Class434_0.Boolean_2;
			}
			return false;
		}

		private static Class454.SeriesChartType smethod_1(Class440 class440_0)
		{
			if (class440_0.Class452_0.Count > 0)
			{
				return class440_0.Class452_0[0].SeriesChartType_0;
			}
			return Class454.SeriesChartType.UNKNOWN;
		}

		private void method_53(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			BarcodeFrame barcodeFrame_;
			DrawingFrame drawingFrame_;
			switch (ribbonToggleButton_0.Name)
			{
			case "TXITEM_BarcodeBackColor_Automatic":
			{
				TXBarcodeControl tXBarcodeControl = this.method_26(null, out barcodeFrame_);
				if (tXBarcodeControl != null)
				{
					tXBarcodeControl.BackColor = ((tXBarcodeControl.BackColor.A == byte.MaxValue) ? SystemColors.Window : Color.FromArgb(tXBarcodeControl.BackColor.A, SystemColors.Window));
					barcodeFrame_.AddUndoUnit();
					barcodeFrame_.Refresh();
				}
				break;
			}
			case "TXITEM_BarcodeForeColor_Automatic":
			{
				TXBarcodeControl tXBarcodeControl = this.method_26(null, out barcodeFrame_);
				if (tXBarcodeControl != null)
				{
					tXBarcodeControl.ForeColor = SystemColors.WindowText;
					barcodeFrame_.AddUndoUnit();
					barcodeFrame_.Refresh();
				}
				break;
			}
			case "TXITEM_DrawingBackColor_Automatic":
			{
				TXDrawingControl tXDrawingControl = this.method_84(null, out drawingFrame_);
				if (tXDrawingControl.IsCanvasVisible)
				{
					if (tXDrawingControl.Selection.Shapes.Length != 0 && tXDrawingControl.Visible)
					{
						if (tXDrawingControl.Visible)
						{
							Shape[] shapes = tXDrawingControl.Selection.Shapes;
							foreach (Shape shape in shapes)
							{
								shape.ShapeFill.Color = Color.FromArgb(shape.ShapeFill.Color.A, 91, 155, 213);
							}
						}
					}
					else
					{
						tXDrawingControl.BackColor = Color.Transparent;
					}
				}
				else
				{
					int? num = this.method_88(bool_0: true, tXDrawingControl);
					int alpha = (num.HasValue ? num.Value : 255);
					Shape shape2 = tXDrawingControl.Shapes[0];
					shape2.ShapeFill.Color = Color.FromArgb(alpha, 91, 155, 213);
				}
				if (drawingFrame_ != null && this.drawingFrame_0 == null)
				{
					drawingFrame_.AddUndoUnit();
					drawingFrame_.Refresh();
				}
				break;
			}
			case "TXITEM_DrawingLineColor_Automatic":
			{
				TXDrawingControl tXDrawingControl = this.method_84(null, out drawingFrame_);
				this.method_86(Color.Black, bool_0: false, bool_1: false, tXDrawingControl);
				if (drawingFrame_ != null && this.drawingFrame_0 == null)
				{
					drawingFrame_.AddUndoUnit();
					drawingFrame_.Refresh();
				}
				break;
			}
			case "TXITEM_TextFrameBackColor_Automatic":
			{
				TextFrame item = base.m_txTextControl.TextFrames.GetItem();
				if (item != null)
				{
					item.Color_0 = base.m_txTextControl.BackColor;
				}
				break;
			}
			}
			ribbonToggleButton_0.Checked = true;
		}

		private void method_54(RibbonListView ribbonListView_0, RibbonListView.RibbonListViewItemEventArgs ribbonListViewItemEventArgs_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			int num = 255;
			BarcodeFrame barcodeFrame_;
			DrawingFrame drawingFrame_;
			switch (ribbonListView_0.Name)
			{
			case "TXITEM_BarcodeBackColor_Gallery":
			{
				TXBarcodeControl tXBarcodeControl = this.method_26(null, out barcodeFrame_);
				if (tXBarcodeControl != null)
				{
					num = tXBarcodeControl.BackColor.A;
					tXBarcodeControl.BackColor = Color.FromArgb(num, (Color)ribbonListViewItemEventArgs_0.Item.Tag);
					if (barcodeFrame_ != null)
					{
						barcodeFrame_.AddUndoUnit();
						barcodeFrame_.Refresh();
					}
				}
				break;
			}
			case "TXITEM_BarcodeForeColor_Gallery":
			{
				TXBarcodeControl tXBarcodeControl = this.method_26(null, out barcodeFrame_);
				if (tXBarcodeControl != null)
				{
					tXBarcodeControl.ForeColor = (Color)ribbonListViewItemEventArgs_0.Item.Tag;
					if (barcodeFrame_ != null)
					{
						barcodeFrame_.AddUndoUnit();
						barcodeFrame_.Refresh();
					}
				}
				break;
			}
			case "TXITEM_DrawingBackColor_Gallery":
				this.method_86((Color)ribbonListViewItemEventArgs_0.Item.Tag, bool_0: true, bool_1: true, this.method_84(null, out drawingFrame_));
				if (drawingFrame_ != null && this.drawingFrame_0 == null)
				{
					drawingFrame_.AddUndoUnit();
					drawingFrame_.Refresh();
				}
				break;
			case "TXITEM_DrawingLineColor_Gallery":
				this.method_86((Color)ribbonListViewItemEventArgs_0.Item.Tag, bool_0: false, bool_1: false, this.method_84(null, out drawingFrame_));
				if (drawingFrame_ != null && this.drawingFrame_0 == null)
				{
					drawingFrame_.AddUndoUnit();
					drawingFrame_.Refresh();
				}
				break;
			case "TXITEM_TextFrameBackColor_Gallery":
			{
				TextFrame item = base.m_txTextControl.TextFrames.GetItem();
				if (item != null)
				{
					item.Color_0 = (Color)ribbonListViewItemEventArgs_0.Item.Tag;
				}
				break;
			}
			}
		}

		private void method_55(RibbonButton ribbonButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			switch (ribbonButton_0.Name)
			{
			case "TXITEM_BarcodeForeColor_MoreColors":
			case "TXITEM_BarcodeBackColor_MoreColors":
				base.m_txTextControl.BarcodeLayoutDialog(2);
				break;
			case "TXITEM_DrawingLineColor_MoreColors":
			case "TXITEM_DrawingBackColor_MoreColors":
			{
				DrawingFrame drawingFrame;
				if ((drawingFrame = base.m_txTextControl.Drawings.GetItem()) == null && (drawingFrame = base.m_txTextControl.Drawings.GetActivatedItem()) == null)
				{
					break;
				}
				TXDrawingControl tXDrawingControl = drawingFrame.Drawing as TXDrawingControl;
				if (tXDrawingControl.Visible)
				{
					if (tXDrawingControl.FormatShapesDialog(1) == DialogResult.OK && this.drawingFrame_0 == null)
					{
						drawingFrame.Refresh();
					}
				}
				else
				{
					base.m_txTextControl.DrawingLayoutDialog(2);
				}
				break;
			}
			case "TXITEM_TextFrameBackColor_MoreColors":
				base.m_txTextControl.TextFrameAttributesDialog(2);
				break;
			}
		}

		private void method_56(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			int num = (int)(ribbonToggleButton_0.Tag as object[])[0];
			switch ((string)(ribbonToggleButton_0.Tag as object[])[1])
			{
			case "TXITEM_DrawingLineWidth":
			{
				this.method_89(num, this.method_84(null, out var drawingFrame_));
				if (drawingFrame_ != null && this.drawingFrame_0 == null)
				{
					drawingFrame_.AddUndoUnit();
					drawingFrame_.Refresh();
				}
				break;
			}
			case "TXITEM_TextFrameLineWidth":
			{
				TextFrame item = base.m_txTextControl.TextFrames.GetItem();
				if (item != null)
				{
					item.Int32_8 = num;
				}
				break;
			}
			}
		}

		private void method_57(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			FrameBase frameBase = this.method_120();
			if (frameBase == null)
			{
				return;
			}
			int num = Convert.ToInt32(ribbonToggleButton_0.Tag);
			switch (frameBase.GetType().Name)
			{
			case "BarcodeFrame":
			{
				BarcodeFrame barcodeFrame_;
				TXBarcodeControl tXBarcodeControl = this.method_26(frameBase, out barcodeFrame_);
				if (tXBarcodeControl != null)
				{
					tXBarcodeControl.BackColor = Color.FromArgb(255 - num, tXBarcodeControl.BackColor);
					if (barcodeFrame_ != null)
					{
						barcodeFrame_.AddUndoUnit();
						barcodeFrame_.Refresh();
					}
				}
				break;
			}
			case "DrawingFrame":
			{
				this.method_87(num, bool_0: true, this.method_84(frameBase, out var drawingFrame_));
				if (this.drawingFrame_0 == null)
				{
					drawingFrame_.AddUndoUnit();
					drawingFrame_.Refresh();
				}
				break;
			}
			case "TextFrame":
				(frameBase as TextFrame).Transparency = Convert.ToByte(num);
				break;
			}
			ribbonToggleButton_0.Checked = true;
		}

		private void method_58(FrameEventArgs frameEventArgs_0)
		{
			if (this.frameBase_0 == null)
			{
				this.UpdateRibbonTab();
			}
			else
			{
				this.frameBase_0 = frameEventArgs_0.Frame;
			}
			if (frameEventArgs_0.Frame is BarcodeFrame)
			{
				BarcodeFrame barcodeFrame_;
				Control7 control = this.method_27(frameEventArgs_0.Frame, out barcodeFrame_);
				if (control != null)
				{
					control.PropertyChanged -= method_149;
					control.PropertyChanged += method_149;
				}
			}
		}

		private void method_59(FrameEventArgs frameEventArgs_0)
		{
			if (this.drawingFrame_0 == null)
			{
				this.method_119(frameEventArgs_0.Frame);
				this.UpdateRibbonTab();
			}
			if (frameEventArgs_0.Frame is BarcodeFrame)
			{
				BarcodeFrame barcodeFrame_;
				TXBarcodeControl tXBarcodeControl = this.method_26(frameEventArgs_0.Frame, out barcodeFrame_);
				if (tXBarcodeControl != null)
				{
					tXBarcodeControl.PropertyChanged -= method_149;
				}
			}
		}

		private void method_60(FrameEventArgs frameEventArgs_0)
		{
			this.method_113(frameEventArgs_0.Frame);
		}

		private void method_61(FrameEventArgs frameEventArgs_0)
		{
			this.method_115(frameEventArgs_0.Frame);
		}

		private void method_62(FrameEventArgs frameEventArgs_0)
		{
			this.frameBase_0 = frameEventArgs_0.Frame;
			this.method_116(this.frameBase_0);
		}

		private void method_63(TextFrameEventArgs textFrameEventArgs_0)
		{
			this.method_151(textFrameEventArgs_0.TextFrame);
		}

		private void method_64()
		{
			this.drawingFrame_0 = null;
			this.UpdateRibbonTab();
		}

		private void method_65(DrawingEventArgs drawingEventArgs_0)
		{
			this.method_119(drawingEventArgs_0.DrawingFrame);
			this.UpdateRibbonTab();
		}

		private void method_66(TXDrawingControl txdrawingControl_0, PropertyChangedEventArgs propertyChangedEventArgs_0)
		{
			switch (propertyChangedEventArgs_0.PropertyName)
			{
			case "IsCanvasVisible":
				this.method_117(txdrawingControl_0, this.drawingFrame_0);
				this.method_79(txdrawingControl_0, this.drawingFrame_0);
				this.method_80(txdrawingControl_0, this.drawingFrame_0);
				this.method_81(txdrawingControl_0, this.drawingFrame_0);
				this.method_82(txdrawingControl_0, this.drawingFrame_0);
				break;
			case "BackColor":
				this.method_80(txdrawingControl_0, this.drawingFrame_0);
				this.method_82(txdrawingControl_0, this.drawingFrame_0);
				break;
			case "BorderColor":
				this.method_79(txdrawingControl_0, this.drawingFrame_0);
				break;
			case "BorderWidth":
				this.method_81(txdrawingControl_0, this.drawingFrame_0);
				break;
			}
		}

		private void method_67(TXDrawingControl txdrawingControl_0)
		{
			this.method_79(txdrawingControl_0, this.drawingFrame_0);
			this.method_80(txdrawingControl_0, this.drawingFrame_0);
			this.method_81(txdrawingControl_0, this.drawingFrame_0);
			this.method_82(txdrawingControl_0, this.drawingFrame_0);
		}

		private void method_68(TXDrawingControl txdrawingControl_0)
		{
			this.method_117(txdrawingControl_0, this.drawingFrame_0);
		}

		private void method_69(TXDrawingControl txdrawingControl_0)
		{
			if (this.drawingFrame_0 != null)
			{
				this.method_117(txdrawingControl_0, this.drawingFrame_0);
				this.method_79(txdrawingControl_0, this.drawingFrame_0);
				this.method_80(txdrawingControl_0, this.drawingFrame_0);
				this.method_81(txdrawingControl_0, this.drawingFrame_0);
				this.method_82(txdrawingControl_0, this.drawingFrame_0);
				RibbonMenuButton ribbonMenuButton = this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingRotation.ToString()] as RibbonMenuButton;
				RibbonMenuButton ribbonMenuButton2 = this.class505_0.TXITEM_ObjectArrangeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_SendToBack.ToString()] as RibbonMenuButton;
				RibbonMenuButton ribbonMenuButton3 = this.class505_0.TXITEM_ObjectArrangeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BringToFront.ToString()] as RibbonMenuButton;
				RibbonGroup ribbonGroup = this.class505_0.TXITEM_ObjectSizeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectSizeGroup.ToString()] as RibbonGroup;
				RibbonGroup ribbonGroup2 = this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Drawing_BordersandBackgroundGroup.ToString()] as RibbonGroup;
				if (this.class505_0.method_1(ribbonMenuButton, ribbonMenuButton2, ribbonMenuButton3, ribbonGroup.Enabled, ribbonGroup2))
				{
					DialogBoxLauncher dialogBoxLauncher = ribbonGroup.DialogBoxLauncher;
					bool flag2 = (ribbonGroup2.DialogBoxLauncher.Enabled = txdrawingControl_0.Selection.Shapes.Length > 0);
					bool flag4 = (dialogBoxLauncher.Enabled = flag2);
					bool flag6 = (ribbonMenuButton3.Enabled = flag4);
					bool enabled = (ribbonMenuButton2.Enabled = flag6);
					ribbonMenuButton.Enabled = enabled;
				}
			}
		}

		private void method_70(TXBarcodeControl txbarcodeControl_0, PropertyChangedEventArgs propertyChangedEventArgs_0)
		{
			switch (propertyChangedEventArgs_0.PropertyName)
			{
			case "Alignment":
				this.method_22(txbarcodeControl_0);
				this.method_23(txbarcodeControl_0);
				break;
			case "ForeColor":
				this.method_24(bool_0: false, txbarcodeControl_0);
				break;
			case "BackColor":
				this.method_24(bool_0: true, txbarcodeControl_0);
				this.method_25(txbarcodeControl_0);
				break;
			}
		}

		internal override void UpdateRibbonTab(params object[] args)
		{
			RibbonGroup ribbonGroup = this.class505_0.TXITEM_TextFrame_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrame_BordersandBackgroundGroup.ToString()] as RibbonGroup;
			RibbonGroup ribbonGroup2 = this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Drawing_BordersandBackgroundGroup.ToString()] as RibbonGroup;
			RibbonGroup ribbonGroup3 = this.class505_0.TXITEM_Barcode_ColorsAndAlignmentGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Barcode_ColorsAndAlignmentGroup.ToString()] as RibbonGroup;
			RibbonGroup ribbonGroup4 = this.class505_0.TXITEM_Chart_TypeAndAppearanceGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Chart_TypeAndAppearanceGroup.ToString()] as RibbonGroup;
			if (!this.class505_0.method_0(ribbonGroup) && !this.class505_0.method_0(ribbonGroup2) && !this.class505_0.method_0(ribbonGroup3) && !this.class505_0.method_0(ribbonGroup4))
			{
				return;
			}
			this.frameBase_0 = (this.drawingFrame_0 = null);
			Class498 @class = (this.class505_0.Control_0 as RibbonTab).Controls[0] as Class498;
			bool boolean_ = @class.Boolean_0;
			@class.Boolean_0 = false;
			bool flag = false;
			if (base.m_txTextControl != null)
			{
				this.frameBase_0 = (this.drawingFrame_0 = base.m_txTextControl.Drawings.GetActivatedItem());
				if (this.frameBase_0 == null)
				{
					this.frameBase_0 = base.m_txTextControl.Frames.GetItem();
				}
				if (this.frameBase_0 != null)
				{
					bool flag3 = (ribbonGroup.Visible = this.frameBase_0 is TextFrame);
					bool num = (flag = flag3);
					bool visible = ribbonGroup3.Visible;
					bool flag5 = (ribbonGroup3.Visible = this.frameBase_0 is BarcodeFrame);
					bool num2 = num || visible != flag5;
					flag = num2;
					bool visible2 = ribbonGroup4.Visible;
					bool flag7 = (ribbonGroup4.Visible = this.frameBase_0 is ChartFrame);
					bool num3 = num2 || visible2 != flag7;
					flag = num3;
					bool visible3 = ribbonGroup2.Visible;
					bool flag9 = (ribbonGroup2.Visible = this.frameBase_0 is DrawingFrame);
					flag = num3 || visible3 != flag9;
					if (this.frameBase_0 is DrawingFrame)
					{
						TXDrawingControl tXDrawingControl = (this.frameBase_0 as DrawingFrame).Drawing as TXDrawingControl;
						bool? flag10 = Class517.smethod_31("PropertyChangedEvent", tXDrawingControl, this);
						if (flag10.HasValue && !flag10.Value)
						{
							tXDrawingControl.PropertyChanged += method_145;
							tXDrawingControl.ShapeFormatChanged += method_146;
							tXDrawingControl.ShapeSelected += method_148;
							tXDrawingControl.ShapeDeselected += method_148;
							tXDrawingControl.ShapeSized += method_147;
						}
					}
				}
				else
				{
					bool visible4 = ribbonGroup.Visible;
					ribbonGroup.Visible = false;
					bool num4 = (flag = visible4);
					bool visible5 = ribbonGroup2.Visible;
					ribbonGroup2.Visible = false;
					bool num5 = num4 || visible5;
					flag = num5;
					bool visible6 = ribbonGroup3.Visible;
					ribbonGroup3.Visible = false;
					bool num6 = num5 || visible6;
					flag = num6;
					bool visible7 = ribbonGroup4.Visible;
					ribbonGroup4.Visible = false;
					flag = num6 || visible7;
				}
			}
			else
			{
				bool visible8 = ribbonGroup.Visible;
				ribbonGroup.Visible = false;
				bool num7 = (flag = visible8);
				bool visible9 = ribbonGroup2.Visible;
				ribbonGroup2.Visible = false;
				bool num8 = num7 || visible9;
				flag = num8;
				bool visible10 = ribbonGroup3.Visible;
				ribbonGroup3.Visible = false;
				bool num9 = num8 || visible10;
				flag = num9;
				bool visible11 = ribbonGroup4.Visible;
				ribbonGroup4.Visible = false;
				flag = num9 || visible11;
			}
			@class.Boolean_0 = boolean_;
			if (@class.Boolean_0 && flag)
			{
				@class.method_3(this.class505_0.Control_0.Width);
			}
			this.method_112(this.frameBase_0);
			this.method_116(this.frameBase_0);
			this.method_118(this.frameBase_0);
			this.method_151(this.frameBase_0);
			this.method_78(this.frameBase_0);
			this.method_21(this.frameBase_0);
			this.method_42(this.frameBase_0);
			if (base.m_txTextControl != null && !base.m_txTextControl.CanEdit && this.frameBase_0 != null)
			{
				this.class505_0.method_18(bool_0: false);
			}
		}

		private DialogResult method_71(FrameBase frameBase_1, int int_1)
		{
			return frameBase_1.GetType().Name switch
			{
				"ChartFrame" => base.m_txTextControl.ChartLayoutDialog(int_1), 
				"BarcodeFrame" => base.m_txTextControl.BarcodeLayoutDialog(int_1), 
				"DrawingFrame" => base.m_txTextControl.DrawingLayoutDialog(int_1), 
				"TextFrame" => base.m_txTextControl.TextFrameAttributesDialog(int_1), 
				"Image" => base.m_txTextControl.ImageAttributesDialog(int_1), 
				_ => DialogResult.None, 
			};
		}

		protected override Color? GetCurrentColor(string colorButtonName)
		{
			Color? result = null;
			if (base.m_txTextControl != null)
			{
				BarcodeFrame barcodeFrame_;
				DrawingFrame drawingFrame_;
				switch (colorButtonName)
				{
				case "TXITEM_BarcodeBackColor":
				{
					TXBarcodeControl tXBarcodeControl = this.method_26(null, out barcodeFrame_);
					if (tXBarcodeControl != null)
					{
						result = tXBarcodeControl.BackColor;
					}
					break;
				}
				case "TXITEM_BarcodeForeColor":
				{
					TXBarcodeControl tXBarcodeControl = this.method_26(null, out barcodeFrame_);
					if (tXBarcodeControl != null)
					{
						result = tXBarcodeControl.ForeColor;
					}
					break;
				}
				case "TXITEM_DrawingBackColor":
				{
					result = this.method_85(bool_0: true, this.method_84(null, out drawingFrame_));
					TXDrawingControl tXDrawingControl = this.method_84(null, out drawingFrame_);
					_ = this.class505_0.Control_0;
					if (tXDrawingControl != null)
					{
						RibbonButton ribbonButton = this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingBackColor_Automatic.ToString()] as RibbonButton;
						string text = ((!tXDrawingControl.IsCanvasVisible || (tXDrawingControl.Selection.Shapes.Length != 0 && tXDrawingControl.Visible)) ? "_Shape" : "_Canvas");
						ribbonButton.SmallIcon = Class517.smethod_53(RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingBackColor_Automatic.ToString() + text, ImageProvider.ImageKind.Small_16x16, base.m_pntDPI);
					}
					break;
				}
				case "TXITEM_DrawingLineColor":
					result = this.method_85(bool_0: false, this.method_84(null, out drawingFrame_));
					break;
				case "TXITEM_TextFrameBackColor":
				{
					TextFrame item = base.m_txTextControl.TextFrames.GetItem();
					if (item != null)
					{
						result = item.Color_0;
					}
					break;
				}
				}
			}
			return result;
		}

		private void method_72()
		{
			if (base.m_txTextControl != null)
			{
				this.method_94();
			}
		}

		private void method_73()
		{
			if (base.m_txTextControl != null)
			{
				this.method_91(90, this.method_84(null, out var drawingFrame_));
				if (drawingFrame_ != null && this.drawingFrame_0 == null)
				{
					drawingFrame_.AddUndoUnit();
					drawingFrame_.Refresh();
				}
			}
		}

		private void method_74()
		{
			if (base.m_txTextControl != null)
			{
				this.method_91(-90, this.method_84(null, out var drawingFrame_));
				if (drawingFrame_ != null && this.drawingFrame_0 == null)
				{
					drawingFrame_.AddUndoUnit();
					drawingFrame_.Refresh();
				}
			}
		}

		private void method_75()
		{
			if (base.m_txTextControl != null)
			{
				this.method_92(bool_0: false, this.method_84(null, out var drawingFrame_));
				if (drawingFrame_ != null && this.drawingFrame_0 == null)
				{
					drawingFrame_.AddUndoUnit();
					drawingFrame_.Refresh();
				}
			}
		}

		private void method_76()
		{
			if (base.m_txTextControl != null)
			{
				this.method_92(bool_0: true, this.method_84(null, out var drawingFrame_));
				if (drawingFrame_ != null && this.drawingFrame_0 == null)
				{
					drawingFrame_.AddUndoUnit();
					drawingFrame_.Refresh();
				}
			}
		}

		private void method_77()
		{
			if (base.m_txTextControl != null)
			{
				this.method_94();
			}
		}

		private void method_78(FrameBase frameBase_1)
		{
			RibbonGroup ribbonGroup = this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Drawing_BordersandBackgroundGroup.ToString()] as RibbonGroup;
			if (this.class505_0.method_0(ribbonGroup))
			{
				DrawingFrame drawingFrame = frameBase_1 as DrawingFrame;
				TXDrawingControl txdrawingControl_ = ((drawingFrame != null) ? (drawingFrame.Drawing as TXDrawingControl) : null);
				this.method_79(txdrawingControl_, drawingFrame);
				this.method_80(txdrawingControl_, drawingFrame);
				this.method_81(txdrawingControl_, drawingFrame);
				this.method_82(txdrawingControl_, drawingFrame);
				this.method_83(txdrawingControl_);
				ribbonGroup.Enabled = drawingFrame != null || base.m_txTextControl == null;
			}
		}

		private void method_79(TXDrawingControl txdrawingControl_0, DrawingFrame drawingFrame_1)
		{
			RibbonMenuButton ribbonMenuButton = this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingLineColor.ToString()] as RibbonMenuButton;
			RibbonToggleButton ribbonToggleButton = this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingLineColor_Automatic.ToString()] as RibbonToggleButton;
			if (this.class505_0.method_2(ribbonMenuButton) || this.class505_0.method_2(ribbonToggleButton))
			{
				DrawingFrame drawingFrame = ((base.m_txTextControl == null || drawingFrame_1 != null) ? drawingFrame_1 : base.m_txTextControl.Drawings.GetItem());
				Color? nullable_ = ((drawingFrame == null || drawingFrame.Drawing != txdrawingControl_0) ? null : this.method_85(bool_0: false, txdrawingControl_0));
				Class517.smethod_59(ribbonMenuButton, nullable_, this.class505_0.Control_0 is ObjectMiniToolbar, base.m_pntDPI);
				bool @checked = false;
				if (nullable_.HasValue)
				{
					@checked = ((!txdrawingControl_0.IsCanvasVisible || (txdrawingControl_0.Selection.Shapes.Length != 0 && txdrawingControl_0.Visible)) ? (nullable_.Value.Name == Color.Black.Name) : (nullable_.Value.Name == SystemColors.WindowText.Name));
				}
				ribbonToggleButton.Checked = @checked;
			}
			RibbonButton ribbonButton = this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingLineColor_MoreColors.ToString()] as RibbonButton;
			if (this.class505_0.method_2(ribbonButton))
			{
				ribbonButton.Enabled = txdrawingControl_0 == null || !txdrawingControl_0.Visible || txdrawingControl_0.Selection.Shapes.Length != 0;
			}
		}

		private void method_80(TXDrawingControl txdrawingControl_0, DrawingFrame drawingFrame_1)
		{
			RibbonMenuButton ribbonMenuButton = this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingBackColor.ToString()] as RibbonMenuButton;
			RibbonToggleButton ribbonToggleButton = this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingBackColor_Automatic.ToString()] as RibbonToggleButton;
			if (this.class505_0.method_2(ribbonMenuButton) || this.class505_0.method_2(ribbonToggleButton))
			{
				DrawingFrame drawingFrame = ((base.m_txTextControl == null || drawingFrame_1 != null) ? drawingFrame_1 : base.m_txTextControl.Drawings.GetItem());
				Color? nullable_ = ((drawingFrame == null || drawingFrame.Drawing != txdrawingControl_0) ? null : this.method_85(bool_0: true, txdrawingControl_0));
				Class517.smethod_59(ribbonMenuButton, nullable_, this.class505_0.Control_0 is ObjectMiniToolbar, base.m_pntDPI);
				bool @checked = false;
				if (nullable_.HasValue)
				{
					@checked = ((!txdrawingControl_0.IsCanvasVisible || (txdrawingControl_0.Selection.Shapes.Length != 0 && txdrawingControl_0.Visible)) ? (nullable_.Value.ToArgb() == Color.FromArgb(91, 155, 213).ToArgb()) : (nullable_.Value.Name == Color.Transparent.Name));
				}
				ribbonToggleButton.Checked = @checked;
			}
			RibbonButton ribbonButton = this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingBackColor_MoreColors.ToString()] as RibbonButton;
			if (this.class505_0.method_2(ribbonMenuButton))
			{
				ribbonButton.Enabled = txdrawingControl_0 == null || !txdrawingControl_0.Visible || txdrawingControl_0.Selection.Shapes.Length != 0;
			}
		}

		private void method_81(TXDrawingControl txdrawingControl_0, DrawingFrame drawingFrame_1)
		{
			RibbonMenuButton ribbonMenuButton = this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingLineWidth.ToString()] as RibbonMenuButton;
			if (!this.class505_0.method_3(ribbonMenuButton))
			{
				return;
			}
			DrawingFrame drawingFrame = ((base.m_txTextControl == null || drawingFrame_1 != null) ? drawingFrame_1 : base.m_txTextControl.Drawings.GetItem());
			int? num = ((drawingFrame == null || drawingFrame.Drawing != txdrawingControl_0) ? new int?(-1) : this.method_90(txdrawingControl_0));
			foreach (IRibbonItem dropDownItem in ribbonMenuButton.DropDownItems)
			{
				if (dropDownItem.IsDefaultRibbonTabItem)
				{
					RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
					if (ribbonToggleButton != null)
					{
						ribbonToggleButton.Checked = (ribbonToggleButton.Tag as object[])[0] as int? == num;
					}
				}
			}
		}

		private void method_82(TXDrawingControl txdrawingControl_0, DrawingFrame drawingFrame_1)
		{
			RibbonMenuButton ribbonMenuButton = this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingTransparency.ToString()] as RibbonMenuButton;
			if (!this.class505_0.method_3(ribbonMenuButton))
			{
				return;
			}
			DrawingFrame drawingFrame = ((base.m_txTextControl == null || drawingFrame_1 != null) ? drawingFrame_1 : base.m_txTextControl.Drawings.GetItem());
			int? num = ((drawingFrame == null || drawingFrame.Drawing != txdrawingControl_0) ? new int?(-1) : this.method_88(bool_0: true, txdrawingControl_0));
			foreach (IRibbonItem dropDownItem in ribbonMenuButton.DropDownItems)
			{
				if (dropDownItem.IsDefaultRibbonTabItem)
				{
					RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
					if (ribbonToggleButton != null)
					{
						ribbonToggleButton.Checked = Convert.ToInt32(ribbonToggleButton.Tag) == 255 - num;
					}
				}
			}
		}

		private void method_83(TXDrawingControl txdrawingControl_0)
		{
			RibbonMenuButton ribbonMenuButton = this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingRotation.ToString()] as RibbonMenuButton;
			if (this.class505_0.method_3(ribbonMenuButton))
			{
				ribbonMenuButton.Enabled = txdrawingControl_0 == null || !txdrawingControl_0.IsCanvasVisible;
			}
		}

		private TXDrawingControl method_84(FrameBase frameBase_1, out DrawingFrame drawingFrame_1)
		{
			if ((drawingFrame_1 = frameBase_1 as DrawingFrame) == null && (drawingFrame_1 = base.m_txTextControl.Drawings.GetItem()) == null)
			{
				RibbonFrameLayoutTab ribbonFrameLayoutTab = this.class505_0.Control_0 as RibbonFrameLayoutTab;
				if (ribbonFrameLayoutTab != null)
				{
					drawingFrame_1 = this.drawingFrame_0;
				}
			}
			if (drawingFrame_1 != null)
			{
				return drawingFrame_1.Drawing as TXDrawingControl;
			}
			return null;
		}

		private Color? method_85(bool bool_0, TXDrawingControl txdrawingControl_0)
		{
			if (txdrawingControl_0 != null)
			{
				if (txdrawingControl_0.IsCanvasVisible)
				{
					if (txdrawingControl_0.Selection.Shapes.Length != 0 && txdrawingControl_0.Visible)
					{
						if (txdrawingControl_0.Selection.IsCommonValueSelected(bool_0 ? Drawing.Selection.Attribute.FillColor : Drawing.Selection.Attribute.LineColor))
						{
							Color color = (bool_0 ? txdrawingControl_0.Selection.Shapes[0].ShapeFill.Color : txdrawingControl_0.Selection.Shapes[0].ShapeOutline.Color);
							return color.IsNamedColor ? color : Color.FromArgb(255, color);
						}
						int num = 0;
						while (true)
						{
							if (num < txdrawingControl_0.Selection.Shapes.Length - 1)
							{
								Color color2 = (bool_0 ? txdrawingControl_0.Selection.Shapes[num].ShapeFill.Color : txdrawingControl_0.Selection.Shapes[num].ShapeOutline.Color);
								Color color3 = (bool_0 ? txdrawingControl_0.Selection.Shapes[num + 1].ShapeFill.Color : txdrawingControl_0.Selection.Shapes[num + 1].ShapeOutline.Color);
								if (color2.R != color3.R || color2.G != color3.G || color2.B != color2.B)
								{
									break;
								}
								num++;
								continue;
							}
							Color color4 = (bool_0 ? txdrawingControl_0.Selection.Shapes[0].ShapeFill.Color : txdrawingControl_0.Selection.Shapes[0].ShapeOutline.Color);
							return color4.IsNamedColor ? color4 : Color.FromArgb(255, color4);
						}
						return null;
					}
					Color color5 = (bool_0 ? txdrawingControl_0.BackColor : txdrawingControl_0.BorderColor);
					return color5.IsNamedColor ? color5 : Color.FromArgb(255, color5);
				}
				Shape shape = txdrawingControl_0.Shapes[0];
				Color color6 = (bool_0 ? shape.ShapeFill.Color : shape.ShapeOutline.Color);
				return color6.IsNamedColor ? color6 : Color.FromArgb(255, color6);
			}
			return null;
		}

		private void method_86(Color color_0, bool bool_0, bool bool_1, TXDrawingControl txdrawingControl_0)
		{
			if (txdrawingControl_0 == null)
			{
				return;
			}
			if (txdrawingControl_0.IsCanvasVisible)
			{
				if (txdrawingControl_0.Selection.Shapes.Length != 0 && txdrawingControl_0.Visible)
				{
					if (bool_0)
					{
						Shape[] shapes = txdrawingControl_0.Selection.Shapes;
						foreach (Shape shape in shapes)
						{
							shape.ShapeFill.Color = ((!bool_1 || shape.ShapeFill.Color.A == byte.MaxValue) ? color_0 : Color.FromArgb(shape.ShapeFill.Color.A, color_0));
						}
					}
					else
					{
						Shape[] shapes2 = txdrawingControl_0.Selection.Shapes;
						foreach (Shape shape2 in shapes2)
						{
							shape2.ShapeOutline.Color = ((!bool_1 || shape2.ShapeOutline.Color.A == byte.MaxValue) ? color_0 : Color.FromArgb(shape2.ShapeOutline.Color.A, color_0));
						}
					}
				}
				else if (bool_0)
				{
					txdrawingControl_0.BackColor = ((!bool_1 || txdrawingControl_0.BackColor.A == byte.MaxValue) ? color_0 : Color.FromArgb(txdrawingControl_0.BackColor.A, color_0));
				}
				else
				{
					txdrawingControl_0.BorderColor = ((!bool_1 || txdrawingControl_0.BorderColor.A == byte.MaxValue) ? color_0 : Color.FromArgb(txdrawingControl_0.BorderColor.A, color_0));
				}
			}
			else
			{
				Shape shape3 = txdrawingControl_0.Shapes[0];
				if (bool_0)
				{
					shape3.ShapeFill.Color = ((!bool_1 || shape3.ShapeFill.Color.A == byte.MaxValue) ? color_0 : Color.FromArgb(shape3.ShapeFill.Color.A, color_0));
				}
				else
				{
					shape3.ShapeOutline.Color = ((!bool_1 || shape3.ShapeOutline.Color.A == byte.MaxValue) ? color_0 : Color.FromArgb(shape3.ShapeOutline.Color.A, color_0));
				}
			}
		}

		private void method_87(int int_1, bool bool_0, TXDrawingControl txdrawingControl_0)
		{
			if (txdrawingControl_0 == null)
			{
				return;
			}
			if (txdrawingControl_0.IsCanvasVisible)
			{
				if (txdrawingControl_0.Selection.Shapes.Length != 0 && txdrawingControl_0.Visible)
				{
					if (bool_0)
					{
						Shape[] shapes = txdrawingControl_0.Selection.Shapes;
						foreach (Shape shape in shapes)
						{
							shape.ShapeFill.Color = Color.FromArgb(255 - int_1, shape.ShapeFill.Color);
						}
					}
					else
					{
						Shape[] shapes2 = txdrawingControl_0.Selection.Shapes;
						foreach (Shape shape2 in shapes2)
						{
							shape2.ShapeOutline.Color = Color.FromArgb(255 - int_1, shape2.ShapeOutline.Color);
						}
					}
				}
				else if (bool_0)
				{
					txdrawingControl_0.BackColor = Color.FromArgb(255 - int_1, txdrawingControl_0.BackColor);
				}
				else
				{
					txdrawingControl_0.BorderColor = Color.FromArgb(255 - int_1, txdrawingControl_0.BorderColor);
				}
			}
			else
			{
				Shape shape3 = txdrawingControl_0.Shapes[0];
				if (bool_0)
				{
					shape3.ShapeFill.Color = Color.FromArgb(255 - int_1, shape3.ShapeFill.Color);
				}
				else
				{
					shape3.ShapeOutline.Color = Color.FromArgb(255 - int_1, shape3.ShapeOutline.Color);
				}
			}
		}

		private int? method_88(bool bool_0, TXDrawingControl txdrawingControl_0)
		{
			if (txdrawingControl_0 != null)
			{
				if (txdrawingControl_0.IsCanvasVisible)
				{
					if (txdrawingControl_0.Selection.Shapes.Length != 0 && txdrawingControl_0.Visible)
					{
						int num = 0;
						while (true)
						{
							if (num < txdrawingControl_0.Selection.Shapes.Length - 1)
							{
								Color color = (bool_0 ? txdrawingControl_0.Selection.Shapes[num].ShapeFill.Color : txdrawingControl_0.Selection.Shapes[num].ShapeOutline.Color);
								Color color2 = (bool_0 ? txdrawingControl_0.Selection.Shapes[num + 1].ShapeFill.Color : txdrawingControl_0.Selection.Shapes[num + 1].ShapeOutline.Color);
								if (color.A != color2.A)
								{
									break;
								}
								num++;
								continue;
							}
							return bool_0 ? txdrawingControl_0.Selection.Shapes[0].ShapeFill.Color.A : txdrawingControl_0.Selection.Shapes[0].ShapeOutline.Color.A;
						}
						return null;
					}
					return bool_0 ? txdrawingControl_0.BackColor.A : txdrawingControl_0.BorderColor.A;
				}
				return bool_0 ? txdrawingControl_0.Shapes[0].ShapeFill.Color.A : txdrawingControl_0.Shapes[0].ShapeOutline.Color.A;
			}
			return null;
		}

		private void method_89(int int_1, TXDrawingControl txdrawingControl_0)
		{
			if (txdrawingControl_0 == null)
			{
				return;
			}
			if (txdrawingControl_0.IsCanvasVisible)
			{
				if (txdrawingControl_0.Selection.Shapes.Length != 0 && txdrawingControl_0.Visible)
				{
					Shape[] shapes = txdrawingControl_0.Selection.Shapes;
					foreach (Shape shape in shapes)
					{
						shape.ShapeOutline.Width = int_1;
					}
				}
				else
				{
					txdrawingControl_0.BorderWidth = int_1;
				}
			}
			else
			{
				txdrawingControl_0.Shapes[0].ShapeOutline.Width = int_1;
			}
		}

		private int? method_90(TXDrawingControl txdrawingControl_0)
		{
			if (txdrawingControl_0 != null)
			{
				if (txdrawingControl_0.IsCanvasVisible)
				{
					if (txdrawingControl_0.Selection.Shapes.Length != 0 && txdrawingControl_0.Visible)
					{
						if (txdrawingControl_0.Selection.IsCommonValueSelected(Drawing.Selection.Attribute.LineWidth))
						{
							return txdrawingControl_0.Selection.Shapes[0].ShapeOutline.Width;
						}
						return null;
					}
					return txdrawingControl_0.BorderWidth;
				}
				return txdrawingControl_0.Shapes[0].ShapeOutline.Width;
			}
			return null;
		}

		private void method_91(int int_1, TXDrawingControl txdrawingControl_0)
		{
			if (txdrawingControl_0 == null || (txdrawingControl_0.IsCanvasVisible && (!txdrawingControl_0.Visible || txdrawingControl_0.Selection.Shapes.Length <= 0)))
			{
				return;
			}
			if (txdrawingControl_0.Visible && txdrawingControl_0.Selection.Shapes.Length > 0)
			{
				Shape[] shapes = txdrawingControl_0.Selection.Shapes;
				foreach (Shape shape in shapes)
				{
					shape.Angle = Class517.smethod_30(shape.Angle + int_1);
				}
			}
			else
			{
				txdrawingControl_0.Shapes[0].Angle = Class517.smethod_30(txdrawingControl_0.Shapes[0].Angle + int_1);
			}
		}

		private void method_92(bool bool_0, TXDrawingControl txdrawingControl_0)
		{
			if (txdrawingControl_0 == null || (txdrawingControl_0.IsCanvasVisible && (!txdrawingControl_0.Visible || txdrawingControl_0.Selection.Shapes.Length <= 0)))
			{
				return;
			}
			if (txdrawingControl_0.Visible && txdrawingControl_0.Selection.Shapes.Length > 0)
			{
				Shape[] shapes = txdrawingControl_0.Selection.Shapes;
				foreach (Shape shape_ in shapes)
				{
					this.method_93(bool_0, shape_);
				}
			}
			else
			{
				this.method_93(bool_0, txdrawingControl_0.Shapes[0]);
			}
		}

		private void method_93(bool bool_0, Shape shape_0)
		{
			bool flag = (shape_0.Flip & Flip.Horizontal) == Flip.Horizontal;
			bool flag2 = (shape_0.Flip & Flip.Vertical) == Flip.Vertical;
			Flip flip;
			Flip flip2;
			if (bool_0)
			{
				flip = ((!flag) ? Flip.Horizontal : Flip.None);
				flip2 = (flag2 ? Flip.Vertical : Flip.None);
			}
			else
			{
				flip = (flag ? Flip.Horizontal : Flip.None);
				flip2 = ((!flag2) ? Flip.Vertical : Flip.None);
			}
			shape_0.Flip = flip | flip2;
		}

		private void method_94()
		{
			DrawingFrame item;
			if ((item = base.m_txTextControl.Drawings.GetItem()) == null)
			{
				RibbonFrameLayoutTab ribbonFrameLayoutTab = this.class505_0.Control_0 as RibbonFrameLayoutTab;
				if (ribbonFrameLayoutTab != null)
				{
					item = this.drawingFrame_0;
				}
			}
			if (item != null)
			{
				TXDrawingControl tXDrawingControl = item.Drawing as TXDrawingControl;
				if (!tXDrawingControl.Visible)
				{
					base.m_txTextControl.DrawingLayoutDialog(2);
				}
				else if (tXDrawingControl.FormatShapesDialog(1) == DialogResult.OK)
				{
					item.Refresh();
				}
			}
		}

		private void method_95()
		{
			if (base.m_txTextControl != null)
			{
				FrameBase item = base.m_txTextControl.Frames.GetItem();
				if (item != null)
				{
					this.method_71(item, 0);
				}
			}
		}

		private void method_96(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			FrameBase item = base.m_txTextControl.Frames.GetItem();
			if (item != null)
			{
				FrameInsertionMode insertionMode = item.InsertionMode;
				HeaderFooter headerFooter = base.m_txTextControl.TextParts.GetItem() as HeaderFooter;
				bool flag = (insertionMode & FrameInsertionMode.FixedOnPage) != 0 || ((insertionMode & FrameInsertionMode.AsCharacter) != 0 && headerFooter != null);
				switch (ribbonToggleButton_0.Name)
				{
				case "TXITEM_WrapText_InFrontOfText":
					item.InsertionMode = FrameInsertionMode.AboveTheText | (flag ? FrameInsertionMode.FixedOnPage : FrameInsertionMode.MoveWithText);
					break;
				case "TXITEM_WrapText_BehindText":
					item.InsertionMode = FrameInsertionMode.BelowTheText | (flag ? FrameInsertionMode.FixedOnPage : FrameInsertionMode.MoveWithText);
					break;
				case "TXITEM_WrapText_Square":
					item.InsertionMode = FrameInsertionMode.DisplaceText | (flag ? FrameInsertionMode.FixedOnPage : FrameInsertionMode.MoveWithText);
					break;
				case "TXITEM_WrapText_TopAndBottom":
					item.InsertionMode = FrameInsertionMode.DisplaceCompleteLines | (flag ? FrameInsertionMode.FixedOnPage : FrameInsertionMode.MoveWithText);
					break;
				case "TXITEM_WrapText_InLineWithText":
					item.InsertionMode = FrameInsertionMode.AsCharacter;
					break;
				}
			}
		}

		private void method_97()
		{
			FrameBase item;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Frames.GetItem()) != null)
			{
				this.method_71(item, 0);
			}
		}

		private void method_98()
		{
			this.method_121(ZOrder.Top);
		}

		private void method_99()
		{
			this.method_121(ZOrder.const_2);
		}

		private void method_100()
		{
			this.method_121(ZOrder.TopMost);
		}

		private void method_101()
		{
			this.method_121(ZOrder.Bottom);
		}

		private void method_102()
		{
			this.method_121(ZOrder.Down);
		}

		private void method_103()
		{
			this.method_121(ZOrder.BottomMost);
		}

		private void method_104(RibbonToggleButton ribbonToggleButton_0)
		{
			FrameBase item;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Frames.GetItem()) != null)
			{
				switch (ribbonToggleButton_0.Name)
				{
				case "TXITEM_Position_Right":
					item.Alignment = HorizontalAlignment.Right;
					break;
				case "TXITEM_Position_Center":
					item.Alignment = HorizontalAlignment.Center;
					break;
				case "TXITEM_Position_Left":
					item.Alignment = HorizontalAlignment.Left;
					break;
				}
			}
		}

		private void method_105()
		{
			FrameBase item;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Frames.GetItem()) != null)
			{
				this.method_71(item, 0);
			}
		}

		private void method_106()
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			FrameBase frameBase = this.method_120();
			if (frameBase == null)
			{
				return;
			}
			if (frameBase.GetType() == typeof(DrawingFrame))
			{
				TXDrawingControl tXDrawingControl = (frameBase as DrawingFrame).Drawing as TXDrawingControl;
				if (tXDrawingControl.Visible)
				{
					if (tXDrawingControl.FormatShapesDialog() == DialogResult.OK)
					{
						(frameBase as DrawingFrame).Refresh();
					}
					return;
				}
			}
			this.method_71(frameBase, 1);
		}

		private void method_107(RibbonTextBox ribbonTextBox_1)
		{
			this.ribbonTextBox_0 = ribbonTextBox_1;
			if (base.m_txTextControl != null)
			{
				FrameBase frameBase = this.method_120();
				if (frameBase != null)
				{
					bool bool_ = this.ribbonTextBox_0.Name == RibbonFrameLayoutTab.RibbonItem.TXITEM_ObjectHeight.ToString();
					double double_ = ((this.ribbonTextBox_0.Text == null || this.ribbonTextBox_0.Text.Length <= 0) ? (-1.0) : ((double)TwipsConverter.DotNet2Tw(Convert.ToDouble(this.ribbonTextBox_0.Text), this.measuringUnit_0) * this.double_0));
					this.method_123(frameBase, double_, this.ribbonTextBox_0, bool_);
					this.ribbonTextBox_0 = null;
				}
			}
		}

		private void method_108(RibbonTextBox ribbonTextBox_1)
		{
			this.method_122(ribbonTextBox_1, this.double_1);
		}

		private void method_109(RibbonTextBox ribbonTextBox_1)
		{
			this.method_122(ribbonTextBox_1, 0.0 - this.double_1);
		}

		private void method_110(RibbonTextBox ribbonTextBox_1)
		{
			this.ribbonTextBox_0 = ribbonTextBox_1;
			if (base.m_txTextControl == null)
			{
				return;
			}
			FrameBase frameBase = this.method_120();
			if (this.ribbonTextBox_0 != null && frameBase != null)
			{
				if (this.ribbonTextBox_0.Text != null && this.ribbonTextBox_0.Text.Length > 0)
				{
					frameBase.Int32_0 = int.Parse(this.ribbonTextBox_0.Text);
				}
				else
				{
					this.ribbonTextBox_0.Text = frameBase.Int32_0.ToString();
				}
				this.ribbonTextBox_0 = null;
			}
		}

		private void method_111(RibbonTextBox ribbonTextBox_1)
		{
			this.ribbonTextBox_0 = ribbonTextBox_1;
			if (base.m_txTextControl != null)
			{
				FrameBase frameBase = this.method_120();
				if (this.ribbonTextBox_0 != null && frameBase != null)
				{
					frameBase.Name = this.ribbonTextBox_0.Text;
					this.ribbonTextBox_0 = null;
				}
			}
		}

		private void method_112(FrameBase frameBase_1)
		{
			RibbonGroup ribbonGroup = this.class505_0.TXITEM_ObjectArrangeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectArrangeGroup.ToString()] as RibbonGroup;
			if (this.class505_0.method_0(ribbonGroup))
			{
				ribbonGroup.DialogBoxLauncher.Enabled = this.drawingFrame_0 == null || !(this.drawingFrame_0.Drawing as TXDrawingControl).Visible;
				ribbonGroup.Enabled = frameBase_1 != null || base.m_txTextControl == null;
				this.method_113(frameBase_1);
				this.method_114();
				this.method_115(frameBase_1);
			}
		}

		private void method_113(FrameBase frameBase_1)
		{
			RibbonMenuButton ribbonMenuButton = this.class505_0.TXITEM_ObjectArrangeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_WrapText.ToString()] as RibbonMenuButton;
			if (frameBase_1 != null)
			{
				ribbonMenuButton.Enabled = this.drawingFrame_0 == null;
				bool flag = (frameBase_1.InsertionMode & FrameInsertionMode.AsCharacter) == FrameInsertionMode.AsCharacter;
				RibbonMenuButton obj = this.class505_0.TXITEM_ObjectArrangeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BringToFront.ToString()] as RibbonMenuButton;
				RibbonMenuButton obj2 = this.class505_0.TXITEM_ObjectArrangeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_SendToBack.ToString()] as RibbonMenuButton;
				bool flag3 = ((this.class505_0.TXITEM_ObjectArrangeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Position.ToString()] as RibbonMenuButton).Enabled = !flag);
				bool enabled = (obj2.Enabled = flag3);
				obj.Enabled = enabled;
				foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
				{
					RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
					if (ribbonToggleButton != null && ((IRibbonItem)ribbonToggleButton).IsDefaultRibbonTabItem)
					{
						switch (ribbonToggleButton.Name)
						{
						case "TXITEM_WrapText_InFrontOfText":
							ribbonToggleButton.Checked = (frameBase_1.InsertionMode & FrameInsertionMode.AboveTheText) == FrameInsertionMode.AboveTheText;
							break;
						case "TXITEM_WrapText_BehindText":
							ribbonToggleButton.Checked = (frameBase_1.InsertionMode & FrameInsertionMode.BelowTheText) == FrameInsertionMode.BelowTheText;
							break;
						case "TXITEM_WrapText_Square":
							ribbonToggleButton.Checked = (frameBase_1.InsertionMode & FrameInsertionMode.DisplaceText) == FrameInsertionMode.DisplaceText;
							break;
						case "TXITEM_WrapText_TopAndBottom":
							ribbonToggleButton.Checked = (frameBase_1.InsertionMode & FrameInsertionMode.DisplaceCompleteLines) == FrameInsertionMode.DisplaceCompleteLines;
							break;
						case "TXITEM_WrapText_InLineWithText":
							ribbonToggleButton.Checked = flag;
							break;
						}
					}
				}
				return;
			}
			foreach (Control dropDownItem2 in ribbonMenuButton.DropDownItems)
			{
				RibbonToggleButton ribbonToggleButton2 = dropDownItem2 as RibbonToggleButton;
				if (ribbonToggleButton2 != null && ((IRibbonItem)ribbonToggleButton2).IsDefaultRibbonTabItem)
				{
					switch (ribbonToggleButton2.Name)
					{
					case "TXITEM_WrapText_InLineWithText":
					case "TXITEM_WrapText_TopAndBottom":
					case "TXITEM_WrapText_Square":
					case "TXITEM_WrapText_BehindText":
					case "TXITEM_WrapText_InFrontOfText":
						ribbonToggleButton2.Checked = false;
						ribbonToggleButton2.Enabled = true;
						break;
					}
				}
			}
		}

		private void method_114()
		{
			RibbonButton ribbonButton = this.class505_0.TXITEM_ObjectArrangeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BringToFront_InFrontOfText.ToString()] as RibbonButton;
			RibbonButton ribbonButton2 = this.class505_0.TXITEM_ObjectArrangeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_SendToBack_BehindText.ToString()] as RibbonButton;
			if (this.drawingFrame_0 != null)
			{
				ribbonButton2.Enabled = false;
				ribbonButton.Enabled = false;
				RibbonMenuButton obj = this.class505_0.TXITEM_ObjectArrangeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_SendToBack.ToString()] as RibbonMenuButton;
				bool enabled = ((this.class505_0.TXITEM_ObjectArrangeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_BringToFront.ToString()] as RibbonMenuButton).Enabled = (this.drawingFrame_0.Drawing as TXDrawingControl).Selection.Shapes.Length > 0);
				obj.Enabled = enabled;
			}
			else
			{
				ribbonButton2.Enabled = true;
				ribbonButton.Enabled = true;
			}
		}

		private void method_115(FrameBase frameBase_1)
		{
			int num = (int)(frameBase_1?.Alignment ?? ((HorizontalAlignment)(-1)));
			RibbonMenuButton ribbonMenuButton = this.class505_0.TXITEM_ObjectArrangeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_Position.ToString()] as RibbonMenuButton;
			ribbonMenuButton.Enabled = this.drawingFrame_0 == null && frameBase_1 != null && (frameBase_1.InsertionMode & FrameInsertionMode.AsCharacter) != FrameInsertionMode.AsCharacter;
			foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
			{
				RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
				if (ribbonToggleButton != null && ((IRibbonItem)ribbonToggleButton).IsDefaultRibbonTabItem)
				{
					switch (ribbonToggleButton.Name)
					{
					case "TXITEM_Position_OtherPosition":
						ribbonToggleButton.Checked = num == 0;
						break;
					case "TXITEM_Position_Right":
						ribbonToggleButton.Checked = num == 2;
						break;
					case "TXITEM_Position_Center":
						ribbonToggleButton.Checked = num == 3;
						break;
					case "TXITEM_Position_Left":
						ribbonToggleButton.Checked = num == 1;
						break;
					}
				}
			}
		}

		private void method_116(FrameBase frameBase_1)
		{
			RibbonGroup ribbonGroup = this.class505_0.TXITEM_ObjectSizeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectSizeGroup.ToString()] as RibbonGroup;
			if (!this.class505_0.method_0(ribbonGroup))
			{
				return;
			}
			if (frameBase_1 != null)
			{
				ribbonGroup.Enabled = true;
				switch (frameBase_1.GetType().Name)
				{
				case "Image":
				{
					var image = frameBase_1 as Image;
					(this.class505_0.TXITEM_ObjectSizeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectHeight.ToString()] as RibbonTextBox).Text = (TwipsConverter.Tw2DotNet(frameBase_1.Size.Height * image.VerticalScaling / 100, this.measuringUnit_0, this.int_0) / this.double_0).ToString();
					(this.class505_0.TXITEM_ObjectSizeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectWidth.ToString()] as RibbonTextBox).Text = (TwipsConverter.Tw2DotNet(frameBase_1.Size.Width * image.HorizontalScaling / 100, this.measuringUnit_0, this.int_0) / this.double_0).ToString();
					break;
				}
				case "DrawingFrame":
				{
					DrawingFrame drawingFrame = frameBase_1 as DrawingFrame;
					this.method_117(drawingFrame.Drawing as TXDrawingControl, drawingFrame);
					break;
				}
				default:
					(this.class505_0.TXITEM_ObjectSizeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectHeight.ToString()] as RibbonTextBox).Text = (TwipsConverter.Tw2DotNet(frameBase_1.Size.Height, this.measuringUnit_0, this.int_0) / this.double_0).ToString();
					(this.class505_0.TXITEM_ObjectSizeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectWidth.ToString()] as RibbonTextBox).Text = (TwipsConverter.Tw2DotNet(frameBase_1.Size.Width, this.measuringUnit_0, this.int_0) / this.double_0).ToString();
					break;
				}
				ribbonGroup.DialogBoxLauncher.Enabled = this.drawingFrame_0 == null || !(this.drawingFrame_0.Drawing as TXDrawingControl).Visible;
			}
			else
			{
				(this.class505_0.TXITEM_ObjectSizeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectHeight.ToString()] as RibbonTextBox).Text = "";
				(this.class505_0.TXITEM_ObjectSizeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectWidth.ToString()] as RibbonTextBox).Text = "";
				ribbonGroup.Enabled = base.m_txTextControl == null;
			}
		}

		private void method_117(TXDrawingControl txdrawingControl_0, DrawingFrame drawingFrame_1)
		{
			RibbonGroup ribbonGroup_ = this.class505_0.TXITEM_ObjectSizeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectSizeGroup.ToString()] as RibbonGroup;
			if (!this.class505_0.method_0(ribbonGroup_))
			{
				return;
			}
			RibbonTextBox ribbonTextBox = this.class505_0.TXITEM_ObjectSizeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectHeight.ToString()] as RibbonTextBox;
			RibbonTextBox ribbonTextBox2 = this.class505_0.TXITEM_ObjectSizeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectWidth.ToString()] as RibbonTextBox;
			DrawingFrame drawingFrame = ((drawingFrame_1 == null) ? base.m_txTextControl.Drawings.GetItem() : drawingFrame_1);
			if (drawingFrame == null || drawingFrame.Drawing != txdrawingControl_0)
			{
				return;
			}
			if (txdrawingControl_0.IsCanvasVisible && txdrawingControl_0.Selection.Shapes.Length != 0 && txdrawingControl_0.Visible)
			{
				if (txdrawingControl_0.Selection.IsCommonValueSelected(Drawing.Selection.Attribute.SizeHeight))
				{
					ribbonTextBox.Text = (TwipsConverter.Tw2DotNet(txdrawingControl_0.Selection.Shapes[0].Size.Height, this.measuringUnit_0, this.int_0) / this.double_0).ToString();
				}
				else
				{
					ribbonTextBox.Text = "";
				}
				if (txdrawingControl_0.Selection.IsCommonValueSelected(Drawing.Selection.Attribute.SizeWidth))
				{
					ribbonTextBox2.Text = (TwipsConverter.Tw2DotNet(txdrawingControl_0.Selection.Shapes[0].Size.Width, this.measuringUnit_0, this.int_0) / this.double_0).ToString();
				}
				else
				{
					ribbonTextBox2.Text = "";
				}
			}
			else
			{
				ribbonTextBox.Text = (TwipsConverter.Tw2DotNet(drawingFrame.Size.Height, this.measuringUnit_0, this.int_0) / this.double_0).ToString();
				ribbonTextBox2.Text = (TwipsConverter.Tw2DotNet(drawingFrame.Size.Width, this.measuringUnit_0, this.int_0) / this.double_0).ToString();
			}
		}

		private void method_118(FrameBase frameBase_1)
		{
			RibbonGroup ribbonGroup = this.class505_0.TXITEM_ObjectPropertiesGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectPropertiesGroup.ToString()] as RibbonGroup;
			if (this.class505_0.method_0(ribbonGroup))
			{
				if (frameBase_1 != null)
				{
					ribbonGroup.Enabled = this.drawingFrame_0 == null;
					(this.class505_0.TXITEM_ObjectPropertiesGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectName.ToString()] as RibbonTextBox).Text = frameBase_1.Name;
					(this.class505_0.TXITEM_ObjectPropertiesGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectID.ToString()] as RibbonTextBox).Text = frameBase_1.Int32_0.ToString();
				}
				else
				{
					ribbonGroup.Enabled = base.m_txTextControl == null;
					(this.class505_0.TXITEM_ObjectPropertiesGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectName.ToString()] as RibbonTextBox).Text = "";
					(this.class505_0.TXITEM_ObjectPropertiesGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectID.ToString()] as RibbonTextBox).Text = "";
				}
			}
		}

		private void method_119(FrameBase frameBase_1)
		{
			if (this.ribbonTextBox_0 == null || frameBase_1 == null)
			{
				return;
			}
			switch (this.ribbonTextBox_0.Name)
			{
			case "TXITEM_ObjectName":
			case "TXITEM_ObjectID":
			{
				RibbonGroup ribbonGroup_2 = this.class505_0.TXITEM_ObjectPropertiesGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectPropertiesGroup.ToString()] as RibbonGroup;
				if (!this.class505_0.method_0(ribbonGroup_2))
				{
					break;
				}
				switch (this.ribbonTextBox_0.Name)
				{
				case "TXITEM_ObjectID":
				{
					if (int.TryParse(this.ribbonTextBox_0.Text, out var result))
					{
						frameBase_1.Int32_0 = result;
					}
					break;
				}
				case "TXITEM_ObjectName":
					frameBase_1.Name = this.ribbonTextBox_0.Text;
					break;
				}
				break;
			}
			case "TXITEM_ObjectHeight":
			case "TXITEM_ObjectWidth":
			{
				RibbonGroup ribbonGroup_ = this.class505_0.TXITEM_ObjectSizeGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_ObjectSizeGroup.ToString()] as RibbonGroup;
				if (this.class505_0.method_0(ribbonGroup_))
				{
					double double_ = ((this.ribbonTextBox_0.Text == null || this.ribbonTextBox_0.Text.Length <= 0) ? (-1.0) : ((double)TwipsConverter.DotNet2Tw(Convert.ToDouble(this.ribbonTextBox_0.Text), this.measuringUnit_0) * this.double_0));
					switch (this.ribbonTextBox_0.Name)
					{
					case "TXITEM_ObjectWidth":
						this.method_123(frameBase_1, double_, this.ribbonTextBox_0, bool_0: false);
						break;
					case "TXITEM_ObjectHeight":
						this.method_123(frameBase_1, double_, this.ribbonTextBox_0, bool_0: true);
						break;
					}
				}
				break;
			}
			}
			this.ribbonTextBox_0 = null;
		}

		private FrameBase method_120()
		{
			FrameBase item;
			if ((item = base.m_txTextControl.Frames.GetItem()) == null)
			{
				RibbonFrameLayoutTab ribbonFrameLayoutTab = this.class505_0.Control_0 as RibbonFrameLayoutTab;
				if (ribbonFrameLayoutTab != null)
				{
					item = this.drawingFrame_0;
				}
			}
			return item;
		}

		private void method_121(ZOrder zorder_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			DrawingFrame activatedItem = base.m_txTextControl.Drawings.GetActivatedItem();
			FrameBase item;
			if (activatedItem != null)
			{
				TXDrawingControl tXDrawingControl = activatedItem.Drawing as TXDrawingControl;
				switch (zorder_0)
				{
				case ZOrder.const_2:
					tXDrawingControl.Selection.BringForward();
					break;
				case ZOrder.Top:
					tXDrawingControl.Selection.BringToFront();
					break;
				case ZOrder.Bottom:
					tXDrawingControl.Selection.SendToBack();
					break;
				case ZOrder.Down:
					tXDrawingControl.Selection.SendBackward();
					break;
				}
			}
			else if ((item = base.m_txTextControl.Frames.GetItem()) != null)
			{
				item.ChangeZOrder(zorder_0);
			}
		}

		private void method_122(RibbonTextBox ribbonTextBox_1, double double_2)
		{
			if (base.m_txTextControl != null)
			{
				FrameBase frameBase = this.method_120();
				if (frameBase != null)
				{
					bool bool_ = ribbonTextBox_1.Name == RibbonFrameLayoutTab.RibbonItem.TXITEM_ObjectHeight.ToString();
					double double_3 = ((ribbonTextBox_1.Text == null || ribbonTextBox_1.Text.Length <= 0) ? (-1.0) : ((double)TwipsConverter.DotNet2Tw(Convert.ToDouble(ribbonTextBox_1.Text) + double_2, this.measuringUnit_0) * this.double_0));
					this.method_123(frameBase, double_3, ribbonTextBox_1, bool_);
				}
			}
		}

		private void method_123(FrameBase frameBase_1, double double_2, RibbonTextBox ribbonTextBox_1, bool bool_0)
		{
			switch (frameBase_1.GetType().Name)
			{
			case "DrawingFrame":
			{
				DrawingFrame drawingFrame = frameBase_1 as DrawingFrame;
				if (drawingFrame == null)
				{
					break;
				}
				TXDrawingControl tXDrawingControl = drawingFrame.Drawing as TXDrawingControl;
				if (double_2 > 0.0)
				{
					if (tXDrawingControl.IsCanvasVisible && tXDrawingControl.Selection.Shapes.Length != 0 && tXDrawingControl.Visible)
					{
						Shape[] shapes = tXDrawingControl.Selection.Shapes;
						foreach (Shape shape in shapes)
						{
							shape.Size = (bool_0 ? new Size(shape.Size.Width, (int)double_2) : new Size((int)double_2, shape.Size.Height));
						}
					}
					else
					{
						drawingFrame.Size = (bool_0 ? new Size(drawingFrame.Size.Width, (int)double_2) : new Size((int)double_2, drawingFrame.Size.Height));
					}
				}
				else if (tXDrawingControl.IsCanvasVisible && tXDrawingControl.Selection.Shapes.Length != 0 && tXDrawingControl.Visible)
				{
					if (bool_0 ? tXDrawingControl.Selection.IsCommonValueSelected(Drawing.Selection.Attribute.SizeHeight) : tXDrawingControl.Selection.IsCommonValueSelected(Drawing.Selection.Attribute.SizeWidth))
					{
						int val2 = (bool_0 ? tXDrawingControl.Selection.Shapes[0].Size.Height : tXDrawingControl.Selection.Shapes[0].Size.Width);
						ribbonTextBox_1.Text = (TwipsConverter.Tw2DotNet(val2, this.measuringUnit_0, this.int_0) * this.double_0).ToString();
					}
					else
					{
						ribbonTextBox_1.Text = "";
					}
				}
				else
				{
					int val3 = (bool_0 ? frameBase_1.Size.Height : frameBase_1.Size.Width);
					ribbonTextBox_1.Text = (TwipsConverter.Tw2DotNet(val3, this.measuringUnit_0, this.int_0) * this.double_0).ToString();
				}
				break;
			}
			case "Image":
			{
				var image = frameBase_1 as Image;
				if (double_2 > 0.0)
				{
					if (bool_0)
					{
						double value = double_2 * 100.0 / (double)frameBase_1.Size.Height;
						int num2 = (image.VerticalScaling = Convert.ToInt32(value));
					}
					else
					{
						double value2 = double_2 * 100.0 / (double)frameBase_1.Size.Width;
						int num4 = (image.HorizontalScaling = Convert.ToInt32(value2));
					}
				}
				else
				{
					int num5 = (bool_0 ? (frameBase_1.Size.Height * image.VerticalScaling) : (frameBase_1.Size.Width * image.HorizontalScaling));
					ribbonTextBox_1.Text = (TwipsConverter.Tw2DotNet(num5 / 100, this.measuringUnit_0, this.int_0) / this.double_0).ToString();
				}
				break;
			}
			default:
			{
				if (double_2 > 0.0)
				{
					frameBase_1.Size = (bool_0 ? new Size(frameBase_1.Size.Width, (int)double_2) : new Size((int)double_2, frameBase_1.Size.Height));
					break;
				}
				int val = (bool_0 ? frameBase_1.Size.Height : frameBase_1.Size.Width);
				ribbonTextBox_1.Text = (TwipsConverter.Tw2DotNet(val, this.measuringUnit_0, this.int_0) / this.double_0).ToString();
				break;
			}
			}
		}

		protected override void DefaultColorButton_Click(object sender, EventArgs e)
		{
			this.method_53(sender as RibbonToggleButton);
		}

		protected override void ColorListView_ItemClick(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			this.method_54(sender as RibbonListView, e);
		}

		protected override void MoreColorsButton_Click(object sender, EventArgs e)
		{
			this.method_55(sender as RibbonButton);
		}

		protected override void LineWidthItem_Click(object sender, EventArgs e)
		{
			this.method_56(sender as RibbonToggleButton);
		}

		private void method_124(object sender, EventArgs e)
		{
			this.method_57(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ArrangeGroup_Handler(object sender, EventArgs e)
		{
			this.method_95();
		}

		private void method_125(object sender, EventArgs e)
		{
			this.method_96(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_WrapText_MoreLayoutOptions_Handler(object sender, EventArgs e)
		{
			this.method_97();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_BringToFront_ToFront_Handler(object sender, EventArgs e)
		{
			this.method_98();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_BringToFront_Forward_Handler(object sender, EventArgs e)
		{
			this.method_99();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_BringToFront_InFrontOfText_Handler(object sender, EventArgs e)
		{
			this.method_100();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_SendToBack_ToBack_Handler(object sender, EventArgs e)
		{
			this.method_101();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_SendToBack_Backward_Handler(object sender, EventArgs e)
		{
			this.method_102();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_SendToBack_BehindText_Handler(object sender, EventArgs e)
		{
			this.method_103();
		}

		private void method_126(object sender, EventArgs e)
		{
			this.method_104(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Position_OtherPosition_Handler(object sender, EventArgs e)
		{
			this.method_105();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ObjectSizeGroup_Handler(object sender, EventArgs e)
		{
			this.method_106();
		}

		private void method_127(object sender, EventArgs e)
		{
			this.method_107(sender as RibbonTextBox);
		}

		private void method_128(object sender, EventArgs e)
		{
			this.method_108(sender as RibbonTextBox);
		}

		private void method_129(object sender, EventArgs e)
		{
			this.method_109(sender as RibbonTextBox);
		}

		private void method_130(object sender, EventArgs e)
		{
			this.method_110(sender as RibbonTextBox);
		}

		private void method_131(object sender, EventArgs e)
		{
			this.method_111(sender as RibbonTextBox);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_TextFrame_BordersandBackgroundGroup_Handler(object sender, EventArgs e)
		{
			this.method_150();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Drawing_BordersandBackgroundGroup_Handler(object sender, EventArgs e)
		{
			this.method_72();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DrawingRotation_Right90_Handler(object sender, EventArgs e)
		{
			this.method_73();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DrawingRotation_Left90_Handler(object sender, EventArgs e)
		{
			this.method_74();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DrawingRotation_FlipVertical_Handler(object sender, EventArgs e)
		{
			this.method_75();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DrawingRotation_FlipHorizontal_Handler(object sender, EventArgs e)
		{
			this.method_76();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DrawingRotation_MoreRotationOptions_Handler(object sender, EventArgs e)
		{
			this.method_77();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Barcode_ColorsAndAlignmentGroup_Handler(object sender, EventArgs e)
		{
			this.method_17();
		}

		private void method_132(object sender, EventArgs e)
		{
			this.method_18(sender as RibbonButton);
		}

		private void method_133(object sender, EventArgs e)
		{
			this.method_19(sender as RibbonButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_BarcodeRotation_MoreRotationOptions_Handler(object sender, EventArgs e)
		{
			this.method_20();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Chart_TypeAndAppearanceGroup_Handler(object sender, EventArgs e)
		{
			this.method_34();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ChartType_Handler(object sender, EventArgs e)
		{
			this.method_35(sender as RibbonMenuButton);
		}

		protected override void ChartGallery_ItemClick(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			this.method_36(sender as RibbonListView, e);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ChartIs3D_Handler(object sender, EventArgs e)
		{
			this.method_37((sender as RibbonToggleButton).Checked);
		}

		private void method_134(object sender, EventArgs e)
		{
			this.method_38(sender as RibbonButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ChartHasRightAngleAxes_Handler(object sender, EventArgs e)
		{
			this.method_39((sender as RibbonToggleButton).Checked);
		}

		private void method_135(object sender, EventArgs e)
		{
			this.method_40(sender as RibbonToggleButton);
		}

		private void method_136(object sender, EventArgs e)
		{
			this.method_41(sender as RibbonToggleButton);
		}

		internal void method_137(object sender, FrameEventArgs e)
		{
			this.method_58(e);
		}

		internal void method_138(object sender, FrameEventArgs e)
		{
			this.method_59(e);
		}

		private void method_139(object sender, FrameEventArgs e)
		{
			this.method_60(e);
		}

		private void method_140(object sender, FrameEventArgs e)
		{
			this.method_61(e);
		}

		internal void method_141(object sender, FrameEventArgs e)
		{
			this.method_62(e);
		}

		internal void method_142(object sender, TextFrameEventArgs e)
		{
			this.method_63(e);
		}

		internal void method_143(object sender, DrawingEventArgs e)
		{
			this.method_64();
		}

		internal void method_144(object sender, DrawingEventArgs e)
		{
			this.method_65(e);
		}

		private void method_145(object sender, PropertyChangedEventArgs e)
		{
			this.method_66(sender as TXDrawingControl, e);
		}

		internal void method_146(object sender, EventArgs e)
		{
			this.method_67(sender as TXDrawingControl);
		}

		private void method_147(object sender, ShapeEventArgs e)
		{
			this.method_68(sender as TXDrawingControl);
		}

		private void method_148(object sender, ShapeEventArgs e)
		{
			this.method_69(sender as TXDrawingControl);
		}

		internal void method_149(object sender, PropertyChangedEventArgs e)
		{
			this.method_70((sender as Control7).Object_0 as TXBarcodeControl, e);
		}

		private void method_150()
		{
			if (base.m_txTextControl != null)
			{
				TextFrame item = base.m_txTextControl.TextFrames.GetItem();
				if (item != null)
				{
					base.m_txTextControl.TextFrameAttributesDialog(2);
				}
			}
		}

		private void method_151(FrameBase frameBase_1)
		{
			RibbonGroup ribbonGroup = this.class505_0.TXITEM_TextFrame_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrame_BordersandBackgroundGroup.ToString()] as RibbonGroup;
			if (this.class505_0.method_0(ribbonGroup))
			{
				TextFrame textFrame = frameBase_1 as TextFrame;
				this.method_152(textFrame);
				this.method_153(textFrame);
				this.method_154(textFrame);
				ribbonGroup.Enabled = textFrame != null || base.m_txTextControl == null;
			}
		}

		private void method_152(TextFrame textFrame_0)
		{
			RibbonMenuButton ribbonMenuButton = this.class505_0.TXITEM_TextFrame_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameBackColor.ToString()] as RibbonMenuButton;
			if (this.class505_0.method_2(ribbonMenuButton) && textFrame_0 != null)
			{
				Class517.smethod_59(ribbonMenuButton, textFrame_0.BackColor, this.class505_0.Control_0 is ObjectMiniToolbar, base.m_pntDPI);
			}
			RibbonToggleButton ribbonToggleButton = this.class505_0.TXITEM_TextFrame_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameBackColor_Automatic.ToString()] as RibbonToggleButton;
			if (this.class505_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = textFrame_0 != null && textFrame_0.BackColor.ToArgb() == base.m_txTextControl.BackColor.ToArgb();
			}
		}

		private void method_153(TextFrame textFrame_0)
		{
			RibbonMenuButton ribbonMenuButton = this.class505_0.TXITEM_TextFrame_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameLineWidth.ToString()] as RibbonMenuButton;
			if (!this.class505_0.method_3(ribbonMenuButton))
			{
				return;
			}
			int num = textFrame_0?.BorderWidth ?? (-1);
			foreach (IRibbonItem dropDownItem in ribbonMenuButton.DropDownItems)
			{
				if (dropDownItem.IsDefaultRibbonTabItem)
				{
					RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
					if (ribbonToggleButton != null)
					{
						ribbonToggleButton.Checked = (ribbonToggleButton.Tag as object[])[0] as int? == num;
					}
				}
			}
		}

		private void method_154(TextFrame textFrame_0)
		{
			RibbonMenuButton ribbonMenuButton = this.class505_0.TXITEM_TextFrame_BordersandBackgroundGroup_Items[RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameTransparency.ToString()] as RibbonMenuButton;
			if (!this.class505_0.method_3(ribbonMenuButton))
			{
				return;
			}
			int num = ((int?)textFrame_0?.Transparency) ?? (-1);
			foreach (IRibbonItem dropDownItem in ribbonMenuButton.DropDownItems)
			{
				if (dropDownItem.IsDefaultRibbonTabItem)
				{
					RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
					if (ribbonToggleButton != null)
					{
						ribbonToggleButton.Checked = Convert.ToInt32(ribbonToggleButton.Tag) == num;
					}
				}
			}
		}
	}
}
