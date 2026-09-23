using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using ns20;
using TXTextControl.Windows.Forms.Ribbon;
using TXTextControl.DataVisualization;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonFrameLayoutTab class represents a Windows Forms ribbon tab for editing objects of type Image, TextFrame, DrawingFrame, BarcodeFrame and ChartFrame.</summary>
	[ToolboxBitmap(typeof(RibbonFrameLayoutTab))]
	public class RibbonFrameLayoutTab : RibbonTab
	{
		/// <summary>Each RibbonItem represents an item in the RibbonFrameLayoutTab that is not a drop-down item.</summary>
		public enum RibbonItem
		{
			/// <summary>Identifies the TXITEM_ObjectArrangeGroup ribbon group inside the RibbonFrameLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_ObjectArrangeGroup,
			/// <summary>Identifies the dialog box launcher of the TXITEM_ObjectArrangeGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle and ToolTipDescription resources. Limitations: The FindItem method returns null when passing this RibbonItem as an argument.</summary>
			TXITEM_ObjectArrangeGroup_DialogBoxLauncher,
			/// <summary>Identifies the TXITEM_WrapText ribbon item inside the TXITEM_ObjectArrangeGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_WrapText,
			/// <summary>Identifies the TXITEM_BringToFront ribbon item inside the TXITEM_ObjectArrangeGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_BringToFront,
			/// <summary>Identifies the TXITEM_SendToBack ribbon item inside the TXITEM_ObjectArrangeGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_SendToBack,
			/// <summary>Identifies the TXITEM_Position ribbon item inside the TXITEM_ObjectArrangeGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Position,
			/// <summary>Identifies the TXITEM_ObjectSizeGroup ribbon group inside the RibbonFrameLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_ObjectSizeGroup,
			/// <summary>Identifies the dialog box launcher of the TXITEM_ObjectSizeGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle and ToolTipDescription resources. Limitations: The FindItem method returns null when passing this RibbonItem as an argument.</summary>
			TXITEM_ObjectSizeGroup_DialogBoxLauncher,
			/// <summary>Identifies the TXITEM_ObjectHeight ribbon item inside the TXITEM_ObjectSizeGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ObjectHeight,
			/// <summary>Identifies the TXITEM_ObjectWidth ribbon item inside the TXITEM_ObjectSizeGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ObjectWidth,
			/// <summary>Identifies the TXITEM_TextFrame_BordersandBackgroundGroup ribbon group inside the RibbonFrameLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_TextFrame_BordersandBackgroundGroup,
			/// <summary>Identifies the dialog box launcher of the TXITEM_TextFrame_BordersandBackgroundGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle and ToolTipDescription resources. Limitations: The FindItem method returns null when passing this RibbonItem as an argument.</summary>
			TXITEM_TextFrame_BordersandBackgroundGroup_DialogBoxLauncher,
			/// <summary>Identifies the TXITEM_TextFrameBackColor ribbon item inside the TXITEM_TextFrame_BordersandBackgroundGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TextFrameBackColor,
			/// <summary>Identifies the TXITEM_TextFrameTransparency ribbon item inside the TXITEM_TextFrame_BordersandBackgroundGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TextFrameTransparency,
			/// <summary>Identifies the TXITEM_TextFrameLineWidth ribbon item inside the TXITEM_TextFrame_BordersandBackgroundGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TextFrameLineWidth,
			/// <summary>Identifies the TXITEM_Drawing_BordersandBackgroundGroup ribbon group inside the RibbonFrameLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_Drawing_BordersandBackgroundGroup,
			/// <summary>Identifies the dialog box launcher of the TXITEM_Drawing_BordersandBackgroundGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle and ToolTipDescription resources. Limitations: The FindItem method returns null when passing this RibbonItem as an argument.</summary>
			TXITEM_Drawing_BordersandBackgroundGroup_DialogBoxLauncher,
			/// <summary>Identifies the TXITEM_DrawingLineColor ribbon item inside the TXITEM_Drawing_BordersandBackgroundGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DrawingLineColor,
			/// <summary>Identifies the TXITEM_DrawingBackColor ribbon item inside the TXITEM_Drawing_BordersandBackgroundGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DrawingBackColor,
			/// <summary>Identifies the TXITEM_DrawingLineWidth ribbon item inside the TXITEM_Drawing_BordersandBackgroundGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DrawingLineWidth,
			/// <summary>Identifies the TXITEM_DrawingTransparency ribbon item inside the TXITEM_Drawing_BordersandBackgroundGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DrawingTransparency,
			/// <summary>Identifies the TXITEM_DrawingRotation ribbon item inside the TXITEM_Drawing_BordersandBackgroundGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DrawingRotation,
			/// <summary>Identifies the TXITEM_Barcode_ColorsAndAlignmentGroup ribbon group inside the RibbonFrameLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_Barcode_ColorsAndAlignmentGroup,
			/// <summary>Identifies the dialog box launcher of the TXITEM_Barcode_ColorsAndAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle and ToolTipDescription resources. Limitations: The FindItem method returns null when passing this RibbonItem as an argument.</summary>
			TXITEM_Barcode_ColorsAndAlignmentGroup_DialogBoxLauncher,
			/// <summary>Identifies the TXITEM_BarcodeForeColor ribbon item inside the TXITEM_Barcode_ColorsAndAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_BarcodeForeColor,
			/// <summary>Identifies the TXITEM_BarcodeBackColor ribbon item inside the TXITEM_Barcode_ColorsAndAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_BarcodeBackColor,
			/// <summary>Identifies the TXITEM_BarcodeTransparency ribbon item inside the TXITEM_Barcode_ColorsAndAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_BarcodeTransparency,
			/// <summary>Identifies the TXITEM_BarcodeHorizontalAlignment ribbon item inside the TXITEM_Barcode_ColorsAndAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_BarcodeHorizontalAlignment,
			/// <summary>Identifies the TXITEM_BarcodeVerticalAlignment ribbon item inside the TXITEM_Barcode_ColorsAndAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_BarcodeVerticalAlignment,
			/// <summary>Identifies the TXITEM_BarcodeRotation ribbon item inside the TXITEM_Barcode_ColorsAndAlignmentGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_BarcodeRotation,
			/// <summary>Identifies the TXITEM_Chart_TypeAndAppearanceGroup ribbon group inside the RibbonFrameLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_Chart_TypeAndAppearanceGroup,
			/// <summary>Identifies the dialog box launcher of the TXITEM_Chart_TypeAndAppearanceGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle and ToolTipDescription resources. Limitations: The FindItem method returns null when passing this RibbonItem as an argument.</summary>
			TXITEM_Chart_TypeAndAppearanceGroup_DialogBoxLauncher,
			/// <summary>Identifies the TXITEM_ChartType ribbon item inside the TXITEM_Chart_TypeAndAppearanceGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ChartType,
			/// <summary>Identifies the TXITEM_ChartIs3D ribbon item inside the TXITEM_Chart_TypeAndAppearanceGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ChartIs3D,
			/// <summary>Identifies the TXITEM_ChartRotation ribbon item inside the TXITEM_Chart_TypeAndAppearanceGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ChartRotation,
			/// <summary>Identifies the TXITEM_ChartHasRightAngleAxes ribbon item inside the TXITEM_Chart_TypeAndAppearanceGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ChartHasRightAngleAxes,
			/// <summary>Identifies the TXITEM_ChartInclination ribbon item inside the TXITEM_Chart_TypeAndAppearanceGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ChartInclination,
			/// <summary>Identifies the TXITEM_ChartPerspective ribbon item inside the TXITEM_Chart_TypeAndAppearanceGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ChartPerspective,
			/// <summary>Identifies the TXITEM_ObjectPropertiesGroup ribbon group inside the RibbonFrameLayoutTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_ObjectPropertiesGroup,
			/// <summary>Identifies the TXITEM_ObjectName ribbon item inside the TXITEM_ObjectPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ObjectName,
			/// <summary>Identifies the TXITEM_ObjectID ribbon item inside the TXITEM_ObjectPropertiesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ObjectID
		}

		/// <summary>Each RibbonDropDownItem represents a drop-down item in the RibbonFrameLayoutTab.</summary>
		public enum RibbonDropDownItem
		{
			/// <summary>Identifies the TXITEM_WrapText_InLineWithText drop-down item inside the TXITEM_WrapText's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_WrapText_InLineWithText,
			/// <summary>Identifies the TXITEM_WrapText_TopAndBottom drop-down item inside the TXITEM_WrapText's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_WrapText_TopAndBottom,
			/// <summary>Identifies the TXITEM_WrapText_Square drop-down item inside the TXITEM_WrapText's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_WrapText_Square,
			/// <summary>Identifies the TXITEM_WrapText_BehindText drop-down item inside the TXITEM_WrapText's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_WrapText_BehindText,
			/// <summary>Identifies the TXITEM_WrapText_InFrontOfText drop-down item inside the TXITEM_WrapText's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_WrapText_InFrontOfText,
			/// <summary>Identifies the TXITEM_WrapText_MoreLayoutOptions drop-down item inside the TXITEM_WrapText's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_WrapText_MoreLayoutOptions,
			/// <summary>Identifies the TXITEM_BringToFront_ToFront drop-down item inside the TXITEM_BringToFront's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_BringToFront_ToFront,
			/// <summary>Identifies the TXITEM_BringToFront_Forward drop-down item inside the TXITEM_BringToFront's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_BringToFront_Forward,
			/// <summary>Identifies the TXITEM_BringToFront_InFrontOfText drop-down item inside the TXITEM_BringToFront's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_BringToFront_InFrontOfText,
			/// <summary>Identifies the TXITEM_SendToBack_ToBack drop-down item inside the TXITEM_SendToBack's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_SendToBack_ToBack,
			/// <summary>Identifies the TXITEM_SendToBack_Backward drop-down item inside the TXITEM_SendToBack's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text and ToolTipTitle resources.</summary>
			TXITEM_SendToBack_Backward,
			/// <summary>Identifies the TXITEM_SendToBack_BehindText drop-down item inside the TXITEM_SendToBack's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_SendToBack_BehindText,
			/// <summary>Identifies the TXITEM_Position_Left drop-down item inside the TXITEM_Position's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_Position_Left,
			/// <summary>Identifies the TXITEM_Position_Center drop-down item inside the TXITEM_Position's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_Position_Center,
			/// <summary>Identifies the TXITEM_Position_Right drop-down item inside the TXITEM_Position's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_Position_Right,
			/// <summary>Identifies the TXITEM_Position_OtherPosition drop-down item inside the TXITEM_Position's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_Position_OtherPosition,
			/// <summary>Identifies the TXITEM_TextFrameBackColor_Automatic drop-down item inside the TXITEM_TextFrameBackColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TextFrameBackColor_Automatic,
			/// <summary>Identifies the TXITEM_TextFrameBackColor_MoreColors drop-down item inside the TXITEM_TextFrameBackColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TextFrameBackColor_MoreColors,
			/// <summary>Identifies the TXITEM_TextFrameTransparency_0 drop-down item inside the TXITEM_TextFrameTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_TextFrameTransparency_0,
			/// <summary>Identifies the TXITEM_TextFrameTransparency_10 drop-down item inside the TXITEM_TextFrameTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_TextFrameTransparency_10,
			/// <summary>Identifies the TXITEM_TextFrameTransparency_20 drop-down item inside the TXITEM_TextFrameTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_TextFrameTransparency_20,
			/// <summary>Identifies the TXITEM_TextFrameTransparency_30 drop-down item inside the TXITEM_TextFrameTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_TextFrameTransparency_30,
			/// <summary>Identifies the TXITEM_TextFrameTransparency_40 drop-down item inside the TXITEM_TextFrameTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_TextFrameTransparency_40,
			/// <summary>Identifies the TXITEM_TextFrameTransparency_50 drop-down item inside the TXITEM_TextFrameTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_TextFrameTransparency_50,
			/// <summary>Identifies the TXITEM_TextFrameTransparency_60 drop-down item inside the TXITEM_TextFrameTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_TextFrameTransparency_60,
			/// <summary>Identifies the TXITEM_TextFrameTransparency_70 drop-down item inside the TXITEM_TextFrameTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_TextFrameTransparency_70,
			/// <summary>Identifies the TXITEM_TextFrameTransparency_80 drop-down item inside the TXITEM_TextFrameTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_TextFrameTransparency_80,
			/// <summary>Identifies the TXITEM_TextFrameTransparency_90 drop-down item inside the TXITEM_TextFrameTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_TextFrameTransparency_90,
			/// <summary>Identifies the TXITEM_TextFrameTransparency_100 drop-down item inside the TXITEM_TextFrameTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_TextFrameTransparency_100,
			/// <summary>Identifies the TXITEM_TextFrameLineWidth_NoLine drop-down item inside the TXITEM_TextFrameLineWidth's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_TextFrameLineWidth_NoLine,
			/// <summary>Identifies the TXITEM_DrawingLineColor_Automatic drop-down item inside the TXITEM_DrawingLineColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_DrawingLineColor_Automatic,
			/// <summary>Identifies the TXITEM_DrawingLineColor_MoreColors drop-down item inside the TXITEM_DrawingLineColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_DrawingLineColor_MoreColors,
			/// <summary>Identifies the TXITEM_DrawingBackColor_Automatic drop-down item inside the TXITEM_DrawingBackColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_DrawingBackColor_Automatic,
			/// <summary>Identifies the TXITEM_DrawingBackColor_MoreColors drop-down item inside the TXITEM_DrawingBackColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_DrawingBackColor_MoreColors,
			/// <summary>Identifies the TXITEM_DrawingLineWidth_NoLine drop-down item inside the TXITEM_DrawingLineWidth's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_DrawingLineWidth_NoLine,
			/// <summary>Identifies the TXITEM_DrawingTransparency_0 drop-down item inside the TXITEM_DrawingTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_DrawingTransparency_0,
			/// <summary>Identifies the TXITEM_DrawingTransparency_10 drop-down item inside the TXITEM_DrawingTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_DrawingTransparency_10,
			/// <summary>Identifies the TXITEM_DrawingTransparency_20 drop-down item inside the TXITEM_DrawingTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_DrawingTransparency_20,
			/// <summary>Identifies the TXITEM_DrawingTransparency_30 drop-down item inside the TXITEM_DrawingTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_DrawingTransparency_30,
			/// <summary>Identifies the TXITEM_DrawingTransparency_40 drop-down item inside the TXITEM_DrawingTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_DrawingTransparency_40,
			/// <summary>Identifies the TXITEM_DrawingTransparency_50 drop-down item inside the TXITEM_DrawingTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_DrawingTransparency_50,
			/// <summary>Identifies the TXITEM_DrawingTransparency_60 drop-down item inside the TXITEM_DrawingTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_DrawingTransparency_60,
			/// <summary>Identifies the TXITEM_DrawingTransparency_70 drop-down item inside the TXITEM_DrawingTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_DrawingTransparency_70,
			/// <summary>Identifies the TXITEM_DrawingTransparency_80 drop-down item inside the TXITEM_DrawingTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_DrawingTransparency_80,
			/// <summary>Identifies the TXITEM_DrawingTransparency_90 drop-down item inside the TXITEM_DrawingTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_DrawingTransparency_90,
			/// <summary>Identifies the TXITEM_DrawingTransparency_100 drop-down item inside the TXITEM_DrawingTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_DrawingTransparency_100,
			/// <summary>Identifies the TXITEM_DrawingRotation_Right90 drop-down item inside the TXITEM_DrawingRotation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_DrawingRotation_Right90,
			/// <summary>Identifies the TXITEM_DrawingRotation_Left90 drop-down item inside the TXITEM_DrawingRotation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_DrawingRotation_Left90,
			/// <summary>Identifies the TXITEM_DrawingRotation_FlipHorizontal drop-down item inside the TXITEM_DrawingRotation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_DrawingRotation_FlipHorizontal,
			/// <summary>Identifies the TXITEM_DrawingRotation_FlipVertical drop-down item inside the TXITEM_DrawingRotation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_DrawingRotation_FlipVertical,
			/// <summary>Identifies the TXITEM_DrawingRotation_MoreRotationOptions drop-down item inside the TXITEM_DrawingRotation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_DrawingRotation_MoreRotationOptions,
			/// <summary>Identifies the TXITEM_BarcodeForeColor_Automatic drop-down item inside the TXITEM_BarcodeForeColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BarcodeForeColor_Automatic,
			/// <summary>Identifies the TXITEM_BarcodeForeColor_MoreColors drop-down item inside the TXITEM_BarcodeForeColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BarcodeForeColor_MoreColors,
			/// <summary>Identifies the TXITEM_BarcodeBackColor_Automatic drop-down item inside the TXITEM_BarcodeBackColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BarcodeBackColor_Automatic,
			/// <summary>Identifies the TXITEM_BarcodeBackColor_MoreColors drop-down item inside the TXITEM_BarcodeBackColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BarcodeBackColor_MoreColors,
			/// <summary>Identifies the TXITEM_BarcodeTransparency_0 drop-down item inside the TXITEM_BarcodeTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_BarcodeTransparency_0,
			/// <summary>Identifies the TXITEM_BarcodeTransparency_10 drop-down item inside the TXITEM_BarcodeTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_BarcodeTransparency_10,
			/// <summary>Identifies the TXITEM_BarcodeTransparency_20 drop-down item inside the TXITEM_BarcodeTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_BarcodeTransparency_20,
			/// <summary>Identifies the TXITEM_BarcodeTransparency_30 drop-down item inside the TXITEM_BarcodeTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_BarcodeTransparency_30,
			/// <summary>Identifies the TXITEM_BarcodeTransparency_40 drop-down item inside the TXITEM_BarcodeTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_BarcodeTransparency_40,
			/// <summary>Identifies the TXITEM_BarcodeTransparency_50 drop-down item inside the TXITEM_BarcodeTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_BarcodeTransparency_50,
			/// <summary>Identifies the TXITEM_BarcodeTransparency_60 drop-down item inside the TXITEM_BarcodeTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_BarcodeTransparency_60,
			/// <summary>Identifies the TXITEM_BarcodeTransparency_70 drop-down item inside the TXITEM_BarcodeTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_BarcodeTransparency_70,
			/// <summary>Identifies the TXITEM_BarcodeTransparency_80 drop-down item inside the TXITEM_BarcodeTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_BarcodeTransparency_80,
			/// <summary>Identifies the TXITEM_BarcodeTransparency_90 drop-down item inside the TXITEM_BarcodeTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_BarcodeTransparency_90,
			/// <summary>Identifies the TXITEM_BarcodeTransparency_100 drop-down item inside the TXITEM_BarcodeTransparency's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_BarcodeTransparency_100,
			/// <summary>Identifies the TXITEM_BarcodeHorizontalAlignment_Left drop-down item inside the TXITEM_BarcodeHorizontalAlignment's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BarcodeHorizontalAlignment_Left,
			/// <summary>Identifies the TXITEM_BarcodeHorizontalAlignment_Center drop-down item inside the TXITEM_BarcodeHorizontalAlignment's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BarcodeHorizontalAlignment_Center,
			/// <summary>Identifies the TXITEM_BarcodeHorizontalAlignment_Right drop-down item inside the TXITEM_BarcodeHorizontalAlignment's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BarcodeHorizontalAlignment_Right,
			/// <summary>Identifies the TXITEM_BarcodeVerticalAlignment_Top drop-down item inside the TXITEM_BarcodeVerticalAlignment's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BarcodeVerticalAlignment_Top,
			/// <summary>Identifies the TXITEM_BarcodeVerticalAlignment_Middle drop-down item inside the TXITEM_BarcodeVerticalAlignment's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BarcodeVerticalAlignment_Middle,
			/// <summary>Identifies the TXITEM_BarcodeVerticalAlignment_Bottom drop-down item inside the TXITEM_BarcodeVerticalAlignment's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BarcodeVerticalAlignment_Bottom,
			/// <summary>Identifies the TXITEM_BarcodeRotation_Right90 drop-down item inside the TXITEM_BarcodeRotation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BarcodeRotation_Right90,
			/// <summary>Identifies the TXITEM_BarcodeRotation_Left90 drop-down item inside the TXITEM_BarcodeRotation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BarcodeRotation_Left90,
			/// <summary>Identifies the TXITEM_BarcodeRotation_180 drop-down item inside the TXITEM_BarcodeRotation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BarcodeRotation_180,
			/// <summary>Identifies the TXITEM_BarcodeRotation_MoreRotationOptions drop-down item inside the TXITEM_BarcodeRotation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BarcodeRotation_MoreRotationOptions,
			/// <summary>Identifies the TXITEM_ChartRotation_Right90 drop-down item inside the TXITEM_ChartRotation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChartRotation_Right90,
			/// <summary>Identifies the TXITEM_ChartRotation_Left90 drop-down item inside the TXITEM_ChartRotation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChartRotation_Left90,
			/// <summary>Identifies the TXITEM_ChartRotation_180 drop-down item inside the TXITEM_ChartRotation's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChartRotation_180,
			/// <summary>Identifies the TXITEM_ChartInclination_0 drop-down item inside the TXITEM_ChartInclination's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChartInclination_0,
			/// <summary>Identifies the TXITEM_ChartInclination_30 drop-down item inside the TXITEM_ChartInclination's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChartInclination_30,
			/// <summary>Identifies the TXITEM_ChartInclination_60 drop-down item inside the TXITEM_ChartInclination's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChartInclination_60,
			/// <summary>Identifies the TXITEM_ChartPerspective_Telephoto drop-down item inside the TXITEM_ChartPerspective's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChartPerspective_Telephoto,
			/// <summary>Identifies the TXITEM_ChartPerspective_Normal drop-down item inside the TXITEM_ChartPerspective's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChartPerspective_Normal,
			/// <summary>Identifies the TXITEM_ChartPerspective_WideAngle drop-down item inside the TXITEM_ChartPerspective's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChartPerspective_WideAngle
		}

		internal enum InternalRibbonItem
		{
			TXITEM_ObjectArrangeGroup,
			TXITEM_ObjectArrangeGroup_DialogBoxLauncher,
			TXITEM_WrapText,
			TXITEM_WrapText_InLineWithText,
			TXITEM_WrapText_TopAndBottom,
			TXITEM_WrapText_Square,
			TXITEM_WrapText_BehindText,
			TXITEM_WrapText_InFrontOfText,
			TXITEM_WrapTextSeperator1,
			TXITEM_WrapText_MoreLayoutOptions,
			TXITEM_BringToFront,
			TXITEM_BringToFront_ToFront,
			TXITEM_BringToFront_Forward,
			TXITEM_BringToFront_InFrontOfText,
			TXITEM_SendToBack,
			TXITEM_SendToBack_ToBack,
			TXITEM_SendToBack_Backward,
			TXITEM_SendToBack_BehindText,
			TXITEM_Position,
			TXITEM_Position_Left,
			TXITEM_Position_Center,
			TXITEM_Position_Right,
			TXITEM_PositionSeperator1,
			TXITEM_Position_OtherPosition,
			TXITEM_ObjectSizeGroup,
			TXITEM_ObjectSizeGroup_DialogBoxLauncher,
			TXITEM_ObjectHeight,
			TXITEM_ObjectWidth,
			TXITEM_ObjectPropertiesGroup,
			TXITEM_ObjectName,
			TXITEM_ObjectID,
			TXITEM_TextFrame_BordersandBackgroundGroup,
			TXITEM_TextFrame_BordersandBackgroundGroup_DialogBoxLauncher,
			TXITEM_TextFrameBackColor,
			TXITEM_TextFrameBackColor_Automatic,
			TXITEM_TextFrameBackColorSeperator1,
			TXITEM_TextFrameBackColor_Gallery,
			TXITEM_TextFrameBackColorSeperator2,
			TXITEM_TextFrameBackColor_MoreColors,
			TXITEM_TextFrameTransparency,
			TXITEM_TextFrameTransparency_0,
			TXITEM_TextFrameTransparency_10,
			TXITEM_TextFrameTransparency_20,
			TXITEM_TextFrameTransparency_30,
			TXITEM_TextFrameTransparency_40,
			TXITEM_TextFrameTransparency_50,
			TXITEM_TextFrameTransparency_60,
			TXITEM_TextFrameTransparency_70,
			TXITEM_TextFrameTransparency_80,
			TXITEM_TextFrameTransparency_90,
			TXITEM_TextFrameTransparency_100,
			TXITEM_TextFrameLineWidth,
			TXITEM_TextFrameLineWidth_NoLine,
			TXITEM_TextFrameLineWidthSeperator1,
			TXITEM_TextFrameLineWidth_25,
			TXITEM_TextFrameLineWidth_50,
			TXITEM_TextFrameLineWidth_75,
			TXITEM_TextFrameLineWidth_100,
			TXITEM_TextFrameLineWidth_150,
			TXITEM_TextFrameLineWidth_225,
			TXITEM_TextFrameLineWidth_300,
			TXITEM_TextFrameLineWidth_450,
			TXITEM_TextFrameLineWidth_600,
			TXITEM_Drawing_BordersandBackgroundGroup,
			TXITEM_Drawing_BordersandBackgroundGroup_DialogBoxLauncher,
			TXITEM_DrawingLineColor,
			TXITEM_DrawingLineColor_Automatic,
			TXITEM_DrawingLineColorSeperator1,
			TXITEM_DrawingLineColor_Gallery,
			TXITEM_DrawingLineColorSeperator2,
			TXITEM_DrawingLineColor_MoreColors,
			TXITEM_DrawingBackColor,
			TXITEM_DrawingBackColor_Automatic,
			TXITEM_DrawingBackColorSeperator1,
			TXITEM_DrawingBackColor_Gallery,
			TXITEM_DrawingBackColorSeperator2,
			TXITEM_DrawingBackColor_MoreColors,
			TXITEM_DrawingLineWidth,
			TXITEM_DrawingLineWidth_NoLine,
			TXITEM_DrawingLineWidthSeperator1,
			TXITEM_DrawingLineWidth_25,
			TXITEM_DrawingLineWidth_50,
			TXITEM_DrawingLineWidth_75,
			TXITEM_DrawingLineWidth_100,
			TXITEM_DrawingLineWidth_150,
			TXITEM_DrawingLineWidth_225,
			TXITEM_DrawingLineWidth_300,
			TXITEM_DrawingLineWidth_450,
			TXITEM_DrawingLineWidth_600,
			TXITEM_DrawingTransparency,
			TXITEM_DrawingTransparency_0,
			TXITEM_DrawingTransparency_10,
			TXITEM_DrawingTransparency_20,
			TXITEM_DrawingTransparency_30,
			TXITEM_DrawingTransparency_40,
			TXITEM_DrawingTransparency_50,
			TXITEM_DrawingTransparency_60,
			TXITEM_DrawingTransparency_70,
			TXITEM_DrawingTransparency_80,
			TXITEM_DrawingTransparency_90,
			TXITEM_DrawingTransparency_100,
			TXITEM_DrawingRotation,
			TXITEM_DrawingRotation_Right90,
			TXITEM_DrawingRotation_Left90,
			TXITEM_DrawingRotation_FlipVertical,
			TXITEM_DrawingRotation_FlipHorizontal,
			TXITEM_DrawingRotationSeperator1,
			TXITEM_DrawingRotation_MoreRotationOptions,
			TXITEM_Barcode_ColorsAndAlignmentGroup,
			TXITEM_Barcode_ColorsAndAlignmentGroup_DialogBoxLauncher,
			TXITEM_BarcodeForeColor,
			TXITEM_BarcodeForeColor_Automatic,
			TXITEM_BarcodeForeColorSeperator1,
			TXITEM_BarcodeForeColor_Gallery,
			TXITEM_BarcodeForeColorSeperator2,
			TXITEM_BarcodeForeColor_MoreColors,
			TXITEM_BarcodeBackColor,
			TXITEM_BarcodeBackColor_Automatic,
			TXITEM_BarcodeBackColorSeperator1,
			TXITEM_BarcodeBackColor_Gallery,
			TXITEM_BarcodeBackColorSeperator2,
			TXITEM_BarcodeBackColor_MoreColors,
			TXITEM_BarcodeTransparency,
			TXITEM_BarcodeTransparency_0,
			TXITEM_BarcodeTransparency_20,
			TXITEM_BarcodeTransparency_40,
			TXITEM_BarcodeTransparency_60,
			TXITEM_BarcodeTransparency_80,
			TXITEM_BarcodeTransparency_100,
			TXITEM_BarcodeHorizontalAlignment,
			TXITEM_BarcodeHorizontalAlignment_Left,
			TXITEM_BarcodeHorizontalAlignment_Center,
			TXITEM_BarcodeHorizontalAlignment_Right,
			TXITEM_BarcodeVerticalAlignment,
			TXITEM_BarcodeVerticalAlignment_Top,
			TXITEM_BarcodeVerticalAlignment_Middle,
			TXITEM_BarcodeVerticalAlignment_Bottom,
			TXITEM_BarcodeRotation,
			TXITEM_BarcodeRotation_Right90,
			TXITEM_BarcodeRotation_Left90,
			TXITEM_BarcodeRotation_180,
			TXITEM_BarcodeRotationSeperator1,
			TXITEM_BarcodeRotation_MoreRotationOptions,
			TXITEM_Chart_TypeAndAppearanceGroup,
			TXITEM_Chart_TypeAndAppearanceGroup_DialogBoxLauncher,
			TXITEM_ChartType,
			TXITEM_ChartType_ColumnCategory,
			TXITEM_ChartType_ColumnGallery,
			TXITEM_ChartType_LineSeperator,
			TXITEM_ChartType_LineCategory,
			TXITEM_ChartType_LineGallery,
			TXITEM_ChartType_PieSeperator,
			TXITEM_ChartType_PieCategory,
			TXITEM_ChartType_PieGallery,
			TXITEM_ChartType_BarSeperator,
			TXITEM_ChartType_BarCategory,
			TXITEM_ChartType_BarGallery,
			TXITEM_ChartType_AreaSeperator,
			TXITEM_ChartType_AreaCategory,
			TXITEM_ChartType_AreaGallery,
			TXITEM_ChartType_XYScatterSeperator,
			TXITEM_ChartType_XYScatterCategory,
			TXITEM_ChartType_XYScatterGallery,
			TXITEM_ChartType_StockSeperator,
			TXITEM_ChartType_StockCategory,
			TXITEM_ChartType_StockGallery,
			TXITEM_ChartType_SurfaceSeperator,
			TXITEM_ChartType_SurfaceCategory,
			TXITEM_ChartType_SurfaceGallery,
			TXITEM_ChartType_RadarSeperator,
			TXITEM_ChartType_RadarCategory,
			TXITEM_ChartType_RadarGallery,
			TXITEM_ChartType_ComboSeperator,
			TXITEM_ChartType_ComboCategory,
			TXITEM_ChartType_ComboGallery,
			TXITEM_ChartIs3D,
			TXITEM_ChartRotation,
			TXITEM_ChartRotation_Right90,
			TXITEM_ChartRotation_Left90,
			TXITEM_ChartRotation_180,
			TXITEM_ChartHasRightAngleAxes,
			TXITEM_ChartInclination,
			TXITEM_ChartInclination_0,
			TXITEM_ChartInclination_30,
			TXITEM_ChartInclination_60,
			TXITEM_ChartPerspective,
			TXITEM_ChartPerspective_Telephoto,
			TXITEM_ChartPerspective_Normal,
			TXITEM_ChartPerspective_WideAngle
		}

		private Class505 class505_0;

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private List<Dictionary<string, object>> list_0 = new List<Dictionary<string, object>>();

		protected override Padding DefaultPadding => new Padding(0);

		protected override Padding DefaultMargin => new Padding(0);

		public override string KeyTip
		{
			get
			{
				if (base.KeyTip == string.Empty)
				{
					return this.resourceManager_0.GetString("KEYTIP_FrameLayoutTab");
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
					return this.resourceManager_0.GetString("HEADER_RibbonFrameLayoutTab");
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
				Class476 @class = this.class505_0.BindingAdapter_0 as Class476;
				Control7 control = null;
				BarcodeFrame barcodeFrame_;
				if (base.TextControl_0 != null)
				{
					this.class505_0.BindingAdapter_0.OnDisconnectingTextControl();
					this.class505_0.BindingAdapter_0.TextControl.PropertyChanged -= this.class505_0.vmethod_0;
					control = @class.method_27(null, out barcodeFrame_);
					if (control != null)
					{
						control.PropertyChanged -= @class.method_149;
					}
				}
				TextControl textControl3 = (base.TextControl_0 = (this.class505_0.BindingAdapter_0.TextControl = value));
				this.class505_0.BindingAdapter_0.SetDialogUnit();
				if (base.TextControl_0 != null)
				{
					this.class505_0.BindingAdapter_0.OnTextControlConnected();
					if (this.class505_0.Boolean_0)
					{
						this.vmethod_0();
					}
					this.class505_0.BindingAdapter_0.TextControl.PropertyChanged += this.class505_0.vmethod_0;
					control = @class.method_27(null, out barcodeFrame_);
					if (control != null)
					{
						control.PropertyChanged -= @class.method_149;
						control.PropertyChanged += @class.method_149;
					}
				}
				this.class505_0.method_5();
			}
		}

		/// <summary>Initializes a new instance of the RibbonFrameLayoutTab class.</summary>
		public RibbonFrameLayoutTab()
		{
			this.method_2();
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			PointF dpi = base.method_0();
			this.class505_0.BindingAdapter_0.AwareOfDPI(dpi);
			base.OnHandleCreated(eventArgs_0);
		}

		internal override void vmethod_0(params object[] object_0)
		{
			this.class505_0.BindingAdapter_0.UpdateRibbonTab();
		}

		internal override void vmethod_1(uint uint_1)
		{
			base.vmethod_1(uint_1);
			this.class505_0.BindingAdapter_0.AwareOfDPI(base.method_0());
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

		private void method_2()
		{
			this.class505_0 = new Class505(this, new Class476());
			this.class505_0.method_10(base.RibbonGroups);
			this.class505_0.method_11(base.RibbonGroups);
			this.class505_0.method_13(base.RibbonGroups);
			this.class505_0.method_14(base.RibbonGroups);
			this.class505_0.method_15(base.RibbonGroups);
			this.class505_0.method_16(base.RibbonGroups);
			this.class505_0.method_12(base.RibbonGroups);
			this.list_0.Add(this.class505_0.TXITEM_ObjectArrangeGroup_Items);
			this.list_0.Add(this.class505_0.TXITEM_ObjectSizeGroup_Items);
			this.list_0.Add(this.class505_0.TXITEM_ObjectPropertiesGroup_Items);
			this.list_0.Add(this.class505_0.TXITEM_TextFrame_BordersandBackgroundGroup_Items);
			this.list_0.Add(this.class505_0.TXITEM_Drawing_BordersandBackgroundGroup_Items);
			this.list_0.Add(this.class505_0.TXITEM_Barcode_ColorsAndAlignmentGroup_Items);
		}
	}
}
