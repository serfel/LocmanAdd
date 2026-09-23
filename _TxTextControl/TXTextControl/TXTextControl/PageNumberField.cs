using System.ComponentModel;
using ns21;

namespace TXTextControl
{
	/// <summary>The PageNumberField class represents a field in a header or footer of a Text Control document that automatically displays the current page number.</summary>
	public class PageNumberField : TextField
	{
		/// <summary>Gets or sets the number format.</summary>
		[Browsable(false)]
		public NumFormat NumberFormat
		{
			get
			{
				int num = Class429.smethod_6(base.Int32_2);
				if (num != 0)
				{
					return (NumFormat)num;
				}
				return NumFormat.ArabicNumbers;
			}
			set
			{
				int num = Class429.smethod_5(base.Int32_2);
				if (num == 0)
				{
					num = 1;
				}
				base.Int32_2 = Class429.smethod_3(num, (int)value);
			}
		}

		/// <summary>Gets or sets a value indicating whether the field shows the page number or the total number of pages.</summary>
		[Browsable(false)]
		public bool ShowNumberOfPages
		{
			get
			{
				if (base.enum105_0 != Enum105.const_3)
				{
					return true;
				}
				return false;
			}
			set
			{
				Enum105 @enum = (value ? Enum105.const_7 : Enum105.const_3);
				if (@enum != base.enum105_0)
				{
					base.enum105_0 = @enum;
					base.Int32_2 = base.Int32_2;
				}
			}
		}

		/// <summary>Gets or sets the page number for the first page.</summary>
		[Browsable(false)]
		public int StartNumber
		{
			get
			{
				int num = Class429.smethod_5(base.Int32_2);
				if (num != 0)
				{
					return num;
				}
				return 1;
			}
			set
			{
				int num = Class429.smethod_6(base.Int32_2);
				if (num == 0)
				{
					num = 3;
				}
				base.Int32_2 = Class429.smethod_3(value, num);
			}
		}

		/// <summary>Creates a new PageNumberField which displays Arabic numbers starting with 1.</summary>
		public PageNumberField()
		{
			base.Int32_2 = Class429.smethod_3(1, 3);
			base.enum105_0 = Enum105.const_3;
		}

		/// <summary>Creates a new PageNumberField which displays page numbers with the specified number format starting with the specified start number.</summary>
		/// <param name="startNumber">Specifies the page number for the first page.</param>
		/// <param name="numberFormat">Specifies the number format.</param>
		public PageNumberField(int startNumber, NumFormat numberFormat)
		{
			base.Int32_2 = Class429.smethod_3(startNumber, (int)numberFormat);
			base.enum105_0 = Enum105.const_3;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal PageNumberField(TextControlCore textControlCore_1, TextPart iTextPart, int iFieldID, Enum105 type)
			: base(textControlCore_1, iTextPart, iFieldID)
		{
			base.enum105_0 = type;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal PageNumberField(TextControlCore textControlCore_1, TextPart iTextPart, int iFieldID)
			: base(textControlCore_1, iTextPart, iFieldID)
		{
			Struct56 struct56_ = new Struct56(0, 0u)
			{
				ushort_2 = 1
			};
			textControlCore_1.method_55(iTextPart, Enum83.const_177, iFieldID, ref struct56_);
			base.enum105_0 = (Enum105)struct56_.byte_0;
		}

		/// <summary>Opens a dialog box to alter the formatting and numbering attributes of the page number field.</summary>
		public Selection.DialogResult PageNumberDialog()
		{
			if (base.textControlCore_0.GetTextControl().GetControlType() == Enum116.const_3)
			{
				return Selection.DialogResult.None;
			}
			if (base.int_0 != 0 && base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
			{
				return base.textControlCore_0.method_29(base.textPart_0, 1964, base.int_0, 0) switch
				{
					1 => Selection.DialogResult.Cancel, 
					2 => Selection.DialogResult.const_2, 
					_ => Selection.DialogResult.None, 
				};
			}
			return Selection.DialogResult.None;
		}
	}
}
