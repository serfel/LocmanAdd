using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>A TableOfContents object defines the position and the properties of a table of contents.</summary>
	public class TableOfContents
	{
		private enum Enum80
		{
			const_0 = 1,
			const_1 = 2,
			const_2 = 4,
			const_3 = 8,
			const_4 = 0x10,
			const_5 = 0x20,
			const_6 = 0x40,
			const_7 = 0x80,
			const_8 = 0x100,
			const_9 = 0x200,
			const_10 = 0x400,
			const_11 = 0x800,
			const_12 = 0x1000,
			const_13 = 0x2000,
			const_14 = 0x3FFF
		}

		internal enum Enum81
		{
			const_0 = 1,
			const_1 = 2,
			const_2 = 4
		}

		private static Color color_0 = Color.FromArgb(60, 0, 0, 0);

		internal TextControlCore textControlCore_0;

		private int int_0;

		private int int_1;

		private TextPart textPart_0;

		private Enum80 enum80_0;

		private Enum80 enum80_1;

		private bool bool_0 = true;

		private bool bool_1 = true;

		private bool bool_2 = true;

		private Color color_1 = TableOfContents.color_0;

		private HighlightMode highlightMode_0 = HighlightMode.Activated;

		private int int_2;

		private int int_3;

		private short short_0 = 2;

		private short short_1 = 1;

		private string string_0 = string.Empty;

		private int int_4;

		private string string_1 = string.Empty;

		/// <summary>Represents the default highlight color.</summary>
		public static Color DefaultHighlightColor => TableOfContents.color_0;

		/// <summary>Gets or sets a value specifying whether each entry in the table of contents is a DocumentLink with a corresponding DocumentTarget.</summary>
		public bool HasLinks
		{
			get
			{
				this.method_3(Enum80.const_10);
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				this.enum80_0 |= Enum80.const_10;
				this.method_4();
			}
		}

		/// <summary>Gets or sets a value specifying whether the table of contents contains page numbers.</summary>
		public bool HasPageNumbers
		{
			get
			{
				this.method_3(Enum80.const_11);
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
				this.enum80_0 |= Enum80.const_11;
				this.method_4();
			}
		}

		/// <summary>Gets or sets a value specifying whether the page numbers in the table of contents are right-aligned.</summary>
		public bool HasRightAlignedPageNumbers
		{
			get
			{
				this.method_3(Enum80.const_12);
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
				this.enum80_0 |= Enum80.const_12;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the highlight color for the table of contents.</summary>
		public Color HighlightColor
		{
			get
			{
				this.method_3(Enum80.const_4);
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
				this.enum80_0 |= Enum80.const_4;
				this.method_4();
			}
		}

		/// <summary>Gets or sets a value indicating how the text of the table of contents is highlighted.</summary>
		public HighlightMode HighlightMode
		{
			get
			{
				this.method_3(Enum80.const_5);
				return this.highlightMode_0;
			}
			set
			{
				this.highlightMode_0 = value;
				this.enum80_0 |= Enum80.const_5;
				this.method_4();
			}
		}

		public int Int32_0
		{
			get
			{
				this.method_3(Enum80.const_3);
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
				this.enum80_0 |= Enum80.const_3;
				this.method_4();
			}
		}

		/// <summary>Gets the number of characters which belong to the table of contents.</summary>
		public int Length
		{
			get
			{
				this.method_3(Enum80.const_1);
				return this.int_3;
			}
		}

		/// <summary>Gets or sets the maximum structure level for this table of contents.</summary>
		public short MaximumStructureLevel
		{
			get
			{
				this.method_3(Enum80.const_8);
				return this.short_0;
			}
			set
			{
				if (value < 1 || value > 10)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.short_0 = value;
				this.enum80_0 |= Enum80.const_8;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the minimum structure level for this table of contents.</summary>
		public short MinimumStructureLevel
		{
			get
			{
				this.method_3(Enum80.const_9);
				return this.short_1;
			}
			set
			{
				if (value < 1 || value > 10)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.short_1 = value;
				this.enum80_0 |= Enum80.const_9;
				this.method_4();
			}
		}

		/// <summary>Gets or sets a name for the table of contents.</summary>
		public string Name
		{
			get
			{
				this.method_3(Enum80.const_2);
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
				this.enum80_0 |= Enum80.const_2;
				this.method_4();
			}
		}

		/// <summary>Gets the number of the table of contents in the text.</summary>
		public int Number
		{
			get
			{
				if (this.int_0 == 0)
				{
					this.method_3(Enum80.const_6);
				}
				return this.int_0;
			}
		}

		/// <summary>Gets the index (one-based) of the first character which belongs to the table of contents.</summary>
		public int Start
		{
			get
			{
				this.method_3(Enum80.const_0);
				return this.int_4;
			}
		}

		/// <summary>Gets the text of the table of contents.</summary>
		public string Text
		{
			get
			{
				this.Save(out var stringData, StringStreamType.PlainText);
				return stringData;
			}
		}

		/// <summary>Gets or sets a title for the table of contents.</summary>
		public string Title
		{
			get
			{
				this.method_3(Enum80.const_13);
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
				this.enum80_0 |= Enum80.const_13;
				this.method_4();
			}
		}

		/// <summary>Defines a table of contents with the specified minimum and maximum structure level. All paragraphs that have a level between these borders will be contained in the table of contents. The ParagraphFormat.StructureLevel property dedines the level of a paragraph.</summary>
		/// <param name="minimumStructureLevel">Specifies the minimum structure level of the paragraphs that will be contained in the table of contents.</param>
		/// <param name="maximumStructureLevel">Specifies the maximum structure level of the paragraphs that will be contained in the table of contents.</param>
		public TableOfContents(short minimumStructureLevel, short maximumStructureLevel)
		{
			this.short_1 = minimumStructureLevel;
			this.short_0 = maximumStructureLevel;
		}

		internal TableOfContents(string name, int int_5)
		{
			this.string_0 = name;
			this.int_2 = int_5;
		}

		internal TableOfContents(TextControlCore textControlCore_1, TextPart iTextPart, int iNumber, int iInternalID)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_0 = iNumber;
			this.textPart_0 = iTextPart;
			this.int_1 = iInternalID;
			this.method_3(Enum80.const_14);
		}

		public override bool Equals(object obj)
		{
			if (obj != null && !(obj.GetType() != base.GetType()))
			{
				TableOfContents tableOfContents = (TableOfContents)obj;
				if (this.int_1 != 0 && tableOfContents.int_1 != 0)
				{
					return this.int_1 == tableOfContents.int_1;
				}
				return base.Equals(obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (this.int_1 == 0)
			{
				this.method_3(Enum80.const_7);
			}
			if (this.int_1 == 0)
			{
				return base.GetHashCode();
			}
			return this.int_1;
		}

		/// <summary>Saves the text of the table of contents in a byte array with the specified format.</summary>
		/// <param name="binaryData">Specifies a byte array into which the text is saved.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		public void Save(out byte[] binaryData, BinaryStreamType binaryStreamType)
		{
			this.Save(out binaryData, binaryStreamType, new SaveSettings());
		}

		/// <summary>Saves the text of the table of contents as a string with the specified format.</summary>
		/// <param name="stringData">Specifies a string into which the text is saved.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		public void Save(out string stringData, StringStreamType stringStreamType)
		{
			this.Save(out stringData, stringStreamType, new SaveSettings());
		}

		/// <summary>Saves the text of the table of contents in a byte array with the specified format and special settings.</summary>
		/// <param name="binaryData">Specifies a byte array into which the text is saved.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(out byte[] binaryData, BinaryStreamType binaryStreamType, SaveSettings saveSettings)
		{
			saveSettings.TextPart = this.textPart_0;
			this.textControlCore_0.method_16(this.textPart_0, this.Start - 1, this.Length);
			saveSettings.method_3(out binaryData, binaryStreamType, this.textControlCore_0, Enum104.const_7);
			this.textControlCore_0.method_17(this.textPart_0);
		}

		/// <summary>Saves the text of the table of contents as a string with the specified format and special settings.</summary>
		/// <param name="stringData">Specifies a string into which the text is saved.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(out string stringData, StringStreamType stringStreamType, SaveSettings saveSettings)
		{
			saveSettings.TextPart = this.textPart_0;
			this.textControlCore_0.method_16(this.textPart_0, this.Start - 1, this.Length);
			saveSettings.method_4(out stringData, stringStreamType, this.textControlCore_0, Enum104.const_7);
			this.textControlCore_0.method_17(this.textPart_0);
		}

		internal int method_0(TextControlCore textControlCore_1, TextPart textPart_1)
		{
			int num = 0;
			Struct47 struct47_ = new Struct47(this.short_1, this.short_0)
			{
				uint_0 = (uint)Class429.smethod_0(this.color_1),
				byte_1 = this.color_1.A,
				ushort_2 = (ushort)((this.highlightMode_0 == HighlightMode.Activated) ? 1u : ((this.highlightMode_0 == HighlightMode.Always) ? 2u : 4u))
			};
			if (this.bool_0)
			{
				struct47_.ushort_1 |= 1;
			}
			if (this.bool_1)
			{
				struct47_.ushort_1 |= 2;
			}
			if (this.bool_2)
			{
				struct47_.ushort_1 |= 4;
			}
			if (!string.IsNullOrEmpty(this.string_1))
			{
				struct47_.intptr_0 = Marshal.StringToBSTR(this.string_1);
			}
			try
			{
				textControlCore_1.method_19(textPart_1, null);
				textControlCore_1.method_23(bool_1: true);
				num = textControlCore_1.method_59(textPart_1, Enum83.const_346, 0, ref struct47_).ToInt32();
				if (num == 2)
				{
					if (struct47_.ushort_3 != 0)
					{
						this.method_2(textControlCore_1, textPart_1, struct47_.ushort_3, bool_3: false);
						this.enum80_0 &= (Enum80)(-7985);
						this.method_4();
						return num;
					}
					return num;
				}
				return num;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				textControlCore_1.method_23(bool_1: false);
				textControlCore_1.method_20(textPart_1);
			}
		}

		internal bool method_1()
		{
			bool flag = false;
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, this.int_2, this.string_0, Enum52.const_4);
			try
			{
				if (flag = ((this.textControlCore_0.method_58(this.textPart_0, Enum83.const_307, 1, ref struct46_) != IntPtr.Zero) ? true : false))
				{
					this.textControlCore_0 = null;
					return flag;
				}
				return flag;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (struct46_.intptr_0 != IntPtr.Zero)
				{
					Marshal.FreeBSTR(struct46_.intptr_0);
				}
			}
		}

		/// <summary>Sets the current input position to the beginning of the table of contents and scrolls it into the visible part of the document.</summary>
		public bool ScrollTo()
		{
			bool flag = false;
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, this.int_2, this.string_0, Enum52.const_4);
			try
			{
				return this.textControlCore_0.method_58(this.textPart_0, Enum83.const_311, 0, ref struct46_) != IntPtr.Zero;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (struct46_.intptr_0 != IntPtr.Zero)
				{
					Marshal.FreeBSTR(struct46_.intptr_0);
				}
			}
		}

		/// <summary>Updates the content and the page numbers of the table of contents.</summary>
		public TableOfContentsCollection.AddResult Update()
		{
			return (TableOfContentsCollection.AddResult)this.textControlCore_0.method_29(this.textPart_0, 2017, this.int_1, 0);
		}

		internal bool method_2(TextControlCore textControlCore_1, TextPart textPart_1, int int_5, bool bool_3)
		{
			bool result = true;
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = textPart_1;
			this.int_1 = int_5;
			if (bool_3)
			{
				this.method_3(Enum80.const_14);
				result = this.enum80_1 == Enum80.const_14;
			}
			return result;
		}

		private void method_3(Enum80 enum80_2)
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated || (this.int_1 == 0 && this.int_0 == 0 && this.int_2 == 0 && this.string_0 == string.Empty) || (enum80_2 & Enum80.const_14) == 0 || (this.enum80_1 & Enum80.const_14) == Enum80.const_14)
			{
				return;
			}
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, this.int_2, this.string_0, Enum52.const_4);
			struct46_.ushort_5 |= 1;
			try
			{
				if (this.textControlCore_0.method_58(this.textPart_0, Enum83.const_310, 0, ref struct46_) != IntPtr.Zero)
				{
					this.int_0 = (int)struct46_.uint_4;
					this.int_1 = struct46_.ushort_4;
					this.int_4 = (int)(struct46_.uint_0 + 1);
					this.int_3 = (int)struct46_.uint_1;
					this.color_1 = Class429.smethod_2((int)struct46_.uint_2);
					if (struct46_.byte_0 < byte.MaxValue)
					{
						this.color_1 = Color.FromArgb(struct46_.byte_0, this.color_1);
					}
					this.highlightMode_0 = ((((uint)struct46_.ushort_1 & (true ? 1u : 0u)) != 0) ? HighlightMode.Activated : (((struct46_.ushort_1 & 2) == 0) ? HighlightMode.Never : HighlightMode.Always));
					this.int_2 = (int)struct46_.uint_3;
					if (struct46_.intptr_0 != IntPtr.Zero)
					{
						this.string_0 = Marshal.PtrToStringBSTR(struct46_.intptr_0);
					}
					this.int_0 = (int)struct46_.uint_4;
					if (struct46_.intptr_1 != IntPtr.Zero)
					{
						this.string_1 = Marshal.PtrToStringBSTR(struct46_.intptr_1);
					}
					ushort ushort_ = Class429.smethod_5((int)struct46_.uint_9);
					this.short_1 = Class429.smethod_9(ushort_);
					this.short_0 = Class429.smethod_10(ushort_);
					Enum81 @enum = (Enum81)Class429.smethod_6((int)struct46_.uint_9);
					this.bool_0 = (((@enum & Enum81.const_0) != 0) ? true : false);
					this.bool_1 = (((@enum & Enum81.const_1) != 0) ? true : false);
					this.bool_2 = (((@enum & Enum81.const_2) != 0) ? true : false);
					this.enum80_1 |= Enum80.const_14;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (struct46_.intptr_0 != IntPtr.Zero)
				{
					Marshal.FreeBSTR(struct46_.intptr_0);
				}
				if (struct46_.intptr_1 != IntPtr.Zero)
				{
					Marshal.FreeBSTR(struct46_.intptr_1);
				}
			}
		}

		private void method_4()
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated || this.enum80_0 == (Enum80)0 || (this.int_0 == 0 && this.int_1 == 0))
			{
				return;
			}
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, 0, string.Empty, Enum52.const_4)
			{
				ushort_1 = 0,
				uint_2 = 2147483648u,
				uint_3 = uint.MaxValue,
				intptr_0 = IntPtr.Zero,
				uint_9 = uint.MaxValue
			};
			if ((this.enum80_0 & Enum80.const_4) != 0)
			{
				struct46_.uint_2 = (uint)Class429.smethod_0(this.color_1);
				struct46_.byte_0 = this.color_1.A;
			}
			if ((this.enum80_0 & Enum80.const_3) != 0)
			{
				struct46_.uint_3 = (uint)this.int_2;
			}
			if ((this.enum80_0 & Enum80.const_5) != 0)
			{
				struct46_.ushort_1 = (ushort)((this.highlightMode_0 == HighlightMode.Activated) ? 1u : ((this.highlightMode_0 == HighlightMode.Always) ? 2u : 4u));
			}
			if ((this.enum80_0 & Enum80.const_2) != 0)
			{
				struct46_.intptr_0 = Marshal.StringToBSTR(this.string_0);
			}
			if ((this.enum80_0 & Enum80.const_13) != 0)
			{
				struct46_.intptr_1 = Marshal.StringToBSTR(this.string_1);
			}
			if ((this.enum80_0 & Enum80.const_9) != 0 || (this.enum80_0 & Enum80.const_8) != 0 || (this.enum80_0 & Enum80.const_10) != 0 || (this.enum80_0 & Enum80.const_11) != 0 || (this.enum80_0 & Enum80.const_12) != 0)
			{
				ushort num = Class429.smethod_4((byte)this.short_1, (byte)this.short_0);
				ushort num2 = 0;
				if (this.bool_0)
				{
					num2 = (ushort)(num2 | 1u);
				}
				if (this.bool_1)
				{
					num2 = (ushort)(num2 | 2u);
				}
				if (this.bool_2)
				{
					num2 = (ushort)(num2 | 4u);
				}
				struct46_.uint_9 = (uint)Class429.smethod_3(num, num2);
			}
			try
			{
				this.textControlCore_0.method_58(this.textPart_0, Enum83.const_308, 0, ref struct46_);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (struct46_.intptr_0 != IntPtr.Zero)
				{
					Marshal.FreeBSTR(struct46_.intptr_0);
				}
				if (struct46_.intptr_1 != IntPtr.Zero)
				{
					Marshal.FreeBSTR(struct46_.intptr_1);
				}
			}
		}
	}
}
