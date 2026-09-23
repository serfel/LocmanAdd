using System;
using System.ComponentModel;
using ns21;

namespace TXTextControl
{
	/// <summary>A DateFormField object represents a date field on a form.</summary>
	public class DateFormField : FormField
	{
		/// <summary>Gets or sets the DateFormField's date.</summary>
		public DateTime? Date
		{
			get
			{
				Struct43 @struct = base.Struct43_0;
				if (@struct.long_0 != 0L)
				{
					return DateTime.FromFileTimeUtc(@struct.long_0);
				}
				return null;
			}
			set
			{
				base.Struct43_0 = new Struct43(string_1: base.Struct43_0.string_0, long_1: (!value.HasValue) ? 0L : value.Value.ToFileTimeUtc());
			}
		}

		/// <summary>Gets or sets the date's format.</summary>
		public string DateFormat
		{
			get
			{
				return base.Struct43_0.string_0;
			}
			set
			{
				base.Struct43_0 = new Struct43(base.Struct43_0.long_0, value);
			}
		}

		/// <summary>Gets or sets the horizontal extension, in twips, of the DateFormField, when a date is not set.</summary>
		[Browsable(false)]
		public int EmptyWidth
		{
			get
			{
				return base.Int32_1;
			}
			set
			{
				base.Int32_1 = value;
			}
		}

		/// <summary>Gets or sets a value indicating wheather a date control is shown below the DateFormField so that the user can select a date.</summary>
		[Browsable(false)]
		public bool IsDateControlVisible
		{
			get
			{
				return base.Boolean_1;
			}
			set
			{
				base.Boolean_1 = value;
			}
		}

		/// <summary>Gets an array of format picture strings which can be used to format the date.</summary>
		public string[] SupportedDateFormats
		{
			get
			{
				string[] result = null;
				IntPtr intPtr = base.textControlCore_0.method_66(Enum83.const_337, (uint)base.int_0, 0);
				if (intPtr != IntPtr.Zero)
				{
					result = KernelHelper.Ptr2StringArray(Class429.GlobalLock(intPtr));
					Class429.GlobalUnlock(intPtr);
					Class429.GlobalFree(intPtr);
				}
				return result;
			}
		}

		/// <summary>Initializes a new instance of an empty DateFormField. The date is set to January 1, 1601.</summary>
		/// <param name="emptyWidth">Specifies the horizontal extension, in twips, of the DateFormField, when a date is not set.</param>
		public DateFormField(int emptyWidth)
		{
			base.Int32_1 = emptyWidth;
			base.Struct43_0 = new Struct43(0L, string.Empty);
			base.enum105_0 = Enum105.const_11;
		}

		/// <summary>Initializes a new instance of a DateFormField with the specified date.</summary>
		/// <param name="date">Specifies the date of the DateFormField.</param>
		/// <param name="emptyWidth">Specifies the horizontal extension, in twips, of the DateFormField, when a date is not set.</param>
		public DateFormField(DateTime date, int emptyWidth)
		{
			base.Int32_1 = emptyWidth;
			base.Struct43_0 = new Struct43(date.ToFileTimeUtc(), string.Empty);
			base.enum105_0 = Enum105.const_11;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal DateFormField(TextControlCore textControlCore_1, TextPart iTextPart, int iFieldID)
			: base(textControlCore_1, iTextPart, iFieldID)
		{
			base.enum105_0 = Enum105.const_11;
		}
	}
}
