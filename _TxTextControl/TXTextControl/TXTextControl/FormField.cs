using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>The FormField class is the base class of all form fields.</summary>
	public class FormField : TextField
	{
		private enum Enum64
		{
			const_0 = 1,
			const_1
		}

		private Enum64 enum64_0;

		private Enum64 enum64_1;

		private string string_4 = string.Empty;

		private string string_5 = string.Empty;

		[Browsable(false)]
		internal string[] String_2
		{
			get
			{
				this.method_4(Enum64.const_0);
				if (!string.IsNullOrEmpty(this.string_4))
				{
					return this.string_4.Split('\u0001');
				}
				return null;
			}
			set
			{
				if ((this.enum64_0 & Enum64.const_1) == 0)
				{
					this.method_4(Enum64.const_1);
				}
				this.string_4 = ((value == null || value.Length == 0 || string.IsNullOrEmpty(value[0])) ? string.Empty : string.Join("\u0001", value));
				this.enum64_0 |= Enum64.const_0;
				this.vmethod_1();
			}
		}

		/// <summary>Gets or set a value indicating whether the form field is enabled.</summary>
		[Browsable(false)]
		public bool Enabled
		{
			get
			{
				return base.Boolean_0;
			}
			set
			{
				base.Boolean_0 = value;
			}
		}

		[Browsable(false)]
		internal string[] String_3
		{
			get
			{
				this.method_4(Enum64.const_0);
				if (!string.IsNullOrEmpty(this.string_5))
				{
					return this.string_5.Split('\u0001');
				}
				return null;
			}
			set
			{
				if ((this.enum64_0 & Enum64.const_0) == 0)
				{
					this.method_4(Enum64.const_0);
				}
				this.string_5 = ((value == null || value.Length == 0 || string.IsNullOrEmpty(value[0])) ? string.Empty : string.Join("\u0001", value));
				this.enum64_0 |= Enum64.const_1;
				this.vmethod_1();
			}
		}

		internal FormField()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal FormField(TextControlCore textControlCore_1, TextPart iTextPart, int iFieldID)
			: base(textControlCore_1, iTextPart, iFieldID)
		{
		}

		internal override void vmethod_0(bool bool_9)
		{
			if (bool_9)
			{
				this.method_4((Enum64)3);
			}
		}

		private void method_4(Enum64 enum64_2)
		{
			if (base.int_0 == 0 || base.textControlCore_0 == null || !base.textControlCore_0.isHandleCreated || (((enum64_2 & Enum64.const_0) == 0 || (this.enum64_1 & Enum64.const_0) != 0) && ((enum64_2 & Enum64.const_1) == 0 || (this.enum64_1 & Enum64.const_1) != 0)))
			{
				return;
			}
			Struct56 struct56_ = new Struct56((byte)base.enum105_0, 0u)
			{
				ushort_2 = 4
			};
			try
			{
				base.textControlCore_0.method_55(base.textPart_0, Enum83.const_177, base.int_0, ref struct56_);
				this.string_4 = string.Empty;
				this.string_5 = string.Empty;
				if (struct56_.intptr_1 != IntPtr.Zero && struct56_.uint_1 > 2)
				{
					string text = Marshal.PtrToStringUni(Class429.GlobalLock(struct56_.intptr_1), (int)struct56_.uint_1 / 2 - 1);
					string[] array = text.Split('\u0002');
					if (array.Length == 2)
					{
						this.string_4 = array[0];
						this.string_5 = array[1];
					}
					Class429.GlobalUnlock(struct56_.intptr_1);
				}
				this.enum64_1 |= (Enum64)3;
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

		internal override void vmethod_1()
		{
			if (base.int_0 == 0 || base.textControlCore_0 == null || !base.textControlCore_0.isHandleCreated)
			{
				return;
			}
			base.vmethod_1();
			if ((this.enum64_0 & Enum64.const_0) != 0 || (this.enum64_0 & Enum64.const_1) != 0)
			{
				string text = ((!string.IsNullOrEmpty(this.string_4) || !string.IsNullOrEmpty(this.string_5)) ? string.Join("\u0002", this.string_4, this.string_5) : string.Empty);
				Struct56 struct56_ = new Struct56((byte)base.enum105_0, text)
				{
					ushort_2 = 4
				};
				try
				{
					base.textControlCore_0.method_55(base.textPart_0, Enum83.const_179, base.int_0, ref struct56_);
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
			this.enum64_0 = (Enum64)0;
		}
	}
}
