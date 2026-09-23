using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the TextField class represents a text field in a Text Control document.</summary>
	public class TextField
	{
		private enum Enum61
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
			const_14 = 0x4000,
			const_15 = 0x8000,
			const_16 = 0x10000,
			const_17 = 0x20000,
			const_18 = 0x40000,
			const_19 = 0x80000,
			const_20 = 0x100000,
			const_21 = 0x200000,
			const_22 = 0x400000,
			const_23 = 6488175
		}

		private enum Enum62
		{
			const_0 = 1,
			const_1 = 2,
			const_2 = 4,
			const_3 = 8,
			const_4 = 0x10,
			const_5 = 0x20,
			const_6 = 0x40,
			const_7 = 0x80,
			const_8 = 0x8000,
			const_9 = 0x4000,
			const_10 = 0x2000,
			const_11 = 0x1000,
			const_12 = 0x800,
			const_13 = 0x400,
			const_14 = 0x200,
			const_15 = 0x100
		}

		private enum Enum63
		{
			const_0 = 1,
			const_1 = 2,
			const_2 = 4,
			const_3 = 8,
			const_4 = 0x8000,
			const_5 = 0x4000,
			const_6 = 0x2000
		}

		private Enum61 enum61_0;

		private Enum61 enum61_1;

		internal TextControlCore textControlCore_0;

		internal TextPart textPart_0;

		internal int int_0;

		internal Enum105 enum105_0;

		private Rectangle rectangle_0 = new Rectangle(0, 0, 0, 0);

		private bool bool_0 = true;

		private bool bool_1;

		private bool bool_2 = true;

		private bool bool_3 = true;

		private Rectangle rectangle_1 = new Rectangle(0, 0, 0, 0);

		private Color color_0 = Color.FromArgb(60, 0, 0, 0);

		private HighlightMode highlightMode_0 = HighlightMode.Never;

		private int int_1;

		private bool bool_4 = true;

		private int int_2 = -1;

		private string string_0 = string.Empty;

		private bool bool_5;

		private int int_3 = -1;

		private string string_1 = string.Empty;

		private bool bool_6;

		private int int_4;

		private bool bool_7 = true;

		private AutoGenerationType autoGenerationType_0 = AutoGenerationType.None;

		private bool bool_8;

		private int int_5;

		private Struct43 struct43_0 = new Struct43(0L, string.Empty);

		private string string_2 = string.Empty;

		private string[] string_3;

		/// <summary>Gets the bounding rectangle of a text field.</summary>
		public Rectangle Bounds
		{
			get
			{
				this.method_3(Enum61.const_14);
				return this.rectangle_0;
			}
		}

		/// <summary>Returns true, if the Textfield contains the current text input position.</summary>
		public bool ContainsInputPosition
		{
			get
			{
				if (this.textControlCore_0 != null)
				{
					return this.textControlCore_0.method_29(this.textPart_0, 1218, 0, 0) == this.int_0;
				}
				return false;
			}
		}

		/// <summary>Specifies whether a text field can be deleted by the end-user while a TX Text Control document is being edited.</summary>
		[DefaultValue(true)]
		[Browsable(false)]
		public bool Deleteable
		{
			get
			{
				this.method_3(Enum61.const_0);
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				this.enum61_0 |= Enum61.const_0;
				this.vmethod_1();
			}
		}

		/// <summary>Specifies whether a text field has a doubled input position in front of its first character and behind its last character.</summary>
		[DefaultValue(false)]
		[Browsable(false)]
		public bool DoubledInputPosition
		{
			get
			{
				this.method_3(Enum61.const_1);
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
				this.enum61_0 |= Enum61.const_1;
				this.vmethod_1();
			}
		}

		/// <summary>Specifies whether the text of a text field can be changed by the end-user while a TX Text Control document is being edited.</summary>
		[Browsable(false)]
		[DefaultValue(true)]
		public bool Editable
		{
			get
			{
				this.method_3(Enum61.const_2);
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
				this.enum61_0 |= Enum61.const_2;
				this.vmethod_1();
			}
		}

		/// <summary>Specifies whether a TextControl.TextFieldDoubleClicked event is raised, if the end-user doubleclicks the text field.</summary>
		[DefaultValue(true)]
		[Browsable(false)]
		public bool DoubleClickEvent
		{
			get
			{
				this.method_3(Enum61.const_3);
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
				this.enum61_0 |= Enum61.const_3;
				this.vmethod_1();
			}
		}

		/// <summary>Gets the formatting rectangle of a text field.</summary>
		public Rectangle FormattingBounds
		{
			get
			{
				this.method_3(Enum61.const_15);
				return this.rectangle_1;
			}
		}

		/// <summary>Gets or sets the highlight color for the text field.</summary>
		public Color HighlightColor
		{
			get
			{
				this.method_3(Enum61.const_18);
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				this.enum61_0 |= Enum61.const_18;
				this.vmethod_1();
			}
		}

		/// <summary>Gets or sets a value indicating when the text field is highlighted.</summary>
		public HighlightMode HighlightMode
		{
			get
			{
				this.method_3(Enum61.const_17);
				return this.highlightMode_0;
			}
			set
			{
				this.highlightMode_0 = value;
				this.enum61_0 |= Enum61.const_17;
				this.vmethod_1();
			}
		}

		[Browsable(false)]
		public int Int32_0
		{
			get
			{
				this.method_3(Enum61.const_11);
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
				this.enum61_0 |= Enum61.const_11;
				this.vmethod_1();
			}
		}

		/// <summary>Specifies whether a text field's text is checked on misspelled words.</summary>
		[Browsable(false)]
		[DefaultValue(true)]
		public bool IsSpellCheckingEnabled
		{
			get
			{
				this.method_3(Enum61.const_16);
				return this.bool_4;
			}
			set
			{
				this.bool_4 = value;
				this.enum61_0 |= Enum61.const_16;
				this.vmethod_1();
			}
		}

		/// <summary>Gets the number of characters in a text field.</summary>
		[Browsable(false)]
		[DefaultValue(-1)]
		public int Length
		{
			get
			{
				this.method_3(Enum61.const_4);
				return this.int_2;
			}
		}

		/// <summary>Relates a user-defined name to a text field.</summary>
		[Browsable(false)]
		public string Name
		{
			get
			{
				this.method_3(Enum61.const_10);
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
				this.enum61_0 |= Enum61.const_10;
				this.vmethod_1();
			}
		}

		/// <summary>Obsolete. Specifies whether a text field toggles its background to gray, if the current input position is in the field.</summary>
		[Browsable(false)]
		[Obsolete]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DefaultValue(false)]
		public bool ShowActivated
		{
			get
			{
				this.method_3(Enum61.const_5);
				return this.bool_5;
			}
			set
			{
				this.bool_5 = value;
				this.enum61_0 |= Enum61.const_5;
				this.vmethod_1();
			}
		}

		/// <summary>Gets the first character position (one-based) of a text field.</summary>
		[DefaultValue(-1)]
		[Browsable(false)]
		public int Start
		{
			get
			{
				this.method_3(Enum61.const_7);
				return this.int_3;
			}
		}

		/// <summary>Returns or sets the text which is contained within a text field.</summary>
		[Browsable(false)]
		public string Text
		{
			get
			{
				this.method_3(Enum61.const_8);
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
				if (this.int_0 != 0 && this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					this.textControlCore_0.method_37(this.textPart_0, 1628, this.int_0, this.string_1);
				}
			}
		}

		[Browsable(false)]
		internal int Int32_1
		{
			get
			{
				this.method_3(Enum61.const_19);
				return this.int_4;
			}
			set
			{
				this.int_4 = value;
				this.enum61_0 |= Enum61.const_19;
				this.vmethod_1();
			}
		}

		[Browsable(false)]
		internal bool Boolean_0
		{
			get
			{
				this.method_3(Enum61.const_21);
				return this.bool_7;
			}
			set
			{
				this.bool_7 = value;
				this.enum61_0 |= Enum61.const_21;
				this.vmethod_1();
			}
		}

		[Browsable(false)]
		internal AutoGenerationType AutoGenerationType_0
		{
			get
			{
				this.method_3(Enum61.const_22);
				return this.autoGenerationType_0;
			}
		}

		[Browsable(false)]
		internal bool Boolean_1
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					Struct78 struct78_ = new Struct78(bool_3: false);
					int num = this.textControlCore_0.method_81(Enum83.const_334, ref struct78_);
					if (num == 1)
					{
						return this.int_0 == struct78_.ushort_2;
					}
					return false;
				}
				return this.bool_8;
			}
			set
			{
				this.bool_8 = value;
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					this.textControlCore_0.method_30(Enum83.const_335, this.int_0, value ? 1 : 0);
				}
			}
		}

		[Browsable(false)]
		internal int Int32_2
		{
			get
			{
				this.method_3(Enum61.const_12);
				return this.int_5;
			}
			set
			{
				this.int_5 = value;
				this.enum61_0 |= Enum61.const_12;
				this.vmethod_1();
			}
		}

		[Browsable(false)]
		internal Struct43 Struct43_0
		{
			get
			{
				this.method_3(Enum61.const_20);
				return this.struct43_0;
			}
			set
			{
				this.struct43_0 = value;
				this.enum61_0 |= Enum61.const_20;
				this.vmethod_1();
			}
		}

		[Browsable(false)]
		internal string String_0
		{
			get
			{
				this.method_3(Enum61.const_9);
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
				this.enum61_0 |= Enum61.const_9;
				this.vmethod_1();
			}
		}

		[Browsable(false)]
		internal string[] String_1
		{
			get
			{
				this.method_3(Enum61.const_13);
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
				this.enum61_0 |= Enum61.const_13;
				this.vmethod_1();
			}
		}

		[Browsable(false)]
		private uint UInt32_0
		{
			get
			{
				Enum62 @enum = (Enum62)0;
				Enum63 enum2 = (Enum63)0;
				if ((this.enum61_0 & Enum61.const_0) != 0)
				{
					@enum |= ((!this.bool_0) ? Enum62.const_0 : Enum62.const_8);
				}
				if ((this.enum61_0 & Enum61.const_1) != 0)
				{
					@enum |= (this.bool_1 ? Enum62.const_4 : Enum62.const_12);
				}
				if ((this.enum61_0 & Enum61.const_2) != 0)
				{
					@enum |= (this.bool_2 ? Enum62.const_9 : Enum62.const_1);
				}
				if ((this.enum61_0 & Enum61.const_3) != 0)
				{
					@enum |= (this.bool_3 ? Enum62.const_14 : Enum62.const_6);
				}
				if ((this.enum61_0 & Enum61.const_5) != 0)
				{
					@enum |= (this.bool_5 ? Enum62.const_3 : Enum62.const_11);
				}
				if ((this.enum61_0 & Enum61.const_6) != 0)
				{
					@enum |= (this.bool_6 ? Enum62.const_5 : Enum62.const_13);
				}
				if ((this.enum61_0 & Enum61.const_16) != 0)
				{
					enum2 |= ((!this.bool_4) ? Enum63.const_0 : Enum63.const_4);
				}
				if ((this.enum61_0 & Enum61.const_21) != 0)
				{
					enum2 |= (this.bool_7 ? Enum63.const_6 : Enum63.const_2);
				}
				if ((this.enum61_0 & Enum61.const_17) != 0)
				{
					if (this.highlightMode_0 == HighlightMode.Activated)
					{
						@enum |= Enum62.const_3;
					}
					if (this.highlightMode_0 == HighlightMode.Never)
					{
						@enum |= Enum62.const_11;
					}
					if (this.highlightMode_0 == HighlightMode.Always)
					{
						enum2 |= Enum63.const_1;
					}
				}
				return (uint)Class429.smethod_3((int)@enum, (int)enum2);
			}
		}

		/// <summary>Creates an empty TextField object.</summary>
		public TextField()
		{
		}

		/// <summary>Creates a TextField object with the specified visible text.</summary>
		/// <param name="text">Specifies the visible text of the text field.</param>
		public TextField(string text)
		{
			this.string_1 = text;
			this.enum61_0 |= Enum61.const_8;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal TextField(TextControlCore textControlCore_1, TextPart iTextPart, int iFieldID)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_0 = iFieldID;
			this.textPart_0 = iTextPart;
		}

		public override bool Equals(object obj)
		{
			if (obj != null && !(obj.GetType() != base.GetType()))
			{
				TextField textField = (TextField)obj;
				if (this.int_0 != 0 && textField.int_0 != 0)
				{
					return this.int_0 == textField.int_0;
				}
				return base.Equals(obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (this.int_0 == 0)
			{
				return base.GetHashCode();
			}
			return this.int_0;
		}

		/// <summary>Sets the current input position to the beginning of a text field and scrolls it into the visible part of the document.</summary>
		public bool ScrollTo()
		{
			return this.textControlCore_0.method_29(this.textPart_0, 1654, 0, this.int_0) != 0;
		}

		internal void method_0(TextControlCore textControlCore_1, int int_6, TextPart textPart_1)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_0 = int_6;
			this.textPart_0 = textPart_1;
		}

		internal virtual void vmethod_0(bool bool_9)
		{
			if (bool_9)
			{
				this.method_3((Enum61)3072);
			}
			this.textControlCore_0 = null;
		}

		internal bool method_1(TextControlCore textControlCore_1, TextPart textPart_1)
		{
			bool result = false;
			textControlCore_1.method_18(textPart_1);
			try
			{
				uint uint_ = this.UInt32_0 | (((textControlCore_1.enum56_0 & Enum56.const_1) != 0) ? 256u : 0u) | (this.bool_8 ? 1073741824u : 0u);
				textControlCore_1.method_19(textPart_1, null);
				textControlCore_1.method_23(bool_1: true);
				Struct57 struct57_ = new Struct57(this.string_1, uint_, (byte)this.enum105_0, this.int_4);
				if ((this.enum61_0 & Enum61.const_12) != 0)
				{
					struct57_.uint_1 = (uint)this.int_5;
				}
				else if ((this.enum61_0 & Enum61.const_20) != 0)
				{
					struct57_.uint_2 = this.struct43_0.UInt32_0;
					struct57_.intptr_0 = this.struct43_0.method_0();
				}
				else if ((this.enum61_0 & Enum61.const_9) != 0)
				{
					if (this.string_2 != null && this.string_2.Length > 0)
					{
						struct57_.uint_2 = (uint)((this.string_2.Length + 1) * 2);
						struct57_.intptr_0 = Marshal.StringToHGlobalUni(this.string_2);
					}
				}
				else if ((this.enum61_0 & Enum61.const_13) != 0 && this.string_3 != null)
				{
					char[] array = KernelHelper.StringArray2CharArray(this.string_3);
					if (array != null)
					{
						struct57_.uint_2 = (uint)(array.Length * 2);
						struct57_.intptr_0 = Marshal.AllocHGlobal((int)struct57_.uint_2);
						Marshal.Copy(array, 0, struct57_.intptr_0, array.Length);
					}
				}
				int num = textControlCore_1.method_56(textPart_1, Enum83.const_333, 0, ref struct57_);
				if (num != 0)
				{
					this.enum61_0 &= (Enum61)(-8073840);
					this.method_0(textControlCore_1, num, textPart_1);
					this.vmethod_1();
					return true;
				}
				return result;
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

		internal bool method_2(bool bool_9)
		{
			bool result = false;
			if (this.int_0 != 0 && this.textControlCore_0 != null)
			{
				int num = ((!bool_9) ? 1 : 0) | (((this.textControlCore_0.enum56_0 & Enum56.const_7) != 0) ? 2 : 0);
				if (result = this.textControlCore_0.method_29(this.textPart_0, 1231, this.int_0, num) != 0)
				{
					this.vmethod_0(bool_9: false);
				}
			}
			return result;
		}

		private void method_3(Enum61 enum61_2)
		{
			if (this.int_0 == 0 || this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated)
			{
				return;
			}
			if (((enum61_2 & Enum61.const_23) != 0 && (this.enum61_1 & Enum61.const_23) == 0) || ((enum61_2 & Enum61.const_18) != 0 && (this.enum61_1 & Enum61.const_18) == 0) || ((enum61_2 & Enum61.const_19) != 0 && (this.enum61_1 & Enum61.const_19) == 0))
			{
				Struct58 struct58_ = new Struct58(0u);
				if (this.textControlCore_0.method_57(this.textPart_0, Enum83.const_331, this.int_0, ref struct58_) != 0)
				{
					Enum62 @enum = (Enum62)Class429.smethod_5((int)struct58_.uint_0);
					Enum63 enum2 = (Enum63)Class429.smethod_6((int)struct58_.uint_0);
					if (@enum != 0)
					{
						this.bool_0 = (@enum & Enum62.const_8) != 0;
						this.bool_1 = (@enum & Enum62.const_4) != 0;
						this.bool_2 = (@enum & Enum62.const_9) != 0;
						this.bool_3 = (@enum & Enum62.const_6) == 0;
						this.bool_5 = (@enum & Enum62.const_3) != 0;
						this.bool_6 = (@enum & Enum62.const_5) != 0;
					}
					if (enum2 != 0)
					{
						this.bool_4 = (enum2 & Enum63.const_4) != 0;
						this.bool_7 = (enum2 & Enum63.const_6) != 0;
						this.autoGenerationType_0 = (((enum2 & Enum63.const_3) == 0) ? AutoGenerationType.None : AutoGenerationType.TableOfContents);
					}
					this.highlightMode_0 = (((@enum & Enum62.const_3) != 0) ? HighlightMode.Activated : (((enum2 & Enum63.const_1) == 0) ? HighlightMode.Never : HighlightMode.Always));
					this.color_0 = Class429.smethod_2((int)struct58_.uint_1);
					if (struct58_.byte_0 < byte.MaxValue)
					{
						this.color_0 = Color.FromArgb(struct58_.byte_0, this.color_0);
					}
					this.int_4 = struct58_.ushort_1;
					this.enum61_1 |= (Enum61)7274607;
				}
			}
			if ((enum61_2 & Enum61.const_7) != 0 || (enum61_2 & Enum61.const_4) != 0 || (enum61_2 & Enum61.const_8) != 0)
			{
				this.int_3 = -1;
				this.int_2 = 0;
				this.string_1 = string.Empty;
				int[] array = new int[2];
				if (this.textControlCore_0.method_40(this.textPart_0, 1228, this.int_0, array) != 0)
				{
					this.int_3 = array[0];
					this.int_2 = 1 + array[1] - array[0];
					if ((enum61_2 & Enum61.const_8) != 0)
					{
						IntPtr intPtr = Marshal.AllocHGlobal((this.int_2 + 1) * 2);
						if (this.textControlCore_0.method_38(this.textPart_0, 1629, this.int_0, intPtr) != 0)
						{
							this.string_1 = Marshal.PtrToStringUni(intPtr);
						}
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
			if (((enum61_2 & Enum61.const_9) != 0 && (this.enum61_1 & Enum61.const_9) == 0) || ((enum61_2 & Enum61.const_13) != 0 && (this.enum61_1 & Enum61.const_13) == 0) || ((enum61_2 & Enum61.const_12) != 0 && (this.enum61_1 & Enum61.const_12) == 0) || (enum61_2 & Enum61.const_20) != 0)
			{
				Struct56 struct56_ = new Struct56((byte)this.enum105_0, 0u);
				try
				{
					this.textControlCore_0.method_55(this.textPart_0, Enum83.const_177, this.int_0, ref struct56_);
					if ((enum61_2 & Enum61.const_9) != 0)
					{
						this.string_2 = string.Empty;
						if (struct56_.intptr_1 != IntPtr.Zero && struct56_.uint_1 > 2)
						{
							this.string_2 = Marshal.PtrToStringUni(Class429.GlobalLock(struct56_.intptr_1), (int)struct56_.uint_1 / 2 - 1);
							Class429.GlobalUnlock(struct56_.intptr_1);
						}
						this.enum61_1 |= Enum61.const_9;
					}
					if ((enum61_2 & Enum61.const_13) != 0)
					{
						this.string_3 = null;
						if (struct56_.intptr_1 != IntPtr.Zero && struct56_.uint_1 != 0)
						{
							this.string_3 = KernelHelper.Ptr2StringArray(Class429.GlobalLock(struct56_.intptr_1));
							Class429.GlobalUnlock(struct56_.intptr_1);
						}
						this.enum61_1 |= Enum61.const_13;
					}
					if ((enum61_2 & Enum61.const_12) != 0)
					{
						this.int_5 = (int)struct56_.uint_0;
						this.enum61_1 |= Enum61.const_12;
					}
					if ((enum61_2 & Enum61.const_20) != 0)
					{
						IntPtr intPtr2 = Class429.GlobalLock(struct56_.intptr_1);
						this.struct43_0 = new Struct43(Marshal.ReadInt64(intPtr2), Marshal.PtrToStringUni(intPtr2 + 8));
						Class429.GlobalUnlock(struct56_.intptr_1);
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					struct56_.method_0();
				}
			}
			if (((enum61_2 & Enum61.const_10) != 0 && (this.enum61_1 & Enum61.const_10) == 0) || ((enum61_2 & Enum61.const_11) != 0 && (this.enum61_1 & Enum61.const_11) == 0))
			{
				Struct55 struct55_ = new Struct55(0);
				try
				{
					this.textControlCore_0.method_61(this.textPart_0, Enum83.const_75, this.int_0, ref struct55_);
					if ((enum61_2 & Enum61.const_10) != 0)
					{
						if (struct55_.intptr_1 != IntPtr.Zero)
						{
							IntPtr ptr = Class429.GlobalLock(struct55_.intptr_1);
							if (struct55_.uint_1 > 2 && Marshal.ReadByte(ptr, (int)(struct55_.uint_1 - 1)) == 0 && Marshal.ReadByte(ptr, (int)(struct55_.uint_1 - 2)) == 0)
							{
								this.string_0 = Marshal.PtrToStringUni(ptr, (int)struct55_.uint_1 / 2 - 1);
							}
							else
							{
								this.string_0 = Marshal.PtrToStringAnsi(ptr, (int)struct55_.uint_1);
							}
							Class429.GlobalUnlock(struct55_.intptr_1);
						}
						else
						{
							this.string_0 = string.Empty;
						}
						this.enum61_1 |= Enum61.const_10;
					}
					if ((enum61_2 & Enum61.const_11) != 0)
					{
						this.int_1 = (int)struct55_.uint_0;
						this.enum61_1 |= Enum61.const_11;
					}
				}
				catch (Exception ex2)
				{
					throw ex2;
				}
				finally
				{
					struct55_.method_0();
				}
			}
			if (((enum61_2 & Enum61.const_14) != 0 && (this.enum61_1 & Enum61.const_14) == 0) || ((enum61_2 & Enum61.const_15) != 0 && (this.enum61_1 & Enum61.const_15) == 0))
			{
				int[] array2 = new int[8];
				this.textControlCore_0.method_40(this.textPart_0, 1216, this.int_0, array2);
				this.rectangle_0 = new Rectangle(array2[0], array2[1], array2[2] - array2[0], array2[3] - array2[1]);
				this.rectangle_1 = new Rectangle(array2[4], array2[5], array2[6] - array2[4], array2[7] - array2[5]);
			}
		}

		internal virtual void vmethod_1()
		{
			if (this.int_0 == 0 || this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated)
			{
				return;
			}
			if ((this.enum61_0 & Enum61.const_23) != 0 || (this.enum61_0 & Enum61.const_18) != 0 || (this.enum61_0 & Enum61.const_19) != 0)
			{
				Struct58 struct58_ = new Struct58(this.UInt32_0);
				if ((this.enum61_0 & Enum61.const_18) != 0)
				{
					struct58_.uint_1 = (uint)Class429.smethod_0(this.color_0);
					struct58_.byte_0 = this.color_0.A;
				}
				if ((this.enum61_0 & Enum61.const_19) != 0)
				{
					struct58_.ushort_1 = (ushort)this.int_4;
				}
				this.textControlCore_0.method_57(this.textPart_0, Enum83.const_332, this.int_0, ref struct58_);
			}
			if ((this.enum61_0 & Enum61.const_9) != 0 || (this.enum61_0 & Enum61.const_13) != 0 || (this.enum61_0 & Enum61.const_12) != 0 || (this.enum61_0 & Enum61.const_20) != 0)
			{
				Struct56 struct56_ = (((this.enum61_0 & Enum61.const_9) != 0) ? new Struct56((byte)this.enum105_0, this.string_2) : (((this.enum61_0 & Enum61.const_13) != 0) ? new Struct56((byte)this.enum105_0, this.string_3) : (((this.enum61_0 & Enum61.const_20) == 0) ? new Struct56((byte)this.enum105_0, (uint)this.int_5) : new Struct56((byte)this.enum105_0, this.struct43_0))));
				try
				{
					this.textControlCore_0.method_55(this.textPart_0, Enum83.const_179, this.int_0, ref struct56_);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					struct56_.method_0();
				}
			}
			if ((this.enum61_0 & Enum61.const_10) != 0 || (this.enum61_0 & Enum61.const_11) != 0)
			{
				if ((this.enum61_0 & Enum61.const_10) == 0)
				{
					this.method_3(Enum61.const_10);
				}
				if ((this.enum61_0 & Enum61.const_11) == 0)
				{
					this.method_3(Enum61.const_11);
				}
				Struct55 struct55_ = new Struct55(this.int_1, this.string_0);
				try
				{
					this.textControlCore_0.method_61(this.textPart_0, Enum83.const_82, this.int_0, ref struct55_);
				}
				catch (Exception ex2)
				{
					throw ex2;
				}
				finally
				{
					struct55_.method_0();
				}
			}
			this.enum61_0 = (Enum61)0;
		}
	}
}
