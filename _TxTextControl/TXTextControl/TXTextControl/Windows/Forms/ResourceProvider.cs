using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using ns21;

namespace TXTextControl.Windows.Forms
{
	/// <summary>The ResourceProvider class provides static methods to receive bitmaps or strings from sources that can be accessed via an assigned identifier.</summary>
	public class ResourceProvider
	{
		/// <summary>Each FileMenuItem represents the identifier for a file menu item.</summary>
		public enum FileMenuItem
		{
			/// <summary>Represents the TXITEM_New file menu item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_New,
			/// <summary>Represents the TXITEM_Open file menu item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Open,
			/// <summary>Represents the TXITEM_Save file menu item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Save,
			/// <summary>Represents the TXITEM_SaveAs file menu item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_SaveAs,
			/// <summary>Represents the TXITEM_Print file menu item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Print,
			/// <summary>Represents the TXITEM_PrintQuick file menu item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_PrintQuick,
			/// <summary>Represents the TXITEM_PrintPreview file menu item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_PrintPreview,
			/// <summary>Represents the TXITEM_Options file menu item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Options,
			/// <summary>Represents the TXITEM_UserAdministration file menu item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_UserAdministration,
			/// <summary>Represents the TXITEM_GrantUserAccess file menu item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_GrantUserAccess,
			/// <summary>Represents the TXITEM_About file menu item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_About,
			/// <summary>Represents the TXITEM_Exit file menu item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Exit,
			/// <summary>Represents the TXITEM_DocumentSettings file menu item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DocumentSettings
		}

		/// <summary>Each GeneralItem represents the identifier for a general item.</summary>
		public enum GeneralItem
		{
			/// <summary>Represents the general TXITEM_Checkmark item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_Checkmark,
			/// <summary>Represents the general TXITEM_Checked item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_Checked,
			/// <summary>Represents the general TXITEM_Unchecked item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_Unchecked,
			/// <summary>Represents the general TXITEM_Launcher item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_Launcher,
			/// <summary>Represents the general TXITEM_Close item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_Close,
			/// <summary>Represents the general TXITEM_Pinned item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_Pinned,
			/// <summary>Represents the general TXITEM_Unpinned item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_Unpinned,
			/// <summary>Represents the general TXITEM_Plus item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_Plus,
			/// <summary>Represents the general TXITEM_Minus item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_Minus,
			/// <summary>Represents the general TXITEM_Undo item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_Undo,
			/// <summary>Represents the general TXITEM_Redo item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_Redo,
			/// <summary>Represents the general TXITEM_NavigateToFirst item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and SmallIcon resources.</summary>
			TXITEM_NavigateToFirst,
			/// <summary>Represents the general TXITEM_NavigateToPrevious item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and SmallIcon resources.</summary>
			TXITEM_NavigateToPrevious,
			/// <summary>Represents the general TXITEM_NavigateToNext item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and SmallIcon resources.</summary>
			TXITEM_NavigateToNext,
			/// <summary>Represents the general TXITEM_NavigateToLast item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and SmallIcon resources.</summary>
			TXITEM_NavigateToLast,
			/// <summary>Represents the general TXITEM_AdvancedSettings item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_AdvancedSettings,
			/// <summary>Represents the general TXITEM_Add item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_Add,
			/// <summary>Represents the general TXITEM_Remove item. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_Remove
		}

		/// <summary>Each ShapeItem represents a list view item inside the RibbonInsertTab's TXITEM_InsertShape drop-down menu.</summary>
		public enum ShapeItem
		{
			/// <summary>Identifies the TXITEM_SHAPE_Line list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Line,
			/// <summary>Identifies the TXITEM_SHAPE_BentConnector3 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_BentConnector3,
			/// <summary>Identifies the TXITEM_SHAPE_CurvedConnector3 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_CurvedConnector3,
			/// <summary>Identifies the TXITEM_SHAPE_Rectangle list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Rectangle,
			/// <summary>Identifies the TXITEM_SHAPE_RoundRectangle list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_RoundRectangle,
			/// <summary>Identifies the TXITEM_SHAPE_Snip1Rectangle list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Snip1Rectangle,
			/// <summary>Identifies the TXITEM_SHAPE_Snip2SameRectangle list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Snip2SameRectangle,
			/// <summary>Identifies the TXITEM_SHAPE_Snip2DiagonalRectangle list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Snip2DiagonalRectangle,
			/// <summary>Identifies the TXITEM_SHAPE_SnipRoundRectangle list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_SnipRoundRectangle,
			/// <summary>Identifies the TXITEM_SHAPE_Round1Rectangle list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Round1Rectangle,
			/// <summary>Identifies the TXITEM_SHAPE_Round2SameRectangle list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Round2SameRectangle,
			/// <summary>Identifies the TXITEM_SHAPE_Round2DiagonalRectangle list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Round2DiagonalRectangle,
			/// <summary>Identifies the TXITEM_SHAPE_Ellipse list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Ellipse,
			/// <summary>Identifies the TXITEM_SHAPE_Triangle list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Triangle,
			/// <summary>Identifies the TXITEM_SHAPE_RightTriangle list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_RightTriangle,
			/// <summary>Identifies the TXITEM_SHAPE_Parallelogram list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Parallelogram,
			/// <summary>Identifies the TXITEM_SHAPE_NonIsoscelesTrapezoid list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_NonIsoscelesTrapezoid,
			/// <summary>Identifies the TXITEM_SHAPE_Diamond list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Diamond,
			/// <summary>Identifies the TXITEM_SHAPE_Pentagon list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Pentagon,
			/// <summary>Identifies the TXITEM_SHAPE_Hexagon list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Hexagon,
			/// <summary>Identifies the TXITEM_SHAPE_Heptagon list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Heptagon,
			/// <summary>Identifies the TXITEM_SHAPE_Octagon list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Octagon,
			/// <summary>Identifies the TXITEM_SHAPE_Decagon list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Decagon,
			/// <summary>Identifies the TXITEM_SHAPE_Dodecagon list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Dodecagon,
			/// <summary>Identifies the TXITEM_SHAPE_Pie list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Pie,
			/// <summary>Identifies the TXITEM_SHAPE_Chord list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Chord,
			/// <summary>Identifies the TXITEM_SHAPE_Teardrop list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Teardrop,
			/// <summary>Identifies the TXITEM_SHAPE_Frame list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Frame,
			/// <summary>Identifies the TXITEM_SHAPE_HalfFrame list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_HalfFrame,
			/// <summary>Identifies the TXITEM_SHAPE_Corner list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Corner,
			/// <summary>Identifies the TXITEM_SHAPE_DiagonalStripe list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_DiagonalStripe,
			/// <summary>Identifies the TXITEM_SHAPE_Plus list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Plus,
			/// <summary>Identifies the TXITEM_SHAPE_Plaque list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Plaque,
			/// <summary>Identifies the TXITEM_SHAPE_Can list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Can,
			/// <summary>Identifies the TXITEM_SHAPE_Cube list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Cube,
			/// <summary>Identifies the TXITEM_SHAPE_Bevel list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Bevel,
			/// <summary>Identifies the TXITEM_SHAPE_Donut list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Donut,
			/// <summary>Identifies the TXITEM_SHAPE_NoSmoking list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_NoSmoking,
			/// <summary>Identifies the TXITEM_SHAPE_BlockArc list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_BlockArc,
			/// <summary>Identifies the TXITEM_SHAPE_FoldedCorner list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FoldedCorner,
			/// <summary>Identifies the TXITEM_SHAPE_SmileyFace list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_SmileyFace,
			/// <summary>Identifies the TXITEM_SHAPE_Heart list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Heart,
			/// <summary>Identifies the TXITEM_SHAPE_LightningBolt list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_LightningBolt,
			/// <summary>Identifies the TXITEM_SHAPE_Sun list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Sun,
			/// <summary>Identifies the TXITEM_SHAPE_Moon list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Moon,
			/// <summary>Identifies the TXITEM_SHAPE_Cloud list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Cloud,
			/// <summary>Identifies the TXITEM_SHAPE_Arc list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Arc,
			/// <summary>Identifies the TXITEM_SHAPE_BracketPair list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_BracketPair,
			/// <summary>Identifies the TXITEM_SHAPE_BracePair list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_BracePair,
			/// <summary>Identifies the TXITEM_SHAPE_LeftBracket list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_LeftBracket,
			/// <summary>Identifies the TXITEM_SHAPE_RightBracket list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_RightBracket,
			/// <summary>Identifies the TXITEM_SHAPE_LeftBrace list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_LeftBrace,
			/// <summary>Identifies the TXITEM_SHAPE_RightBrace list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_RightBrace,
			/// <summary>Identifies the TXITEM_SHAPE_RightArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_RightArrow,
			/// <summary>Identifies the TXITEM_SHAPE_LeftArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_LeftArrow,
			/// <summary>Identifies the TXITEM_SHAPE_UpArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_UpArrow,
			/// <summary>Identifies the TXITEM_SHAPE_DownArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_DownArrow,
			/// <summary>Identifies the TXITEM_SHAPE_LeftRightArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_LeftRightArrow,
			/// <summary>Identifies the TXITEM_SHAPE_UpDownArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_UpDownArrow,
			/// <summary>Identifies the TXITEM_SHAPE_QuadArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_QuadArrow,
			/// <summary>Identifies the TXITEM_SHAPE_LeftRightUpArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_LeftRightUpArrow,
			/// <summary>Identifies the TXITEM_SHAPE_BentArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_BentArrow,
			/// <summary>Identifies the TXITEM_SHAPE_UTurnArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_UTurnArrow,
			/// <summary>Identifies the TXITEM_SHAPE_LeftUpArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_LeftUpArrow,
			/// <summary>Identifies the TXITEM_SHAPE_BentUpArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_BentUpArrow,
			/// <summary>Identifies the TXITEM_SHAPE_CurvedRightArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_CurvedRightArrow,
			/// <summary>Identifies the TXITEM_SHAPE_CurvedLeftArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_CurvedLeftArrow,
			/// <summary>Identifies the TXITEM_SHAPE_CurvedUpArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_CurvedUpArrow,
			/// <summary>Identifies the TXITEM_SHAPE_CurvedDownArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_CurvedDownArrow,
			/// <summary>Identifies the TXITEM_SHAPE_StripedRightArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_StripedRightArrow,
			/// <summary>Identifies the TXITEM_SHAPE_NotchedRightArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_NotchedRightArrow,
			/// <summary>Identifies the TXITEM_SHAPE_HomePlate list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_HomePlate,
			/// <summary>Identifies the TXITEM_SHAPE_Chevron list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Chevron,
			/// <summary>Identifies the TXITEM_SHAPE_RightArrowCallout list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_RightArrowCallout,
			/// <summary>Identifies the TXITEM_SHAPE_DownArrowCallout list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_DownArrowCallout,
			/// <summary>Identifies the TXITEM_SHAPE_LeftArrowCallout list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_LeftArrowCallout,
			/// <summary>Identifies the TXITEM_SHAPE_UpArrowCallout list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_UpArrowCallout,
			/// <summary>Identifies the TXITEM_SHAPE_LeftRightArrowCallout list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_LeftRightArrowCallout,
			/// <summary>Identifies the TXITEM_SHAPE_QuadArrowCallout list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_QuadArrowCallout,
			/// <summary>Identifies the TXITEM_SHAPE_CircularArrow list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_CircularArrow,
			/// <summary>Identifies the TXITEM_SHAPE_MathPlus list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_MathPlus,
			/// <summary>Identifies the TXITEM_SHAPE_MathMinus list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_MathMinus,
			/// <summary>Identifies the TXITEM_SHAPE_MathMultiply list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_MathMultiply,
			/// <summary>Identifies the TXITEM_SHAPE_MathDivide list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_MathDivide,
			/// <summary>Identifies the TXITEM_SHAPE_MathEqual list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_MathEqual,
			/// <summary>Identifies the TXITEM_SHAPE_MathNotEqual list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_MathNotEqual,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartProcess list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartProcess,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartAlternateProcess list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartAlternateProcess,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartDecision list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartDecision,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartInputOutput list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartInputOutput,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartPredefinedProcess list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartPredefinedProcess,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartInternalStorage list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartInternalStorage,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartDocument list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartDocument,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartMultidocument list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartMultidocument,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartTerminator list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartTerminator,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartPreparation list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartPreparation,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartManualInput list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartManualInput,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartManualOperation list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartManualOperation,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartConnector list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartConnector,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartOffpageConnector list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartOffpageConnector,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartPunchedCard list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartPunchedCard,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartPunchedTape list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartPunchedTape,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartSummingJunction list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartSummingJunction,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartOr list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartOr,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartCollate list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartCollate,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartSort list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartSort,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartExtract list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartExtract,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartMerge list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartMerge,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartOnlineStorage list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartOnlineStorage,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartDelay list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartDelay,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartMagneticTape list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartMagneticTape,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartMagneticDisk list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartMagneticDisk,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartMagneticDrum list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartMagneticDrum,
			/// <summary>Identifies the TXITEM_SHAPE_FlowChartDisplay list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_FlowChartDisplay,
			/// <summary>Identifies the TXITEM_SHAPE_IrregularSeal1 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_IrregularSeal1,
			/// <summary>Identifies the TXITEM_SHAPE_IrregularSeal2 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_IrregularSeal2,
			/// <summary>Identifies the TXITEM_SHAPE_Star4 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Star4,
			/// <summary>Identifies the TXITEM_SHAPE_Star5 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Star5,
			/// <summary>Identifies the TXITEM_SHAPE_Star6 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Star6,
			/// <summary>Identifies the TXITEM_SHAPE_Star7 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Star7,
			/// <summary>Identifies the TXITEM_SHAPE_Star8 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Star8,
			/// <summary>Identifies the TXITEM_SHAPE_Star10 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Star10,
			/// <summary>Identifies the TXITEM_SHAPE_Star12 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Star12,
			/// <summary>Identifies the TXITEM_SHAPE_Star16 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Star16,
			/// <summary>Identifies the TXITEM_SHAPE_Star24 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Star24,
			/// <summary>Identifies the TXITEM_SHAPE_Star32 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Star32,
			/// <summary>Identifies the TXITEM_SHAPE_Ribbon2 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Ribbon2,
			/// <summary>Identifies the TXITEM_SHAPE_Ribbon list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Ribbon,
			/// <summary>Identifies the TXITEM_SHAPE_EllipseRibbon2 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_EllipseRibbon2,
			/// <summary>Identifies the TXITEM_SHAPE_EllipseRibbon list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_EllipseRibbon,
			/// <summary>Identifies the TXITEM_SHAPE_VerticalScroll list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_VerticalScroll,
			/// <summary>Identifies the TXITEM_SHAPE_HorizontalScroll list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_HorizontalScroll,
			/// <summary>Identifies the TXITEM_SHAPE_Wave list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Wave,
			/// <summary>Identifies the TXITEM_SHAPE_DoubleWave list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_DoubleWave,
			/// <summary>Identifies the TXITEM_SHAPE_WedgeRectangleCallout list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_WedgeRectangleCallout,
			/// <summary>Identifies the TXITEM_SHAPE_WedgeRoundRectangleCallout list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_WedgeRoundRectangleCallout,
			/// <summary>Identifies the TXITEM_SHAPE_WedgeEllipseCallout list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_WedgeEllipseCallout,
			/// <summary>Identifies the TXITEM_SHAPE_CloudCallout list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_CloudCallout,
			/// <summary>Identifies the TXITEM_SHAPE_BorderCallout1 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_BorderCallout1,
			/// <summary>Identifies the TXITEM_SHAPE_BorderCallout2 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_BorderCallout2,
			/// <summary>Identifies the TXITEM_SHAPE_BorderCallout3 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_BorderCallout3,
			/// <summary>Identifies the TXITEM_SHAPE_AccentCallout1 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_AccentCallout1,
			/// <summary>Identifies the TXITEM_SHAPE_AccentCallout2 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_AccentCallout2,
			/// <summary>Identifies the TXITEM_SHAPE_AccentCallout3 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_AccentCallout3,
			/// <summary>Identifies the TXITEM_SHAPE_Callout1 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Callout1,
			/// <summary>Identifies the TXITEM_SHAPE_Callout2 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Callout2,
			/// <summary>Identifies the TXITEM_SHAPE_Callout3 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_Callout3,
			/// <summary>Identifies the TXITEM_SHAPE_AccentBorderCallout1 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_AccentBorderCallout1,
			/// <summary>Identifies the TXITEM_SHAPE_AccentBorderCallout2 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_AccentBorderCallout2,
			/// <summary>Identifies the TXITEM_SHAPE_AccentBorderCallout3 list view item inside the TXITEM_InsertShape's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and ToolTipDescription resources.</summary>
			TXITEM_SHAPE_AccentBorderCallout3
		}

		/// <summary>Each ChartItem represents a list view item inside the RibbonInsertTab's TXITEM_InsertChart drop-down menu.</summary>
		public enum ChartItem
		{
			/// <summary>Identifies the TXITEM_CHART_ClusteredColumn list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_ClusteredColumn,
			/// <summary>Identifies the TXITEM_CHART_StackedColumn list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_StackedColumn,
			/// <summary>Identifies the TXITEM_CHART_StackedColumn100Percent list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_StackedColumn100Percent,
			/// <summary>Identifies the TXITEM_CHART_ClusteredColumn3D list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_ClusteredColumn3D,
			/// <summary>Identifies the TXITEM_CHART_StackedColumn3D list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_StackedColumn3D,
			/// <summary>Identifies the TXITEM_CHART_StackedColumn100Percent3D list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_StackedColumn100Percent3D,
			/// <summary>Identifies the TXITEM_CHART_Column3D list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_Column3D,
			/// <summary>Identifies the TXITEM_CHART_Line list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_Line,
			/// <summary>Identifies the TXITEM_CHART_LineWithMarkers list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_LineWithMarkers,
			/// <summary>Identifies the TXITEM_CHART_Line3D list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_Line3D,
			/// <summary>Identifies the TXITEM_CHART_Pie list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_Pie,
			/// <summary>Identifies the TXITEM_CHART_Pie3D list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_Pie3D,
			/// <summary>Identifies the TXITEM_CHART_Doughnut list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_Doughnut,
			/// <summary>Identifies the TXITEM_CHART_ClusteredBar list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_ClusteredBar,
			/// <summary>Identifies the TXITEM_CHART_StackedBar list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_StackedBar,
			/// <summary>Identifies the TXITEM_CHART_StackedBar100Percent list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_StackedBar100Percent,
			/// <summary>Identifies the TXITEM_CHART_ClusteredBar3D list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_ClusteredBar3D,
			/// <summary>Identifies the TXITEM_CHART_StackedBar3D list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_StackedBar3D,
			/// <summary>Identifies the TXITEM_CHART_StackedBar100Percent3D list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_StackedBar100Percent3D,
			/// <summary>Identifies the TXITEM_CHART_Area list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_Area,
			/// <summary>Identifies the TXITEM_CHART_StackedArea list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_StackedArea,
			/// <summary>Identifies the TXITEM_CHART_StackedArea100Percent list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_StackedArea100Percent,
			/// <summary>Identifies the TXITEM_CHART_Area3D list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_Area3D,
			/// <summary>Identifies the TXITEM_CHART_StackedArea3D list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_StackedArea3D,
			/// <summary>Identifies the TXITEM_CHART_StackedArea100Percent3D list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_StackedArea100Percent3D,
			/// <summary>Identifies the TXITEM_CHART_Scatter list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_Scatter,
			/// <summary>Identifies the TXITEM_CHART_ScatterWithSmoothLinesAndMarkers list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_ScatterWithSmoothLinesAndMarkers,
			/// <summary>Identifies the TXITEM_CHART_ScatterWithSmoothLines list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_ScatterWithSmoothLines,
			/// <summary>Identifies the TXITEM_CHART_ScatterWithStraightLinesAndMarkers list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_ScatterWithStraightLinesAndMarkers,
			/// <summary>Identifies the TXITEM_CHART_ScatterWithStraightLines list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_ScatterWithStraightLines,
			/// <summary>Identifies the TXITEM_CHART_Bubble list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_Bubble,
			/// <summary>Identifies the TXITEM_CHART_Bubble3D list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_Bubble3D,
			/// <summary>Identifies the TXITEM_CHART_HighLowClose list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_HighLowClose,
			/// <summary>Identifies the TXITEM_CHART_OpenHighLowClose list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_OpenHighLowClose,
			/// <summary>Identifies the TXITEM_CHART_Radar list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_Radar,
			/// <summary>Identifies the TXITEM_CHART_RadarWithMarkers list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_RadarWithMarkers,
			/// <summary>Identifies the TXITEM_CHART_FilledRadar list view item inside the TXITEM_InsertChart's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon and ToolTipTitle resources.</summary>
			TXITEM_CHART_FilledRadar
		}

		/// <summary>Each BarcodeItem represents a drop-down item inside the RibbonInsertTab's TXITEM_Insert_Barcode drop-down menu.</summary>
		public enum BarcodeItem
		{
			/// <summary>Identifies the TXITEM_BARCODE_QRCode drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_QRCode,
			/// <summary>Identifies the TXITEM_BARCODE_Code128 drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_Code128,
			/// <summary>Identifies the TXITEM_BARCODE_EAN13 drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_EAN13,
			/// <summary>Identifies the TXITEM_BARCODE_UPCA drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_UPCA,
			/// <summary>Identifies the TXITEM_BARCODE_EAN8 drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_EAN8,
			/// <summary>Identifies the TXITEM_BARCODE_Interleaved2of5 drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_Interleaved2of5,
			/// <summary>Identifies the TXITEM_BARCODE_Postnet drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_Postnet,
			/// <summary>Identifies the TXITEM_BARCODE_Code39 drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_Code39,
			/// <summary>Identifies the TXITEM_BARCODE_AztecCode drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_AztecCode,
			/// <summary>Identifies the TXITEM_BARCODE_IntelligentMail drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_IntelligentMail,
			/// <summary>Identifies the TXITEM_BARCODE_Datamatrix drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_Datamatrix,
			/// <summary>Identifies the TXITEM_BARCODE_PDF417 drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_PDF417,
			/// <summary>Identifies the TXITEM_BARCODE_MicroPDF drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_MicroPDF,
			/// <summary>Identifies the TXITEM_BARCODE_Codabar drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_Codabar,
			/// <summary>Identifies the TXITEM_BARCODE_FourState drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_FourState,
			/// <summary>Identifies the TXITEM_BARCODE_Code11 drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_Code11,
			/// <summary>Identifies the TXITEM_BARCODE_Code93 drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_Code93,
			/// <summary>Identifies the TXITEM_BARCODE_PLANET drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_PLANET,
			/// <summary>Identifies the TXITEM_BARCODE_RoyalMail drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_RoyalMail,
			/// <summary>Identifies the TXITEM_BARCODE_Maxicode drop-down item inside the TXITEM_InsertBarcode's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon resource.</summary>
			TXITEM_BARCODE_Maxicode
		}

		/// <summary>The ImageSourceSettings class provides properties for advanced settings to receive an image by using the ResourceProvider.GetSmallIcon and ResourceProvider.GetLargeIcon methods.</summary>
		public class ImageSourceSettings
		{
			private CultureInfo cultureInfo_0 = CultureInfo.CurrentUICulture;

			[CompilerGenerated]
			private Color? nullable_0;

			[CompilerGenerated]
			private Color? nullable_1;

			/// <summary>Specifies the culture to receive a language related image.</summary>
			public CultureInfo Culture
			{
				get
				{
					return this.cultureInfo_0;
				}
				set
				{
					this.cultureInfo_0 = value;
				}
			}

			/// <summary>Specifies the fill color of editable scopes inside the related image.</summary>
			public Color? FillColor
			{
				[CompilerGenerated]
				get
				{
					return this.nullable_0;
				}
				[CompilerGenerated]
				set
				{
					this.nullable_0 = value;
				}
			}

			/// <summary>Specifies the stroke color of editable scopes inside the related image.</summary>
			public Color? StrokeColor
			{
				[CompilerGenerated]
				get
				{
					return this.nullable_1;
				}
				[CompilerGenerated]
				set
				{
					this.nullable_1 = value;
				}
			}

			/// <summary>Initializes a new instance of the ResourceProvider.ImageSourceSettings class.</summary>
			public ImageSourceSettings()
			{
			}
		}

		internal ResourceProvider()
		{
		}

		/// <summary>Gets a System.Drawing.Bitmap of the small icon that is associated with the specified identifier in a specific resolution.</summary>
		/// <param name="identifier">The identifier of the item that is associated with the requested small icon.</param>
		/// <param name="dpi">Specifies the resolution that is used to create the requested small icon.</param>
		public static Bitmap GetSmallIcon(string identifier, float dpi)
		{
			return ResourceProvider.GetSmallIcon(identifier, dpi, new ImageSourceSettings());
		}

		public static Bitmap GetSmallIcon(string identifier, float dpi, ImageSourceSettings settings)
		{
			ImageProvider.ImageSetting imageSetting = new ImageProvider.ImageSetting();
			imageSetting.Culture = settings.Culture;
			imageSetting.Fill = settings.FillColor;
			imageSetting.Stroke = settings.StrokeColor;
			imageSetting.DrawGroupMarker = identifier.EndsWith("Group");
			switch (identifier)
			{
			case "TXITEM_Bold":
			case "TXITEM_Italic":
			case "TXITEM_Underline":
				imageSetting.CheckCulture = true;
				break;
			}
			return Class406.smethod_0(identifier, Class406.Enum72.const_0, (int)dpi, imageSetting);
		}

		/// <summary>Gets a System.Drawing.Bitmap of the large icon that is associated with the specified identifier in a specific resolution.</summary>
		/// <param name="identifier">The identifier of the item that is associated with the requested large icon.</param>
		/// <param name="dpi">Specifies the resolution that is used to create the requested large icon.</param>
		public static Bitmap GetLargeIcon(string identifier, float dpi)
		{
			return ResourceProvider.GetLargeIcon(identifier, dpi, new ImageSourceSettings());
		}

		public static Bitmap GetLargeIcon(string identifier, float dpi, ImageSourceSettings settings)
		{
			ImageProvider.ImageSetting imageSetting = new ImageProvider.ImageSetting();
			imageSetting.Culture = settings.Culture;
			imageSetting.Fill = settings.FillColor;
			imageSetting.Stroke = settings.StrokeColor;
			imageSetting.DrawGroupMarker = identifier.EndsWith("Group");
			return Class406.smethod_0(identifier, Class406.Enum72.const_1, (int)dpi, imageSetting);
		}

		/// <summary>Gets the text that is associated with the specified item identifier.</summary>
		/// <param name="identifier">The identifier of the item that is associated with the requested text.</param>
		public static string GetText(string identifier)
		{
			return Class406.smethod_1(identifier, Class406.Enum72.const_2, null);
		}

		/// <summary>Gets the text that is associated with the specified item identifier in the specified language.</summary>
		/// <param name="identifier">The identifier of the item that is associated with the requested text.</param>
		/// <param name="culture">Specifies the language in which the text is returned.</param>
		public static string GetText(string identifier, CultureInfo culture)
		{
			return Class406.smethod_1(identifier, Class406.Enum72.const_2, culture);
		}

		/// <summary>Gets the tool tip title that is associated with the specified item identifier.</summary>
		/// <param name="identifier">The identifier of the item that is associated with the requested tool tip title.</param>
		public static string GetToolTipTitle(string identifier)
		{
			return Class406.smethod_1(identifier, Class406.Enum72.const_3, null);
		}

		/// <summary>Gets the tool tip title that is associated with the specified item identifier in the specified language.</summary>
		/// <param name="identifier">The identifier of the item that is associated with the requested tool tip title.</param>
		/// <param name="culture">Specifies the language in which the tool tip title is returned.</param>
		public static string GetToolTipTitle(string identifier, CultureInfo culture)
		{
			return Class406.smethod_1(identifier, Class406.Enum72.const_3, culture);
		}

		/// <summary>Gets the tool tip description that is associated with the specified item identifier.</summary>
		/// <param name="identifier">The identifier of the item that is associated with the requested tool tip description.</param>
		public static string GetToolTipDescription(string identifier)
		{
			return Class406.smethod_1(identifier, Class406.Enum72.const_4, null);
		}

		/// <summary>Gets the tool tip description that is associated with the specified item identifier in the specified language.</summary>
		/// <param name="identifier">The identifier of the item that is associated with the requested tool tip description.</param>
		/// <param name="culture">Specifies the language in which the tool tip description is returned.</param>
		public static string GetToolTipDescription(string identifier, CultureInfo culture)
		{
			return Class406.smethod_1(identifier, Class406.Enum72.const_4, culture);
		}

		/// <summary>Gets the key tip that is associated with the specified item identifier.</summary>
		/// <param name="identifier">The identifier of the item that is associated with the requested key tip.</param>
		public static string GetKeyTip(string identifier)
		{
			return Class406.smethod_1(identifier, Class406.Enum72.const_5, null);
		}

		/// <summary>Gets the key tip that is associated with the specified item identifier in the specified language.</summary>
		/// <param name="identifier">The identifier of the item that is associated with the requested key tip.</param>
		/// <param name="culture">Specifies the language in which the key tip is returned.</param>
		public static string GetKeyTip(string identifier, CultureInfo culture)
		{
			return Class406.smethod_1(identifier, Class406.Enum72.const_5, culture);
		}
	}
}
