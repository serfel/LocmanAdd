using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>An EditableRegion object represents an editable region in a TX Text Control document.</summary>
	public class EditableRegion
	{
		private enum Enum54
		{
			const_0 = 1,
			const_1 = 2,
			const_2 = 4,
			const_3 = 8,
			const_4 = 0x10,
			const_5 = 0x20,
			const_6 = 0x40,
			const_7 = 0x80,
			const_8 = 0xFF
		}

		private static Color color_0 = Color.FromArgb(60, 0, 255, 0);

		internal TextControlCore textControlCore_0;

		private int int_0;

		private int int_1;

		private TextPart textPart_0;

		private Enum54 enum54_0;

		private Enum54 enum54_1;

		private Color color_1 = EditableRegion.color_0;

		private HighlightMode highlightMode_0 = HighlightMode.Always;

		private int int_2;

		private int int_3;

		private int int_4;

		private string string_0 = string.Empty;

		/// <summary>Gets the default highlight color of an editable region.</summary>
		public static Color DefaultHighlightColor => EditableRegion.color_0;

		/// <summary>Gets or sets the highlight color for the editable region.</summary>
		public Color HighlightColor
		{
			get
			{
				this.method_2(Enum54.const_4);
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
				this.enum54_0 |= Enum54.const_4;
				this.method_3();
			}
		}

		/// <summary>Gets or sets a value indicating when the editable region is highlighted.</summary>
		public HighlightMode HighlightMode
		{
			get
			{
				this.method_2(Enum54.const_5);
				return this.highlightMode_0;
			}
			set
			{
				this.highlightMode_0 = value;
				this.enum54_0 |= Enum54.const_5;
				this.method_3();
			}
		}

		public int Int32_0
		{
			get
			{
				this.method_2(Enum54.const_3);
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
				this.enum54_0 |= Enum54.const_3;
				this.method_3();
			}
		}

		/// <summary>Gets the number of characters which belong to the editable region.</summary>
		public int Length
		{
			get
			{
				this.method_2(Enum54.const_1);
				return this.int_3;
			}
		}

		/// <summary>Gets the editable region's number.</summary>
		public int Number
		{
			get
			{
				if (this.int_0 == 0)
				{
					this.method_2(Enum54.const_6);
				}
				return this.int_0;
			}
		}

		/// <summary>Gets the index (one-based) of the first character which belongs to the editable region.</summary>
		public int Start
		{
			get
			{
				this.method_2(Enum54.const_0);
				return this.int_4;
			}
		}

		/// <summary>Gets the editable region's text.</summary>
		public string Text
		{
			get
			{
				this.Save(out var stringData, StringStreamType.PlainText);
				return stringData;
			}
		}

		/// <summary>Gets or sets the name of the user who can edit the region.</summary>
		public string UserName
		{
			get
			{
				this.method_2(Enum54.const_2);
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
				this.enum54_0 |= Enum54.const_2;
				this.method_3();
			}
		}

		/// <summary>Creates an editable region with the specified user name and/or id. The start and length of the editable region are initialized to zero. When a zero-length editable region is inserted, the current text selection defines it position and length.</summary>
		/// <param name="userName">Specifies the name of the user who can edit the region.</param>
		/// <param name="id">Specifies an identifier for the editable region.</param>
		public EditableRegion(string userName, int int_5)
		{
			this.string_0 = userName;
			this.int_2 = int_5;
		}

		/// <summary>Creates an editable region with the specified user name, id, start position and length.</summary>
		/// <param name="userName">Specifies the name of the user who can edit the region.</param>
		/// <param name="id">Specifies an identifier for the editable region.</param>
		/// <param name="start">Specifies the index (one-based) of the first character which belongs to the editable region.</param>
		/// <param name="length">Specifies the number of characters which belong to the editable region.</param>
		public EditableRegion(string userName, int int_5, int start, int length)
		{
			if (start < 1)
			{
				throw new ArgumentException();
			}
			this.string_0 = userName;
			this.int_2 = int_5;
			this.int_4 = start;
			this.int_3 = length;
		}

		internal EditableRegion(int iInternalID, string userName, int int_5)
		{
			this.string_0 = userName;
			this.int_2 = int_5;
			this.int_1 = iInternalID;
		}

		internal EditableRegion(TextControlCore textControlCore_1, TextPart iTextPart, int iNumber, int iInternalID)
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
				EditableRegion editableRegion = (EditableRegion)obj;
				if (this.int_1 != 0 && editableRegion.int_1 != 0)
				{
					return this.int_1 == editableRegion.int_1;
				}
				return base.Equals(obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (this.int_1 == 0)
			{
				this.method_2(Enum54.const_7);
			}
			if (this.int_1 == 0)
			{
				return base.GetHashCode();
			}
			return this.int_1;
		}

		/// <summary>Saves the editable region's text in a byte array with the specified format.</summary>
		/// <param name="binaryData">Specifies a byte array into which the editable region's text is saved.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		public void Save(out byte[] binaryData, BinaryStreamType binaryStreamType)
		{
			this.Save(out binaryData, binaryStreamType, new SaveSettings());
		}

		/// <summary>Saves the editable region's text as a string with the specified format.</summary>
		/// <param name="stringData">Specifies a string into which the editable region's text is saved.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		public void Save(out string stringData, StringStreamType stringStreamType)
		{
			this.Save(out stringData, stringStreamType, new SaveSettings());
		}

		/// <summary>Saves the editable region's text in a byte array with the specified format and special settings.</summary>
		/// <param name="binaryData">Specifies a byte array into which the editable region's text is saved.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(out byte[] binaryData, BinaryStreamType binaryStreamType, SaveSettings saveSettings)
		{
			saveSettings.TextPart = this.textPart_0;
			this.textControlCore_0.method_16(this.textPart_0, this.Start - 1, this.Length);
			saveSettings.method_3(out binaryData, binaryStreamType, this.textControlCore_0, Enum104.const_7);
			this.textControlCore_0.method_17(this.textPart_0);
		}

		/// <summary>Saves the editable region's text as a string with the specified format and special settings.</summary>
		/// <param name="stringData">Specifies a string into which the editable region's text is saved.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(out string stringData, StringStreamType stringStreamType, SaveSettings saveSettings)
		{
			saveSettings.TextPart = this.textPart_0;
			this.textControlCore_0.method_16(this.textPart_0, this.Start - 1, this.Length);
			saveSettings.method_4(out stringData, stringStreamType, this.textControlCore_0, Enum104.const_7);
			this.textControlCore_0.method_17(this.textPart_0);
		}

		internal bool method_0(bool bool_0)
		{
			bool flag = false;
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, this.int_2, this.string_0, Enum52.const_1);
			try
			{
				Enum53 @enum = (bool_0 ? Enum53.const_2 : ((Enum53)0)) | Enum53.const_1;
				if (flag = ((this.textControlCore_0.method_58(this.textPart_0, Enum83.const_307, (int)@enum, ref struct46_) != IntPtr.Zero) ? true : false))
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

		/// <summary>Sets the current input position to the beginning of an editable region and scrolls it into the visible part of the document.</summary>
		public bool ScrollTo()
		{
			bool flag = false;
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, this.int_2, this.string_0, Enum52.const_1);
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

		internal bool method_1(TextControlCore textControlCore_1, TextPart textPart_1, int int_5)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = textPart_1;
			this.int_1 = int_5;
			this.method_2(Enum54.const_8);
			return this.enum54_1 == Enum54.const_8;
		}

		private void method_2(Enum54 enum54_2)
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated || (this.int_1 == 0 && this.int_0 == 0 && this.int_2 == 0 && this.string_0 == string.Empty) || (enum54_2 & Enum54.const_8) == 0 || (this.enum54_1 & Enum54.const_8) != 0)
			{
				return;
			}
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, this.int_2, this.string_0, Enum52.const_1);
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
					this.enum54_1 |= Enum54.const_8;
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
			}
		}

		internal void method_3()
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated || this.enum54_0 == (Enum54)0 || (this.int_0 == 0 && this.int_1 == 0))
			{
				return;
			}
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, 0, string.Empty, Enum52.const_1)
			{
				ushort_1 = 0,
				uint_2 = 2147483648u,
				uint_3 = uint.MaxValue,
				intptr_0 = IntPtr.Zero
			};
			if ((this.enum54_0 & Enum54.const_4) != 0)
			{
				struct46_.uint_2 = (uint)Class429.smethod_0(this.color_1);
				struct46_.byte_0 = this.color_1.A;
			}
			if ((this.enum54_0 & Enum54.const_3) != 0)
			{
				struct46_.uint_3 = (uint)this.int_2;
			}
			if ((this.enum54_0 & Enum54.const_5) != 0)
			{
				struct46_.ushort_1 = (ushort)((this.highlightMode_0 == HighlightMode.Activated) ? 1u : ((this.highlightMode_0 == HighlightMode.Always) ? 2u : 4u));
			}
			if ((this.enum54_0 & Enum54.const_2) != 0)
			{
				struct46_.intptr_0 = Marshal.StringToBSTR(this.string_0);
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
			}
		}
	}
}
