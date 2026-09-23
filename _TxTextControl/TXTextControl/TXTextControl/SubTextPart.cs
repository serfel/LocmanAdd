using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>A SubTextPart object represents a user-defined part of a document.</summary>
	public class SubTextPart
	{
		private enum Enum74
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
			const_12 = 0xFFF
		}

		internal TextControlCore textControlCore_0;

		private int int_0;

		private int int_1;

		private TextPart textPart_0;

		private Enum74 enum74_0;

		private Enum74 enum74_1;

		private string string_0 = string.Empty;

		private Color color_0 = Color.FromArgb(60, 255, 0, 0);

		private HighlightMode highlightMode_0 = HighlightMode.Activated;

		private int int_2;

		private int int_3;

		private string string_1 = string.Empty;

		private int int_4 = 1;

		private int int_5;

		private int int_6;

		private int int_7;

		/// <summary>Gets or sets additional data of the subtextpart.</summary>
		public string Data
		{
			get
			{
				this.method_2(Enum74.const_10);
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
				this.enum74_0 |= Enum74.const_10;
				this.method_3();
			}
		}

		/// <summary>Gets or sets the highlight color for the subtextpart.</summary>
		public Color HighlightColor
		{
			get
			{
				this.method_2(Enum74.const_4);
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				this.enum74_0 |= Enum74.const_4;
				this.method_3();
			}
		}

		/// <summary>Gets or sets a value indicating when the subtextpart is highlighted.</summary>
		public HighlightMode HighlightMode
		{
			get
			{
				this.method_2(Enum74.const_5);
				return this.highlightMode_0;
			}
			set
			{
				this.highlightMode_0 = value;
				this.enum74_0 |= Enum74.const_5;
				this.method_3();
			}
		}

		public int Int32_0
		{
			get
			{
				this.method_2(Enum74.const_3);
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
				this.enum74_0 |= Enum74.const_3;
				this.method_3();
			}
		}

		/// <summary>Gets the number of characters which belong to the subtextpart.</summary>
		public int Length
		{
			get
			{
				this.method_2(Enum74.const_1);
				return this.int_3;
			}
		}

		/// <summary>Gets or sets the name of the subtextpart.</summary>
		public string Name
		{
			get
			{
				this.method_2(Enum74.const_2);
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
				this.enum74_0 |= Enum74.const_2;
				this.method_3();
			}
		}

		/// <summary>Gets the subtextpart's nested level.</summary>
		public int NestedLevel
		{
			get
			{
				this.method_2(Enum74.const_6);
				return this.int_4;
			}
		}

		/// <summary>Gets the subtextpart's number.</summary>
		public int Number
		{
			get
			{
				if (this.int_0 == 0)
				{
					this.method_2(Enum74.const_9);
				}
				return this.int_0;
			}
		}

		/// <summary>Gets a subtextpart's outermost subtextpart.</summary>
		public SubTextPart OuterMostSubTextPart
		{
			get
			{
				this.method_2(Enum74.const_8);
				if (this.int_5 == 0)
				{
					return null;
				}
				return new SubTextPart(this.textControlCore_0, this.textPart_0, this.int_5, 0);
			}
		}

		/// <summary>Gets a subtextpart's outer subtextpart.</summary>
		public SubTextPart OuterSubTextPart
		{
			get
			{
				this.method_2(Enum74.const_7);
				if (this.int_6 == 0)
				{
					return null;
				}
				return new SubTextPart(this.textControlCore_0, this.textPart_0, this.int_6, 0);
			}
		}

		/// <summary>Gets the index (one-based) of the first character which belongs to the subtextpart.</summary>
		public int Start
		{
			get
			{
				this.method_2(Enum74.const_0);
				return this.int_7;
			}
		}

		/// <summary>Gets the subtextpart's text.</summary>
		public string Text
		{
			get
			{
				this.Save(out var stringData, StringStreamType.PlainText);
				return stringData;
			}
		}

		/// <summary>Creates a subtextpart with the specified name and/or id. The start and length of the subtextpart are initialized to zero. When a zero-length subtextpart is inserted, the current text selection defines it position and length.</summary>
		/// <param name="name">Specifies the name of the subtextpart.</param>
		/// <param name="id">Specifies an identifier for the subtextpart.</param>
		public SubTextPart(string name, int int_8)
		{
			this.string_1 = name;
			this.int_2 = int_8;
		}

		/// <summary>Creates a subtextpart with the specified name, id, start position and length.</summary>
		/// <param name="name">Specifies the name of the subtextpart.</param>
		/// <param name="id">Specifies an identifier for the subtextpart.</param>
		/// <param name="start">Specifies the index (one-based) of the first character which belongs to the subtextpart.</param>
		/// <param name="length">Specifies the number of characters which belong to the subtextpart.</param>
		public SubTextPart(string name, int int_8, int start, int length)
		{
			if (start < 1)
			{
				throw new ArgumentException();
			}
			this.string_1 = name;
			this.int_2 = int_8;
			this.int_7 = start;
			this.int_3 = length;
		}

		internal SubTextPart(TextControlCore textControlCore_1, TextPart iTextPart, int iNumber, int iInternalID)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_0 = iNumber;
			this.textPart_0 = iTextPart;
			this.int_1 = iInternalID;
		}

		public override bool Equals(object obj)
		{
			if (obj != null && !(obj.GetType() != base.GetType()))
			{
				SubTextPart subTextPart = (SubTextPart)obj;
				if (this.int_1 != 0 && subTextPart.int_1 != 0)
				{
					return this.int_1 == subTextPart.int_1;
				}
				return base.Equals(obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (this.int_1 == 0)
			{
				this.method_2(Enum74.const_11);
			}
			if (this.int_1 == 0)
			{
				return base.GetHashCode();
			}
			return this.int_1;
		}

		/// <summary>Saves the subtextpart's text in a byte array with the specified format.</summary>
		/// <param name="binaryData">Specifies a byte array into which the subtextpart's text is saved.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		public void Save(out byte[] binaryData, BinaryStreamType binaryStreamType)
		{
			this.Save(out binaryData, binaryStreamType, new SaveSettings());
		}

		/// <summary>Saves the subtextpart's text as a string with the specified format.</summary>
		/// <param name="stringData">Specifies a string into which the subtextpart's text is saved.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		public void Save(out string stringData, StringStreamType stringStreamType)
		{
			this.Save(out stringData, stringStreamType, new SaveSettings());
		}

		/// <summary>Saves the subtextpart's text in a byte array with the specified format and special settings.</summary>
		/// <param name="binaryData">Specifies a byte array into which the subtextpart's text is saved.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(out byte[] binaryData, BinaryStreamType binaryStreamType, SaveSettings saveSettings)
		{
			saveSettings.TextPart = this.textPart_0;
			this.textControlCore_0.method_16(this.textPart_0, this.Start - 1, this.Length);
			saveSettings.method_3(out binaryData, binaryStreamType, this.textControlCore_0, Enum104.const_7);
			this.textControlCore_0.method_17(this.textPart_0);
		}

		/// <summary>Saves the subtextpart's text as a string with the specified format and special settings.</summary>
		/// <param name="stringData">Specifies a string into which the subtextpart's text is saved.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(out string stringData, StringStreamType stringStreamType, SaveSettings saveSettings)
		{
			saveSettings.TextPart = this.textPart_0;
			this.textControlCore_0.method_16(this.textPart_0, this.Start - 1, this.Length);
			saveSettings.method_4(out stringData, stringStreamType, this.textControlCore_0, Enum104.const_7);
			this.textControlCore_0.method_17(this.textPart_0);
		}

		internal bool method_0(bool bool_0, bool bool_1)
		{
			bool flag = false;
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, this.int_2, this.string_1, Enum52.const_0);
			try
			{
				Enum53 @enum = ((!bool_0) ? Enum53.const_0 : ((Enum53)0)) | (bool_1 ? Enum53.const_1 : ((Enum53)0));
				return (this.textControlCore_0.method_58(this.textPart_0, Enum83.const_307, (int)@enum, ref struct46_) != IntPtr.Zero) ? true : false;
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

		/// <summary>Sets the current input position to the beginning of a subtextpart and scrolls it into the visible part of the document.</summary>
		public bool ScrollTo()
		{
			bool flag = false;
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, this.int_2, this.string_1, Enum52.const_0);
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

		/// <summary>Returns an array of SubTextPart objects which are the children of this SubTextPart. The array contains all direct children and all further descendants in the order as they appear in the text.</summary>
		public SubTextPart[] GetChildren()
		{
			SubTextPart[] result = null;
			IntPtr intPtr = IntPtr.Zero;
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, this.int_2, this.string_1, Enum52.const_0);
			try
			{
				intPtr = this.textControlCore_0.method_58(this.textPart_0, Enum83.const_340, 0, ref struct46_);
				if (intPtr != IntPtr.Zero)
				{
					int[] array = KernelHelper.PtrInt16ToIntArray(intPtr);
					result = new SubTextPart[array.Length];
					for (int i = 0; i < array.Length; i++)
					{
						result[i] = new SubTextPart(this.textControlCore_0, this.textPart_0, 0, array[i]);
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
				if (intPtr != IntPtr.Zero)
				{
					Class429.GlobalFree(intPtr);
				}
			}
		}

		/// <summary>Returns an array of TextField objects which are completely contained in this SubTextPart. The objects' type depend on the fieldType parameter.</summary>
		/// <param name="fieldType">Specifies types of text fields.</param>
		public TextField[] GetTextFields(TextFieldType fieldType)
		{
			TextField[] result = null;
			IntPtr intPtr = IntPtr.Zero;
			try
			{
				int[] array = new int[2];
				array[0] = this.Start - 1;
				array[1] = array[0] + this.Length;
				intPtr = this.textControlCore_0.method_65(this.textPart_0, Enum83.const_341, (uint)fieldType, array);
				if (intPtr != IntPtr.Zero)
				{
					int[] array2 = KernelHelper.PtrInt32ToIntArray(intPtr);
					result = new TextField[array2.Length];
					for (int i = 0; i < array2.Length; i++)
					{
						result[i] = TextFieldCollectionBase.CreateTextField(this.textControlCore_0, this.textPart_0, Class429.smethod_5(array2[i]), (Enum105)Class429.smethod_6(array2[i]));
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
				if (intPtr != IntPtr.Zero)
				{
					Class429.GlobalFree(intPtr);
				}
			}
		}

		internal bool method_1(TextControlCore textControlCore_1, TextPart textPart_1, int int_8)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = textPart_1;
			this.int_1 = int_8;
			this.method_2(Enum74.const_12);
			return this.enum74_1 == Enum74.const_12;
		}

		private void method_2(Enum74 enum74_2)
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated || (this.int_1 == 0 && this.int_0 == 0 && this.int_2 == 0 && this.string_1 == string.Empty) || (enum74_2 & Enum74.const_12) == 0 || (this.enum74_1 & Enum74.const_12) != 0)
			{
				return;
			}
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, this.int_2, this.string_1, Enum52.const_0);
			struct46_.ushort_5 |= 1;
			try
			{
				if (this.textControlCore_0.method_58(this.textPart_0, Enum83.const_310, 0, ref struct46_) != IntPtr.Zero)
				{
					this.int_0 = (int)struct46_.uint_4;
					this.int_1 = struct46_.ushort_4;
					this.int_7 = (int)(struct46_.uint_0 + 1);
					this.int_3 = (int)struct46_.uint_1;
					this.color_0 = Class429.smethod_2((int)struct46_.uint_2);
					if (struct46_.byte_0 < byte.MaxValue)
					{
						this.color_0 = Color.FromArgb(struct46_.byte_0, this.color_0);
					}
					this.highlightMode_0 = ((((uint)struct46_.ushort_1 & (true ? 1u : 0u)) != 0) ? HighlightMode.Activated : (((struct46_.ushort_1 & 2) == 0) ? HighlightMode.Never : HighlightMode.Always));
					this.int_2 = (int)struct46_.uint_3;
					if (struct46_.intptr_0 != IntPtr.Zero)
					{
						this.string_1 = Marshal.PtrToStringBSTR(struct46_.intptr_0);
					}
					this.int_4 = struct46_.ushort_2;
					this.int_6 = (int)struct46_.uint_5;
					this.int_5 = (int)struct46_.uint_6;
					this.int_0 = (int)struct46_.uint_4;
					if (struct46_.intptr_1 != IntPtr.Zero)
					{
						this.string_0 = Marshal.PtrToStringBSTR(struct46_.intptr_1);
					}
					this.enum74_1 |= Enum74.const_12;
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

		internal void method_3()
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated || this.enum74_0 == (Enum74)0 || (this.int_0 == 0 && this.int_1 == 0))
			{
				return;
			}
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, 0, string.Empty, Enum52.const_0)
			{
				ushort_1 = 0,
				uint_2 = 2147483648u,
				uint_3 = uint.MaxValue,
				intptr_0 = IntPtr.Zero
			};
			if ((this.enum74_0 & Enum74.const_4) != 0)
			{
				struct46_.uint_2 = (uint)Class429.smethod_0(this.color_0);
				struct46_.byte_0 = this.color_0.A;
			}
			if ((this.enum74_0 & Enum74.const_3) != 0)
			{
				struct46_.uint_3 = (uint)this.int_2;
			}
			if ((this.enum74_0 & Enum74.const_5) != 0)
			{
				struct46_.ushort_1 = (ushort)((this.highlightMode_0 == HighlightMode.Activated) ? 1u : ((this.highlightMode_0 == HighlightMode.Always) ? 2u : 4u));
			}
			if ((this.enum74_0 & Enum74.const_2) != 0)
			{
				struct46_.intptr_0 = Marshal.StringToBSTR(this.string_1);
			}
			if ((this.enum74_0 & Enum74.const_10) != 0)
			{
				struct46_.intptr_1 = Marshal.StringToBSTR(this.string_0);
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
