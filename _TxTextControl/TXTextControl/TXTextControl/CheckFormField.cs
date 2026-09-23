using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>The CheckFormField class represents a checkbox in a document.</summary>
	public class CheckFormField : FormField
	{
		/// <summary>Represents the default character which is used to display the checkbox in the checked state.</summary>
		public const char DefaultCheckedCharacter = '☒';

		/// <summary>Represents the default character which is used to display the checkbox in the unchecked state.</summary>
		public const char DefaultUncheckedCharacter = '☐';

		/// <summary>Gets or set a value indicating whether the checkbox is in the checked state.</summary>
		[Browsable(false)]
		public bool Checked
		{
			get
			{
				return base.Text[0] == Class429.smethod_5(base.Int32_2);
			}
			set
			{
				if (this.Checked != value)
				{
					base.textControlCore_0.method_64(base.textPart_0, Enum83.const_338, (uint)base.int_0, 0);
				}
			}
		}

		/// <summary>Gets or sets the character which is used to display the checkbox in the checked state.</summary>
		[Browsable(false)]
		public char CheckedCharacter
		{
			get
			{
				return Convert.ToChar(Class429.smethod_5(base.Int32_2));
			}
			set
			{
				int int32_ = base.Int32_2;
				if (value != Class429.smethod_5(int32_))
				{
					base.Int32_2 = Class429.smethod_3(value, Class429.smethod_6(int32_));
				}
			}
		}

		/// <summary>Gets or sets the character which is used to display the checkbox in the unchecked state.</summary>
		[Browsable(false)]
		public char UncheckedCharacter
		{
			get
			{
				return Convert.ToChar(Class429.smethod_6(base.Int32_2));
			}
			set
			{
				int int32_ = base.Int32_2;
				if (value != Class429.smethod_6(int32_))
				{
					base.Int32_2 = Class429.smethod_3(Class429.smethod_5(int32_), value);
				}
			}
		}

		/// <summary>Gets possible characters which can be used to display the checkbox in the checked state.</summary>
		public char[] SupportedCheckedCharacters
		{
			get
			{
				char[] result = null;
				IntPtr intPtr = base.textControlCore_0.method_66(Enum83.const_339, (uint)base.int_0, 0);
				if (intPtr != IntPtr.Zero)
				{
					string text = Marshal.PtrToStringUni(Class429.GlobalLock(intPtr));
					result = text.ToCharArray();
					Class429.GlobalUnlock(intPtr);
					Class429.GlobalFree(intPtr);
				}
				return result;
			}
		}

		/// <summary>Gets possible characters which can be used to display the checkbox in the unchecked state.</summary>
		public char[] SupportedUncheckedCharacters
		{
			get
			{
				char[] result = null;
				IntPtr intPtr = base.textControlCore_0.method_66(Enum83.const_339, (uint)base.int_0, 1);
				if (intPtr != IntPtr.Zero)
				{
					string text = Marshal.PtrToStringUni(Class429.GlobalLock(intPtr));
					result = text.ToCharArray();
					Class429.GlobalUnlock(intPtr);
					Class429.GlobalFree(intPtr);
				}
				return result;
			}
		}

		/// <summary>Initializes a new instance of the CheckFormField class.</summary>
		/// <param name="isChecked">Specifies whether the checkbox is initially checked or unchecked.</param>
		public CheckFormField(bool isChecked)
		{
			base.Int32_2 = Class429.smethod_3(9746, 9744);
			base.Text = (isChecked ? '☒'.ToString() : '☐'.ToString());
			base.enum105_0 = Enum105.const_8;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal CheckFormField(TextControlCore textControlCore_1, TextPart iTextPart, int iFieldID)
			: base(textControlCore_1, iTextPart, iFieldID)
		{
			base.enum105_0 = Enum105.const_8;
		}
	}
}
