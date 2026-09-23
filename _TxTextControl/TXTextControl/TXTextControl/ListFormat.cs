using System;
using System.ComponentModel;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the ListFormat class represents the formatting attributes of a bulleted or numbered list.</summary>
	[TypeConverter(typeof(Class417))]
	public class ListFormat
	{
		/// <summary>Determines a certain list format attribute.</summary>
		public enum Attribute
		{
			/// <summary>Specifies the attribute set through the Level property.</summary>
			Level = 1,
			/// <summary>Specifies the attribute set through the LeftIndent property.</summary>
			LeftIndent = 2,
			/// <summary>Specifies the attribute set through the FormatChar property.</summary>
			FormatCharacter = 4,
			/// <summary>Specifies the attribute set through the NumberFormat property.</summary>
			NumberFormat = 8,
			/// <summary>Specifies the attribute set through the FirstNumber property.</summary>
			FirstNumber = 0x10,
			/// <summary>Obsolete. Use the TextBeforeNumber attribute instead.</summary>
			CharBeforeNumber = 0x20,
			/// <summary>Specifies the attribute set through the CharAfterNumber property.</summary>
			CharAfterNumber = 0x40,
			/// <summary>Specifies the attribute set through the RestartNumbering property.</summary>
			RestartNumbering = 0x80,
			/// <summary>Specifies the attribute set through the BulletCharacter property.</summary>
			BulletCharacter = 0x100,
			/// <summary>Specifies the attribute set through the BulletSize property.</summary>
			BulletSize = 0x200,
			/// <summary>Specifies the attribute set through the HangingIndent property.</summary>
			HangingIndent = 0x400,
			/// <summary>Specifies the attribute set through the Type property.</summary>
			Type = 0x800,
			/// <summary>Specifies the attribute set through the TextBeforeNumber property.</summary>
			TextBeforeNumber = 0x1000,
			/// <summary>Specifies the attribute set through the TextAfterNumber property.</summary>
			TextAfterNumber = 0x2000,
			/// <summary>Specifies the attribute set through the FontName property.</summary>
			FontName = 0x4000,
			/// <summary>Specifies all attributes of the ListFormat.</summary>
			All = 0x7FFF
		}

		[Flags]
		internal enum Enum68
		{
			flag_0 = 0x1,
			flag_1 = 0x2,
			flag_2 = 0x3,
			flag_3 = 0x4,
			flag_4 = 0x8,
			flag_5 = 0xC
		}

		/// <summary>Represents the maximum of levels for bulleted and numbered lists.</summary>
		public const int MaxLevel = 10;

		/// <summary>Represents the maximum number of charcters for the additinal text in front and behind the number of a numbered list.</summary>
		public const int MaxText = 20;

		internal const char char_0 = '·';

		internal const string string_0 = "Symbol";

		private int int_0 = -1;

		private Attribute attribute_0;

		private bool bool_0;

		private Attribute attribute_1;

		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private ListType listType_0 = ListType.None;

		private int int_1 = 1;

		private int int_2;

		private int int_3 = 360;

		private ListFormatCharacter listFormatCharacter_0 = ListFormatCharacter.Tab;

		private NumFormat numberFormat_0 = NumFormat.ArabicNumbers;

		private int int_4 = 1;

		private char char_1;

		private char char_2 = '.';

		private string string_1 = string.Empty;

		private string string_2 = ".";

		private bool bool_1;

		private char char_3 = '·';

		private int int_5;

		private string string_3 = "Symbol";

		/// <summary>Gets or sets the symbol character for a bulleted list.</summary>
		[DefaultValue('·')]
		[Attribute3("PROP_LIST_BULLETCHAR")]
		public char BulletCharacter
		{
			get
			{
				this.method_11(Attribute.BulletCharacter);
				return this.char_3;
			}
			set
			{
				this.char_3 = value;
				this.attribute_0 |= Attribute.BulletCharacter;
				this.method_12();
			}
		}

		/// <summary>Gets or sets the size of the symbol character for a bulleted list.</summary>
		[Attribute3("PROP_LIST_BULLETSIZE")]
		[DefaultValue(0)]
		public int BulletSize
		{
			get
			{
				this.method_11(Attribute.BulletSize);
				return this.int_5;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.int_5 = value;
				this.attribute_0 |= Attribute.BulletSize;
				this.method_12();
			}
		}

		/// <summary>Obsolete. Gets or sets a character that is displayed behind the number in a numbered list.</summary>
		[Browsable(false)]
		public char CharAfterNumber
		{
			get
			{
				this.method_11(Attribute.CharAfterNumber);
				return this.char_2;
			}
			set
			{
				this.char_2 = value;
				this.attribute_0 |= Attribute.CharAfterNumber;
				this.method_12();
			}
		}

		/// <summary>Obsolete. Gets or sets a character that is displayed in front of the number in a numbered list.</summary>
		[Browsable(false)]
		public char CharBeforeNumber
		{
			get
			{
				this.method_11(Attribute.CharBeforeNumber);
				return this.char_1;
			}
			set
			{
				this.char_1 = value;
				this.attribute_0 |= Attribute.CharBeforeNumber;
				this.method_12();
			}
		}

		/// <summary>Gets or sets the starting number for a numbered list.</summary>
		[DefaultValue(1)]
		[Attribute3("PROP_LIST_FIRSTNUMBER")]
		public int FirstNumber
		{
			get
			{
				this.method_11(Attribute.FirstNumber);
				return this.int_4;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.int_4 = value;
				this.attribute_0 |= Attribute.FirstNumber;
				this.method_12();
			}
		}

		/// <summary>Gets or sets the formatting character for a bulleted or numbered list.</summary>
		[Attribute3("PROP_LIST_FORMATCHARACTER")]
		[DefaultValue(ListFormatCharacter.Tab)]
		public ListFormatCharacter FormatCharacter
		{
			get
			{
				this.method_11(Attribute.FormatCharacter);
				return this.listFormatCharacter_0;
			}
			set
			{
				this.listFormatCharacter_0 = value;
				this.attribute_0 |= Attribute.FormatCharacter;
				this.method_12();
			}
		}

		/// <summary>Gets or sets the font used for the bullet character.</summary>
		[Attribute3("PROP_LIST_FONTNAME")]
		[DefaultValue("Symbol")]
		public string FontName
		{
			get
			{
				this.method_11(Attribute.FontName);
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
				this.attribute_0 |= Attribute.FontName;
				this.method_12();
			}
		}

		/// <summary>Gets or sets the hanging indent of a numbered list.</summary>
		[DefaultValue(360)]
		[Attribute3("PROP_LIST_HANGINGINDENT")]
		public int HangingIndent
		{
			get
			{
				this.method_11(Attribute.HangingIndent);
				return this.int_3;
			}
			set
			{
				if (value > 32767)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.int_3 = value;
				this.attribute_0 |= Attribute.HangingIndent;
				this.method_12();
			}
		}

		/// <summary>Gets or sets the left indent for a numbered list.</summary>
		[Attribute3("PROP_LIST_LEFTINDENT")]
		[DefaultValue(0)]
		public int LeftIndent
		{
			get
			{
				this.method_11(Attribute.LeftIndent);
				return this.int_2;
			}
			set
			{
				if (value < 0 || value > 32767)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.int_2 = value;
				this.attribute_0 |= Attribute.LeftIndent;
				this.method_12();
			}
		}

		/// <summary>Gets or sets the level for a bulleted or numbered list.</summary>
		[Attribute3("PROP_LIST_LEVEL")]
		[DefaultValue(1)]
		public int Level
		{
			get
			{
				this.method_11(Attribute.Level);
				return this.int_1;
			}
			set
			{
				if (value < 1 || value > 10)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.int_1 = value;
				this.attribute_0 |= Attribute.Level;
				this.method_12();
			}
		}

		/// <summary>Gets or sets the number format for a numbered list.</summary>
		[Attribute3("PROP_LIST_NUMBERFORMAT")]
		[DefaultValue(NumFormat.ArabicNumbers)]
		public NumFormat NumberFormat
		{
			get
			{
				this.method_11(Attribute.NumberFormat);
				return this.numberFormat_0;
			}
			set
			{
				this.numberFormat_0 = value;
				this.attribute_0 |= Attribute.NumberFormat;
				this.method_12();
			}
		}

		/// <summary>Gets or sets a value determining whether a new numbered list begins.</summary>
		[Attribute3("PROP_LIST_RESTARTNUMBERING")]
		[DefaultValue(false)]
		public bool RestartNumbering
		{
			get
			{
				this.method_11(Attribute.RestartNumbering);
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
				this.attribute_0 |= Attribute.RestartNumbering;
				this.method_12();
			}
		}

		/// <summary>Gets or sets the text that is displayed behind the number in a numbered list.</summary>
		[Attribute3("PROP_LIST_TEXTAFTERNUMBER")]
		[DefaultValue(".")]
		public string TextAfterNumber
		{
			get
			{
				this.method_11(Attribute.TextAfterNumber);
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
				this.attribute_0 |= Attribute.TextAfterNumber;
				this.method_12();
			}
		}

		/// <summary>Gets or sets the text that is displayed in front of the number in a numbered list.</summary>
		[DefaultValue("")]
		[Attribute3("PROP_LIST_TEXTBEFORENUMBER")]
		public string TextBeforeNumber
		{
			get
			{
				this.method_11(Attribute.TextBeforeNumber);
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
				this.attribute_0 |= Attribute.TextBeforeNumber;
				this.method_12();
			}
		}

		/// <summary>Gets or sets the type of the list, bulleted, numbered or none.</summary>
		[DefaultValue(ListType.None)]
		[Attribute3("PROP_LIST_TYPE")]
		[RefreshProperties(RefreshProperties.Repaint)]
		public ListType Type
		{
			get
			{
				this.method_11(Attribute.Type);
				return this.listType_0;
			}
			set
			{
				this.listType_0 = value;
				this.attribute_0 |= Attribute.Type;
				this.method_12();
			}
		}

		internal int Int32_0
		{
			get
			{
				int num = 0;
				for (int i = 0; i < 32; i++)
				{
					if (((uint)this.attribute_0 & (uint)(1 << i)) != 0)
					{
						num++;
					}
				}
				return num;
			}
		}

		/// <summary>Creates a new empty instance of the ListFormat class.</summary>
		public ListFormat()
		{
			this.method_5();
		}

		/// <summary>Creates a new instance of the ListFormat class which has the specified list type.</summary>
		/// <param name="type">Specifies one of the ListType values.</param>
		public ListFormat(ListType type)
		{
			this.method_5();
			this.listType_0 = type;
			this.attribute_0 |= Attribute.Type;
		}

		internal ListFormat(int iPosition)
		{
			this.method_5();
			this.int_0 = iPosition;
		}

		internal ListFormat(ListType iType, int iPosition)
		{
			this.method_5();
			this.listType_0 = iType;
			this.attribute_0 |= Attribute.Type;
			this.int_0 = iPosition;
		}

		internal bool method_0()
		{
			if (this.listType_0 == ListType.None && this.int_1 == 1 && this.int_2 == 0 && this.int_3 == 360 && this.listFormatCharacter_0 == ListFormatCharacter.Tab && this.numberFormat_0 == NumFormat.ArabicNumbers && this.int_4 == 1 && this.char_1 == '\0' && this.char_2 == '.' && this.string_1 == string.Empty && this.string_2 == "." && this.char_3 == '·' && this.int_5 == 0)
			{
				return this.string_3 == "Symbol";
			}
			return false;
		}

		internal void method_1(TextControlCore textControlCore_1, TextPart textPart_1)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = textPart_1;
		}

		internal void method_2(TextControlCore textControlCore_1, TextPart textPart_1, int int_6)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = textPart_1;
			this.int_0 = int_6;
		}

		internal void method_3(ListFormat listFormat_0)
		{
			listFormat_0.listType_0 = this.listType_0;
			listFormat_0.int_1 = this.int_1;
			listFormat_0.int_2 = this.int_2;
			listFormat_0.int_3 = this.int_3;
			listFormat_0.listFormatCharacter_0 = this.listFormatCharacter_0;
			listFormat_0.numberFormat_0 = this.numberFormat_0;
			listFormat_0.int_4 = this.int_4;
			listFormat_0.char_1 = this.char_1;
			listFormat_0.char_2 = this.char_2;
			listFormat_0.string_1 = this.string_1;
			listFormat_0.string_2 = this.string_2;
			listFormat_0.char_3 = this.char_3;
			listFormat_0.int_5 = this.int_5;
			listFormat_0.string_3 = this.string_3;
			listFormat_0.attribute_0 = this.attribute_0;
		}

		internal bool method_4(Attribute attribute_2)
		{
			return (this.attribute_0 & attribute_2) != 0;
		}

		internal void method_5()
		{
			this.listType_0 = ListType.None;
			this.int_1 = 1;
			this.int_2 = 0;
			this.int_3 = 360;
			this.listFormatCharacter_0 = ListFormatCharacter.Tab;
			this.numberFormat_0 = NumFormat.ArabicNumbers;
			this.int_4 = 1;
			this.char_1 = '\0';
			this.char_2 = '.';
			this.string_1 = string.Empty;
			this.string_2 = ".";
			this.char_3 = '·';
			this.int_5 = 0;
			this.string_3 = "Symbol";
		}

		internal bool method_6(Attribute attribute_2)
		{
			this.method_11(attribute_2);
			return (this.attribute_1 & attribute_2) == 0;
		}

		internal void method_7()
		{
			this.method_5();
			this.attribute_0 = Attribute.All;
			this.method_12();
		}

		internal void method_8()
		{
			if (this.char_1 != 0 && this.string_1 == "")
			{
				this.string_1 = this.char_1.ToString();
			}
			if (this.char_2 != '.' && this.string_2 == ".")
			{
				this.string_2 = this.char_2.ToString();
			}
		}

		internal void method_9()
		{
			this.attribute_0 = (Attribute)0;
		}

		internal void method_10()
		{
			this.attribute_0 = Attribute.All;
		}

		private void method_11(Attribute attribute_2)
		{
			if (this.int_0 == 0 || this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated || this.bool_0)
			{
				return;
			}
			this.attribute_1 = (Attribute)0;
			this.method_5();
			if (this.int_0 > 0)
			{
				this.textControlCore_0.method_14(this.textPart_0, this.int_0 - 1, 0);
			}
			Struct61 struct61_ = new Struct61(0);
			this.listType_0 = (ListType)this.textControlCore_0.method_47(this.textPart_0, 1910, 0, ref struct61_);
			if (this.int_0 > 0)
			{
				this.textControlCore_0.method_15(this.textPart_0);
			}
			if ((this.listType_0 & (ListType)6) != 0)
			{
				if (struct61_.short_0 == -1)
				{
					this.attribute_1 |= Attribute.LeftIndent;
					this.int_2 = 0;
				}
				else
				{
					this.int_2 = struct61_.short_0;
				}
				if (struct61_.short_1 != -1 && struct61_.short_0 != -1)
				{
					this.int_3 = struct61_.short_1 - struct61_.short_0;
				}
				else
				{
					this.attribute_1 |= Attribute.HangingIndent;
					this.int_3 = 0;
				}
				this.int_1 = struct61_.ushort_1;
				if (this.int_1 == 0)
				{
					this.attribute_1 |= Attribute.Level;
					this.int_1 = 1;
				}
				switch (struct61_.sbyte_0)
				{
				default:
					this.listFormatCharacter_0 = ListFormatCharacter.Tab;
					this.attribute_1 |= Attribute.FormatCharacter;
					break;
				case 32:
					this.listFormatCharacter_0 = ListFormatCharacter.Space;
					break;
				case 9:
					this.listFormatCharacter_0 = ListFormatCharacter.Tab;
					break;
				case 1:
					this.listFormatCharacter_0 = ListFormatCharacter.None;
					break;
				}
			}
			if ((this.listType_0 & ListType.Numbered) != 0)
			{
				this.numberFormat_0 = (NumFormat)struct61_.ushort_2;
				if (this.numberFormat_0 == NumFormat.None)
				{
					this.numberFormat_0 = NumFormat.ArabicNumbers;
					this.attribute_1 |= Attribute.NumberFormat;
				}
				this.int_4 = struct61_.ushort_4;
				if (this.int_4 == 0)
				{
					this.int_4 = 1;
					this.attribute_1 |= Attribute.FirstNumber;
				}
				if (struct61_.char_1[0] == '\0')
				{
					this.char_1 = '\0';
					this.attribute_1 |= Attribute.CharBeforeNumber;
				}
				else
				{
					this.char_1 = ((struct61_.char_1[0] != '\u0001') ? struct61_.char_1[0] : '\0');
				}
				if (struct61_.char_2[0] == '\0')
				{
					this.char_2 = '\0';
					this.attribute_1 |= Attribute.CharAfterNumber;
				}
				else
				{
					this.char_2 = ((struct61_.char_2[0] != '\u0001') ? struct61_.char_2[0] : '\0');
				}
				switch (struct61_.ushort_3 & 3)
				{
				default:
					this.bool_1 = false;
					this.attribute_1 |= Attribute.RestartNumbering;
					break;
				case 1:
					this.bool_1 = true;
					break;
				case 2:
					this.bool_1 = false;
					break;
				}
				if (struct61_.char_1[0] == '\0')
				{
					this.string_1 = string.Empty;
					this.attribute_1 |= Attribute.TextBeforeNumber;
				}
				else if (struct61_.char_1[0] == '\u0001')
				{
					this.string_1 = string.Empty;
				}
				else
				{
					this.string_1 = KernelHelper.GetString(struct61_.char_1);
				}
				if (struct61_.char_2[0] == '\0')
				{
					this.string_2 = string.Empty;
					this.attribute_1 |= Attribute.TextAfterNumber;
				}
				else if (struct61_.char_2[0] == '\u0001')
				{
					this.string_2 = string.Empty;
				}
				else
				{
					this.string_2 = KernelHelper.GetString(struct61_.char_2);
				}
				if ((struct61_.ushort_3 & 0xC) == 0)
				{
					this.listType_0 |= ListType.Structured;
				}
				if ((struct61_.ushort_3 & 8u) != 0)
				{
					this.listType_0 &= (ListType)(-5);
					this.listType_0 |= ListType.Structured;
				}
			}
			if ((this.listType_0 & ListType.Bulleted) != 0)
			{
				this.char_3 = struct61_.char_0;
				if (this.char_3 == '\0')
				{
					this.char_3 = '·';
					this.attribute_1 |= Attribute.BulletCharacter;
				}
				if (struct61_.short_2 == 0)
				{
					this.int_5 = 0;
					this.attribute_1 |= Attribute.BulletSize;
				}
				else
				{
					this.int_5 = ((struct61_.short_2 != -1) ? struct61_.short_2 : 0);
				}
				if (struct61_.char_3[0] == '\0')
				{
					this.string_3 = string.Empty;
					this.attribute_1 |= Attribute.FontName;
				}
				else
				{
					this.string_3 = KernelHelper.GetString(struct61_.char_3);
				}
			}
			if ((this.listType_0 & ListType.Bulleted) == 0)
			{
				this.attribute_1 |= (Attribute)768;
			}
			if ((this.listType_0 & ListType.Numbered) == 0 && (this.listType_0 & ListType.Structured) == 0)
			{
				this.attribute_1 |= (Attribute)12536;
			}
			if (this.listType_0 == ListType.None)
			{
				this.attribute_1 = Attribute.All;
				this.attribute_1 &= (Attribute)(-2049);
			}
			if (this.listType_0 != ListType.None && this.listType_0 != ListType.Bulleted && this.listType_0 != ListType.Numbered && this.listType_0 != ListType.Structured)
			{
				this.listType_0 = ListType.None;
				this.attribute_1 |= Attribute.Type;
			}
			this.bool_0 = true;
		}

		internal void method_12()
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated || this.attribute_0 == (Attribute)0)
			{
				return;
			}
			ListType listType = (ListType)0;
			Struct61 struct61_ = new Struct61(0);
			this.attribute_1 &= ~this.attribute_0;
			if ((this.attribute_0 & Attribute.LeftIndent) != 0 || (this.attribute_0 & Attribute.HangingIndent) != 0)
			{
				struct61_.short_1 = (short)(this.int_2 + this.int_3);
				struct61_.short_0 = (short)this.int_2;
			}
			if ((this.attribute_0 & Attribute.Level) != 0)
			{
				struct61_.ushort_1 = (ushort)this.int_1;
			}
			if ((this.attribute_0 & Attribute.FormatCharacter) != 0)
			{
				struct61_.sbyte_0 = (sbyte)this.listFormatCharacter_0;
			}
			if ((this.attribute_0 & Attribute.BulletSize) != 0)
			{
				struct61_.short_2 = (short)((this.int_5 == 0) ? (-1) : this.int_5);
			}
			if ((this.attribute_0 & Attribute.NumberFormat) != 0)
			{
				struct61_.ushort_2 = (ushort)this.numberFormat_0;
			}
			if ((this.attribute_0 & Attribute.FirstNumber) != 0)
			{
				struct61_.ushort_4 = (ushort)this.int_4;
			}
			if ((this.attribute_0 & Attribute.BulletCharacter) != 0)
			{
				struct61_.char_0 = this.char_3;
				if ((this.attribute_0 & Attribute.FontName) != 0)
				{
					this.string_3.CopyTo(0, struct61_.char_3, 0, Math.Min(32, this.string_3.Length));
				}
				else
				{
					"Symbol".CopyTo(0, struct61_.char_3, 0, Math.Min(32, "Symbol".Length));
				}
			}
			if ((this.attribute_0 & Attribute.CharBeforeNumber) != 0)
			{
				struct61_.char_1[0] = ((this.char_1 == '\0') ? '\u0001' : this.char_1);
			}
			if ((this.attribute_0 & Attribute.CharAfterNumber) != 0)
			{
				struct61_.char_2[0] = ((this.char_2 == '\0') ? '\u0001' : this.char_2);
			}
			if ((this.attribute_0 & Attribute.RestartNumbering) != 0)
			{
				struct61_.ushort_3 |= (ushort)(this.bool_1 ? 1 : 2);
			}
			if ((this.attribute_0 & Attribute.Type) != 0)
			{
				struct61_.ushort_3 |= (ushort)((this.listType_0 == ListType.Numbered) ? 4 : ((this.listType_0 == ListType.Structured) ? 8 : 0));
				listType = this.listType_0;
			}
			if ((this.attribute_0 & Attribute.TextBeforeNumber) != 0)
			{
				if (this.string_1 == string.Empty)
				{
					struct61_.char_1[0] = '\u0001';
					struct61_.char_1[1] = '\0';
				}
				else
				{
					this.string_1.CopyTo(0, struct61_.char_1, 0, Math.Min(20, this.string_1.Length));
					struct61_.char_1[19] = '\0';
				}
			}
			if ((this.attribute_0 & Attribute.TextAfterNumber) != 0)
			{
				if (this.string_2 == string.Empty)
				{
					struct61_.char_2[0] = '\u0001';
					struct61_.char_2[1] = '\0';
				}
				else
				{
					this.string_2.CopyTo(0, struct61_.char_2, 0, Math.Min(20, this.string_2.Length));
					struct61_.char_2[19] = '\0';
				}
			}
			switch (this.int_0)
			{
			default:
				this.textControlCore_0.method_14(this.textPart_0, this.int_0 - 1, 0);
				break;
			case 0:
				this.textControlCore_0.method_12(this.textPart_0);
				break;
			case -1:
				break;
			}
			this.textControlCore_0.method_47(this.textPart_0, 1911, (int)listType, ref struct61_);
			if (this.int_0 >= 0)
			{
				this.textControlCore_0.method_15(this.textPart_0);
			}
			this.attribute_0 = (Attribute)0;
		}

		internal Attribute method_13()
		{
			Attribute attribute = (Attribute)0;
			Attribute attribute2 = this.attribute_1;
			this.bool_0 = false;
			ListType listType = this.listType_0;
			NumFormat numberFormat = this.numberFormat_0;
			char c = this.char_3;
			this.method_11(Attribute.All);
			if (listType != this.listType_0 || (attribute2 & Attribute.Type) != (this.attribute_1 & Attribute.Type))
			{
				attribute |= Attribute.Type;
			}
			if (numberFormat != this.numberFormat_0 || (attribute2 & Attribute.NumberFormat) != (this.attribute_1 & Attribute.NumberFormat))
			{
				attribute |= Attribute.NumberFormat;
			}
			if (c != this.char_3 || (attribute2 & Attribute.BulletCharacter) != (this.attribute_1 & Attribute.BulletCharacter))
			{
				attribute |= Attribute.BulletCharacter;
			}
			return attribute;
		}

		internal void method_14()
		{
			this.bool_0 = false;
		}
	}
}
