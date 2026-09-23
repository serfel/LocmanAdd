using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>The FormattingStyle object represents a styling for a text range.</summary>
	public class FormattingStyle
	{
		[Flags]
		internal enum Enum59
		{
			flag_0 = 0x1,
			flag_1 = 0x2,
			flag_2 = 0x4,
			flag_3 = 0x8,
			flag_4 = 0x10,
			flag_5 = 0x20,
			flag_6 = 0x40,
			flag_7 = 0x80,
			flag_8 = 0x100,
			flag_9 = 0x10000,
			flag_10 = 0x20000,
			flag_11 = 0x301FF
		}

		private int int_0;

		private string string_0 = string.Empty;

		private int int_1;

		private bool bool_0;

		private bool bool_1;

		private FontUnderlineStyle fontUnderlineStyle_0 = FontUnderlineStyle.None;

		private bool bool_2;

		private Color color_0 = Color.Empty;

		private string string_1 = string.Empty;

		private string string_2 = string.Empty;

		private Color color_1 = Color.Empty;

		private Enum58 enum58_0 = Enum58.const_0;

		internal Enum59 enum59_0;

		internal Enum59 enum59_1;

		internal string string_3 = string.Empty;

		internal ParagraphFormat paragraphFormat_0 = new ParagraphFormat();

		internal ListFormat listFormat_0 = new ListFormat();

		internal uint uint_0;

		private TextControlCore textControlCore_0;

		private string string_4 = string.Empty;

		private Enum58 enum58_1;

		/// <summary>Gets or sets the baseline alignment, in twips, of the style.</summary>
		public int Baseline
		{
			get
			{
				return this.int_0;
			}
			set
			{
				if (value < -960 || value > 960)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.enum59_0 |= Enum59.flag_6;
				this.int_0 = value;
			}
		}

		/// <summary>Gets the FormattingStyle which is the base style of this style.</summary>
		public FormattingStyle BaseStyle
		{
			get
			{
				if (this.string_4 != null && this.string_4 != string.Empty && this.enum58_1 != 0)
				{
					if (this.enum58_1 == Enum58.const_0)
					{
						return new ParagraphStyle(this.textControlCore_0, this.string_4);
					}
					if (this.enum58_1 == Enum58.const_1)
					{
						return new InlineStyle(this.textControlCore_0, this.string_4);
					}
				}
				return null;
			}
		}

		/// <summary>Gets or sets the font of the style.</summary>
		public string FontName
		{
			get
			{
				return this.string_0;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException();
				}
				this.enum59_0 |= Enum59.flag_0;
				this.string_0 = value;
			}
		}

		/// <summary>Gets or sets the font's size of the style.</summary>
		public int FontSize
		{
			get
			{
				return this.int_1;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.enum59_0 |= Enum59.flag_1;
				this.int_1 = value;
			}
		}

		/// <summary>Gets or sets the bold attribute of the style.</summary>
		public bool Bold
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.enum59_0 |= Enum59.flag_2;
				this.bool_0 = value;
			}
		}

		/// <summary>Gets or sets the italic attribute of the style.</summary>
		public bool Italic
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.enum59_0 |= Enum59.flag_3;
				this.bool_1 = value;
			}
		}

		/// <summary>Gets or sets underlining styles for the style.</summary>
		public FontUnderlineStyle Underline
		{
			get
			{
				return this.fontUnderlineStyle_0;
			}
			set
			{
				this.enum59_0 |= Enum59.flag_4;
				this.fontUnderlineStyle_0 = value;
			}
		}

		/// <summary>Gets or sets the strikeout attribute of the style.</summary>
		public bool Strikeout
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.enum59_0 |= Enum59.flag_5;
				this.bool_2 = value;
			}
		}

		/// <summary>Gets or sets the style's color used to display the text.</summary>
		public Color ForeColor
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.enum59_0 |= Enum59.flag_7;
				this.color_0 = value;
			}
		}

		/// <summary>Gets or sets the name of the style.</summary>
		public string Name
		{
			get
			{
				return this.string_1;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException();
				}
				this.enum59_0 |= Enum59.flag_9;
				this.string_2 = value;
			}
		}

		/// <summary>Gets or sets the style's text background color.</summary>
		public Color TextBackColor
		{
			get
			{
				return this.color_1;
			}
			set
			{
				this.enum59_0 |= Enum59.flag_8;
				this.color_1 = value;
			}
		}

		internal FormattingStyle(TextControlCore textControlCore_1, string name, Enum58 type)
		{
			this.textControlCore_0 = textControlCore_1;
			this.string_1 = name;
			this.enum58_0 = type;
			this.method_3();
		}

		internal FormattingStyle(string name, string strBaseStyle, Enum58 type)
		{
			this.string_1 = name;
			this.enum58_0 = type;
			this.string_4 = strBaseStyle;
			this.enum59_0 |= Enum59.flag_9;
		}

		internal FormattingStyle(FormattingStyle style)
		{
			style.method_2(this);
			this.string_3 = string.Empty;
			this.string_4 = string.Empty;
			this.enum59_0 = Enum59.flag_11;
			this.paragraphFormat_0.method_9();
			this.listFormat_0.method_10();
		}

		/// <summary>Applies all set attributes of the style to the current document.</summary>
		public bool Apply()
		{
			bool result = false;
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated && this.string_1.Length != 0)
			{
				Struct71 struct71_ = new Struct71(this.string_1);
				this.method_4(ref struct71_, this.textControlCore_0);
				try
				{
					if (result = this.textControlCore_0.method_71(Enum83.const_186, this.string_1, ref struct71_) != 0)
					{
						this.enum59_0 = (Enum59)0;
						if (this.string_2.Length != 0)
						{
							this.string_1 = this.string_2;
							this.string_2 = string.Empty;
							return result;
						}
						return result;
					}
					return result;
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					struct71_.method_0();
				}
			}
			return result;
		}

		internal bool method_0(TextControlCore textControlCore_1)
		{
			Struct71 struct71_ = new Struct71(this.string_1)
			{
				ushort_1 = (ushort)this.enum58_0
			};
			this.method_4(ref struct71_, textControlCore_1);
			if (textControlCore_1.method_71(Enum83.const_191, this.string_4, ref struct71_) != 0)
			{
				this.method_1(textControlCore_1);
				this.enum59_0 = (Enum59)0;
				return true;
			}
			return false;
		}

		internal void method_1(TextControlCore textControlCore_1)
		{
			this.textControlCore_0 = textControlCore_1;
			this.method_3();
		}

		private void method_2(FormattingStyle formattingStyle_0)
		{
			formattingStyle_0.enum59_0 = this.enum59_0;
			formattingStyle_0.int_0 = this.int_0;
			formattingStyle_0.string_0 = this.string_0;
			formattingStyle_0.int_1 = this.int_1;
			formattingStyle_0.bool_0 = this.bool_0;
			formattingStyle_0.bool_1 = this.bool_1;
			formattingStyle_0.fontUnderlineStyle_0 = this.fontUnderlineStyle_0;
			formattingStyle_0.bool_2 = this.bool_2;
			formattingStyle_0.color_0 = this.color_0;
			formattingStyle_0.string_1 = this.string_1;
			formattingStyle_0.color_1 = this.color_1;
			formattingStyle_0.enum58_0 = this.enum58_0;
			formattingStyle_0.string_3 = this.string_3;
			this.paragraphFormat_0.method_3(formattingStyle_0.paragraphFormat_0);
			this.listFormat_0.method_3(formattingStyle_0.listFormat_0);
			formattingStyle_0.uint_0 = this.uint_0;
			formattingStyle_0.string_4 = this.string_4;
		}

		internal void method_3()
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated)
			{
				return;
			}
			Struct71 struct71_ = new Struct71(this.string_1);
			Struct61 @struct = new Struct61(0);
			Marshal.StructureToPtr((object)@struct, struct71_.intptr_4, fDeleteOld: false);
			try
			{
				this.textControlCore_0.method_71(Enum83.const_185, this.string_1, ref struct71_);
				if (struct71_.intptr_1 != IntPtr.Zero)
				{
					this.string_0 = Marshal.PtrToStringBSTR(struct71_.intptr_1);
				}
				else
				{
					this.enum59_1 |= Enum59.flag_0;
				}
				if (struct71_.ushort_2 != 0)
				{
					this.int_1 = struct71_.ushort_2;
				}
				else
				{
					this.enum59_1 |= Enum59.flag_1;
				}
				Enum96 @enum = (Enum96)struct71_.uint_0;
				this.bool_0 = (@enum & Enum96.const_2) != 0;
				if ((@enum & Enum96.const_10) != 0)
				{
					this.enum59_1 |= Enum59.flag_2;
				}
				this.bool_1 = (@enum & Enum96.const_3) != 0;
				if ((@enum & Enum96.const_11) != 0)
				{
					this.enum59_1 |= Enum59.flag_3;
				}
				this.bool_2 = (@enum & Enum96.const_5) != 0;
				if ((@enum & Enum96.const_13) != 0)
				{
					this.enum59_1 |= Enum59.flag_5;
				}
				this.fontUnderlineStyle_0 = FontUnderlineStyle.None;
				if ((@enum & Enum96.const_4) != 0)
				{
					this.fontUnderlineStyle_0 = (((@enum & Enum96.const_7) != 0) ? FontUnderlineStyle.SingleWordsOnly : FontUnderlineStyle.Single);
				}
				else if ((@enum & Enum96.const_6) != 0)
				{
					this.fontUnderlineStyle_0 = (((@enum & Enum96.const_7) != 0) ? FontUnderlineStyle.DoubledWordsOnly : FontUnderlineStyle.Doubled);
				}
				else if ((@enum & Enum96.const_12) != 0)
				{
					this.enum59_1 |= Enum59.flag_4;
				}
				switch (struct71_.ushort_3)
				{
				case 8:
					this.int_0 = (short)(-struct71_.ushort_4);
					break;
				case 2:
					this.int_0 = 0;
					break;
				default:
					this.int_0 = 0;
					this.enum59_1 |= Enum59.flag_6;
					break;
				case 4:
					this.int_0 = (short)struct71_.ushort_4;
					break;
				}
				if (struct71_.uint_1 == 2147483648u)
				{
					this.color_0 = SystemColors.WindowText;
					this.enum59_1 |= Enum59.flag_7;
				}
				else if (struct71_.uint_1 == 1073741824)
				{
					this.color_0 = SystemColors.WindowText;
				}
				else
				{
					this.color_0 = Class429.smethod_2((int)struct71_.uint_1);
				}
				if (struct71_.uint_2 == 2147483648u)
				{
					this.color_1 = SystemColors.Window;
					this.enum59_1 |= Enum59.flag_8;
				}
				else if (struct71_.uint_2 == 1073741824)
				{
					this.color_1 = SystemColors.Window;
				}
				else if (struct71_.uint_2 == 1342177280)
				{
					this.color_1 = Class429.smethod_2(this.textControlCore_0.GetTextControl().GetBackColor());
				}
				else
				{
					this.color_1 = Class429.smethod_2((int)struct71_.uint_2);
				}
				if (struct71_.intptr_5 != IntPtr.Zero)
				{
					this.string_4 = Marshal.PtrToStringBSTR(struct71_.intptr_5);
					this.enum58_1 = (Enum58)struct71_.ushort_16;
				}
				if (this.enum58_0 == Enum58.const_0)
				{
					this.paragraphFormat_0.Alignment = (HorizontalAlignment)struct71_.ushort_5;
					short num = (short)struct71_.ushort_8;
					this.paragraphFormat_0.LeftIndent = struct71_.ushort_6 + num;
					this.paragraphFormat_0.HangingIndent = -num;
					this.paragraphFormat_0.RightIndent = struct71_.ushort_7;
					this.paragraphFormat_0.TopDistance = struct71_.ushort_9;
					this.paragraphFormat_0.BottomDistance = struct71_.ushort_10;
					if (struct71_.ushort_11 != 0)
					{
						this.paragraphFormat_0.LineSpacing = struct71_.ushort_11;
					}
					if (struct71_.ushort_12 != 0)
					{
						this.paragraphFormat_0.AbsoluteLineSpacing = struct71_.ushort_12;
					}
					this.paragraphFormat_0.Frame = (Frame)((int)struct71_.uint_3 & 0x8F);
					this.paragraphFormat_0.FrameStyle = (FrameStyle)((int)struct71_.uint_3 & 0x60);
					if (struct71_.ushort_13 > 0)
					{
						this.paragraphFormat_0.FrameLineWidth = struct71_.ushort_13;
					}
					if (struct71_.short_0 >= 0)
					{
						this.paragraphFormat_0.FrameDistance = struct71_.short_0;
					}
					this.paragraphFormat_0.KeepLinesTogether = (struct71_.uint_5 & 1) != 0;
					this.paragraphFormat_0.KeepWithNext = (struct71_.uint_5 & 8) != 0;
					this.paragraphFormat_0.PageBreakBefore = (struct71_.uint_5 & 0x10) != 0;
					this.paragraphFormat_0.WidowOrphanLines = (((struct71_.uint_5 & 0x20u) != 0) ? 1 : (((struct71_.uint_5 & 0x40u) != 0) ? 2 : (((struct71_.uint_5 & 0x80u) != 0) ? 3 : 0)));
					this.paragraphFormat_0.BackColor = ((struct71_.uint_6 == 1342177280) ? Color.Transparent : Class429.smethod_2((int)struct71_.uint_6));
					this.paragraphFormat_0.FrameLineColor = ((struct71_.uint_7 == 1073741824) ? SystemColors.WindowText : Class429.smethod_2((int)struct71_.uint_7));
					this.paragraphFormat_0.Direction = (((struct71_.uint_5 & 0x100) == 0) ? Direction.LeftToRight : Direction.RightToLeft);
					this.paragraphFormat_0.Justification = (((struct71_.uint_5 & 0x4000000u) != 0 && (struct71_.uint_5 & 0x2000000u) != 0) ? Justification.Spaces : (((struct71_.uint_5 & 0x200) == 0 || (struct71_.uint_5 & 0x400) == 0) ? Justification.SpacesAndKashida : Justification.Kashida));
					int[] array = new int[14];
					TabType[] array2 = new TabType[14];
					TabLeader[] array3 = new TabLeader[14];
					for (int i = 0; i < 14; i++)
					{
						array2[i] = (TabType)struct71_.byte_0[i * 3];
						array[i] = Class429.smethod_4(struct71_.byte_0[i * 3 + 1], struct71_.byte_0[i * 3 + 2]);
						array3[i] = (TabLeader)struct71_.byte_2[i];
					}
					this.paragraphFormat_0.TabTypes = array2;
					this.paragraphFormat_0.TabPositions = array;
					this.paragraphFormat_0.TabLeaders = array3;
					this.paragraphFormat_0.StructureLevel = struct71_.short_1;
					@struct = (Struct61)Marshal.PtrToStructure(struct71_.intptr_4, typeof(Struct61));
					this.listFormat_0.Type = (ListType)((struct71_.ushort_15 != 4 || (@struct.ushort_3 & 8) == 0) ? struct71_.ushort_15 : 8);
					if (this.listFormat_0.Type != ListType.None)
					{
						this.listFormat_0.LeftIndent = @struct.short_0;
						this.listFormat_0.HangingIndent = @struct.short_1 - @struct.short_0;
						this.listFormat_0.Level = @struct.ushort_1;
						this.listFormat_0.FormatCharacter = (ListFormatCharacter)@struct.sbyte_0;
						this.listFormat_0.NumberFormat = (NumFormat)@struct.ushort_2;
						this.listFormat_0.FirstNumber = @struct.ushort_4;
						this.listFormat_0.CharBeforeNumber = ((@struct.char_1[0] != '\u0001') ? @struct.char_1[0] : '\0');
						this.listFormat_0.CharAfterNumber = ((@struct.char_2[0] != '\u0001') ? @struct.char_2[0] : '\0');
						this.listFormat_0.RestartNumbering = (@struct.ushort_3 & 1) != 0;
						this.listFormat_0.BulletCharacter = @struct.char_0;
						this.listFormat_0.BulletSize = ((@struct.short_2 != -1) ? @struct.short_2 : 0);
						this.listFormat_0.FontName = KernelHelper.GetString(@struct.char_3);
						this.listFormat_0.TextBeforeNumber = ((@struct.char_1[0] == '\u0001') ? string.Empty : KernelHelper.GetString(@struct.char_1));
						this.listFormat_0.TextAfterNumber = ((@struct.char_2[0] == '\u0001') ? string.Empty : KernelHelper.GetString(@struct.char_2));
					}
					if (struct71_.intptr_3 != IntPtr.Zero)
					{
						this.string_3 = Marshal.PtrToStringBSTR(struct71_.intptr_3);
					}
				}
				this.enum59_0 = (Enum59)0;
				this.paragraphFormat_0.method_8();
				this.listFormat_0.method_9();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				struct71_.method_0();
			}
		}

		private void method_4(ref Struct71 struct71_0, TextControlCore textControlCore_1)
		{
			if ((this.enum59_0 & Enum59.flag_9) != 0)
			{
				struct71_0.intptr_0 = Marshal.StringToBSTR((this.string_2.Length != 0) ? this.string_2 : this.string_1);
			}
			if ((this.enum59_0 & Enum59.flag_0) != 0)
			{
				struct71_0.intptr_1 = Marshal.StringToBSTR(this.string_0);
			}
			if ((this.enum59_0 & Enum59.flag_1) != 0)
			{
				struct71_0.ushort_2 = (ushort)this.int_1;
			}
			struct71_0.uint_0 = 0u;
			if ((this.enum59_0 & Enum59.flag_2) != 0)
			{
				struct71_0.uint_0 |= (uint)(this.bool_0 ? 4 : 1024);
			}
			if ((this.enum59_0 & Enum59.flag_3) != 0)
			{
				struct71_0.uint_0 |= (uint)(this.bool_1 ? 8 : 2048);
			}
			if ((this.enum59_0 & Enum59.flag_5) != 0)
			{
				struct71_0.uint_0 |= (uint)(this.bool_2 ? 32 : 8192);
			}
			if ((this.enum59_0 & Enum59.flag_4) != 0)
			{
				struct71_0.uint_0 |= (uint)this.fontUnderlineStyle_0;
			}
			if ((this.enum59_0 & Enum59.flag_6) != 0)
			{
				struct71_0.ushort_4 = (ushort)Math.Abs(this.int_0);
				struct71_0.ushort_3 = (ushort)((this.int_0 == 0) ? 2u : ((this.int_0 < 0) ? 8u : 4u));
			}
			if ((this.enum59_0 & Enum59.flag_7) != 0)
			{
				struct71_0.uint_1 = ((this.color_0 == SystemColors.WindowText) ? 1073741824u : ((uint)Class429.smethod_0(this.color_0)));
			}
			if ((this.enum59_0 & Enum59.flag_8) != 0)
			{
				struct71_0.uint_2 = ((Class429.smethod_0(this.color_1) == textControlCore_1.GetTextControl().GetBackColor()) ? 1342177280u : ((this.color_1 == SystemColors.Window) ? 1073741824u : ((uint)Class429.smethod_0(this.color_1))));
			}
			if (this.enum58_0 == Enum58.const_0)
			{
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.Alignment))
				{
					struct71_0.ushort_5 = (ushort)this.paragraphFormat_0.Alignment;
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.StructureLevel))
				{
					struct71_0.short_1 = (short)this.paragraphFormat_0.StructureLevel;
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.LeftIndent))
				{
					struct71_0.ushort_6 = (ushort)(this.paragraphFormat_0.LeftIndent + this.paragraphFormat_0.HangingIndent);
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.HangingIndent))
				{
					struct71_0.ushort_6 = (ushort)(this.paragraphFormat_0.LeftIndent + this.paragraphFormat_0.HangingIndent);
					struct71_0.ushort_8 = (ushort)(-this.paragraphFormat_0.HangingIndent);
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.RightIndent))
				{
					struct71_0.ushort_7 = (ushort)this.paragraphFormat_0.RightIndent;
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.TopDistance))
				{
					struct71_0.ushort_9 = (ushort)this.paragraphFormat_0.TopDistance;
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.BottomDistance))
				{
					struct71_0.ushort_10 = (ushort)this.paragraphFormat_0.BottomDistance;
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.LineSpacing))
				{
					struct71_0.ushort_11 = (ushort)this.paragraphFormat_0.LineSpacing;
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.AbsoluteLineSpacing))
				{
					struct71_0.ushort_12 = (ushort)this.paragraphFormat_0.AbsoluteLineSpacing;
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.Frame))
				{
					struct71_0.uint_3 |= (uint)this.paragraphFormat_0.Frame;
					if ((struct71_0.uint_3 & 1) == 0)
					{
						struct71_0.uint_3 |= 65536u;
					}
					if ((struct71_0.uint_3 & 2) == 0)
					{
						struct71_0.uint_3 |= 131072u;
					}
					if ((struct71_0.uint_3 & 4) == 0)
					{
						struct71_0.uint_3 |= 262144u;
					}
					if ((struct71_0.uint_3 & 8) == 0)
					{
						struct71_0.uint_3 |= 524288u;
					}
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.FrameStyle))
				{
					struct71_0.uint_3 |= (uint)this.paragraphFormat_0.FrameStyle;
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.FrameLineWidth))
				{
					struct71_0.ushort_13 = (ushort)this.paragraphFormat_0.FrameLineWidth;
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.FrameDistance))
				{
					struct71_0.short_0 = (short)this.paragraphFormat_0.FrameDistance;
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.KeepLinesTogether))
				{
					struct71_0.uint_5 |= (uint)(this.paragraphFormat_0.KeepLinesTogether ? 1 : 65536);
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.KeepWithNext))
				{
					struct71_0.uint_5 |= (uint)(this.paragraphFormat_0.KeepWithNext ? 8 : 524288);
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.PageBreakBefore))
				{
					struct71_0.uint_5 |= (uint)(this.paragraphFormat_0.PageBreakBefore ? 16 : 1048576);
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.WidowOrphanLines))
				{
					struct71_0.uint_5 |= (uint)(this.paragraphFormat_0.WidowOrphanLines switch
					{
						2 => 64, 
						1 => 32, 
						0 => 14680064, 
						_ => 128, 
					});
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.Direction))
				{
					struct71_0.uint_5 |= (uint)((this.paragraphFormat_0.Direction == Direction.RightToLeft) ? 256 : 16777216);
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.Justification))
				{
					struct71_0.uint_5 |= (uint)(this.paragraphFormat_0.Justification switch
					{
						Justification.Kashida => 1536, 
						Justification.Spaces => 100663296, 
						_ => 67109376, 
					});
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.BackColor))
				{
					struct71_0.uint_6 = ((Class429.smethod_0(this.paragraphFormat_0.BackColor) == textControlCore_1.GetTextControl().GetBackColor()) ? 1342177280u : ((uint)Class429.smethod_0(this.paragraphFormat_0.BackColor)));
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.FrameLineColor))
				{
					struct71_0.uint_7 = ((this.paragraphFormat_0.FrameLineColor == SystemColors.WindowText) ? 1073741824u : ((uint)Class429.smethod_0(this.paragraphFormat_0.FrameLineColor)));
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.TabPositions) && this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.TabTypes))
				{
					for (int i = 0; i < 14; i++)
					{
						struct71_0.byte_0[i * 3] = (byte)this.paragraphFormat_0.TabTypes[i];
						struct71_0.byte_0[i * 3 + 1] = (byte)(this.paragraphFormat_0.TabPositions[i] % 256);
						struct71_0.byte_0[i * 3 + 2] = (byte)(this.paragraphFormat_0.TabPositions[i] / 256);
					}
				}
				if (this.paragraphFormat_0.method_4(ParagraphFormat.Attribute.TabLeaders))
				{
					for (int j = 0; j < 14; j++)
					{
						struct71_0.byte_2[j] = (byte)this.paragraphFormat_0.TabLeaders[j];
					}
				}
				Struct61 @struct = new Struct61(0);
				if (this.listFormat_0.method_4(ListFormat.Attribute.Type))
				{
					ListType type = this.listFormat_0.Type;
					struct71_0.ushort_15 = (ushort)((type == ListType.Structured) ? 4 : ((ushort)type));
					@struct.ushort_3 |= (ushort)(type switch
					{
						ListType.Structured => 8, 
						ListType.Numbered => 4, 
						_ => 0, 
					});
				}
				if (this.listFormat_0.method_4(ListFormat.Attribute.Level))
				{
					@struct.ushort_1 = (ushort)this.listFormat_0.Level;
				}
				if (this.listFormat_0.method_4(ListFormat.Attribute.LeftIndent) || this.listFormat_0.method_4(ListFormat.Attribute.HangingIndent))
				{
					@struct.short_1 = (short)(this.listFormat_0.LeftIndent + this.listFormat_0.HangingIndent);
					@struct.short_0 = (short)this.listFormat_0.LeftIndent;
				}
				if (this.listFormat_0.method_4(ListFormat.Attribute.FormatCharacter))
				{
					@struct.sbyte_0 = (sbyte)this.listFormat_0.FormatCharacter;
				}
				if (this.listFormat_0.method_4(ListFormat.Attribute.NumberFormat))
				{
					@struct.ushort_2 = (ushort)this.listFormat_0.NumberFormat;
				}
				if (this.listFormat_0.method_4(ListFormat.Attribute.RestartNumbering))
				{
					@struct.ushort_3 = (ushort)(this.listFormat_0.RestartNumbering ? 1u : 2u);
				}
				if (this.listFormat_0.method_4(ListFormat.Attribute.FirstNumber))
				{
					@struct.ushort_4 = (ushort)this.listFormat_0.FirstNumber;
				}
				if (this.listFormat_0.method_4(ListFormat.Attribute.CharBeforeNumber))
				{
					char charBeforeNumber = this.listFormat_0.CharBeforeNumber;
					@struct.char_1[0] = ((charBeforeNumber == '\0') ? '\u0001' : charBeforeNumber);
				}
				if (this.listFormat_0.method_4(ListFormat.Attribute.CharAfterNumber))
				{
					char charAfterNumber = this.listFormat_0.CharAfterNumber;
					@struct.char_1[0] = ((charAfterNumber == '\0') ? '\u0001' : charAfterNumber);
				}
				if (this.listFormat_0.method_4(ListFormat.Attribute.BulletCharacter))
				{
					@struct.char_0 = this.listFormat_0.BulletCharacter;
					if (this.listFormat_0.method_4(ListFormat.Attribute.FontName))
					{
						this.listFormat_0.FontName.CopyTo(0, @struct.char_3, 0, Math.Min(32, this.listFormat_0.FontName.Length));
					}
					else
					{
						"Symbol".CopyTo(0, @struct.char_3, 0, Math.Min(32, "Symbol".Length));
					}
				}
				if (this.listFormat_0.method_4(ListFormat.Attribute.BulletSize))
				{
					int bulletSize = this.listFormat_0.BulletSize;
					@struct.short_2 = (short)((bulletSize == 0) ? (-1) : bulletSize);
				}
				if (this.listFormat_0.method_4(ListFormat.Attribute.TextBeforeNumber))
				{
					string textBeforeNumber = this.listFormat_0.TextBeforeNumber;
					if (textBeforeNumber == string.Empty)
					{
						@struct.char_1[0] = '\u0001';
						@struct.char_1[1] = '\0';
					}
					else
					{
						textBeforeNumber.CopyTo(0, @struct.char_1, 0, Math.Min(20, textBeforeNumber.Length));
						@struct.char_1[19] = '\0';
					}
				}
				if (this.listFormat_0.method_4(ListFormat.Attribute.TextAfterNumber))
				{
					string textAfterNumber = this.listFormat_0.TextAfterNumber;
					if (textAfterNumber == string.Empty)
					{
						@struct.char_2[0] = '\u0001';
						@struct.char_2[1] = '\0';
					}
					else
					{
						textAfterNumber.CopyTo(0, @struct.char_2, 0, Math.Min(20, textAfterNumber.Length));
						@struct.char_2[19] = '\0';
					}
				}
				Marshal.StructureToPtr((object)@struct, struct71_0.intptr_4, fDeleteOld: false);
				if ((this.enum59_0 & Enum59.flag_10) != 0)
				{
					struct71_0.intptr_3 = Marshal.StringToBSTR(this.string_3);
				}
			}
			struct71_0.uint_4 = this.uint_0;
		}
	}
}
