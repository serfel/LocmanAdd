using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using ns21;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonFormattingTab class represents a ribbon tab for setting font and paragraph attributes, formatting styles and for handling the clipboard.</summary>
	[ToolboxBitmap(typeof(RibbonFormattingTab))]
	public class RibbonFormattingTab : RibbonTab
	{
		/// <summary>Each RibbonItem represents an item in the RibbonFormattingTab that is not a drop-down item.</summary>
		public enum RibbonItem
		{
			/// <summary>Identifies the TXITEM_ClipboardGroup ribbon group inside the RibbonFormattingTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_ClipboardGroup,
			/// <summary>Identifies the TXITEM_Paste ribbon item inside the TXITEM_ClipboardGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Paste,
			/// <summary>Identifies the TXITEM_Cut ribbon item inside the TXITEM_ClipboardGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Cut,
			/// <summary>Identifies the TXITEM_Copy ribbon item inside the TXITEM_ClipboardGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Copy,
			/// <summary>Identifies the TXITEM_FontGroup ribbon group inside the RibbonFormattingTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_FontGroup,
			/// <summary>Identifies the dialog box launcher of the TXITEM_FontGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle and ToolTipDescription resources. Limitations: The FindItem method returns null when passing this RibbonItem as an argument.</summary>
			TXITEM_FontGroup_DialogBoxLauncher,
			/// <summary>Identifies the TXITEM_FontFamily ribbon item inside the TXITEM_FontGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_FontFamily,
			/// <summary>Identifies the TXITEM_FontSize ribbon item inside the TXITEM_FontGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_FontSize,
			/// <summary>Identifies the TXITEM_IncreaseFont ribbon item inside the TXITEM_FontGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_IncreaseFont,
			/// <summary>Identifies the TXITEM_DecreaseFont ribbon item inside the TXITEM_FontGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DecreaseFont,
			/// <summary>Identifies the TXITEM_ClearFormatting ribbon item inside the TXITEM_FontGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ClearFormatting,
			/// <summary>Identifies the TXITEM_Bold ribbon item inside the TXITEM_FontGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Bold,
			/// <summary>Identifies the TXITEM_Italic ribbon item inside the TXITEM_FontGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Italic,
			/// <summary>Identifies the TXITEM_Underline ribbon item inside the TXITEM_FontGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Underline,
			/// <summary>Identifies the TXITEM_Strikeout ribbon item inside the TXITEM_FontGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Strikeout,
			/// <summary>Identifies the TXITEM_Subscript ribbon item inside the TXITEM_FontGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Subscript,
			/// <summary>Identifies the TXITEM_Superscript ribbon item inside the TXITEM_FontGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Superscript,
			/// <summary>Identifies the TXITEM_ChangeCase ribbon item inside the TXITEM_FontGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ChangeCase,
			/// <summary>Identifies the TXITEM_TextBackColor ribbon item inside the TXITEM_FontGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TextBackColor,
			/// <summary>Identifies the TXITEM_TextColor ribbon item inside the TXITEM_FontGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_TextColor,
			/// <summary>Identifies the TXITEM_ParagraphGroup ribbon group inside the RibbonFormattingTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_ParagraphGroup,
			/// <summary>Identifies the dialog box launcher of the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle and ToolTipDescription resources. Limitations: The FindItem method returns null when passing this RibbonItem as an argument.</summary>
			TXITEM_ParagraphGroup_DialogBoxLauncher,
			/// <summary>Identifies the TXITEM_BulletedList ribbon item inside the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_BulletedList,
			/// <summary>Identifies the TXITEM_NumberedList ribbon item inside the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_NumberedList,
			/// <summary>Identifies the TXITEM_StructuredList ribbon item inside the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_StructuredList,
			/// <summary>Identifies the TXITEM_DecreaseIndent ribbon item inside the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_DecreaseIndent,
			/// <summary>Identifies the TXITEM_IncreaseIndent ribbon item inside the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_IncreaseIndent,
			/// <summary>Identifies the TXITEM_LeftToRight ribbon item inside the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_LeftToRight,
			/// <summary>Identifies the TXITEM_RightToLeft ribbon item inside the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_RightToLeft,
			/// <summary>Identifies the TXITEM_EditTabs ribbon item inside the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_EditTabs,
			/// <summary>Identifies the TXITEM_ControlChars ribbon item inside the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_ControlChars,
			/// <summary>Identifies the TXITEM_LeftAligned ribbon item inside the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_LeftAligned,
			/// <summary>Identifies the TXITEM_Centered ribbon item inside the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Centered,
			/// <summary>Identifies the TXITEM_RightAligned ribbon item inside the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_RightAligned,
			/// <summary>Identifies the TXITEM_Justified ribbon item inside the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Justified,
			/// <summary>Identifies the TXITEM_LineSpacing ribbon item inside the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_LineSpacing,
			/// <summary>Identifies the TXITEM_Borders ribbon item inside the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Borders,
			TXITEM_LeftFrameLine,
			TXITEM_TopFrameLine,
			TXITEM_RightFrameLine,
			TXITEM_BottomFrameLine,
			TXITEM_BoxFrame,
			TXITEM_AllFrameLines,
			TXITEM_InnerHorizontalFrameLines,
			TXITEM_InnerVerticalFrameLines,
			/// <summary>Identifies the TXITEM_BackColor ribbon item inside the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_BackColor,
			/// <summary>Identifies the TXITEM_FrameLineColor ribbon item inside the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_FrameLineColor,
			/// <summary>Identifies the TXITEM_FrameLineWidth ribbon item inside the TXITEM_ParagraphGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_FrameLineWidth,
			/// <summary>Identifies the TXITEM_StylesGroup ribbon group inside the RibbonFormattingTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_StylesGroup,
			/// <summary>Identifies the dialog box launcher of the TXITEM_StylesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, ToolTipTitle and ToolTipDescription resources. Limitations: The FindItem method returns null when passing this RibbonItem as an argument.</summary>
			TXITEM_StylesGroup_DialogBoxLauncher,
			/// <summary>Identifies the TXITEM_StyleName ribbon item inside the TXITEM_StylesGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_StyleName,
			/// <summary>Identifies the TXITEM_EditingGroup ribbon group inside the RibbonFormattingTab ribbon tab. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon, SmallIcon, Text and KeyTip resources.</summary>
			TXITEM_EditingGroup,
			/// <summary>Identifies the TXITEM_Find ribbon item inside the TXITEM_EditingGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Find,
			/// <summary>Identifies the TXITEM_Find_Sidebars ribbon item inside the TXITEM_EditingGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Find_Sidebars,
			/// <summary>Identifies the TXITEM_Replace ribbon item inside the TXITEM_EditingGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Replace,
			/// <summary>Identifies the TXITEM_Replace_Sidebars ribbon item inside the TXITEM_EditingGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle and ToolTipDescription resources.</summary>
			TXITEM_Replace_Sidebars,
			/// <summary>Identifies the TXITEM_Goto ribbon item inside the TXITEM_EditingGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Goto,
			/// <summary>Identifies the TXITEM_Goto_Sidebars ribbon item inside the TXITEM_EditingGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_Goto_Sidebars,
			/// <summary>Identifies the TXITEM_SelectAll ribbon item inside the TXITEM_EditingGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_SelectAll,
			/// <summary>Identifies the TXITEM_SelectObjects ribbon item inside the TXITEM_EditingGroup ribbon group. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon, Text, ToolTipTitle, ToolTipDescription and KeyTip resources.</summary>
			TXITEM_SelectObjects
		}

		/// <summary>Each RibbonDropDownItem represents a drop-down item in the RibbonFormattingTab.</summary>
		public enum RibbonDropDownItem
		{
			/// <summary>Identifies the TXITEM_PasteText drop-down item inside the TXITEM_Paste's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_PasteText,
			/// <summary>Identifies the TXITEM_PastePlainText drop-down item inside the TXITEM_Paste's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_PastePlainText,
			/// <summary>Identifies the TXITEM_PasteImage drop-down item inside the TXITEM_Paste's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_PasteImage,
			/// <summary>Identifies the TXITEM_PasteTextFrame drop-down item inside the TXITEM_Paste's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_PasteTextFrame,
			/// <summary>Identifies the TXITEM_PasteChart drop-down item inside the TXITEM_Paste's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_PasteChart,
			/// <summary>Identifies the TXITEM_PasteBarcode drop-down item inside the TXITEM_Paste's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_PasteBarcode,
			/// <summary>Identifies the TXITEM_PasteDrawing drop-down item inside the TXITEM_Paste's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_PasteDrawing,
			/// <summary>Identifies the TXITEM_ChangeCase_Sentence drop-down item inside the TXITEM_ChangeCase's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChangeCase_Sentence,
			/// <summary>Identifies the TXITEM_ChangeCase_Lower drop-down item inside the TXITEM_ChangeCase's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChangeCase_Lower,
			/// <summary>Identifies the TXITEM_ChangeCase_Upper drop-down item inside the TXITEM_ChangeCase's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChangeCase_Upper,
			/// <summary>Identifies the TXITEM_ChangeCase_Capitalize drop-down item inside the TXITEM_ChangeCase's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChangeCase_Capitalize,
			/// <summary>Identifies the TXITEM_ChangeCase_Toggle drop-down item inside the TXITEM_ChangeCase's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_ChangeCase_Toggle,
			/// <summary>Identifies the TXITEM_TextBackColor_Transparent drop-down item inside the TXITEM_TextBackColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TextBackColor_Transparent,
			/// <summary>Identifies the TXITEM_TextBackColor_MoreColors drop-down item inside the TXITEM_TextBackColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TextBackColor_MoreColors,
			/// <summary>Identifies the TXITEM_TextColor_Automatic drop-down item inside the TXITEM_TextColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TextColor_Automatic,
			/// <summary>Identifies the TXITEM_TextColor_MoreColors drop-down item inside the TXITEM_TextColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TextColor_MoreColors,
			/// <summary>Identifies the TXITEM_BulletedList_Characters drop-down item inside the TXITEM_BulletedList's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_BulletedList_Characters,
			/// <summary>Identifies the TXITEM_BulletedList_Format drop-down item inside the TXITEM_BulletedList's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BulletedList_Format,
			/// <summary>Identifies the TXITEM_NumberedList_Numbers drop-down item inside the TXITEM_NumberedList's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_NumberedList_Numbers,
			/// <summary>Identifies the TXITEM_NumberedList_Gallery_ArabicNumbers list view item inside the TXITEM_NumberedList's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon resource.</summary>
			TXITEM_NumberedList_Gallery_ArabicNumbers,
			/// <summary>Identifies the TXITEM_NumberedList_Gallery_CapitalLetters list view item inside the TXITEM_NumberedList's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon resource.</summary>
			TXITEM_NumberedList_Gallery_CapitalLetters,
			/// <summary>Identifies the TXITEM_NumberedList_Gallery_Letters list view item inside the TXITEM_NumberedList's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon resource.</summary>
			TXITEM_NumberedList_Gallery_Letters,
			/// <summary>Identifies the TXITEM_NumberedList_Gallery_RomanNumbers list view item inside the TXITEM_NumberedList's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon resource.</summary>
			TXITEM_NumberedList_Gallery_RomanNumbers,
			/// <summary>Identifies the TXITEM_NumberedList_Gallery_SmallRomanNumbers list view item inside the TXITEM_NumberedList's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon resource.</summary>
			TXITEM_NumberedList_Gallery_SmallRomanNumbers,
			/// <summary>Identifies the TXITEM_NumberedList_Format drop-down item inside the TXITEM_NumberedList's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_NumberedList_Format,
			/// <summary>Identifies the TXITEM_StructuredList_Numbers drop-down item inside the TXITEM_StructuredList's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding Text resource.</summary>
			TXITEM_StructuredList_Numbers,
			/// <summary>Identifies the TXITEM_StructuredList_Gallery_ArabicNumbers list view item inside the TXITEM_StructuredList's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon resource.</summary>
			TXITEM_StructuredList_Gallery_ArabicNumbers,
			/// <summary>Identifies the TXITEM_StructuredList_Gallery_CapitalLetters list view item inside the TXITEM_StructuredList's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon resource.</summary>
			TXITEM_StructuredList_Gallery_CapitalLetters,
			/// <summary>Identifies the TXITEM_StructuredList_Gallery_Letters list view item inside the TXITEM_StructuredList's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon resource.</summary>
			TXITEM_StructuredList_Gallery_Letters,
			/// <summary>Identifies the TXITEM_StructuredList_Gallery_RomanNumbers list view item inside the TXITEM_StructuredList's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon resource.</summary>
			TXITEM_StructuredList_Gallery_RomanNumbers,
			/// <summary>Identifies the TXITEM_StructuredList_Gallery_SmallRomanNumbers list view item inside the TXITEM_StructuredList's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding LargeIcon resource.</summary>
			TXITEM_StructuredList_Gallery_SmallRomanNumbers,
			/// <summary>Identifies the TXITEM_StructuredList_Format drop-down item inside the TXITEM_StructuredList's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_StructuredList_Format,
			/// <summary>Identifies the TXITEM_LeftFrameLine drop-down item inside the TXITEM_Borders's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_LeftFrameLine,
			/// <summary>Identifies the TXITEM_TopFrameLine drop-down item inside the TXITEM_Borders's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_TopFrameLine,
			/// <summary>Identifies the TXITEM_RightFrameLine drop-down item inside the TXITEM_Borders's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_RightFrameLine,
			/// <summary>Identifies the TXITEM_BottomFrameLine drop-down item inside the TXITEM_Borders's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BottomFrameLine,
			/// <summary>Identifies the TXITEM_BoxFrame drop-down item inside the TXITEM_Borders's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BoxFrame,
			/// <summary>Identifies the TXITEM_AllFrameLines drop-down item inside the TXITEM_Borders's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_AllFrameLines,
			/// <summary>Identifies the TXITEM_InnerHorizontalFrameLines drop-down item inside the TXITEM_Borders's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_InnerHorizontalFrameLines,
			/// <summary>Identifies the TXITEM_InnerVerticalFrameLines drop-down item inside the TXITEM_Borders's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_InnerVerticalFrameLines,
			/// <summary>Identifies the TXITEM_BackColor_Transparent drop-down item inside the TXITEM_BackColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BackColor_Transparent,
			/// <summary>Identifies the TXITEM_BackColor_MoreColors drop-down item inside the TXITEM_BackColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_BackColor_MoreColors,
			/// <summary>Identifies the TXITEM_FrameLineColor_Automatic drop-down item inside the TXITEM_FrameLineColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_FrameLineColor_Automatic,
			/// <summary>Identifies the TXITEM_FrameLineColor_MoreColors drop-down item inside the TXITEM_FrameLineColor's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_FrameLineColor_MoreColors,
			/// <summary>Identifies the TXITEM_Find_Sidebars_Vertical drop-down item inside the TXITEM_Find_Sidebars's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_Find_Sidebars_Vertical,
			/// <summary>Identifies the TXITEM_Find_Sidebars_Horizontal drop-down item inside the TXITEM_Find_Sidebars's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_Find_Sidebars_Horizontal,
			/// <summary>Identifies the TXITEM_Replace_Sidebars_Vertical drop-down item inside the TXITEM_Replace_Sidebars's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_Replace_Sidebars_Vertical,
			/// <summary>Identifies the TXITEM_Replace_Sidebars_Horizontal drop-down item inside the TXITEM_Replace_Sidebars's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_Replace_Sidebars_Horizontal,
			/// <summary>Identifies the TXITEM_Goto_Sidebars_Vertical drop-down item inside the TXITEM_Goto_Sidebars's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_Goto_Sidebars_Vertical,
			/// <summary>Identifies the TXITEM_Goto_Sidebars_Horizontal drop-down item inside the TXITEM_Goto_Sidebars's drop-down menu. The string conversion of that identifier can be passed to the appropriate ResourceProvider method to get the corresponding SmallIcon and Text resources.</summary>
			TXITEM_Goto_Sidebars_Horizontal
		}

		internal enum InternalRibbonItem
		{
			TXITEM_ClipboardGroup,
			TXITEM_Paste,
			TXITEM_PasteText,
			TXITEM_PastePlainText,
			TXITEM_PasteImage,
			TXITEM_PasteTextFrame,
			TXITEM_PasteChart,
			TXITEM_PasteBarcode,
			TXITEM_PasteDrawing,
			TXITEM_Cut,
			TXITEM_Copy,
			TXITEM_FontGroup,
			TXITEM_FontGroup_DialogBoxLauncher,
			TXITEM_FontFamily,
			TXITEM_FontSize,
			TXITEM_IncreaseFont,
			TXITEM_FontGroupSeperator1,
			TXITEM_DecreaseFont,
			TXITEM_ClearFormatting,
			TXITEM_Bold,
			TXITEM_Italic,
			TXITEM_Underline,
			TXITEM_Underline_Single,
			TXITEM_Underline_Doubled,
			TXITEM_Underline_SingleWordsOnly,
			TXITEM_Underline_DoubledWordsOnly,
			TXITEM_Strikeout,
			TXITEM_Subscript,
			TXITEM_Superscript,
			TXITEM_ChangeCase,
			TXITEM_ChangeCase_Sentence,
			TXITEM_ChangeCase_Lower,
			TXITEM_ChangeCase_Upper,
			TXITEM_ChangeCase_Capitalize,
			TXITEM_ChangeCase_Toggle,
			TXITEM_FontGroupSeperator2,
			TXITEM_TextBackColor,
			TXITEM_TextBackColor_Transparent,
			TXITEM_TextBackColorSeperator1,
			TXITEM_TextBackColor_Gallery,
			TXITEM_TextBackColorSeperator2,
			TXITEM_TextBackColor_MoreColors,
			TXITEM_TextColor,
			TXITEM_TextColor_Automatic,
			TXITEM_TextColorSeperator1,
			TXITEM_TextColor_Gallery,
			TXITEM_TextColorSeperator2,
			TXITEM_TextColor_MoreColors,
			TXITEM_ParagraphGroup,
			TXITEM_ParagraphGroup_DialogBoxLauncher,
			TXITEM_BulletedList,
			TXITEM_BulletedList_Characters,
			TXITEM_BulletedListSeperator1,
			TXITEM_BulletedList_Gallery,
			TXITEM_BulletedListSeperator2,
			TXITEM_BulletedList_Format,
			TXITEM_NumberedList,
			TXITEM_NumberedList_Numbers,
			TXITEM_NumberedListSeperator1,
			TXITEM_NumberedList_Gallery,
			TXITEM_NumberedListSeperator2,
			TXITEM_NumberedList_Format,
			TXITEM_StructuredList,
			TXITEM_StructuredList_Numbers,
			TXITEM_StructuredListSeperator1,
			TXITEM_StructuredList_Gallery,
			TXITEM_StructuredListSeperator2,
			TXITEM_StructuredList_Format,
			TXITEM_ParagraphGroupSeperator1,
			TXITEM_DecreaseIndent,
			TXITEM_IncreaseIndent,
			TXITEM_ParagraphGroupSeperator2,
			TXITEM_LeftToRight,
			TXITEM_RightToLeft,
			TXITEM_ParagraphGroupSeperator3,
			TXITEM_EditTabs,
			TXITEM_ParagraphGroupSeperator4,
			TXITEM_ControlChars,
			TXITEM_LeftAligned,
			TXITEM_Centered,
			TXITEM_RightAligned,
			TXITEM_Justified,
			TXITEM_ParagraphGroupSeperator5,
			TXITEM_LineSpacing,
			TXITEM_LineSpacing_100,
			TXITEM_LineSpacing_115,
			TXITEM_LineSpacing_150,
			TXITEM_LineSpacing_200,
			TXITEM_LineSpacing_250,
			TXITEM_LineSpacing_300,
			TXITEM_ParagraphGroupSeperator6,
			TXITEM_Borders,
			TXITEM_LeftFrameLine,
			TXITEM_TopFrameLine,
			TXITEM_RightFrameLine,
			TXITEM_BottomFrameLine,
			TXITEM_BordersSeperator1,
			TXITEM_BoxFrame,
			TXITEM_AllFrameLines,
			TXITEM_BordersSeperator2,
			TXITEM_InnerHorizontalFrameLines,
			TXITEM_InnerVerticalFrameLines,
			TXITEM_BackColor,
			TXITEM_BackColor_Transparent,
			TXITEM_BackColorSeperator1,
			TXITEM_BackColor_Gallery,
			TXITEM_BackColorSeperator2,
			TXITEM_BackColor_MoreColors,
			TXITEM_FrameLineColor,
			TXITEM_FrameLineColor_Automatic,
			TXITEM_FrameLineColorSeperator1,
			TXITEM_FrameLineColor_Gallery,
			TXITEM_FrameLineColorSeperator2,
			TXITEM_FrameLineColor_MoreColors,
			TXITEM_FrameLineWidth,
			TXITEM_FrameLineWidth_25,
			TXITEM_FrameLineWidth_50,
			TXITEM_FrameLineWidth_75,
			TXITEM_FrameLineWidth_100,
			TXITEM_FrameLineWidth_150,
			TXITEM_FrameLineWidth_225,
			TXITEM_FrameLineWidth_300,
			TXITEM_FrameLineWidth_450,
			TXITEM_FrameLineWidth_600,
			TXITEM_StylesGroup,
			TXITEM_StylesGroup_DialogBoxLauncher,
			TXITEM_StyleName,
			TXITEM_EditingGroup,
			TXITEM_Find,
			TXITEM_Find_Dialog,
			TXITEM_Find_Sidebars,
			TXITEM_Find_Sidebars_Vertical,
			TXITEM_Find_Sidebars_Horizontal,
			TXITEM_Replace,
			TXITEM_Replace_Dialog,
			TXITEM_Replace_Sidebars,
			TXITEM_Replace_Sidebars_Vertical,
			TXITEM_Replace_Sidebars_Horizontal,
			TXITEM_Goto,
			TXITEM_Goto_Dialog,
			TXITEM_Goto_Sidebars,
			TXITEM_Goto_Sidebars_Vertical,
			TXITEM_Goto_Sidebars_Horizontal,
			TXITEM_SelectAll,
			TXITEM_SelectObjects
		}

		private Class502 class502_0;

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private List<Dictionary<string, object>> list_0 = new List<Dictionary<string, object>>();

		private Sidebar sidebar_0;

		private Sidebar sidebar_1;

		private Sidebar sidebar_2;

		private Sidebar sidebar_3;

		private Sidebar sidebar_4;

		private Sidebar sidebar_5;

		private Sidebar sidebar_6;

		/// <summary>Gets or sets the horizontal sidebar that is connected to the RibbonFormattingTab's TXITEM_Find button and its horizontal sidebar drop down button.</summary>
		[DefaultValue(null)]
		[Category("Behavior")]
		[Attribute3("PROP_FINDHORIZONTALSIDEBAR")]
		public Sidebar FindHorizontalSidebar
		{
			get
			{
				return this.sidebar_1;
			}
			set
			{
				Sidebar sidebar;
				if ((sidebar = this.sidebar_1) != (this.sidebar_1 = value))
				{
					if (this.sidebar_1 != null)
					{
						this.sidebar_1.TextControl = this.TextControl_0;
					}
					(this.class502_0.BindingAdapter_0 as Class473).method_69(sidebar);
				}
			}
		}

		/// <summary>Gets or sets the vertical sidebar that is connected to the RibbonFormattingTab's TXITEM_Find button and its vertical sidebar drop down button.</summary>
		[DefaultValue(null)]
		[Attribute3("PROP_FINDSIDEBAR")]
		[Category("Behavior")]
		public Sidebar FindSidebar
		{
			get
			{
				return this.sidebar_0;
			}
			set
			{
				Sidebar sidebar;
				if ((sidebar = this.sidebar_0) != (this.sidebar_0 = value))
				{
					if (this.sidebar_0 != null)
					{
						this.sidebar_0.TextControl = this.TextControl_0;
					}
					(this.class502_0.BindingAdapter_0 as Class473).method_69(sidebar);
				}
			}
		}

		/// <summary>Gets or sets the horizontal sidebar that is connected to the RibbonFormattingTab's TXITEM_Goto button.</summary>
		[Attribute3("PROP_GOTOHORIZONTALSIDEBAR")]
		[Category("Behavior")]
		[DefaultValue(null)]
		public Sidebar GotoHorizontalSidebar
		{
			get
			{
				return this.sidebar_3;
			}
			set
			{
				Sidebar sidebar;
				if ((sidebar = this.sidebar_3) != (this.sidebar_3 = value))
				{
					if (this.sidebar_3 != null)
					{
						this.sidebar_3.TextControl = this.TextControl_0;
					}
					(this.class502_0.BindingAdapter_0 as Class473).method_73(sidebar);
				}
			}
		}

		/// <summary>Gets or sets the vertical sidebar that is connected to the RibbonFormattingTab's TXITEM_Goto button and its vertical sidebar drop down button.</summary>
		[Attribute3("PROP_GOTOSIDEBAR")]
		[DefaultValue(null)]
		[Category("Behavior")]
		public Sidebar GotoSidebar
		{
			get
			{
				return this.sidebar_2;
			}
			set
			{
				Sidebar sidebar;
				if ((sidebar = this.sidebar_2) != (this.sidebar_2 = value))
				{
					if (this.sidebar_2 != null)
					{
						this.sidebar_2.TextControl = this.TextControl_0;
					}
					(this.class502_0.BindingAdapter_0 as Class473).method_73(sidebar);
				}
			}
		}

		/// <summary>Gets or sets the horizontal sidebar that is connected to the RibbonFormattingTab's TXITEM_Replace button.</summary>
		[Attribute3("PROP_REPLACEHORIZONTALSIDEBAR")]
		[Category("Behavior")]
		[DefaultValue(null)]
		public Sidebar ReplaceHorizontalSidebar
		{
			get
			{
				return this.sidebar_5;
			}
			set
			{
				Sidebar sidebar;
				if ((sidebar = this.sidebar_5) != (this.sidebar_5 = value))
				{
					if (this.sidebar_5 != null)
					{
						this.sidebar_5.TextControl = this.TextControl_0;
					}
					(this.class502_0.BindingAdapter_0 as Class473).method_71(sidebar);
				}
			}
		}

		/// <summary>Gets or sets the vertical sidebar that is connected to the RibbonFormattingTab's TXITEM_Replace button and its vertical sidebar drop down button.</summary>
		[Category("Behavior")]
		[Attribute3("PROP_REPLACESIDEBAR")]
		[DefaultValue(null)]
		public Sidebar ReplaceSidebar
		{
			get
			{
				return this.sidebar_4;
			}
			set
			{
				Sidebar sidebar;
				if ((sidebar = this.sidebar_4) != (this.sidebar_4 = value))
				{
					if (this.sidebar_4 != null)
					{
						this.sidebar_4.TextControl = this.TextControl_0;
					}
					(this.class502_0.BindingAdapter_0 as Class473).method_71(sidebar);
				}
			}
		}

		/// <summary>Gets or sets the sidebar that is connected to the RibbonFormattingTab's TXITEM_StylesGroup's dialog box launcher.</summary>
		[DefaultValue(null)]
		[Category("Behavior")]
		[Attribute3("PROP_STYLESSIDEBAR")]
		public Sidebar StylesSidebar
		{
			get
			{
				return this.sidebar_6;
			}
			set
			{
				Sidebar sidebar;
				if ((sidebar = this.sidebar_6) != (this.sidebar_6 = value))
				{
					if (this.sidebar_6 != null)
					{
						this.sidebar_6.TextControl = this.TextControl_0;
					}
					(this.class502_0.BindingAdapter_0 as Class473).method_68(sidebar);
				}
			}
		}

		protected override Padding DefaultPadding => new Padding(0);

		protected override Padding DefaultMargin => new Padding(0);

		public override string KeyTip
		{
			get
			{
				if (base.KeyTip == string.Empty)
				{
					return this.resourceManager_0.GetString("KEYTIP_FormattingTab");
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
					return this.resourceManager_0.GetString("HEADER_RibbonFormattingTab");
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
					this.class502_0.BindingAdapter_0.OnDisconnectingTextControl();
					this.class502_0.BindingAdapter_0.TextControl.PropertyChanged -= this.class502_0.method_15;
				}
				TextControl textControl3 = (base.TextControl_0 = (this.class502_0.BindingAdapter_0.TextControl = value));
				if (this.sidebar_1 != null)
				{
					this.sidebar_1.TextControl = value;
				}
				if (this.sidebar_0 != null)
				{
					this.sidebar_0.TextControl = value;
				}
				if (this.sidebar_3 != null)
				{
					this.sidebar_3.TextControl = value;
				}
				if (this.sidebar_2 != null)
				{
					this.sidebar_2.TextControl = value;
				}
				if (this.sidebar_5 != null)
				{
					this.sidebar_5.TextControl = value;
				}
				if (this.sidebar_4 != null)
				{
					this.sidebar_4.TextControl = value;
				}
				if (this.sidebar_6 != null)
				{
					this.sidebar_6.TextControl = value;
				}
				if (base.TextControl_0 != null)
				{
					this.class502_0.BindingAdapter_0.OnTextControlConnected();
					if (this.class502_0.Boolean_0)
					{
						this.vmethod_0();
					}
					this.class502_0.BindingAdapter_0.TextControl.PropertyChanged += this.class502_0.method_15;
				}
				this.class502_0.method_5();
				(this.class502_0.BindingAdapter_0 as Class473).method_69(null);
				(this.class502_0.BindingAdapter_0 as Class473).method_73(null);
				(this.class502_0.BindingAdapter_0 as Class473).method_71(null);
				(this.class502_0.BindingAdapter_0 as Class473).method_68(null);
			}
		}

		/// <summary>Initializes a new instance of the RibbonFormattingTab class.</summary>
		public RibbonFormattingTab()
		{
			this.method_2();
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			PointF dpi = base.method_0();
			this.class502_0.BindingAdapter_0.AwareOfDPI(dpi);
			base.OnHandleCreated(eventArgs_0);
		}

		internal override void vmethod_0(params object[] object_0)
		{
			this.class502_0.BindingAdapter_0.UpdateRibbonTab();
		}

		internal override void vmethod_1(uint uint_1)
		{
			base.vmethod_1(uint_1);
			this.class502_0.BindingAdapter_0.AwareOfDPI(base.method_0());
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
			this.class502_0 = new Class502(this, new Class473(this));
			this.class502_0.method_10(base.RibbonGroups);
			this.class502_0.method_11(base.RibbonGroups);
			this.class502_0.method_12(base.RibbonGroups);
			this.class502_0.method_13(base.RibbonGroups);
			this.class502_0.method_14(base.RibbonGroups);
			this.list_0.Add(this.class502_0.TXITEM_ClipboardGroup_Items);
			this.list_0.Add(this.class502_0.TXITEM_FontGroup_Items);
			this.list_0.Add(this.class502_0.TXITEM_ParagraphGroup_Items);
			this.list_0.Add(this.class502_0.TXITEM_StylesGroup_Items);
			this.list_0.Add(this.class502_0.TXITEM_EditingGroup_Items);
		}
	}
}
