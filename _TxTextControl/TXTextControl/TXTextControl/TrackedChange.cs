using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>A TrackedChange object represents a change made to the document after anyone has revised the document.</summary>
	public class TrackedChange
	{
		private enum Enum82
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
			const_10 = 0x3FF
		}

		private static Color color_0 = Color.FromArgb(60, 255, 0, 0);

		internal TextControlCore textControlCore_0;

		private int int_0;

		private int int_1;

		private TextPart textPart_0;

		private Enum82 enum82_0;

		private Enum82 enum82_1;

		private bool bool_0 = true;

		private ChangeKind changeKind_0;

		private DateTime dateTime_0;

		private Color color_1 = TrackedChange.color_0;

		private HighlightMode highlightMode_0 = HighlightMode.Always;

		private int int_2;

		private int int_3;

		private string string_0 = string.Empty;

		/// <summary>Gets or sets a value specifying whether the TrackedChange is currently active or not.</summary>
		public bool Active
		{
			get
			{
				this.method_2(Enum82.const_9);
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				this.enum82_1 |= Enum82.const_9;
				this.method_0();
			}
		}

		/// <summary>Gets the kind of change.</summary>
		public ChangeKind ChangeKind
		{
			get
			{
				this.method_2(Enum82.const_4);
				return this.changeKind_0;
			}
		}

		/// <summary>Gets the date and time when the change has been made.</summary>
		public DateTime ChangeTime
		{
			get
			{
				this.method_2(Enum82.const_5);
				return this.dateTime_0;
			}
		}

		/// <summary>Gets the default highlight color of a tracked change.</summary>
		public static Color DefaultHighlightColor => TrackedChange.color_0;

		/// <summary>Gets or sets the highlight color for the tracked change.</summary>
		public Color HighlightColor
		{
			get
			{
				this.method_2(Enum82.const_6);
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
				this.enum82_1 |= Enum82.const_6;
				this.method_0();
			}
		}

		/// <summary>Gets or sets a value indicating whether the tracked change is highlighted.</summary>
		public HighlightMode HighlightMode
		{
			get
			{
				this.method_2(Enum82.const_7);
				return this.highlightMode_0;
			}
			set
			{
				if (value == HighlightMode.Activated)
				{
					throw new ArgumentException();
				}
				this.highlightMode_0 = value;
				this.enum82_1 |= Enum82.const_7;
				this.method_0();
			}
		}

		/// <summary>Gets the number of changed characters.</summary>
		public int Length
		{
			get
			{
				this.method_2(Enum82.const_1);
				return this.int_2;
			}
		}

		/// <summary>Gets the change's number.</summary>
		public int Number
		{
			get
			{
				if (this.int_0 == 0)
				{
					this.method_2(Enum82.const_3);
				}
				return this.int_0;
			}
		}

		/// <summary>Gets the index (one-based) of the first changed character.</summary>
		public int Start
		{
			get
			{
				this.method_2(Enum82.const_0);
				return this.int_3;
			}
		}

		/// <summary>Gets the changed text.</summary>
		public string Text
		{
			get
			{
				this.Save(out var stringData, StringStreamType.PlainText);
				return stringData;
			}
		}

		/// <summary>Gets the name of the user who has changed the document.</summary>
		public string UserName
		{
			get
			{
				this.method_2(Enum82.const_2);
				return this.string_0;
			}
		}

		internal TrackedChange(int iInternalID, string userName, ChangeKind changeKind, DateTime changeTime)
		{
			this.int_1 = iInternalID;
			this.string_0 = userName;
			this.changeKind_0 = changeKind;
			this.dateTime_0 = changeTime;
		}

		internal TrackedChange(TextControlCore textControlCore_1, TextPart iTextPart, int iNumber, int iInternalID)
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
				TrackedChange trackedChange = (TrackedChange)obj;
				if (this.int_1 != 0 && trackedChange.int_1 != 0)
				{
					return this.int_1 == trackedChange.int_1;
				}
				return base.Equals(obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (this.int_1 == 0)
			{
				this.method_2(Enum82.const_8);
			}
			if (this.int_1 == 0)
			{
				return base.GetHashCode();
			}
			return this.int_1;
		}

		/// <summary>Saves the changed text in a byte array with the specified format.</summary>
		/// <param name="binaryData">Specifies a byte array into which the changed text is saved.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		public void Save(out byte[] binaryData, BinaryStreamType binaryStreamType)
		{
			this.Save(out binaryData, binaryStreamType, new SaveSettings());
		}

		/// <summary>Saves the changed text as a string with the specified format.</summary>
		/// <param name="stringData">Specifies a string into which the changed text is saved.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		public void Save(out string stringData, StringStreamType stringStreamType)
		{
			this.Save(out stringData, stringStreamType, new SaveSettings());
		}

		/// <summary>Saves the changed text in a byte array with the specified format and special settings.</summary>
		/// <param name="binaryData">Specifies a byte array into which the changed text is saved.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(out byte[] binaryData, BinaryStreamType binaryStreamType, SaveSettings saveSettings)
		{
			saveSettings.TextPart = this.textPart_0;
			this.textControlCore_0.method_16(this.textPart_0, this.Start - 1, this.Length);
			saveSettings.method_3(out binaryData, binaryStreamType, this.textControlCore_0, Enum104.const_7);
			this.textControlCore_0.method_17(this.textPart_0);
		}

		/// <summary>Saves the changed text as a string with the specified format and special settings.</summary>
		/// <param name="stringData">Specifies a string into which the changed text is saved.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(out string stringData, StringStreamType stringStreamType, SaveSettings saveSettings)
		{
			saveSettings.TextPart = this.textPart_0;
			this.textControlCore_0.method_16(this.textPart_0, this.Start - 1, this.Length);
			saveSettings.method_4(out stringData, stringStreamType, this.textControlCore_0, Enum104.const_7);
			this.textControlCore_0.method_17(this.textPart_0);
		}

		/// <summary>Scrolls the beginning of the tracked change into the visible part of the document using a default position depending on the previous position.</summary>
		public bool ScrollTo()
		{
			return this.ScrollTo(InputPosition.ScrollPosition.Auto);
		}

		public bool ScrollTo(InputPosition.ScrollPosition position)
		{
			bool flag = false;
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, 0, this.string_0, Enum52.const_2);
			try
			{
				return this.textControlCore_0.method_58(this.textPart_0, Enum83.const_311, (int)position, ref struct46_) != IntPtr.Zero;
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

		/// <summary>Selects the changed part of the document.</summary>
		public bool Select()
		{
			bool result = false;
			if (this.textControlCore_0 != null)
			{
				this.textControlCore_0.method_5(this.textPart_0, this.Start - 1, this.Length);
				result = true;
			}
			return result;
		}

		internal void method_0()
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated && this.enum82_1 != 0 && (this.int_0 != 0 || this.int_1 != 0))
			{
				Struct46 struct46_ = new Struct46(this.int_1, this.int_0, 0, string.Empty, Enum52.const_2)
				{
					ushort_1 = 0,
					uint_2 = 2147483648u,
					uint_3 = uint.MaxValue,
					intptr_0 = IntPtr.Zero
				};
				if ((this.enum82_1 & Enum82.const_6) != 0)
				{
					struct46_.uint_2 = (uint)Class429.smethod_0(this.color_1);
					struct46_.byte_0 = this.color_1.A;
				}
				if ((this.enum82_1 & Enum82.const_7) != 0)
				{
					struct46_.ushort_1 = (ushort)((this.highlightMode_0 == HighlightMode.Activated) ? 1u : ((this.highlightMode_0 == HighlightMode.Always) ? 2u : 4u));
				}
				if ((this.enum82_1 & Enum82.const_9) != 0)
				{
					struct46_.ushort_1 |= (ushort)(this.bool_0 ? 16 : 32);
				}
				this.textControlCore_0.method_58(this.textPart_0, Enum83.const_308, 0, ref struct46_);
			}
		}

		internal bool method_1(TextControlCore textControlCore_1, TextPart textPart_1, int int_4)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = textPart_1;
			this.int_1 = int_4;
			this.method_2(Enum82.const_10);
			return this.enum82_0 == Enum82.const_10;
		}

		private void method_2(Enum82 enum82_2)
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated || (this.int_1 == 0 && this.int_0 == 0 && this.string_0 == string.Empty) || (enum82_2 & Enum82.const_10) == 0 || (this.enum82_0 & Enum82.const_10) != 0)
			{
				return;
			}
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, 0, this.string_0, Enum52.const_2);
			try
			{
				if (this.textControlCore_0.method_58(this.textPart_0, Enum83.const_310, 0, ref struct46_) != IntPtr.Zero)
				{
					this.int_0 = (int)struct46_.uint_4;
					this.int_1 = struct46_.ushort_4;
					this.int_3 = (int)(struct46_.uint_0 + 1);
					this.int_2 = (int)struct46_.uint_1;
					this.color_1 = Class429.smethod_2((int)struct46_.uint_2);
					if (struct46_.byte_0 < byte.MaxValue)
					{
						this.color_1 = Color.FromArgb(struct46_.byte_0, this.color_1);
					}
					this.highlightMode_0 = ((((uint)struct46_.ushort_1 & (true ? 1u : 0u)) != 0) ? HighlightMode.Activated : (((struct46_.ushort_1 & 2) == 0) ? HighlightMode.Never : HighlightMode.Always));
					if (struct46_.intptr_0 != IntPtr.Zero)
					{
						this.string_0 = Marshal.PtrToStringBSTR(struct46_.intptr_0);
					}
					this.changeKind_0 = (ChangeKind)(struct46_.ushort_1 & 0x7000);
					this.dateTime_0 = DateTime.FromFileTimeUtc((long)(((ulong)struct46_.uint_8 << 32) + struct46_.uint_7));
					this.bool_0 = (((struct46_.ushort_1 & 0x20) == 0) ? true : false);
					this.enum82_0 |= Enum82.const_10;
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

		internal bool method_3(bool bool_1)
		{
			bool result = false;
			if (this.textControlCore_0 != null)
			{
				Struct46 struct46_ = new Struct46(this.int_1, this.int_0, 0, null, Enum52.const_2);
				result = this.textControlCore_0.method_58(this.textPart_0, Enum83.const_326, bool_1 ? 1 : 0, ref struct46_) != IntPtr.Zero;
			}
			return result;
		}
	}
}
