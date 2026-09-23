using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;
using DocumentServer.DataSources;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonChartLayoutTab class represents a Windows Forms ribbon tab for editing objects of type ChartFrame.</summary>
	[ToolboxBitmap(typeof(RibbonChartLayoutTab))]
	public class RibbonChartLayoutTab : RibbonTab
	{
		/// <summary>Each RibbonItem represents an item in the RibbonChartLayoutTab that is not a drop-down item.</summary>
		public enum RibbonItem
		{
			/// <summary>Identifies the TXITEM_DataGroup ribbon group inside the RibbonChartLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_DataGroup,
			/// <summary>Identifies the TXITEM_EditData ribbon item inside the TXITEM_DataGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_EditData,
			/// <summary>Identifies the TXITEM_SetDataRelation ribbon item inside the TXITEM_DataGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_SetDataRelation,
			/// <summary>Identifies the TXITEM_LabelsGroup ribbon group inside the RibbonChartLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_LabelsGroup,
			/// <summary>Identifies the TXITEM_Legend ribbon item inside the TXITEM_LabelsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Legend,
			/// <summary>Identifies the TXITEM_XAxisLabels ribbon item inside the TXITEM_LabelsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_XAxisLabels,
			/// <summary>Identifies the TXITEM_YAxisLabels ribbon item inside the TXITEM_LabelsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_YAxisLabels,
			/// <summary>Identifies the TXITEM_TitlesGroup ribbon group inside the RibbonChartLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_TitlesGroup,
			/// <summary>Identifies the TXITEM_ChartTitle ribbon item inside the TXITEM_TitlesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ChartTitle,
			/// <summary>Identifies the TXITEM_XAxisTitle ribbon item inside the TXITEM_TitlesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_XAxisTitle,
			/// <summary>Identifies the TXITEM_YAxisTitle ribbon item inside the TXITEM_TitlesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_YAxisTitle,
			/// <summary>Identifies the TXITEM_FormatChartTitle ribbon item inside the TXITEM_TitlesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_FormatChartTitle,
			/// <summary>Identifies the TXITEM_FormatXAxisTitle ribbon item inside the TXITEM_TitlesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_FormatXAxisTitle,
			/// <summary>Identifies the TXITEM_FormatYAxisTitle ribbon item inside the TXITEM_TitlesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_FormatYAxisTitle,
			/// <summary>Identifies the TXITEM_XAxisGroup ribbon group inside the RibbonChartLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_XAxisGroup,
			/// <summary>Identifies the TXITEM_XAxisLine ribbon item inside the TXITEM_XAxisGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_XAxisLine,
			/// <summary>Identifies the TXITEM_XAxisMajorGridlines ribbon item inside the TXITEM_XAxisGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_XAxisMajorGridlines,
			/// <summary>Identifies the TXITEM_XAxisMinorGridlines ribbon item inside the TXITEM_XAxisGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_XAxisMinorGridlines,
			/// <summary>Identifies the TXITEM_XAxisMinimumAutomatic ribbon item inside the TXITEM_XAxisGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_XAxisMinimumAutomatic,
			/// <summary>Identifies the TXITEM_XAxisMaximumAutomatic ribbon item inside the TXITEM_XAxisGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_XAxisMaximumAutomatic,
			/// <summary>Identifies the TXITEM_XAxisIntervalAutomatic ribbon item inside the TXITEM_XAxisGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_XAxisIntervalAutomatic,
			/// <summary>Identifies the TXITEM_XAxisMinimum ribbon item inside the TXITEM_XAxisGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_XAxisMinimum,
			/// <summary>Identifies the TXITEM_XAxisMaximum ribbon item inside the TXITEM_XAxisGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_XAxisMaximum,
			/// <summary>Identifies the TXITEM_XAxisInterval ribbon item inside the TXITEM_XAxisGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_XAxisInterval,
			/// <summary>Identifies the TXITEM_YAxisGroup ribbon group inside the RibbonChartLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_YAxisGroup,
			/// <summary>Identifies the TXITEM_YAxisLine ribbon item inside the TXITEM_YAxisGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_YAxisLine,
			/// <summary>Identifies the TXITEM_YAxisMajorGridlines ribbon item inside the TXITEM_YAxisGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_YAxisMajorGridlines,
			/// <summary>Identifies the TXITEM_YAxisMinorGridlines ribbon item inside the TXITEM_YAxisGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_YAxisMinorGridlines,
			/// <summary>Identifies the TXITEM_YAxisMinimumAutomatic ribbon item inside the TXITEM_YAxisGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_YAxisMinimumAutomatic,
			/// <summary>Identifies the TXITEM_YAxisMaximumAutomatic ribbon item inside the TXITEM_YAxisGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_YAxisMaximumAutomatic,
			/// <summary>Identifies the TXITEM_YAxisIntervalAutomatic ribbon item inside the TXITEM_YAxisGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_YAxisIntervalAutomatic,
			/// <summary>Identifies the TXITEM_YAxisMinimum ribbon item inside the TXITEM_YAxisGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_YAxisMinimum,
			/// <summary>Identifies the TXITEM_YAxisMaximum ribbon item inside the TXITEM_YAxisGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_YAxisMaximum,
			/// <summary>Identifies the TXITEM_YAxisInterval ribbon item inside the TXITEM_YAxisGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_YAxisInterval
		}

		/// <summary>Each RibbonDropDownItem represents a drop-down item in the RibbonChartLayoutTab.</summary>
		public enum RibbonDropDownItem
		{
			/// <summary>Identifies the TXITEM_LegendShow drop-down item inside the TXITEM_Legend's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_LegendShow,
			/// <summary>Identifies the TXITEM_LegendDocking drop-down item inside the TXITEM_Legend's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_LegendDocking,
			/// <summary>Identifies the TXITEM_LegendDocking_Left drop-down item inside the TXITEM_LegendDocking's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_LegendDocking_Left,
			/// <summary>Identifies the TXITEM_LegendDocking_Top drop-down item inside the TXITEM_LegendDocking's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_LegendDocking_Top,
			/// <summary>Identifies the TXITEM_LegendDocking_Right drop-down item inside the TXITEM_LegendDocking's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_LegendDocking_Right,
			/// <summary>Identifies the TXITEM_LegendDocking_Bottom drop-down item inside the TXITEM_LegendDocking's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_LegendDocking_Bottom,
			/// <summary>Identifies the TXITEM_LegendAlignment drop-down item inside the TXITEM_Legend's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_LegendAlignment,
			/// <summary>Identifies the TXITEM_LegendAlignment_Near drop-down item inside the TXITEM_LegendAlignment's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_LegendAlignment_Near,
			/// <summary>Identifies the TXITEM_LegendAlignment_Center drop-down item inside the TXITEM_LegendAlignment's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_LegendAlignment_Center,
			/// <summary>Identifies the TXITEM_LegendAlignment_Far drop-down item inside the TXITEM_LegendAlignment's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_LegendAlignment_Far,
			/// <summary>Identifies the TXITEM_LegendColor drop-down item inside the TXITEM_Legend's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_LegendColor,
			/// <summary>Identifies the TXITEM_LegendColor_Automatic drop-down item inside the TXITEM_LegendColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_LegendColor_Automatic,
			/// <summary>Identifies the TXITEM_LegendColor_MoreColors drop-down item inside the TXITEM_LegendColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_LegendColor_MoreColors,
			/// <summary>Identifies the TXITEM_LegendFont drop-down item inside the TXITEM_Legend's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_LegendFont,
			/// <summary>Identifies the TXITEM_XAxisLabelsShow drop-down item inside the TXITEM_XAxisLabels's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_XAxisLabelsShow,
			/// <summary>Identifies the TXITEM_XAxisLabelsColor drop-down item inside the TXITEM_XAxisLabels's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisLabelsColor,
			/// <summary>Identifies the TXITEM_XAxisLabelsColor_Automatic drop-down item inside the TXITEM_XAxisLabelsColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisLabelsColor_Automatic,
			/// <summary>Identifies the TXITEM_XAxisLabelsColor_MoreColors drop-down item inside the TXITEM_XAxisLabelsColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisLabelsColor_MoreColors,
			/// <summary>Identifies the TXITEM_XAxisLabelsFont drop-down item inside the TXITEM_XAxisLabels's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisLabelsFont,
			/// <summary>Identifies the TXITEM_YAxisLabelsShow drop-down item inside the TXITEM_YAxisLabels's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_YAxisLabelsShow,
			/// <summary>Identifies the TXITEM_YAxisLabelsColor drop-down item inside the TXITEM_YAxisLabels's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisLabelsColor,
			/// <summary>Identifies the TXITEM_YAxisLabelsColor_Automatic drop-down item inside the TXITEM_YAxisLabelsColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisLabelsColor_Automatic,
			/// <summary>Identifies the TXITEM_YAxisLabelsColor_MoreColors drop-down item inside the TXITEM_YAxisLabelsColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisLabelsColor_MoreColors,
			/// <summary>Identifies the TXITEM_YAxisLabelsFont drop-down item inside the TXITEM_YAxisLabels's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisLabelsFont,
			/// <summary>Identifies the TXITEM_ChartTitleDocking drop-down item inside the TXITEM_FormatChartTitle's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_ChartTitleDocking,
			/// <summary>Identifies the TXITEM_ChartTitleDocking_Left drop-down item inside the TXITEM_ChartTitleDocking's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChartTitleDocking_Left,
			/// <summary>Identifies the TXITEM_ChartTitleDocking_Top drop-down item inside the TXITEM_ChartTitleDocking's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChartTitleDocking_Top,
			/// <summary>Identifies the TXITEM_ChartTitleDocking_Right drop-down item inside the TXITEM_ChartTitleDocking's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChartTitleDocking_Right,
			/// <summary>Identifies the TXITEM_ChartTitleDocking_Bottom drop-down item inside the TXITEM_ChartTitleDocking's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChartTitleDocking_Bottom,
			/// <summary>Identifies the TXITEM_ChartTitleOrientation drop-down item inside the TXITEM_FormatChartTitle's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_ChartTitleOrientation,
			/// <summary>Identifies the TXITEM_ChartTitleOrientation_Auto drop-down item inside the TXITEM_ChartTitleOrientation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChartTitleOrientation_Auto,
			/// <summary>Identifies the TXITEM_ChartTitleOrientation_Horizontal drop-down item inside the TXITEM_ChartTitleOrientation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChartTitleOrientation_Horizontal,
			/// <summary>Identifies the TXITEM_ChartTitleOrientation_Rotated270 drop-down item inside the TXITEM_ChartTitleOrientation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChartTitleOrientation_Rotated270,
			/// <summary>Identifies the TXITEM_ChartTitleOrientation_Rotated90 drop-down item inside the TXITEM_ChartTitleOrientation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChartTitleOrientation_Rotated90,
			/// <summary>Identifies the TXITEM_ChartTitleOrientation_Stacked drop-down item inside the TXITEM_ChartTitleOrientation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChartTitleOrientation_Stacked,
			/// <summary>Identifies the TXITEM_ChartTitleColor drop-down item inside the TXITEM_FormatChartTitle's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_ChartTitleColor,
			/// <summary>Identifies the TXITEM_ChartTitleColor_Automatic drop-down item inside the TXITEM_ChartTitleColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_ChartTitleColor_Automatic,
			/// <summary>Identifies the TXITEM_ChartTitle_MoreColors drop-down item inside the TXITEM_ChartTitleColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_ChartTitle_MoreColors,
			/// <summary>Identifies the TXITEM_ChartTitleFont drop-down item inside the TXITEM_FormatChartTitle's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_ChartTitleFont,
			/// <summary>Identifies the TXITEM_XAxisTitleAlignment drop-down item inside the TXITEM_FormatXAxisTitle's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisTitleAlignment,
			/// <summary>Identifies the TXITEM_XAxisTitleAlignment_Near drop-down item inside the TXITEM_XAxisTitleAlignment's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_XAxisTitleAlignment_Near,
			/// <summary>Identifies the TXITEM_XAxisTitleAlignment_Center drop-down item inside the TXITEM_XAxisTitleAlignment's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_XAxisTitleAlignment_Center,
			/// <summary>Identifies the TXITEM_XAxisTitleAlignment_Far drop-down item inside the TXITEM_XAxisTitleAlignment's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_XAxisTitleAlignment_Far,
			/// <summary>Identifies the TXITEM_XAxisTitleOrientation drop-down item inside the TXITEM_FormatXAxisTitle's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisTitleOrientation,
			/// <summary>Identifies the TXITEM_XAxisTitleOrientation_Auto drop-down item inside the TXITEM_XAxisTitleOrientation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_XAxisTitleOrientation_Auto,
			/// <summary>Identifies the TXITEM_XAxisTitleOrientation_Horizontal drop-down item inside the TXITEM_XAxisTitleOrientation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_XAxisTitleOrientation_Horizontal,
			/// <summary>Identifies the TXITEM_XAxisTitleOrientation_Rotated270 drop-down item inside the TXITEM_XAxisTitleOrientation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_XAxisTitleOrientation_Rotated270,
			/// <summary>Identifies the TXITEM_XAxisTitleOrientation_Rotated90 drop-down item inside the TXITEM_XAxisTitleOrientation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_XAxisTitleOrientation_Rotated90,
			/// <summary>Identifies the TXITEM_XAxisTitleOrientation_Stacked drop-down item inside the TXITEM_XAxisTitleOrientation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_XAxisTitleOrientation_Stacked,
			/// <summary>Identifies the TXITEM_XAxisTitleColor drop-down item inside the TXITEM_FormatXAxisTitle's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisTitleColor,
			/// <summary>Identifies the TXITEM_XAxisTitleColor_Automatic drop-down item inside the TXITEM_XAxisTitleColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisTitleColor_Automatic,
			/// <summary>Identifies the TXITEM_XAxisTitleColor_MoreColors drop-down item inside the TXITEM_XAxisTitleColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisTitleColor_MoreColors,
			/// <summary>Identifies the TXITEM_XAxisTitleFont drop-down item inside the TXITEM_FormatXAxisTitle's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisTitleFont,
			/// <summary>Identifies the TXITEM_YAxisTitleAlignment drop-down item inside the TXITEM_FormatYAxisTitle's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisTitleAlignment,
			/// <summary>Identifies the TXITEM_YAxisTitleAlignment_Far drop-down item inside the TXITEM_YAxisTitleAlignment's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_YAxisTitleAlignment_Far,
			/// <summary>Identifies the TXITEM_YAxisTitleAlignment_Center drop-down item inside the TXITEM_YAxisTitleAlignment's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_YAxisTitleAlignment_Center,
			/// <summary>Identifies the TXITEM_YAxisTitleAlignment_Near drop-down item inside the TXITEM_YAxisTitleAlignment's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_YAxisTitleAlignment_Near,
			/// <summary>Identifies the TXITEM_YAxisTitleOrientation drop-down item inside the TXITEM_FormatYAxisTitle's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisTitleOrientation,
			/// <summary>Identifies the TXITEM_YAxisTitleOrientation_Auto drop-down item inside the TXITEM_YAxisTitleOrientation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_YAxisTitleOrientation_Auto,
			/// <summary>Identifies the TXITEM_YAxisTitleOrientation_Horizontal drop-down item inside the TXITEM_YAxisTitleOrientation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_YAxisTitleOrientation_Horizontal,
			/// <summary>Identifies the TXITEM_YAxisTitleOrientation_Rotated270 drop-down item inside the TXITEM_YAxisTitleOrientation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_YAxisTitleOrientation_Rotated270,
			/// <summary>Identifies the TXITEM_YAxisTitleOrientation_Rotated90 drop-down item inside the TXITEM_YAxisTitleOrientation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_YAxisTitleOrientation_Rotated90,
			/// <summary>Identifies the TXITEM_YAxisTitleOrientation_Stacked drop-down item inside the TXITEM_YAxisTitleOrientation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_YAxisTitleOrientation_Stacked,
			/// <summary>Identifies the TXITEM_YAxisTitleColor drop-down item inside the TXITEM_FormatYAxisTitle's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisTitleColor,
			/// <summary>Identifies the TXITEM_YAxisTitleColor_Automatic drop-down item inside the TXITEM_YAxisTitleColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisTitleColor_Automatic,
			/// <summary>Identifies the TXITEM_YAxisTitleColor_MoreColors drop-down item inside the TXITEM_YAxisTitleColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisTitleColor_MoreColors,
			/// <summary>Identifies the TXITEM_YAxisTitleFont drop-down item inside the TXITEM_FormatYAxisTitle's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisTitleFont,
			/// <summary>Identifies the TXITEM_XAxisLineShow drop-down item inside the TXITEM_XAxisLine's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_XAxisLineShow,
			/// <summary>Identifies the TXITEM_XAxisLineColor drop-down item inside the TXITEM_XAxisLine's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisLineColor,
			/// <summary>Identifies the TXITEM_XAxisLineColor_Automatic drop-down item inside the TXITEM_XAxisLineColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisLineColor_Automatic,
			/// <summary>Identifies the TXITEM_XAxisLineColor_MoreColors drop-down item inside the TXITEM_XAxisLineColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisLineColor_MoreColors,
			/// <summary>Identifies the TXITEM_XAxisLineDashType drop-down item inside the TXITEM_XAxisLine's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisLineDashType,
			/// <summary>Identifies the TXITEM_XAxisLineDashType_Dash drop-down item inside the TXITEM_XAxisLineDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisLineDashType_Dash,
			/// <summary>Identifies the TXITEM_XAxisLineDashType_DashDot drop-down item inside the TXITEM_XAxisLineDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisLineDashType_DashDot,
			/// <summary>Identifies the TXITEM_XAxisLineDashType_DashDotDot drop-down item inside the TXITEM_XAxisLineDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisLineDashType_DashDotDot,
			/// <summary>Identifies the TXITEM_XAxisLineDashType_Dot drop-down item inside the TXITEM_XAxisLineDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisLineDashType_Dot,
			/// <summary>Identifies the TXITEM_XAxisLineDashType_Solid drop-down item inside the TXITEM_XAxisLineDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisLineDashType_Solid,
			/// <summary>Identifies the TXITEM_XAxisMajorGridlinesShow drop-down item inside the TXITEM_XAxisMajorGridlines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_XAxisMajorGridlinesShow,
			/// <summary>Identifies the TXITEM_XAxisMajorGridlinesColor drop-down item inside the TXITEM_XAxisMajorGridlines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisMajorGridlinesColor,
			/// <summary>Identifies the TXITEM_XAxisMajorGridlinesColor_Automatic drop-down item inside the TXITEM_XAxisMajorGridlinesColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisMajorGridlinesColor_Automatic,
			/// <summary>Identifies the TXITEM_XAxisMajorGridlinesColor_MoreColors drop-down item inside the TXITEM_XAxisMajorGridlinesColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisMajorGridlinesColor_MoreColors,
			/// <summary>Identifies the TXITEM_XAxisMajorGridlinesDashType drop-down item inside the TXITEM_XAxisMajorGridlines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisMajorGridlinesDashType,
			/// <summary>Identifies the TXITEM_XAxisMajorGridlinesDashType_Dash drop-down item inside the TXITEM_XAxisMajorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisMajorGridlinesDashType_Dash,
			/// <summary>Identifies the TXITEM_XAxisMajorGridlinesDashType_DashDot drop-down item inside the TXITEM_XAxisMajorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisMajorGridlinesDashType_DashDot,
			/// <summary>Identifies the TXITEM_XAxisMajorGridlinesDashType_DashDotDot drop-down item inside the TXITEM_XAxisMajorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisMajorGridlinesDashType_DashDotDot,
			/// <summary>Identifies the TXITEM_XAxisMajorGridlinesDashType_Dot drop-down item inside the TXITEM_XAxisMajorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisMajorGridlinesDashType_Dot,
			/// <summary>Identifies the TXITEM_XAxisMajorGridlinesDashType_Solid drop-down item inside the TXITEM_XAxisMajorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisMajorGridlinesDashType_Solid,
			/// <summary>Identifies the TXITEM_XAxisMinorGridlinesShow drop-down item inside the TXITEM_XAxisMinorGridlines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_XAxisMinorGridlinesShow,
			/// <summary>Identifies the TXITEM_XAxisMinorGridlinesColor drop-down item inside the TXITEM_XAxisMinorGridlines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisMinorGridlinesColor,
			/// <summary>Identifies the TXITEM_XAxisMinorGridlinesColor_Automatic drop-down item inside the TXITEM_XAxisMinorGridlinesColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisMinorGridlinesColor_Automatic,
			/// <summary>Identifies the TXITEM_XAxisMinorGridlinesColor_MoreColors drop-down item inside the TXITEM_XAxisMinorGridlinesColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisMinorGridlinesColor_MoreColors,
			/// <summary>Identifies the TXITEM_XAxisMinorGridlinesDashType drop-down item inside the TXITEM_XAxisMinorGridlines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisMinorGridlinesDashType,
			/// <summary>Identifies the TXITEM_XAxisMinorGridlinesDashType_Dash drop-down item inside the TXITEM_XAxisMinorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisMinorGridlinesDashType_Dash,
			/// <summary>Identifies the TXITEM_XAxisMinorGridlinesDashType_DashDot drop-down item inside the TXITEM_XAxisMinorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisMinorGridlinesDashType_DashDot,
			/// <summary>Identifies the TXITEM_XAxisMinorGridlinesDashType_DashDotDot drop-down item inside the TXITEM_XAxisMinorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisMinorGridlinesDashType_DashDotDot,
			/// <summary>Identifies the TXITEM_XAxisMinorGridlinesDashType_Dot drop-down item inside the TXITEM_XAxisMinorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisMinorGridlinesDashType_Dot,
			/// <summary>Identifies the TXITEM_XAxisMinorGridlinesDashType_Solid drop-down item inside the TXITEM_XAxisMinorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_XAxisMinorGridlinesDashType_Solid,
			/// <summary>Identifies the TXITEM_YAxisLineShow drop-down item inside the TXITEM_YAxisLine's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_YAxisLineShow,
			/// <summary>Identifies the TXITEM_YAxisLineColor drop-down item inside the TXITEM_YAxisLine's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisLineColor,
			/// <summary>Identifies the TXITEM_YAxisLineColor_Automatic drop-down item inside the TXITEM_YAxisLineColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisLineColor_Automatic,
			/// <summary>Identifies the TXITEM_YAxisLineColor_MoreColors drop-down item inside the TXITEM_YAxisLineColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisLineColor_MoreColors,
			/// <summary>Identifies the TXITEM_YAxisLineDashType drop-down item inside the TXITEM_YAxisLine's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisLineDashType,
			/// <summary>Identifies the TXITEM_YAxisLineDashType_Dash drop-down item inside the TXITEM_YAxisLineDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisLineDashType_Dash,
			/// <summary>Identifies the TXITEM_YAxisLineDashType_DashDot drop-down item inside the TXITEM_YAxisLineDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisLineDashType_DashDot,
			/// <summary>Identifies the TXITEM_YAxisLineDashType_DashDotDot drop-down item inside the TXITEM_YAxisLineDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisLineDashType_DashDotDot,
			/// <summary>Identifies the TXITEM_YAxisLineDashType_Dot drop-down item inside the TXITEM_YAxisLineDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisLineDashType_Dot,
			/// <summary>Identifies the TXITEM_YAxisLineDashType_Solid drop-down item inside the TXITEM_YAxisLineDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisLineDashType_Solid,
			/// <summary>Identifies the TXITEM_YAxisMajorGridlinesShow drop-down item inside the TXITEM_YAxisMajorGridlines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_YAxisMajorGridlinesShow,
			/// <summary>Identifies the TXITEM_YAxisMajorGridlinesColor drop-down item inside the TXITEM_YAxisMajorGridlines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisMajorGridlinesColor,
			/// <summary>Identifies the TXITEM_YAxisMajorGridlinesColor_Automatic drop-down item inside the TXITEM_YAxisMajorGridlinesColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisMajorGridlinesColor_Automatic,
			/// <summary>Identifies the TXITEM_YAxisMajorGridlinesColor_MoreColors drop-down item inside the TXITEM_YAxisMajorGridlinesColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisMajorGridlinesColor_MoreColors,
			/// <summary>Identifies the TXITEM_YAxisMajorGridlinesDashType drop-down item inside the TXITEM_YAxisMajorGridlines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisMajorGridlinesDashType,
			/// <summary>Identifies the TXITEM_YAxisMajorGridlinesDashType_Dash drop-down item inside the TXITEM_YAxisMajorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisMajorGridlinesDashType_Dash,
			/// <summary>Identifies the TXITEM_YAxisMajorGridlinesDashType_DashDot drop-down item inside the TXITEM_YAxisMajorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisMajorGridlinesDashType_DashDot,
			/// <summary>Identifies the TXITEM_YAxisMajorGridlinesDashType_DashDotDot drop-down item inside the TXITEM_YAxisMajorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisMajorGridlinesDashType_DashDotDot,
			/// <summary>Identifies the TXITEM_YAxisMajorGridlinesDashType_Dot drop-down item inside the TXITEM_YAxisMajorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisMajorGridlinesDashType_Dot,
			/// <summary>Identifies the TXITEM_YAxisMajorGridlinesDashType_Solid drop-down item inside the TXITEM_YAxisMajorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisMajorGridlinesDashType_Solid,
			/// <summary>Identifies the TXITEM_YAxisMinorGridlinesShow drop-down item inside the TXITEM_YAxisMinorGridlines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_YAxisMinorGridlinesShow,
			/// <summary>Identifies the TXITEM_YAxisMinorGridlinesColor drop-down item inside the TXITEM_YAxisMinorGridlines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisMinorGridlinesColor,
			/// <summary>Identifies the TXITEM_YAxisMinorGridlinesColor_Automatic drop-down item inside the TXITEM_YAxisMinorGridlinesColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisMinorGridlinesColor_Automatic,
			/// <summary>Identifies the TXITEM_YAxisMinorGridlinesColor_MoreColors drop-down item inside the TXITEM_YAxisMinorGridlinesColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisMinorGridlinesColor_MoreColors,
			/// <summary>Identifies the TXITEM_YAxisMinorGridlinesDashType drop-down item inside the TXITEM_YAxisMinorGridlines's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisMinorGridlinesDashType,
			/// <summary>Identifies the TXITEM_YAxisMinorGridlinesDashType_Dash drop-down item inside the TXITEM_YAxisMinorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisMinorGridlinesDashType_Dash,
			/// <summary>Identifies the TXITEM_YAxisMinorGridlinesDashType_DashDot drop-down item inside the TXITEM_YAxisMinorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisMinorGridlinesDashType_DashDot,
			/// <summary>Identifies the TXITEM_YAxisMinorGridlinesDashType_DashDotDot drop-down item inside the TXITEM_YAxisMinorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisMinorGridlinesDashType_DashDotDot,
			/// <summary>Identifies the TXITEM_YAxisMinorGridlinesDashType_Dot drop-down item inside the TXITEM_YAxisMinorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisMinorGridlinesDashType_Dot,
			/// <summary>Identifies the TXITEM_YAxisMinorGridlinesDashType_Solid drop-down item inside the TXITEM_YAxisMinorGridlinesDashType's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_YAxisMinorGridlinesDashType_Solid
		}

		[Obfuscation(Exclude = true)]
		internal enum InternalRibbonItem
		{
			TXITEM_DataGroup,
			TXITEM_EditData,
			TXITEM_SetDataRelation,
			TXITEM_LabelsGroup,
			TXITEM_Legend,
			TXITEM_LegendShow,
			TXITEM_LegendDocking,
			TXITEM_LegendDocking_Left,
			TXITEM_LegendDocking_Top,
			TXITEM_LegendDocking_Right,
			TXITEM_LegendDocking_Bottom,
			TXITEM_LegendAlignment,
			TXITEM_LegendAlignment_Near,
			TXITEM_LegendAlignment_Center,
			TXITEM_LegendAlignment_Far,
			TXITEM_LegendColor,
			TXITEM_LegendColor_Automatic,
			TXITEM_LegendColorSeperator1,
			TXITEM_LegendColor_Gallery,
			TXITEM_LegendColorSeperator2,
			TXITEM_LegendColor_MoreColors,
			TXITEM_LegendFont,
			TXITEM_XAxisLabels,
			TXITEM_XAxisLabelsShow,
			TXITEM_XAxisLabelsColor,
			TXITEM_XAxisLabelsColor_Automatic,
			TXITEM_XAxisLabelsColorSeperator1,
			TXITEM_XAxisLabelsColor_Gallery,
			TXITEM_XAxisLabelsColorSeperator2,
			TXITEM_XAxisLabelsColor_MoreColors,
			TXITEM_XAxisLabelsFont,
			TXITEM_YAxisLabels,
			TXITEM_YAxisLabelsShow,
			TXITEM_YAxisLabelsColor,
			TXITEM_YAxisLabelsColor_Automatic,
			TXITEM_YAxisLabelsColorSeperator1,
			TXITEM_YAxisLabelsColor_Gallery,
			TXITEM_YAxisLabelsColorSeperator2,
			TXITEM_YAxisLabelsColor_MoreColors,
			TXITEM_YAxisLabelsFont,
			TXITEM_TitlesGroup,
			TXITEM_ChartTitle,
			TXITEM_XAxisTitle,
			TXITEM_YAxisTitle,
			TXITEM_FormatChartTitle,
			TXITEM_ChartTitleDocking,
			TXITEM_ChartTitleDocking_Left,
			TXITEM_ChartTitleDocking_Top,
			TXITEM_ChartTitleDocking_Right,
			TXITEM_ChartTitleDocking_Bottom,
			TXITEM_ChartTitleOrientation,
			TXITEM_ChartTitleOrientation_Auto,
			TXITEM_ChartTitleOrientation_Horizontal,
			TXITEM_ChartTitleOrientation_Rotated270,
			TXITEM_ChartTitleOrientation_Rotated90,
			TXITEM_ChartTitleOrientation_Stacked,
			TXITEM_ChartTitleColor,
			TXITEM_ChartTitleColor_Automatic,
			TXITEM_ChartTitleColorSeperator1,
			TXITEM_ChartTitleColor_Gallery,
			TXITEM_ChartTitleSeperator2,
			TXITEM_ChartTitle_MoreColors,
			TXITEM_ChartTitleFont,
			TXITEM_FormatXAxisTitle,
			TXITEM_XAxisTitleAlignment,
			TXITEM_XAxisTitleAlignment_Near,
			TXITEM_XAxisTitleAlignment_Center,
			TXITEM_XAxisTitleAlignment_Far,
			TXITEM_XAxisTitleOrientation,
			TXITEM_XAxisTitleOrientation_Auto,
			TXITEM_XAxisTitleOrientation_Horizontal,
			TXITEM_XAxisTitleOrientation_Rotated270,
			TXITEM_XAxisTitleOrientation_Rotated90,
			TXITEM_XAxisTitleOrientation_Stacked,
			TXITEM_XAxisTitleColor,
			TXITEM_XAxisTitleColor_Automatic,
			TXITEM_XAxisTitleColorSeperator1,
			TXITEM_XAxisTitleColor_Gallery,
			TXITEM_XAxisTitleColorSeperator2,
			TXITEM_XAxisTitleColor_MoreColors,
			TXITEM_XAxisTitleFont,
			TXITEM_FormatYAxisTitle,
			TXITEM_YAxisTitleAlignment,
			TXITEM_YAxisTitleAlignment_Near,
			TXITEM_YAxisTitleAlignment_Center,
			TXITEM_YAxisTitleAlignment_Far,
			TXITEM_YAxisTitleOrientation,
			TXITEM_YAxisTitleOrientation_Auto,
			TXITEM_YAxisTitleOrientation_Horizontal,
			TXITEM_YAxisTitleOrientation_Rotated270,
			TXITEM_YAxisTitleOrientation_Rotated90,
			TXITEM_YAxisTitleOrientation_Stacked,
			TXITEM_YAxisTitleColor,
			TXITEM_YAxisTitleColor_Automatic,
			TXITEM_YAxisTitleColorSeperator1,
			TXITEM_YAxisTitleColor_Gallery,
			TXITEM_YAxisTitleColorSeperator2,
			TXITEM_YAxisTitleColor_MoreColors,
			TXITEM_YAxisTitleFont,
			TXITEM_XAxisGroup,
			TXITEM_XAxisLine,
			TXITEM_XAxisLineShow,
			TXITEM_XAxisLineColor,
			TXITEM_XAxisLineColor_Automatic,
			TXITEM_XAxisLineColorSeperator1,
			TXITEM_XAxisLineColor_Gallery,
			TXITEM_XAxisLineColorSeperator2,
			TXITEM_XAxisLineColor_MoreColors,
			TXITEM_XAxisLineDashType,
			TXITEM_XAxisLineDashType_Dash,
			TXITEM_XAxisLineDashType_DashDot,
			TXITEM_XAxisLineDashType_DashDotDot,
			TXITEM_XAxisLineDashType_Dot,
			TXITEM_XAxisLineDashType_Solid,
			TXITEM_XAxisMajorGridlines,
			TXITEM_XAxisMajorGridlinesShow,
			TXITEM_XAxisMajorGridlinesColor,
			TXITEM_XAxisMajorGridlinesColor_Automatic,
			TXITEM_XAxisMajorGridlinesColorSeperator1,
			TXITEM_XAxisMajorGridlinesColor_Gallery,
			TXITEM_XAxisMajorGridlinesColorSeperator2,
			TXITEM_XAxisMajorGridlinesColor_MoreColors,
			TXITEM_XAxisMajorGridlinesDashType,
			TXITEM_XAxisMajorGridlinesDashType_Dash,
			TXITEM_XAxisMajorGridlinesDashType_DashDot,
			TXITEM_XAxisMajorGridlinesDashType_DashDotDot,
			TXITEM_XAxisMajorGridlinesDashType_Dot,
			TXITEM_XAxisMajorGridlinesDashType_Solid,
			TXITEM_XAxisMinorGridlines,
			TXITEM_XAxisMinorGridlinesShow,
			TXITEM_XAxisMinorGridlinesColor,
			TXITEM_XAxisMinorGridlinesColor_Automatic,
			TXITEM_XAxisMinorGridlinesColorSeperator1,
			TXITEM_XAxisMinorGridlinesColor_Gallery,
			TXITEM_XAxisMinorGridlinesColorSeperator2,
			TXITEM_XAxisMinorGridlinesColor_MoreColors,
			TXITEM_XAxisMinorGridlinesDashType,
			TXITEM_XAxisMinorGridlinesDashType_Dash,
			TXITEM_XAxisMinorGridlinesDashType_DashDot,
			TXITEM_XAxisMinorGridlinesDashType_DashDotDot,
			TXITEM_XAxisMinorGridlinesDashType_Dot,
			TXITEM_XAxisMinorGridlinesDashType_Solid,
			TXITEM_XAxisMinimum,
			TXITEM_XAxisMaximum,
			TXITEM_XAxisInterval,
			TXITEM_XAxisMinimumAutomatic,
			TXITEM_XAxisMaximumAutomatic,
			TXITEM_XAxisIntervalAutomatic,
			TXITEM_YAxisGroup,
			TXITEM_YAxisLine,
			TXITEM_YAxisLineShow,
			TXITEM_YAxisLineColor,
			TXITEM_YAxisLineColor_Automatic,
			TXITEM_YAxisLineColorSeperator1,
			TXITEM_YAxisLineColor_Gallery,
			TXITEM_YAxisLineColorSeperator2,
			TXITEM_YAxisLineColor_MoreColors,
			TXITEM_YAxisLineDashType,
			TXITEM_YAxisLineDashType_Dash,
			TXITEM_YAxisLineDashType_DashDot,
			TXITEM_YAxisLineDashType_DashDotDot,
			TXITEM_YAxisLineDashType_Dot,
			TXITEM_YAxisLineDashType_Solid,
			TXITEM_YAxisMajorGridlines,
			TXITEM_YAxisMajorGridlinesShow,
			TXITEM_YAxisMajorGridlinesColor,
			TXITEM_YAxisMajorGridlinesColor_Automatic,
			TXITEM_YAxisMajorGridlinesColorSeperator1,
			TXITEM_YAxisMajorGridlinesColor_Gallery,
			TXITEM_YAxisMajorGridlinesColorSeperator2,
			TXITEM_YAxisMajorGridlinesColor_MoreColors,
			TXITEM_YAxisMajorGridlinesDashType,
			TXITEM_YAxisMajorGridlinesDashType_Dash,
			TXITEM_YAxisMajorGridlinesDashType_DashDot,
			TXITEM_YAxisMajorGridlinesDashType_DashDotDot,
			TXITEM_YAxisMajorGridlinesDashType_Dot,
			TXITEM_YAxisMajorGridlinesDashType_Solid,
			TXITEM_YAxisMinorGridlines,
			TXITEM_YAxisMinorGridlinesShow,
			TXITEM_YAxisMinorGridlinesColor,
			TXITEM_YAxisMinorGridlinesColor_Automatic,
			TXITEM_YAxisMinorGridlinesColorSeperator1,
			TXITEM_YAxisMinorGridlinesColor_Gallery,
			TXITEM_YAxisMinorGridlinesColorSeperator2,
			TXITEM_YAxisMinorGridlinesColor_MoreColors,
			TXITEM_YAxisMinorGridlinesDashType,
			TXITEM_YAxisMinorGridlinesDashType_Dash,
			TXITEM_YAxisMinorGridlinesDashType_DashDot,
			TXITEM_YAxisMinorGridlinesDashType_DashDotDot,
			TXITEM_YAxisMinorGridlinesDashType_Dot,
			TXITEM_YAxisMinorGridlinesDashType_Solid,
			TXITEM_YAxisMinimum,
			TXITEM_YAxisMaximum,
			TXITEM_YAxisInterval,
			TXITEM_YAxisMinimumAutomatic,
			TXITEM_YAxisMaximumAutomatic,
			TXITEM_YAxisIntervalAutomatic
		}

		private Class501 class501_0;

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private List<Dictionary<string, object>> list_0 = new List<Dictionary<string, object>>();

		internal DataSourceManager dataSourceManager_0;

		protected override Padding DefaultPadding => new Padding(0);

		protected override Padding DefaultMargin => new Padding(0);

		public override string KeyTip
		{
			get
			{
				if (base.KeyTip == string.Empty)
				{
					return this.resourceManager_0.GetString("KEYTIP_ChartLayoutTab");
				}
				return base.KeyTip;
			}
			set
			{
				base.KeyTip = value;
			}
		}

		public override string Text
		{
			get
			{
				if (base.Text == string.Empty)
				{
					return this.resourceManager_0.GetString("HEADER_RibbonChartLayoutTab");
				}
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		internal override TextControl TextControl_0
		{
			get
			{
				return base.TextControl_0;
			}
			set
			{
				if (base.TextControl_0 == value)
				{
					return;
				}
				if (base.TextControl_0 != null)
				{
					this.class501_0.BindingAdapter_0.OnDisconnectingTextControl();
					this.class501_0.BindingAdapter_0.TextControl.PropertyChanged -= this.class501_0.vmethod_0;
				}
				TextControl textControl3 = (base.TextControl_0 = (this.class501_0.BindingAdapter_0.TextControl = value));
				if (base.TextControl_0 != null)
				{
					this.class501_0.BindingAdapter_0.OnTextControlConnected();
					if (this.class501_0.Boolean_0)
					{
						this.vmethod_0();
					}
					this.class501_0.BindingAdapter_0.TextControl.PropertyChanged += this.class501_0.vmethod_0;
				}
				this.class501_0.method_5();
			}
		}

		/// <summary>Initializes a new instance of the RibbonChartLayoutTab class.</summary>
		public RibbonChartLayoutTab()
		{
			this.method_3();
		}

		public Control FindItem(RibbonItem ribbonItem)
		{
			object value = null;
			foreach (Dictionary<string, object> item in this.list_0)
			{
				if (item.TryGetValue(ribbonItem.ToString(), out value))
				{
					return value as Control;
				}
			}
			return null;
		}

		public bool ShouldSerializeKeyTip()
		{
			return base.KeyTip != string.Empty;
		}

		public void ResetKeyTip()
		{
			this.KeyTip = string.Empty;
		}

		public bool ShouldSerializeText()
		{
			return base.Text != string.Empty;
		}

		internal void method_2(bool bool_3)
		{
			RibbonSplitButton obj = this.class501_0.TXITEM_LabelsGroup_Items[InternalRibbonItem.TXITEM_XAxisLabels.ToString()] as RibbonSplitButton;
			RibbonSplitButton obj2 = this.class501_0.TXITEM_LabelsGroup_Items[InternalRibbonItem.TXITEM_YAxisLabels.ToString()] as RibbonSplitButton;
			RibbonTextBox obj3 = this.class501_0.TXITEM_TitlesGroup_Items[InternalRibbonItem.TXITEM_XAxisTitle.ToString()] as RibbonTextBox;
			RibbonTextBox obj4 = this.class501_0.TXITEM_TitlesGroup_Items[InternalRibbonItem.TXITEM_YAxisTitle.ToString()] as RibbonTextBox;
			RibbonMenuButton obj5 = this.class501_0.TXITEM_TitlesGroup_Items[InternalRibbonItem.TXITEM_FormatXAxisTitle.ToString()] as RibbonMenuButton;
			RibbonMenuButton obj6 = this.class501_0.TXITEM_TitlesGroup_Items[InternalRibbonItem.TXITEM_FormatYAxisTitle.ToString()] as RibbonMenuButton;
			RibbonGroup obj7 = this.class501_0.TXITEM_XAxisGroup_Items[InternalRibbonItem.TXITEM_XAxisGroup.ToString()] as RibbonGroup;
			bool flag2 = ((this.class501_0.TXITEM_YAxisGroup_Items[InternalRibbonItem.TXITEM_YAxisGroup.ToString()] as RibbonGroup).Enabled = !bool_3);
			bool flag4 = (obj7.Enabled = flag2);
			bool flag6 = (obj6.Enabled = flag4);
			bool flag8 = (obj5.Enabled = flag6);
			bool flag10 = (obj4.Enabled = flag8);
			bool flag12 = (obj3.Enabled = flag10);
			bool enabled = (obj2.Enabled = flag12);
			obj.Enabled = enabled;
		}

		private void method_3()
		{
			this.class501_0 = new Class501(this, new Class472());
			this.class501_0.method_10(base.RibbonGroups);
			this.class501_0.method_11(base.RibbonGroups);
			this.class501_0.method_12(base.RibbonGroups);
			this.class501_0.method_13(base.RibbonGroups);
			this.class501_0.method_14(base.RibbonGroups);
			this.list_0.Add(this.class501_0.TXITEM_DataGroup_Items);
			this.list_0.Add(this.class501_0.TXITEM_LabelsGroup_Items);
			this.list_0.Add(this.class501_0.TXITEM_TitlesGroup_Items);
			this.list_0.Add(this.class501_0.TXITEM_XAxisGroup_Items);
			this.list_0.Add(this.class501_0.TXITEM_YAxisGroup_Items);
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			PointF dpi = base.method_0();
			this.class501_0.BindingAdapter_0.AwareOfDPI(dpi);
			Ribbon ribbon = base.Parent as Ribbon;
			if (ribbon != null)
			{
				foreach (RibbonTab control in ribbon.Controls)
				{
					if (control is RibbonReportingTab)
					{
						this.dataSourceManager_0 = (control as RibbonReportingTab).DataSourceManager;
						this.dataSourceManager_0.IsMergingPossibleChanged += dataSourceManager_0_IsMergingPossibleChanged;
						break;
					}
				}
			}
			RibbonButton ribbonButton = this.class501_0.TXITEM_DataGroup_Items[InternalRibbonItem.TXITEM_SetDataRelation.ToString()] as RibbonButton;
			if (this.dataSourceManager_0 == null)
			{
				(this.class501_0.TXITEM_DataGroup_Items[InternalRibbonItem.TXITEM_DataGroup.ToString()] as RibbonGroup).RibbonItems.Remove(ribbonButton);
			}
			else
			{
				ribbonButton.Enabled = this.dataSourceManager_0.IsMergingPossible;
			}
			base.OnHandleCreated(eventArgs_0);
		}

		internal override void vmethod_0(params object[] object_0)
		{
			this.class501_0.BindingAdapter_0.UpdateRibbonTab();
		}

		internal override void vmethod_1(uint uint_1)
		{
			base.vmethod_1(uint_1);
			this.class501_0.BindingAdapter_0.AwareOfDPI(base.method_0());
		}

		private void dataSourceManager_0_IsMergingPossibleChanged(object sender, EventArgs e)
		{
			(this.class501_0.TXITEM_DataGroup_Items[InternalRibbonItem.TXITEM_SetDataRelation.ToString()] as RibbonButton).Enabled = this.dataSourceManager_0.IsMergingPossible;
		}
	}
}
