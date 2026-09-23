using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using ns21;

namespace TXTextControl
{
	/// <summary>The InputFormat class represents all formatting attributes at the current text input position.</summary>
	public class InputFormat
	{
		private enum Enum66
		{
			const_0 = 1,
			const_1 = 2,
			const_2 = 4,
			const_3 = 8,
			const_4 = 0x10,
			const_5 = 0x20,
			const_6 = 0xF,
			const_7 = 0x3F,
			const_8 = 0x40,
			const_9 = 0x80,
			const_10 = 0x100,
			const_11 = 448,
			const_12 = 0x200,
			const_13 = 0x400,
			const_14 = 0x800,
			const_15 = 0x1000,
			const_16 = 0x2000,
			const_17 = 0x4000,
			const_18 = 24576,
			const_19 = 32704,
			const_20 = 0x7FFF
		}

		private TextControlCore textControlCore_0;

		private Selection selection_0 = new Selection();

		private Selection.Attribute attribute_0;

		private ParagraphFormat.Attribute attribute_1;

		private ListFormat.Attribute attribute_2;

		private Enum66 enum66_0;

		private Enum66 enum66_1;

		private Enum66 enum66_2;

		private bool bool_0 = true;

		private bool bool_1 = true;

		private Color color_0 = Color.Transparent;

		private bool bool_2;

		private bool bool_3;

		private char char_0 = '·';

		private Color color_1 = SystemColors.WindowText;

		private int int_0;

		private bool bool_4;

		private bool bool_5;

		private bool bool_6;

		private string string_0;

		private bool bool_7;

		private bool bool_8;

		private bool bool_9 = true;

		private bool bool_10 = true;

		private bool bool_11;

		private FontUnderlineStyle fontUnderlineStyle_0 = FontUnderlineStyle.Single;

		private bool bool_12;

		private EventHandler eventHandler_0;

		private EventHandler eventHandler_1;

		private EventHandler eventHandler_2;

		private EventHandler eventHandler_3;

		private EventHandler eventHandler_4;

		private EventHandler eventHandler_5;

		private EventHandler eventHandler_6;

		private EventHandler eventHandler_7;

		private EventHandler eventHandler_8;

		private EventHandler eventHandler_9;

		private EventHandler eventHandler_10;

		private EventHandler eventHandler_11;

		private EventHandler eventHandler_12;

		private EventHandler eventHandler_13;

		private EventHandler eventHandler_14;

		private EventHandler eventHandler_15;

		private EventHandler eventHandler_16;

		private EventHandler eventHandler_17;

		private EventHandler eventHandler_18;

		private EventHandler eventHandler_19;

		private EventHandler eventHandler_20;

		private EventHandler eventHandler_21;

		private EventHandler eventHandler_22;

		private EventHandler eventHandler_23;

		private EventHandler eventHandler_24;

		private EventHandler eventHandler_25;

		private EventHandler eventHandler_26;

		private EventHandler eventHandler_27;

		private EventHandler eventHandler_28;

		private EventHandler eventHandler_29;

		private EventHandler eventHandler_30;

		private EventHandler eventHandler_31;

		private EventHandler eventHandler_32;

		private EventHandler eventHandler_33;

		private EventHandler eventHandler_34;

		private EventHandler eventHandler_35;

		private EventHandler eventHandler_36;

		private EventHandler eventHandler_37;

		private EventHandler eventHandler_38;

		private EventHandler eventHandler_39;

		private EventHandler eventHandler_40;

		private EventHandler eventHandler_41;

		private EventHandler eventHandler_42;

		private EventHandler eventHandler_43;

		private EventHandler eventHandler_44;

		private EventHandler eventHandler_45;

		private EventHandler eventHandler_46;

		private EventHandler eventHandler_47;

		private EventHandler eventHandler_48;

		/// <summary>Gets or sets a value specifying whether all frame lines, including all inner frame lines, are set for the selected text.</summary>
		public bool AllFrameLines
		{
			get
			{
				this.method_7(Enum66.const_7);
				if (this.bool_6 && this.bool_11 && this.bool_8 && this.bool_3 && (this.bool_4 || !this.bool_0) && (this.bool_5 || !this.bool_1))
				{
					return true;
				}
				return false;
			}
			set
			{
				this.bool_6 = value;
				this.bool_11 = value;
				this.bool_8 = value;
				this.bool_3 = value;
				this.bool_4 = value;
				this.bool_5 = value;
				this.enum66_0 = Enum66.const_7;
				this.method_8();
			}
		}

		/// <summary>Gets or sets the color used to display the frame fill color at the current input position.</summary>
		public Color? FrameFillColor
		{
			get
			{
				this.method_7(Enum66.const_12);
				if ((this.enum66_2 & Enum66.const_12) == 0)
				{
					return this.color_0;
				}
				return null;
			}
			set
			{
				if (value.HasValue)
				{
					this.enum66_0 = Enum66.const_12;
					this.color_0 = value.Value;
					this.method_8();
				}
			}
		}

		/// <summary>Gets or sets a value specifying whether text is bold at the current input position.</summary>
		[DefaultValue(false)]
		public bool? Bold
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(Selection.Attribute.Bold))
				{
					return null;
				}
				return this.selection_0.Bold;
			}
			set
			{
				this.attribute_0 = Selection.Attribute.Bold;
				if (value.HasValue)
				{
					this.selection_0.Bold = value.Value;
				}
				this.attribute_0 = (Selection.Attribute)0;
			}
		}

		/// <summary>Gets or sets a value specifying whether text is bottom aligned at the current input position.</summary>
		[DefaultValue(false)]
		public bool? BottomAligned
		{
			get
			{
				this.method_7(Enum66.const_10);
				if ((this.enum66_2 & Enum66.const_10) == 0)
				{
					return this.bool_2;
				}
				return null;
			}
			set
			{
				if (value.HasValue)
				{
					this.enum66_0 = Enum66.const_10;
					this.enum66_1 &= (Enum66)(-449);
					this.bool_2 = value.Value;
					this.method_8();
				}
			}
		}

		/// <summary>Gets or sets a bottom paragraph distance, in twips, at the current input position.</summary>
		[DefaultValue(0)]
		public int? BottomDistance
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(ParagraphFormat.Attribute.BottomDistance))
				{
					return null;
				}
				return this.selection_0.ParagraphFormat.BottomDistance;
			}
			set
			{
				this.attribute_1 = ParagraphFormat.Attribute.BottomDistance;
				if (value.HasValue)
				{
					this.selection_0.ParagraphFormat.BottomDistance = value.Value;
				}
				this.attribute_1 = (ParagraphFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets a value specifying whether there is a frame line at the bottom of the text.</summary>
		public bool BottomFrameLine
		{
			get
			{
				this.method_7(Enum66.const_3);
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
				this.enum66_0 = Enum66.const_3;
				this.method_8();
			}
		}

		/// <summary>Gets or sets a value specifying whether there is a complete frame around the text.</summary>
		public bool BoxFrame
		{
			get
			{
				this.method_7(Enum66.const_7);
				if (this.bool_6 && this.bool_11 && this.bool_8 && this.bool_3 && !this.bool_4 && !this.bool_5)
				{
					return true;
				}
				return false;
			}
			set
			{
				this.bool_6 = value;
				this.bool_11 = value;
				this.bool_8 = value;
				this.bool_3 = value;
				this.bool_4 = false;
				this.bool_5 = false;
				this.enum66_0 = Enum66.const_7;
				this.method_8();
			}
		}

		/// <summary>Gets or sets the bullet character at the current input position.</summary>
		[DefaultValue('·')]
		public char? BulletCharacter
		{
			get
			{
				if (this.selection_0.ListFormat.Type == ListType.Bulleted && this.selection_0.IsCommonValueSelected(ListFormat.Attribute.BulletCharacter))
				{
					return this.selection_0.ListFormat.BulletCharacter;
				}
				return null;
			}
			set
			{
				this.attribute_2 = (ListFormat.Attribute)2304;
				if (((int?)value).HasValue)
				{
					ListFormat listFormat = new ListFormat(ListType.Bulleted);
					listFormat.BulletCharacter = value.Value;
					this.selection_0.ListFormat = listFormat;
					this.char_0 = value.Value;
				}
				this.attribute_2 = (ListFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets a value specifying whether there is a bulleted list at the current input position.</summary>
		[DefaultValue(false)]
		public bool? BulletedList
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(ListFormat.Attribute.Type))
				{
					return null;
				}
				return (this.selection_0.ListFormat.Type == ListType.Bulleted) ? true : false;
			}
			set
			{
				this.attribute_2 = (ListFormat.Attribute)2304;
				if (value == true)
				{
					ListFormat listFormat = new ListFormat(ListType.Bulleted);
					listFormat.BulletCharacter = this.char_0;
					this.selection_0.ListFormat = listFormat;
				}
				else
				{
					this.selection_0.ListFormat.Type = ListType.None;
				}
				this.attribute_2 = (ListFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets a value specifying whether text is centered at the current input position.</summary>
		[DefaultValue(false)]
		public bool? Centered
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(ParagraphFormat.Attribute.Alignment))
				{
					return null;
				}
				return (this.selection_0.ParagraphFormat.Alignment == HorizontalAlignment.Center) ? true : false;
			}
			set
			{
				this.attribute_1 = ParagraphFormat.Attribute.Alignment;
				if (value == true)
				{
					this.selection_0.ParagraphFormat.Alignment = HorizontalAlignment.Center;
				}
				this.attribute_1 = (ParagraphFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets the font family at the current input position.</summary>
		public string FontFamily
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(Selection.Attribute.FontName))
				{
					return null;
				}
				return this.selection_0.FontName;
			}
			set
			{
				this.attribute_0 = Selection.Attribute.FontName;
				if (value != null)
				{
					this.selection_0.FontName = value;
				}
				this.attribute_0 = (Selection.Attribute)0;
			}
		}

		/// <summary>Gets or sets the font's size, in twips, at the current input position.</summary>
		public int? FontSize
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(Selection.Attribute.FontSize))
				{
					return null;
				}
				return this.selection_0.FontSize;
			}
			set
			{
				this.attribute_0 = Selection.Attribute.FontSize;
				if (value.HasValue)
				{
					this.selection_0.FontSize = value.Value;
				}
				this.attribute_0 = (Selection.Attribute)0;
			}
		}

		/// <summary>Gets or sets the color used to display the color of frame lines at the current text input position.</summary>
		public Color? FrameLineColor
		{
			get
			{
				this.method_7(Enum66.const_13);
				if ((this.enum66_2 & Enum66.const_13) == 0)
				{
					return this.color_1;
				}
				return null;
			}
			set
			{
				if (value.HasValue)
				{
					this.enum66_0 = Enum66.const_13;
					this.color_1 = value.Value;
					this.method_8();
				}
			}
		}

		/// <summary>Gets or sets the line width, in twips, of the paragraph's or table's frame at the current input position.</summary>
		[DefaultValue(0)]
		public int? FrameLineWidth
		{
			get
			{
				this.method_7(Enum66.const_14);
				if ((this.enum66_2 & Enum66.const_14) == 0)
				{
					return this.int_0;
				}
				return null;
			}
			set
			{
				if (value.HasValue)
				{
					this.enum66_0 = Enum66.const_14;
					this.int_0 = value.Value;
					this.method_8();
				}
			}
		}

		/// <summary>Gets or sets the hanging indent, in twips, at the current input position.</summary>
		[DefaultValue(0)]
		public int? HangingIndent
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(ParagraphFormat.Attribute.HangingIndent))
				{
					return null;
				}
				return this.selection_0.ParagraphFormat.HangingIndent;
			}
			set
			{
				this.attribute_1 = ParagraphFormat.Attribute.HangingIndent;
				if (value.HasValue)
				{
					this.selection_0.ParagraphFormat.HangingIndent = value.Value;
				}
				this.attribute_1 = (ParagraphFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets a value specifying whether all inner horizontal frame lines are set for the selected text.</summary>
		public bool InnerHorizontalFrameLines
		{
			get
			{
				this.method_7(Enum66.const_4);
				return this.bool_4;
			}
			set
			{
				this.bool_4 = value;
				this.enum66_0 = Enum66.const_4;
				this.method_8();
			}
		}

		/// <summary>Gets or sets a value specifying whether all inner vertical frame lines are set for the selected text.</summary>
		public bool InnerVerticalFrameLines
		{
			get
			{
				this.method_7(Enum66.const_5);
				return this.bool_5;
			}
			set
			{
				this.bool_5 = value;
				this.enum66_0 = Enum66.const_5;
				this.method_8();
			}
		}

		/// <summary>Gets or sets a value specifying whether the text is italic at the current input position.</summary>
		[DefaultValue(false)]
		public bool? Italic
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(Selection.Attribute.Italic))
				{
					return null;
				}
				return this.selection_0.Italic;
			}
			set
			{
				this.attribute_0 = Selection.Attribute.Italic;
				if (value.HasValue)
				{
					this.selection_0.Italic = value.Value;
				}
				this.attribute_0 = (Selection.Attribute)0;
			}
		}

		/// <summary>Gets or sets a value specifying whether text is justified at the current input position.</summary>
		[DefaultValue(false)]
		public bool? Justified
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(ParagraphFormat.Attribute.Alignment))
				{
					return null;
				}
				return (this.selection_0.ParagraphFormat.Alignment == HorizontalAlignment.Justify) ? true : false;
			}
			set
			{
				this.attribute_1 = ParagraphFormat.Attribute.Alignment;
				if (value == true)
				{
					this.selection_0.ParagraphFormat.Alignment = HorizontalAlignment.Justify;
				}
				this.attribute_1 = (ParagraphFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets a value specifying whether text is left aligned at the current input position.</summary>
		[DefaultValue(true)]
		public bool? LeftAligned
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(ParagraphFormat.Attribute.Alignment))
				{
					return null;
				}
				return (this.selection_0.ParagraphFormat.Alignment == HorizontalAlignment.Left) ? true : false;
			}
			set
			{
				this.attribute_1 = ParagraphFormat.Attribute.Alignment;
				if (value == true)
				{
					this.selection_0.ParagraphFormat.Alignment = HorizontalAlignment.Left;
				}
				this.attribute_1 = (ParagraphFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets a value specifying whether there is a frame line at the left side of the text.</summary>
		public bool LeftFrameLine
		{
			get
			{
				this.method_7(Enum66.const_0);
				return this.bool_6;
			}
			set
			{
				this.bool_6 = value;
				this.enum66_0 = Enum66.const_0;
				this.method_8();
			}
		}

		/// <summary>Gets or sets the left indent, in twips, at the current input position.</summary>
		[DefaultValue(0)]
		public int? LeftIndent
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(ParagraphFormat.Attribute.LeftIndent))
				{
					return null;
				}
				return this.selection_0.ParagraphFormat.LeftIndent;
			}
			set
			{
				this.attribute_1 = ParagraphFormat.Attribute.LeftIndent;
				if (value.HasValue)
				{
					this.selection_0.ParagraphFormat.LeftIndent = value.Value;
				}
				this.attribute_1 = (ParagraphFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets the line spacing, in percent, at the current input position.</summary>
		public int? LineSpacing
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(ParagraphFormat.Attribute.LineSpacing))
				{
					return null;
				}
				return this.selection_0.ParagraphFormat.LineSpacing;
			}
			set
			{
				this.attribute_1 = ParagraphFormat.Attribute.LineSpacing;
				if (value.HasValue)
				{
					this.selection_0.ParagraphFormat.LineSpacing = value.Value;
				}
				this.attribute_1 = (ParagraphFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets a value specifying whether there is a numbered list at the current input position.</summary>
		[DefaultValue(false)]
		public bool? NumberedList
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(ListFormat.Attribute.Type))
				{
					return null;
				}
				return (this.selection_0.ListFormat.Type == ListType.Numbered) ? true : false;
			}
			set
			{
				this.attribute_2 = (ListFormat.Attribute)2056;
				this.selection_0.ListFormat.Type = ((value != true) ? ListType.None : ListType.Numbered);
				this.attribute_2 = (ListFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets the number format for a numbered list at the current input position.</summary>
		public NumFormat NumberedListFormat
		{
			get
			{
				if (this.selection_0.ListFormat.Type == ListType.Numbered && this.selection_0.IsCommonValueSelected(ListFormat.Attribute.NumberFormat))
				{
					return this.selection_0.ListFormat.NumberFormat;
				}
				return NumFormat.None;
			}
			set
			{
				this.attribute_2 = (ListFormat.Attribute)2056;
				if (value != 0)
				{
					ListFormat listFormat = new ListFormat(ListType.Numbered);
					listFormat.NumberFormat = value;
					this.selection_0.ListFormat = listFormat;
				}
				this.attribute_2 = (ListFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets a number format which can be used to automatically format numbers in table cells.</summary>
		[DefaultValue(null)]
		public string NumberFormat
		{
			get
			{
				this.method_7(Enum66.const_15);
				return this.string_0;
			}
			set
			{
				if (value != null)
				{
					this.enum66_0 = Enum66.const_15;
					this.string_0 = value;
					this.method_8();
				}
			}
		}

		/// <summary>Returns an array of all supported number formats for numbered and structured lists.</summary>
		public NumFormat[] NumberFormats => new NumFormat[5]
		{
			NumFormat.ArabicNumbers,
			NumFormat.Letters,
			NumFormat.CapitalLetters,
			NumFormat.RomanNumbers,
			NumFormat.SmallRomanNumbers
		};

		/// <summary>Gets or sets a value specifying whether text at the current input position is interpreted as a number which means that the period character (.) is defined as decimal separator and the comma character (,) is defined as thousands separator.</summary>
		[DefaultValue(false)]
		public bool? NumberTextType
		{
			get
			{
				this.method_7(Enum66.const_16);
				if ((this.enum66_2 & Enum66.const_16) == 0)
				{
					return this.bool_7;
				}
				return null;
			}
			set
			{
				if (value == true)
				{
					this.enum66_0 = Enum66.const_16;
					this.enum66_1 &= (Enum66)(-24577);
					this.bool_7 = value.Value;
					this.method_8();
				}
			}
		}

		/// <summary>Gets or sets a value specifying whether text is right aligned at the current input position.</summary>
		[DefaultValue(false)]
		public bool? RightAligned
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(ParagraphFormat.Attribute.Alignment))
				{
					return null;
				}
				return (this.selection_0.ParagraphFormat.Alignment == HorizontalAlignment.Right) ? true : false;
			}
			set
			{
				this.attribute_1 = ParagraphFormat.Attribute.Alignment;
				if (value == true)
				{
					this.selection_0.ParagraphFormat.Alignment = HorizontalAlignment.Right;
				}
				this.attribute_1 = (ParagraphFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets a value specifying whether there is a frame line at the right side of the text.</summary>
		public bool RightFrameLine
		{
			get
			{
				this.method_7(Enum66.const_2);
				return this.bool_8;
			}
			set
			{
				this.bool_8 = value;
				this.enum66_0 = Enum66.const_2;
				this.method_8();
			}
		}

		/// <summary>Gets or sets the right indent, in twips, at the current input position.</summary>
		[DefaultValue(0)]
		public int? RightIndent
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(ParagraphFormat.Attribute.RightIndent))
				{
					return null;
				}
				return this.selection_0.ParagraphFormat.RightIndent;
			}
			set
			{
				this.attribute_1 = ParagraphFormat.Attribute.RightIndent;
				if (value.HasValue)
				{
					this.selection_0.ParagraphFormat.RightIndent = value.Value;
				}
				this.attribute_1 = (ParagraphFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets a value specifying whether the writung direction is left-to-right at the current input position.</summary>
		[DefaultValue(true)]
		public bool? LeftToRight
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(ParagraphFormat.Attribute.Direction))
				{
					return null;
				}
				return (this.selection_0.ParagraphFormat.Direction == Direction.LeftToRight) ? true : false;
			}
			set
			{
				this.attribute_1 = (ParagraphFormat.Attribute)262145;
				if (value == true)
				{
					this.selection_0.ChangeDirection(Direction.LeftToRight);
				}
				this.attribute_1 = (ParagraphFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets a value specifying whether the writing direction is right-to-left at the current input position.</summary>
		[DefaultValue(false)]
		public bool? RightToLeft
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(ParagraphFormat.Attribute.Direction))
				{
					return null;
				}
				return (this.selection_0.ParagraphFormat.Direction == Direction.RightToLeft) ? true : false;
			}
			set
			{
				this.attribute_1 = (ParagraphFormat.Attribute)262145;
				if (value == true)
				{
					this.selection_0.ChangeDirection(Direction.RightToLeft);
				}
				this.attribute_1 = (ParagraphFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets a value specifying whether the text at the current input position is interpreted as standard text which means that it is displayed as it is.</summary>
		[DefaultValue(true)]
		public bool? StandardTextType
		{
			get
			{
				this.method_7(Enum66.const_17);
				if ((this.enum66_2 & Enum66.const_17) == 0)
				{
					return this.bool_9;
				}
				return null;
			}
			set
			{
				if (value == true)
				{
					this.enum66_0 = Enum66.const_17;
					this.enum66_1 &= (Enum66)(-24577);
					this.bool_9 = value.Value;
					this.method_8();
				}
			}
		}

		/// <summary>Gets or sets a value specifying whether the text is strikeout at the current input position.</summary>
		[DefaultValue(false)]
		public bool? Strikeout
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(Selection.Attribute.Strikeout))
				{
					return null;
				}
				return this.selection_0.Strikeout;
			}
			set
			{
				this.attribute_0 = Selection.Attribute.Strikeout;
				if (value.HasValue)
				{
					this.selection_0.Strikeout = value.Value;
				}
				this.attribute_0 = (Selection.Attribute)0;
			}
		}

		/// <summary>Gets or sets a value specifying whether there is a structured list at the current input position.</summary>
		[DefaultValue(false)]
		public bool? StructuredList
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(ListFormat.Attribute.Type))
				{
					return null;
				}
				return (this.selection_0.ListFormat.Type == ListType.Structured) ? true : false;
			}
			set
			{
				this.attribute_2 = ListFormat.Attribute.Type;
				this.selection_0.ListFormat.Type = ((value != true) ? ListType.None : ListType.Structured);
				this.attribute_2 = (ListFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets the number format for a structured list at the current input position.</summary>
		public NumFormat StructuredListFormat
		{
			get
			{
				if (this.selection_0.ListFormat.Type == ListType.Structured && this.selection_0.IsCommonValueSelected(ListFormat.Attribute.NumberFormat))
				{
					return this.selection_0.ListFormat.NumberFormat;
				}
				return NumFormat.None;
			}
			set
			{
				this.attribute_2 = (ListFormat.Attribute)2056;
				if (value != 0)
				{
					ListFormat listFormat = new ListFormat(ListType.Structured);
					listFormat.NumberFormat = value;
					this.selection_0.ListFormat = listFormat;
				}
				this.attribute_2 = (ListFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets the structure level of all selected paragraphs.</summary>
		[DefaultValue(0)]
		public int? StructureLevel
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(ParagraphFormat.Attribute.StructureLevel))
				{
					return null;
				}
				return this.selection_0.ParagraphFormat.StructureLevel;
			}
			set
			{
				this.attribute_1 = ParagraphFormat.Attribute.StructureLevel;
				if (value.HasValue)
				{
					this.selection_0.ParagraphFormat.StructureLevel = value.Value;
				}
				this.attribute_1 = (ParagraphFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets the formatting style name at the current input position.</summary>
		public string StyleName
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(Selection.Attribute.FormattingStyle))
				{
					return null;
				}
				return this.selection_0.FormattingStyle;
			}
			set
			{
				this.attribute_0 = Selection.Attribute.FormattingStyle;
				if (value != null)
				{
					this.selection_0.FormattingStyle = value;
				}
				this.attribute_0 = (Selection.Attribute)0;
			}
		}

		/// <summary>Returns an array of the names of all formatting styles, the document contains.</summary>
		public string[] StyleNames
		{
			get
			{
				string[] result = null;
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					IntPtr intPtr = this.textControlCore_0.method_66(Enum83.const_182, 255u, 0);
					IntPtr ptr = Class429.GlobalLock(intPtr);
					result = KernelHelper.Ptr2StringArray(ptr);
					Class429.GlobalUnlock(intPtr);
					Marshal.FreeHGlobal(intPtr);
				}
				return result;
			}
		}

		/// <summary>Gets or sets a value specifying whether text is subscript at the current input position.</summary>
		[DefaultValue(false)]
		public bool? Subscript
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(Selection.Attribute.Baseline))
				{
					return null;
				}
				return (this.selection_0.Baseline < 0) ? true : false;
			}
			set
			{
				this.attribute_0 = Selection.Attribute.Baseline;
				if (value.HasValue)
				{
					this.selection_0.Baseline = ((value == true) ? (-60) : 0);
				}
				this.attribute_0 = (Selection.Attribute)0;
			}
		}

		/// <summary>Gets or sets a value specifying whether text is superscript at the current input position.</summary>
		[DefaultValue(false)]
		public bool? Superscript
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(Selection.Attribute.Baseline))
				{
					return null;
				}
				return (this.selection_0.Baseline > 0) ? true : false;
			}
			set
			{
				this.attribute_0 = Selection.Attribute.Baseline;
				if (value.HasValue)
				{
					this.selection_0.Baseline = ((value == true) ? 60 : 0);
				}
				this.attribute_0 = (Selection.Attribute)0;
			}
		}

		/// <summary>Gets or sets the color used to display the text background color at the current input position.</summary>
		public Color? TextBackColor
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(Selection.Attribute.TextBackColor))
				{
					return null;
				}
				return this.selection_0.TextBackColor;
			}
			set
			{
				this.attribute_0 = Selection.Attribute.TextBackColor;
				if (value.HasValue)
				{
					this.selection_0.TextBackColor = value.Value;
				}
				this.attribute_0 = (Selection.Attribute)0;
			}
		}

		/// <summary>Returns or sets the color used to display the text at the current input position.</summary>
		public Color? TextColor
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(Selection.Attribute.ForeColor))
				{
					return null;
				}
				return this.selection_0.ForeColor;
			}
			set
			{
				this.attribute_0 = Selection.Attribute.ForeColor;
				if (value.HasValue)
				{
					this.selection_0.ForeColor = value.Value;
				}
				this.attribute_0 = (Selection.Attribute)0;
			}
		}

		/// <summary>Gets or sets a value specifying whether text is top aligned at the current input position.</summary>
		[DefaultValue(true)]
		public bool? TopAligned
		{
			get
			{
				this.method_7(Enum66.const_8);
				if ((this.enum66_2 & Enum66.const_8) == 0)
				{
					return this.bool_10;
				}
				return null;
			}
			set
			{
				if (value.HasValue)
				{
					this.enum66_0 = Enum66.const_8;
					this.enum66_1 &= (Enum66)(-449);
					this.bool_10 = value.Value;
					this.method_8();
				}
			}
		}

		/// <summary>Gets or sets a top paragraph distance, in twips, at the current input position.</summary>
		[DefaultValue(0)]
		public int? TopDistance
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(ParagraphFormat.Attribute.TopDistance))
				{
					return null;
				}
				return this.selection_0.ParagraphFormat.TopDistance;
			}
			set
			{
				this.attribute_1 = ParagraphFormat.Attribute.TopDistance;
				if (value.HasValue)
				{
					this.selection_0.ParagraphFormat.TopDistance = value.Value;
				}
				this.attribute_1 = (ParagraphFormat.Attribute)0;
			}
		}

		/// <summary>Gets or sets a value specifying whether there is a frame line at the top of the text.</summary>
		public bool TopFrameLine
		{
			get
			{
				this.method_7(Enum66.const_1);
				return this.bool_11;
			}
			set
			{
				this.bool_11 = value;
				this.enum66_0 = Enum66.const_1;
				this.method_8();
			}
		}

		/// <summary>Gets or sets a value specifying whether text is underlined at the current input position.</summary>
		[DefaultValue(false)]
		public bool? Underline
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(Selection.Attribute.Underline))
				{
					return null;
				}
				return (this.selection_0.Underline == this.fontUnderlineStyle_0) ? true : false;
			}
			set
			{
				this.attribute_0 = Selection.Attribute.Underline;
				if (value.HasValue)
				{
					this.selection_0.Underline = ((value == true) ? this.fontUnderlineStyle_0 : FontUnderlineStyle.None);
				}
				this.attribute_0 = (Selection.Attribute)0;
			}
		}

		/// <summary>Gets or sets the underline style at the current input position.</summary>
		public FontUnderlineStyle UnderlineStyle
		{
			get
			{
				if (!this.selection_0.IsCommonValueSelected(Selection.Attribute.Underline))
				{
					return FontUnderlineStyle.None;
				}
				return this.selection_0.Underline;
			}
			set
			{
				if (value == FontUnderlineStyle.None)
				{
					throw new ArgumentException();
				}
				this.fontUnderlineStyle_0 = value;
				this.attribute_0 = Selection.Attribute.Underline;
				this.selection_0.Underline = this.fontUnderlineStyle_0;
				this.attribute_0 = (Selection.Attribute)0;
			}
		}

		/// <summary>Returns an array of all supported underline styles.</summary>
		public FontUnderlineStyle[] UnderlineStyles => new FontUnderlineStyle[4]
		{
			FontUnderlineStyle.Single,
			FontUnderlineStyle.Doubled,
			FontUnderlineStyle.SingleWordsOnly,
			FontUnderlineStyle.DoubledWordsOnly
		};

		/// <summary>Gets or sets a value specifying whether text is vertically centered at the current text input position.</summary>
		[DefaultValue(false)]
		public bool? VerticallyCentered
		{
			get
			{
				this.method_7(Enum66.const_9);
				if ((this.enum66_2 & Enum66.const_9) == 0)
				{
					return this.bool_12;
				}
				return null;
			}
			set
			{
				if (value.HasValue)
				{
					this.enum66_0 = Enum66.const_9;
					this.enum66_1 &= (Enum66)(-449);
					this.bool_12 = value.Value;
					this.method_8();
				}
			}
		}

		public event EventHandler BoldChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler BottomDistanceChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler BulletCharacterChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_2;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_2, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_2;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_2, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler BulletedListChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_3;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_3, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_3;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_3, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler CenteredChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_4;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_4, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_4;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_4, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler FontFamilyChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_5;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_5, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_5;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_5, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler FontSizeChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_6;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_6, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_6;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_6, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler HangingIndentChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_7;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_7, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_7;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_7, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler ItalicChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_8;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_8, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_8;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_8, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler JustifiedChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_9;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_9, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_9;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_9, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler LeftAlignedChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_10;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_10, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_10;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_10, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler LeftIndentChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_11;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_11, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_11;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_11, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler LineSpacingChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_12;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_12, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_12;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_12, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler NumberedListChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_13;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_13, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_13;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_13, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler NumberedListFormatChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_14;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_14, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_14;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_14, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler RightAlignedChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_15;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_15, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_15;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_15, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler RightIndentChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_16;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_16, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_16;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_16, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler StrikeoutChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_17;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_17, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_17;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_17, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler StructuredListChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_18;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_18, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_18;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_18, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler StructuredListFormatChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_19;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_19, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_19;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_19, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler StyleNameChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_20;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_20, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_20;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_20, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler StyleNamesChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_21;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_21, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_21;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_21, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler SubscriptChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_22;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_22, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_22;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_22, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler SuperscriptChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_23;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_23, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_23;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_23, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler TextColorChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_24;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_24, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_24;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_24, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler TextBackColorChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_25;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_25, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_25;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_25, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler TopDistanceChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_26;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_26, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_26;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_26, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler UnderlineChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_27;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_27, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_27;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_27, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler UnderlineStyleChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_28;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_28, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_28;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_28, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler LeftFrameLineChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_29;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_29, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_29;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_29, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler TopFrameLineChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_30;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_30, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_30;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_30, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler RightFrameLineChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_31;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_31, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_31;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_31, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler BottomFrameLineChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_32;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_32, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_32;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_32, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler InnerHorizontalFrameLinesChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_33;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_33, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_33;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_33, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler InnerVerticalFrameLinesChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_34;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_34, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_34;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_34, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler BoxFrameChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_35;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_35, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_35;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_35, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler AllFrameLinesChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_36;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_36, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_36;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_36, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler LeftToRightChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_37;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_37, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_37;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_37, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler RightToLeftChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_38;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_38, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_38;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_38, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler TopAlignedChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_39;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_39, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_39;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_39, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler VerticallyCenteredChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_40;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_40, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_40;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_40, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler BottomAlignedChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_41;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_41, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_41;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_41, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler FrameFillColorChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_42;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_42, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_42;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_42, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler FrameLineColorChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_43;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_43, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_43;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_43, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler FrameLineWidthChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_44;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_44, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_44;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_44, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler StandardTextTypeChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_45;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_45, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_45;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_45, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler NumberTextTypeChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_46;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_46, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_46;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_46, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler NumberFormatChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_47;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_47, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_47;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_47, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler StructureLevelChanged
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_48;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_48, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_48;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_48, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		internal InputFormat()
		{
		}

		/// <summary>Returns an array of strings specifying all supported fonts. These fonts depend on the formatting device set with the WPF.TextControl.FormattingPrinter or TextControl.FormattingPrinter property and on attributes set with the WPF.TextControl.FontSettings or TextControl.FontSettings property.</summary>
		public string[] GetFontFamilies()
		{
			if (!this.textControlCore_0.isHandleCreated)
			{
				return null;
			}
			return this.textControlCore_0.GetSupportedFonts();
		}

		/// <summary>Returns an array of strings specifying all possible font sizes for the font at the text input position. If the font is free scalable, standard sizes are returned.</summary>
		public string[] GetFontSizes()
		{
			string fontFamily = this.FontFamily;
			return this.GetFontSizes((fontFamily == null) ? "Arial" : fontFamily);
		}

		/// <summary>Returns an array of strings specifying all possible font sizes for specified font. If the font is free scalable, standard sizes are returned.</summary>
		/// <param name="fontFamily">Specifies the font the possible sizes of which are returned.</param>
		public string[] GetFontSizes(string fontName)
		{
			string[] result = null;
			if (this.textControlCore_0.isHandleCreated && fontName != null)
			{
				IntPtr intPtr = this.textControlCore_0.method_39(Enum83.const_163, 0, fontName);
				IntPtr intPtr2 = Class429.GlobalLock(intPtr);
				try
				{
					if (intPtr2 != IntPtr.Zero)
					{
						return KernelHelper.Ptr2StringArray(intPtr2);
					}
					return result;
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (intPtr2 != IntPtr.Zero)
					{
						Class429.GlobalUnlock(intPtr);
					}
					if (intPtr != IntPtr.Zero)
					{
						Class429.GlobalFree(intPtr);
					}
				}
			}
			return result;
		}

		private void method_0()
		{
			if (this.attribute_0 != 0)
			{
				if (this.eventHandler_0 != null && (this.attribute_0 & Selection.Attribute.Bold) != 0)
				{
					this.eventHandler_0(this, EventArgs.Empty);
				}
				if (this.eventHandler_5 != null && (this.attribute_0 & Selection.Attribute.FontName) != 0)
				{
					this.eventHandler_5(this, EventArgs.Empty);
				}
				if (this.eventHandler_6 != null && (this.attribute_0 & Selection.Attribute.FontSize) != 0)
				{
					this.eventHandler_6(this, EventArgs.Empty);
				}
				if (this.eventHandler_8 != null && (this.attribute_0 & Selection.Attribute.Italic) != 0)
				{
					this.eventHandler_8(this, EventArgs.Empty);
				}
				if (this.eventHandler_17 != null && (this.attribute_0 & Selection.Attribute.Strikeout) != 0)
				{
					this.eventHandler_17(this, EventArgs.Empty);
				}
				if (this.eventHandler_22 != null && (this.attribute_0 & Selection.Attribute.Baseline) != 0)
				{
					this.eventHandler_22(this, EventArgs.Empty);
				}
				if (this.eventHandler_23 != null && (this.attribute_0 & Selection.Attribute.Baseline) != 0)
				{
					this.eventHandler_23(this, EventArgs.Empty);
				}
				if (this.eventHandler_27 != null && (this.attribute_0 & Selection.Attribute.Underline) != 0)
				{
					this.eventHandler_27(this, EventArgs.Empty);
				}
				if (this.eventHandler_28 != null && (this.attribute_0 & Selection.Attribute.Underline) != 0)
				{
					this.eventHandler_28(this, EventArgs.Empty);
				}
				if (this.eventHandler_24 != null && (this.attribute_0 & Selection.Attribute.ForeColor) != 0)
				{
					this.eventHandler_24(this, EventArgs.Empty);
				}
				if (this.eventHandler_25 != null && (this.attribute_0 & Selection.Attribute.TextBackColor) != 0)
				{
					this.eventHandler_25(this, EventArgs.Empty);
				}
				return;
			}
			Selection.Attribute attribute = (Selection.Attribute)0;
			if (this.eventHandler_0 != null)
			{
				attribute |= Selection.Attribute.Bold;
			}
			if (this.eventHandler_8 != null)
			{
				attribute |= Selection.Attribute.Italic;
			}
			if (this.eventHandler_17 != null)
			{
				attribute |= Selection.Attribute.Strikeout;
			}
			if (this.eventHandler_22 != null)
			{
				attribute |= Selection.Attribute.Baseline;
			}
			if (this.eventHandler_23 != null)
			{
				attribute |= Selection.Attribute.Baseline;
			}
			if (this.eventHandler_27 != null)
			{
				attribute |= Selection.Attribute.Underline;
			}
			if (this.eventHandler_28 != null)
			{
				attribute |= Selection.Attribute.Underline;
			}
			if (this.eventHandler_5 != null)
			{
				attribute |= Selection.Attribute.FontName;
			}
			if (this.eventHandler_6 != null)
			{
				attribute |= Selection.Attribute.FontSize;
			}
			if (this.eventHandler_24 != null)
			{
				attribute |= Selection.Attribute.ForeColor;
			}
			if (this.eventHandler_25 != null)
			{
				attribute |= Selection.Attribute.TextBackColor;
			}
			Selection.Attribute attribute2 = this.selection_0.method_5(Selection.Attribute.All, attribute);
			if (this.eventHandler_0 != null && (attribute2 & Selection.Attribute.Bold) != 0)
			{
				this.eventHandler_0(this, EventArgs.Empty);
			}
			if (this.eventHandler_8 != null && (attribute2 & Selection.Attribute.Italic) != 0)
			{
				this.eventHandler_8(this, EventArgs.Empty);
			}
			if (this.eventHandler_17 != null && (attribute2 & Selection.Attribute.Strikeout) != 0)
			{
				this.eventHandler_17(this, EventArgs.Empty);
			}
			if (this.eventHandler_22 != null && (attribute2 & Selection.Attribute.Baseline) != 0)
			{
				this.eventHandler_22(this, EventArgs.Empty);
			}
			if (this.eventHandler_23 != null && (attribute2 & Selection.Attribute.Baseline) != 0)
			{
				this.eventHandler_23(this, EventArgs.Empty);
			}
			if (this.eventHandler_27 != null && (attribute2 & Selection.Attribute.Underline) != 0)
			{
				this.eventHandler_27(this, EventArgs.Empty);
			}
			if (this.eventHandler_28 != null && (attribute2 & Selection.Attribute.Underline) != 0)
			{
				this.eventHandler_28(this, EventArgs.Empty);
			}
			if (this.eventHandler_5 != null && (attribute2 & Selection.Attribute.FontName) != 0)
			{
				this.eventHandler_5(this, EventArgs.Empty);
			}
			if (this.eventHandler_6 != null && (attribute2 & Selection.Attribute.FontSize) != 0)
			{
				this.eventHandler_6(this, EventArgs.Empty);
			}
			if (this.eventHandler_24 != null && (attribute2 & Selection.Attribute.ForeColor) != 0)
			{
				this.eventHandler_24(this, EventArgs.Empty);
			}
			if (this.eventHandler_25 != null && (attribute2 & Selection.Attribute.TextBackColor) != 0)
			{
				this.eventHandler_25(this, EventArgs.Empty);
			}
		}

		private void method_1()
		{
			if (this.attribute_1 != 0)
			{
				if ((this.attribute_1 & ParagraphFormat.Attribute.Alignment) != 0)
				{
					if (this.eventHandler_10 != null)
					{
						this.eventHandler_10(this, EventArgs.Empty);
					}
					if (this.eventHandler_15 != null)
					{
						this.eventHandler_15(this, EventArgs.Empty);
					}
					if (this.eventHandler_4 != null)
					{
						this.eventHandler_4(this, EventArgs.Empty);
					}
					if (this.eventHandler_9 != null)
					{
						this.eventHandler_9(this, EventArgs.Empty);
					}
				}
				if ((this.attribute_1 & ParagraphFormat.Attribute.Direction) != 0)
				{
					if (this.eventHandler_37 != null)
					{
						this.eventHandler_37(this, EventArgs.Empty);
					}
					if (this.eventHandler_38 != null)
					{
						this.eventHandler_38(this, EventArgs.Empty);
					}
				}
				if (this.eventHandler_11 != null && (this.attribute_1 & ParagraphFormat.Attribute.LeftIndent) != 0)
				{
					this.eventHandler_11(this, EventArgs.Empty);
				}
				if (this.eventHandler_16 != null && (this.attribute_1 & ParagraphFormat.Attribute.RightIndent) != 0)
				{
					this.eventHandler_16(this, EventArgs.Empty);
				}
				if (this.eventHandler_7 != null && (this.attribute_1 & ParagraphFormat.Attribute.HangingIndent) != 0)
				{
					this.eventHandler_7(this, EventArgs.Empty);
				}
				if (this.eventHandler_26 != null && (this.attribute_1 & ParagraphFormat.Attribute.TopDistance) != 0)
				{
					this.eventHandler_26(this, EventArgs.Empty);
				}
				if (this.eventHandler_1 != null && (this.attribute_1 & ParagraphFormat.Attribute.BottomDistance) != 0)
				{
					this.eventHandler_1(this, EventArgs.Empty);
				}
				if (this.eventHandler_12 != null && (this.attribute_1 & ParagraphFormat.Attribute.LineSpacing) != 0)
				{
					this.eventHandler_12(this, EventArgs.Empty);
				}
				if (this.eventHandler_48 != null && (this.attribute_1 & ParagraphFormat.Attribute.StructureLevel) != 0)
				{
					this.eventHandler_48(this, EventArgs.Empty);
				}
				return;
			}
			ParagraphFormat.Attribute attribute = (ParagraphFormat.Attribute)0;
			HorizontalAlignment horizontalAlignment = (HorizontalAlignment)0;
			Direction direction = (Direction)0;
			if (this.eventHandler_10 != null || this.eventHandler_15 != null || this.eventHandler_4 != null || this.eventHandler_9 != null)
			{
				attribute |= ParagraphFormat.Attribute.Alignment;
				horizontalAlignment = (this.selection_0.IsCommonValueSelected(ParagraphFormat.Attribute.Alignment) ? this.selection_0.ParagraphFormat.Alignment : ((HorizontalAlignment)0));
			}
			if (this.eventHandler_37 != null || this.eventHandler_38 != null)
			{
				attribute |= ParagraphFormat.Attribute.Direction;
				direction = (this.selection_0.IsCommonValueSelected(ParagraphFormat.Attribute.Direction) ? this.selection_0.ParagraphFormat.Direction : ((Direction)0));
			}
			if (this.eventHandler_11 != null)
			{
				attribute |= ParagraphFormat.Attribute.LeftIndent;
			}
			if (this.eventHandler_16 != null)
			{
				attribute |= ParagraphFormat.Attribute.RightIndent;
			}
			if (this.eventHandler_7 != null)
			{
				attribute |= ParagraphFormat.Attribute.HangingIndent;
			}
			if (this.eventHandler_26 != null)
			{
				attribute |= ParagraphFormat.Attribute.TopDistance;
			}
			if (this.eventHandler_1 != null)
			{
				attribute |= ParagraphFormat.Attribute.BottomDistance;
			}
			if (this.eventHandler_12 != null)
			{
				attribute |= ParagraphFormat.Attribute.LineSpacing;
			}
			if (this.eventHandler_48 != null)
			{
				attribute |= ParagraphFormat.Attribute.StructureLevel;
			}
			ParagraphFormat.Attribute attribute2 = this.selection_0.ParagraphFormat.method_12(ParagraphFormat.Attribute.All, attribute);
			if ((attribute2 & ParagraphFormat.Attribute.Alignment) != 0)
			{
				HorizontalAlignment horizontalAlignment2 = (this.selection_0.IsCommonValueSelected(ParagraphFormat.Attribute.Alignment) ? this.selection_0.ParagraphFormat.Alignment : ((HorizontalAlignment)0));
				if (this.eventHandler_10 != null && (horizontalAlignment == HorizontalAlignment.Left || horizontalAlignment2 == HorizontalAlignment.Left))
				{
					this.eventHandler_10(this, EventArgs.Empty);
				}
				if (this.eventHandler_15 != null && (horizontalAlignment == HorizontalAlignment.Right || horizontalAlignment2 == HorizontalAlignment.Right))
				{
					this.eventHandler_15(this, EventArgs.Empty);
				}
				if (this.eventHandler_4 != null && (horizontalAlignment == HorizontalAlignment.Center || horizontalAlignment2 == HorizontalAlignment.Center))
				{
					this.eventHandler_4(this, EventArgs.Empty);
				}
				if (this.eventHandler_9 != null && (horizontalAlignment == HorizontalAlignment.Justify || horizontalAlignment2 == HorizontalAlignment.Justify))
				{
					this.eventHandler_9(this, EventArgs.Empty);
				}
			}
			if ((attribute2 & ParagraphFormat.Attribute.Direction) != 0)
			{
				Direction direction2 = (this.selection_0.IsCommonValueSelected(ParagraphFormat.Attribute.Direction) ? this.selection_0.ParagraphFormat.Direction : ((Direction)0));
				if (this.eventHandler_37 != null && (direction == Direction.LeftToRight || direction2 == Direction.LeftToRight))
				{
					this.eventHandler_37(this, EventArgs.Empty);
				}
				if (this.eventHandler_38 != null && (direction == Direction.RightToLeft || direction2 == Direction.RightToLeft))
				{
					this.eventHandler_38(this, EventArgs.Empty);
				}
			}
			if (this.eventHandler_11 != null && (attribute2 & ParagraphFormat.Attribute.LeftIndent) != 0)
			{
				this.eventHandler_11(this, EventArgs.Empty);
			}
			if (this.eventHandler_16 != null && (attribute2 & ParagraphFormat.Attribute.RightIndent) != 0)
			{
				this.eventHandler_16(this, EventArgs.Empty);
			}
			if (this.eventHandler_7 != null && (attribute2 & ParagraphFormat.Attribute.HangingIndent) != 0)
			{
				this.eventHandler_7(this, EventArgs.Empty);
			}
			if (this.eventHandler_26 != null && (attribute2 & ParagraphFormat.Attribute.TopDistance) != 0)
			{
				this.eventHandler_26(this, EventArgs.Empty);
			}
			if (this.eventHandler_1 != null && (attribute2 & ParagraphFormat.Attribute.BottomDistance) != 0)
			{
				this.eventHandler_1(this, EventArgs.Empty);
			}
			if (this.eventHandler_12 != null && (attribute2 & ParagraphFormat.Attribute.LineSpacing) != 0)
			{
				this.eventHandler_12(this, EventArgs.Empty);
			}
			if (this.eventHandler_48 != null && (attribute2 & ParagraphFormat.Attribute.StructureLevel) != 0)
			{
				this.eventHandler_48(this, EventArgs.Empty);
			}
		}

		private void method_2()
		{
			if (this.attribute_2 != 0)
			{
				this.selection_0.ListFormat.method_13();
				if (this.eventHandler_3 != null)
				{
					this.eventHandler_3(this, EventArgs.Empty);
				}
				if (this.eventHandler_13 != null)
				{
					this.eventHandler_13(this, EventArgs.Empty);
				}
				if (this.eventHandler_18 != null)
				{
					this.eventHandler_18(this, EventArgs.Empty);
				}
				if (this.eventHandler_14 != null)
				{
					this.eventHandler_14(this, EventArgs.Empty);
				}
				if (this.eventHandler_19 != null)
				{
					this.eventHandler_19(this, EventArgs.Empty);
				}
				if (this.eventHandler_2 != null)
				{
					this.eventHandler_2(this, EventArgs.Empty);
				}
			}
			else
			{
				if (this.eventHandler_3 == null && this.eventHandler_13 == null && this.eventHandler_14 == null && this.eventHandler_18 == null && this.eventHandler_19 == null && this.eventHandler_2 == null)
				{
					return;
				}
				ListFormat.Attribute attribute = this.selection_0.ListFormat.method_13();
				if ((attribute & ListFormat.Attribute.Type) != 0)
				{
					if (this.eventHandler_3 != null)
					{
						this.eventHandler_3(this, EventArgs.Empty);
					}
					if (this.eventHandler_13 != null)
					{
						this.eventHandler_13(this, EventArgs.Empty);
					}
					if (this.eventHandler_18 != null)
					{
						this.eventHandler_18(this, EventArgs.Empty);
					}
				}
				if ((attribute & ListFormat.Attribute.NumberFormat) != 0)
				{
					if (this.eventHandler_14 != null)
					{
						this.eventHandler_14(this, EventArgs.Empty);
					}
					if (this.eventHandler_19 != null)
					{
						this.eventHandler_19(this, EventArgs.Empty);
					}
				}
				if (this.eventHandler_2 != null && (attribute & ListFormat.Attribute.BulletCharacter) != 0)
				{
					this.eventHandler_2(this, EventArgs.Empty);
				}
			}
		}

		private void method_3()
		{
			if (this.enum66_0 != 0)
			{
				if (this.eventHandler_29 != null && (this.enum66_0 & Enum66.const_0) != 0)
				{
					this.eventHandler_29(this, EventArgs.Empty);
				}
				if (this.eventHandler_30 != null && (this.enum66_0 & Enum66.const_1) != 0)
				{
					this.eventHandler_30(this, EventArgs.Empty);
				}
				if (this.eventHandler_31 != null && (this.enum66_0 & Enum66.const_2) != 0)
				{
					this.eventHandler_31(this, EventArgs.Empty);
				}
				if (this.eventHandler_32 != null && (this.enum66_0 & Enum66.const_3) != 0)
				{
					this.eventHandler_32(this, EventArgs.Empty);
				}
				if (this.eventHandler_33 != null && (this.enum66_0 & Enum66.const_4) != 0)
				{
					this.eventHandler_33(this, EventArgs.Empty);
				}
				if (this.eventHandler_34 != null && (this.enum66_0 & Enum66.const_5) != 0)
				{
					this.eventHandler_34(this, EventArgs.Empty);
				}
				if (this.eventHandler_35 != null && (this.enum66_0 & Enum66.const_7) != 0)
				{
					this.eventHandler_35(this, EventArgs.Empty);
				}
				if (this.eventHandler_36 != null && (this.enum66_0 & Enum66.const_7) != 0)
				{
					this.eventHandler_36(this, EventArgs.Empty);
				}
				if (this.eventHandler_42 != null && (this.enum66_0 & Enum66.const_12) != 0)
				{
					this.eventHandler_42(this, EventArgs.Empty);
				}
				if (this.eventHandler_43 != null && (this.enum66_0 & Enum66.const_13) != 0)
				{
					this.eventHandler_43(this, EventArgs.Empty);
				}
				if (this.eventHandler_44 != null && (this.enum66_0 & Enum66.const_14) != 0)
				{
					this.eventHandler_44(this, EventArgs.Empty);
				}
				if (this.eventHandler_47 != null && (this.enum66_0 & Enum66.const_15) != 0)
				{
					this.eventHandler_47(this, EventArgs.Empty);
				}
				if ((this.enum66_0 & Enum66.const_11) != 0)
				{
					if (this.eventHandler_39 != null)
					{
						this.eventHandler_39(this, EventArgs.Empty);
					}
					if (this.eventHandler_40 != null)
					{
						this.eventHandler_40(this, EventArgs.Empty);
					}
					if (this.eventHandler_41 != null)
					{
						this.eventHandler_41(this, EventArgs.Empty);
					}
				}
				if ((this.enum66_0 & Enum66.const_18) != 0)
				{
					if (this.eventHandler_45 != null)
					{
						this.eventHandler_45(this, EventArgs.Empty);
					}
					if (this.eventHandler_46 != null)
					{
						this.eventHandler_46(this, EventArgs.Empty);
					}
				}
				return;
			}
			Enum66 @enum = (Enum66)0;
			if (this.eventHandler_29 != null)
			{
				@enum |= Enum66.const_0;
			}
			if (this.eventHandler_31 != null)
			{
				@enum |= Enum66.const_2;
			}
			if (this.eventHandler_30 != null)
			{
				@enum |= Enum66.const_1;
			}
			if (this.eventHandler_32 != null)
			{
				@enum |= Enum66.const_3;
			}
			if (this.eventHandler_33 != null)
			{
				@enum |= Enum66.const_4;
			}
			if (this.eventHandler_34 != null)
			{
				@enum |= Enum66.const_5;
			}
			if (this.eventHandler_35 != null)
			{
				@enum |= Enum66.const_6;
			}
			if (this.eventHandler_36 != null)
			{
				@enum |= Enum66.const_7;
			}
			if (this.eventHandler_39 != null)
			{
				@enum |= Enum66.const_8;
			}
			if (this.eventHandler_40 != null)
			{
				@enum |= Enum66.const_9;
			}
			if (this.eventHandler_41 != null)
			{
				@enum |= Enum66.const_10;
			}
			if (this.eventHandler_42 != null)
			{
				@enum |= Enum66.const_12;
			}
			if (this.eventHandler_43 != null)
			{
				@enum |= Enum66.const_13;
			}
			if (this.eventHandler_44 != null)
			{
				@enum |= Enum66.const_14;
			}
			if (this.eventHandler_45 != null)
			{
				@enum |= Enum66.const_17;
			}
			if (this.eventHandler_46 != null)
			{
				@enum |= Enum66.const_16;
			}
			if (this.eventHandler_47 != null)
			{
				@enum |= Enum66.const_15;
			}
			Enum66 enum2 = this.method_9(Enum66.const_20, @enum);
			if (this.eventHandler_29 != null && (enum2 & Enum66.const_0) != 0)
			{
				this.eventHandler_29(this, EventArgs.Empty);
			}
			if (this.eventHandler_30 != null && (enum2 & Enum66.const_1) != 0)
			{
				this.eventHandler_30(this, EventArgs.Empty);
			}
			if (this.eventHandler_31 != null && (enum2 & Enum66.const_2) != 0)
			{
				this.eventHandler_31(this, EventArgs.Empty);
			}
			if (this.eventHandler_32 != null && (enum2 & Enum66.const_3) != 0)
			{
				this.eventHandler_32(this, EventArgs.Empty);
			}
			if (this.eventHandler_33 != null && (enum2 & Enum66.const_4) != 0)
			{
				this.eventHandler_33(this, EventArgs.Empty);
			}
			if (this.eventHandler_34 != null && (enum2 & Enum66.const_5) != 0)
			{
				this.eventHandler_34(this, EventArgs.Empty);
			}
			if (this.eventHandler_35 != null && (enum2 & Enum66.const_7) != 0)
			{
				this.eventHandler_35(this, EventArgs.Empty);
			}
			if (this.eventHandler_36 != null && (enum2 & Enum66.const_7) != 0)
			{
				this.eventHandler_36(this, EventArgs.Empty);
			}
			if (this.eventHandler_39 != null && (enum2 & Enum66.const_8) != 0)
			{
				this.eventHandler_39(this, EventArgs.Empty);
			}
			if (this.eventHandler_40 != null && (enum2 & Enum66.const_9) != 0)
			{
				this.eventHandler_40(this, EventArgs.Empty);
			}
			if (this.eventHandler_41 != null && (enum2 & Enum66.const_10) != 0)
			{
				this.eventHandler_41(this, EventArgs.Empty);
			}
			if (this.eventHandler_42 != null && (enum2 & Enum66.const_12) != 0)
			{
				this.eventHandler_42(this, EventArgs.Empty);
			}
			if (this.eventHandler_43 != null && (enum2 & Enum66.const_13) != 0)
			{
				this.eventHandler_43(this, EventArgs.Empty);
			}
			if (this.eventHandler_44 != null && (enum2 & Enum66.const_14) != 0)
			{
				this.eventHandler_44(this, EventArgs.Empty);
			}
			if (this.eventHandler_45 != null && (enum2 & Enum66.const_17) != 0)
			{
				this.eventHandler_45(this, EventArgs.Empty);
			}
			if (this.eventHandler_46 != null && (enum2 & Enum66.const_16) != 0)
			{
				this.eventHandler_46(this, EventArgs.Empty);
			}
			if (this.eventHandler_47 != null && (enum2 & Enum66.const_15) != 0)
			{
				this.eventHandler_47(this, EventArgs.Empty);
			}
		}

		private void method_4()
		{
			if (this.attribute_0 != 0)
			{
				if (this.eventHandler_20 != null && (this.attribute_0 & Selection.Attribute.FormattingStyle) != 0)
				{
					this.eventHandler_20(this, EventArgs.Empty);
				}
				return;
			}
			Selection.Attribute attribute = this.selection_0.method_5(Selection.Attribute.FormattingStyle, Selection.Attribute.FormattingStyle);
			if (this.eventHandler_20 != null && (attribute & Selection.Attribute.FormattingStyle) != 0)
			{
				this.eventHandler_20(this, EventArgs.Empty);
			}
		}

		internal void method_5(Enum84 enum84_0)
		{
			switch (enum84_0)
			{
			case Enum84.const_8:
			case Enum84.const_12:
				this.method_0();
				break;
			case (Enum84)0:
				this.method_0();
				this.method_1();
				this.method_2();
				this.method_3();
				if (this.eventHandler_21 != null)
				{
					this.eventHandler_21(this, EventArgs.Empty);
				}
				if (this.eventHandler_20 != null)
				{
					this.eventHandler_20(this, EventArgs.Empty);
				}
				break;
			case Enum84.const_49:
				this.method_4();
				break;
			case Enum84.const_50:
				if (this.eventHandler_21 != null)
				{
					this.eventHandler_21(this, EventArgs.Empty);
				}
				break;
			case Enum84.const_51:
				this.method_3();
				break;
			case Enum84.const_13:
			case Enum84.const_23:
				this.method_1();
				this.method_2();
				this.method_3();
				break;
			case Enum84.const_91:
			case Enum84.const_99:
				this.enum66_1 = (Enum66)0;
				this.selection_0.method_6();
				break;
			}
		}

		internal void method_6(TextControlCore textControlCore_1)
		{
			this.textControlCore_0 = textControlCore_1;
			this.selection_0.method_0(textControlCore_1, TextPart.Auto);
		}

		private void method_7(Enum66 enum66_3)
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated)
			{
				return;
			}
			if ((enum66_3 & Enum66.const_7) != 0 && (this.enum66_1 & Enum66.const_7) != Enum66.const_7)
			{
				this.enum66_2 &= (Enum66)(-64);
				int[] array = new int[1];
				int[] array2 = new int[2];
				int[] array3 = array2;
				this.textControlCore_0.method_40(TextPart.Auto, 1132, 0, array3);
				this.bool_0 = (this.bool_1 = ((array3[0] != array3[1]) ? true : false));
				Enum98 @enum;
				if (this.textControlCore_0.method_40(TextPart.Auto, 1281, 0, array) != 0)
				{
					@enum = (Enum98)array[0];
					this.bool_4 = (((@enum & Enum98.const_6) != 0) ? true : false);
					this.bool_5 = (((@enum & Enum98.const_4) != 0) ? true : false);
				}
				else
				{
					@enum = (Enum98)this.textControlCore_0.method_40(TextPart.Auto, 1153, 0, array);
					this.bool_4 = (((@enum & Enum98.const_12) != 0 && (@enum & (Enum98)12) != 0) ? true : false);
					this.bool_5 = false;
					this.bool_1 = false;
				}
				this.bool_6 = (((@enum & Enum98.const_0) != 0) ? true : false);
				this.bool_11 = (((@enum & Enum98.const_2) != 0) ? true : false);
				this.bool_8 = (((@enum & Enum98.const_1) != 0) ? true : false);
				this.bool_3 = (((@enum & Enum98.const_3) != 0) ? true : false);
				this.enum66_1 |= Enum66.const_7;
			}
			if ((enum66_3 & Enum66.const_19) == 0 || (this.enum66_1 & Enum66.const_19) == Enum66.const_19)
			{
				return;
			}
			Struct79 struct79_ = default(Struct79);
			struct79_.method_0();
			struct79_.ushort_1 = 4;
			if (this.textControlCore_0.method_80(Enum83.const_104, ref struct79_) != 0)
			{
				this.enum66_2 &= (Enum66)(-32705);
				if (struct79_.uint_0 == 2147483648u)
				{
					this.enum66_2 |= Enum66.const_12;
					this.color_0 = Color.Transparent;
				}
				else
				{
					this.color_0 = KernelHelper.TxColor2SysDrawingColor(struct79_.uint_0, bBkGnd: true);
				}
				if (struct79_.uint_1 == 2147483648u)
				{
					this.enum66_2 |= Enum66.const_13;
					this.color_1 = SystemColors.WindowText;
				}
				else
				{
					this.color_1 = KernelHelper.TxColor2SysDrawingColor(struct79_.uint_1, bBkGnd: false);
				}
				this.int_0 = struct79_.short_0;
				if (this.int_0 == -1)
				{
					this.enum66_2 |= Enum66.const_14;
					this.int_0 = 0;
				}
				this.bool_10 = struct79_.sbyte_0 == 0;
				this.bool_2 = struct79_.sbyte_0 == 2;
				this.bool_12 = struct79_.sbyte_0 == 1;
				if (struct79_.sbyte_0 == -1)
				{
					this.enum66_2 |= Enum66.const_11;
				}
				this.bool_9 = struct79_.sbyte_1 == 0;
				this.bool_7 = struct79_.sbyte_1 == 1;
				if (struct79_.sbyte_1 == -1)
				{
					this.enum66_2 |= Enum66.const_18;
				}
				this.string_0 = string.Empty;
				if (struct79_.intptr_0 != IntPtr.Zero)
				{
					this.string_0 = Marshal.PtrToStringBSTR(struct79_.intptr_0);
					Marshal.FreeBSTR(struct79_.intptr_0);
					if (this.string_0.Length == 0)
					{
						this.enum66_2 |= Enum66.const_15;
						this.string_0 = null;
					}
				}
				this.enum66_1 |= Enum66.const_19;
				return;
			}
			if (((enum66_3 & Enum66.const_12) != 0 && (this.enum66_1 & Enum66.const_12) != Enum66.const_12) || ((enum66_3 & Enum66.const_13) != 0 && (this.enum66_1 & Enum66.const_13) != Enum66.const_13))
			{
				int[] array4 = new int[2];
				int[] array5 = array4;
				this.textControlCore_0.method_40(TextPart.Auto, 1984, 0, array5);
				this.enum66_2 &= (Enum66)(-1537);
				if (array5[0] == int.MinValue)
				{
					this.enum66_2 |= Enum66.const_12;
					this.color_0 = Color.Transparent;
				}
				else
				{
					this.color_0 = KernelHelper.TxColor2SysDrawingColor((uint)array5[0], bBkGnd: true);
				}
				if (array5[1] == int.MinValue)
				{
					this.enum66_2 |= Enum66.const_13;
					this.color_1 = SystemColors.WindowText;
				}
				else
				{
					this.color_1 = KernelHelper.TxColor2SysDrawingColor((uint)array5[1], bBkGnd: false);
				}
				this.enum66_1 |= (Enum66)1536;
			}
			if ((enum66_3 & Enum66.const_14) != 0 && (this.enum66_1 & Enum66.const_14) != Enum66.const_14)
			{
				int[] array6 = new int[1];
				this.textControlCore_0.method_40(TextPart.Auto, 1153, 0, array6);
				this.enum66_2 &= (Enum66)(-2049);
				this.int_0 = Class429.smethod_5(array6[0]);
				if (this.int_0 == -1)
				{
					this.enum66_2 |= Enum66.const_14;
					this.int_0 = 0;
				}
				this.enum66_1 |= Enum66.const_14;
			}
			this.enum66_2 &= (Enum66)(-449);
			this.bool_10 = true;
			this.bool_12 = false;
			this.bool_2 = false;
			this.enum66_1 |= Enum66.const_11;
			this.enum66_2 &= (Enum66)(-24577);
			this.bool_9 = true;
			this.bool_7 = false;
			this.enum66_1 |= Enum66.const_18;
			this.enum66_2 &= (Enum66)(-4097);
			this.string_0 = string.Empty;
			this.enum66_1 |= Enum66.const_15;
		}

		private void method_8()
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated || this.enum66_0 == (Enum66)0)
			{
				return;
			}
			this.enum66_2 &= ~this.enum66_0;
			if ((this.enum66_0 & Enum66.const_7) != 0)
			{
				Enum98 @enum = (Enum98)0;
				if ((this.enum66_0 & Enum66.const_0) != 0)
				{
					@enum |= (this.bool_6 ? Enum98.const_0 : Enum98.const_7);
				}
				if ((this.enum66_0 & Enum66.const_1) != 0)
				{
					@enum |= (this.bool_11 ? Enum98.const_2 : Enum98.const_9);
				}
				if ((this.enum66_0 & Enum66.const_2) != 0)
				{
					@enum |= (this.bool_8 ? Enum98.const_1 : Enum98.const_8);
				}
				if ((this.enum66_0 & Enum66.const_3) != 0)
				{
					@enum |= (this.bool_3 ? Enum98.const_3 : Enum98.const_10);
				}
				if ((this.enum66_0 & Enum66.const_4) != 0)
				{
					@enum |= (this.bool_4 ? Enum98.const_6 : Enum98.const_13);
					@enum |= (this.bool_4 ? Enum98.const_12 : Enum98.const_5);
				}
				if ((this.enum66_0 & Enum66.const_5) != 0)
				{
					@enum |= (this.bool_5 ? Enum98.const_4 : Enum98.const_11);
				}
				if (this.textControlCore_0.method_30(Enum83.const_124, 0, (int)@enum) == 0)
				{
					@enum &= (Enum98)(-17);
					this.textControlCore_0.method_30(Enum83.const_42, (int)@enum, Class429.smethod_3(0, -1));
				}
			}
			if ((this.enum66_0 & Enum66.const_19) != 0)
			{
				Struct79 struct79_ = default(Struct79);
				struct79_.method_0();
				if ((this.enum66_0 & Enum66.const_8) != 0 && this.bool_10)
				{
					struct79_.sbyte_0 = 0;
				}
				if ((this.enum66_0 & Enum66.const_9) != 0 && this.bool_12)
				{
					struct79_.sbyte_0 = 1;
				}
				if ((this.enum66_0 & Enum66.const_10) != 0 && this.bool_2)
				{
					struct79_.sbyte_0 = 2;
				}
				if ((this.enum66_0 & Enum66.const_14) != 0)
				{
					struct79_.short_0 = (short)this.int_0;
				}
				if ((this.enum66_0 & Enum66.const_13) != 0)
				{
					struct79_.uint_1 = KernelHelper.SysDrawingColor2TxColor(this.color_1, bBkGnd: false);
				}
				if ((this.enum66_0 & Enum66.const_12) != 0)
				{
					struct79_.uint_0 = KernelHelper.SysDrawingColor2TxColor(this.color_0, bBkGnd: true);
				}
				if ((this.enum66_0 & Enum66.const_17) != 0 && this.bool_9)
				{
					struct79_.sbyte_1 = 0;
				}
				if ((this.enum66_0 & Enum66.const_16) != 0 && this.bool_7)
				{
					struct79_.sbyte_1 = 1;
				}
				if ((this.enum66_0 & Enum66.const_15) != 0)
				{
					struct79_.intptr_0 = Marshal.StringToBSTR(this.string_0);
				}
				try
				{
					if (this.textControlCore_0.method_80(Enum83.const_105, ref struct79_) == 0)
					{
						if ((this.enum66_0 & Enum66.const_13) != 0 || (this.enum66_0 & Enum66.const_12) != 0)
						{
							int[] array = new int[2] { -2147483648, 0 };
							if ((this.enum66_0 & Enum66.const_12) != 0)
							{
								array[0] = (int)KernelHelper.SysDrawingColor2TxColor(this.color_0, bBkGnd: true);
							}
							array[1] = int.MinValue;
							if ((this.enum66_0 & Enum66.const_13) != 0)
							{
								array[1] = (int)KernelHelper.SysDrawingColor2TxColor(this.color_1, bBkGnd: false);
							}
							this.textControlCore_0.method_41(Enum83.const_315, 0, array);
						}
						if ((this.enum66_0 & Enum66.const_14) != 0)
						{
							this.textControlCore_0.method_30(Enum83.const_42, 0, Class429.smethod_3(this.int_0, -1));
						}
					}
				}
				catch (FilterException ex)
				{
					throw new NumberFormatException(ex.Reason, struct79_.ushort_2);
				}
				catch (Exception ex2)
				{
					throw ex2;
				}
				finally
				{
					if (struct79_.intptr_0 != IntPtr.Zero)
					{
						Marshal.FreeBSTR(struct79_.intptr_0);
					}
				}
			}
			this.enum66_0 = (Enum66)0;
		}

		private Enum66 method_9(Enum66 enum66_3, Enum66 enum66_4)
		{
			Enum66 @enum = (Enum66)0;
			Enum66 enum2 = this.enum66_2;
			this.enum66_1 &= ~enum66_3;
			if ((enum66_4 & Enum66.const_7) != 0)
			{
				bool flag = this.bool_6;
				bool flag2 = this.bool_11;
				bool flag3 = this.bool_8;
				bool flag4 = this.bool_3;
				bool flag5 = this.bool_4;
				bool flag6 = this.bool_5;
				this.method_7(Enum66.const_7);
				if (flag != this.bool_6 || (enum2 & Enum66.const_0) != (this.enum66_2 & Enum66.const_0))
				{
					@enum |= Enum66.const_0;
				}
				if (flag3 != this.bool_8 || (enum2 & Enum66.const_2) != (this.enum66_2 & Enum66.const_2))
				{
					@enum |= Enum66.const_2;
				}
				if (flag2 != this.bool_11 || (enum2 & Enum66.const_1) != (this.enum66_2 & Enum66.const_1))
				{
					@enum |= Enum66.const_1;
				}
				if (flag4 != this.bool_3 || (enum2 & Enum66.const_3) != (this.enum66_2 & Enum66.const_3))
				{
					@enum |= Enum66.const_3;
				}
				if (flag5 != this.bool_4 || (enum2 & Enum66.const_4) != (this.enum66_2 & Enum66.const_4))
				{
					@enum |= Enum66.const_4;
				}
				if (flag6 != this.bool_5 || (enum2 & Enum66.const_5) != (this.enum66_2 & Enum66.const_5))
				{
					@enum |= Enum66.const_5;
				}
			}
			if ((enum66_4 & Enum66.const_19) != 0)
			{
				bool flag7 = this.bool_10;
				bool flag8 = this.bool_12;
				bool flag9 = this.bool_2;
				Color color = this.color_0;
				Color color2 = this.color_1;
				int num = this.int_0;
				bool flag10 = this.bool_9;
				bool flag11 = this.bool_7;
				string text = this.string_0;
				this.method_7(Enum66.const_19);
				if (flag7 != this.bool_10 || (enum2 & Enum66.const_8) != (this.enum66_2 & Enum66.const_8))
				{
					@enum |= Enum66.const_8;
				}
				if (flag8 != this.bool_12 || (enum2 & Enum66.const_9) != (this.enum66_2 & Enum66.const_9))
				{
					@enum |= Enum66.const_9;
				}
				if (flag9 != this.bool_2 || (enum2 & Enum66.const_10) != (this.enum66_2 & Enum66.const_10))
				{
					@enum |= Enum66.const_10;
				}
				if (color != this.color_0 || (enum2 & Enum66.const_12) != (this.enum66_2 & Enum66.const_12))
				{
					@enum |= Enum66.const_12;
				}
				if (color2 != this.color_1 || (enum2 & Enum66.const_13) != (this.enum66_2 & Enum66.const_13))
				{
					@enum |= Enum66.const_13;
				}
				if (num != this.int_0 || (enum2 & Enum66.const_14) != (this.enum66_2 & Enum66.const_14))
				{
					@enum |= Enum66.const_14;
				}
				if (flag10 != this.bool_9 || (enum2 & Enum66.const_17) != (this.enum66_2 & Enum66.const_17))
				{
					@enum |= Enum66.const_17;
				}
				if (flag11 != this.bool_7 || (enum2 & Enum66.const_16) != (this.enum66_2 & Enum66.const_16))
				{
					@enum |= Enum66.const_16;
				}
				if (text != this.string_0)
				{
					@enum |= Enum66.const_15;
				}
			}
			return @enum;
		}
	}
}
