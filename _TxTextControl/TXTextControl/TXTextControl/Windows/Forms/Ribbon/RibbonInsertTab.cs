using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonInsertTab class represents a Windows Forms ribbon tab for inserting pages, images, charts, shapes, hyperlinks, bookmarks, headers and footers, textframes and symbols.</summary>
	[ToolboxBitmap(typeof(RibbonInsertTab))]
	public class RibbonInsertTab : RibbonTab
	{
		/// <summary>Each RibbonItem represents an item in the RibbonInsertTab that is not a drop-down item.</summary>
		public enum RibbonItem
		{
			/// <summary>Identifies the TXITEM_PageGroup ribbon group inside the RibbonInsertTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_PageGroup,
			/// <summary>Identifies the TXITEM_InsertPage ribbon item inside the TXITEM_PageGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertPage,
			/// <summary>Identifies the TXITEM_InsertPageBreak ribbon item inside the TXITEM_PageGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertPageBreak,
			/// <summary>Identifies the TXITEM_TableGroup ribbon group inside the RibbonInsertTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_TableGroup,
			/// <summary>Identifies the TXITEM_InsertTable ribbon item inside the TXITEM_TableGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertTable,
			/// <summary>Identifies the TXITEM_IllustrationsGroup ribbon group inside the RibbonInsertTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_IllustrationsGroup,
			/// <summary>Identifies the TXITEM_InsertImage ribbon item inside the TXITEM_IllustrationsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertImage,
			/// <summary>Identifies the TXITEM_InsertChart ribbon item inside the TXITEM_IllustrationsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_InsertChart,
			/// <summary>Identifies the TXITEM_InsertShape ribbon item inside the TXITEM_IllustrationsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertShape,
			/// <summary>Identifies the TXITEM_InsertBarcode ribbon item inside the TXITEM_IllustrationsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertBarcode,
			/// <summary>Identifies the TXITEM_LinksGroup ribbon group inside the RibbonInsertTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_LinksGroup,
			/// <summary>Identifies the TXITEM_InsertHyperlink ribbon item inside the TXITEM_LinksGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertHyperlink,
			/// <summary>Identifies the TXITEM_InsertBookmark ribbon item inside the TXITEM_LinksGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertBookmark,
			/// <summary>Identifies the TXITEM_HeaderFooterGroup ribbon group inside the RibbonInsertTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_HeaderFooterGroup,
			/// <summary>Identifies the TXITEM_InsertHeader ribbon item inside the TXITEM_HeaderFooterGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertHeader,
			/// <summary>Identifies the TXITEM_InsertFooter ribbon item inside the TXITEM_HeaderFooterGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertFooter,
			/// <summary>Identifies the TXITEM_InsertPageNumber ribbon item inside the TXITEM_HeaderFooterGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertPageNumber,
			/// <summary>Identifies the TXITEM_TextGroup ribbon group inside the RibbonInsertTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_TextGroup,
			/// <summary>Identifies the TXITEM_InsertTextFrame ribbon item inside the TXITEM_TextGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertTextFrame,
			/// <summary>Identifies the TXITEM_InsertFile ribbon item inside the TXITEM_TextGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertFile,
			/// <summary>Identifies the TXITEM_SymbolsGroup ribbon group inside the RibbonInsertTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_SymbolsGroup,
			/// <summary>Identifies the TXITEM_InsertSymbol ribbon item inside the TXITEM_SymbolsGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_InsertSymbol
		}

		/// <summary>Each RibbonDropDownItem represents a drop-down item in the RibbonInsertTab.</summary>
		public enum RibbonDropDownItem
		{
			/// <summary>Identifies the TXITEM_InsertTableGallery drop-down item inside the TXITEM_InsertTable's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_InsertTableGallery,
			/// <summary>Identifies the TXITEM_InsertTableDialog drop-down item inside the TXITEM_InsertTable's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_InsertTableDialog,
			/// <summary>Identifies the TXITEM_InsertImageDialog drop-down item inside the TXITEM_InsertImage's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_InsertImageDialog,
			/// <summary>Identifies the TXITEM_InsertImagePlaceHolder drop-down item inside the TXITEM_InsertImage's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_InsertImagePlaceHolder,
			/// <summary>Identifies the TXITEM_LinesCategory drop-down item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_LinesCategory,
			/// <summary>Identifies the TXITEM_RectanglesCategory drop-down item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_RectanglesCategory,
			/// <summary>Identifies the TXITEM_BasicShapesCategory drop-down item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_BasicShapesCategory,
			/// <summary>Identifies the TXITEM_BlockArrowsCategory drop-down item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_BlockArrowsCategory,
			/// <summary>Identifies the TXITEM_EquationShapesCategory drop-down item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_EquationShapesCategory,
			/// <summary>Identifies the TXITEM_FlowChartCategory drop-down item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_FlowChartCategory,
			/// <summary>Identifies the TXITEM_StarsAndBannersCategory drop-down item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_StarsAndBannersCategory,
			/// <summary>Identifies the TXITEM_CalloutsCategory drop-down item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_CalloutsCategory,
			/// <summary>Identifies the TXITEM_InsertDrawingCanvas drop-down item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_InsertDrawingCanvas,
			/// <summary>Identifies the TXITEM_DrawingMarkerLines drop-down item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_DrawingMarkerLines,
			/// <summary>Identifies the TXITEM_InsertHyperlinkDialog drop-down item inside the TXITEM_InsertHyperlink's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_InsertHyperlinkDialog,
			/// <summary>Identifies the TXITEM_EditHyperlink drop-down item inside the TXITEM_InsertHyperlink's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_EditHyperlink,
			/// <summary>Identifies the TXITEM_InsertBookmarkDialog drop-down item inside the TXITEM_InsertBookmark's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_InsertBookmarkDialog,
			/// <summary>Identifies the TXITEM_DeleteBookmark drop-down item inside the TXITEM_InsertBookmark's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_DeleteBookmark,
			/// <summary>Identifies the TXITEM_EditBookmark drop-down item inside the TXITEM_InsertBookmark's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_EditBookmark,
			/// <summary>Identifies the TXITEM_DocumentTargetMarkers drop-down item inside the TXITEM_InsertBookmark's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_DocumentTargetMarkers,
			/// <summary>Identifies the TXITEM_EditHeader drop-down item inside the TXITEM_InsertHeader's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_EditHeader,
			/// <summary>Identifies the TXITEM_RemoveHeader drop-down item inside the TXITEM_InsertHeader's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_RemoveHeader,
			/// <summary>Identifies the TXITEM_EditFooter drop-down item inside the TXITEM_InsertFooter's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_EditFooter,
			/// <summary>Identifies the TXITEM_RemoveFooter drop-down item inside the TXITEM_InsertFooter's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_RemoveFooter,
			/// <summary>Identifies the TXITEM_InsertStandardPageNumber drop-down item inside the TXITEM_InsertPageNumber's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_InsertStandardPageNumber,
			/// <summary>Identifies the TXITEM_FormatPageNumber drop-down item inside the TXITEM_InsertPageNumber's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_FormatPageNumber,
			/// <summary>Identifies the TXITEM_RemovePageNumber drop-down item inside the TXITEM_InsertPageNumber's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_RemovePageNumber,
			/// <summary>Identifies the TXITEM_AddTextFrame drop-down item inside the TXITEM_InsertTextFrame's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_AddTextFrame,
			/// <summary>Identifies the TXITEM_TextFrameMarkerLines drop-down item inside the TXITEM_InsertTextFrame's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_TextFrameMarkerLines,
			/// <summary>Identifies the TXITEM_MoreSymbols drop-down item inside the TXITEM_InsertSymbol's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_MoreSymbols
		}

		internal enum InternalRibbonItem
		{
			TXITEM_PageGroup,
			TXITEM_InsertPage,
			TXITEM_InsertPageBreak,
			TXITEM_TableGroup,
			TXITEM_InsertTable,
			TXITEM_InsertTableGalleryHeader,
			TXITEM_InsertTableGallery,
			TXITEM_InsertTableSeperator,
			TXITEM_InsertTableDialog,
			TXITEM_IllustrationsGroup,
			TXITEM_InsertImage,
			TXITEM_InsertImageDialog,
			TXITEM_InsertImagePlaceHolder,
			TXITEM_InsertChart,
			TXITEM_InsertChart_ColumnCategory,
			TXITEM_InsertChart_ColumnGallery,
			TXITEM_CHART_ClusteredColumn,
			TXITEM_CHART_StackedColumn,
			TXITEM_CHART_StackedColumn100Percent,
			TXITEM_CHART_ClusteredColumn3D,
			TXITEM_CHART_StackedColumn3D,
			TXITEM_CHART_StackedColumn100Percent3D,
			TXITEM_CHART_Column3D,
			TXITEM_InsertChart_LineSeperator,
			TXITEM_InsertChart_LineCategory,
			TXITEM_InsertChart_LineGallery,
			TXITEM_CHART_Line,
			TXITEM_CHART_LineWithMarkers,
			TXITEM_CHART_Line3D,
			TXITEM_InsertChart_PieSeperator,
			TXITEM_InsertChart_PieCategory,
			TXITEM_InsertChart_PieGallery,
			TXITEM_CHART_Pie,
			TXITEM_CHART_Pie3D,
			TXITEM_CHART_Doughnut,
			TXITEM_InsertChart_BarSeperator,
			TXITEM_InsertChart_BarCategory,
			TXITEM_InsertChart_BarGallery,
			TXITEM_CHART_ClusteredBar,
			TXITEM_CHART_StackedBar,
			TXITEM_CHART_StackedBar100Percent,
			TXITEM_CHART_ClusteredBar3D,
			TXITEM_CHART_StackedBar3D,
			TXITEM_CHART_StackedBar100Percent3D,
			TXITEM_InsertChart_AreaSeperator,
			TXITEM_InsertChart_AreaCategory,
			TXITEM_InsertChart_AreaGallery,
			TXITEM_CHART_Area,
			TXITEM_CHART_StackedArea,
			TXITEM_CHART_StackedArea100Percent,
			TXITEM_CHART_Area3D,
			TXITEM_CHART_StackedArea3D,
			TXITEM_CHART_StackedArea100Percent3D,
			TXITEM_InsertChart_XYScatterSeperator,
			TXITEM_InsertChart_XYScatterCategory,
			TXITEM_InsertChart_XYScatterGallery,
			TXITEM_CHART_Scatter,
			TXITEM_CHART_ScatterWithSmoothLinesAndMarkers,
			TXITEM_CHART_ScatterWithSmoothLines,
			TXITEM_CHART_ScatterWithStraightLinesAndMarkers,
			TXITEM_CHART_ScatterWithStraightLines,
			TXITEM_CHART_Bubble,
			TXITEM_CHART_Bubble3D,
			TXITEM_InsertChart_StockSeperator,
			TXITEM_InsertChart_StockCategory,
			TXITEM_InsertChart_StockGallery,
			TXITEM_CHART_HighLowClose,
			TXITEM_CHART_OpenHighLowClose,
			TXITEM_InsertChart_RadarSeperator,
			TXITEM_InsertChart_RadarCategory,
			TXITEM_InsertChart_RadarGallery,
			TXITEM_CHART_Radar,
			TXITEM_CHART_RadarWithMarkers,
			TXITEM_CHART_FilledRadar,
			TXITEM_InsertShape,
			TXITEM_LinesCategory,
			TXITEM_InsertShapeLinesGallery,
			TXITEM_SHAPE_Line,
			TXITEM_SHAPE_BentConnector3,
			TXITEM_SHAPE_CurvedConnector,
			TXITEM_RectanglesSeperator,
			TXITEM_RectanglesCategory,
			TXITEM_RectanglesGallery,
			TXITEM_SHAPE_Rectangle,
			TXITEM_SHAPE_RoundRectangle,
			TXITEM_SHAPE_Snip1Rectangle,
			TXITEM_SHAPE_Snip2SameRectangle,
			TXITEM_SHAPE_Snip2DiagonalRectangle,
			TXITEM_SHAPE_SnipRoundRectangle,
			TXITEM_SHAPE_Round1Rectangle,
			TXITEM_SHAPE_Round2SameRectangle,
			TXITEM_SHAPE_Round2DiagonalRectangle,
			TXITEM_BasicShapesSeperator,
			TXITEM_BasicShapesCategory,
			TXITEM_BasicShapesGallery,
			TXITEM_SHAPE_Ellipse,
			TXITEM_SHAPE_Triangle,
			TXITEM_SHAPE_RightTriangle,
			TXITEM_SHAPE_Parallelogram,
			TXITEM_SHAPE_NonIsoscelesTrapezoid,
			TXITEM_SHAPE_Diamond,
			TXITEM_SHAPE_Pentagon,
			TXITEM_SHAPE_Hexagon,
			TXITEM_SHAPE_Heptagon,
			TXITEM_SHAPE_Octagon,
			TXITEM_SHAPE_Decagon,
			TXITEM_SHAPE_Dodecagon,
			TXITEM_SHAPE_Pie,
			TXITEM_SHAPE_Chord,
			TXITEM_SHAPE_Teardrop,
			TXITEM_SHAPE_Frame,
			TXITEM_SHAPE_HalfFrame,
			TXITEM_SHAPE_Corner,
			TXITEM_SHAPE_DiagonalStripe,
			TXITEM_SHAPE_Plus,
			TXITEM_SHAPE_Plaque,
			TXITEM_SHAPE_Can,
			TXITEM_SHAPE_Cube,
			TXITEM_SHAPE_Bevel,
			TXITEM_SHAPE_Donut,
			TXITEM_SHAPE_NoSmoking,
			TXITEM_SHAPE_BlockArc,
			TXITEM_SHAPE_FoldedCorner,
			TXITEM_SHAPE_SmileyFace,
			TXITEM_SHAPE_Heart,
			TXITEM_SHAPE_LightningBolt,
			TXITEM_SHAPE_Sun,
			TXITEM_SHAPE_Moon,
			TXITEM_SHAPE_Cloud,
			TXITEM_SHAPE_Arc,
			TXITEM_SHAPE_BracketPair,
			TXITEM_SHAPE_BracePair,
			TXITEM_SHAPE_LeftBracket,
			TXITEM_SHAPE_RightBracket,
			TXITEM_SHAPE_LeftBrace,
			TXITEM_SHAPE_RightBrace,
			TXITEM_BlockArrowsSeperator,
			TXITEM_BlockArrowsCategory,
			TXITEM_BlockArrowsGallery,
			TXITEM_SHAPE_RightArrow,
			TXITEM_SHAPE_LeftArrow,
			TXITEM_SHAPE_UpArrow,
			TXITEM_SHAPE_DownArrow,
			TXITEM_SHAPE_LeftRightArrow,
			TXITEM_SHAPE_UpDownArrow,
			TXITEM_SHAPE_QuadArrow,
			TXITEM_SHAPE_LeftRightUpArrow,
			TXITEM_SHAPE_BentArrow,
			TXITEM_SHAPE_UTurnArrow,
			TXITEM_SHAPE_LeftUpArrow,
			TXITEM_SHAPE_BentUpArrow,
			TXITEM_SHAPE_CurvedRightArrow,
			TXITEM_SHAPE_CurvedLeftArrow,
			TXITEM_SHAPE_CurvedUpArrow,
			TXITEM_SHAPE_CurvedDownArrow,
			TXITEM_SHAPE_StripedRightArrow,
			TXITEM_SHAPE_NotchedRightArrow,
			TXITEM_SHAPE_HomePlate,
			TXITEM_SHAPE_Chevron,
			TXITEM_SHAPE_RightArrowCallout,
			TXITEM_SHAPE_DownArrowCallout,
			TXITEM_SHAPE_LeftArrowCallout,
			TXITEM_SHAPE_UpArrowCallout,
			TXITEM_SHAPE_LeftRightArrowCallout,
			TXITEM_SHAPE_QuadArrowCallout,
			TXITEM_SHAPE_CircularArrow,
			TXITEM_InsertShapeEquationShapesSeperator,
			TXITEM_EquationShapesCategory,
			TXITEM_InsertShapeEquationShapesGallery,
			TXITEM_SHAPE_MathPlus,
			TXITEM_SHAPE_MathMinus,
			TXITEM_SHAPE_MathMultiply,
			TXITEM_SHAPE_MathDivide,
			TXITEM_SHAPE_MathEqual,
			TXITEM_SHAPE_MathNotEqual,
			TXITEM_FlowChartSeperator,
			TXITEM_FlowChartCategory,
			TXITEM_FlowChartGallery,
			XITEM_SHAPE_FlowChartProcess,
			TXITEM_SHAPE_FlowChartAlternateProcess,
			TXITEM_SHAPE_FlowChartDecision,
			TXITEM_SHAPE_FlowChartInputOutput,
			TXITEM_SHAPE_FlowChartPredefinedProcess,
			TXITEM_SHAPE_FlowChartInternalStorage,
			TXITEM_SHAPE_FlowChartDocument,
			TXITEM_SHAPE_FlowChartMultidocument,
			TXITEM_SHAPE_FlowChartTerminator,
			TXITEM_SHAPE_FlowChartPreparation,
			TXITEM_SHAPE_FlowChartManualInput,
			TXITEM_SHAPE_FlowChartManualOperation,
			TXITEM_SHAPE_FlowChartConnector,
			TXITEM_SHAPE_FlowChartOffpageConnector,
			TXITEM_SHAPE_FlowChartPunchedCard,
			TXITEM_SHAPE_FlowChartPunchedTape,
			TXITEM_SHAPE_FlowChartSummingJunction,
			TXITEM_SHAPE_FlowChartOr,
			TXITEM_SHAPE_FlowChartCollate,
			TXITEM_SHAPE_FlowChartSort,
			TXITEM_SHAPE_FlowChartExtract,
			TXITEM_SHAPE_FlowChartMerge,
			TXITEM_SHAPE_FlowChartOnlineStorage,
			TXITEM_SHAPE_FlowChartDelay,
			TXITEM_SHAPE_FlowChartMagneticTape,
			TXITEM_SHAPE_FlowChartMagneticDisk,
			TXITEM_SHAPE_FlowChartMagneticDrum,
			TXITEM_SHAPE_FlowChartDisplay,
			TXITEM_StarsAndBannersSeperator,
			TXITEM_StarsAndBannersCategory,
			TXITEM_StarsAndBannersGallery,
			TXITEM_SHAPE_IrregularSeal1,
			TXITEM_SHAPE_IrregularSeal2,
			TXITEM_SHAPE_Star4,
			TXITEM_SHAPE_Star5,
			TXITEM_SHAPE_Star6,
			TXITEM_SHAPE_Star7,
			TXITEM_SHAPE_Star8,
			TXITEM_SHAPE_Star10,
			TXITEM_SHAPE_Star12,
			TXITEM_SHAPE_Star16,
			TXITEM_SHAPE_Star24,
			TXITEM_SHAPE_Star32,
			TXITEM_SHAPE_Ribbon2,
			TXITEM_SHAPE_Ribbon,
			TXITEM_SHAPE_EllipseRibbon2,
			TXITEM_SHAPE_EllipseRibbon,
			TXITEM_SHAPE_VerticalScroll,
			TXITEM_SHAPE_HorizontalScroll,
			TXITEM_SHAPE_Wave,
			TXITEM_SHAPE_DoubleWave,
			TXITEM_CalloutsSeperator,
			TXITEM_CalloutsCategory,
			TXITEM_CalloutsGallery,
			TXITEM_SHAPE_WedgeRectangleCallout,
			TXITEM_SHAPE_WedgeRoundRectangleCallout,
			TXITEM_SHAPE_WedgeEllipseCallout,
			TXITEM_SHAPE_CloudCallout,
			TXITEM_SHAPE_BorderCallout1,
			TXITEM_SHAPE_BorderCallout2,
			TXITEM_SHAPE_BorderCallout3,
			TXITEM_SHAPE_AccentCallout1,
			TXITEM_SHAPE_AccentCallout2,
			TXITEM_SHAPE_AccentCallout3,
			TXITEM_SHAPE_Callout1,
			TXITEM_SHAPE_Callout2,
			TXITEM_SHAPE_Callout3,
			TXITEM_SHAPE_AccentBorderCallout1,
			TXITEM_SHAPE_AccentBorderCallout2,
			TXITEM_SHAPE_AccentBorderCallout3,
			TXITEM_InsertShapeSeperator,
			TXITEM_InsertDrawingCanvas,
			TXITEM_DrawingMarkerLines,
			TXITEM_InsertBarcode,
			TXITEM_BARCODE_QRCode,
			TXITEM_BARCODE_Code128,
			TXITEM_BARCODE_EAN13,
			TXITEM_BARCODE_UPCA,
			TXITEM_BARCODE_EAN8,
			TXITEM_BARCODE_Interleaved2of5,
			TXITEM_BARCODE_Postnet,
			TXITEM_BARCODE_Code39,
			TXITEM_BARCODE_AztecCode,
			TXITEM_BARCODE_IntelligentMail,
			TXITEM_BARCODE_Datamatrix,
			TXITEM_BARCODE_PDF417,
			TXITEM_BARCODE_MicroPDF,
			TXITEM_BARCODE_Codabar,
			TXITEM_BARCODE_FourState,
			TXITEM_BARCODE_Code11,
			TXITEM_BARCODE_Code93,
			TXITEM_BARCODE_PLANET,
			TXITEM_BARCODE_RoyalMail,
			TXITEM_BARCODE_Maxicode,
			TXITEM_LinksGroup,
			TXITEM_InsertHyperlink,
			TXITEM_InsertHyperlinkDialog,
			TXITEM_EditHyperlink,
			TXITEM_InsertBookmark,
			TXITEM_InsertBookmarkDialog,
			TXITEM_DeleteBookmark,
			TXITEM_EditBookmark,
			TXITEM_InsertBookmarkSeperator,
			TXITEM_DocumentTargetMarkers,
			TXITEM_HeaderFooterGroup,
			TXITEM_InsertHeader,
			TXITEM_EditHeader,
			TXITEM_RemoveHeader,
			TXITEM_InsertFooter,
			TXITEM_EditFooter,
			TXITEM_RemoveFooter,
			TXITEM_InsertPageNumber,
			TXITEM_InsertStandardPageNumber,
			TXITEM_FormatPageNumber,
			TXITEM_RemovePageNumber,
			TXITEM_TextGroup,
			TXITEM_InsertTextFrame,
			TXITEM_AddTextFrame,
			TXITEM_InsertTextFrameSeperator,
			TXITEM_TextFrameMarkerLines,
			TXITEM_InsertFile,
			TXITEM_SymbolsGroup,
			TXITEM_InsertSymbol,
			TXITEM_SymbolGallery,
			TXITEM_InsertSymbolSeperator,
			TXITEM_MoreSymbols
		}

		internal enum ChartTemplate
		{
			ClusteredColumn,
			StackedColumn,
			StackedColumn100Percent,
			ClusteredColumn3D,
			StackedColumn3D,
			StackedColumn100Percent3D,
			Column3D,
			Line,
			LineWithMarkers,
			Line3D,
			Pie,
			Pie3D,
			Doughnut,
			ClusteredBar,
			StackedBar,
			StackedBar100Percent,
			ClusteredBar3D,
			StackedBar3D,
			StackedBar100Percent3D,
			Area,
			StackedArea,
			StackedArea100Percent,
			Area3D,
			StackedArea3D,
			StackedArea100Percent3D,
			Scatter,
			ScatterWithSmoothLinesAndMarkers,
			ScatterWithSmoothLines,
			ScatterWithStraightLinesAndMarkers,
			ScatterWithStraightLines,
			Bubble,
			Bubble3D,
			HighLowClose,
			OpenHighLowClose,
			Radar,
			RadarWithMarkers,
			FilledRadar
		}

		private Class506 class506_0;

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
					return this.resourceManager_0.GetString("KEYTIP_InsertTab");
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
					return this.resourceManager_0.GetString("HEADER_RibbonInsertTab");
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
					this.class506_0.BindingAdapter_0.OnDisconnectingTextControl();
					this.class506_0.BindingAdapter_0.TextControl.PropertyChanged -= this.class506_0.vmethod_0;
				}
				TextControl textControl3 = (base.TextControl_0 = (this.class506_0.BindingAdapter_0.TextControl = value));
				if (base.TextControl_0 != null)
				{
					this.class506_0.BindingAdapter_0.OnTextControlConnected();
					if (this.class506_0.Boolean_0)
					{
						this.vmethod_0();
					}
					this.class506_0.BindingAdapter_0.TextControl.PropertyChanged += this.class506_0.vmethod_0;
				}
				this.class506_0.method_5();
			}
		}

		/// <summary>Initializes a new instance of the RibbonInsertTab class.</summary>
		public RibbonInsertTab()
		{
			this.method_2();
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			PointF dpi = base.method_0();
			this.class506_0.BindingAdapter_0.AwareOfDPI(dpi);
			base.OnHandleCreated(eventArgs_0);
		}

		internal override void vmethod_0(params object[] object_0)
		{
			this.class506_0.BindingAdapter_0.UpdateRibbonTab();
		}

		internal override void vmethod_1(uint uint_1)
		{
			base.vmethod_1(uint_1);
			this.class506_0.BindingAdapter_0.AwareOfDPI(base.method_0());
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
			this.class506_0 = new Class506(this, new Class477());
			this.class506_0.method_10(base.RibbonGroups);
			this.class506_0.method_11(base.RibbonGroups);
			this.class506_0.method_12(base.RibbonGroups);
			this.class506_0.method_13(base.RibbonGroups);
			this.class506_0.method_14(base.RibbonGroups);
			this.class506_0.method_15(base.RibbonGroups);
			this.class506_0.method_16(base.RibbonGroups);
			this.list_0.Add(this.class506_0.TXITEM_PageGroup_Items);
			this.list_0.Add(this.class506_0.TXITEM_TableGroup_Items);
			this.list_0.Add(this.class506_0.TXITEM_IllustrationsGroup_Items);
			this.list_0.Add(this.class506_0.TXITEM_LinksGroup_Items);
			this.list_0.Add(this.class506_0.TXITEM_HeaderFooterGroup_Items);
			this.list_0.Add(this.class506_0.TXITEM_TextGroup_Items);
			this.list_0.Add(this.class506_0.TXITEM_SymbolsGroup_Items);
		}
	}
}
